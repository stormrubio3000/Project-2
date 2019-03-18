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
	GameID int primary key identity,
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
	Description nvarchar(max) not null
)


--drop table Game.Character
create table Game.Character (
	CharacterID int primary key identity,
	Name nvarchar(75) not null,
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


insert into Game.Class(Name,Description) values 
	('Barbarian', 'A fierce warrior of primitive background who can enter a battle rage.'),
	('Fighter','A master of martial combat, skilled with a variety of weapons and armor.'),
	('Paladin','A holy warrior bound to a sacred oath.'),
	('Bard', 'An inspiring magician whose power echoes the music of creation.'),
	('Sorcerer', 'A spellcaster who draws on inherent magic from a gift or bloodline.'),
	('Cleric', 'A priestly champion who wields divine magic in service of a higher power.'),
	('Druid', 'A priest of the Old Faith, wielding the powers of nature—moonlight and plant growth, fire and lightning—and adopting animal forms.'),
	('Ranger', 'A warrior who uses martial prowess and nature magic to combat threats on the edges of civilization.'),
	('Rogue', 'A scoundrel who uses stealth and trickery to overcome obstacles and enemies.'),
	('Wizard', 'A scholarly magic-user capable of manipulating the structures of reality')

insert into Game.Race(Name,Description) values 
	('Dwarf', 'Dwarves are solid and enduring like the mountains they love, weathering the passage of centuries with stoic endurance and little change.'),
	('Human', 'Whatever drives them, humans are the innovators, the achievers, and the pioneers of the worlds.'),
	('Elf', 'Elves are a magical people of otherworldly grace, living in the world but not entirely part of it.'),
	('Halfling', 'The comforts of home are the goals of most halflings’ lives: a place to settle in peace and quiet, far from marauding monsters and clashing armies.'),
	('Gnomes', 'Gnomes take delight in life, enjoying every moment of invention, exploration, investigation, creation, and play.'),
	('Half-Orc', 'Half-orcs are not evil by nature, but evil does lurk within them, whether they embrace it or rebel against it.')





insert into Game.Character(Name,CampaignID,RaceID,ClassID,UsersID,Str,Dex,Con,Int,Wis,CHA,Speed,MaxHP) values
	('sparticustard', 1,3,5,1,17,15,12,7,9,12,30,12),
	('ANERD', 1,1,1,2,22,5,19,13,4,3,30,10)


insert into Game.Abilities(Name,Description,NumDice,NumSides,Attack) values
	('Bash', 'The Warrior strikes down on the head of their foe with a reckless fury',null,null,1),
	('FireBolt', 'The Mage unleashes a bolt of fire to scorch their foes.',1,10,1),
	('Teleport', 'The Mage teleports away in a poof of smoke.',null,null,0)


insert into Game.CharAbilities(CharacterID,AbilityID,Mods) values
	(1,1,5),
	(2,2,0),
	(2,3,null)


insert into Game.Feats(Name,Description,StatTable,StatType,Mods) values
	('Im not sure where this goes', 'But it will be a thing somewhere',0,4,1),
	('This will also be a place','When I find out where this will change',1,2,1)


insert into Game.CharFeats(CharacterID,FeatID) values
	(1,2),
	(2,1)


insert into Game.Item(Name,Description,Type,AC,NumDice,NumSides,Mods,Effects) values
	('Longsword', 'A standard Longsword', 1,null,1,8,0,'No Effects'),
	('Candle','You no take!',3000,null,null,null,null,'Cannot be taken'),
	('SplintMail','Standard Splint linked mail',2000,14,null,null,0,'No Effects')


insert into Game.Inventory(CharacterID,ItemID,Quantity,ToggleE) values 
	(1,1,1,1),
	(1,3,1,1),
	(2,2,10,0)


insert into Game.CharStats(CharacterID,HP,AC,PB,Gold,Acrobatics,AnimalHandling,Arcana,Athletics,Deception,History,
Insight,Intimidation,Investigation,Medicine,Nature,Perception,Performance,Persuasion,Religion,SleightOfHand,Stealth,
Survival,STR_Save,DEX_Save,CON_Save,INT_Save,WIS_Save,CHA_Save,STR_Mod,DEX_Mod,CON_Mod,INT_Mod,WIS_Mod,CHA_Mod) values
	(1,12,10,2,0,1,2,1,2,3,1,2,3,2,1,2,3,1,2,3,2,1,2,3,2,2,2,1,2,1,2,1,2,1,1),
	(2,10,11,2,2,1,2,1,2,3,1,2,1,2,1,2,3,1,2,3,2,1,2,1,2,2,2,1,2,3,2,1,3,1,1)


select * from Game.Info
select * from Game.userCampaign
select * from Game.Users
select * from Game.Campaign
select * from Game.Class
select * from Game.Race
select * from Game.Character
select * from Game.Abilities
select * from Game.CharAbilities
select * from Game.Feats
select * from Game.CharFeats
select * from Game.Inventory
select * from Game.Item

