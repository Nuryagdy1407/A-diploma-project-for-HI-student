-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 29, 2021 at 06:37 AM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.4.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `diplom`
--

-- --------------------------------------------------------

--
-- Table structure for table `tb_sms`
--

CREATE TABLE `tb_sms` (
  `no` int(11) NOT NULL,
  `sms` longtext COLLATE utf8mb4_unicode_ci NOT NULL,
  `sene` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `kimden` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `tb_sms`
--

INSERT INTO `tb_sms` (`no`, `sms`, `sene`, `kimden`) VALUES
(1, 'girdi', 'Monday, October 25, 2021', 'a');

-- --------------------------------------------------------

--
-- Table structure for table `tb_ulanyjy`
--

CREATE TABLE `tb_ulanyjy` (
  `no` int(11) NOT NULL,
  `ulanyjy_hakyky` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `ulanyjy_status` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `ulanyjy_rugsat` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `ulanyjy_parol` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `ulanyjy_ad` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `ulanyjy_nomer` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `tb_ulanyjy`
--

INSERT INTO `tb_ulanyjy` (`no`, `ulanyjy_hakyky`, `ulanyjy_status`, `ulanyjy_rugsat`, `ulanyjy_parol`, `ulanyjy_ad`, `ulanyjy_nomer`) VALUES
(1, 'Myrat Myradow', 'ADMIN', '0', '000', 'admin', '+99361254334'),
(2, 'Begli Begliyew', 'ULANYJY', '1', '1', 'a', '+99361254334');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tb_sms`
--
ALTER TABLE `tb_sms`
  ADD PRIMARY KEY (`no`);

--
-- Indexes for table `tb_ulanyjy`
--
ALTER TABLE `tb_ulanyjy`
  ADD PRIMARY KEY (`no`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tb_sms`
--
ALTER TABLE `tb_sms`
  MODIFY `no` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `tb_ulanyjy`
--
ALTER TABLE `tb_ulanyjy`
  MODIFY `no` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
