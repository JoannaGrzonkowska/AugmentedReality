/*CREATE DATABASE `skynotedb` /*!40100 DEFAULT CHARACTER SET utf8 */;

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
  `UserId` int(11) NOT NULL ,
  `GroupId` int(11) NOT NULL,
  PRIMARY KEY (`UserId`, `GroupId`),
	FOREIGN KEY (`UserId`) REFERENCES `user`(UserID) ON UPDATE CASCADE,  
    FOREIGN KEY (`GroupId`) REFERENCES `group`(Id) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE `note` 
ALTER TABLE `note` 
