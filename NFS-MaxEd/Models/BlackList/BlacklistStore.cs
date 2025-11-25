using System.Collections.ObjectModel;

namespace NFSMaxEd.Models;

public class BlacklistStore
{
    // Словарь, где ключ — RaceBin, значение — набор коллекций
    private readonly Dictionary<string, RaceBinData> _store = new();

    public BlacklistStore()
    {
        _store["race_bin_15"] = new RaceBinData
        {
            BossRaces =
            [
                "15_1_2_circuit",
                "15_1_1_circuit_reversed"
            ],
            Children =
            [
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
            ],
            WorldRaces =
            [
                "15_1_1_circuit",
                "15_2_1_sprint",
                "15_3_1_knockout"
            ],
            Milestones = 
            [
                "milestones/bin_15/challenge_15_cops_damaged",
                "milestones/bin_15/challenge_15_pursuit_evasion_time",
                "milestones/bin_15/challenge_15_pursuit_length",
                "milestones/bin_15/taggedcarmarker1",
                "milestones/bin_15/challenge_15_pursuit_length",
            ]
        };
        _store["race_bin_14"] = new RaceBinData
        {
            BossRaces =
            [
                "14_2_4_spirit",
                "15_2_1_spirit_reverse"
            ],
            Children =
            [
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
            ],
            WorldRaces =
            [
                "14_1_1_circuit",
                "14_2_1_sprint",
                "14_2_2_sprint",
                "14_3_1_lapknockout",
                "14_4_1_tollbooth",
                "14_1_2_cellphone_circuit"
            ],
            Milestones = 
            [
                "milestones/bin_14/challenge_14_cops_destroyed",
                "milestones/bin_14/challenge_14_cost_to_state",
                "milestones/bin_14/challenge_14_total_infractions",
            ]
        };
        _store["race_bin_13"] = new RaceBinData
        {
            BossRaces =
            [
                "13_2_3_spirit",
                "14_2_2_r_spirit"
            ],
            Children =
            [
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
            ],
            WorldRaces =
            [
                "13_2_1_sprint",
                "13_3_1_lap_ko",
                "13_3_2_lap_ko",
                "13_4_1_tollbooth",
                "13_4_2_tollbooth",
                "13_5_1_speedtrap",
                "13_5_2_speedtrap"
            ],
            Milestones = 
            [
                "milestones/bin_13/challenge_13_cops_damaged",
                "milestones/bin_13/challenge_13_cops_destroyed",
                "milestones/bin_13/challenge_13_pursuit_evasion_time",
            ]
        };
        _store["race_bin_12"] = new RaceBinData
        {
            BossRaces =
            [
                "12_2_1_sprint",
                "12_1_2_circuit"
            ],
            Children =
            [
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
            ],
            WorldRaces =
            [
                "12_1_1_circuit",
                "12_4_1_tollbooth",
                "12_4_2_tollbooth",
                "12_5_1_speedtrap",
                "12_7_3_drag",
                "13_2_2_r_sprint",
                "14_2_3_r_sprint"
            ],
            Milestones = 
            [
                "milestones/bin_12/challenge_12_cops_damaged",
                "milestones/bin_12/challenge_12_pursuit_evasion_time",
                "milestones/bin_12/challenge_12_pursuit_length",
                "milestones/bin_12/taggedcarmarker1",
            ]
        };
        _store["race_bin_11"] = new RaceBinData
        {
            BossRaces =
            [
                "11_1_2_circuit",
                "11_1_2_r_circuit"
            ],
            Children =
            [
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
            ],
            WorldRaces =
            [
                "11_2_1_sprint",
                "11_1_1_circuit",
                "11_5_1_speedtrap_race",
                "11_4_2_tollbooth",
                "11_4_1_tollbooth",
                "12_2_1_r_sprint",
                "11_5_2_speedtrap",
                "11_7_1_drag"
            ],
            Milestones = 
            [
                "milestones/bin_11/challenge_11_cost_to_state",
                "milestones/bin_11/challenge_11_roadblocks_dodged",
                "milestones/bin_11/challenge_11_total_infractions",
            ]
        };
        _store["race_bin_10"] = new RaceBinData
        {
            BossRaces =
            [
                "10_2_1_sprint",
                "10_7_3_drag"
            ],
            Children =
            [
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
            ],
            WorldRaces =
            [
                "10_3_1_knockout",
                "10_3_2_knockout",
                "10_4_2_tollbooth",
                "10_4_1_tollbooth",
                "11_2_1_r_sprint",
                "10_2_2_sprint",
                "11_1_2_r_circuit",
                "11_5_1_r_speedtrap"
            ],
            Milestones = 
            [
                "milestones/bin_10/challenge_10_cops_destroyed",
                "milestones/bin_10/challenge_10_cost_to_state",
                "milestones/bin_10/challenge_10_pursuit_length",
                "milestones/bin_10/challenge_10_roadblocks_dodged",
            ]
        };
        _store["race_bin_09"] = new RaceBinData
        {
            BossRaces =
            [
                "9_5_3_speedtrap_race",
                "9_2_1_sprint"
            ],
            Children =
            [
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
            ],
            WorldRaces =
            [
                "9_1_1_circuit",
                "9_7_1_drag",
                "9_4_1_tollbooth",
                "9_5_1_speedtrap",
                "9_5_2_speedtrap",
                "9_4_2_tollbooth",
                "12_1_1_r_circuit",
                "9_3_1_lapknockout"
            ],
            Milestones = 
            [
                "milestones/bin_09/challenge_9_cops_damaged",
                "milestones/bin_09/challenge_9_cops_destroyed",
                "milestones/bin_09/challenge_9_pursuit_evasion_time",
                "milestones/bin_09/challenge_9_roadblocks_dodged",
            ]
        };
        _store["race_bin_08"] = new RaceBinData
        {
            BossRaces =
            [
                "8_2_1_sprint",
                "8_7_5_drag"
            ],
            Children =
            [
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
            ],
            WorldRaces =
            [
                "8_3_1_lap_ko",
                "13_3_1_r_lap_ko",
                "8_5_1_speedtrap",
                "8_5_2_speedtrap",
                "8_2_2_sprint",
                "10_4_2_r_tollbooth",
                "9_4_1_r_tollbooth"
            ],
            Milestones = 
            [
                "milestones/bin_08/challenge_8_cops_damaged",
                "milestones/bin_08/challenge_8_pursuit_length",
                "milestones/bin_08/challenge_8_tire_spikes_dodged",
                "milestones/bin_08/challenge_8_total_infractions",
                "milestones/bin_08/taggedcarmarker1",
            ]
        };
        _store["race_bin_07"] = new RaceBinData
        {
            BossRaces =
            [
                "7_2_2_p2p",
                "7_2_3_p2p"
            ],
            Children =
            [
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
            ],
            WorldRaces =
            [
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
            ],
            Milestones = 
            [
                "milestones/bin_07/challenge_7_cops_destroyed",
                "milestones/bin_07/challenge_7_cost_to_state",
                "milestones/bin_07/challenge_7_pursuit_evasion_time",
                "milestones/bin_07/challenge_7_roadblocks_dodged",
            ]
        };
        _store["race_bin_06"] = new RaceBinData
        {
            BossRaces =
            [
                "6_1_1_circuit",
                "6_5_2_speedtraprace"
            ],
            Children =
            [
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
            ],
            WorldRaces =
            [
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
            ],
            Milestones = 
            [
                "milestones/bin_06/challenge_6_cops_damaged",
                "milestones/bin_06/challenge_6_pursuit_length",
                "milestones/bin_06/challenge_6_roadblocks_dodged",
                "milestones/bin_06/challenge_6_tire_spikes_dodged",
            ]
        };
        _store["race_bin_05"] = new RaceBinData
        {
            BossRaces =
            [
                "5_2_2_sprint",
                "5_5_4_speedtrap",
                "5_2_1_r_sprint"
            ],
            Children =
            [
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
            ],
            WorldRaces =
            [
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
            ],
            Milestones = 
            [
                "milestones/bin_05/challenge_5_cops_destroyed",
                "milestones/bin_05/challenge_5_cost_to_state",
                "milestones/bin_05/challenge_5_pursuit_evasion_time",
                "milestones/bin_05/challenge_5_tire_spikes_dodged",
            ]
        };
        _store["race_bin_04"] = new RaceBinData
        {
            BossRaces =
            [
                "4_5_2_speedtrap",
                "4_7_4_drag",
                "4_5_1_r_speedtrap"
            ],
            Children =
            [
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
            ],
            WorldRaces =
            [
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
            ],
            Milestones = 
            [
                "milestones/bin_04/challenge_4_cops_damaged",
                "milestones/bin_04/challenge_4_cops_destroyed",
                "milestones/bin_04/challenge_4_cost_to_state",
                "milestones/bin_04/challenge_4_total_infractions",
            ]
        };
        _store["race_bin_03"] = new RaceBinData
        {
            BossRaces =
            [
                "3_1_2_r_circuit",
                "3_2_2_sprint",
                "3_1_2_circuit"
            ],
            Children =
            [
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
            ],
            WorldRaces =
            [
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
            ],
            Milestones = 
            [
                "milestones/bin_03/challenge_3_cops_damaged",
                "milestones/bin_03/challenge_3_cops_destroyed",
                "milestones/bin_03/challenge_3_pursuit_evasion_time",
                "milestones/bin_03/challenge_3_pursuit_length",
            ]
        };
        _store["race_bin_02"] = new RaceBinData
        {
            BossRaces =
            [
                "3_1_1_r_circuit",
                "9_2_2_r_sprint",
                "2_2_1_sprint"
            ],
            Children =
            [
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
            ],
            WorldRaces =
            [
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
            ],
            Milestones = 
            [
                "milestones/bin_02/challenge_2_cost_to_state",
                "milestones/bin_02/challenge_2_pursuit_length",
                "milestones/bin_02/challenge_2_roadblocks_dodged",
                "milestones/bin_02/challenge_2_tire_spikes_dodged",
            ]
        };
        _store["race_bin_01"] = new RaceBinData
        {
            BossRaces =
            [
                "1_5_2_speedtraprace",
                "1_7_3_drag",
                "4_2_1_sprint",
                "1_1_2_circuit",
                "1_2_3_sprint",
                "epic_pursuit"
            ],
            Children =
            [
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
            ],
            WorldRaces =
            [
                "1_1_1_circuit",
                "1_2_1_sprint",
                "1_2_2_sprint",
                "1_2_4_sprint",
                "1_3_1_lapknockout",
                "1_4_1_tollbooth",
                "1_4_2_tollbooth",
                "1_5_1_speedtraprace",
                "1_5_3_speedtrap",
                "2_2_1_r_sprint",
                "2_4_3_r_tollbooth"
            ],
            Milestones = 
            [
                "milestones/bin_01/challenge_1_cops_damaged",
                "milestones/bin_01/challenge_1_cops_destroyed",
                "milestones/bin_01/challenge_1_pursuit_evasion_time",
                "milestones/bin_01/challenge_1_pursuit_length",
            ]
        };
    }
    public RaceBinData GetData(string raceBin)
    {
        if (_store.TryGetValue(raceBin, out var data))
            return data;
        return new RaceBinData();
    }
}