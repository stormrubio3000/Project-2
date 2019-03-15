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