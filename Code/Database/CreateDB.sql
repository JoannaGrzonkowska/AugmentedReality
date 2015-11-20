
CREATE TABLE `location` (
  `LocationId` int(11) NOT NULL AUTO_INCREMENT,
  `XCord` decimal(10,0) DEFAULT NULL,
  `YCord` decimal(10,0) DEFAULT NULL,
  `ZCord` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`LocationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `user` (
  `UserID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Login` varchar(20) DEFAULT NULL,
  `Mail` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `PasswordSalt` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `note` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) DEFAULT NULL,
  `LocationId` int(11) DEFAULT NULL,
  `Topic` varchar(45) DEFAULT NULL,
  `Content` varchar(200) DEFAULT NULL,
  `Date` Datetime ,
  PRIMARY KEY (`Id`),
  FOREIGN KEY (`LocationId`) REFERENCES `location` (`LocationId`),
FOREIGN KEY (`UserId`) REFERENCES `user` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `group` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `usergroup` (
  `UsergroupId` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) NOT NULL ,
  `GroupId` int(11) NOT NULL,
  PRIMARY KEY (`UsergroupId`),
	FOREIGN KEY (`UserId`) REFERENCES `user`(UserID) ON UPDATE CASCADE,  
    FOREIGN KEY (`GroupId`) REFERENCES `group`(Id) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `userfriends` (
  `UserfriendsId` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) NOT NULL ,
  `FriendId` int(11) NOT NULL,
  PRIMARY KEY (`UserfriendsId`),
	FOREIGN KEY (`UserId`) REFERENCES `user`(UserID) ON UPDATE CASCADE,  
    FOREIGN KEY (`FriendId`) REFERENCES `user`(UserID) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `notesGroups` (
  `NotesgroupsId` int(11) NOT NULL AUTO_INCREMENT,
  `NoteId` int(11) NOT NULL ,
  `GroupId` int(11) NOT NULL,
  PRIMARY KEY (`NotesgroupsId`),
	FOREIGN KEY (`NoteId`) REFERENCES `note`(Id) ON UPDATE CASCADE,  
    FOREIGN KEY (`GroupId`) REFERENCES `group`(Id) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



CREATE TABLE `categories` (
  `CategoryId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`CategoryId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `types` (
  `TypeId` int(11) NOT NULL AUTO_INCREMENT,
  `CategoryId` int(11) NOT NULL,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`TypeId`),
	FOREIGN KEY (`CategoryId`) REFERENCES `categories`(CategoryId) ON UPDATE CASCADE 
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE `note` 
ADD COLUMN `TypeId` INT(11) NULL DEFAULT NULL AFTER `Date`,
ADD COLUMN `CategoryId` INT(11) NULL DEFAULT NULL AFTER `TypeId`,
ADD INDEX `note_category_idx` (`CategoryId` ASC),
ADD INDEX `note_type_idx` (`TypeId` ASC);
ALTER TABLE `skynotedbnormal`.`note` 
ADD CONSTRAINT `note_category`
  FOREIGN KEY (`CategoryId`)
  REFERENCES `categories` (`CategoryId`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `note_type`
  FOREIGN KEY (`TypeId`)
  REFERENCES `types` (`TypeId`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;
  
  ALTER TABLE `note` 
DROP FOREIGN KEY `note_category`;
ALTER TABLE `note` 
DROP COLUMN `CategoryId`,
DROP INDEX `note_category_idx` ;
  
INSERT INTO `categories` (`CategoryId`, `Name`) VALUES ('1', 'Gastronomia');
INSERT INTO `categories` (`CategoryId`, `Name`) VALUES ('2', 'Zabytki');
INSERT INTO `categories` (`CategoryId`, `Name`) VALUES ('3', 'Edukacja');
INSERT INTO `categories` (`CategoryId`, `Name`) VALUES ('4', 'Zdrowie');
INSERT INTO `categories` (`CategoryId`, `Name`) VALUES ('5', 'Rekreacja');
INSERT INTO `categories` (`CategoryId`, `Name`) VALUES ('6', 'Firmy');
INSERT INTO `categories` (`CategoryId`, `Name`) VALUES ('7', 'Transport');

INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('1', '1', 'Restauracja');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('2', '1', 'Fastfood');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('3', '1', 'Bar mleczny');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('4', '2', 'Kościół');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('5', '2', 'Muzeum');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('6', '2', 'Skansem');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('7', '3', 'Przedszkole');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('8', '3', 'Szkoła podstawowa');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('9', '3', 'Gimnazjum');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('10', '3', 'Liceum ogólnokształcące');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('11', '3', 'Liceum profilowane');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('12', '3', 'Szkoła zawodowa');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('13', '3', 'Uczelnia wyższa');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('14', '3', 'Biblioteka');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('15', '4', 'Szpital');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('16', '4', 'Przychodnia');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('17', '4', 'Apteka');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('18', '5', 'Park');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('19', '5', 'Kino');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('20', '5', 'Teatr');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('21', '5', 'Opera');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('22', '6', 'Usługi');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('23', '6', 'Produkcja');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('24', '6', 'Handel');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('25', '7', 'Port');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('26', '7', 'Lotnisko');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('27', '7', 'Autobus');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('28', '7', 'Tramwaj');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('29', '7', 'Trolejbus');
INSERT INTO `types` (`TypeId`, `CategoryId`, `Name`) VALUES ('30', '7', 'Taksówka');
