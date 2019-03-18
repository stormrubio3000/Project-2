using ANightsTale.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANightsTale.DataAccess
{
    class Mapper
    {
        public static Library.Character Map(Character character) => new Library.Character
        {
            Name = character.Name,
            CampaignID = character.CampaignId,
            RaceID = character.RaceId,
            ClassID = character.ClassId,
            Experience = (int)character.Experience,
            Level = (int)character.Level,
            Str = character.Str,
            Dex = character.Dex,
            Con = character.Con,
            Int = character.Int,
            Wis = character.Wis,
            Cha = character.Cha,
            Speed = character.Speed,
            MaxHP = character.MaxHp
        };

        public static Character Map(Library.Character character) => new Character
        {
            Name = character.Name,
            CampaignId = character.CampaignID,
            RaceId = character.RaceID,
            ClassId = character.ClassID,
            Experience = (int)character.Experience,
            Level = (int)character.Level,
            Str = character.Str,
            Dex = character.Dex,
            Con = character.Con,
            Int = character.Int,
            Wis = character.Wis,
            Cha = character.Cha,
            Speed = character.Speed,
            MaxHp = character.MaxHP
        };

        public static Library.CharStats Map(CharStats c) => new Library.CharStats
        {
            CharacterID = c.CharacterId,
            HP = c.Hp,
            AC = c.Ac,
            PB = c.Pb,
            Gold = c.Gold,
            Acrobatics = c.Acrobatics,
            AnimalHandling = c.AnimalHandling,
            Arcana = c.Arcana,
            Athletics = c.Athletics,
            Deception = c.Deception,
            History = c.History,
            Insight = c.Insight,
            Investigation = c.Investigation,
            Intimidation = c.Intimidation,
            Medicine = c.Medicine,
            Nature = c.Nature,
            Perception = c.Perception,
            Performance = c.Performance,
            Persuasion = c.Persuasion,
            Religion = c.Religion,
            SleightOfHand = c.SleightOfHand,
            Stealth = c.Stealth,
            Survival = c.Survival,
            STR_Save = c.StrSave,
            DEX_Save = c.DexSave,
            CON_Save = c.ConSave,
            INT_Save = c.IntSave,
            WIS_Save = c.WisSave,
            CHA_Save = c.ChaSave,
            STR_Mod = c.StrMod,
            DEX_Mod = c.DexMod,
            CON_Mod = c.ConMod,
            INT_Mod = c.IntMod,
            WIS_Mod = c.WisMod,
            CHA_Mod = c.ChaMod
        };

        public static CharStats Map(Library.CharStats c) => new CharStats
        {
            CharacterId = c.CharacterID,
            Hp = c.HP,
            Ac = c.AC,
            Pb = c.PB,
            Gold = c.Gold,
            Acrobatics = c.Acrobatics,
            AnimalHandling = c.AnimalHandling,
            Arcana = c.Arcana,
            Athletics = c.Athletics,
            Deception = c.Deception,
            History = c.History,
            Insight = c.Insight,
            Investigation = c.Investigation,
            Intimidation = c.Intimidation,
            Medicine = c.Medicine,
            Nature = c.Nature,
            Perception = c.Perception,
            Performance = c.Performance,
            Persuasion = c.Persuasion,
            Religion = c.Religion,
            SleightOfHand = c.SleightOfHand,
            Stealth = c.Stealth,
            Survival = c.Survival,
            StrSave = c.STR_Save,
            DexSave = c.DEX_Save,
            ConSave = c.CON_Save,
            IntSave = c.INT_Save,
            WisSave = c.WIS_Save,
            ChaSave = c.CHA_Save,
            StrMod = c.STR_Mod,
            DexMod = c.DEX_Mod,
            ConMod = c.CON_Mod,
            IntMod = c.INT_Mod,
            WisMod = c.WIS_Mod,
            ChaMod = c.CHA_Mod
        };

        public static Library.Class Map(Class c) => new Library.Class
        {
            ClassID = c.ClassId,
            Name = c.Name,
            Description = c.Name
        };

        public static Class Map(Library.Class c) => new Class
        {
            ClassId = c.ClassID,
            Name = c.Name,
            Description = c.Name
        };

        public static Library.Race Map(Race r) => new Library.Race
        {
            RaceID = r.RaceId,
            Name = r.Name,
            Description = r.Name
        };

        public static Race Map(Library.Race r) => new Race
        {
            RaceId = r.RaceID,
            Name = r.Name,
            Description = r.Name
        };

        public static Library.Abilities Map(Abilities r) => new Library.Abilities
        {
            AbilityID = r.AbilityId,
            Name = r.Name,
            Description = r.Name,
            NumDice = r.NumDice,
            NumSides = r.NumSides,
            Attack = r.Attack
        };

        public static Abilities Map(Library.Abilities r) => new Abilities
        {
            AbilityId = r.AbilityID,
            Name = r.Name,
            Description = r.Name,
            NumDice = r.NumDice,
            NumSides = r.NumSides,
            Attack = r.Attack
        };

        public static IEnumerable<Library.Abilities> Map(IEnumerable<Abilities> abilities) => abilities.Select(Map);
        public static IEnumerable<Abilities> Map(IEnumerable<Library.Abilities> abilities) => abilities.Select(Map);

        public static Library.Item Map(Item r) => new Library.Item
        {
            ItemID = r.ItemId,
            Name = r.Name,
            Description = r.Name,
            NumDice = r.NumDice,
            NumSides = r.NumSides,
            Mods = r.Mods
        };

        public static Item Map(Library.Item r) => new Item
        {
            ItemId = r.ItemID,
            Name = r.Name,
            Description = r.Name,
            NumDice = r.NumDice,
            NumSides = r.NumSides,
            Mods = r.Mods
        };

        public static IEnumerable<Library.Item> Map(IEnumerable<Item> item) => item.Select(Map);
        public static IEnumerable<Item> Map(IEnumerable<Library.Item> item) => item.Select(Map);

        public static Library.Campaign Map(Campaign r) => new Library.Campaign
        {
            CampaingID = r.CampaignId,
            Name = r.Name,
        };

        public static Campaign Map(Library.Campaign r) => new Campaign
        {
            CampaignId = r.CampaingID,
            Name = r.Name,
        };

        public static IEnumerable<Library.Campaign> Map(IEnumerable<Campaign> campaign) => campaign.Select(Map);
        public static IEnumerable<Campaign> Map(IEnumerable<Library.Campaign> campaign) => campaign.Select(Map);
    }
}
