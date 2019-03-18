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
	constraint Fk_Char_to_Class foreign key (ClassID) references Game.Class(ClassID) on update cascade on delete cascade
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
		REFERENCES Game.Character (CharacterID) ON DELETE CASCADE
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
	CONSTRAINT FK_CharAb_To_Character FOREIGN KEY (CharacterID) REFERENCES Game.Character (CharacterID),
	CONSTRAINT FK_CharAb_To_Abilities FOREIGN KEY (AbilityID) REFERENCES Game.Abilities (AbilityID)
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
	CONSTRAINT FK_CharFeat_To_Character FOREIGN KEY (CharacterID) REFERENCES Game.Character (CharacterID),
	CONSTRAINT FK_CharFeat_To_Feats FOREIGN KEY (FeatID) REFERENCES Game.Feats (FeatID)
);

insert into Game.Users (Username, Password, Email) values 
('this','thing','sucks')


select * from Game.Users