--create schema Game





drop table Game.CharFeats
drop table Game.CharAbilities
drop table Game.CharStats
drop table Game.Feats
drop table Game.Abilities
drop table Game.Inventory
drop table Game.Item
drop table Game.Character
drop table Game.Race
drop table Game.Class
drop table Game.userCampaign 
drop table Game.Info
drop table Game.Campaign
drop table Game.Users


--drop table Game.Users
create table Game.Users(
	UsersID int primary key identity,
	Username nvarchar(200) unique not null,
	Password nvarchar(200) not null,
	Permission int default(0),
	Email nvarchar(200) not null
)




--drop table Game.Campaign
create table Game.Campaign(
	CampaignID int primary key identity,
	Name nvarchar(200) unique not null
)


--drop  table Game.userCampaign 
create table Game.userCampaign (
	UserID int not null,
	CampaignID int not null,
	DateCreated datetime2 default(GETDATE()),
	primary key (UserID, CampaignID),
	constraint FK_UC_to_U foreign key (UserID) references Game.Users(UsersID) on update cascade on delete cascade,
	constraint FK_UC_to_C foreign key (CampaignID) references Game.Campaign(CampaignID) on update cascade on delete cascade
)


--drop table Game.Info
create table Game.Info(
	InfoID int primary key identity,
	Type nvarchar(50) not null,
	Message nvarchar(max) not null,
	CampaignID int not null,
	constraint FK_I_to_C foreign key (CampaignID) references Game.Campaign(CampaignID) on update cascade on delete cascade
)


--drop table Game.Race
create table Game.Race(
	RaceID int primary key identity,
	Name nvarchar(50) not null,
	Description nvarchar(max) not null
)


--drop table Game.Class
create table Game.Class(
	ClassID int primary key identity,
	Name nvarchar(50) not null,
	Description nvarchar(max) not null,
	HD int not null
)


--drop table Game.Character
create table Game.Character (
	CharacterID int primary key identity,
	Name nvarchar(75) not null,
	Bio nvarchar(max) null,
	UsersID int not null,
	CampaignID int not null,
	RaceID int not null,
	ClassID int not null,
	experience int default(0),
	Level int default(1),
	Str int not null,
	Dex int not null,
	Con int not null,
	Int int not null,
	Wis int not null,
	CHA int not null,
	Speed int not null,
	MaxHP int not null,
	constraint FK_Char_to_C foreign key (CampaignID) references Game.Campaign(CampaignID) on update cascade on delete cascade,
	constraint FK_Char_to_Race foreign key (RaceID) references Game.Race(RaceID) on update cascade on delete cascade,
	constraint Fk_Char_to_Class foreign key (ClassID) references Game.Class(ClassID) on update cascade on delete cascade,
	constraint Fk_Char_to_User foreign key (UsersID) references Game.Users(UsersID) on update cascade on delete cascade
)


create table Game.Item(
	ItemID int primary key identity,
	Name nvarchar(max) not null,
	Description nvarchar(max) not null,
	Type int not null,
	AC int null,
	NumDice int null,
	NumSides int null,
	Mods int null,
	Effects nvarchar(max) 
)



--drop table Game.Inventory
create table Game.Inventory(
	CharacterID int not null,
	ItemID int not null,
	Quantity int not null,
	ToggleE bit default(0),
	constraint FK_I_to_Char foreign key (CharacterID) references Game.Character(CharacterID) on update cascade on delete cascade,
	constraint Fk_I_to_Item foreign key (ItemID) references Game.Item(ItemID) on update cascade on delete cascade,
	primary key (CharacterID, ItemID)
)


