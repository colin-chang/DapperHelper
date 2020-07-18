SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for article
-- ----------------------------
DROP TABLE IF EXISTS `article`;
CREATE TABLE `article` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Title` varchar(255) NOT NULL,
  `Content` text NOT NULL,
  `Status` int NOT NULL DEFAULT '1',
  `UpdateTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `AuthorId` int NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for author
-- ----------------------------
DROP TABLE IF EXISTS `author`;
CREATE TABLE `author` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NickName` varchar(255) NOT NULL,
  `RealName` varchar(255) NOT NULL,
  `BirthDate` date DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for comment
-- ----------------------------
DROP TABLE IF EXISTS `comment`;
CREATE TABLE `comment` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ArticleId` int NOT NULL,
  `Content` varchar(255) NOT NULL,
  `CreateTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

SET FOREIGN_KEY_CHECKS = 1;
