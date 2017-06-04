-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: vilms
-- ------------------------------------------------------
-- Server version	5.7.18-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `m_course`
--

DROP TABLE IF EXISTS `m_course`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `m_course` (
  `CourseID` int(2) NOT NULL,
  `CourseName` varchar(50) DEFAULT NULL,
  `CourseDescription` varchar(5000) DEFAULT NULL,
  `TimeCreated` datetime DEFAULT NULL,
  `TimeUpdated` datetime DEFAULT NULL,
  PRIMARY KEY (`CourseID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `m_course`
--

LOCK TABLES `m_course` WRITE;
/*!40000 ALTER TABLE `m_course` DISABLE KEYS */;
INSERT INTO `m_course` VALUES (1,'Basic Typing','Course aims to cover basic typing with Computer Keyboard. By the end of this course you will learn the following',NULL,NULL),(2,'Advanced Typing','This course is designed to improve speed and accuracy in English Typing.',NULL,NULL);
/*!40000 ALTER TABLE `m_course` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `m_lessons`
--

DROP TABLE IF EXISTS `m_lessons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `m_lessons` (
  `CourseID` int(2) DEFAULT NULL,
  `LessonID` int(2) NOT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `TimeCreated` datetime DEFAULT NULL,
  `TimeUpdated` datetime DEFAULT NULL,
  PRIMARY KEY (`LessonID`)
) ENGINE=InnoDB DEFAULT CHARSET=sjis;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `m_lessons`
--

LOCK TABLES `m_lessons` WRITE;
/*!40000 ALTER TABLE `m_lessons` DISABLE KEYS */;
INSERT INTO `m_lessons` VALUES (1,1,'Introduction To Computer Keyboard',NULL,NULL),(1,2,'Getting started with typing practice',NULL,NULL);
/*!40000 ALTER TABLE `m_lessons` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `m_question`
--

DROP TABLE IF EXISTS `m_question`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `m_question` (
  `QuestionID` int(2) NOT NULL,
  `TopicID` int(2) DEFAULT NULL,
  `LessonID` int(2) DEFAULT NULL,
  `CourseID` int(2) DEFAULT NULL,
  `QuestionType` varchar(50) DEFAULT NULL,
  `Attempts` int(2) DEFAULT NULL,
  `QuestionTypeParameter` varchar(50) DEFAULT NULL,
  `Instruction` varchar(5000) DEFAULT NULL,
  `Question` varchar(5000) DEFAULT NULL,
  `OptionToQuestion` varchar(50) DEFAULT NULL,
  `Answer` varchar(5000) DEFAULT NULL,
  `Hint` varchar(500) DEFAULT NULL,
  `FeedBackCorrectAnswer` varchar(5000) DEFAULT NULL,
  `FeedBackWrongAnswer` varchar(5000) DEFAULT NULL,
  `CreatedTime` datetime DEFAULT NULL,
  `UpdatedTime` datetime DEFAULT NULL,
  PRIMARY KEY (`QuestionID`)
) ENGINE=InnoDB DEFAULT CHARSET=sjis;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `m_question`
--

LOCK TABLES `m_question` WRITE;
/*!40000 ALTER TABLE `m_question` DISABLE KEYS */;
INSERT INTO `m_question` VALUES (1,3,2,1,'Text',4,'Trail','In this exercise you will learn typing with home row. Home row is third row from bottom of keyboard. Now you need to find F key on home row, it has tiny bump on it and is fifth key from left of keyboard. You need to type F key with your left hand index finger (first finger after thumb) and spacebar key with your right hand thumb.','Type F and press spacebar key.','','f',NULL,'Your answer is correct. Lets move to next task.',NULL,NULL,NULL),(2,3,2,1,'Text',4,'Trail','Now type J, J is the first letter in January. Type J with your right hand index finger and press spacebar key with your right hand thumb.','Type J and press spacebar key.',NULL,'j',NULL,'Well done. Lets move to next task',NULL,NULL,NULL),(3,3,2,1,'Text',4,'Trail','Now type keys f j and press spacebar key, f is the first letter in february and j is the first letter in january. Type it four times','Type f j and press spacebar key.',NULL,'fj',NULL,'Well done. Lets move to next task',NULL,NULL,NULL),(4,3,2,1,'Text',4,'Trail','Now type f j k, f, j, k are the first letters in frog, jackal and kite. K is next to j. Type K key with your right hand middle finger.','Type f j k and press spacebar key.',NULL,'fjk',NULL,'Well done. Lets move to next task',NULL,NULL,NULL),(5,3,2,1,'Text',4,'Trail','Now type f j k l, f, j,k,l are first letter in frog, jackal, kangaroo and lion. L is next key after k toward right side. Type L with your right hand ring finger (third finger from thumb).','Type f j k l and press spacebar key.',NULL,'fjkl',NULL,'Well done. Lets move to next task',NULL,NULL,NULL),(6,3,2,1,'Text',4,'Trail','Now type j f, j, f are first letters in january and february.','Type j f and press spacebar key.',NULL,'jf',NULL,'Well done. Lets move to next task',NULL,NULL,NULL),(7,3,2,1,'Text',4,'Trail','Now type j f d, d as in first letter in dog. Type D with your left hand middle finger, D is next key towards left of F','Type j f d and press spacebar key.',NULL,'jfd',NULL,'Well done. Lets move to next task',NULL,NULL,NULL),(8,3,2,1,'Text',4,'Trail','Now type j f d s, s as in first letter in summer. Type S with your left hand ring finger (third finger from thumb). S is next to D key towards left.','Type j f d s and press spacebar key.',NULL,'jfds',NULL,'Well done. Lets move to next task',NULL,NULL,NULL),(9,3,2,1,'Text',4,'Trail','Now type j f d s a, a is towards left of s key.','Type j f d s a and press spacebar key.',NULL,'jfdsa',NULL,'Well done. Lets move to next task',NULL,NULL,NULL),(10,3,2,1,'Text',4,'Trail','No Instruction','Type j f a and press spacebar key.',NULL,'jfa',NULL,'Well done. Lets move to next task',NULL,NULL,NULL),(11,3,2,1,'Text',4,'Trail','No Instruction','Type j f a s and press spacebar key.',NULL,'jfas',NULL,'Well done. Lets move to next task',NULL,NULL,NULL),(12,3,2,1,'Text',4,'Trail','No Instruction','Type j f a s d f and press spacebar key.',NULL,'jfasd',NULL,'Well done. Lets move to next task',NULL,NULL,NULL),(13,3,2,1,'Text',4,'Trail','No Instruction','Type j f a s d f j and press spacebar key.',NULL,'jfasdf',NULL,'Well done. Lets move to next task',NULL,NULL,NULL),(14,3,2,1,'Text',4,'Trail','No Instruction','Type j k l f and press spacebar key.',NULL,'jklf',NULL,'Well done. Lets move to next task',NULL,NULL,NULL),(15,3,2,1,'Text',4,'Trail','No Instruction','Type j k l f d s a and press spacebar key.',NULL,'jklfdsa',NULL,'Well done. Lets move to next task',NULL,NULL,NULL),(16,3,2,1,'Text',4,'Trail','Here is the last task of exercise.','Type j k l a s d f and press spacebar key.',NULL,'jklasdf',NULL,'Well done. Lets move to next task',NULL,NULL,NULL);
/*!40000 ALTER TABLE `m_question` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `m_topic`
--

DROP TABLE IF EXISTS `m_topic`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `m_topic` (
  `TopicID` int(2) NOT NULL,
  `LessonID` int(2) DEFAULT NULL,
  `CourseID` int(2) DEFAULT NULL,
  `Name` varchar(500) DEFAULT NULL,
  `Content` varchar(5000) DEFAULT NULL,
  PRIMARY KEY (`TopicID`)
) ENGINE=InnoDB DEFAULT CHARSET=sjis COMMENT='	';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `m_topic`
--

LOCK TABLES `m_topic` WRITE;
/*!40000 ALTER TABLE `m_topic` DISABLE KEYS */;
INSERT INTO `m_topic` VALUES (1,1,1,'Introduction To Computer Keyboard','Keyboard is an input device for Computer. It is rectangular in shape and consist of various keys which can be pressed to enter data.'),(2,1,1,'Keyboard Layout','Understanding keyboard layout'),(3,2,1,'Keyboard Home Row, locating reference keys F and J','Keyboard home row is located at center of keyboard, third row from bottom of keyboard. In this topic we will learn locating reference keys F and J and typing practice with home row.');
/*!40000 ALTER TABLE `m_topic` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `m_user`
--

DROP TABLE IF EXISTS `m_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `m_user` (
  `ID` int(2) NOT NULL,
  `User_name` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `Status` int(2) DEFAULT NULL,
  PRIMARY KEY (`User_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `m_user`
--

LOCK TABLES `m_user` WRITE;
/*!40000 ALTER TABLE `m_user` DISABLE KEYS */;
INSERT INTO `m_user` VALUES (2,'TrailUser','TrailUser',1),(1,'Username','P@ssword',1);
/*!40000 ALTER TABLE `m_user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-06-03 11:06:22