CREATE TABLE Game.CharStats (
	ID INT PRIMARY KEY IDENTITY,
	CharacterID INT NOT NULL,
	HP INT NOT NULL,
	AC INT NOT NULL,
	PB INT NOT NULL,
	Gold INT NOT NULL,
	Acrobatics iNT NOT NULL,
	AnimalHandling INT NOT NULL,
	Arcana INT NOT NULL,
	Athletics INT NOT NULL,
	Deception INT NOT NULL,
	History INT NOT NULL,
	Insight INT NOT NULL,
	Intimidation INT NOT NULL,
	Investigation INT NOT NULL,
	Medicine INT NOT NULL,
	Nature INT NOT NULL,
	Perception INT NOT NULL,
	Performance INT NOT NULL,
	Persuasion INT NOT NULL,
	Religion INT NOT NULL,
	SleightOfHand INT NOT NULL,
	Stealth INT NOT NULL,
	Survival INT NOT NULL,
	STR_Save INT NOT NULL,
	DEX_Save INT NOT NULL,
	CON_Save INT NOT NULL,
	INT_Save INT NOT NULL,
	WIS_Save INT NOT NULL,
	CHA_Save INT NOT NULL,
	STR_Mod INT NOT NULL,
	DEX_Mod INT NOT NULL,
	CON_Mod INT NOT NULL,
	INT_Mod INT NOT NULL,
	WIS_Mod INT NOT NULL,
	CHA_Mod INT NOT NULL
	CONSTRAINT Stats_To_Char FOREIGN KEY (CharacterID) 
		REFERENCES Game.Character (CharacterID) ON DELETE CASCADE on update cascade
);



CREATE TABLE Game.Abilities (
	AbilityID INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(MAX) NOT NULL,
	Description NVARCHAR(MAX) NULL,
	RequiredLV int not null,
	RequiredClass int not null,
	NumDice INT NULL,
	NumSides INT NULL,
	Attack BIT
);

CREATE TABLE Game.CharAbilities (
	CharacterID INT NOT NULL,
	AbilityID INT NOT NULL,
	Mods INT
	CONSTRAINT PK_CharAbilities PRIMARY KEY (CharacterID, AbilityID),
	CONSTRAINT FK_CharAb_To_Character FOREIGN KEY (CharacterID) REFERENCES Game.Character (CharacterID) on delete cascade on update cascade,
	CONSTRAINT FK_CharAb_To_Abilities FOREIGN KEY (AbilityID) REFERENCES Game.Abilities (AbilityID) on delete cascade on update cascade
);

CREATE TABLE Game.Feats (
	FeatID INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(MAX) NOT NULL,
	Description NVARCHAR(MAX),
	RequiredLV int not null,
	RequiredClass int not null,
	StatTable BIT NOT NULL,
	StatType INT NOT NULL,
	Mods INT NOT NULL
);

CREATE TABLE Game.CharFeats (
	CharacterID INT NOT NULL,
	FeatID INT NOT NULL,
	CONSTRAINT PK_CharFeats PRIMARY KEY (CharacterID, FeatID),
	CONSTRAINT FK_CharFeat_To_Character FOREIGN KEY (CharacterID) REFERENCES Game.Character (CharacterID) on delete cascade on update cascade,
	CONSTRAINT FK_CharFeat_To_Feats FOREIGN KEY (FeatID) REFERENCES Game.Feats (FeatID) on delete cascade on update cascade
);

insert into Game.Users (Username, Password, Email) values 
	('Lee2382','totallylegitpassword.exe','Arealemail@nmail'),
	('thatoneguy2','password.virus','areemailsreal@lol.com')

insert into Game.Users (Username, Password, Email, Permission) values 
	('LeetHazer45','123abc','youcantmakeme@no',1)


insert into Game.Campaign (Name) values
	('1001 tales')



insert into Game.userCampaign(CampaignID,UserID) values 
	(1,1),
	(1,2),
	(1,3)


insert into Game.Info (CampaignID,type,Message) values
	(1,'intro','So there was this one time at band camp')


insert into Game.Class(Name,Description,HD) values 
	('Barbarian', 'A fierce warrior of primitive background who can enter a battle rage.',12),
	('Fighter','A master of martial combat, skilled with a variety of weapons and armor.',10),
	('Paladin','A holy warrior bound to a sacred oath.',10),
	('Bard', 'An inspiring magician whose power echoes the music of creation.',8),
	('Sorcerer', 'A spellcaster who draws on inherent magic from a gift or bloodline.',6),
	('Cleric', 'A priestly champion who wields divine magic in service of a higher power.',8),
	('Druid', 'A priest of the Old Faith, wielding the powers of nature�moonlight and plant growth, fire and lightning�and adopting animal forms.',8),
	('Ranger', 'A warrior who uses martial prowess and nature magic to combat threats on the edges of civilization.',10),
	('Rogue', 'A scoundrel who uses stealth and trickery to overcome obstacles and enemies.',8),
	('Wizard', 'A scholarly magic-user capable of manipulating the structures of reality',6)

