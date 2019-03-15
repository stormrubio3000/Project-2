--create schema Game

drop table Game.userCampaign 
drop table Game.Info
drop table Game.Inventory
drop table Game.Character
drop table Game.Race
drop table Game.Class


drop table Game.Item
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
	constraint Fk_I_to_Item foreign key (ItemID) references Game.Item(ItemID) on update cascade on delete cascade
)




insert into Game.Users (Username, Password, Email) values 
('this','thing','sucks')


select * from Game.Users