using System.Text.RegularExpressions;
using NFSMaxEd.Models;

namespace NFSMaxEd.Services;

public abstract class BaseParser
    {
        protected readonly RaceScriptBuilder builder;
        protected readonly RaceConfig config;

        protected BaseParser(RaceConfig config)
        {
            this.config = config;
            this.builder = new RaceScriptBuilder(config.Path, config.NodeType)
                .ChangeVault(config.Path.Split('/')[0]);
        }

        protected abstract void ParseSpecificSettings();
        public string GenerateCode()
        {
            ParseBaseSettings();
            UpdateArrays();
            ResizeArrays();
            CreateChildren();
            ParseSpecificSettings();
            builder.ResizeChildrenEntry(config.GetChildrenCount());
            // Обновления родительского контейнера, если нужно
            return builder.Build();
        }
        protected void ParseBaseSettings()
        {
            builder.EnableQR(config.AvailableQR)
                .SetCashValue(config.CashValue)
                .SetEventId(config.EventId)
                .SetIntroNIS(config.IntroNis)
                .SetRegion(config.Region)
                .SetTemplate(config.Template)
                .SetTrafficLevel(config.TrafficLevel)
                .SetOpponents(config.Opponent);
            if(int.TryParse(config.RaceBin.Split("_")[2], out int level))
                builder.SetProgressionLevel(level);
            if (config.EnableCops)
            {
                builder.EnableCops(config.EnableCops)
                    .SetForceHeatLevel(config.ForceHeatLevel)
                    .SetMaxHeatLevel(config.MaxHeatLevel);
            }

            if (config.QuickRaceNis)
                builder.AddQuickRaceNis();
            
            if (config.BossRaces)
            {
                builder.SetBossRace()
                    .SetPostRaceActivity(config.PostRaceActivity)
                    .SetRivalBestTime(config.RivalBestTime);
            }

            if (config.IsChanceOfRain)
            {
                builder.SetChanceOfRain(config.ChanceOfRain);
            }

            if (config.RaceLength > 0)
                builder.SetRaceLength(config.RaceLength);

            if (!string.IsNullOrWhiteSpace(config.FinishCamera))
                builder.SetFinishCamera(config.FinishCamera);

            if (!string.IsNullOrWhiteSpace(config.GameplayVault))
                builder.SetGameplayVault(config.GameplayVault);

            if (config.Barriers.Count > 0)
                builder.SetBarriers(config.Barriers.Count);

            if (config.Checkpoints.Count > 0)
                builder.SetCheckpoints(config.Checkpoints.Count);

            if (config.ChildrenPaths.Count > 0)
                builder.SetChildren(config.ChildrenPaths.Count);

            if (config.Shortcuts.Count > 0)
                builder.SetShortcuts(config.Shortcuts.Count);
        }

        protected void UpdateArrays()
        {
            for (int i = 0; i < config.Barriers.Count; i++)
                builder.UpdateBarrier(i, config.Barriers[i].Value);

            for (int i = 0; i < config.Checkpoints.Count; i++)
                builder.UpdateCheckpoint(i, config.Checkpoints[i].Name);

            for (int i = 0; i < config.ChildrenPaths.Count; i++)
                builder.UpdateChild(i, config.ChildrenPaths[i]);

            
            if(!config.BossRaces)
            {
                for (int i = 0; i < config.Opponents.Count && config.NodeType != RaceType.cashgrab; i++)
                    builder.UpdateOpponent(i, config.Opponents[i].Name);
            }
            else
            {
                builder.UpdateOpponent(0, BossRaceStore.BossRaces[config.RaceBin]);
            }

            for (int i = 0; i < config.Shortcuts.Count; i++)
                builder.UpdateShortcut(i, config.Shortcuts[i].Name);
        }

        protected void ResizeArrays()
        {
            if (config.Barriers.Count > 0)
                builder.ResizeBarriers(config.Barriers.Count);

            if (config.Checkpoints.Count > 0)
                builder.ResizeCheckpoints(config.Checkpoints.Count);

            if (config.ChildrenPaths.Count > 0)
                builder.ResizeChildren(config.ChildrenPaths.Count);

            if (config.Shortcuts.Count > 0)
                builder.ResizeShortcuts(config.Shortcuts.Count);
        }

        protected void CreateChildren()
        {

            builder.SetChildrenEntry();

            if (config.StartGrid != null)
            {
                builder.SetRaceStart();
                builder.AddChildNode(EntityType.startgrid, EntityType.startgrid.ToString(),
                    GetTransformDict(config.StartGrid.PositionX, config.StartGrid.PositionY, config.StartGrid.PositionZ, config.StartGrid.Rotation));
            }

            if (config.FinishLine != null && config.NodeType != RaceType.cashgrab)
            {
                builder.SetRaceFinish();
                
                builder.AddChildNode(EntityType.finishline, EntityType.finishline.ToString(), new Dictionary<string, object>
                {
                    {"Dimensions", new Dictionary<string, object>
                        {
                            {"X", config.FinishLine.DimensionsX},
                            {"Y", config.FinishLine.DimensionsY},
                            {"Z", config.FinishLine.DimensionsZ}
                        }
                    },
                    {"Position", new Dictionary<string, object>
                        {
                            {"X", config.FinishLine.PositionX},
                            {"Y", config.FinishLine.PositionY},
                            {"Z", config.FinishLine.PositionZ}
                        }
                    },
                    
                    {"Rotation", config.FinishLine.Rotation},
                    {"Template", ""}
                });
            }
            
            foreach (var checkpoint in config.Checkpoints.Where(c => !c.Name.Contains("/")))
            {
                builder.AddChildNode(EntityType.checkpoint, checkpoint.Name,
                    GetTransformDict(checkpoint.PositionX, checkpoint.PositionY, checkpoint.PositionZ, checkpoint.Rotation));
            }
            foreach (var shortcut in config.Shortcuts)
            {
                builder.AddChildNode(EntityType.shortcut, shortcut.Name, new Dictionary<string, object>
                {
                    {"Position", new Dictionary<string, object>
                        {
                            {"X", shortcut.PositionX},
                            {"Y", shortcut.PositionY},
                            {"Z", shortcut.PositionZ}
                        }
                    },
                    {"Rotation", shortcut.Rotation},
                    {"ShortcutMaxChance", shortcut.MaxChance},
                    {"ShortcutMinChance", shortcut.MinChance},
                    {"Template", ""}
                });
            }
            

            foreach (var playerTriger in config.ResetPlayerTrigers)
            {
                builder.AddChildNode(EntityType.resetplayertrigger, playerTriger.Name,
                    GetTransformDict(playerTriger.PositionX, 
                        playerTriger.PositionY, 
                        playerTriger.PositionZ,
                        playerTriger.Rotation));
            }
        }


        protected Dictionary<string, object> GetTransformDict(float x, float y, float z, float rotation)
        {
            return new Dictionary<string, object>
            {
                {"Position", new Dictionary<string, object>{{"X", x}, {"Y", y}, {"Z", z}}},
                {"Rotation", rotation},
                {"Template", ""}
            };
        }
    }