insert into Game.Race(Name,Description) values 
	('Dwarf', 'Dwarves are solid and enduring like the mountains they love, weathering the passage of centuries with stoic endurance and little change.'),
	('Human', 'Whatever drives them, humans are the innovators, the achievers, and the pioneers of the worlds.'),
	('Elf', 'Elves are a magical people of otherworldly grace, living in the world but not entirely part of it.'),
	('Halfling', 'The comforts of home are the goals of most halflings� lives: a place to settle in peace and quiet, far from marauding monsters and clashing armies.'),
	('Gnomes', 'Gnomes take delight in life, enjoying every moment of invention, exploration, investigation, creation, and play.'),
	('Half-Orc', 'Half-orcs are not evil by nature, but evil does lurk within them, whether they embrace it or rebel against it.')





insert into Game.Character(Name,CampaignID,RaceID,ClassID,UsersID,Str,Dex,Con,Int,Wis,CHA,Speed,MaxHP) values
	('sparticustard',1,3,5,1,17,15,12,7,9,12,30,12),
	('ANERD',1,1,1,2,22,5,19,13,4,3,30,10)


insert into Game.Abilities(Name,Description,RequiredClass,RequiredLV,NumDice,NumSides,Attack) values
	('Attack', 'The character attacks with their weapon',11,1,null,null,1),
	('Rage', 'The Barbarian flies into a rage',1,1,null,null,0),
	('Reckless Attack','The Barbarians attacks with a reckless fury',1,2,1,20,1),
	('Second Wind', 'The Fighter draws on inner stamina',2,1,1,10,0),
	('Action Surge', 'The Fighter takes an additonal action',2,2,null,null,0),
	('Lay on Hands', 'The Paladin draws on holy energy to heal an ally',3,1,null,5,0),
	 
	('FireBolt', 'The Mage unleashes a bolt of fire to scorch their foes.',1,2,1,10,1),
	('Teleport', 'The Mage teleports away in a poof of smoke.',3,2,null,null,0)


insert into Game.CharAbilities(CharacterID,AbilityID,Mods) values
	(1,1,5),
	(2,2,0),
	(2,3,null)


insert into Game.Feats(Name,Description,RequiredLV,RequiredClass,StatTable,StatType,Mods) values
	('Im not sure where this goes', 'But it will be a thing somewhere',1,1,0,4,1),
	('This will also be a place','When I find out where this will change',1,2,1,2,1)


insert into Game.CharFeats(CharacterID,FeatID) values
	(1,2),
	(2,1)


