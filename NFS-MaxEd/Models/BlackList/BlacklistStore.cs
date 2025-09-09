using System.Collections.ObjectModel;

namespace NFSMaxEd.Models;

public class BlacklistStore
{
    private readonly Dictionary<string, RaceBinData> _store = new();

    public BlacklistStore()
    {
        _store["race_bin_15"] = new RaceBinData
        {
            BossRaces = new ObservableCollection<string>
            {
                "15_1_2_circuit",
                "15_1_1_circuit_reversed"
            },
            Children = new ObservableCollection<string>
            {
                "tony_ho",
                "15_3_1_knockout",
                "15_1_2_circuit",
                "15_2_1_sprint",
                "15_1_1_circuit",
                "engage",
                "debug spawn_point",
                "15_1_1_circuit_reversed",
                "opponent1",
                "opponent2",
                "opponent3",
                "rewards",
                "unlocks"
            },
            WorldRaces = new ObservableCollection<string>
            {
                "15_1_1_circuit",
                "15_2_1_sprint",
                "15_3_1_knockout"
            }
        };
        _store["race_bin_14"] = new RaceBinData
        {
            BossRaces = new ObservableCollection<string>
            {
                "14_2_4_spirit",
                "15_2_1_spirit_reverse"
            },
            Children = new ObservableCollection<string>
            {
                "vince_kilic",
                "14_1_1_circuit",
                "14_4_1_tollbooth",
                "14_2_1_sprint",
                "14_1_2_cellphone_circuit",
                "14_2_4_sprint",
                "14_2_2_sprint",
                "14_3_1_lapknockout",
                "engage",
                "15_2_1_sprint_reverse",
                "rewards",
                "unlocks",
                "character1",
                "character2",
                "character3"
            },
            WorldRaces = new ObservableCollection<string>
            {
                "14_1_1_circuit",
                "14_2_1_sprint",
                "14_2_2_sprint",
                "14_3_1_lapknockout",
                "14_4_1_tollbooth",
                "14_1_2_cellphone_circuit"
            }
        };
        _store["race_bin_13"] = new RaceBinData
        {
            BossRaces = new ObservableCollection<string>
            {
                "13_2_3_spirit",
                "14_2_2_r_spirit"
            },
            Children = new ObservableCollection<string>
            {
                "victor_vasquez",
                "13_5_1_speedtrap",
                "13_5_2_speedtrap",
                "13_3_1_lap_ko",
                "13_2_1_sprint",
                "13_4_1_tollbooth",
                "13_3_2_lap_ko",
                "13_4_2_tollbooth",
                "engage",
                "rewards",
                "unlocks",
                "14_2_2_r_sprint",
                "13_2_3_sprint",
                "character1",
                "character2",
                "character3"
            },
            WorldRaces = new ObservableCollection<string>
            {
                "13_2_1_sprint",
                "13_3_1_lap_ko",
                "13_3_2_lap_ko",
                "13_4_1_tollbooth",
                "13_4_2_tollbooth",
                "13_5_1_speedtrap",
                "13_5_2_speedtrap"
            }
        };
        _store["race_bin_12"] = new RaceBinData
        {
            BossRaces = new ObservableCollection<string>
            {
                "12_2_1_sprint",
                "12_1_2_circuit"
            },
            Children = new ObservableCollection<string>
            {
                "isabel_diaz",
                "12_7_3_drag",
                "12_1_1_circuit",
                "12_4_2_tollbooth",
                "12_2_1_sprint",
                "12_1_2_circuit",
                "12_4_1_tollbooth",
                "engage",
                "rewards",
                "unlocks",
                "14_2_3_r_sprint",
                "13_2_2_r_sprint",
                "12_5_1_speedtrap",
                "character1",
                "character2",
                "character3",
                "drag_opponent"
            },
            WorldRaces = new ObservableCollection<string>
            {
                "12_1_1_circuit",
                "12_4_1_tollbooth",
                "12_4_2_tollbooth",
                "12_5_1_speedtrap",
                "12_7_3_drag",
                "13_2_2_r_sprint",
                "14_2_3_r_sprint"
            }
        };
        _store["race_bin_11"] = new RaceBinData
        {
            BossRaces = new ObservableCollection<string>
            {
                "11_1_2_circuit",
                "11_1_2_r_circuit"
            },
            Children = new ObservableCollection<string>
            {
                "lou_park",
                "11_1_2_circuit",
                "11_1_1_circuit",
                "11_5_1_speedtrap_race",
                "11_4_2_tollbooth",
                "11_2_1_sprint",
                "11_4_1_tollbooth",
                "rewards",
                "unlocks",
                "12_2_1_r_sprint",
                "12_1_2_r_circuit",
                "11_5_2_speedtrap",
                "character1",
                "character2",
                "character3",
                "11_7_1_drag",
                "engage",
                "drag_opponent"
            },
            WorldRaces = new ObservableCollection<string>
            {
                "11_2_1_sprint",
                "11_1_1_circuit",
                "11_5_1_speedtrap_race",
                "11_4_2_tollbooth",
                "11_4_1_tollbooth",
                "12_2_1_r_sprint",
                "11_5_2_speedtrap",
                "11_7_1_drag"
            }
        };

        _store["race_bin_10"] = new RaceBinData
        {
            BossRaces = new ObservableCollection<string>
            {
                "10_2_1_sprint",
                "10_7_3_drag"
            },
            Children = new ObservableCollection<string>
            {
                "karl_smit",
                "10_3_2_knockout",
                "10_3_1_knockout",
                "10_4_2_tollbooth",
                "10_2_1_sprint",
                "10_4_1_tollbooth",
                "engage",
                "rewards",
                "unlocks",
                "11_2_1_r_sprint",
                "11_1_2_r_circuit",
                "11_5_1_r_speedtrap",
                "10_2_2_sprint",
                "character1",
                "character2",
                "character3",
                "10_7_3_drag",
                "drag_opponent"
            },
            WorldRaces = new ObservableCollection<string>
            {
                "10_3_1_knockout",
                "10_3_2_knockout",
                "10_4_2_tollbooth",
                "10_4_1_tollbooth",
                "11_2_1_r_sprint",
                "10_2_2_sprint",
                "11_1_2_r_circuit",
                "11_5_1_r_speedtrap"
            }
        };
        
        _store["race_bin_09"] = new RaceBinData
    {
        BossRaces = new ObservableCollection<string>
        {
            "9_5_3_speedtrap_race",
            "9_2_1_sprint"
        },
    Children = new ObservableCollection<string>
    {
        "pierre_dupont",
        "9_7_1_drag",
        "9_2_1_sprint",
        "9_4_1_tollbooth",
        "9_1_1_circuit",
        "9_5_1_speedtrap",
        "engage",
        "9_5_2_speedtrap",
        "9_5_3_speedtrap_race",
        "9_4_2_tollbooth",
        "rewards",
        "unlocks",
        "character1",
        "character2",
        "character3",
        "12_1_1_r_circuit",
        "9_3_1_lapknockout",
        "drag_opponent"
    },
    WorldRaces = new ObservableCollection<string>
    {
        "9_1_1_circuit",
        "9_7_1_drag",
        "9_4_1_tollbooth",
        "9_5_1_speedtrap",
        "9_5_2_speedtrap",
        "9_4_2_tollbooth",
        "12_1_1_r_circuit",
        "9_3_1_lapknockout"
    }
};

_store["race_bin_08"] = new RaceBinData
{
    BossRaces = new ObservableCollection<string>
    {
        "8_2_1_sprint",
        "8_7_5_drag"
    },
    Children = new ObservableCollection<string>
    {
        "jade_barrett",
        "8_3_1_lap_ko",
        "engage",
        "8_2_1_sprint",
        "rewards",
        "unlocks",
        "13_3_1_r_lap_ko",
        "8_5_1_speedtrap",
        "8_5_2_speedtrap",
        "8_2_2_sprint",
        "character1",
        "character2",
        "character3",
        "10_4_2_r_tollbooth",
        "9_4_1_r_tollbooth",
        "8_7_5_drag"
    },
    WorldRaces = new ObservableCollection<string>
    {
        "8_3_1_lap_ko",
        "13_3_1_r_lap_ko",
        "8_5_1_speedtrap",
        "8_5_2_speedtrap",
        "8_2_2_sprint",
        "10_4_2_r_tollbooth",
        "9_4_1_r_tollbooth"
    }
};

_store["race_bin_07"] = new RaceBinData
{
    BossRaces = new ObservableCollection<string>
    {
        "7_2_2_p2p",
        "7_2_3_p2p"
    },
    Children = new ObservableCollection<string>
    {
        "kira_nazakato",
        "7_4_3_tollbooth",
        "7_2_3_p2p",
        "7_5_1_speedtrap",
        "7_4_1_tollbooth",
        "7_2_2_p2p",
        "7_4_2_tollbooth",
        "7_3_1_lap_ko",
        "engage",
        "7_2_1_sprint",
        "rewards",
        "unlocks",
        "16_1_1_r_circuit",
        "8_2_1_r_sprint",
        "7_1_1_circuit",
        "character1",
        "character2",
        "character3",
        "7_7_4_drag",
        "drag opponent"
    },
    WorldRaces = new ObservableCollection<string>
    {
        "7_2_1_sprint",
        "7_4_3_tollbooth",
        "7_5_1_speedtrap",
        "7_4_1_tollbooth",
        "7_3_1_lap_ko",
        "16_1_1_r_circuit",
        "8_2_1_r_sprint",
        "7_1_1_circuit",
        "7_4_2_tollbooth",
        "7_7_4_drag"
    }
};
_store["race_bin_06"] = new RaceBinData
{
    BossRaces = new ObservableCollection<string>
    {
        "6_1_1_circuit",
        "6_5_2_speedtraprace"
    },
    Children = new ObservableCollection<string>
    {
        "hector_domingo",
        "6_1_1_circuit",
        "6_4_1_tollbooth",
        "6_5_1_speedtraprace",
        "6_2_1_p2p",
        "6_5_2_speedtraprace",
        "6_4_2tollbooth",
        "6_2_2_p2p",
        "6_3_1_lap_ko",
        "engage",
        "rewards",
        "unlocks",
        "14_3_1_r_lap_ko",
        "6_2_3_sprint",
        "6_5_3_speedtrap",
        "7_7_1_r_drag",
        "7_4_1_r_tollbooth",
        "character1",
        "character2",
        "character3",
        "drag opponent"
    },
    WorldRaces = new ObservableCollection<string>
    {
        "6_2_2_p2p",
        "6_4_1_tollbooth",
        "6_5_1_speedtraprace",
        "6_2_1_p2p",
        "6_4_2_tollbooth",
        "6_3_1_lap_ko",
        "14_3_1_r_lap_ko",
        "6_2_3_sprint",
        "6_5_3_speedtrap",
        "7_7_1_drag"
    }
};

_store["race_bin_05"] = new RaceBinData
{
    BossRaces = new ObservableCollection<string>
    {
        "5_2_2_sprint",
        "5_5_4_speedtrap",
        "5_2_1_r_sprint"
    },
    Children = new ObservableCollection<string>
    {
        "wes_allen",
        "engage",
        "5_1_1_circuit",
        "5_2_1_sprint",
        "5_3_1_lap_ko",
        "5_5_1_speedtrap",
        "5_5_2_speedtrap",
        "5_2_2_sprint",
        "rewards",
        "unlocks",
        "5_4_1_tollbooth",
        "5_2_1_r_sprint",
        "5_5_3_speedtrap",
        "5_2_3_sprint",
        "5_5_4_speedtrap",
        "6_4_1_r_tollbooth",
        "7_4_2_tollbooth",
        "character1",
        "character2",
        "character3",
        "drag_opponent"
    },
    WorldRaces = new ObservableCollection<string>
    {
        "5_3_1_lap_ko",
        "5_1_1_circuit",
        "5_2_1_sprint",
        "5_5_1_speedtrap",
        "5_5_2_speedtrap",
        "5_4_1_tollbooth",
        "5_5_3_speedtrap",
        "5_2_3_sprint",
        "6_4_1_r_tollbooth",
        "7_4_2_r_tollbooth"
    }
};
_store["race_bin_04"] = new RaceBinData
{
    BossRaces = new ObservableCollection<string>
    {
        "4_5_2_speedtrap",
        "4_7_4_drag",
        "4_5_1_r_speedtrap"
    },
    Children = new ObservableCollection<string>
    {
        "joe_vega",
        "4_4_1_tollbooth",
        "4_5_2_speedtrap",
        "4_1_1_circuit",
        "4_3_1_lapknockout",
        "4_5_3_speedtrap",
        "4_5_1_speedtrap",
        "engage",
        "rewards",
        "unlocks",
        "5_5_2_r_speedtrap",
        "7_2_2_r_sprint",
        "4_5_1_r_speedtrap",
        "6_3_1_r_knockout",
        "9_1_1_r_circuit",
        "5_4_1_r_tollbooth",
        "7_4_3_r_tollbooth",
        "character1",
        "character2",
        "character3",
        "4_7_4_drag",
        "drag opponent"
    },
    WorldRaces = new ObservableCollection<string>
    {
        "4_4_1_tollbooth",
        "4_1_1_circuit",
        "4_3_1_Japknockout",
        "4_5_3_speedtrap",
        "4_5_1_speedtrap",
        "5_5_2_r_speedtrap",
        "7_2_2_r_sprint",
        "6_3_1_r_knockout",
        "9_1_1_r_circuit",
        "5_4_1_r_tollbooth",
        "7_4_3_r_tollbooth"
    }
};

_store["race_bin_03"] = new RaceBinData
{
    BossRaces = new ObservableCollection<string>
    {
        "3_1_2_r_circuit",
        "3_2_2_sprint",
        "3_1_2_circuit"
    },
    Children = new ObservableCollection<string>
    {
        "ronnie_mccrea",
        "3_3_1_lap_ko",
        "engage",
        "3_1_1_circuit",
        "3_2_2_sprint",
        "3_1_2_circuit",
        "rewards",
        "unlocks",
        "3_4_1_tollbooth",
        "7_2_1_r_sprint",
        "3_1_2_r_circuit",
        "4_3_1_r_knockout",
        "3_5_1_speedtrap",
        "3_5_2_speedtrap",
        "3_4_1_r_tollbooth",
        "4_4_1_r_tollbooth",
        "character1",
        "character2",
        "character3",
        "4_2_1_r_sprint_race",
        "3_7_3_drag",
        "3_2_1_sprint"
    },
    WorldRaces = new ObservableCollection<string>
    {
        "3_2_1_sprint",
        "3_3_1_lap_ko",
        "3_1_1_circuit",
        "3_4_1_tollbooth",
        "7_2_1_r_sprint",
        "4_3_1_r_knockout",
        "3_5_1_speedtrap",
        "3_5_2_speedtrap",
        "3_4_1_r_tollbooth",
        "4_4_1_r_tollbooth",
        "4_2_1_r_sprint_race",
        "3_7_3_drag"
    }
};

_store["race_bin_02"] = new RaceBinData
{
    BossRaces = new ObservableCollection<string>
    {
        "3_1_1_r_circuit",
        "9_2_2_r_sprint",
        "2_2_1_sprint"
    },
    Children = new ObservableCollection<string>
    {
        "toro_sato",
        "engage",
        "2_5_1_speedtrap",
        "2_1_1_circuit",
        "2_2_1_sprint",
        "rewards",
        "unlocks",
        "2_4_1_tollbooth",
        "2_4_2_tollbooth",
        "2_4_3_tollbooth",
        "3_3_2_r_knockout",
        "5_5_1_r_speedtrap",
        "3_3_1_r_knockout",
        "3_2_1_r_sprint",
        "2_1_1_r_circuit",
        "3_1_1_r_circuit",
        "5_1_1_r_Circuit",
        "9_2_2_r_sprint",
        "character1",
        "character2",
        "character3",
        "2_7_1_drag"
    },
    WorldRaces = new ObservableCollection<string>
    {
        "2_1_1_circuit",
        "2_1_1_r_circuit",
        "2_4_1_tollbooth",
        "2_4_2_tollbooth",
        "2_4_3_tollbooth",
        "2_5_1_speedtrap",
        "3_2_1_r_sprint",
        "3_3_1_r_knockout",
        "3_3_2_r_knockout",
        "5_1_1_r_Circuit",
        "5_5_1_r_speedtrap",
        "2_7_1_drag"
    }
};

_store["race_bin_01"] = new RaceBinData
{
    BossRaces = new ObservableCollection<string>
    {
        "1_5_2_speedtraprace",
        "1_7_3_drag",
        "4_2_1_sprint",
        "1_1_2_circuit",
        "1_2_3_sprint",
        "epic_pursuit"
    },
    Children = new ObservableCollection<string>
    {
        "razor_callahan",
        "engage",
        "1_3_1_lapknockout",
        "1_1_1_circuit",
        "1_2_2_sprint",
        "1_5_1_speedtraprace",
        "1_1_2_circuit",
        "1_2_1_sprint",
        "rewards",
        "unlocks",
        "1_4_1_tollbooth",
        "1_4_2_tollbooth",
        "1_2_3_sprint",
        "2_2_1_r_sprint",
        "1_2_4_sprint",
        "1_5_3_speedtrap",
        "2_4_3_r_tollbooth",
        "character1",
        "character2",
        "character3",
        "4_2_1_sprint",
        "17_3_drag",
        "epic_pursuit",
        "1_5_2_speedtraprace"
    },
    WorldRaces = new ObservableCollection<string>
    {
        "1_1_1circuit",
        "1_2_1_sprint",
        "1_2_2_sprint",
        "1_2_4_sprint",
        "1_3_1_Japknockout",
        "1_4_1_tollbooth",
        "1_4_2_tollbooth",
        "1_5_1_speedtraprace",
        "1_5_3_speedtrap",
        "2_2_1_r_sprint",
        "2_4_3_r_tollbooth"
    }
};

    }

    public RaceBinData GetData(string raceBin)
    {
        if (_store.TryGetValue(raceBin, out var data))
            return data;

        return new RaceBinData();
    }
}