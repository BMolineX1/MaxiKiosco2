-- MySQL dump 10.13  Distrib 8.0.43, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: maxikiosco
-- ------------------------------------------------------
-- Server version	8.0.43

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `categoria`
--

DROP TABLE IF EXISTS `categoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categoria` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre_categoria` varchar(100) NOT NULL,
  `estado` tinyint NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  UNIQUE KEY `nombre_categoria` (`nombre_categoria`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoria`
--

LOCK TABLES `categoria` WRITE;
/*!40000 ALTER TABLE `categoria` DISABLE KEYS */;
INSERT INTO `categoria` VALUES (2,'Bebidas',1),(3,'Panificados',1),(9,'Fiambreria',1),(10,'Galletitas',1),(11,'Golosina',1);
/*!40000 ALTER TABLE `categoria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cierres_caja`
--

DROP TABLE IF EXISTS `cierres_caja`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cierres_caja` (
  `id` int NOT NULL AUTO_INCREMENT,
  `fecha` date DEFAULT NULL,
  `empleado_id` int DEFAULT NULL,
  `total_ventas` decimal(10,2) DEFAULT NULL,
  `diferencia` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `empleado_id` (`empleado_id`),
  CONSTRAINT `cierres_caja_ibfk_1` FOREIGN KEY (`empleado_id`) REFERENCES `usuario` (`idusuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cierres_caja`
--

LOCK TABLES `cierres_caja` WRITE;
/*!40000 ALTER TABLE `cierres_caja` DISABLE KEYS */;
/*!40000 ALTER TABLE `cierres_caja` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cliente` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `apellido` varchar(100) NOT NULL,
  `dni` varchar(20) NOT NULL,
  `cuit` varchar(15) DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `domicilio` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `estado` tinyint DEFAULT '1',
  PRIMARY KEY (`id`),
  UNIQUE KEY `dni` (`dni`),
  UNIQUE KEY `email_UNIQUE` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` VALUES (1,'Federico','Molina','38962453',NULL,'3644657148','mz 7 pc 12 Barrio Pro.Mu.Vi','fede.099molina@gmail.com',1),(4,'gabi','Vera','2333333333',NULL,'33333333','mz 7 pc 23','fede@gmail.com',0),(5,'Elias','Ramirez','42746919',NULL,'3644222298','Barrio anbtocñ','elias@gmail.com',1);
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `compra`
--

DROP TABLE IF EXISTS `compra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `compra` (
  `id_compra` int NOT NULL AUTO_INCREMENT,
  `fecharegistro` datetime NOT NULL,
  `montototal` decimal(10,2) DEFAULT NULL,
  `empleado_id` int DEFAULT NULL,
  `proveedor_id` int DEFAULT NULL,
  `tipodocumento` varchar(45) DEFAULT NULL,
  `numerodocumento` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_compra`),
  KEY `empleado_id` (`empleado_id`),
  KEY `proveedor_id` (`proveedor_id`),
  CONSTRAINT `compra_ibfk_1` FOREIGN KEY (`empleado_id`) REFERENCES `usuario` (`idusuario`),
  CONSTRAINT `compra_ibfk_2` FOREIGN KEY (`proveedor_id`) REFERENCES `proveedor` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `compra`
--

LOCK TABLES `compra` WRITE;
/*!40000 ALTER TABLE `compra` DISABLE KEYS */;
INSERT INTO `compra` VALUES (3,'2025-09-30 22:57:38',4500000.00,1,3,'Boleta','0001-00000001'),(4,'2025-09-30 23:25:14',30000.00,1,3,'Boleta','0001-00000002'),(5,'2025-10-07 14:30:48',38600.00,1,3,'Boleta','0001-00000003');
/*!40000 ALTER TABLE `compra` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalle_compra`
--

DROP TABLE IF EXISTS `detalle_compra`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `detalle_compra` (
  `id` int NOT NULL AUTO_INCREMENT,
  `compra_id` int DEFAULT NULL,
  `producto_id` int DEFAULT NULL,
  `cantidad` int NOT NULL,
  `montototal` decimal(10,2) NOT NULL,
  `preciocompra` decimal(10,2) NOT NULL,
  `precioventa` decimal(10,2) NOT NULL,
  `fecharegistro` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `compra_id` (`compra_id`),
  KEY `producto_id` (`producto_id`),
  CONSTRAINT `detalle_compra_ibfk_1` FOREIGN KEY (`compra_id`) REFERENCES `compra` (`id_compra`),
  CONSTRAINT `detalle_compra_ibfk_2` FOREIGN KEY (`producto_id`) REFERENCES `producto` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalle_compra`
--

LOCK TABLES `detalle_compra` WRITE;
/*!40000 ALTER TABLE `detalle_compra` DISABLE KEYS */;
INSERT INTO `detalle_compra` VALUES (1,3,3,30,4500000.00,150000.00,0.00,'2025-09-30 22:57:38'),(2,4,8,20,30000.00,1500.00,2000.00,'2025-09-30 23:25:14'),(3,5,8,20,32000.00,1600.00,1400.00,'2025-10-07 14:30:48'),(4,5,4,6,6600.00,1100.00,1000.00,'2025-10-07 14:30:48');
/*!40000 ALTER TABLE `detalle_compra` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalle_venta`
--

DROP TABLE IF EXISTS `detalle_venta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `detalle_venta` (
  `id` int NOT NULL AUTO_INCREMENT,
  `venta_id` int DEFAULT NULL,
  `producto_id` int DEFAULT NULL,
  `cantidad` int DEFAULT NULL,
  `precio_unitario` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `venta_id` (`venta_id`),
  KEY `producto_id` (`producto_id`),
  CONSTRAINT `detalle_venta_ibfk_1` FOREIGN KEY (`venta_id`) REFERENCES `venta` (`id`),
  CONSTRAINT `detalle_venta_ibfk_2` FOREIGN KEY (`producto_id`) REFERENCES `producto` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalle_venta`
--

LOCK TABLES `detalle_venta` WRITE;
/*!40000 ALTER TABLE `detalle_venta` DISABLE KEYS */;
INSERT INTO `detalle_venta` VALUES (1,1,8,10,2000.00);
/*!40000 ALTER TABLE `detalle_venta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `factura`
--

DROP TABLE IF EXISTS `factura`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `factura` (
  `id` int NOT NULL AUTO_INCREMENT,
  `venta_id` int DEFAULT NULL,
  `fecha` datetime NOT NULL,
  `tipo_factura` enum('A','B','C') NOT NULL DEFAULT 'B',
  PRIMARY KEY (`id`),
  KEY `venta_id` (`venta_id`),
  CONSTRAINT `factura_ibfk_1` FOREIGN KEY (`venta_id`) REFERENCES `venta` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factura`
--

LOCK TABLES `factura` WRITE;
/*!40000 ALTER TABLE `factura` DISABLE KEYS */;
/*!40000 ALTER TABLE `factura` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `negocio`
--

DROP TABLE IF EXISTS `negocio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `negocio` (
  `idnegocio` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(60) NOT NULL,
  `ruc` varchar(60) NOT NULL,
  `direccion` varchar(80) NOT NULL,
  `logo` mediumblob,
  PRIMARY KEY (`idnegocio`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `negocio`
--

LOCK TABLES `negocio` WRITE;
/*!40000 ALTER TABLE `negocio` DISABLE KEYS */;
INSERT INTO `negocio` VALUES (1,'MaxiKiosco Molina','101010','av. codigo 123',_binary '�PNG\r\n\Z\n\0\0\0\rIHDR\0\0�\0\0W\0\0\0\�MO�\0\0\0sRGB\0�\�\�\0\0\0gAMA\0\0���a\0\0\0	pHYs\0\0\�\0\0\�\�o�d\0\0��IDATx^\��|Tg�7��\�G����c \�j����&�5j\�\�\�.���C\�*%\�\�F6�\�[\�ۏ?J�\�j\�~[�)\�J1)b\�\�]�?ֲ�����qԎ��+��82XD\�L��\�kr\�}��&�I2����\��Q��w�\�M�9\\sΙ\�x-Z4���*\r\r\�\�`tt�TJv\0�^/\�\�\�q\�\����\�n\0�\�\�GYYΟ?/���=֢\�Z�X�k\�c-z�E��\�ͧZΜ9�\�eUYmެ?�\'j\�dVVVbxxX6g���!�NkW�\0\��x\����J�0>��^�>�����+k\�c-z�E��\�=֢\�Z�X�\�|�%�H�\�dz*++ݙ\0�,Y�S�N\�\�Y�Z�X�k\�c-z�E��\�=֢7�jv/2yO�������\'֢\�Z�X�k\�+�ZxO&\�.2�����\�\�$\"\"\"��\�\"�����\n��L\"\"\"\"*8.2�����\�\�$\"\"\"���\�\�\�j�\�\\�p!Ξ=+�3�~?\�\�v\�w\�;\�{�^���s|>_\�=�֢\�Z�J������9\�tZveY�`�q5�ϗ�\�<�\�kq+�Ze��k�\��k\�\�Zr\�\�Z\��\�288\�\�\'���\�XkQ���ݻwˮ)S�b�Z�\�b-�?�8v\�\�!���}\�Z��\�\�t��\�6c\�\"\�\�ZX�R��\�޽;v\��\�?.S�fM[[\0p�\��Z�X�^)բ[d�L\"\"\"\"*8.2�����\�\�$\"\"\"��\�\"��fQ\�d\�\��\"\Z��&D�I$�\�)�\\\��32\�=!�JDD��E&͞�\�H!&\�3B辥CO\�v�p=j;\�0�Ef��\0�\0���H��%`��zc�L%\"�I�TVVj�]�d\��:uJ6\�\n֢\�Z�J��={�\��{\�)�o���H\��#����8�\�\0V��1$�\�@eZk �\�@b=qt�\rZ?;؉��v���m��\�F4֞�\0���\�}\�\�\�\�\'\�\�T����1\0 ч�\�f���Uǖ\�\�2r8i\�`���׮{}Kݵ��]s7\�W�����6��~\�w\�}���\n�>*֢\�Z�\�S-\�\�\�\�o����B\�t\�\�\�\0�\�I�R�vj3`\�.c2�L&�����\�\�j\�m|[\n\"�5���\0j*��]l�\�&b\�:ĺ\�Y\����\�<`�mЉV\�r�uUQ\�@ �t��\0�7\�\�\�0�\�>C\�1��\�z7VO�1\��X`�:F��ZB=q�n��[0�r;���Њ\n��Ϊ�#�\�\�.\��t\"�ú��v\�R466\�z\�:_�\��>b-\�`-�`-�0բ\�M�R\�\�����\��.�]�\�C)�N��d�l��Z��Z�Q���\�\"3�\�K���\�kg���B�\�q�^W=�^�\�}K\rPۚ�WR�]��@\�P�}i<��\��\�\0Ћ\��\�e\�_��&k�\�\�$\��\�%�\�Z\�\\\�e\�مƠ��ne��֬����#8�\�<w)\���-\��k\�\�\�\�K�W��|�\��L\"�%5�\n�\��~uo\�\0ڗ�C+*��!R_c�U�AU0�N����p\�V}��H\�=���8�ۀ-���\��~�	MM�fZQ�\��V-\�B6�\�\'��Bp�1\�\�DD��D4;�\�\�:��%\�3��@gcJԠ^-\n\�Q$\�\�9�p���K\�M\�X_k��{���4ԏv\0\�#�:�k��B=q$G�s�ΜN\\�\�57\�|\�E&\�\n\�\�2\�l`\�:\�A�\��qW��yk*6ۗ�o��\\��\�tu\0ڻ�۪0�\0��\�k�\Z՞��\�^Dʟ\�\�\�1�F��wW\�\�JΜ��\'.�k\�&\"�g�\�rka-J1\�\�g�S1\�\�\�X�k\�+�Z�\�r\"\"\"\"�^�\�]x<W�3\0s\�$\�\�ׯ\�4�\Zǔ\�$�d�l�a�G�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8��b�\��\�$�d�l��k\�8�\'\�\'sd�\�<jS��\�9�]�i5�)\�I�\�\�.\�4�\Zǔ\�$�d�l�a�G�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�\�Wrn\�^QQ���\�<+X�k\�+\�ZJv3v�\�fj3�B��\n��\���T�n3v\�\�ŋ��\�e˖\�ĉ�9����T\ni{Pu\�>�׋��2cXKN�E�k\�=�T�\�\�\�\��x�s\�N\�\��\�4k\�c-z�\�\��\�ӮE�wll�w�9�Ѳ\�ٯ\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8�\'\�\'sd�\�<jS��\�9�]�i5�)\�I�\�\�.\�4�\ZǔCT\�r�~�d�̑\�2r\�\�ǔ\�$�d�l�a�G�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8�\'\�\'sd�\�<jS��\����\":\�%\�F6\�\�Z�b�\�\��:����2�hV,_�UUU�\��\�-�X�k\�+�Zt[q�ic-�E)\�Z�\�(�q<��\�2�hVTWWchh��L��\��R���L֒��̝Z�\�*F܌ݍ�\��R�E�\�\�=�DDDDTp�+��\"\�\�l�y\�W\�ܹs�v>�ȳq�\�ޜS�\�ȗ\�Z��Z�Q��\�|�\�8r\����AT,V�^\r�׋����׬\n\�y�L&�P\�|�L&��胵\�c>\�r\�\�9\\y\�Upʹ��%Kp\�\�)\�<+X�k\�+\�Z�;��ڌ�P\�B`-z�Eo>բ݌��dZXkQ��ޓIň�d��=֢WJ��L\"\"\"\"�\\dQ�q�IT�B\�\'�L&q�dѰ\�\�#y8\"[\��?�k\�Q$�ּ\������J�D��i\�1tX�4�\�\�pR\"�&�\��\�B��@\0�@\0��@\�P��\��\�\\\"\"*Y\\d\�e\�\�$�\�FQ�\��#x\�q�1\��8���\�\�a�/ފ�[�C\�ף?Љ�3���x7Bζ\\\�Q$3�ꌨ�ߞn\�\�2gI�&\�x��h\�\�\"��$��aS�����\�\���k\�\0Z-\�[ښ}\�;Ek�u�3�u����h�֜�\�ߌ\�\�f�\�v�p?b�*\�`\�,k�=w\�J`K �@G5��� �\�:l�Έ��@�fALDDŋ�L�9(s6rs\rP\�j�y\�F1��6�+�DҾ�]S?�x�\�\�\0��\�br�A$�?}�\�\�?X��0�\�T�\0�=l/T\����\��i9*D\�.\�Lf\�\� P[ϳ�DDs����V�O\�q�\�Yٜ\����N�1>���̎�ccc\��ϗsO&��\��R�\�\�\�\�]w\�\�\�\'3E���5�s�\�\�\�]U8\�\��x��sE]�\\�����hE�\�B��s�sFM���\�3r8��\�-�\�h�\�\�\�D+\��h\�9\"�&\�c\�+���\nxgQkkk\�\�W_�={�Ȯ�|��l�%�<�\�-_-����}2������kɹ��\r�\"��}��Ѽ\�Z\�\�m�l����Hn:\rho\�F|W#F����\�D݇���v\�^@Z54���\�=?ꓭ�8d�l�\'n]\�\�y�܌ݍ�\��R������p�~��K�-�`_��w@��s��\�$�۪0�\�r�T��\0\�\��ad]*�\�\���\�����\���bm�}�|�\\`\�)\\d���ͨ4��h��8�ػ�:�ŐZ��n�\��\��5v_u\Z?giGC�і\�?\�kًX��ne�~�0>�%SS\�تN^6\'\"�s�\�$�bﳉ>tN\�R;\�m\\d\��΂�\�|ZgY�\�vQ)\�\"�����\n��L\"\"\"\"*8Oee�v�%K�\�ԩS�yV�=֢W��\�ٳ�\�s�{##{{� p\���/\�/�LP�dfSݹ�\�\�X\0�A���F8jm\���F�\�4g����\��\��\�]U��Q!�=֢7�jvma\�	�\�Efee%��3�s)++C:�\����!�Ji7턽\�\�\�\�\�\�\�\�\�Z�X�^)\���\�\�{\�\�\"3�Of��]�Ef�&\�\�^�jK�>�TJ\�\�\�\��z\�\�\�!��\"|�7֢\�Z�L�$	\�\"ӛJ�����qW�3\0`ll\�ծB�N�]}2G�\�`-�`-�(\�Ztoh�>k�}�w\�]����G�H<�yFy摔ɤ�g#�\�x+\�\�¹ő�xH�Ne�\�p\��\�\��\�ID\��{��k\�<K�i�-���E*\�\�\�G�%;X��/\�Z\\\�*�բ\�{2�J���y1tV�Ϯ\��\�@\0�@���N,\�\��\�\�:��B]\�A}m}�y�\�\�\�G,X�\Z\0hZ��`��\�5+�-�\01\�l�\"���\�0�\�\�\'�\�PZ5b\"\"*^\\d\�A����k�\�V�\�c�3��@�]I��?A��~b���\�\�x�Ā\�?!t\�[��j4\�}�����a\0\�Ue=�\'���P\r�#�\n,��\�@\�~2Q]k�@m=\�f\�!\\d\�A���tĬ/\���4P�\�?�EMn�\��Q>\��1\�\�G��q?�\�\�>�ʧ�\�I\\d\�#�ώ\0�\�\�݄\�}���\����3�M\�P��\\A4Y���Ŝ�tw�뱾v\�R9\�8�\Z�G\rFp��\�1�\Z��k�\�\'u������DsY�a\ng\"���C�/Cw��dg�7�\�\r\��Ak2�\�*�ؗ\�#�[Q�ݎxOhj_�\0�\�\�0�.�@b\��\�\��XG\�\�{J��˾\\>�\�ɞ�%\"��\�Y�x��k�˖-É\'dsFyy9R�\�\�\�\�(//ǅds�\�\�EYY�1�%\'֢W��\�޽;v\�\�FEɹ�\�ğ\�r������\r�;w\�]@��L�=֢\�Z\�N�>\�\�\�(\�f\��ͳ��\��R�\�\�6c/6\���5�>�d\�Jr�9�\�\�f\�zk\�c-z�\�f\�<�ia-z�Eo�k)�3�TJx&Ӎ�\��R�Ew&\�;66]����ڜ{�h\�\�\�Wd�̑\�2L�qL9N�O\�\�v�y\�8�\'\�\'sd�\�<jS��\�9�]�i5�)\�I�\�\�.\�4�\Zǔ\�$�d�l�a�G�c\�!*v�^�N�O\�\�v�\�p�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8�\'\�\'sd�\�<jS��\�9�]�i5�)\�I�\�~�_�!\"\"\"��\�\"�����\n��L\"\"\"\"*8ϢE��_����\�\�Аl\�X�`FGG�\��Pt�7s�h�k�~�eee8��\�\�\�Z�X�^)\�\�\�ߏ���\�W��)D�bɒ%�\����.`ǎ��(\�G�%ka-N�Z˙3g\\_�\�\"\�\�ZX�R��|\�+_���E<�\�c2�hV\\v\�e���\�166\�E�k\�c-z�T�v���\�\�\�J\�挲�2�\�i\�D\0\��x\����J�0>��^�>�����+k\�c-z�X\�<�{ｗ[QQikk�\�\�EGG�\�*\��k\�\�ZX�ӥ֒H$܋\�\\��/Y��N��ͳ��\��R��46c�R3S��\�}T�E��\�ͧZ����r�����k\�f\�T�\�\�\�\0��\�X�k\�+�Zt�\��\�r\"\"\"\"*8.2�����\�\�$\"\"\"��\�\"��\\\"�����\0DM&\rˌɈ ����)O[S7\�Bw<�d\�V�(\�3Nhz\�\'\"���\�$\"!�\�Ke[4u#�lEMVc\�۪p`ͻ\�\\@ @`S��3`��zco\�O\\�pTn^�\�靟�h\�\"�h.G�<��\0�PO\�\�\�g\�G��d\�d\�OYg*�6\�c�g;\Z�@p�cQV\�\�\�\�\�fjp�<\\o���g�eS�V�[Qw�\�ζ,\�x�3�\�(��n�\��v�\�wC�o��;:\�ڻP\�b��O�\�\�\�珨6�%�y��L�RV[l�\�\�նb;� \�D5��\�o:\�3x#h\�\�\rl܂��8�\���ajЏ@ �\�� \Z[\"\�Y\�\�\�\�@ Ђ�������*�\� \�\�Y\�v4T7C��\�\�`\�Y\�\�ԋ�G�Xa-\�\"�5H=h�lDU�=?\Z��\'��\�Z9`\�oוY \�?��\�zD\0��	�aR�̩\�ꉣ�\�\�3Љ\�B��h��\�\�\�j�\�\\�p!Ξ=+�3�~?\�\�v\�w\�;\�{�^���s|>_\�=�֢\�Z�J���\�w\�uWf�\�PO]k�\�ɉ>�8r����\�nF/\"�&\�chS5���\�\�B\�Ý�fy�:��M[�m]�;ڂ\�5�&��hC\���\0��H\�2��\�j�1���\���^�,��\����]u\�Ա\�\�\�\�\�T\�@��:\�\�ԍ�6`K�A�S�\�E5�@\��z�\�e��5\��YI\�|\�%\�߉V�\�f�8�~����\rW_}5�\�\�#���}\�Z���\���|���\�\�f\�6\�\�Z�b�%\�f\�\�(����\"*\�\��bh�$�\�E�\�T�ÇPw����a�\"�ex�U�\��qы\�)\�߉V�.\�E�\�\�\�\�X�k\�+�Z�;9\�0��/C\�c�\�\�\�\�\�!$�uX\�\0!�[Dbغ�\\�κ?1\\/ΒJ�8~2��\�d�ԋ\�GPwK�.U�k�z�j\�ۗ���)\'AUp\�ML�\�\�N ��5\�~\�\�\��IDTz�\�$�\�\�\r9\�\�MF/��;�m�����}�\ZЎ^?)��#\�oFu\�\Zw%�Lv��d\'�7��w\���]\�$��@L��\�\�CM�$��\�~����\�3�u\�\��ч-{�pZ�U�5F=j�\�>�/�\�&9\�\�jt֠5�D2ي�C-��������r�����k\�y�|γ�|t�Z]�\�A\\�F8�\�f�3sI;�\�\�8�w\�T�K\�/E�\\\�\�Z�X�^)\�\�\�\�DTdz\��0Кc&\��;&7\� ���\�\���.j�Y����\�!.2�hv\�\�߻�\Z��\�r(܀�T\�\"\�ä �\�C\\dQ�y*++��d.Y��N��ͳ��\��R�eϞ=�\�{J�L�\�\�\�\�\���q\�}�ɮ�*\���X�kћO��\�\���A\�\"���\�\�ò9���\�tZ{�RVV�T*�ݴ�M�>�����+k\�c-z�X\�<�{\�w\���\�I{�\�\�}2�ƹOfQ\�s˳6(o\�F��K߆F��:dn!��Hn\�m�+�z��I��>ܛ\����6x�^ttt\�.�\�G�ō�\�=S-�Dµ\���R)\�b||\�\�\�\0s��PE�\�iW�̑\�2X�>X�>J�\�z���|�l�4�\�\�v>����K�\�\n�{[�y7��\�\�[n\�C1t�?O\�\�Jk�\�Ak1k�9�\�p�zѼu\�\r_hR�z-\�K\01�x\�9��Tr�~��}\�Z�����R�\�ծ\"_-:�\'�h.G�̱�	�đ<܍\�x\�\��p\�jK&��[�[mqt7�z�xP\�Y\�\�\�\�\�fj�6@�\�\�\�6\�Y\�\�\���H\�\�V\�\�4,\��2{Z��Hƻ��\�}؞+\�mm\0��ޮ��@\�8\��\�Ӎ�=v������\�\��7\�\0\�᛺w\�hT����f�D���\�j��m\�vlA ЉjP�.\�B�A\�A\�n`\��%�ġ-�-j\�o��\�ԍ�\�\n�m�\�\�-mE�\'d-Pч�@\0�~\��Ӵu��\�@��#Ϛ\�\�YO�Xa-�\"�5H��\�Q\�oϏFl\�	\��(Mu�pi\�\�6]�p?b�*�vG�\0P�\� \�C\�\�(\"� ����\�aˡ��\�b\�@]c\�ڼ~�g(8?\�l\�\"�hʜ�\�\\�\'�\�Δ%pp?��\�1���Ě���\�l�ςm�q<*1[�\�:\��OA^W��\Z\�^+\�\�+�E`�_�\��(j@;BX�4��\'eN�޾`\�:�\��\�Sw}\�\�1\rB+*���ġd\Z��\�������a�\�i?%�\�^�\�~\�P�\���\�OJZ�X\�\�g\�&�>;�`�v�mP����f�DsP\�~��0\�y	��%쳑*.�8�\�ԍx��S�c�A�\�\�\�P��5P��?�z\�e��&��\�m\��\�B\�\�9\���D�VC	��7\�=����\�\�!$2g=\�3�\��ŕ\�3�\���\�\�M݈o�d-�zq�dU\�e\Zr\�E�\�#���PgI\�YW5�ώ\0��}�����\��\��\�\�z����T\r8Ί�\�Q��\�q��\�\�9B=�\��CWT 1\�>��W�\�\'\"�M^�\�]x<W�3\0s\�$\�\�ׯ\�4�\Zǔ\�$�d�l�a�G�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8���.\�I6@/��;S�\�7W�oS\�ы\�\'\���ͨ\��/\�v��d\'�7��w\����\\]�ry\�\�\Z\�\\ƞ�\�:c�W�#AL\\*�\�m�\�G�l\�\�\rh9W]S�\�\r`]�F֥j\0H,]��� \�рv������u�z��3\�!�[i\�<+�ό\\�_\'\�\'sd��\\s8\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8�\'\�\'sd�\�<jS��\�9�]�i5�)\�I�\�\�.\�4�\Zǔ\�$�d��s3���\n���\�\�Y�Z�X�^)\�R���\�\�O�ϲ\�24�d8�\�fLi?\�HO7b\'�\0�;ޅ��\���֟\�Na\�Φn\�[����>`�0S��\�}T�E��\�ͧZ���/^�X�\�\\�lN�8!�3\�\�ˑJ��N�eWFyy9.\\� �3�^/\�\�ʌ9`-9��R�e�\�\�رcG	.2\�c}\�3�j\��sC�)/2#\�yR4{\���Mѧ�\��;�\�:\��O�\�?3\�\�\�\��x�s\�N\�\��\�4k\�c-z�\�\��\�ӮE�wll�w�9�Ѳ\�ٯ\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8�\'\�\'sd�\�<jS��\�9�]�i5�)\�I�\�\�.\�4�\Zǔ3/\�䯾\��ġp\��\�\�>\�&\0����E�^4WOec�^4W_\��\�\�z�:\�>�#\�e\�\�9�)\�I�\�\�.\�4�\Zǔ\�$�d�l�a�G�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8�\'\�\'��Et\"\"\"\"�K�E&�DDDDTp\\dQ�q�IDDDD\�\�+\�\�\�4U\\y\�8w]�\�\��l\�\�7\�m2�\�}�}�b-7\�|3�9�\�\�a�իW\�\��\�?��\�5�y\�#�\�)\��(\�<�\�a-�`-��O��;wW^u�rnƾd\��:uJ6\�\n֢\�Z�J��\�݌�沙ڌ�P\�B`-z�Eo>բ݌}ѢE\�EfUU���dsƂ0::�T*%�\0{��6\�̵�\�\�GYYΟ?/���=֢W����f\�4g���\0v\�\�!���}\�Z��\�\�t���9sƵȴ\�{�DDDDTp\\dQ�q�IDDDD\�E&�DDDDTp\\dQ�yjkk��d.\\�gϞ�\�~�\�t\Z\�\�\�\�\�?66f\���|9�dRX�k\�+\�Z\��n\�u\�]\�\'��J[[���j\�ٳGv\����dc-�\�a-n�jt\�\�\�\�m���(\�X7c�b\�\�\�\�X�k\�+�Z�;\�.2�����\�\�$\"\"\"��\�\"�����\n��L\"\"\"\"*8.2�����\�<���\�-��,Y�S�N\�\�Y�Z�X�^)ֲg\�\�s\�=\��J[[�~?\�\�>\�UP�zk\�c-z�\�\�a\�F�`0�]dVVVbxxX6g���!�Nk�JR\�\�ʐJ���v\�\�s\�\��attTvea-z�E�ky\��p\��r�IE���\r^��(\��kqc-z�E\�TK\"�p-2��T\n�w�9\0\�\�\�\\\�*T�\�t\�\�\'sd�֢֢�R�E��&*�^�\��>b-\��Z\�})\�\�jW��ޓIDDDD\�E&�DDDDTp\\dQ�q�IDDDD\��z�Ѕ\�\�q�9�1GL��|�*L�qL9N�O\�\�v�y\�8�\'\�\'sd�\�<jS��\�9�]�i5�)\�I�\�\�.\�4�\Zǔ\�$�d�l�a�G�c\�!*v�^�N�O\�\�v�\�p�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8�\'\�\'sd�\�<jS��\�9�]�i5�)\�I�\�~%\�f\��ͳ��\��R����S1��\�\��>*֢\�Z�\�S-\�\�\�/^�]d.[�\'N��\�\�\�\�H�RH�Ӳ+���.\\�\�^�eee\����X�^)ֲ{�n\�<e^�7�\�\�lc-zs����\�ܹS6E�>2\�\�Z�X�kq;}��{��h\�\"\�\"���\nCCC�9c��ͽ�כ)&ׁ\�\�����\�ϟ�]YX�k\�+\�Zjkks\�\���\���s����\��կ~%�3�`ԁltttN\�r\�-�\���\�8r\�0˵Hs�\��b|��l���8]j-gΜ\�\"��L`-�\�i>\�RQQ�����\�?\�\�\��v`k\�a-z�E��\��\�E�\�\�ߩIDT�n��V���/\��\�\�3�L\"\"�\\dѼPQQ�}\�C\0�ŋ���M�Qq�ID�­�ފ���:�\�W�\�<�ID4��\�$��WQQ�M�6᷿�-Ο?�3g\�`�\�\�����JDD\�\�+\�^ͦ�W^y%Ν;\�jW\����<wz\�\�9e��|9�E�E�E�{\��|\�+\�\�ى\�Ǐ\�\��.~�\�_\���=��y<�\���SQ\�Zd�3f��\"ۜ�Z��Z��Z�1�j9w\���\�*8\�܌}ɒ%8u\�l��E��\���^\�+_�J�\����-[���\��f<�\�S3^K.��{Ʌ�\�=֢7�j\�n\�\�-�,���(���kٶm�x\�	�ۿ�0˵H�E��\�=֢7ݵp#\"\"\"\"�\\dQ�q�IDDDD\�E&�DDDDTp\\dQ�q�IDDDD穭�\�p\�B�={V6g��~�\�i��k<�c�\�ؘ1\�\��\�ܓIa-z�E��\�\���?�?�\�O�\�#�\0�\\�\�Z�X�k\�c-z\�]\�\�\�k�Ln\�nc-�Ea-�]7cg-:���(�\�\�j\�f\�DDDD4#�\�$\"\"\"��\�\"�����\n��L\"\"\"\"*8.2�����\�\�$\"\"\"���TVVj�0Z�d	N�:%�gk\�c-z�E��X�lق�\�G8t\�0˵H�E��\�=֢7ݵ��0��A\�\"���\�\�ò9���\�tZ�W�RVV�T*�ݴ��K>�����+k\�c-z�E��X�n݊\'�x}}}�,\�\"�=֢\�Z�X�\�tגH$\\�Lo*��.\�\�\�]m\�\0���1W�\nUd:�v�\�\�.��胵胵胵L�;Ǟ\�Zd�}�}�}�}Lw-:�\'�����\n��L\"\"\"\"*8.2�����\�\�$\"\"\"��\�\"�����\n\�\��z��\�\�js\0c��D��U�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8�\'\�\'sd�\�<jS��\�9�]�i5�)\�I�\�\�.\�4�\Zǔ\�$�d�l�a�G�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�=O\�ئy\�8�\'\�\'sd�\�<jS��\�9�]�i5�)\�I�\�\�.\�4�\Zǔ\�$�d�l�a�G�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8�\'\�\'sd�\�<jS��\��J\�\�\�+**022\"�gk\�c-z�E��X\�f\�Y�\�Z�X�k\�c-z\�]˰n3�ŋk�˖-É\'dsFyy9R�\�\�\�\�(//ǅds�\�\�EYY�1�%\'֢\�Z�X�%\�\'�����Y�Eb-z�E��\��\�\��\�ӮE�w\�ޘX\�����\�\0�9N�O\�\�v�y\�8�\'\�\'sd�\�<jS��\�9�]�i5�)\�I�\�\�.\�4�\Zǔ\�$�d�l�a�G�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�O\�\�����M�qL9N�O\�\�v�y\�8�\'\�\'sd�\�<jS��\�9�]�i5�)\�I�\�\�.\�4�\Zǔ\�$�d�l�a�G�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8�\'\�\'��Et\"\"\"\"�K�E&�DDDDTp\\dQ�q�IDDDD\�\�+\�^ͦ�W^y%Ν;\�jW\����<wz\�\�9e��|9�E�E�E�Ŋ�����\�رc�\�r-2X�>X�>X�>X�>���s\�\�\�ʫ��S\�\�ؗ,Y�S�N\�\�Y�Z�X�k\�c-��l\�\"�=֢\�Z�X�\�tע݌}ѢE\�EfUU���dsƂ0::�T*%�\0{��6\�̵�\�\�GYYΟ?/���=֢W��\�޽�V��\�S\��x0>�}�ϸ٬���cccf�i.ֲs\�N\�رC6\����dc-�\�\�Rk9s\���ek�;�\�޽;v\��\�?.S�fM[[\0p�\��Z�X�^)բ[dZ׉����\n��L\"\"\"\"*8.2�����\�\�$�\�	G�L&�<�=z\�(�\�8��\��.��\�S�%\'{�x7B\�֞�U\�C��{:~DD3��L\"*�H}��?j\�1\�]��@5��ˎ�Ջ\�\�\0k\�e\��\�\�\��ú̢/�u+�@b\0\�]躉�J�DTM\�X_$cH��aա\�F�\'�3�\� \�>{9l\�:ό6u#�ڒID3sDu�\�3�\�9���\�aQ[2\�Z ��\r � \�\Z\�֡.$�D�\�l�\ZG�]ęP;\'�F��$\"*�\�\�Z\�F.\�ٳges�\�\�G:�ι��\�1~ll̘\���r~]^a-z�E�k��\�q\�]w�F��8�\�}��\0ۺ\�x�\�>�Bw����6U�y\�d+*���\�V$7WX\�\�E3��`�\Z�\Z\�\�F|W#F:Z0tKꎶ�zc/\"��h]ڇ�\�X\�B#�\�R\��\�ѵv��N,��:bV\rvNo8�\�\�\Z\�:\�O��֮͞��9������\�aU������<sw���k倣\���(\�3�mmm��꫱g\�\�U�\�#֒��䞇��\�eppе��ɴ�֢c-ſO����\�j4\�\�^��:lW�K��:ޢ�\�p.��Y\��?$�\�R}�jѪ[�\�D�k��P\r�!s\�\�\�D�c.\�8k,\�\"ڱ8<ޒDk�����T\�\"�!l��\�\�\�od/v\�\�\"\�\'3k\�c-z�T�\�$�\�a_>Fm+�ɤ�t\\^.\�rw\�\��\���\�+sɼ�uA \�\�׳}M\0�M}H\0\0jЪ��\�9�DrW6\�\�n\"�9��L\"�d��FCg �@ �@�}	 �r\�Ľ��/\�ԠJ\�Ϙ5ʄذ�6\�\�2~�\r�����/\�dc\�9�\�\��b \�ܢ\�lEc��bN��\�\ZC\�~Pž��\�8�����@/���B\r�Њ�L�򥰾<�\�\�NDT\Z�\�$�KA}-��~L,\�4\�\�N��j[\�d+j}\�\".G;�n�F\�`��\���NT��\�80\�v!�\�B�­\�՝�ѕLڗ�\�efwN\�P�}\�|�\�\�\�U\�E�\�>$gsc\rh\�\��\�l&\�Z92��p�k\�Z	$D\�ubX\"�9��d\�XkQ���\�\'\�DޓI���d��=֢WJ��L\"\"\"\"�\\d\�4�7E\�YL\"�y\�SYY��\\�d\��:uJ6\�\n֢\�Z�J��={�\��{�˩T����\��\��\�]U��Q!�=֢7�jv].��A\�\"���\�\�ò9���\�tZ{]^)++C*�\�n\�	���\�\�\�\�\�\�\�\�Z�X�^)\���\�\�{\�\�\"��J[[�^/:::dP�\�#\�\�\�Z�X����D\"\�ZdzS�t1>>\�js\0����\�U�\"\�鴫O\�\�v�E�E�X�\�\rMTr�~��}\�Z�����R�\�ծ\"_-:�\'�����\n��L\"\"\"\"*8\�ic-�E)\�Z�x\�	<�\�c�����B4+^�W\�\�ٳx�駹O�k\�c-z�T�n�L.2m���(\�X\�7��\r<��\�x\�\�d\nѬ�����u\�p��q.2X�k\�+�Z�\�d-YX\�ܩen?�J��\�\�Z�X�^)բ[dz�^/t\��x\\m\�\0`\��h#_�\n\�<jS��\�9�]�i5�)\�I�\�\�.\�4�\Zǔ\�$�d�l�a�G�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�r��]�ׯ�\�9�]F�9�\�r�d�̑\�2L�qL9N�O\�\�v�y\�8�\'\�\'sd�\�<jS��\�9�]�i5�)\�I�\�\�.\�4�\Zǔ\�$�d�l�a�G�c\�q�}�_ɹ{EEFFFd�`-z�E�k\�f\�T�fj3�B��\n��\���T�v3�ŋk�˖-É\'dsFyy9R�\�\�\�\�P�Us�z�(++3怵\�\�Z�J�^.�b\�\�\��ǃ�;w\�.�\�G�yX�k\�c-n�O�v-2�ccc\�\�����\��7��\�\�~E�\�\�.\�4�\Zǔ\�$�d�l�a�G�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8��b�\��\�$�d�l��k\�8�\'\�\'sd�\�<jS��\�9�]�i5�)\�I�\�\�.\�4�\Zǔ\�$�d�l�a�G�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�\�W�щ����.�D49\�(��n�d�4�N\"\�\�)\�G�pD6Q\�\"���L˗\�6K\�\�jִ\�f\"\"*B\\d\�e\�h\�3{\�Y�(�\�$�ɤ#/�\�ݖ���	\0\"�&\�\�\�:\�#���8�X�V��\�f8�d<�h\\\�1�s\�[g\'�a{�g�\�\�َ\� \\�ݮ!�\�\�8�\�(Rg2�s:k�\�ڬ~��DD4�\�$*e�@ ���>$jף�	�\�B\�\�N:Fи+\nk�Dce?�\0:�h\�U��@\0-��\\g-\�5�\�-\�C#��\�g�C[���;\�\nt&\�\�f-\0\�\�\� |����T�\�PsK7�q�@\�\�4\�\�ނ@��\�Vs:6�5l-x[kc\�\�:������h&y�~?t\��x\\m΀��yٮ\�\��\0|>��O�ڼS�\�`-�`-�(\�Z<�B=q\�l\�\�\Z��\�u6/#1�\0\�?kw4\�Rt�߾\�\�GXn�mT\�\�0؏v\0�\�:�U��?\0�8x4�`e�\�>�\���UA�f�}6qs\r�\�:{|��o\0	��(\Z�n\�^H\�F�ն\�s\�0��Z\"�5���� \�v�>�^�\��>b-\��Z\�}~\�\�jW��oYYt\���\\m΀=�lW�&�ۏ;҅*X�\�0\�S\�Zrk\�\�\\�E.2{7Vg\��A�	̱@�y	�m�\�d�\�3�\Z��Q�\�bnN\"�TgUi��\�{�\�(\��k\�\�\�\�+c-�v�j\��?�H�R�6g\0�\�訫]�ڬ��>���\0\�j��Z��Z�Q��\�ڃl\�zq�$PSo/\�\���ɜ��\Zԇ �u+�H\�DC� \Z[\��Q\�\�1\��\��7X��e\���ǀ\�zk��u�\�\��i�\�5^�\�#֒�\�\�w���\�U\�E��d\�e\�)ۺ}M��ڗ\�7W�oS�uyyRb@}\�d\Zч-\�\�^4Ww\"�.\�;\�\�}�w\��\�rw5b��\��B\��\�Ov~^\�t֠5�Dr[F.u\�JDDͳh\�\"\�c%���044$�3,X�\�\�Q�R)\�ؗP\�\�r��Q�\\s��֢\�Z�J�>V�\"4u#����\�钴��\0v\�\�!���}\�Z��\�\�t���9s\��Xɬ?\�ea��uf�o�\�L\�\"��JG���\0�]��h�p�IDDDD\�E&Qɚx�\�ɓ\�/\�8\�	n���sΧ9��\�d���eNDD���L�RմuA\�\�7K����3��\�O	\nX\��xԤ\�d\�9$�\��ʷ؉�h��\�\�\�j�]�p\�B�={V6g��~�\�i��k�^�ccc\��ϗ�L\nk\�c-z�X\�\�wߍ�\�\��\��p\��~\�6FD����\�\��Z�����8�\�\�Hv\"��\�j�<���vD\'\�Z C\�c$\�5r8��\�-�\�[��6`K��\�3y{�ZoBKu3zBw�U�`\�.T\�C\�\�F\�:\����\�e�1tr�Zt\�\�\�p�\�WcϞ=��(\�G�%k\�=kq\�W\�\�\�\�\�\�\�\�\�\�ZX�R��\�\�\�(\�\"S-Ҫp Љ\��.T=@t�\0:W؋\��z$7\�Z\�ً��\�ˈ �\\��Il\r��\�D\�d=�3cO\�ֈ>��pԞ���9��`*\�\�ȍ�\��R��[��I?�\\��\0��\�J\��O��Գ�C获��n\�\���t]�j\0��\�3�\�Y\����q�u?g\�\�\�ē|��hN\�\"�h��g��|�>;A4�\�*\�lN^{5�D\�k\�\�7�u?\�D��\\ND4�p�I4��>;Ԯ�\�h}c\���\�\��V��/\��C�}X���1�;��g��8FP��vm����\�\�Q�\�\"�h.�\�\�\�\rh9�2t\ZOvfoX�\�\�ߑí��\�nG�\'d\��9�\�_/#\�R9\0$��\�\\��u4�\�h\�\����k޵v��=SKDDE��L�R��Ձ��\�\���3�\��\�{7Vg�w�\Z���\r�\�e\�Q��ךð�k_#��º�A���[2\�f.\�\�oF5/�\�Y\\d\�� ���I\�y��t\�\�ᩬ�\�na�d\��:uJ6\�\n֢\�Z�J��={�\��{\�qoaD4�\�\�\�\���q\�}�ɮ�*\���X�kћO���0��A\�\"���\�\�ò9���\�tZ�W�RVV�T*�ݴ��K>�����+k\�c-z�X\�<�{ｗ�L**mmm�z�\�\�\�]@��X�k\�c-z�Z��k�\�M�R\�\�����\�\0066\�jW��L�Ӯ>�#\�e�}�}�b-�74Q1\���-\��k\�\�\�\�K�W��|�\��L\"\"\"\"*8.2�����\�\�$\"\"\"���,Z�H{�\�t?HE�Pw�\�\�P��|\�[\�¿�˿\��?��L!�˗/\�\r7܀��~\Z;v\�\�E�>b-\�Xkq�\�ZΜ9\��\��6\�\�Z�b�\��\�G4\Z\�\�O?-S�fEuu5\�\�ǹ\�X�k\�+�Z��\�ŋk�˖-É\'dsFyy9R�\�\�\�\�P\�\�\��zQVVf\�kɉ�\�b-�w\�Ǝ;�����6x<\�ܹSvE�>2\�\�Z�X�kq;}��{��k3���\n���\�\�Y�Z�X�^)\�\�\�ة\�\�f\�zk\�c-z�\�f\�<�ia-z�Eo�k\�L*F<�\�\�Z�X�^)բ;�\��.\�\�\�]m΀�A�lw�+�O\�\�v�y\�8�\'\�\'sd�\�<jS��\�9�]�i5�)\�I�\�\�.\�4�\Zǔ\�$�d�l�a�G�c\�q�}2G�\�0ͣ\�1\��\\�_\'\�\'sd��\\s8\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8�\'\�\'sd�\�<jS��\�9�]�i5�)\�I�\�\�.\�4�\Zǔ\�$�d�\�-������\�\�$\"\"\"��\�\"��dDM&�\�D4,s��q\��\��\"\���K\�ԍ�\�\�\��\"�&\�\�n�\�S\�#�w.\"\"ʇ�L��ю�@\0�@\0���\�C��\�B/2\�Q$w\�a`�=_�+�&�B��*X\�\�oƖ\��ӳX&\"�i�E&\�\\�N\�[�\'>qf\�η\�\�u�;>\�>�E�\�VF\�k�8�\��\��h\�ڂ}�)-\�挪u\�1z8��\�Y\�\�\�V\�\�D�=T\�\��-\�\�PO<炶�E�\�<�\�<\�k�\� \�\��&\�\�����\�\�js\�\�\�v>�\0\���\\}*�^k�+\�e�}�}�b-�-E\�\���f���N����\�ԇDm+�c�N\�P��0�\�8�8ΎW�C\�\�#\��fϳ�\���\�\"\�\�t\�r(��z���bx����\�Z;�\�@\0�@\'F\�v!\Z��\�s\�0�:�kz7V�z��\0D\r\���ۺB\��VTj�\�+\�\Z\�F���\�\�\�4�{ɵp�\�r�~��}\�Z�������\�ծ\"_-:޲�2\�\�\��ڜ{\"ٮBM\�w�U�l�a����\�֢��X�\\df\��m�j[���\�>\�Њ\n ؈�d\�d\Z��X\�%pp?��\�1��z�\�\\\�\�\�\r��W�\�\�\\c�8џO{�=s��km0�O- C+*��~��e;���wa�\���t�D/���\�:g�[�\�\Z��o\0�`jP�����9گ�BP��ы�GV��#M�\�ޣOF1��XKv�w_kq��\�W������\�E*�r�9\0FGG]\�*\�f�.\\p��\0W�֢֢�R�E\�Aֻ�z\�\�\��N\�W7Cwn�D��5\�\"�Y\�p\�]U8�\�\�\�P�B,i��w^�FȺ\�Z\�3�Tzr�Ƌ�}\�Z�����γW��|�\��L�\��\�P�޾?\�Z�M\�p\�u_d�~\�,_{��\��<�н��s�b7�!�[�}&S�꫷�\�R�\�4g-C���n\�,m���\�b�a(D]��wδ?9�Dк���İZHѥ\�\"�h.7\�?+n�\�O\�e_.?ٙ\�~F7k1مd2��\�>��=oǈ=�5n\�\�1�u	�fs\�\�v\�hX�\�}I?\�`\�\'�L\"��\�l[sO\�\�	�i\�`]\�6}�\'�z��<з��\�Es�u��\�>�\�\�f�\�oFu\�\�0�\�\�\�Y�h��\�\�UUU\Z\Z�\�,�\�\�(R��\�\��t\�3.\�>E]\�\�u�Ua-z�E�k��\�.���s��\��}��\�V~;&�hmmm\0�;vȮ�|��l���8]j-gΜq?�<\�ODDE�\���f\�\�W��L\"�9��L\"*^\�v��ͨ6}������DDDDTp\\dQ�yjkk�_�Y�p!Ξ=+�3�~?\�\�4\�ǵ?�\��׋��1c�\�\�\�y��\�Z�X�^)\�r�\�w㮻\�g_��b\�\�ֆ���\Z{�\�]E�>b-\�XK\�yX�[�Z]_�\�\�m���(\�X\���v9;~�܍�\��R��\�.\'\"\"\"��E&�DDDDTp\\dQ�q�IDDDD\�E&����R��ђ%Kp\�\�)\�<+X�k\�+\�Z�\�ك{[QQikk�\�\�\�}�\�\'�\n�P\�B`-z�Eo>\�2<<\�\�\�\���\�\�\�J\�挲�2�\�i\�^IJYYR��v\�N\�{.�|>���ʮ,�E��\�b-<�\0\��^.2������\�����CvE�>b-n�E��\�jI$�E�7�JA\�\�\�6g\0�\�ؘ�]�*2�N��d�l��Z��Z�Q��\�\�\�D\� \�\�\�G�%;X��/\�Z\\\�*�բ\�{2�����\�\�$*D�I$5\r\�\�h\�F\�9\�\�̘\�(\�=������Hƻ�\'+��\�\��;%\"*!\\d��v4tĀDZ\�?7zA\�ԍ��F�t\��Zз�u�Do��@�*���I\�\�l\�\"�h.G\'���\�]gC=q$w�;>\�>�E\�La����N\�\�\�[���]�\�&1_\�̡u\�j�[��ptb.\�\�p\�xѸ�W�\0B=끇�\�kW\�\�5��k�\�\�\\g�Ъ\�r�\�G]�#�\�]\�3�DD��E&Q�Gѵr�>�i�q\�,�j뀭6�!Qۊ\�؂@�1Ԡ>��;�-�����\�B˗�\�X�<�b D\�u���6\���a Գ��Ϯv��q[�\�\��\nm\r ���\�]h<\�i\�1�\�]QDº��Г��\�#���\0h_�\�n�xx��\�=!k1��b�業�K�]kG\� \�\�\�ڮW\"\"��^���x<�6g\00\�I���_�i5�)\�I�\�\�.\�4�\Zǔ\�$�d�l�a�G�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qL9�dήm�j[\�g圹+*�`#��I$�]h5����\�\0\�gH`��@C	��7܎^u6ssMָ���0�\�]I$\�\�p�\�Z\�\�T�8z\�:\�n@�z\��\��\�`/jc�\�Vs�1T`yS\r��*G�a(Q�\�\�K\�1���&����BP�.\��`?��\�\�?T��\�\�o�^�N�O\�\�v�\�p�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8�\'\�\'sd�\�<jS��\�9�]�i5�)\�I�\�~\�[^^]x�^W�3\0�\���\�e�lsFYYYޜr֒3X�>J��\�\�X=q\�\�}�ϴhS9*\�\��<\"��H\�\�5\0�\�O\�Z�95�C]0��\'���\�La/3�4�\�\�z\�:_��\�3�>�m\�`-�`-�`-\�\��^�p�s�9��L�]\�\�6g��Ce�֢֢�R�E\�Ov1z�\�{%ս�SY�%u�@�~bQ\�\�e]^��tB��F�y\�d���:�\�A+#6��/�;\�\�|r	\�g�֡.��\��Z\�fξ�\�Q�߯;k�;�)Y�\0!�[�.�?9�D�\�\�ߑj�~w\�\�w ��Z`\�\�1\���N�]�Y\�kW�9c�\�G�\��E�E�\�:ޱ�1\�b||\�\�\�\�D\�vg�\"�d�l�a�G�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8�\'\�\'sd�\�<jSN^\��g%\�\rh9\��uҺ��zc\�s�Y\��c�\�B2�D�p�*\�\0��fT:�\�\�\�8�=�kڭo�w\0���eZ��a\�\�^�n�F\�I���\�\Z\�:\Z\�n\�\�ٸ+�\�*�ؗ\��5��דI$7W�oS\�ы�G��Fǂ9\\�\Z��v\�/�Āz�fX�a3�;Fܿ�pZU\��VTj\�\�\�9�\�z�:\�>�#\�e\�\�9�)\�I�\�\�.\�4�\Zǔ\�$�d�l�a�G�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8�\'\�\'�ϢE������\�\�Аl\�X�`FGGs\��n���`��u�~?\�\�\�p��yٕ��\��R�e�\�\�رc+\�A4�����\�q,\�F��L&J[[\0`ǎ��(\�G�%ka-N�Z˙3g܏�\��ќҎΣu\�7\�\�Q�\�\0�DDE��L\"�\�z7Vg.m\�u���f�DDDDTp\\dQ����⊰W��\�W^�s\�ι\�U�|> \�Ɲ^{o?\�&#_k\�k\�G)\�r�\�7\�ȑ#Q�X�z5�^/~�\��^�*�\�=2��B���\�3�֢֢��T˹s\�p\�UW�\�SYY��v��%Kp\�\�)\�<+X�k\�+\�Z�\�ك{\�.��\�\�\��ߏ�\�OvT�\�G��Z�X�\�|�exx\��\�rnadc-�E)\�Z��#na\�\�Z�X�^)\�\�-�����hFp�IDDDD\�E&�DDDDTp\\dQ�q�IDDDD\�E&����V�O\�q�\�Yٜ\����N�1>���̎�ccc\��ϗsO&��\��R�\�\�\�\�]w\�\�}2�����\�ꫯƞ={dWQ��XK6֒{\�▯���A\�>�܌\�\�ZX�R��p3v*F܌ݍ�\��R����ь\�\"�����\n��L\"\"\"\"*8.2�����\�\�$\"\"\"��\�\"�����\n\�SYY�\�\�hɒ%8u\�l��E��\�b-{�\��=�\�\�-�������\��\��\�]U��Q!�=֢7�jvma\�	�\�Efee%���esFYY\�\�v�$����TJ�i\'\�=�|>FGGeW֢\�Z�J��x\0G��]D�\��\�/Ggg\'R��k#\�b{�7֢\�Z�L�$	�\"���[XkQf��k��W]u��\�\Z�\�E/^�\",^�8뿯y\�kp\����׿�?\��z�ޜ\�ꫯ\��\�?/�3�~?\�\�\�r��\�S%\�B�̿Z��\��ox\��\��~�\�\�\�H\�α��\�{ME:�\��W\�<y�\�\�\��\�G\���f-z�E��j\�m\�\�E�����еTWW��\�\�\�\������ӧOg�\�\�˗\�\�n\�ڵkRK1�^X�\�\\�媫�\�C=�m۶\�?�|>|>.�\�2�\�/@:��\�>\�\�����[^^�w�\�]���\�?�A9E\�dk)�\�k\�\�Z�J�\�\"�_�!�FW_}5>�\�\�ⵯ}-��y9r<�\0>������oy\�[p�\�7\�}\�{>���ᮻ\�={\�\�ׇ#G�\�\�o���݈.E2�\�g>�|\����W^�t:�?�\�O�\���\�����\�o~�_��\��s\�=�\�Ǐ\�g��SO=�_��x\�[ߊ\���rX\"*\\dM�\�w\�y\'���j|\�+_A__�q<�\�3�\�\�~\'ӳ�\�}\�\�ɓ\'�\�#�\�.���F�\�\�~��\�\'d�\�ƍ�\�}O=��\�\"��E&\�4�\��g�?6l�]9UVV����g1iθ�\�{�\���7#����\�\Zlܸ{�\�]DT\"�\�$�;w\�D[[*++e�Vkk+\��~�\����\�\"*Z������~���\�\�d�\�m�݆��\�8q\�\�\"�\��\�\�4�\��x\\m΀�MF\�\�\�wL��|�*L�qL9N�O\�\�v�y\�8�\'\�\'sd�\�<jS��\�9�]�i5�)\�I�\�\�.\�4�\Zǔ\�$�d�l��\�y\�gp���\��\�\\\�\�Z\��ַ╯|%\��~G%�\�\�ׯB\�#�Zd�����0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�82\�g��g?�Y|�tT➫��7nDww��_��G��ٟ��#\�e�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8�\'\�\'sd�\�<jS��\�9�]�i5�)\�I�\�\�.\�4�\Zǔ\�$�d��s3���\n���\�\�Y�Z�X�^1\��\��\�k_�\Z��\�of\�9}��_ŗ��%|��ߗ]�D\�2�X�^�\�r\�w\�ܹs�\�{d\0`˖-��曱c\�\�ݻW�MU�K��\�X�kћO�h7c_�x�v��l\�2\�e���r�\�\�rQ_u\�\�\�����̘֒k\�+\�Zjjj�\�w�ozӛ𶷽\r\�ϟw\���~/{\�˲\�MG-:�֢\�Z�]~�\�طov\�ލC�e��\�e/Ã>�\�\�V455a\�ʕسg����e\�9]J-J1�^֢\�Z�\�J-�O�v-2�c�ƾ2\�\�\�]m\�\0`\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8�\'\�\'sd�\�<jS��\�9�]\���8/^��n�	\�y\�{�\�_��?�8>�\�g\�Q�,[�---�\��\��\�4W�~���\Zǔ\�$�d�l�a�G�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qr\��\��g?�Y�����PQQ�շq\�F\�ٳ��\���-[�\�\��8^��\�\�\��n��f\�Xc�X�\�\���\�ׯ\�4�\Zǔ\�$�d�l�a�G�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8�\'\�\'��Et\"*�׾��ذajkk�\�#�`\�޽�\�\'?����Z�*+�\��0���/\�\�\�j\'���\�CemkT]]�7���\�W��i�\�\�~��~��ؾ};֬Y����\����3�D4wq�I4\r�/_���\�=��\�q��i\�ݻ��\����g\�\����عs\'��\��>�����\r˖-\�<�5\�\\�g\�x<|\�\0\�o�\�+_��\�\�G�Ekk+:::�w�===x\�[\�*ӈh\�\"���\�\�\�\�\�Ѐ[o�˖-C__�\�݋cǎe\�}�\�\���0\������E���Y9D�೟�,n��Vlذ�y\�k�\��ʔ,������\��\��\��\�oǗ��%\\��2��\�\0.2�\n���\Z6l�M7݄_�\�ػw/�=��^��;w\��\�?\�\��\�\'?A�L!��N�<��\�\�\'>�)m��\�\�~\�}\�{q�\�A|\��Ν;�\�$�c�\�$�D\�\\s\r֮]�\r6\�/x�\�݋`xxX�fy\�\�p\��\�t\�M<�I%\�\�\��6\���A�\����i\�&���#�஻\�«_�j�FDE\��[UVV\Z��,++C:�\�y�\�\���\��#�Ja|\\;�^/|>���\'֢\�Z�f��?��?\�\�_�zTTT\�\�\�c�=�\��\�7������~/�%k)\\-\�}\�{�q\�F<�\�c\�\�\���\�>;k�\�=֢WJ�$	\�F97c_�d	N�:%�gk\�c-z3Q\�ҥK�z�j�^�\ZO>�$�9����\�2mFj�,֢\�Z��ߟ�\��;\���\�݋�\'Of�\�t��\�&֢\�Z����a\�f\�-\�.2���044$�3,X�\�\�Q�R)\�\�+k�ig�U�\�\�GYYΟ?/���=֢7��x�^\�p\�\rx\�߈��r|��\�ǣ�>�ss\�\�E)�ߋ\�ZX�2�,\\��\�v\����\�k_�\Zx\�$�I�6#�(\��{QX�kѻ\�ZΜ9\�Zd�L�Iz\�+^�\r6\��[n��\'�}\r\�h4\����\�ٳg�/|\�x\�;\��z�o}���x\�_(S�hp�I�\�����6l�\�ŋ�w\�^<�\�C\�O�D4sN�>���\�;\��N\\s\�5�ַ��\�o�>�O�\�\�\"�J\�\�Ȉl\�r\�\��\r\�f\�\\X�`,X���\�g��\�{�s\�N9r\�t�g0��D\�~\��s\�=�;\�o{\�\��o}+V���E��\�ӹL�=�\��BD�Ȥ��?�I6e��\�j��1:�<~�\�_cxx\�?�|\�^�q���DT�\�\�.\�\�ɓx�\�q\�\���\�e�\�\�|\�\"��E&\�a!tǓH&�#\Z�y�p7��d\�4u#~8\"[�hֽ�\��\"\�E&\�q1t8�!\�?,��:\�DD%�\��b\�E&���nēQX\�\"�&\�\�~(�\�\� \ZwE\�:\Z�\�h�\��#�iw��\�oQ[3d�A���&\�&�\��cѬ�\�\�\�joN[�p!Ξ=+�3�~?\�\�t\�{\�<�^���7�\��ϗsO&��\�\��Z~�\�7c\�{\�tf\�\�h@{S7\�-��\�:`k5���\�q,\�\��\�8�c�7�\��pԣ?Љ\��.T=l���N��?��z\�\ra \�GW\���#\�r\�k\�\0�]v***�Ed\�\�\�%֢\�Z�\�R-��}\�}��Wǂ��\�%E�{)���X�^)\�288\�\�\'���\�X\�\\�%�\�x+�W7�:\�g�8����\�xK��\�\��6m�M�ꉣ�\�-�e{\�&4ug�A��#q�%3�4;�=֢\�Z�\�R-ee�\�˱ű\�u-��\��RL���R����\������\0Tnw\�\�N q�\�q\���K/���\�:��\�UA�(i_�~�#k[\�\�iDTtf�X�\��SD��4\�ՠU|�4~t\�\�@\�v��9��]\�^� \Zwű�oVv9~F\�s\�־�\�l\�\�R�\�}^\�g[Qq�S{���fRq�\�$�\�x�\�\�ZJ��bRL�֢\�Z�\�R-eee�ͳ��~/�E��\�]j-�\\NDDDD3��L\"\"\"\"*8.2�\��\�oƭ�ފ;\�7\�x#/^�\��\�\�\��g�9y�^\\~�\��zs�=�~?.��r\�LD��\��\�\�{zժU�����=�\��\�w\�n\"r�TVVj\�\�\\�d	N�:%�gk\�c-\�^��a�\�\�x\�[ߊ��\�g8r\�~�ӟʴU���\�=֢�j�\�\�p뭷\�\�k�\�޽{�o|C�N�b��֢7ݵ�\�\���A\�\"���\�\�ò9���\�tZ{�RVV�T*�ݴ��K�ϗ��m֢\�Z&�Z�\n��\�q\�W⩧�B___\�Mg���\���8�=֢\�Z�d-\�_=6n܈��\�\�\�\��w��\�Y�E�\�ߋ\�Z�J��D\"\�^d�\�\�\�27kY�|9n�\��\�\ro�ѣG�_��_�ӟ�4+�\�\�\�\�E��\�=֢���7��\�\����\0_�\�W�\���\�2��Z�b��(�E��j\�˩d�������\�z+�-[��~>� �;&S���\�~�|\��޽{\�\�܌�\�7\�p�L#�W�Ȥ9���\Z6l�M7݄_�\�ػw/��������fR4\ZEss3��_��\���ttt\��믗iD��4g\\s\�5��\��a\��\�/�޽{q\��\�=&DD�����P\�����m\�6|��ǫ_�j�FTҸȤ9\��\�\�{\���^�\Z�>�(�\�݋\'�xB��\�\�^466\�\�?�1v\�؁H$�+V\�4��\�E&�\�\�J�_�6l���\��\�C\�СC�\�o~#S���\�޽{q\�7\���\��җ��O~򓨬��iD%\�\��z��\�\�js\0c��D��U�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8�\'\�\'sd�\�<jS��\�\�\�\�Ǜ\��&\�z\�xի^���>|��_\�\��s\�\�\�0ͣ\�2\�\�Zt��_�i5�)\�I�\�\�.\�4�\Zǔ\�$�d�l�a�G�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8�\'\�\'sd�\�<j�\\9cccؽ{7\��w෿�-��_�����_�\�E/r�1ݵ��|s\�\�Wa�G�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�O�+97c����\�Ȉl��E�Tky�\�_�իW\��\�Ǒ#Gp\�\�\�R!k�T�E��\��R�%`Æ\r�Bػw/�\�݋s\�\�ɴ�\nY˥b-z�a\�f\�/\�.2�-[�\'N\�\���r�R)�\�iٕ��S\�\�\�����̘֒S�\�p��\�\���=~��\�\�\�G\�\�?�\�\�Z�\��\�Z�X�k\�+\�Z*++q\�m�\�\�o;����\��\�\��\�J-\�l�^$֢W,��>}ڵ\�􎍍A\�\�\�6g\00\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8�\'\�\'sd�\�<jSNMM\r\��\�wc͚5�\���o<�\��x\�\�\\c\�D-N�O\�\�v�y\�8�\'\�\'sd�\�<jS��\�9�]�i5�)\�I�\�\�.\�4�\Zǔ\�$�d�l�a�G�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�\�ĉؾ};\����\�/}):�w��ݮ��a�g\�\"k���_�i5�)\�I�\�\�.\�4�\Zǔ\�$�d�l�a�G�c\�q�}2G�\�0ͣ\�1\�8\�>ٯ\�/�͐`0��o�\�}\�{\0_�\�W�o|�DB���cǎ\�;\��G?�Q\�\�\�\�\���x׻\�%ӈ\�.2i֬^�\Z6l@mm->��z�XL�\�+?�\�\��\�O~۶m\�[\��8p\0k׮�iDE��L�q˗/\�{\��lذ\�d{�\�ſ���\�\�ٳ2��h\��\��͛7cǎ��\��\��b͚52��hq�I3��\�\'\"���\��\�?�\�\�n\�v\�m�����\�7�Q�.2iF�\�U�\�{\��^>o��\�\"=�\�#��\�[�o|mmmضm�\���_2��hx���v�\�\�J\�3�\�\�ʐN�s.<�~?R�\�ǵS�\��\�\��attTvea-zs��k����\�q\�\r7\�ԩSx�\�G��H�\�H-J1�^֢\�Z�X�\�|�\��\0\Z�_�===�\�\�~�\�?��\�\�Mw-�Dµ�Q\�\�ؗ,Y�S�N\�\�Y�Z􊽖׾��X�z5^�\�g6U��\�r����\�\�Z�X�k\�c-z��w��\�ذa�w\�^<�\�2u\�\�\�̧Z�u��/Z�H�Ȭ��2>ee��E*��]���V�v\�Z��~���\����+\�L\��ӟ�Tve�x<\��l(�Z�~?|>Ry6w-4]-�����\�=\�\�ڜ^)\��k\�\�Z̵�{qd-\�\�\��z�y�����\�T\�Zxܝ���3g\�p��������x�\�_.�\�\"\\v\�e�x<9�@��o\�>\�ر�;k)�Zxܥb\�\�n�|�\���\�M�?�\�O\\`\�S\\dQ�q�IDDDD\�E\�|�\"�L\"\�\�j�đLF\�j\�-\�w�aA4�DRE�S�i\"�\�a\�q���dѰ�\�$�\��\�@\�q\�q8Gw�\�9<�y����\�y ��\0���hl\�\���#�\Z\�d�^S\�ȳ��Y���d+\�@ `E\�\�:t\�,\�|д\0�\�đ8�\�m�\�\�Г\�d��\�HL��A4م��-�\�p`\�\0\�vEA˗&&?/\�E\�\"s��\"6�}H��\�a�c�\�\�k�U�t\'\�V:\�D\�v��g(\'>O��48>%�n܂>\�a]\�\�\�Ukl��\�9���Bw\�1G8j\�7u#\�F�a;\�>���DDE\�*cً\�p+\�vbhi�\�WW�\�q\�\�Gwc�\'M\�\�	����8Ԃꍎ���Qh@;jP���p]uRg7#����X\�\�xO(\�|D����V��\�q�\�Yٜ\����N�s\�E\��x\��z166f\�Q�(�\�d-�<�V�X!�\��\�ہ�Pw����M݈o�\�zl�lGW\�ִ\���ڴ\�օ����b�\'���h�>�u�v��H\�2��\�fL\�\"�Ɨ�3�\�\�9�D}�ni\��\��g�eϷ[Pݷ�mvݙ\�\0\ZErs\rb4�U\�\�h�\��\��\�Ca߾}�]E�>b-\�XK\�\�<\�YǴX�\�Z�\��\�\��p�2\�\��\�q\�clQ�\nQ\�\n\�q.�h\�h��\�\�\�`�;���5\�\Z�\�[��zM\��.4�-\�\�@\�qU7_\�\�q7[�Z][q�L[\�\�צ$[�\�p Љ\��\��\�-��\��\��\�U����\��Zȍ\�P\�\�X���H\��#\�_o�7��� �\��y\��+{�9q\�;ޒDkm�\�\�\��ra�\�>��\�E\�\�މ����s�����ec-�UK\�w]Աk\�\�{\�\n븵۱1�r]ւ\�:�\�v5N�\�Z(Z-\�c�C�q\�Z�f.\�v\"���w�垯��-_-\�\'s>�ξ���8F\0�i\�N@�~�R	\��=\�}:ioÎ\�֟\�3t����p+\Z1�����56\ra�}Y\�5�-R_�X�}XkZ�:\�\��֭��%�\�^Q�w�h!\"�E\�\�t/���֭������돎K\��Oh\�\�\�\�\�\�_����9n��H&\�ѯ\�?���\�\�z\��[�J\�q~��\��\�Ef��X�\�0�\0�7Va��}⠱�8F��}�\0B=\�\�x�\0�w��+\�Y_\�i\�\���\���YG����ayư�\'\�帧M݈o�@\�V\�\�L4�\�\r\�Dl\�r\�ّ�/&5u#��7�[sY�G\�D@l8��z\�}��+\�ץ�\�ND4��\�pX�UG;ў9\�\�0��A�:+��ui:\�\�\�í�1��/]����\�\�p8���#8��ckhE�:\�3��\�\�������ȍ�̒�}\��A:��뀣ыv4t��q�u3w\�\���i\�C#��I$�Ua$a/�\�\r\�<i�\�\�Z\�].i_@\'Z\'nb\�U�\�O{W*6�\�[���\�\�D\�R;W65��8~2h׶u�uVS|�\�ݸe\�g��@Gi\�\'DDs\�\��\�R�\�\�\�\�:Ӌ歎\�\�f\������\�j\��zĀ�\�s�\�q��!��/��n<���]vN=`\�~�}�hr�I�\'\�6\�\r����ec-�U��T�x\�͖�ޓIDDDD3��L\"\"\"\"*8Oee��r��%Kp\�\�)\�<+f�^��b�o\�>|�_\�ѣGeפ\�\��(֢7_k\�q����S3<<\�\\>::\n]�\�iW�3\0L*\'�J�\�U�\�i\0p�˘\�<�əL-D\�*\�\�\�G�]\�d\�Lkq\�\\���X\�z�\��H�˘\�<�\�\�U��7�JA\�\�\�6g\0�\�ؘ�]��)4�N��d�l�1���\\�\�b|\�v�E��b�\��[�\�#\�.c�k\�\�=�DDDDTp\\dQ�q�L�\�\�ǭ�ފ\�|\�3\�\�\�\�D����\n�|\�+�}���\�XK\�\�򲗽����\�\�.���*,^���\�\�xܵ\�E�O&�6�ߏ����7���/\�/��/e7Ѭ����\�?�q����`gc-�S˒%K�_��_<\�RQ���@kk+>��\��k\�W����[iP1\�\'���Ҫ�\�]*F<\�f\�W�n�\��z�Ѕ\�\�q�9�1GL��|�*L�qL9N�O�CT�\�kV�ve�\�{D�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8�\'٧\�!*F�5+_��]�\�=�\�1\�8\�>�#\�e�\�Q\�r�d�\�Wrn\�^QQ���\�<+f�~��bT�M�g�}�kћ���Kň\�ݩ\�m\�\�Y�x�v��l\�2�8qB6g���#�Je6\�Q�Us�z�(++3\�`�k\����Ѿ}�\�\�ѡ�lS�\�#SXKN�w��\�f�\��\�ӮE�wll�w�9�1\�I�\�\�.\�4�\Zǔ\�$�t9D\�H�f\�kW�\�0�G\�8�\'\�\'sd�\�<jS��\�9�]�i5�)\�I�\�\�.\�4�\Zǔ\�$�d�l�a�G�c\�q�}��b$_��+\�e�\�#jS��\�9�]�i5�)\�I�\�~E�����\�p�YM݈\'�H&O\�\�d\�M2A	�;�D4,\�#��~Nז-\�G2�tG�!�LDTJx\�%*z\\d@����N˰\"P�\��2c���O��F�����/\�:֟��\�+���J��Dŏ�\�I�\�}��km�mE�硬O��\��r\�=�3��\�:�L\"y�\�\�At�eS\�잸f�\�a\�|M݈\'���O\�=Q���:�>��d�ED4[x\�%�۸ȼT\��J\0���\��T�9\�G+:\�O��Y�=\�L�g;\Zч�@\0�~8>=��A�wc5�7\�V�����ֈ֧�~�\0�h�\�G @\�!�q[7B\�(�VXuZз�UP\'\"*<\�\�	^�\�]x<W�3`m^����|\0\0�\�\�\�S�6\�\�2f��l�z[k��͹>�\�TZ���O���Au�uvo\�V�8z\�:���\���K\�G����X�u�\�\��wo\�\0�*�VT\0�Ft%�H&�\�j\����\�z�\��H�\�`-����d\�q��G�\�o1��d��\�E\�[VV]�|>W�3`O$\�U�	��\�t�\n�\�2L���l�h��\�\����f��l�Z\�O\�\�\�d\�4iG�`\r\�\�\�\�\�П\���\�o\�\Zup�b�\��[�\�#\�.\�4Ok\��ZK6w�x\�z�\��H�\�0\�SV�Zt�\�ϟ�.R���\�\00::\�jW�6\�pႫO\�\�\�(\0�\�e\�d-�N ��\�g\��I\�E�8x4�\�\�uַ\��yo6����>\����\�\\�� \�\Z���\�:C\�}v�]o_R�\� L\�ͼ\\�\�b|\�v�E�B\�q�\n-\�\�\�G�]\�tע��VA\Z\�kh\��\�ԡwc5:k\�j_��8Ԓ�����\�z\�l3�\�\0�b\�K6��ۑL&ѵ\�\�ڌ\�p�u�\�.��\�\�\�I�1 \"�N<\�\�m�E�i+YUU���!ٜ�`����\"�J\�.����?�k\'xu\�5\�\nX�\�ZJ\��fM݈\�@���:�h�\�\�A��þ}��c\�\�\�͊�}\�Z��s-<\�R1\�q7[�ZΜ9\�~�d֟�4��H\�ju:.\�Ѵ\�q�ȅ�\�Rn\�\�(ߎ�\0?MMw�\\�\�$\"\"\"��\�\"�\n�]\����X1�\�\�%�y�\�]��\�Ef���\�\�7\"�\0����]����\�\�%���\�]�\�穭�\�~�|\�8{��l\����H�\�\��8<�^/\�\�ƌ9>�/\�7����\�G��+d7\"���\�\�\�[�\"�\�\�m-q\�Y�\�d�\"��\'VX}-�\�tǻP�p\0\r\��\�֓0C��\"�s����\�\\\�vlɱ\�\�D^Cؚw�p�����c?\�\�1th�kk��P\��z\�\�s�ao\�M��\�C=�}��appPv\����dc-�sx\�\�q�X�-_-����o�s#[��4r\�\�\�\']�XD�\�1��\ZU[�})f=�6m�M��V����\�(��+2�\�v�d\��\"Yߏ��vQ[+j\�Y�Ǟ�\�*t\�2d\�!ǡ���4���Ҫ�\�]w���\��\�\�-��l6��AtW6\�;\�i��D4g�KT*�\�4��g\�6u#��G�E\�g\�g\�\�\\\�\�.Q�\�\"s�\\�3t��\�l\�{�ƌ\�\�%���\�]�\�\�E\�$\�\�3tC\�\�ֈ`\�2�\�0��KD���Ds��c\�w��\�y�\�Н\�xz6\�RZ��Kň\�\�l�j\�\�>C��hf�K\�⩬�Ԟ\�\\�d	N�:%�g\�L\�R2����\�۷_�\�q�\�Q\�5i3�>ʇ�\�\�\�Zxܥb\�\�\�\��\�d���B\�t\�\�\�\0�\�I�R�v\�t\Z\0\\\�2&3\�dr&SQ�\���-\���l�1�y&�\�Z\�1k!*V�^�\��>�\�2&3\�drrբ\�M�R\�\�����\�\0066\�jW��ק\�iW�̑\�2f��b�\��[�\�#\�.��\�c�\�BT�r�~��}$\�eLw-:�\'�����\n��L\"\"\"\"*8.2�����\�O�\�\��#\n\���<n�\�\�M4k�/_���ۿ\�\�?�q\�\�fc-�SKUU���\��KEe��\�X�~=>��\��k\�W�n�L.2m~��\�z+>�\�O\�3���\�&�5/�\��׽�\�\�x����ҩ\�e/{���\��KE\�\�/9^�җⳟ�,���|�h��/\�.2�-[�\'N\�\���r�R�\�W\�uT1�x�^���s0õp�6*F��\�CGG��`W�\�#SXKN�w��\�f�\��\�\�\�Ef�\�\�+**022\"�g\�L\��Bl\n<�\�|X�\�|��\�]*F<\�N�n3v�ɴ�53~�vc-zs�w��\�f�Ew&\�;66]����ڜ��\�$�d�l�a�G�c\�q�}��b$_��+\�e�\�#jS��\�9�]�i5�)\�I�\�\�.\�4�\Zǔ\�$�d�l�a�G�c\�q�}2G�\�0ͣ\�1\�8\�>]Q1��Y�ڕ\�2L\�5�)\�I�\�\�.\�4�\Zǔ\�$�d�\�-������\�\�$\"\"\"��\�\"sVEM\�\�\� E2ED�LF8�d��I�\�{B4�DRѰ3�\�D\���\"\�:?������(.2gS\�rTȶ�đ\�\\#Z#�\�2�-ߍ�@\0�@\0���\�C��\�l\�\�@\�6q�\�\�>���[���r\�\"s�\"�s}\��;�D���\�\'C�-�L\"y\���\�4\�o}r�{[#��\�qp�?l\�8>\r�z\�O���\�1^�\�N���y;��\�P\�\��z\�7�7�ա�q\�\'�\�ak�PO\�\�\��\�\�\�<Z�\�0\�Oϓ<K0\����\��}�\'���\�]y\�\�q�\��\�\�.<��\���6/\�U�|>\0�\�\�s���z�5�l�1��\\�����@\0-��ټ\�jb��GDw\�a`��ɱ\�PZנykH�o�:\�\0����F8���#\�X\�#k���\�F\�P�\0�\���n@�FyHa\�J`\�I\�\�� X\�\0\�\�&0\�g�S[g�}��ն\"\Z���\�>:1�v{\�\��\�j\�#��\��;\�\�eJ�\�o:\�\'�0JU�\�o1��d�֢��Z\�\�\�q�\�\�\�\��[�\�#\�.c�k\�񖕕A>�\�\�\�\�\�vjB���#]��e�\�<e�%\�\�\'\�\�Z�f���8!q� z\�7:8���CH@]�	�q���]k��AP��?l�w\��@ZQ�\��v��B]p\�`\�\�s��S��\��\�\�N�8x�kY���\0@�~L̿\"��\� P\�j�mE\r�\�\�\��{/]>Ń\�\�\�\nN���\�\\밮\�?U\�z�\��H�\�0\�S\�ZrF�֒�\�]@\�\�qw\�\�z�\��H�\�0\�SV�Zt�\�ϟ�.R���\�\00::\�jW�6\�pႫO\�\�\�(\0�\�e\�d-\�z\�\\m}j\�b�\'8�\'\�Ɉٟ�UL�\�\�\�\0V�C���\�&	������L�\��	�\�g(�����+\�\�\�G�]k\�\�|�%��&<\�ά\\�\�b|\�v\�]�Υ]��\�\�#��z��x�\'\��b�ώ8>}GP_����O��zy��\�P撈��f8Y��+1q\�p\��l/b\�	׶fڣ\�o)^W�\�\�\�yV\ZS�(Dc�}N\�R�!JD��\�\�ə\��<\�\�Tq�9I\�k.\�[x\�h\�\��\�/ی������cD܀\�n�\�%�/�TjAC�\�[\'ƫG�\�6�K\"y��� \�%\0HT`��<3؉�0л�\Z��5�.+=R_�X�}�\�Ahr����ںOȺlS��M\�w���.\r��<\�\�\�\�Y�h��\�\�UUU\Z\Z�\�,�\�\�(R��\�\�G\�3.s=nH]\�\�u�U�\�ZJ��D\�˭��\�r�Nb�pK\�L�\'���h\��s&7O.�>iڷov\�ء}�n1��XK6\�b��\�\�K=\�Mn�\\.}�\�\�\�n�|��9s\��\��?Q	���خ�y\�b\�l\�ZÁK�\�\'r�ռeGN�����x�K�\�d\�J�5\�e�D����V-<\�R1\�q7[�Zx&�����f�DDDDTp�\�\�Z\�\��\�\�ٳ�9\�\��#�Nc|\\�\��x<�z�3\��|���f���\�G��+d�4� �\\��M\�h�.�\�f��b�qG��eȺI;u<?7��M�}\�\�Q\�W�\n#k\�\�|VEF�\�R�ə[�\'nm�,%�.�\��n\�[��zM�\�Z\��.4\�?4q�{�{衇�o\�>ʮ�|��l�%w��<\�+w�\�epp\�u���d\�f\�ޠ�n\�w\�a�`�\�hU\��\� 3b������ �=\�4�<U��\Zꉣ�\�\��c6u#��\n.\�w<\�xoP6\�RZ��;�xܽX<\�f\�W\�ɼ�ÎMo�X\�΋�t#���e=\�\�~�\�a{����~k[\�9�A�_[�a;Ǳip�\'n��\�\�j���v\"\�\�\�xCo߀�x5\0���\�o6u#\�\�[-rؚ+\�G�p��\�c\�\�5\��?�h2�=v<�l^\�\��YG\�\��-\�\�+\��t-�������\�\�\r��4�p�Y 5+�-�\0Z%P�y;�5�@G\�~jB\�]u�\�\�r���kм�	$зU�j��\0�NĂ�h\r[�z�O\�V�\�\�.\�`���/֯��\Z\�\�G;BX�zRf8\�?��\�\�)\"���xF/j묿O�ڈ7\Z�?Ţ\�~�X\'F\�n\�&��?�`�U�D�\0Dce������A8j\�\� hA\�R�KC���ۻ�zҗb\n7?\�wyܥ\�\�E�\�\�\'\�\�Z�fs\�O�	����ώ\0	�\�	OY�h���A4\�~�km\��\�.��\�\��\�¡@\�M؎�A���C�N�\��5O�Po\�5\�\0jP�q\�3fO�hZ�\n�w\0����t{�!\�T�\�d+j0�I�#f�j*��\�*`\�\�\�e�\�޾$�U\�\�!؈�dɤu�OM��\r�\��\� ��ˌ<9���\n�\�]�\�\���\�\\�E�Q/���O���\�\rځ@`ҟز\�\�O\�*�\���PO\��~�x\�Oo\�\0�r\"�u�}�6I؟\�UL��Ҏ��\Zԇ#��Uz�A�	ގ�7�O\�l\�ODn<\��{��\�L\�\"s&\�?�\�`��I<\�Ϻ�Ǥ�\�ǧ\�\�k���/b 1�	6R?q\�&\�\�vlo\��2�d�7\��\�:�_��K6�{�g{N ��5\�M\�wʬ���e=j2g\r\08>��\Z\�Lٿ����!\�L\�ę��/M�/K\�P����\��Sa�{<\�R~\\dNR��K�f^;\Z6�k�\�\�6#ַ\r�ǈ�\�%\�`\�Kd_�8Ԃ�p/��N�W��MS7��\r\"h�[E\�yI&���\�d\0�\n�W�g;\��\��\��uM\�p��\'i\�K&��\�\�\��{�\�\r\�}:�\�\�&\';\'>�7�C�]�\�ODӂ\�]ws\�Os����R��ђ%Kp\�\�)\�<+f��\�JcFi�\�ЈNb��\�>f���u�Q���AwO͓=���� �l��w\\h�[i\�`���o\�>|�_\�ѣGeפ\�\��(֢7_k\�q�\�ݩ\�?xܝ�\�\�a�F���\�E:�v�9��rR���]E:�\0W��\�\�3��\�\�R�\�\�y�\�s~ڴ.E�\�\�p`�*��r�y\�\�$ErW#p��\�\�j\�\���輘S!\�A�^�\��>�\�2&3\�drX�;\�b-��\�]�B\�?�r�~��}$\�eLf�\�\�\�E���\�feS`�I\��\�XKi\�\�\�.#w�嫅��ь\�\"�����\n��L\"\"\"\"*8.2�����\�\�$\"\"\"���z�^\�\�\��ڜ��#&\�F�~�y\�8�\'٧\�!*F�5+_��]�\�=�\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8�\'\�\'sd�\�<jS��\�\�\�#����]\�.\��Q\�r�d�̑\�2L�qL9N�O�+97c����\�Ȉl�3Y�ҠbT�M�g�}�kћ���Kň\�ݩ\�m\�\�Y�x�v��l\�2�8qB6g���#�J7\�U�)\�\��zQVVf\��\��}�����C�_[1��L9`-9\�\�Zxܥb\�㮛��ӧO��ޱ�1\�b||\�\�\�\0\�\'\�\'sd�\�<jS��\�\�\�#����]\�.\��Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8�\'\�\'sd�\�<jS��\�9�]�i5�)\�I�\�r���|\�\�׮l�az��qL9N�O\�\�v�y\�8�\'\�\'��Et\"\"\"\"�K�E&�DDDDTp\\dQ�q�IDDDD\����Ѕ\�\�q�9�\�\�e�\n�\�\0��|�>j�N\�.c&k!*V�^�\��>�\�2X�>\�k-D\�*\�\�\�G�]\�tע�s3�%K�\�ԩS�yV\�d-ܯ��Q!6�\��Q>�Eo�\�\�\�.#w�F���E���̪�*\r\r\�\�`tt�TJv�jXmڙk�$�ߏ��2�?^ve�\�Zx��b�o\�>\�رC�)p1��XK6\�b��\�]*F<\�f\�W˙3g\\�L^� \"\"\"��\�\"�����\n��L\"\"\"\"*8.2�����\�\�$\"\"\"��\�\"�����\n��L\"\"\"\"*8Omm�v�̅\�\�ٳ�9\�\��#�Nc|\\�\��x<�z�3\��|��{2)3Y\�#�<�+V\�n�Y�\�Ca߾}�]E�>b-\�XK\�w�X�-_-����}2����S1\��\�XKi\�\�\�.#w�嫅��ь\�\"�����\n��L\"\"\"\"*8.2�����\�\�$\"\"\"��\�\"�����\n\�SYY�\�\�hɒ%8u\�l�3Y�Ҡb�o\�>|�_\�ѣGeפ\�\��(֢7_k\�q����S3<<\�\�\�\���\�\�\�J\�挲�2�\�i\�^IJYYR��v\�N\�{.�|>���ʮ,3Y\�O�S\�ܹSvͪU�V\�_�dWQ��XK6\�b��\�]*F<jI$�E����<<66W]u~�߸\�U�bR���O\���1::�)Z�ڥ�O���\�3YK�MH����\Z�\�es�\�\�\0\���w\����9�\�x��\�sa-zS�e\�ҥ��\��\�\�Z$U\�s\�=���!�8q\"\�k��\�G�%;X���b?\�.X�\0��\��\�wx\�_8��8\��\�ũk\�q7;�\�r��y\\y\�UٿK>�ǒ�������\�/Y�(�Eo*�\\{\��\�w���z��ǁY�E���\'֢7���\�_�%>�\�\�\�E/z���q\�5\�\�Z-\�l�^�٨\�\�oķ��m�6+�\�2�j\�.҆\r����8t\�\�9���\Z\0�\����6m�\�D4O]v\�e�뮻p\�}����\n�\��g\�hfuvv\�\�_�2�\�كU�V\�n*\\d\Z\\{\�\�\�\���>�)���/ď�c�Bsܫ^�*\\q\�x�^��~�������BD�\�\r7܀\�|\�;���\�q�\�W�%\�\�<��\�\�9x� \�\�4n�\�&\�۷�w\�\�ʕ+e\Z\�2.2sx\��އo�\�X�v-�� \0\�瞓i4ǽ�\�o\��\�k��۶mÍ7ޘ�CD�Ǜ\��&\�ݻ˖-˺W;\�%D�ǎ\�ٳg�̛o�����׼F�\�,\�\"S\��\��>�mۖ��88T\Z�.]\n\����;w>��\�?����Z�\�<���\���~�\�\�\�\0\���L�Yt\�\�1\\~�\���\�ٳg�H$p\�e��P�z�^\�\�\��ڜ��lw�;&\�F�~�y\�8�\'\�\'s�^/zzz�я~;v\����0~�\�\�w��Ν;g�G�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�q<^��W���\�=�����㳟�,\��\�����\��\�7�s�\�\�\�\�7W�~�y\�8�\'\�\'sd�\�<jS��\�9�]�i5�)\�I�\�\�.\�4�\Zǔ\�$�d�l�a�G�c\�q�}2G�\�0ͣ\�1\�8\�>��\�\������g�y�W�\�\��\�\�\�w��]\�gM�qL9N�O\�\�v�y\�8�\'\�\'sd�\�<jS��\�9\�\�j;�ӧO\�\�G\�\�ի�W�W�\�o\��Y9N�k\��y\�8�\'\�\'sd�\�<jS��\��J\�\�\�+**2�\�f\�l\�r\�e�\�\�[o�\�\�\�\��F\�p\�\r�\�?�x<>\�\�2��\\\�b-\����\��\�r^�җ\�n@8�i�d��\�֢\�Z�\�{-��ԧ�H$p���\�S��\��ַb͚5�RK.󽖮�.�\�-o�>���\�o\���\��O��O�RK.�\�f\�/\�.2�-[�\'N\�\���r�R)�\�iٕ��Ꞌ\�\�EYY�1�T˛\��&��\�Dww7Ο?�\�|\�;����;\�b��%�\���\�2Wky�_�_�\�Wx\�+^�\�۷c˖-8v\�جԒk\�c-z�Eo*�\�\�\�\���<\Z]_��\�ZL\�{-w\�}7\���7\�\rox\�\�\��կ~===��<\�\�2��\\���ӧO��\�1͆�cccw�9�F��\�ٯ\�>�#\�e�\�Q\�r�d�\�\�\�ŋQWW�\�{O<��|�I�\�\ro�����qL9N�O\�\�v�y\�8�\'\�\'sd�\�<jS��\�9�]�i5�\�9u\�\�\�\��\�SO\�駟Ɗ+�\�+_���Ԣ\'\�\'sd�\�<jS��\�9�]�i5�)\�I�\�\�.\�4�\Zǔ\�$�d�l�a�G�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�\�\��\��~|�\�_\�{?@g�\�Q\�r�d�̑\�2L�qL9N�O\�\�v�y\�8�\'\�\'sԟ?�\��o|#\�\�\�p\�\�\�y\��\�\'?���\�%���\���\\a�G�c\�q�}2G�\�0ͣ\�1\�8\�>ٯ\�/�\�s�W�\���\�g\�L�*\rǎõ\�^+��hy\�[ނ��\�x�\�e��\�[����\�\�\���?�\��=\\d\n\�^{-V�Z�#G�\�\�g��\�T;�W�\�X�p�\�\"�y\��\0��\�/\�f�#��կ\��\�\��\�G>\"�hp�)�^�\Z\�dG��]T\�;��\��x�\�\"�y\�\�x~��\�\�\���\�9\�_�\��\�7\�/��/e\�0.2^��\�a�\�\�x��\�q\�\�\�M%ndd$s6��\��ǃ\�n�\r�w\�]4ǜ?w\�y\'\�\��\�%/�\�4��ȴ-\\�uuu�я~ĳ��\�\�O?\�E&\�<�������x\�\'d\�AG�\�\�ݻq\�w\�.�A�+��\"\�\�l�y\�W\�ܹs�v>�ȳq�\�ޜS�\�ȗ3��\�Mo\��\�_�o~����\�\�W1�L6��\�\�Rj)//Ǎ7ވ\'�xgϞu�˘\�Z��o�\�\�}�}̧Z^��ᮻ\�B8\��\�?\�\�w\�t\�2�֢UK,Û\��fTWW\�\'�\��\�F-�]E)\�r\�\�9\\y\�Upʹ��%Kp\�\�)\�<+����K�\�\�[o\�SO=���\�;\�t\�2�E\�RjY�p!�n݊��\�x�\�Ge��]J-�\�Z�X�\�|�\�#�R�v\�\�)�\\����`-z\�Z��\�*|\�+_��;�\�}O�N�b��L\�f\�-\�.2���044$�3,X�\�\�Ѭ\����Y!�Ϙ�\�\�GYYΟ?/��Lw-\�z׻�\�W�\Z��\�ñc\�dw�\�E�{�<�\�\���\��\�?�_��g��b���\�\�T*�\\{\�سgn�\�&�?~VkQ�\����B-ox\�p\�w\�o�\�o�_�jVk�J��3gθ�\�y\�y\�կ~u\�\�>\�9�4�;v̵);�&�e�z>9��G}_�\�\�x\�,�׋L�׋U�Vahh��\�cǎ\�\�/9�\0DT\�V�Z�\�\�j|\�+_�]Tb\��~�\�i|\�C�]4�\��\"s�\�ո��\�q\�\������\�4O;v\�>�,^��\�.\"*!\�x}~���?�w�\�]�\�dM�y�\�\\�hQ\�2�ѣGe7\�s\�<�\�d������BYY�\�\��MvQ�����O�\��\�\�>�E�\�n��v��j\�*,^��{b��Zd��D��g1\�\�}\�{�\�7��O|\������\\d�\�e/\�\�իq\�\�<�\�S��\�<���\�\n�\�$*A\�}\�{q��q�\�?�]4tuu\��\�/\�\�\�.���\�\�\"sժU�\���\�\\v\0~��_��D%\�/x\�b>�\�\�\�[o\�\�իe����V�O\�q�\�Yٜ\����N�1>���̎�ccc\��ϗsO&���TWW#\n\�;\��N\�\"s6j1\����\�\�oDUUv\�\�%Sf��b����l�%�<\�XKss3.\\�/|\�����Ŕ\�Z\�\n]\�\r7܀��\�}����{�;w.\�?��\�+���ɜW��{<lܸ\0�g\�\\�p!�3ӵ\�dS�TWW\�\��\�\�p\�w`dd$+g�k)�\�k\�\�Z\�N-/zы���k׮\�{�� �J\��\�PQQ���\��٪Eg.\�2\�7c_�j^��W\�ȑ#YL\"�cǎ\�ܹs�dNT\"n��v|�\�_v-0i���\�{p뭷\�.*�y�\��X�j�9���A\�M\�r�\�YޗIT\"^�\�\�\rox\�\�$�;\��6m\�\�^�:\�E�h\�,2\�\�\�`�~ه���L�\�p\�m�a�\�\��]4\�?~w\�y\'\�\�\\~�岛.��Xd�ٟ�V�\\�\���?�#��rR�L>��h\�z\�[ނ`0����\�.\"\0�7��M<�\�c�ԧ>%�\�̋E\�U�p��i�Ť);v\��y\�\\{\���\�\�o��\�\'��>��\�cٲe�\�[d]��_d\�\�\�aժU�o~�\�Md4>>\�K\�Ds\�;\��N�\�w�\��\�\�.\"�;\��\�G�׼Fv\�E�TVVj�0Z�d	N�:%�g\�\�\�r\�W`Æ\r8w\��\�ݫ�\��T]l-Ӂ�\���n�\�x\�;�m۶��\�&�е\\\n֢\�Z�J��ǃ��A$���\�\�r��L֢w��466���	�\�v\�%�.��B�\�Z���][�,X���\��\�w����|H�\�H�Ӯ>gN*�ʙ{ߥ\�\�QW�3.��n���C�!�L\�j-2����Xk�\���o�O=�N�<��Y�E�����9�E�3�j�\�\�p��y\�ݻw\�k�9�\�\�R\�\��s��\�\��F|\�{\�s��\�`-*�~/*\'W-\�ΝÕW]\'o*��.\�\�\�]m\�\0���1W��1�/�N�]}2G�˸�Z***�r\�J<�\�c�\�O:��8c�/\�`-��\�{O?�4^����r\�\�\�(t-�`-\�~g�l��Z�1\�k�ꪫ����\���\�\�\�\�\�Ka-���\��g�gx\�;\�\�\�W93UK1�^L�\�\�=��W�\�\�\��9\"���\�駟\�}�Ds\�\�ߎpG�h����q\�w\�U�z�\�I*\�E\�k^�\Z�^�\ZG����\�&�2�\���Ų���̵\�^��n���\�%�\�㙅&]��[d�|>�Z�\n��\�/�e̱c\���?��g3�\�|\��򗿌\������hJz{{��\�O\����\�I(�E\�\�ի�\�׾G��ٳge7\�E��\�ϭ��\�U�V�����bR�|�ӟ\�k_�Z\�t\�M���(�Ef �\�ի��\�\�?��\�&�$O?�47e\'*r\�,&Q��R)|�ӟƧ>�)>�m��^���x<�6g�ރL�;��h#_�\n\�<j�ǃ׿��p�\�+_��\�\�\"۝��\�\�ׯ\�4�\Zǔ\�$�d�l�a�G�c\�q�}2G�\�0ͣ\�1\�89۟}�Y�\��\�Zhʟ�a�\�{	�\�rd�\�<jS��\�9�]�i5�)\�I�\�\�.\�4�\Zǔ\�$�d�l�a�G�c\�q�}2G�\�0ͣ\�1\�8\�>�#\�e�\�Q\�x<�]��]v���\\��\�\�ׯb��\�vg�����0ͣ\�1\�8\�>�#\�e�\�Q\�r�d�̑\�2L�qL9N�\�\'?�	v\�܉;\�#+G��\�<jS��\�9�]�i5�)\�I�\�~%\�f\��ͳb2��\�e/Æ\r�\�O\��\���\�.�\�\�2SX�\�t\�\��x���\0\��\�we�\�t\�r1X�kћ��\�۷_�\��裏ʮ��l-3��\�Mg-[�n\��\�?�;v\�.�\�e���\�f\�o�\�\�Efyy9.\\� �3�^/\�\�\�1>��q�\�Q�*\�x<x<c&Y\�\�ŋq\�W\�\�\�\�\�d-\��{\�\�?��;w\�n�c�\�ݲ9�е\�\�\�bjY�l|>�?>\�(��{\�\�\�\�~�\�\�����\�8\�\�\�\'dsFyy9R����L\�\�S��|\�C\�ʕ+eWF1�^r)d-K�,�UW]�\'�|Rv3\\K1�^&�o@�1>��\�\�%/yIAk)�\�\�\�\�\����׽ǎ\�o�[m�\�t֢\�\��m\���w���\�L�\��\�r�6\�L�*}.Z�z5\0h?uy�^�ۋL]?��\�_�\��\�7\�K_���\�?\�\�y���\r;v\�\�.2�~?\�\�\�p��yٕ���\nCCC�9c��ͽ���ڽp\�B\�^�\��}c\��&i2�\�z\�\�u\�]x��\��\�s\�ɮyʹК\�\��\�wb�Ǳ\�E\�E�Jf�Inmmm@��Zd\�\r�mɒ%���?�;v\�\�?��\��\�ۗ��R\�\�T1-슩�\�Խ���\���뵫���\��,��\\>��Ϲ��;5�H\�ԩS\�ʈ��h�\�$��\�|\�3�dODD�GI/2#��H�\�f\"\"��o\0\�\�*\�Ef8�d2�y���ȉ�~iZִ;ڨ�EM&\r�\�nēQ�_AR\�d\�M�����\r��\n�;�D�\'$\�/\�81?3\�\"\0Cg �@ �@��\��\��Sk*�\�\rM1tV7�7�u^�z�������|���AihG\�j\��1��4\"8؏)�SӴ��2|>�\��\���\�7\�\�2<��\�0�n��\�n�:�%\\K\�_�\���\���ﵫ^�s_/��!�r�\�\�P\�z\�$pp��1�\�0%s�\�g>\�\�{B@8�\�Z\0���Y���u�+�D2�\���=�~v�|�\�{�\�(\��z����w�����6���v���:3b�\�G��G�\�\��n�B��FD\�6�Ϫ?��ΜD�gZ��\�\�?h\\g\�\��3wf�6�dv`�\�B�y�ʅ\�\�J\�d��KcDH�j\�o�\"�c���\�\"duV\�M\n5Ai��mmf-\�Ia\�\�H[\�>\�G�9s$m.�=�~\�4\�<\�!�\�}揮�\�\�z~�5\�ߖ\�H7-\�k\�\���\\V\��4�\"]�\�\�hN�,���\���{�\�tw\�N\�!\�̖\�l�u\�\��7�jo�_\�6�q\�V\�O��_\������+r_{os/�d��4g\��pf��`ז�w�l��p\�\�֕���]�;f�q\�./�\��\�]��ϝ�W���l���Qi\�f;�����Ѳ�\��\�/��\�\�\����H���z��xm-߳�\�]J�/]*_�޲\�>�h\�7�\���ͬ-���[��\��ݒּ-,�ص�V�k][�蚭�;g�?\�\�Q\�P]0[�����\�-\�i��\���\��\�\�\�Wϓ\���\�#\�\�����z=3���Ƹk2��Y�\�ɧH\�\�9�\'x����5\�=�*㮫��\�q�\�z=-\�\�F\�.Η?�\�}\�.�6mm\��\�_f�\�\�\�\�r�z�\�o�[fk\�\�p\�V�{�so�\�^2�^\�C\���J\���\�\�]���\��\�E[\�0����7�\�ͳf�k凣Kk�i��f�r\�\�{�lv�\�?�ɱb�~\�\�ܟ\�W��\��\�=[y�M���\��wӺ{�e6|\�s\�\�/��m\�\�X^�\�\��\nt�\��Z��m��-߷�g\0V�m%�����n\0�\�=\0\�Z\\۴֕��w\�/�_����-���\�4\�ϙe���zY�ť�n\�]�Ͽ�\�\�\�{Ʉz��9\�	\�[Y]�n뢽�\�\�G\�\�\�[Y�Mk\�ff.\�{�K\�ٓ\'w\��?\�W�Z���Ğ|v޾.\�\��kq@�\�l\�\�\�\�R�Qyz!b][-?\�ڋ�]�o&�ӹ^���\r\���I�2o٥{�(V�����\"�\�����句K67|�\n\�\��=[\�\�\�\�wln\�\�\��m\�\�\����W����}��jw�\��t�\�7wl�|\'��\�=\0U\�{�2�\����V�L�M{\�;:��݋\�\�ʦ}����\�w�9�x/yݽ\��\�Ǚ+�kcK���OW\�g��n��ʷ�\�/}/�麭�](\����\��|\�\n��M\�V�Ju\�.\�X5�r���|+�\�\�\�����ܽ�f����_\"���V�-;�G�^\��Hfo�K�U\�\��&@���z�wW�\�j��p����b\��p\�6/�z\�\�\r\�\�\0,<ybOn���n�\�%���]>\��wk�\�\�8\n�v�~��,�\�r\�a\�\�]�v9���]\0\0�\��L\0\0\0T��\�\'\�|`�N��/��BKV�լ(\n�\�O��\0�ꫯ\�\�/����\r-Y�V�z�>��\�\�ĉ�\�\�3M5\Z\r��\��xJ\�\�\�\�N\�3����\�{��\�?�\�0��q\�\�~h\�~�-�\�P��\�9dN�\�|�\�d\�(�N\�~��,|\'Gq�{��k�\�d\�(�C&�\0\0�r2\0\0P9�\0\0\0��L\0\0\0T�C&\0\0\0*\�!\0\0\0�\�y4\Z\r������)��1�QLMM�\\O\�\�\�\�l6\�\�G\�D1\�Laf\�l6G�)ҵ;n�\�	���_qT㮫��\�F��KGR�y�&\�ɜpEQ\�\�۷5mV\�<?��s���\��\�z\�-��\�Om}}]KV�\�\�u\��zZڧ\�n[�\�\��P�ٴ�`\�>�/i6�\�\��݇H\�\�r\�\�\rZ\�:\�0\�\���\�\�\�Ç�\\gϞ=�s2O�:��}\Z�F���V�Y�ѰZ�����(�J�Y|��egg\����H����P\�\�Y\�y�^\�a_�e}}\���\���_S�\�\�\�\�\�\�afc�\�~�ϸ9�\�k�n�x��\�U�^�e��1˸\���k�\�Ç�\�2\�\���2���\�\�\�\����s��<�*�f\�,>f�1��Y|\�\�c��&i��O�Z�\��}��GV\0\0\0\�\�!\0\0\0�\�	\0\0�\�q\�\0\0@劢(̋Z�6�\�\�\�\�4\�|^\�6q\�z�h��NԓӚ�h^#\�\'��䴦=�׈�I\�D=9�i�\�5�}\�:QONkڣy�h��NԓӚ�h^#\�\'��䴦=�׈�I\�D=9�i�\�5�}\�:QONkڣy�h��NԓӚ�h^#\�\'��䴦=�׈�I\�D=9�i�\�5�}\�:QONkڣy�h��NԓӚ�h^#\�\'��䴦=�׈�I\�D=9�i�\�5�}\�:QONkڣy�h��NԓӚ�h^#\�\'��䴦��\�n�\�\�.������-M�\�\�c���\�\�,>f�1��Y|\�i�N�3�\�\�ӧO��\�s\�΅a����~�>8���8EQX�\�{�Y\�b���\�\�,>f�1��Y|\�i�Ǐ�2����bwww$���\�|^O��=�׈�I\�D=9�i�\�5�}\�:QONkڣy�h��NԓӚ�h^#\�\'��䴦=�׈�I\�D=9�i�\�5�}\�:QONkڣy�h��NԓӚ�h^#\�\'��䴦=�׈�I\�D=9�i�\�5�}\�:QONkڣy�h��NԓӚ�h^#\�\'��䴦=�׈�I\�D=9�i�\�5�}\�:QONkڣy�h��NԓӚ�h^#\�\'��䴦=�׈�I\�D=9�i�\�5�}\�:QONkZO�\�\0\0�_�C&\0\0\0*\�!\0\0\0�\�	\0\0�\�q\�\0\0@\�j�V\�}�Q�ݶN��\�f�i��`\�o\�j5k4\Z\�\��mw\�\���z�n�^OK�0��Y|\�\�c���\�\�,>f��Y�\�\�\�#�\�>��̙3�\�\�#M�\�\�c���\�\�,>f�1��Y|\�i���0�7\�x\�=d�?\�<x�\�\�\�i\��z\�\���dV��\�C;ǝ���5�M\�\�\�\�\�>\�\�c���\�\�,>f�1��Y|\�i��O��2�N&\0\0\0*\�!\0\0\0�\�	\0\0�\�q\�\0\0@\�8d\0\0�r2\0\0P9�\0\0\0�\\\�\�s2O�8aϞ=\��P�Ѱ�`\�>�\�\�\'\�Ea;;;aO�^�L��Y|\�\�c���\�\�,>f�1�\�8Ͳ��1�L\�^bfI��Yr\�\�c���\�7I��0v\0\0\0�&8d\0\0�r2\0\0P9�\0\0\0��L\0\0\0T�C&\0\0\0*Wk�\�\�#�Μ9c�=\��K�,>f�1��Y|\�\�c���\�w�f\�t:#�0��Z-��\�n��\�\�hz�\�l\�`0p���4�M\���\�C;�|\�R�^�^���}�\�\�,>f�1��Y|\�\�c���\�,\�nw\�Y���Z\�\�\�1��\'O\�O?�4�O��\���#�4`�Ѱ^�7Z#=���_~�\��,~0�\�\����,~0�\�\���q�f\�\�޶ߝ<i9��	\0\0�\�q\�\0\0@\�8d\0\0�r2\0\0P9�\0\0\0�\\Q�yQ�\�Fry�Y\�#��qP=E�OZ\'\�\�iM{4�\�։zrZ\�\�kD��u���ִG�\Z\�>i��\'�5\�ѼF�OZ\'\�\�iM{4�\�։zrZ\�\�kD��u���ִG�\Z\�>i��\'�5\�ѼF�OZ\'\�\�iM{4�\�։zrZ\�\�kD��u���ִG�\Z\�>i��\'�5\�ѼF�OZ\'\�\�iM{4�\�։zrZ\�\�kD��u���ִG�\Z\�>i��\'�5\�ѼF�OZ\'\�\�iM{4�\�։zrZ\�z2�a쳳�����闂Y|\�\�c���\�\�,>f�1�\�8\�\��\�~��i��y\�\�9{�𡦇����\�\�\�`0\�\�\�\�Ԕ=�\\\�CEQX�\�{�Y\�b���\�\�,>f�1��Y|\�i�Ǐ�2}�f�\�\�ݑ\\f�䴦=�׈�I\�D=9�i�\�5�}\�:QONkڣy�h��NԓӚ�h^#\�\'��䴦=�׈�I\�D=9�i�\�5�}\�:QONkڣy�h��NԓӚ�h^#\�\'��䴦=�׈�I\�D=9�i�\�5�}\�:QONkڣy�h��NԓӚ�h^#\�\'��䴦=�׈�I\�D=9�i�\�5�}\�:QONkڣy�h��NԓӚ�h^#\�\'��䴦=�׈�I\�D=9�i�\�5�}\�:QONkZO�\�\0\0�_�C&\0\0\0*\�!\0\0\0�\�	\0\0�\�q\�\0\0@\�j�V\�}�Q�ݶN��\�f�i��`\�o\�j5k4\Z\�\��mw\�\���z�n�^OK�0��Y|\�\�c���\�\�,>f��Y�\�\�\�#�\�>��̙3�\�\�#M�\�\�c���\�\�,>f�1��Y|\�i���0��FV&Ac�\0\0\0\0IEND�B`�');
/*!40000 ALTER TABLE `negocio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `permiso`
--

DROP TABLE IF EXISTS `permiso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `permiso` (
  `idpermiso` int NOT NULL AUTO_INCREMENT,
  `idrol` int DEFAULT NULL,
  `nombremenu` varchar(45) NOT NULL,
  `fechacreacion` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`idpermiso`),
  KEY `idrol_idx` (`idrol`),
  CONSTRAINT `idrol` FOREIGN KEY (`idrol`) REFERENCES `rol` (`idrol`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `permiso`
--

LOCK TABLES `permiso` WRITE;
/*!40000 ALTER TABLE `permiso` DISABLE KEYS */;
INSERT INTO `permiso` VALUES (1,1,'menuusuario','2025-06-19 23:50:07'),(2,1,'menumantenedor','2025-06-19 23:50:07'),(3,1,'menuventas','2025-06-19 23:50:07'),(4,1,'menucompras','2025-06-19 23:50:07'),(5,1,'menuclientes','2025-06-19 23:50:07'),(6,1,'menuproveedores','2025-06-19 23:50:07'),(7,1,'menureportes','2025-06-19 23:50:07'),(8,1,'menuacercade','2025-06-19 23:50:07'),(9,1,'menuventas','2025-06-19 23:55:21'),(10,1,'menucompras','2025-06-19 23:55:21'),(11,1,'menuclientes','2025-06-19 23:55:21'),(12,1,'menuproveedores','2025-06-19 23:55:21'),(13,1,'menuacercade','2025-06-19 23:55:21'),(14,2,'menuventas','2025-06-20 00:44:37'),(15,2,'menucompras','2025-06-20 00:44:37'),(16,2,'menuclientes','2025-06-20 00:44:37'),(17,2,'menuproveedores','2025-06-20 00:44:37'),(18,2,'menuacercade','2025-06-20 00:44:37');
/*!40000 ALTER TABLE `permiso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `producto`
--

DROP TABLE IF EXISTS `producto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `producto` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `stock` int NOT NULL DEFAULT '0',
  `precioventa` decimal(10,2) NOT NULL,
  `categoria_id` int DEFAULT NULL,
  `preciocompra` decimal(10,2) NOT NULL,
  `descripcion` varchar(250) DEFAULT NULL,
  `fecharegistro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `estado` tinyint NOT NULL DEFAULT '1',
  `codigo` varchar(13) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `codigo_UNIQUE` (`codigo`),
  KEY `categoria_id` (`categoria_id`),
  CONSTRAINT `producto_ibfk_1` FOREIGN KEY (`categoria_id`) REFERENCES `categoria` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto`
--

LOCK TABLES `producto` WRITE;
/*!40000 ALTER TABLE `producto` DISABLE KEYS */;
INSERT INTO `producto` VALUES (2,'secco',30,1500.00,2,1200.00,'3 litros','2025-08-04 19:49:11',1,'10011010'),(3,'coca-cola',70,0.00,2,150000.00,'2.25 litros','2025-08-04 19:51:38',1,'11101101'),(4,'pan',26,1000.00,3,1100.00,'20 kilos','2025-08-04 19:57:39',1,'2002202'),(8,'Gaseosa',30,1400.00,2,1600.00,'1 litro','2025-10-08 00:55:54',1,'1010100'),(12,'yerba',20,1600.00,9,1400.00,'1 kg','2025-09-16 14:12:35',1,'21212121'),(15,'Pure de tomate',10,130.00,2,900.00,'nada','2025-10-08 19:34:26',1,'125125'),(22,'Masita diversion',5,25000.00,3,2000.00,'dwd','2025-10-07 19:40:01',1,'1241556'),(28,'Borrar',12,232222.00,3,124.20,'sfs','2025-10-07 22:58:13',1,'INT-1'),(29,'Borrar',12,232222.00,3,124.20,'sfs','2025-10-07 23:02:01',1,'INT-2'),(30,'Masita Terrabusi',9,250000.00,10,200000.00,'sfsf','2025-10-08 00:49:35',1,'124952525'),(31,'Sidra',16,2500.00,2,2000.00,'12','2025-10-08 00:22:34',1,'491915051051'),(35,'borrar',2,124.00,2,124.00,'121','2025-10-08 00:56:52',1,'INT-4'),(36,'borrwr',12,1242.00,2,212.00,'124','2025-10-08 00:57:30',1,'INT-5');
/*!40000 ALTER TABLE `producto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proveedor`
--

DROP TABLE IF EXISTS `proveedor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `proveedor` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `cuit` varchar(20) NOT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `direccion` varchar(200) DEFAULT NULL,
  `estado` tinyint NOT NULL DEFAULT '1',
  `fecharegistro` datetime NOT NULL,
  `email` varchar(60) DEFAULT NULL,
  `razonsocial` varchar(80) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `cuit` (`cuit`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proveedor`
--

LOCK TABLES `proveedor` WRITE;
/*!40000 ALTER TABLE `proveedor` DISABLE KEYS */;
INSERT INTO `proveedor` VALUES (3,'Distribuidora Norte','20-12345678-9','3624-555555','Av. Siempre Viva 123',1,'2025-09-23 08:35:45','contacto@norte.com','Distribuidora Norte SRL'),(4,'Arcor','00997733664','3644223344','ada',1,'2025-10-08 21:34:13','qwrqwr@gmail.com','');
/*!40000 ALTER TABLE `proveedor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `retiros`
--

DROP TABLE IF EXISTS `retiros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `retiros` (
  `id` int NOT NULL AUTO_INCREMENT,
  `empleado_id` int DEFAULT NULL,
  `monto` decimal(10,2) DEFAULT NULL,
  `fecha_hora` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `empleado_id` (`empleado_id`),
  CONSTRAINT `retiros_ibfk_1` FOREIGN KEY (`empleado_id`) REFERENCES `usuario` (`idusuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `retiros`
--

LOCK TABLES `retiros` WRITE;
/*!40000 ALTER TABLE `retiros` DISABLE KEYS */;
/*!40000 ALTER TABLE `retiros` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rol`
--

DROP TABLE IF EXISTS `rol`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rol` (
  `idrol` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `fecha_creacion` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`idrol`),
  UNIQUE KEY `nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rol`
--

LOCK TABLES `rol` WRITE;
/*!40000 ALTER TABLE `rol` DISABLE KEYS */;
INSERT INTO `rol` VALUES (1,'Administrador','2025-06-19 23:45:01'),(2,'Empleado','2025-06-19 23:53:21');
/*!40000 ALTER TABLE `rol` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subas_precios`
--

DROP TABLE IF EXISTS `subas_precios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subas_precios` (
  `id` int NOT NULL AUTO_INCREMENT,
  `tipo` enum('Proveedor','Categoria','Producto','Unidad') DEFAULT NULL,
  `referencia_id` int DEFAULT NULL,
  `porcentaje` decimal(5,2) DEFAULT NULL,
  `fecha_aplicacion` date DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subas_precios`
--

LOCK TABLES `subas_precios` WRITE;
/*!40000 ALTER TABLE `subas_precios` DISABLE KEYS */;
/*!40000 ALTER TABLE `subas_precios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `idusuario` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `apellido` varchar(100) NOT NULL,
  `dni` varchar(20) NOT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `rol_id` int DEFAULT NULL,
  `usuario_cuenta` varchar(45) NOT NULL,
  `contrasenia` varchar(45) NOT NULL,
  `email` varchar(60) NOT NULL,
  `estado` tinyint DEFAULT '1',
  PRIMARY KEY (`idusuario`),
  UNIQUE KEY `dni` (`dni`),
  KEY `rol_id` (`rol_id`),
  CONSTRAINT `usuario_ibfk_1` FOREIGN KEY (`rol_id`) REFERENCES `rol` (`idrol`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'Federicooo','Molina','38962453','3644657148',1,'FNMolina','123456789','fede.099molina@gmail.com',1),(2,'Hector','Ramirez','38862453','3644657148',2,'EliasR','123456789','fede.99molina@gmail.com',1),(12,'Prueba','Prueba','12312356','3644332255',1,'admin','admin','prueba@gmail.com',1);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `venta`
--

DROP TABLE IF EXISTS `venta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `venta` (
  `id` int NOT NULL AUTO_INCREMENT,
  `fecharegistro` datetime NOT NULL,
  `empleado_id` int DEFAULT NULL,
  `cliente_id` int DEFAULT NULL,
  `montototal` decimal(10,2) NOT NULL,
  `montopago` decimal(10,2) DEFAULT NULL,
  `montocambio` decimal(10,2) DEFAULT NULL,
  `tipodocumento` varchar(45) NOT NULL,
  `numerodocumento` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `empleado_id` (`empleado_id`),
  KEY `cliente_id` (`cliente_id`),
  CONSTRAINT `venta_ibfk_1` FOREIGN KEY (`empleado_id`) REFERENCES `usuario` (`idusuario`),
  CONSTRAINT `venta_ibfk_2` FOREIGN KEY (`cliente_id`) REFERENCES `cliente` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venta`
--

LOCK TABLES `venta` WRITE;
/*!40000 ALTER TABLE `venta` DISABLE KEYS */;
INSERT INTO `venta` VALUES (1,'2025-10-06 20:49:44',1,NULL,20000.00,20000.00,0.00,'Boleta','0001-00000001');
/*!40000 ALTER TABLE `venta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `venta_mediopago`
--

DROP TABLE IF EXISTS `venta_mediopago`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `venta_mediopago` (
  `id` int NOT NULL AUTO_INCREMENT,
  `venta_id` int DEFAULT NULL,
  `medio_pago` enum('Efectivo','Tarjeta','Billetera Virtual') NOT NULL,
  `monto` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `venta_id` (`venta_id`),
  CONSTRAINT `venta_mediopago_ibfk_1` FOREIGN KEY (`venta_id`) REFERENCES `venta` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venta_mediopago`
--

LOCK TABLES `venta_mediopago` WRITE;
/*!40000 ALTER TABLE `venta_mediopago` DISABLE KEYS */;
/*!40000 ALTER TABLE `venta_mediopago` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'maxikiosco'
--

--
-- Dumping routines for database 'maxikiosco'
--
/*!50003 DROP PROCEDURE IF EXISTS `SP_EditarCategoria` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_EditarCategoria`(
	IN p_id int,
    IN p_nombre_categoria VARCHAR(50),
    IN p_estado tinyint,
    OUT p_resultado INT,
    OUT mensaje VARCHAR(250)
)
BEGIN
    SET p_resultado = 1;
    SET mensaje = '';

    IF NOT EXISTS (SELECT * FROM categoria WHERE nombre_categoria = p_nombre_categoria and id != p_id) THEN
        update categoria set nombre_categoria = p_nombre_categoria,estado=p_estado where id = p_id;
		SET mensaje = 'Categoría editada correctamente';
    else
		set p_resultado = 0;
		SET mensaje = 'Error: No se puede repetir la descripcion de una categoria';
	END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_EDITARCLIENTE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_EDITARCLIENTE`(
    IN p_idcliente INT,
    IN p_documento VARCHAR(50),
    IN p_nombre VARCHAR(80),
    IN p_apellido VARCHAR(60),
    IN p_telefono VARCHAR(20),
    IN p_domicilio VARCHAR(50),
    IN p_email VARCHAR(50),
    IN p_estado TINYINT,
    OUT respuesta TINYINT,
    OUT mensaje VARCHAR(250)
)
BEGIN
    
    SET respuesta = 0;
    SET mensaje = '';

    
    UPDATE cliente
    SET dni = p_documento,
        nombre = p_nombre,
        apellido = p_apellido,
        telefono = p_telefono,
        domicilio = p_domicilio,
        email = p_email,
        estado = p_estado
    WHERE id = p_idcliente;

    
    IF ROW_COUNT() > 0 THEN
        SET respuesta = 1;
        SET mensaje = 'Cliente actualizado correctamente';
    ELSE
        SET mensaje = 'No se encontró el cliente o no hubo cambios';
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_EditarProducto` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_EditarProducto`(
    IN p_id INT,
    IN p_nombre VARCHAR(60),
    IN p_stock INT,
    IN p_precioventa DECIMAL,
    IN p_categoria_id INT,
    IN p_preciocompra DECIMAL,
    IN p_descripcion VARCHAR(20),
    IN p_fecharegistro DATETIME,
    IN p_estado TINYINT,
    IN p_codigo VARCHAR(13),
    OUT mensaje VARCHAR(250),
    OUT resultado INT
)
BEGIN
    DECLARE existe_nombre INT DEFAULT 0;
    DECLARE existe_codigo INT DEFAULT 0;

    SET mensaje = '';
    SET resultado = 1;

    
    SELECT COUNT(*) INTO existe_nombre
    FROM producto 
    WHERE id != p_id AND nombre = p_nombre;

    
    SELECT COUNT(*) INTO existe_codigo
    FROM producto 
    WHERE id != p_id AND codigo = p_codigo;

    
    IF (existe_nombre = 0 AND existe_codigo = 0) THEN
        UPDATE producto 
        SET nombre = p_nombre,
            stock = p_stock,
            precioventa = p_precioventa,
            categoria_id = p_categoria_id,
            preciocompra = p_preciocompra,
            descripcion = p_descripcion,
            fecharegistro = p_fecharegistro,
            estado = p_estado,
            codigo = p_codigo
        WHERE id = p_id;

        SET mensaje = 'El producto se editó con éxito';
        SET resultado = 1;
    ELSE
        SET resultado = 0;
        IF existe_nombre > 0 THEN
            SET mensaje = 'Error: ya existe otro producto con ese nombre';
        ELSEIF existe_codigo > 0 THEN
            SET mensaje = 'Error: ya existe otro producto con ese código';
        END IF;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_EDITARPROVEEDOR` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_EDITARPROVEEDOR`(
IN p_id INT,
IN p_nombre VARCHAR(80),
IN p_cuit VARCHAR(40),
IN p_razonsocial VARCHAR(80),
IN p_telefono VARCHAR(20),
IN p_direccion VARCHAR(80),
IN p_estado TINYINT,
IN p_email VARCHAR(60),
OUT resultado TINYINT,
OUT mensaje VARCHAR(250)
)
BEGIN
	set resultado = 1;
    set mensaje = '';
    IF NOT EXISTS(SELECT 1 FROM proveedor WHERE cuit = p_cuit and id != p_id ) THEN 
		UPDATE proveedor 
		SET nombre = p_nombre,
		cuit = p_cuit, 
        razonsocial = p_razonsocial,
		telefono = p_telefono,
		direccion = p_direccion,
		estado = p_estado,
		email = p_email where id = p_id;
		SET resultado = last_insert_id();
		SET mensaje = 'El proveedor fue modificado con exito';
    ELSE
		SET mensaje = 'El numero de documento ya existe';
	END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_EDITARUSUARIO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_EDITARUSUARIO`(
	IN p_idusuario int,
    IN p_documento VARCHAR(50),
    IN p_nombre VARCHAR(80),
    IN p_apellido VARCHAR(60),
    IN p_telefono VARCHAR(20),
    IN p_rol_id INT,
    IN p_usuario_cuenta VARCHAR(30),
    IN p_contrasenia VARCHAR(80),
    IN p_email VARCHAR(50),
    IN p_estado TINYINT,
    OUT respuesta tinyint,
    OUT mensaje VARCHAR(250)
)
BEGIN
    
    SET respuesta = 0;
    SET mensaje = '';

    IF NOT EXISTS (SELECT 1 FROM usuario WHERE dni = p_documento AND idusuario <> p_idusuario) THEN
        UPDATE usuario set dni = p_documento,
		nombre = p_nombre,
        apellido = p_apellido,
        email = p_email,
        usuario_cuenta = p_usuario_cuenta,
        contrasenia = p_contrasenia,
        rol_id =  p_rol_id,
        telefono =  p_telefono,
        estado = p_estado
        where idusuario = p_idusuario;

        SET respuesta = 1;
        SET mensaje = 'Usuario editado correctamente';
    ELSE
        SET mensaje = 'Error: No se puede editar a ese usuario';
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_EliminarCategoria` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_EliminarCategoria`(
	IN p_id int,
    OUT p_resultado INT,
    OUT mensaje VARCHAR(250)
)
BEGIN
    SET p_resultado = 1;
    SET mensaje = '';

    IF NOT EXISTS (SELECT * FROM categoria inner join producto on producto.categoria_id = categoria.id
    WHERE categoria.id = p_id) THEN
        delete from categoria where id=p_id;
        SET mensaje = 'Categoría eliminada correctamente';
    
    else
		set p_resultado = 0;
		SET mensaje = 'Error: No se puede eliminar esta categoria ya esta relacionada a un producto';
	END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_EliminarProducto` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_EliminarProducto`(
in p_id int,
out resultado int,
out mensaje varchar(250)
)
begin
	DECLARE pasoregla TINYINT DEFAULT 1;
	set resultado = 1;
	set mensaje = '';
	
	if exists(select * from detalle_compra inner join producto on producto.id = detalle_compra.producto_id where producto.id = p_id) then
	set resultado = 0;
    set pasoregla = 0;
    set mensaje = 'No se puede eliminar este producto por que esta asociado a una compra';
    end if;
	if exists(select * from detalle_venta inner join producto on producto.id = detalle_venta.producto_id
	where producto.id = p_id) then
		set resultado = 0;
        set pasoregla = 0;
        set mensaje = 'No se puede eliminar este producto por que esta asociado a una venta';
	end if;
	if (pasoregla = 1)then
			delete from producto where producto.id = p_id;
			set resultado = 1;
	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_ELIMINARPROVEEDOR` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_ELIMINARPROVEEDOR`(
IN p_id int,
out resultado TINYINT,
out mensaje varchar(250)
)
BEGIN
	set resultado = 1;
    if not exists(
		select * from proveedor p inner join compra c on p.id = c.proveedor_id where p_id = p.id
		) THEN
		delete from proveedor where id = p_id;
    ELSE
		set resultado = 0;
        set mensaje = "El proveedor se encuentra relacionado a una compra";
	END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_ELIMINARUSUARIO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_ELIMINARUSUARIO`(
    IN p_idusuario INT,
    OUT respuesta TINYINT,
    OUT mensaje VARCHAR(250)
)
BEGIN
    
    DECLARE pasoregla TINYINT DEFAULT 1;

    
    SET respuesta = 0;
    SET mensaje = '';

    
    IF EXISTS (
        SELECT 1 FROM compra c 
        INNER JOIN usuario u ON u.idusuario = c.empleado_id 
        WHERE u.idusuario = p_idusuario
    ) THEN
        SET pasoregla = 0;
        SET respuesta = 0;
        SET mensaje = 'No se puede eliminar porque el usuario se encuentra relacionado a una compra';
    END IF;

    
    IF EXISTS (
        SELECT 1 FROM venta v 
        INNER JOIN usuario u ON u.idusuario = v.empleado_id 
        WHERE u.idusuario = p_idusuario
    ) THEN
        SET pasoregla = 0;
        SET respuesta = 0;
        SET mensaje = 'No se puede eliminar porque el usuario se encuentra relacionado a una venta';
    END IF;

    
    IF pasoregla = 1 THEN
        DELETE FROM usuario WHERE idusuario = p_idusuario;
        SET respuesta = 1;
        SET mensaje = 'Usuario eliminado correctamente';
    END IF;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_RegistrarCategoria` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_RegistrarCategoria`(
    IN p_nombre_categoria VARCHAR(50),
    IN p_estado tinyint,
    OUT p_resultado INT,
    OUT mensaje VARCHAR(250)
)
BEGIN
    SET p_resultado = 0;
    SET mensaje = '';

    IF NOT EXISTS (SELECT * FROM categoria WHERE nombre_categoria = p_nombre_categoria) THEN
        INSERT INTO categoria(nombre_categoria,estado) VALUES (p_nombre_categoria,p_estado);
        SET p_resultado = LAST_INSERT_ID();
		SET mensaje = 'Categoría creada correctamente';
    else
		SET mensaje = 'Error: Ya existe esa categoria';
	END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_REGISTRARCLIENTE` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_REGISTRARCLIENTE`(
    IN p_documento VARCHAR(50),
    IN p_nombre VARCHAR(80),
    IN p_apellido VARCHAR(60),
    IN p_telefono VARCHAR(20),
    IN p_email VARCHAR(50),
    IN p_domicilio varchar(50),
    IN p_estado TINYINT,
    OUT idclienteresultado INT,
    OUT mensaje VARCHAR(250)
)
BEGIN
    
    SET idclienteresultado = 0;
    SET mensaje = '';

    IF NOT EXISTS (SELECT 1 FROM cliente WHERE dni = p_documento) THEN
        INSERT INTO cliente (nombre, apellido, dni,telefono,domicilio,email, estado)
        VALUES ( p_nombre, p_apellido,p_documento,p_telefono,p_domicilio,p_email,p_estado);

        SET idclienteresultado = LAST_INSERT_ID();
        SET mensaje = 'Cliente registrado correctamente';
    ELSE
        SET mensaje = 'Error: Ya existe un cliente con ese documento';
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_RegistrarCompra` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_RegistrarCompra`(
  IN  p_empleado_id     INT,
  IN  p_proveedor_id    INT,
  IN  p_tipodocumento   VARCHAR(45),
  IN  p_numerodocumento VARCHAR(45),
  IN  p_detallecompra   JSON,       
  OUT resultado         TINYINT,
  OUT mensaje           VARCHAR(250)
)
BEGIN
  DECLARE v_compra_id BIGINT;
  DECLARE v_rows INT DEFAULT 0;
  DECLARE v_missing INT DEFAULT 0;
  DECLARE v_first_missing INT DEFAULT NULL;
  DECLARE v_msg TEXT;
  DECLARE v_sqlstate CHAR(5);

  
  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    GET DIAGNOSTICS CONDITION 1 v_msg = MESSAGE_TEXT, v_sqlstate = RETURNED_SQLSTATE;
    ROLLBACK;
    SET resultado = 0;
    SET mensaje = CONCAT('Error al registrar la compra: ', COALESCE(v_msg,'?'), ' [SQLSTATE ', COALESCE(v_sqlstate,'00000'), ']');
  END;

  proc: BEGIN
    
    IF JSON_TYPE(p_detallecompra) <> 'ARRAY' THEN
      SET resultado = 0;
      SET mensaje = 'p_detallecompra debe ser un arreglo JSON';
      LEAVE proc;
    END IF;

    
    CREATE TEMPORARY TABLE IF NOT EXISTS det_tmp (
      producto_id  INT NOT NULL,
      preciocompra DECIMAL(10,2) NOT NULL,
      precioventa  DECIMAL(10,2) NOT NULL,
      cantidad     INT NOT NULL
    ) ENGINE=Memory;

    TRUNCATE det_tmp;

    INSERT INTO det_tmp (producto_id, preciocompra, precioventa, cantidad)
    SELECT
      j.producto_id,
      j.preciocompra,
      j.precioventa,
      j.cantidad
    FROM JSON_TABLE(
           p_detallecompra, '$[*]'
           COLUMNS(
             producto_id  INT            PATH '$.producto_id',
             preciocompra DECIMAL(10,2)  PATH '$.preciocompra',
             precioventa  DECIMAL(10,2)  PATH '$.precioventa',
             cantidad     INT            PATH '$.cantidad'
           )
         ) AS j;

    
    SELECT COUNT(*) INTO v_rows FROM det_tmp;
    IF v_rows = 0 THEN
      SET resultado = 0;
      SET mensaje = 'El detalle está vacío';
      LEAVE proc;
    END IF;

    
    SELECT COUNT(*)
      INTO v_missing
    FROM (SELECT DISTINCT producto_id FROM det_tmp) x
    LEFT JOIN producto p ON p.id = x.producto_id
    WHERE p.id IS NULL;

    IF v_missing > 0 THEN
      SELECT x.producto_id
        INTO v_first_missing
      FROM (SELECT DISTINCT producto_id FROM det_tmp) x
      LEFT JOIN producto p ON p.id = x.producto_id
      WHERE p.id IS NULL
      LIMIT 1;

      SET resultado = 0;
      SET mensaje = CONCAT('Producto inexistente: ', v_first_missing);
      LEAVE proc;
    END IF;

    START TRANSACTION;

    
    INSERT INTO compra (fecharegistro, montototal, empleado_id, proveedor_id, tipodocumento, numerodocumento)
    SELECT
      NOW(),
      IFNULL(SUM(cantidad * preciocompra), 0),
      p_empleado_id,
      p_proveedor_id,
      p_tipodocumento,
      p_numerodocumento
    FROM det_tmp;

    SET v_compra_id = LAST_INSERT_ID();

    
    INSERT INTO detalle_compra (compra_id, producto_id, cantidad, montototal, preciocompra, precioventa, fecharegistro)
    SELECT
      v_compra_id,
      producto_id,
      cantidad,
      cantidad * preciocompra,
      preciocompra,
      precioventa,
      NOW()
    FROM det_tmp;

    
    UPDATE producto p
    JOIN (
      SELECT
        producto_id,
        SUM(cantidad)     AS qty,
        MAX(preciocompra) AS pc,
        MAX(precioventa)  AS pv
      FROM det_tmp
      GROUP BY producto_id
    ) dc ON dc.producto_id = p.id
    SET p.stock        = p.stock + dc.qty,
        p.preciocompra = dc.pc,
        p.precioventa  = dc.pv;

    COMMIT;

    SET resultado = 1;
    SET mensaje   = 'Compra registrada correctamente';

    
    DROP TEMPORARY TABLE IF EXISTS det_tmp;
  END proc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_RegistrarProducto` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_RegistrarProducto`(
in p_nombre varchar(60),
in p_stock int,
in p_precioventa float,
in p_categoria_id int,
in p_preciocompra float,
in p_descripcion varchar(20),
in p_fecharegistro datetime,
in p_estado tinyint,
in p_codigo varchar(13),
out mensaje varchar(250),
out resultado int
)
begin
	set mensaje = '';
    set resultado = 1;
	if not exists(select * from producto where producto.nombre = p_nombre and producto.codigo = p_codigo) then
			insert into producto(nombre,stock,precioventa,categoria_id,preciocompra,descripcion,estado,codigo)
			values (p_nombre,p_stock,p_precioventa,p_categoria_id,p_preciocompra,p_descripcion,p_estado,p_codigo);
			set resultado = last_insert_id();
			set mensaje = "El producto se registro con exito";
	else
			set mensaje = "Error, el producto ya esta registrado";
	end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_REGISTRARPROVEEDOR` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_REGISTRARPROVEEDOR`(
    IN p_nombre VARCHAR(80),
    IN p_cuit VARCHAR(30),
    IN p_razonsocial VARCHAR(80),
    IN p_telefono VARCHAR(20),
    IN p_direccion VARCHAR(100),
    IN p_estado TINYINT,
    IN p_email VARCHAR(80),
    OUT resultado INT,
    OUT mensaje VARCHAR(250)
)
BEGIN
    SET resultado = 0;
    SET mensaje = '';

    IF NOT EXISTS (SELECT 1 FROM proveedor WHERE cuit = p_cuit) THEN
        INSERT INTO proveedor(nombre, cuit, razonsocial , telefono, direccion, estado, fecharegistro, email)
        VALUES (p_nombre, p_cuit, p_razonsocial, p_telefono, p_direccion, p_estado, NOW(), p_email);

        SET resultado = LAST_INSERT_ID();
        SET mensaje = 'El proveedor fue registrado con éxito';
    ELSE
        SET mensaje = 'Error: el CUIT ya existe';
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_REGISTRARUSUARIO` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_REGISTRARUSUARIO`(
    IN p_documento VARCHAR(50),
    IN p_nombre VARCHAR(80),
    IN p_apellido VARCHAR(60),
    IN p_telefono VARCHAR(20),
    IN p_rol_id INT,
    IN p_usuario_cuenta VARCHAR(30),
    IN p_contrasenia VARCHAR(80),
    IN p_email VARCHAR(50),
    IN p_estado TINYINT,
    OUT idusuarioresultado INT,
    OUT mensaje VARCHAR(250)
)
BEGIN
    
    SET idusuarioresultado = 0;
    SET mensaje = '';

    IF NOT EXISTS (SELECT 1 FROM usuario WHERE dni = p_documento) THEN
        INSERT INTO usuario (dni, nombre, apellido, email, usuario_cuenta, contrasenia, rol_id, telefono, estado)
        VALUES (p_documento, p_nombre, p_apellido, p_email, p_usuario_cuenta, p_contrasenia, p_rol_id, p_telefono, p_estado);

        SET idusuarioresultado = LAST_INSERT_ID();
        SET mensaje = 'Usuario registrado correctamente';
    ELSE
        SET mensaje = 'Error: Ya existe un usuario con ese documento';
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_RegistrarVenta` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_RegistrarVenta`(
  IN  p_IdUsuario       INT,
  IN  p_TipoDocumento   VARCHAR(45),
  IN  p_NumeroDocumento VARCHAR(45),
  IN  p_NombreCliente   VARCHAR(150),
  IN  p_MontoPago       DECIMAL(10,2),
  IN  p_DetalleVenta    JSON,   
  OUT resultado         TINYINT,
  OUT mensaje           VARCHAR(250)
)
BEGIN
  DECLARE v_VentaId     BIGINT;
  DECLARE v_MontoTotal  DECIMAL(10,2);
  DECLARE v_Insuf       INT DEFAULT 0;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK;
    SET resultado = 0;
    SET mensaje  = 'Error al registrar la venta';
  END;

  proc: BEGIN
    IF JSON_TYPE(p_DetalleVenta) <> 'ARRAY' THEN
      SET resultado = 0;
      SET mensaje   = 'p_DetalleVenta debe ser un arreglo JSON';
      LEAVE proc;
    END IF;

    SELECT IFNULL(SUM(j.cantidad * j.precio_unitario), 0)
      INTO v_MontoTotal
    FROM JSON_TABLE(
           p_DetalleVenta, '$[*]'
           COLUMNS(
             producto_id     INT            PATH '$.producto_id',
             cantidad        INT            PATH '$.cantidad',
             precio_unitario DECIMAL(10,2)  PATH '$.precio_unitario'
           )
         ) AS j;

    IF p_MontoPago < v_MontoTotal THEN
      SET resultado = 0;
      SET mensaje   = 'El monto de pago es insuficiente';
      LEAVE proc;
    END IF;

    START TRANSACTION;

    
    SELECT COUNT(*)
      INTO v_Insuf
    FROM producto p
    JOIN (
      SELECT producto_id, SUM(cantidad) qty
      FROM JSON_TABLE(
             p_DetalleVenta, '$[*]'
             COLUMNS(
               producto_id INT PATH '$.producto_id',
               cantidad    INT PATH '$.cantidad'
             )
           ) jt
      GROUP BY producto_id
    ) dv ON dv.producto_id = p.id
    WHERE p.stock < dv.qty
    FOR UPDATE;

    IF v_Insuf > 0 THEN
      ROLLBACK;
      SET resultado = 0;
      SET mensaje   = 'Stock insuficiente';
      LEAVE proc;
    END IF;

    INSERT INTO venta(
      fecharegistro, empleado_id, cliente_id,          
      montototal, montopago, montocambio,
      tipodocumento, numerodocumento
    )
    VALUES (NOW(), p_IdUsuario, NULL,
            v_MontoTotal, p_MontoPago, p_MontoPago - v_MontoTotal,
            p_TipoDocumento, p_NumeroDocumento);

    SET v_VentaId = LAST_INSERT_ID();

    INSERT INTO detalle_venta(venta_id, producto_id, cantidad, precio_unitario)
    SELECT v_VentaId, j.producto_id, j.cantidad, j.precio_unitario
    FROM JSON_TABLE(
           p_DetalleVenta, '$[*]'
           COLUMNS(
             producto_id     INT            PATH '$.producto_id',
             cantidad        INT            PATH '$.cantidad',
             precio_unitario DECIMAL(10,2)  PATH '$.precio_unitario'
           )
         ) AS j;

    UPDATE producto p
    JOIN (
      SELECT producto_id, SUM(cantidad) qty
      FROM JSON_TABLE(
             p_DetalleVenta, '$[*]'
             COLUMNS(
               producto_id INT PATH '$.producto_id',
               cantidad    INT PATH '$.cantidad'
             )
           ) jt
      GROUP BY producto_id
    ) dv ON dv.producto_id = p.id
    SET p.stock = p.stock - dv.qty;

    COMMIT;

    SET resultado = 1;
    SET mensaje  = 'Venta registrada correctamente';
  END proc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-10-09  0:26:05