insert into Game.Item(Name,Description,Type,AC,NumDice,NumSides,Mods,Effects) values
	('Longsword', 'A standard Longsword', 1,null,1,8,0,'No Effects'),
	('Spear', 'A standard Spear',1,null,1,6,0,'No Effects'),
	('BattleAxe', 'A standard BattleAxe',1,null,1,8,0,'No Effects'),
	('Club', 'A standard Club',1,null,1,4,0,'No Effects'),
	('Dagger', 'A standard Dagger',1,null,1,4,0,'No Effects'),
	('Dart', 'A standard Dart',1,null,1,4,0,'No Effects'),
	('Flail', 'A standard Flail',1,null,1,8,0,'No Effects'),
	('GreatSword', 'A standard GreatSword',1,null,2,6,0,'No Effects'),
	('Halberd', 'A standard Halberd',1,null,1,10,0,'No Effects'),
	('Longbow','A standard Longbow', 1,null,1,8,0,'No Effects'),
	('QuarterStaff', 'A standard Quarterstaff',1,null,1,6,0,'No Effects'),
	('Shortbow', 'A standard Shortbow',1,null,1,6,0,'No Effects'),
	('Shortsword', 'A standard Shortsword',1,null,1,6,0,'No Effects'),
	('Sling', 'A standard Sling', 1,null,1,4,0,'No Effects'),
	('Spear', 'A standard Spear', 1,null,1,6,0,'No Effects'),
	('Warhammer', 'A standard Warhammer', 1,null,1,8,0,'No Effects'),
	('Flame Tongue', 'A Sword covered in writhing flames',1,null,3,8,1,'Sheds a bright light within a 40-foot radius'),
	('SplintMail','A standard SplintMail armor',2,17,null,null,0,'No Effects'),
	('Studded Leather', 'A standard Studded Leather Armor',2,12,null,null,0,'No Effects'),
	('ChainMail', 'A standard ChainMail armor',2,16,null,null,0,'No Effects'),
	('Leather', 'A standard Leather armor', 2,11,null,null,0,'No Effects'),
	('Plate', 'A standard Plate armor', 2,18,null,null,0,'No Effects'),
	('Demon Armor','A suit of armor made from the scales of slain demons',2,19,null,null,0,'Can speak Infernal while wearing the armor'),
	('Copper Ring', 'A ring made of copper', 3,0,null,null,null, 'No Effects'),
	('Silver Ring', 'A ring made of Silver', 3,0,null,null,null, 'No Effects'),
	('Gold Ring', 'A ring made of Gold', 3,0,null,null,null, 'No Effects'),
	('Ring of WaterBreathing', 'A Ring made from a gil of a Mermaid',3,0,null,null,null,'Can breath underwater while wearing'),
	('Copper Necklace', 'A Necklace made of copper', 4,0,null,null,null, 'No Effects'),
	('Silver Necklace', 'A Necklace made of Silver', 4,0,null,null,null, 'No Effects'),
	('Gold Necklace', 'A Necklace made of Gold', 4,0,null,null,null, 'No Effects'),
	('Amulet of Stone','A Elemental stone held together by a clasp',4,1,null,null,null,'Adds +1 to AC'),
	('Iron Helmet', 'A standard Helmet made of iron',5,0,null,null,null,'No Effects'),
	('Helm of NightVision', 'A helm forged in the UnderDark',5,0,null,null,null,'Casts NightVision on the wearer'),
	('Leather Boots', 'A standard pair of Boots made of leather',6,null,null,null,null,'No Effects'),
	('Boots of Speed', 'Unnaturally Quick Boots',6,0,null,null,null,'Casts Haste on the wearer'),
	('Candle','You no take!',7,null,null,null,null,'Cannot be taken')




--1. weapons 2. Armor 3. Rings  4. Amulets  5. Helmets  6. Boots  7. Misc
insert into Game.Inventory(CharacterID,ItemID,Quantity,ToggleE) values 
	(1,1,1,1),
	(1,24,1,1),
	(2,30,10,0)





insert into Game.CharStats(CharacterID,HP,AC,PB,Gold,Acrobatics,AnimalHandling,Arcana,Athletics,Deception,History,
Insight,Intimidation,Investigation,Medicine,Nature,Perception,Performance,Persuasion,Religion,SleightOfHand,Stealth,
Survival,STR_Save,DEX_Save,CON_Save,INT_Save,WIS_Save,CHA_Save,STR_Mod,DEX_Mod,CON_Mod,INT_Mod,WIS_Mod,CHA_Mod) values
	(1,12,10,2,0,1,2,1,2,3,1,2,3,2,1,2,3,1,2,3,2,1,2,3,2,2,2,1,2,1,2,1,2,1,1),
	(2,10,11,2,2,1,2,1,2,3,1,2,1,2,1,2,3,1,2,3,2,1,2,1,2,2,2,1,2,3,2,1,3,1,1)


--select * from Game.Info
--select * from Game.userCampaign
--select * from Game.Users
--select * from Game.Campaign
--select * from Game.Class
--select * from Game.Race
--select * from Game.Character
--select * from Game.Abilities
--select * from Game.CharAbilities
--select * from Game.Feats
--select * from Game.CharFeats
--select * from Game.Inventory
--select * from Game.Item

