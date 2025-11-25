using NFSMaxEd.Models;

namespace NFSMaxEd.Services;

public partial  class RaceScriptBuilder
{
    public RaceScriptBuilder(string path, RaceType nodeType)
    {
        _path = path;
        _nodeType = nodeType;
        AddMainNode(nodeType);
    }
    public RaceScriptBuilder AddField(string fieldName, object? value = null)
    {
        _fieldDeclarations.Add(
            value is null
                ? $"add_field gameplay {_path} {fieldName}"
                : $"add_field gameplay {_path} {fieldName} {value}"
        );
        return this;
    }
    public RaceScriptBuilder UpdateField<T>(string fieldName, T value)
    {
        _scalarUpdates.Add($"update_field gameplay {_path} {fieldName} {value}");
        return this;
    }
    public RaceScriptBuilder UpdateArrayItem(string arrayName, int index, string valuePath)
    {
        _arrayUpdates.Add($"update_field gameplay {_path} {arrayName}[{index}] {valuePath}");
        return this;
    }
    public RaceScriptBuilder UpdateArrayItemRelative(string arrayName, int index, string target)
    {
        var childPath = $"{_path}/{target}";
        _arrayUpdates.Add($"update_field gameplay {_path} {arrayName}[{index}] {childPath}");
        return this;
    }

    public RaceScriptBuilder ResizeArray(string arrayName, int count)
    {
        _arrayResizes.Add($"resize_field gameplay {_path} {arrayName} {count}");
        return this;
    }
    public RaceScriptBuilder AddFieldChild(string childName, string fieldName, object? value = null)
    {
        var childPath = $"{_path}/{childName}";
        _childNodes.Add(value is not null
            ? $"add_field gameplay {childPath} {fieldName} {value}"
            : $"add_field gameplay {childPath} {fieldName}");
        return this;
    }
    public RaceScriptBuilder UpdateFieldChildValue(string childName, string fieldName, object value)
    {
        var childPath = $"{_path}/{childName}";
        _childNodes.Add($"update_field gameplay {childPath} {fieldName} {value}");
        return this;
    }
    public RaceScriptBuilder UpdateNestedFieldChild(string childName, string fieldName, string subField, object value)
    {
        var childPath = $"{_path}/{childName}";
        _childNodes.Add($"update_field gameplay {childPath} {fieldName} {subField} {value}");
        return this;
    }
    public RaceScriptBuilder UpdateArrayItemChild(string childName, string arrayName, int index, string target)
    {
        var childPath = $"{_path}/{childName}";
        _arrayUpdates.Add($"update_field gameplay {childPath} {arrayName}[{index}] {childPath}/{target}");
        return this;
    }
    
    public RaceScriptBuilder UpdateFieldChildReference(string childName, string fieldName, string referenceName)
    {
        var childPath = $"{_path}/{childName}";
        _childNodes.Add($"update_field gameplay {childPath} {fieldName} {childPath}/{referenceName}");
        return this;
    }
    
    private RaceScriptBuilder AddChildToChildren(string childPath, bool autoincrement = true)
    {
        _childrenEntries.Add($"update_field gameplay {_path} Children[{_childIndex}] {childPath}");
        if(autoincrement)
            _childIndex++;
        return this;
    }
    
    public RaceScriptBuilder AddFieldCharacter(string trafficTriggerName, string childName, string fieldName, object? value = null)
    {
        var childPath = $"{_path}/{trafficTriggerName}/{childName}";
        _childNodes.Add(value is not null
            ? $"add_field gameplay {childPath} {fieldName} {value}"
            : $"add_field gameplay {childPath} {fieldName}");
        return this;
    }
    
    public RaceScriptBuilder UpdateFieldCharacterValue(string trafficTriggerName, string childName, string fieldName, object value)
    {
        var childPath = $"{_path}/{trafficTriggerName}/{childName}";
        _childNodes.Add($"update_field gameplay {childPath} {fieldName} {value}");
        return this;
    }
    
    public RaceScriptBuilder UpdateFieldChildReferenceToParent(string childName, string fieldName, string referenceName)
    {
        var childPath = $"{_path}/{childName}";
        _childNodes.Add($"update_field gameplay {childPath} {fieldName} {_path}/{referenceName}");
        return this;
    }
    
    public RaceScriptBuilder UpdateArrayItemChildToParent(string childName, string arrayName, int index, string target)
    {
        var childPath = $"{_path}/{childName}";
        _childNodes.Add($"update_field gameplay {childPath} {arrayName}[{index}] {_path}/{target}");
        return this;
    }
    
    public RaceScriptBuilder AddNodeComment(string nodeName, string? prefix = null)
    {
        var displayName = prefix != null ? $"{prefix}: {nodeName}" : nodeName;
        _childNodes.Add($"// ---------- {displayName.ToUpper()} ----------");
        return this;
    }
    public RaceScriptBuilder AddNode(string type, string nodePath)
    {
        _childNodes.Add($"add_node gameplay {type} {nodePath}");
        return this;
    }
    
    public RaceScriptBuilder ChangeVault(string nodePath, string vault)
    {
        _childNodes.Add($"change_vault gameplay {nodePath} {vault}");
        return this;
    }
    
    public RaceScriptBuilder InitializeNode(string type, string nodePath, string vault, string? commentPrefix = null)
    {
        var nodeName = nodePath.Split('/').Last();
        AddNodeComment(nodeName, commentPrefix);
        AddNode(type, nodePath);
        ChangeVault(nodePath, vault);
        return this;
    }
}