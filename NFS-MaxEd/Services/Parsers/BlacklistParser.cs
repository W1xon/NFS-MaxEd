using System.Collections.ObjectModel;
using NFSMaxEd.Models;

namespace NFSMaxEd.Services;

public class BlacklistParser
    {
        private readonly BlacklistConfig _blacklistConfig;
        private readonly BlacklistStore _store;
        private readonly BlacklistScriptBuilder _builder;

        public BlacklistParser(BlacklistConfig blacklistConfig, BlacklistStore store)
        {
            _blacklistConfig = blacklistConfig;
            _store = store;
            _builder = new BlacklistScriptBuilder(_blacklistConfig.RaceBin);
        }

        public string GenerateCode()
        {
            if (_blacklistConfig.RequiredBounty != 0)
                _builder.AddRequiredBounty(_blacklistConfig.RequiredBounty);
            if (_blacklistConfig.RequiredChallenges != 0)
                _builder.AddRequiredChallenges(_blacklistConfig.RequiredChallenges);
            if(_blacklistConfig.RequiredRaceWon !=0)
                _builder .AddRequiredRaceWon(_blacklistConfig.RequiredRaceWon);

            var raceBin = _blacklistConfig.RaceBin;
            var originalData = _store.GetData(raceBin);

            // Конвертируем ObservableCollection<StringWrapper> в ObservableCollection<string> для сравнения
            var worldRacesStrings = new ObservableCollection<string>(_blacklistConfig.WorldRaces.Select(sw => sw.Value));
            var childrenStrings = new ObservableCollection<string>(_blacklistConfig.Children.Select(sw => sw.Value));
            var bossRacesStrings = new ObservableCollection<string>(_blacklistConfig.BossRaces.Select(sw => sw.Value));
            var milestonesStrings = new ObservableCollection<string>(_blacklistConfig.Milestones.Select(sw => sw.Value));
            
            CompareAndBuildArray("WorldRaces", originalData.WorldRaces, worldRacesStrings);
            CompareAndBuildArray("Children", originalData.Children, childrenStrings);
            CompareAndBuildArray("BossRaces", originalData.BossRaces, bossRacesStrings);
            CompareAndBuildMilestoneArray(originalData.Milestones, milestonesStrings);

            return _builder.Build();
        }

        private void CompareAndBuildArray(string field, ObservableCollection<string> original, ObservableCollection<string> updated)
        {
            if (updated.Count > original.Count)
            {
                _builder.AddResizeField(field, updated.Count);
            }

            for (int i = 0; i < updated.Count; i++)
            {
                if (i >= original.Count || original[i] != updated[i])
                {
                    _builder.AddUpdateField(field, i, updated[i]);
                }
            }
        }
        private void CompareAndBuildMilestoneArray(ObservableCollection<string> original, ObservableCollection<string> updated)
        {
            if (updated.Count > original.Count)
            {
                _builder.AddResizeMilestoneField(updated.Count);
            }

            for (int i = 0; i < updated.Count; i++)
            {
                if (i >= original.Count || original[i] != updated[i])
                {
                    _builder.AddUpdateMilestoneField(i, updated[i]);
                }
            }
        }
    }
