using ANightsTale.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANightsTale.DataAccess
{
    public class Mapper
    {
        public static Library.Character Map(Character character) => new Library.Character
        {
			CharacterID = character.CharacterId,
            Name = character.Name,
            Bio = character.Bio,
            CampaignID = character.CampaignId,
            UserId = character.UsersId,
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
			CharacterId = character.CharacterID,
            Name = character.Name,
            Bio = character.Bio,
            UsersId = character.UserId,
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

        public static IEnumerable<Library.Race> Map(IEnumerable<Race> race) => race.Select(Map);
        public static IEnumerable<Race> Map(IEnumerable<Library.Race> race) => race.Select(Map);

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

        public static IEnumerable<Library.Class> Map(IEnumerable<Class> c) => c.Select(Map);
        public static IEnumerable<Class> Map(IEnumerable<Library.Class> c) => c.Select(Map);

        public static Library.Feats Map(Feats r) => new Library.Feats
        {
            FeatID = r.FeatId,
            Name = r.Name,
            Description = r.Name,
            Mods = r.Mods,
            StatTable = r.StatTable,
            StatType = r.StatType
        };

        public static Feats Map(Library.Feats r) => new Feats
        {
            FeatId = r.FeatID,
            Name = r.Name,
            Description = r.Name,
            Mods = r.Mods,
            StatTable = r.StatTable,
            StatType = r.StatType
        };

        public static IEnumerable<Library.Feats> Map(IEnumerable<Feats> feats) => feats.Select(Map);
        public static IEnumerable<Feats> Map(IEnumerable<Library.Feats> feats) => feats.Select(Map);

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
            CampaignID = r.CampaignId,
            Name = r.Name,
        };

        public static Campaign Map(Library.Campaign r) => new Campaign
        {
            CampaignId = r.CampaignID,
            Name = r.Name,
        };

        public static IEnumerable<Library.Campaign> Map(IEnumerable<Campaign> campaign) => campaign.Select(Map);
        public static IEnumerable<Campaign> Map(IEnumerable<Library.Campaign> campaign) => campaign.Select(Map);

        public static Library.Info Map(Info r) => new Library.Info
        {
            InfoID = r.InfoId,
            Type = r.Type,
            Message = r.Message,
            CampaignID = r.CampaignId
        };

        public static Info Map(Library.Info r) => new Info
        {
            InfoId = r.InfoID,
            Type = r.Type,
            Message = r.Message,
            CampaignId = r.CampaignID
        };

        public static IEnumerable<Library.Info> Map(IEnumerable<Info> info) => info.Select(Map);
        public static IEnumerable<Info> Map(IEnumerable<Library.Info> info) => info.Select(Map);



        public static IEnumerable<Library.Character> Map(IEnumerable<Character> characters) => characters.Select(Map);
        public static IEnumerable<Character> Map(IEnumerable<Library.Character> characters) => characters.Select(Map);

        public static Library.Users Map(Users r) => new Library.Users
        {
            UserID = r.UsersId,
            Username = r.Username,
            Password = r.Password,
            Permission = r.Permission,
            Email = r.Email
        };

        public static Users Map(Library.Users r) => new Users
        {
            UsersId = r.UserID,
            Username = r.Username,
            Password = r.Password,
            Permission = r.Permission,
            Email = r.Email
        };

        public static IEnumerable<Library.Users> Map(IEnumerable<Users> user) => user.Select(Map);
        public static IEnumerable<Users> Map(IEnumerable<Library.Users> user) => user.Select(Map);

        public static Library.UserCampaign Map(UserCampaign r) => new Library.UserCampaign
        {
            UserID = r.UserId,
            CampaignID = r.CampaignId,
            DateCreated = r.DateCreated
        };

        public static UserCampaign Map(Library.UserCampaign r) => new UserCampaign
        {
            UserId = r.UserID,
            CampaignId = r.CampaignID,
            DateCreated = r.DateCreated
        };

        public static IEnumerable<Library.UserCampaign> Map(IEnumerable<UserCampaign> userCampaign) => userCampaign.Select(Map);
        public static IEnumerable<UserCampaign> Map(IEnumerable<Library.UserCampaign> userCampaign) => userCampaign.Select(Map);

        public static Library.Inventory Map(Inventory r) => new Library.Inventory
        {
            ItemID = r.ItemId,
            CharacterID = r.CharacterId,
            Quantity = r.Quantity,
            ToggleE = r.ToggleE
        };

        public static Inventory Map(Library.Inventory r) => new Inventory
        {
            ItemId = r.ItemID,
            CharacterId = r.CharacterID,
            Quantity = r.Quantity,
            ToggleE = r.ToggleE
        };

        public static IEnumerable<Library.Inventory> Map(IEnumerable<Inventory> iventory) => iventory.Select(Map);
        public static IEnumerable<Inventory> Map(IEnumerable<Library.Inventory> iventory) => iventory.Select(Map);
    }
}
