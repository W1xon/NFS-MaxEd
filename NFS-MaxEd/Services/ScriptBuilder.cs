using System.Text;

namespace NFSMaxEd.Services;

public abstract class ScriptBuilder
{
    protected StringBuilder _commands = new();
    public abstract string Build();
}