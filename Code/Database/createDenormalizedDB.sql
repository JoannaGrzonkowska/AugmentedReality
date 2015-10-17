
CREATE TABLE `note` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) DEFAULT NULL,  
  `Topic` varchar(45) DEFAULT NULL,
  `Content` varchar(200) DEFAULT NULL,
  `Date` datetime,
  `LocationId` int(11) NOT NULL,
  `XCord` decimal(10,8) DEFAULT NULL,
  `YCord` decimal(10,8) DEFAULT NULL,
  `ZCord` decimal(10,8) DEFAULT NULL,  
  `Name` varchar(45) DEFAULT NULL,
  `Login` varchar(20) DEFAULT NULL,
  `Mail` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
