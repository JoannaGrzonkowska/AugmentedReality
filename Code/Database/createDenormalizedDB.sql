
CREATE TABLE `note` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) DEFAULT NULL,  
  `Topic` varchar(45) DEFAULT NULL,
  `Content` varchar(200) DEFAULT NULL,
  `Date` TimeStamp,
  `LocationId` int(11) NOT NULL,
  `XCord` decimal(10,7) DEFAULT NULL,
  `YCord` decimal(10,7) DEFAULT NULL,
  `ZCord` decimal(10,7) DEFAULT NULL,  
  `Name` varchar(45) DEFAULT NULL,
  `Login` varchar(20) DEFAULT NULL,
  `Mail` varchar(45) DEFAULT NULL,
  `GroupId` int(11) NOT NULL,
  `GroupName` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `group` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `GroupId` int(11) DEFAULT NULL,  
  `GroupName` varchar(45) DEFAULT NULL,
  `Role` varchar(45) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,    
  `UserName` varchar(45) DEFAULT NULL,
  `UserLogin` varchar(20) DEFAULT NULL,
  `UserMail` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE `group` 
ADD COLUMN `FriendName` VARCHAR(45) NULL DEFAULT NULL AFTER `UserMail`,
ADD COLUMN `FriendLogin` VARCHAR(20) NULL DEFAULT NULL AFTER `FriendName`,
ADD COLUMN `FriendMail` VARCHAR(45) NULL DEFAULT NULL AFTER `FriendLogin`,
ADD COLUMN `FriendId` INT(11) NULL DEFAULT NULL AFTER `FriendMail`;

ALTER TABLE `note` 
CHANGE COLUMN `Date` `Date` TIMESTAMP NULL DEFAULT NULL ;

ALTER TABLE `note` 
CHANGE COLUMN `LocationId` `LocationId` INT(11) NULL DEFAULT NULL ,
CHANGE COLUMN `GroupId` `GroupId` INT(11) NULL DEFAULT NULL ;

ALTER TABLE `note` 
ADD COLUMN `Identyfication` VARCHAR(45) NULL DEFAULT NULL AFTER `GroupName`;
ALTER TABLE `note` change  `Id` `NoteId` VARCHAR(45);

ALTER TABLE `note` 
ADD COLUMN `CategoryId` INT(11) NULL DEFAULT NULL AFTER `NoteId`,
ADD COLUMN `CategoryName` VARCHAR(45) NULL DEFAULT NULL AFTER `CategoryId`,
ADD COLUMN `TypeId` INT(11) NULL DEFAULT NULL AFTER `CategoryName`,
ADD COLUMN `TypeName` VARCHAR(45) NULL DEFAULT NULL AFTER `TypeId`;





CREATE TABLE `invites` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `State` varchar(45) DEFAULT NULL,
  
  `GroupId` int(11) DEFAULT NULL,  
  `GroupName` varchar(45) DEFAULT NULL,
    
  `UserId` int(11) DEFAULT NULL,    
  `UserName` varchar(45) DEFAULT NULL,
  `UserLogin` varchar(20) DEFAULT NULL,
  `UserMail` varchar(45) DEFAULT NULL,
    
  `FriendId` int(11) DEFAULT NULL,    
  `FriendName` varchar(45) DEFAULT NULL,
  `FriendLogin` varchar(20) DEFAULT NULL,
  `FriendMail` varchar(45) DEFAULT NULL,
  
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
