CREATE DATABASE `kasiaskynote` /*!40100 DEFAULT CHARACTER SET utf8 */;

CREATE TABLE `locations` (
  `LocationId` int(11) NOT NULL AUTO_INCREMENT,
  `XCord` decimal(10,0) DEFAULT NULL,
  `YCord` decimal(10,0) DEFAULT NULL,
  `ZCord` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`LocationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `notes` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) DEFAULT NULL,
  `LocationId` int(11) DEFAULT NULL,
  `Topic` varchar(45) DEFAULT NULL,
  `Content` varchar(200) DEFAULT NULL,
  `Date` varchar(45) DEFAULT 'CURRENT_DATE',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `users` (
  `UserID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Login` varchar(20) DEFAULT NULL,
  `Mail` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `PasswordSalt` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE `kasiaskynote`.`notes` 
DROP FOREIGN KEY `LocationId`;
ALTER TABLE `kasiaskynote`.`notes` 
ADD CONSTRAINT `LocationId`
  FOREIGN KEY (`LocationId`)
  REFERENCES `kasiaskynote`.`locations` (`LocationId`)
  ON DELETE NO ACTION
  ON UPDATE CASCADE;


ALTER TABLE `kasiaskynote`.`notes` 
DROP FOREIGN KEY `UserId`;
ALTER TABLE `kasiaskynote`.`notes` 
ADD CONSTRAINT `UserId`
  FOREIGN KEY (`UserId`)
  REFERENCES `kasiaskynote`.`users` (`UserID`)
  ON DELETE NO ACTION
  ON UPDATE CASCADE;
