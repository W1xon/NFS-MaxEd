using NFSMaxEd.Models;

namespace NFSMaxEd.Services;

    public partial class RaceScriptBuilder : ScriptBuilder
    {
        private readonly string _path;
        private readonly RaceType _nodeType;
        private bool _isInitChildren = false;
        
        // Логические блоки команд
        private readonly List<string> _nodeCreation = [];
        private readonly List<string> _fieldDeclarations = [];
        private readonly List<string> _arrayUpdates = [];
        private readonly List<string> _scalarUpdates = [];
        private readonly List<string> _arrayResizes = [];
        private readonly List<string> _childNodes = [];
        private readonly List<string> _parentUpdates = [];
        private readonly List<string> _childrenEntries = [];
        private int _childIndex = 0;

        private void AddMainNode(RaceType nodeType)
        {
            _nodeCreation.Add($"add_node gameplay {nodeType} {_path}");
        }

        public RaceScriptBuilder ChangeVault(string vault)
        {
            _nodeCreation.Add($"change_vault gameplay {_path} {vault}");
            return this;
        }
        
        public RaceScriptBuilder EnableQR(bool enable)
        {
            return AddField("AvailableQR")
                .UpdateField("AvailableQR", enable ? "True" : "False");
        }


        public RaceScriptBuilder SetBarriers(int count)
        {
            return AddField("Barriers", count);
        }


        public RaceScriptBuilder UpdateBarrier(int index, string spline)
        {
            string prefix = spline.Contains('*') ? "*" : "";
            string cleanedSpline = spline.Replace("*", "");
            string valuePath = $"{prefix}BARRIER_SPLINE_{cleanedSpline}";

            return UpdateArrayItem("Barriers", index, valuePath);
        }


        public RaceScriptBuilder ResizeBarriers(int count)
        {
            return ResizeArray("Barriers", count);
        }


        public RaceScriptBuilder SetCashValue(int amount)
        {
            return AddField("CashValue").UpdateField("CashValue", amount);
        }

        public RaceScriptBuilder SetChanceOfRain(int chance)
        {
            return AddField("ChanceOfRain")
                .UpdateField("ChanceOfRain", chance);
        }

        public RaceScriptBuilder SetSkillLevel(int value)
        {
            return AddField("SkillLevel", value);
        }


        public RaceScriptBuilder SetCheckpoints(int count)
        {
            return AddField("Checkpoint", count)
                .AddField("CheckpointsVisible");
        }


        public RaceScriptBuilder UpdateCheckpoint(int index, string checkpointPath)
        {
            string formattedPath = checkpointPath.Contains("/")
                ? $"{_path}/{checkpointPath.Replace("/", "time_bonus_")}"
                : $"{_path}/{checkpointPath}";

            return UpdateArrayItem("Checkpoint", index, formattedPath);
        }



        public RaceScriptBuilder ResizeCheckpoints(int count)
        {
            return ResizeArray("Checkpoint", count);
        }


        public RaceScriptBuilder SetChildren(int count)
        {
            return AddField("Children", count);
        }


        public RaceScriptBuilder UpdateChild(int index, string childPath)
        {
            return UpdateArrayItem("Children", index, childPath);
        }


        public RaceScriptBuilder ResizeChildren(int count)
        {
            return ResizeArray("Children", count);
        }


        public RaceScriptBuilder EnableCops(bool enable = true)
        {
            return AddField("CopsInRace")
                .UpdateField("CopsInRace", enable ? "True" : "False");
        }


        public RaceScriptBuilder SetEventId(string id)
        {
            return AddField("EventID")
                .UpdateField("EventID", id);
        }


        public RaceScriptBuilder SetFinishCamera(string camera)
        {
            return AddField("FinishCamera")
                .UpdateField("FinishCamera", camera);
        }


        public RaceScriptBuilder SetGameplayVault(string vaultName)
        {
            return AddField("gameplayvault")
                .UpdateField("gameplayvault", vaultName);
        }


        public RaceScriptBuilder SetIntroNIS(string nisId)
        {
            return AddField("IntroNIS")
                .UpdateField("IntroNIS", nisId);
        }

        public RaceScriptBuilder SetPostRaceActivity(string postRaceActivity)
        {
            return AddField("PostRaceActivity")
                .UpdateField("PostRaceActivity", postRaceActivity);
        }

        public RaceScriptBuilder SetRivalBestTime(double rivalBestTime)
        {
            return AddField("RivalBestTime")
                .UpdateField("RivalBestTime", rivalBestTime);
        }

        public RaceScriptBuilder SetBossRace()
        {
            return AddField("BossRace")
                .UpdateField("BossRace", "True");
        }

        public RaceScriptBuilder SetForceHeatLevel(double forceHeatLevel)
        {
            return AddField("ForceHeatLevel")
                .UpdateField("ForceHeatLevel", forceHeatLevel);
        }

        public RaceScriptBuilder SetMaxHeatLevel(double maxHeatLevel)
        {
            return AddField("MaxHeatLevel")
                .UpdateField("MaxHeatLevel", maxHeatLevel);
        }

        public RaceScriptBuilder SetNumLaps(int laps)
        {
            return AddField("NumLaps")
                .UpdateField("NumLaps", laps);
        }


        public RaceScriptBuilder SetOpponents(int count)
        {
            return AddField("Opponents", count);
        }

        public RaceScriptBuilder SetProgressionLevel(int level)
        {
            return AddField("ProgressionLevel", level);
        }

        public RaceScriptBuilder UpdateOpponent(int index, string opponentPath, bool isCashgrab = false)
        {
            if(isCashgrab) return UpdateArrayItem("Opponents", index, $"{_path}/{opponentPath}");
            return UpdateArrayItem("Opponents", index, $"{_path.Split("/")[0]}/{opponentPath}");
        }


        public RaceScriptBuilder AddQuickRaceNis()
        {
            return AddField("QuickRaceNIS");
        }


        public RaceScriptBuilder SetRaceFinish()
        {
            return AddField("racefinish")
                .UpdateField("racefinish", $"{_path}/finishline");
        }

        public RaceScriptBuilder SetRaceStart()
        {
            return AddField("racestart")
                .UpdateField("racestart", $"{_path}/startgrid");
        }

        public RaceScriptBuilder SetRaceLength(int length)
        {
            return AddField("RaceLength")
                .UpdateField("RaceLength", length);
        }


        public RaceScriptBuilder SetRegion(string region)
        {
            return AddField("Region")
                .UpdateField("Region", region);
        }

        public RaceScriptBuilder SetShortcuts(int count)
        {
            return AddField("Shortcuts", count);
        }


        public RaceScriptBuilder UpdateShortcut(int index, string shortcutPath)
        {
            return UpdateArrayItem("Shortcuts", index, $"{_path}/{shortcutPath}");
        }

        public RaceScriptBuilder ResizeShortcuts(int count)
        {
            return ResizeArray("Shortcuts", count);
        }


        public RaceScriptBuilder SetTemplate(string templateName)
        {
            return AddField("Template");
        }

        public RaceScriptBuilder SetTrafficLevel(int level)
        {
            return AddField("TrafficLevel")
                .UpdateField("TrafficLevel", level);
        }

        public RaceScriptBuilder SetReputation(int reputation)
        {
            return AddField("Reputation")
                .UpdateField("Reputation", reputation);
        }

        public RaceScriptBuilder SetChildrenEntry(int count = 1000)
        {
            if (!_isInitChildren)
            {
                _isInitChildren = true;
                AddField("Children", count);
            }
            return this;
        }


        public RaceScriptBuilder ResizeChildrenEntry(int count)
        {
            return ResizeArray("Children", count);
        }

        
        public RaceScriptBuilder SetTimeLimit(int limit)
        {
            return AddField("TimeLimit")
                .UpdateField("TimeLimit", limit);
        }


        public RaceScriptBuilder SetSpeedTrapList(IList<SpeedtrapEntity> speedTraps)
        {
            int count = speedTraps.Count;
            AddField("SpeedTrapList", count); 
        
            for (int i = 0; i < count; i++)
            {
                UpdateArrayItemRelative("SpeedTrapList", i, speedTraps[i].Name);
            }
        
            ResizeArray("SpeedTrapList", count);
            return this;
        }



        public RaceScriptBuilder SetRandomSpawnTriggers(IList<TrafficSpawnTrigger> triggers)
        {
            int count = triggers.Count;
            AddField("RandomSpawnTriggers", count);

            for (int i = 0; i < count; i++)
            {
                UpdateArrayItem("RandomSpawnTriggers", i, triggers[i].Name);
            }

            ResizeArray("RandomSpawnTriggers", count);
            return this;
        }


        public RaceScriptBuilder AddChildNode(EntityType type, string childName, Dictionary<string, object> properties, bool addToChildrens = true)
        {
            var childPath = $"{_path}/{childName}";
            var vault = _path.Split('/')[1];

            InitializeNode(type.ToString(), childPath, vault);
            // Добавление всех полей
            foreach (var prop in properties.Keys)
            {
                if(type == EntityType.trafficspawntrigger && prop == "Children") 
                    continue;
                
                if (prop == "Children" && properties[prop] is not null)
                {
                    AddFieldChild(childName, prop, 1);
                }
                else
                {
                    AddFieldChild(childName, prop);
                }
            }
        
            foreach (var (key, value) in properties)
            {
                if (key == "Position" && value is Dictionary<string, object> pos)
                {
                    foreach (var (axis, coordinate) in pos)
                    {
                        UpdateNestedFieldChild(childName, "Position", axis, coordinate);
                    }
                }
                
                else if (key == "Dimensions" && value is Dictionary<string, object> dim)
                {
                    foreach (var (axis, coordinate) in dim)
                    {
                        UpdateNestedFieldChild(childName, "Dimensions", axis, coordinate);
                    }
                }
                else if (key == "Children" && value is not null)
                {
                    UpdateArrayItemChild(childName, "Children", 0, value.ToString()!);
                }
                else if (key == "TrafficCharacter" && value is not null)
                {
                    UpdateFieldChildReference(childName, key, value.ToString()!);
                }
                else if(key != "Template" && value is not null)
                {
                    UpdateFieldChildValue(childName, key, value);
                }
            }
            
            AddChildToChildren(childPath, addToChildrens );

            
            return this;
        }

        public RaceScriptBuilder AddCharacter(string type, string trafficTriggerName, string childName, Dictionary<string, object> properties)
        {
            var childPath = $"{_path}/{trafficTriggerName}/{childName}";
            var vault = _path.Split('/')[0];

            InitializeNode(type, childPath, vault, trafficTriggerName.ToUpper());
 
            // Добавление всех полей
            foreach (var prop in properties.Keys)
            {
                AddFieldCharacter(trafficTriggerName, childName, prop);
            }
    
            // Обновление значений полей
            foreach (var (key, value) in properties)
            { 
                if(key != "Template")
                {
                    UpdateFieldCharacterValue(trafficTriggerName, childName, key, value);
                }
            }
            return this;
        }
        public RaceScriptBuilder AddCashgrabCharacter(string type, string childName, Dictionary<string, object> properties)
        {
            var childPath = $"{_path}/{childName}";
                var vault = _path.Split('/')[1];
            
                InitializeNode(type, childPath, vault);
 
            // Добавление всех полей
            foreach (var prop in properties.Keys)
            {
                if(prop == "Children" || prop == "CannedPath") 
                    continue;
     
                AddFieldChild(childName, prop);
            }
    
            // Обновление значений полей
            foreach (var (key, value) in properties)
            {
                if (key == "ForceStartPosition" && value is not null)
                {
                    UpdateFieldChildReferenceToParent(childName, key, value.ToString()!);
                }
                else if (key == "Children" && value is not null)
                {
                    AddFieldChild(childName, "Children", 1);
                    UpdateArrayItemChildToParent(childName, "Children", 0, value.ToString()!);
                }
                else if (key == "CannedPath" && value is List<string> moneybags)
                {
                    AddFieldChild(childName, "CannedPath", moneybags.Count);
                    for (int index = 0; index < moneybags.Count; index++)
                    {
                        UpdateArrayItemChildToParent(childName, "CannedPath", index, moneybags[index]);
                    }
                }
                else if(key != "Template" && value is not null)
                {
                    UpdateFieldChildValue(childName, key, value);
                }
            }
    
            AddChildToChildren(childPath);
            return this;
        }
        public RaceScriptBuilder SetCashRewards(IList<Moneybag> cashRewards)
        {
            int count = cashRewards.Count;
            AddField("CashRewards", count); 

            for (int i = 0; i < count; i++)
            {
                UpdateArrayItemRelative("CashRewards", i, cashRewards[i].Name);
            }

            ResizeArray("CashRewards", count);
            return this;
        }


        public override string Build()
        {
            // 1. Создание основного узла
            if (_nodeCreation.Any())
            {
                _commands.AppendLine("// ========== MAIN CIRCUIT NODE ==========");
                _commands.AppendLine(string.Join("\n", _nodeCreation));
                _commands.AppendLine();
            }

            // 2. Объявление полей
            if (_fieldDeclarations.Any())
            {
                _commands.AppendLine("// ---------- Field Declarations ----------");
                _commands.AppendLine(string.Join("\n", _fieldDeclarations));
                _commands.AppendLine();
            }

            // 3. Обновление массивов
            if (_arrayUpdates.Any())
            {
                _commands.AppendLine("// ---------- Array Field Updates ----------");
                _commands.AppendLine(string.Join("\n", _arrayUpdates));
                _commands.AppendLine();
            }

            // 4. Изменение размеров массивов
            if (_arrayResizes.Any())
            {
                _commands.AppendLine("// ---------- Array Resizing ----------");
                _commands.AppendLine(string.Join("\n", _arrayResizes));
                _commands.AppendLine();
            }

            // 5. Обновление скалярных полей
            if (_scalarUpdates.Any())
            {
                _commands.AppendLine("// ---------- Scalar Field Updates ----------");
                _commands.AppendLine(string.Join("\n", _scalarUpdates));
                _commands.AppendLine();
            }
            // 6. Children Entries
            if (_childrenEntries.Any())
            {
                _commands.AppendLine("// ========== CHILDREN ENTRIES ==========");
                _commands.AppendLine(string.Join("\n", _childrenEntries));
                _commands.AppendLine();
            }

            // 7. Дочерние узлы
            if (_childNodes.Any())
            {
                _commands.AppendLine("// ========== CHILD NODES ==========");
                _commands.AppendLine(string.Join("\n", _childNodes));
                _commands.AppendLine(); 
            }

            // 8. Обновления родительских контейнеров
            if (_parentUpdates.Any())
            {
                _commands.AppendLine("// ---------- Parent Container Updates ----------");
                _commands.AppendLine(string.Join("\n", _parentUpdates));
            }

            return _commands.ToString().TrimEnd().Replace(",", ".");
        }
    }
