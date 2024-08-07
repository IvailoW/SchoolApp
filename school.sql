-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 11, 2024 at 09:59 AM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `school`
--
CREATE DATABASE IF NOT EXISTS `school` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `school`;

-- --------------------------------------------------------

--
-- Table structure for table `classes`
--

CREATE TABLE `classes` (
  `ClassID` int(11) NOT NULL,
  `ClassName` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `classes`
--

INSERT INTO `classes` (`ClassID`, `ClassName`) VALUES
(1, '1А'),
(2, '2А'),
(3, '3А'),
(4, '4А'),
(5, '5А'),
(6, '6А'),
(7, '7А');

-- --------------------------------------------------------

--
-- Table structure for table `courses`
--

CREATE TABLE `courses` (
  `CourseID` int(11) NOT NULL,
  `CourseName` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `courses`
--

INSERT INTO `courses` (`CourseID`, `CourseName`) VALUES
(1, 'Математика'),
(2, 'История'),
(3, 'Физика'),
(4, 'Химия'),
(5, 'Биология'),
(6, 'География'),
(7, 'Английски Език'),
(8, 'Физическо Възпитание и Спорт'),
(9, 'Български Език и Лтература'),
(10, 'Информационни Технологии');

-- --------------------------------------------------------

--
-- Table structure for table `studentcourses`
--

CREATE TABLE `studentcourses` (
  `StudentID` int(11) NOT NULL,
  `CourseID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `studentcourses`
--

INSERT INTO `studentcourses` (`StudentID`, `CourseID`) VALUES
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(1, 5),
(1, 6),
(1, 7),
(1, 8),
(1, 9),
(1, 10),
(2, 1),
(2, 2),
(2, 3),
(2, 4),
(2, 5),
(2, 6),
(2, 7),
(2, 8),
(2, 9),
(2, 10),
(3, 1),
(3, 2),
(3, 3),
(3, 4),
(3, 5),
(3, 6),
(3, 7),
(3, 8),
(3, 9),
(3, 10),
(4, 1),
(4, 2),
(4, 3),
(4, 4),
(4, 5),
(4, 6),
(4, 7),
(4, 8),
(4, 9),
(4, 10),
(5, 1),
(5, 2),
(5, 3),
(5, 4),
(5, 5),
(5, 6),
(5, 7),
(5, 8),
(5, 9),
(5, 10),
(6, 1),
(6, 2),
(6, 3),
(6, 4),
(6, 5),
(6, 6),
(6, 7),
(6, 8),
(6, 9),
(6, 10),
(7, 1),
(7, 2),
(7, 3),
(7, 4),
(7, 5),
(7, 6),
(7, 7),
(7, 8),
(7, 9),
(7, 10),
(8, 1),
(8, 2),
(8, 3),
(8, 4),
(8, 5),
(8, 6),
(8, 7),
(8, 8),
(8, 9),
(8, 10),
(9, 1),
(9, 2),
(9, 3),
(9, 4),
(9, 5),
(9, 6),
(9, 7),
(9, 8),
(9, 9),
(9, 10),
(10, 1),
(10, 2),
(10, 3),
(10, 4),
(10, 5),
(10, 6),
(10, 7),
(10, 8),
(10, 9),
(10, 10);

-- --------------------------------------------------------

--
-- Table structure for table `students`
--

CREATE TABLE `students` (
  `StudentID` int(11) NOT NULL,
  `FirstName` varchar(50) DEFAULT NULL,
  `LastName` varchar(50) DEFAULT NULL,
  `ClassID` int(11) DEFAULT NULL,
  `DateOfBirth` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `students`
--

INSERT INTO `students` (`StudentID`, `FirstName`, `LastName`, `ClassID`, `DateOfBirth`) VALUES
(1, 'Иван', 'Иванов', 1, '2016-01-15'),
(2, 'Петър', 'Петров', 1, '2016-02-20'),
(3, 'Георги', 'Георгиев', 1, '2016-03-25'),
(4, 'Димитър', 'Димитров', 1, '2016-04-30'),
(5, 'Николай', 'Николаев', 1, '2016-05-05'),
(6, 'Стоян', 'Стоянов', 1, '2016-06-10'),
(7, 'Мартин', 'Мартинов', 1, '2016-07-15'),
(8, 'Калоян', 'Калоянов', 1, '2016-08-20'),
(9, 'Васил', 'Василев', 1, '2016-09-25'),
(10, 'Теодор', 'Теодоров', 1, '2016-10-30'),
(11, 'Кирил', 'Кирилов', 1, '2016-11-05'),
(12, 'Любомир', 'Любомиров', 1, '2016-12-10'),
(13, 'Деян', 'Деянов', 1, '2016-01-15'),
(14, 'Стефан', 'Стефанов', 1, '2016-02-20'),
(15, 'Милена', 'Миленова', 1, '2016-03-25'),
(16, 'Румен', 'Руменов', 1, '2016-04-30'),
(17, 'Светослав', 'Светославов', 1, '2016-05-05'),
(18, 'Борис', 'Борисов', 1, '2016-06-10'),
(19, 'Атанас', 'Атанасов', 1, '2016-07-15'),
(20, 'Христо', 'Христов', 1, '2016-08-20'),
(21, 'Симеон', 'Симеонов', 1, '2016-09-25'),
(22, 'Ангел', 'Ангелов', 1, '2016-10-30'),
(23, 'Радостин', 'Радостинов', 1, '2016-11-05'),
(24, 'Владимир', 'Владимиров', 1, '2016-12-10'),
(25, 'Ваня', 'Ванева', 2, '2015-01-15'),
(26, 'Борислав', 'Бориславов', 2, '2015-02-20'),
(27, 'Валентин', 'Валентинов', 2, '2015-03-25'),
(28, 'Георги', 'Георгиев', 2, '2015-04-30'),
(29, 'Добромир', 'Добромиров', 2, '2015-05-05'),
(30, 'Емил', 'Емилов', 2, '2015-06-10'),
(31, 'Захари', 'Захариев', 2, '2015-07-15'),
(32, 'Христо', 'Христов', 2, '2015-08-20'),
(33, 'Иво', 'Иванов', 2, '2015-09-25'),
(34, 'Калоян', 'Калоянов', 2, '2015-10-30'),
(35, 'Лидия', 'Лидиева', 2, '2015-11-05'),
(36, 'Марин', 'Маринов', 2, '2015-12-10'),
(37, 'Николина', 'Николова', 2, '2015-01-15'),
(38, 'Огнян', 'Огнянов', 2, '2015-02-20'),
(39, 'Павлина', 'Павлова', 2, '2015-03-25'),
(40, 'Райна', 'Райнова', 2, '2015-04-30'),
(41, 'Симеон', 'Симеонов', 2, '2015-05-05'),
(42, 'Цветан', 'Цветков', 2, '2015-06-10'),
(43, 'Филип', 'Филипов', 2, '2015-07-15'),
(44, 'Хараламби', 'Хараламбиев', 2, '2015-08-20'),
(45, 'Цветанка', 'Цветкова', 2, '2015-09-25'),
(46, 'Уляна', 'Улянова', 2, '2015-10-30'),
(47, 'Фросина', 'Фросинова', 2, '2015-11-05'),
(48, 'Ян', 'Янов', 2, '2015-12-10'),
(49, 'Алек', 'Алексиев', 3, '2014-01-15'),
(50, 'Благовест', 'Благовестов', 3, '2014-02-20'),
(51, 'Виктор', 'Викторов', 3, '2014-03-25'),
(52, 'Гергана', 'Герганова', 3, '2014-04-30'),
(53, 'Диана', 'Диянова', 3, '2014-05-05'),
(54, 'Емилия', 'Емилиянова', 3, '2014-06-10'),
(55, 'Зорница', 'Зорницова', 3, '2014-07-15'),
(56, 'Християн', 'Християнов', 3, '2014-08-20'),
(57, 'Ивана', 'Иванова', 3, '2014-09-25'),
(58, 'Калина', 'Калинова', 3, '2014-10-30'),
(59, 'Любослава', 'Любославова', 3, '2014-11-05'),
(60, 'Марияна', 'Мариянова', 3, '2014-12-10'),
(61, 'Никола', 'Николов', 3, '2014-01-15'),
(62, 'Огнян', 'Огнянов', 3, '2014-02-20'),
(63, 'Петър', 'Петров', 3, '2014-03-25'),
(64, 'Радослав', 'Радославов', 3, '2014-04-30'),
(65, 'Станислав', 'Станиславов', 3, '2014-05-05'),
(66, 'Тодор', 'Тодоров', 3, '2014-06-10'),
(67, 'Филип', 'Филипов', 3, '2014-07-15'),
(68, 'Хараламби', 'Хараламбиев', 3, '2014-08-20'),
(69, 'Цветан', 'Цветков', 3, '2014-09-25'),
(70, 'Уляна', 'Улянова', 3, '2014-10-30'),
(71, 'Фросина', 'Фросинова', 3, '2014-11-05'),
(72, 'Ян', 'Янов', 3, '2014-12-10'),
(73, 'Анастасия', 'Анастасова', 4, '2013-01-15'),
(74, 'Богдан', 'Богданов', 4, '2013-02-20'),
(75, 'Валерия', 'Валерова', 4, '2013-03-25'),
(76, 'Георги', 'Георгиев', 4, '2013-04-30'),
(77, 'Димо', 'Димов', 4, '2013-05-05'),
(78, 'Емил', 'Емилов', 4, '2013-06-10'),
(79, 'Захари', 'Захариев', 4, '2013-07-15'),
(80, 'Христо', 'Христов', 4, '2013-08-20'),
(81, 'Ива', 'Иванова', 4, '2013-09-25'),
(82, 'Калоян', 'Калоянов', 4, '2013-10-30'),
(83, 'Лидия', 'Лидиева', 4, '2013-11-05'),
(84, 'Марин', 'Маринов', 4, '2013-12-10'),
(85, 'Николина', 'Николова', 4, '2013-01-15'),
(86, 'Огнян', 'Огнянов', 4, '2013-02-20'),
(87, 'Павлина', 'Павлова', 4, '2013-03-25'),
(88, 'Райна', 'Райнова', 4, '2013-04-30'),
(89, 'Симеон', 'Симеонов', 4, '2013-05-05'),
(90, 'Цветан', 'Цветков', 4, '2013-06-10'),
(91, 'Филип', 'Филипов', 4, '2013-07-15'),
(92, 'Хараламби', 'Хараламбиев', 4, '2013-08-20'),
(93, 'Цветанка', 'Цветкова', 4, '2013-09-25'),
(94, 'Уляна', 'Улянова', 4, '2013-10-30'),
(95, 'Фросина', 'Фросинова', 4, '2013-11-05'),
(96, 'Ян', 'Янов', 4, '2013-12-10'),
(97, 'Антония', 'Антонова', 5, '2012-01-15'),
(98, 'Борис', 'Бориславов', 5, '2012-02-20'),
(99, 'Валентин', 'Валентинов', 5, '2012-03-25'),
(100, 'Георги', 'Георгиев', 5, '2012-04-30'),
(101, 'Добромир', 'Добромиров', 5, '2012-05-05'),
(102, 'Емил', 'Емилов', 5, '2012-06-10'),
(103, 'Захари', 'Захариев', 5, '2012-07-15'),
(104, 'Христо', 'Христов', 5, '2012-08-20'),
(105, 'Иво', 'Иванов', 5, '2012-09-25'),
(106, 'Калоян', 'Калоянов', 5, '2012-10-30'),
(107, 'Лидия', 'Лидиева', 5, '2012-11-05'),
(108, 'Марин', 'Маринов', 5, '2012-12-10'),
(109, 'Николина', 'Николова', 5, '2012-01-15'),
(110, 'Огнян', 'Огнянов', 5, '2012-02-20'),
(111, 'Павлина', 'Павлова', 5, '2012-03-25'),
(112, 'Райна', 'Райнова', 5, '2012-04-30'),
(113, 'Симеон', 'Симеонов', 5, '2012-05-05'),
(114, 'Цветан', 'Цветков', 5, '2012-06-10'),
(115, 'Филип', 'Филипов', 5, '2012-07-15'),
(116, 'Хараламби', 'Хараламбиев', 5, '2012-08-20'),
(117, 'Цветанка', 'Цветкова', 5, '2012-09-25'),
(118, 'Уляна', 'Улянова', 5, '2012-10-30'),
(119, 'Фросина', 'Фросинова', 5, '2012-11-05'),
(120, 'Ян', 'Янов', 5, '2012-12-10'),
(121, 'Богдана', 'Богданова', 6, '2011-01-15'),
(122, 'Борислав', 'Бориславов', 6, '2011-02-20'),
(123, 'Валентина', 'Валентинова', 6, '2011-03-25'),
(124, 'Георги', 'Георгиев', 6, '2011-04-30'),
(125, 'Димо', 'Димов', 6, '2011-05-05'),
(126, 'Емил', 'Емилов', 6, '2011-06-10'),
(127, 'Захари', 'Захариев', 6, '2011-07-15'),
(128, 'Христо', 'Христов', 6, '2011-08-20'),
(129, 'Ива', 'Иванова', 6, '2011-09-25'),
(130, 'Калоян', 'Калоянов', 6, '2011-10-30'),
(131, 'Лидия', 'Лидиева', 6, '2011-11-05'),
(132, 'Марин', 'Маринов', 6, '2011-12-10'),
(133, 'Николина', 'Николова', 6, '2011-01-15'),
(134, 'Огнян', 'Огнянов', 6, '2011-02-20'),
(135, 'Павлина', 'Павлова', 6, '2011-03-25'),
(136, 'Райна', 'Райнова', 6, '2011-04-30'),
(137, 'Симеон', 'Симеонов', 6, '2011-05-05'),
(138, 'Цветан', 'Цветков', 6, '2011-06-10'),
(139, 'Филип', 'Филипов', 6, '2011-07-15'),
(140, 'Хараламби', 'Хараламбиев', 6, '2011-08-20'),
(141, 'Цветанка', 'Цветкова', 6, '2011-09-25'),
(142, 'Уляна', 'Улянова', 6, '2011-10-30'),
(143, 'Фросина', 'Фросинова', 6, '2011-11-05'),
(144, 'Ян', 'Янов', 6, '2011-12-10'),
(145, 'Боряна', 'Бориславова', 7, '2010-01-15'),
(146, 'Валентин', 'Валентинов', 7, '2010-02-20'),
(147, 'Георги', 'Георгиев', 7, '2010-03-25'),
(148, 'Димо', 'Димов', 7, '2010-04-30'),
(149, 'Емил', 'Емилов', 7, '2010-05-05'),
(150, 'Захари', 'Захариев', 7, '2010-06-10'),
(151, 'Христо', 'Христов', 7, '2010-07-15'),
(152, 'Иво', 'Иванов', 7, '2010-08-20'),
(153, 'Калоян', 'Калоянов', 7, '2010-09-25'),
(154, 'Лидия', 'Лидиева', 7, '2010-10-30'),
(155, 'Марин', 'Маринов', 7, '2010-11-05'),
(156, 'Николина', 'Николова', 7, '2010-12-10'),
(157, 'Огнян', 'Огнянов', 7, '2010-01-15'),
(158, 'Павлина', 'Павлова', 7, '2010-02-20'),
(159, 'Райна', 'Райнова', 7, '2010-03-25'),
(160, 'Симеон', 'Симеонов', 7, '2010-04-30'),
(161, 'Цветан', 'Цветков', 7, '2010-05-05'),
(162, 'Филип', 'Филипов', 7, '2010-06-10'),
(163, 'Хараламби', 'Хараламбиев', 7, '2010-07-15'),
(164, 'Цветанка', 'Цветкова', 7, '2010-08-20'),
(165, 'Уляна', 'Улянова', 7, '2010-09-25'),
(166, 'Фросина', 'Фросинова', 7, '2010-10-30'),
(167, 'Ян', 'Янов', 7, '2010-11-05'),
(168, 'Лъчезар', 'Лъчезаров', 7, '2010-12-10');

-- --------------------------------------------------------

--
-- Table structure for table `teachercourses`
--

CREATE TABLE `teachercourses` (
  `TeacherID` int(11) NOT NULL,
  `CourseID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `teachercourses`
--

INSERT INTO `teachercourses` (`TeacherID`, `CourseID`) VALUES
(1, 1),
(1, 3),
(2, 2),
(2, 4),
(3, 3),
(3, 5),
(4, 4),
(4, 6),
(5, 5),
(5, 7),
(6, 6),
(6, 8),
(7, 7),
(7, 9),
(8, 8),
(8, 10),
(9, 1),
(9, 9),
(10, 2),
(10, 10),
(11, 1),
(11, 3),
(12, 2),
(12, 4),
(13, 3),
(13, 5),
(14, 4),
(14, 6),
(15, 5),
(15, 7),
(16, 6),
(16, 8),
(17, 7),
(17, 9),
(18, 8),
(18, 10),
(19, 1),
(19, 9);

-- --------------------------------------------------------

--
-- Table structure for table `teachers`
--

CREATE TABLE `teachers` (
  `TeacherID` int(11) NOT NULL,
  `FirstName` varchar(50) DEFAULT NULL,
  `LastName` varchar(50) DEFAULT NULL,
  `Subject` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `teachers`
--

INSERT INTO `teachers` (`TeacherID`, `FirstName`, `LastName`, `Subject`) VALUES
(1, 'Петър', 'Петров', 'Математика'),
(2, 'Елена', 'Иванова', 'История'),
(3, 'Димитър', 'Димитров', 'Физика'),
(4, 'Maria', 'Marinova', 'Химия'),
(5, 'Георги', 'Георгиев', 'Биология'),
(6, 'Иванка', 'Иванова', 'География'),
(7, 'Тодор', 'Тодоров', 'Английски Език'),
(8, 'Светлана', 'Светославова', 'Физическо Възпитание и Спорт'),
(9, 'Румен', 'Руменов', 'Български Език и Лтература'),
(10, 'Пламен', 'Петров', 'Информационни Технологии'),
(11, 'Галина', 'Ганчева', 'Физическо Възпитание и Спорт'),
(12, 'Петко', 'Петков', 'Английски Език'),
(13, 'Християна', 'Христова', 'Биология'),
(14, 'Милена', 'Миленова', 'Български Език и Лтература'),
(15, 'Андрей', 'Андреев', 'Математика'),
(16, 'Цветан', 'Цветанов', 'Физика'),
(17, 'Яана', 'Яанкова', 'Химия'),
(18, 'Борислав', 'Борисов', 'История'),
(19, 'Стефан', 'Стефанов', 'Биология');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `classes`
--
ALTER TABLE `classes`
  ADD PRIMARY KEY (`ClassID`);

--
-- Indexes for table `courses`
--
ALTER TABLE `courses`
  ADD PRIMARY KEY (`CourseID`);

--
-- Indexes for table `studentcourses`
--
ALTER TABLE `studentcourses`
  ADD PRIMARY KEY (`StudentID`,`CourseID`),
  ADD KEY `CourseID` (`CourseID`);

--
-- Indexes for table `students`
--
ALTER TABLE `students`
  ADD PRIMARY KEY (`StudentID`);

--
-- Indexes for table `teachercourses`
--
ALTER TABLE `teachercourses`
  ADD PRIMARY KEY (`TeacherID`,`CourseID`),
  ADD KEY `CourseID` (`CourseID`);

--
-- Indexes for table `teachers`
--
ALTER TABLE `teachers`
  ADD PRIMARY KEY (`TeacherID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `classes`
--
ALTER TABLE `classes`
  MODIFY `ClassID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `courses`
--
ALTER TABLE `courses`
  MODIFY `CourseID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `students`
--
ALTER TABLE `students`
  MODIFY `StudentID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=170;

--
-- AUTO_INCREMENT for table `teachers`
--
ALTER TABLE `teachers`
  MODIFY `TeacherID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `studentcourses`
--
ALTER TABLE `studentcourses`
  ADD CONSTRAINT `studentcourses_ibfk_1` FOREIGN KEY (`StudentID`) REFERENCES `students` (`StudentID`),
  ADD CONSTRAINT `studentcourses_ibfk_2` FOREIGN KEY (`CourseID`) REFERENCES `courses` (`CourseID`);

--
-- Constraints for table `teachercourses`
--
ALTER TABLE `teachercourses`
  ADD CONSTRAINT `teachercourses_ibfk_1` FOREIGN KEY (`TeacherID`) REFERENCES `teachers` (`TeacherID`) ON DELETE CASCADE,
  ADD CONSTRAINT `teachercourses_ibfk_2` FOREIGN KEY (`CourseID`) REFERENCES `courses` (`CourseID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
