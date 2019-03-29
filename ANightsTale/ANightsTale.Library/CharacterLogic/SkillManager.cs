using ANightsTale.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANightsTale.Library.CharacterLogic
{
    public class SkillManager : ISkillManager
    {
        public void SetSkills(Library.CharStats stats)
        {
            //STR
            stats.Athletics = stats.STR_Mod;

            //DEX
            stats.Acrobatics = stats.DEX_Mod;
            stats.SleightOfHand = stats.DEX_Mod;
            stats.Stealth = stats.DEX_Mod;

            //INT
            stats.Arcana = stats.INT_Mod;
            stats.History = stats.INT_Mod;
            stats.Investigation = stats.INT_Mod;
            stats.Nature = stats.INT_Mod;
            stats.Religion = stats.INT_Mod;

            //WIS
            stats.AnimalHandling = stats.WIS_Mod;
            stats.Insight = stats.WIS_Mod;
            stats.Medicine = stats.WIS_Mod;
            stats.Perception = stats.WIS_Mod;
            stats.Survival = stats.WIS_Mod;

            //CHA
            stats.Deception = stats.CHA_Mod;
            stats.Intimidation = stats.CHA_Mod;
            stats.Persuasion = stats.CHA_Mod;
            stats.Performance = stats.CHA_Mod;
        }

        public IEnumerable<Skill> GetSkillsByClass(int id)
        {
            var skills = new List<Skill>
            {
                new Skill(1, "Acrobatics"),
                new Skill(2, "Animal Handling"),
                new Skill(3, "Arcana"),
                new Skill(4, "Athletics"),
                new Skill(5, "Deception"),
                new Skill(6, "History"),
                new Skill(7, "Insight"),
                new Skill(8, "Intimidation"),
                new Skill(9, "Investigation"),
                new Skill(10, "Medicine"),
                new Skill(11, "Nature"),
                new Skill(12, "Perception"),
                new Skill(13, "Performance"),
                new Skill(14, "Persuasion"),
                new Skill(15, "Religion"),
                new Skill(16, "Sleight of Hand"),
                new Skill(17, "Stealth"),
                new Skill(18, "Survival"),
            };

            switch (id)
            {
                case 1:
                    // Barbarian {2,4,8,11,12,18}
                    return skills.Where(s => s.Id == 2 || s.Id == 4 || s.Id == 8 ||
                                             s.Id == 11 || s.Id == 12 || s.Id == 18);
                case 2:
                    // Fighter {1, 2, 4, 6, 7, 8, 12, 18}
                    return skills.Where(s => s.Id == 1 || s.Id == 2 || s.Id == 4 ||
                                             s.Id == 6 || s.Id == 7 || s.Id == 8 ||
                                             s.Id == 12 || s.Id == 18);
                case 3:
                    // Paladin {4, 7, 8, 10, 14, 15} 
                    return skills.Where(s => s.Id == 4 || s.Id == 7 || s.Id == 8 ||
                                             s.Id == 10 || s.Id == 14 || s.Id == 15);
                case 4:
                    // Bard {All Skills}
                    return skills;
                case 5:
                    // Sorcerer {3, 5, 7, 8, 14, 15}
                    return skills.Where(s => s.Id == 3 || s.Id == 5 || s.Id == 7 ||
                                             s.Id == 8 || s.Id == 14 || s.Id == 15);
                case 6:
                    // Cleric {6, 7, 10, 14, 15}
                    return skills.Where(s => s.Id == 6 || s.Id == 7 || s.Id == 10 ||
                                             s.Id == 14 || s.Id == 15);
                case 7:
                    // Druid {2, 3, 7, 10, 11, 12, 15, 18}
                    return skills.Where(s => s.Id == 2 || s.Id == 3 || s.Id == 7 ||
                                             s.Id == 10 || s.Id == 11 || s.Id == 12 ||
                                             s.Id == 15 || s.Id == 18);
                case 8:
                    // Ranger {2, 4, 7, 9, 11, 12, 17, 18} 
                    return skills.Where(s => s.Id == 2 || s.Id == 4 || s.Id == 7 ||
                                             s.Id == 9 || s.Id == 11 || s.Id == 12 ||
                                             s.Id == 17 || s.Id == 18);
                case 9:
                    // Rogue {1, 4, 5, 7, 8, 9, 12, 13, 14, 16, 17}
                    return skills.Where(s => s.Id == 1 || s.Id == 2 || s.Id == 4 ||
                                             s.Id == 6 || s.Id == 7 || s.Id == 8 ||
                                             s.Id == 12 || s.Id == 18);
                case 10:
                    // Wizard {3, 6, 7, 9, 10, 15}
                    return skills.Where(s => s.Id == 3 || s.Id == 6 || s.Id == 7 ||
                                             s.Id == 9 || s.Id == 10 || s.Id == 15);
                default:
                    throw new ArgumentException("Class does not exist...");
            }
        }

        public void UpdateSkills(List<int> skills, Library.CharStats stats)
        {
            if (stats != null)
            {
                foreach (int skill in skills)
                {
                    switch (skill)
                    {
                        case 1:
                            // Acrobatics
                            stats.Acrobatics += stats.PB;
                            break;
                        case 2:
                            // AnimalHandling
                            stats.AnimalHandling += stats.PB;
                            break;
                        case 3:
                            // Arcana
                            stats.Arcana += stats.PB;
                            break;
                        case 4:
                            // Athletics
                            stats.Athletics += stats.PB;
                            break;
                        case 5:
                            // Deception
                            stats.Deception += stats.PB;
                            break;
                        case 6:
                            // History
                            stats.History += stats.PB;
                            break;
                        case 7:
                            // Insight
                            stats.Insight += stats.PB;
                            break;
                        case 8:
                            // Intimidation
                            stats.Intimidation += stats.PB;
                            break;
                        case 9:
                            // Investigation
                            stats.Investigation += stats.PB;
                            break;
                        case 10:
                            // Medicine
                            stats.Medicine += stats.PB;
                            break;
                        case 11:
                            // Nature
                            stats.Nature += stats.PB;
                            break;
                        case 12:
                            // Perception
                            stats.Perception += stats.PB;
                            break;
                        case 13:
                            // Performance
                            stats.Performance += stats.PB;
                            break;
                        case 14:
                            // Persuasion
                            stats.Persuasion += stats.PB;
                            break;
                        case 15:
                            // Religion
                            stats.Religion += stats.PB;
                            break;
                        case 16:
                            // Sleight Of Hand
                            stats.SleightOfHand += stats.PB;
                            break;
                        case 17:
                            // Stealth
                            stats.Stealth += stats.PB;
                            break;
                        case 18:
                            // Survival
                            stats.Survival += stats.PB;
                            break;
                        default:
                            throw new ArgumentException("This skill does not exist.");
                    }
                }
            }
            else
            {
                throw new ArgumentNullException("Character Stats cannot be null...");
            }

        }
    }
}
