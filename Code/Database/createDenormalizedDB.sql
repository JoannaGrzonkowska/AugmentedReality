
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
  `UserMail` varchar(45) DEFAULT NULL
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


ALTER TABLE `note` 
ADD COLUMN `CategoryId` INT(11) NULL DEFAULT NULL AFTER `NoteId`,
ADD COLUMN `CategoryName` VARCHAR(45) NULL DEFAULT NULL AFTER `CategoryId`,
ADD COLUMN `TypeId` INT(11) NULL DEFAULT NULL AFTER `CategoryName`,
ADD COLUMN `TypeName` VARCHAR(45) NULL DEFAULT NULL AFTER `TypeId`;

ALTER TABLE `note` 
ADD COLUMN `LocationPoint` POINT NULL;

ALTER TABLE `note` 
ENGINE = MyISAM ;


UPDATE `note`
 SET 
`LocationPoint` = POINT(XCord, YCord);

ALTER TABLE `note` 
CHANGE COLUMN `LocationPoint` `LocationPoint` POINT NOT NULL;


ALTER TABLE note ADD SPATIAL INDEX(LocationPoint);

PROCEDURE `insert_note`(
userIdParam INT(11),
topicParam VARCHAR(45),
contentParam VARCHAR(200),
locationIdParam INT(11),
xCordParam INT(11),
yCordParam INT(11),
zCordParam INT(11),
nameParam VARCHAR(45),
loginParam VARCHAR(20),
mailParam VARCHAR(45),
groupIdParam INT(11),
groupNameParam VARCHAR(45),
identyficationParam VARCHAR(45),
dateParam TIMESTAMP,
noteIdParam INT(11),
categoryIdParam INT(11),
categoryNameParam VARCHAR(45),
typeIdParam INT(11),
typeNameParam VARCHAR(45)
)
BEGIN
INSERT INTO `note`
(`UserId`,
`Topic`,
`Content`,
`LocationId`,
`XCord`,
`YCord`,
`ZCord`,
`Name`,
`Login`,
`Mail`,
`GroupId`,
`GroupName`,
`Identyfication`,
`Date`,
`NoteId`,
`CategoryId`,
`CategoryName`,
`TypeId`,
`TypeName`,
`LocationPoint`)
VALUES
(userIdParam,
topicParam,
contentParam,
locationIdParam,
xCordParam,
yCordParam,
zCordParam,
nameParam,
loginParam,
mailParam,
groupIdParam,
groupNameParam,
identyficationParam,
dateParam,
noteIdParam,
categoryIdParam,
categoryNameParam,
typeIdParam,
typeNameParam,
POINT(xCordParam, yCordParam));

END
