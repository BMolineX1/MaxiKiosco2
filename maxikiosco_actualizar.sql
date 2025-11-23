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
-- Table structure for table `caja_apertura`
--

DROP TABLE IF EXISTS `caja_apertura`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `caja_apertura` (
  `id` int NOT NULL AUTO_INCREMENT,
  `fecha` date NOT NULL,
  `empleado_id` int NOT NULL,
  `monto_inicial` decimal(12,2) NOT NULL DEFAULT '0.00',
  `abierta` tinyint(1) NOT NULL DEFAULT '1',
  `abierto_en` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `cerrado_en` datetime DEFAULT NULL,
  `saldo_cierre` decimal(12,2) DEFAULT NULL,
  `observaciones` varchar(255) DEFAULT NULL,
  `fecha_abierta_empleado` varchar(40) GENERATED ALWAYS AS ((case when (`abierta` = 1) then concat(date_format(`fecha`,_utf8mb4'%Y-%m-%d'),_utf8mb4'#',`empleado_id`) else NULL end)) STORED,
  PRIMARY KEY (`id`),
  UNIQUE KEY `uq_fecha_abierta_empleado` (`fecha_abierta_empleado`),
  UNIQUE KEY `uq_fecha_abierta` (((case when (`abierta` = 1) then `fecha` end)))
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `caja_apertura`
--

LOCK TABLES `caja_apertura` WRITE;
/*!40000 ALTER TABLE `caja_apertura` DISABLE KEYS */;
INSERT INTO `caja_apertura` (`id`, `fecha`, `empleado_id`, `monto_inicial`, `abierta`, `abierto_en`, `cerrado_en`, `saldo_cierre`, `observaciones`) VALUES (1,'2025-11-01',1,1000.00,0,'2025-11-01 21:28:35','2025-11-01 21:29:33',950.00,'Inicio del d√≠a'),(3,'2025-11-03',1,1000.00,0,'2025-11-03 15:18:35','2025-11-03 15:18:35',1250.00,'Cierre del d√≠a'),(4,'2025-11-03',1,1000.00,0,'2025-11-03 15:18:43','2025-11-03 15:18:43',1250.00,'Cierre del d√≠a'),(5,'2025-11-03',1,10000.00,0,'2025-11-03 15:37:53','2025-11-03 20:40:33',40000.00,''),(6,'2025-11-03',1,20000.00,0,'2025-11-03 20:43:32','2025-11-03 20:53:06',1250.00,'Cierre del turno'),(7,'2025-10-06',1,0.00,0,'2025-10-06 00:00:00','2025-10-06 23:59:59',NULL,'Apertura t√©cnica (backfill)'),(8,'2025-10-25',1,0.00,0,'2025-10-25 00:00:00','2025-10-25 23:59:59',NULL,'Apertura t√©cnica (backfill)'),(9,'2025-10-28',1,0.00,0,'2025-10-28 00:00:00','2025-10-28 23:59:59',NULL,'Apertura t√©cnica (backfill)'),(10,'2025-10-29',1,0.00,0,'2025-10-29 00:00:00','2025-10-29 23:59:59',NULL,'Apertura t√©cnica (backfill)'),(11,'2025-10-31',1,0.00,0,'2025-10-31 00:00:00','2025-10-31 23:59:59',NULL,'Apertura t√©cnica (backfill)'),(14,'2025-11-03',1,10000.00,0,'2025-11-03 21:31:48','2025-11-03 21:32:31',150000.00,''),(15,'2025-11-03',1,20000.00,0,'2025-11-03 22:49:12','2025-11-03 22:52:24',240000.00,'sobro dinero por venta de caramelos'),(16,'2025-11-03',1,10000.00,0,'2025-11-03 23:04:41','2025-11-03 23:10:41',0.00,''),(17,'2025-11-03',1,10000.00,0,'2025-11-03 23:35:12','2025-11-03 23:37:03',240000.00,'asd'),(18,'2025-11-03',1,10000.00,0,'2025-11-03 23:37:17','2025-11-03 23:42:18',0.00,''),(19,'2025-11-03',1,10000.00,0,'2025-11-03 23:43:28','2025-11-03 23:45:09',100000.00,'asdasd'),(20,'2025-11-03',1,20000.00,0,'2025-11-03 23:55:31','2025-11-04 00:04:27',20000.00,''),(21,'2025-11-06',12,100000.00,0,'2025-11-06 13:38:26','2025-11-06 13:45:16',102200.00,'funciona'),(22,'2025-11-06',12,0.00,0,'2025-11-06 13:50:10','2025-11-06 13:53:03',5500.00,'todo ok'),(23,'2025-11-06',12,0.00,0,'2025-11-06 15:07:23','2025-11-06 15:10:27',0.00,''),(24,'2025-11-06',12,0.00,0,'2025-11-06 16:53:27','2025-11-06 16:54:36',0.00,''),(25,'2025-11-06',12,0.00,0,'2025-11-06 19:15:36','2025-11-06 19:16:20',0.00,''),(26,'2025-11-06',12,0.00,0,'2025-11-06 19:21:00','2025-11-06 19:21:56',0.00,''),(27,'2025-11-06',12,0.00,0,'2025-11-06 19:23:53','2025-11-06 19:25:16',0.00,''),(28,'2025-11-07',12,0.00,0,'2025-11-07 22:19:43','2025-11-07 22:20:46',0.00,''),(29,'2025-11-11',12,0.00,0,'2025-11-11 03:36:55','2025-11-11 03:39:03',0.00,'');
/*!40000 ALTER TABLE `caja_apertura` ENABLE KEYS */;
UNLOCK TABLES;

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
  `porcentaje_aumento` decimal(5,2) DEFAULT '0.00',
  PRIMARY KEY (`id`),
  UNIQUE KEY `nombre_categoria` (`nombre_categoria`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoria`
--

LOCK TABLES `categoria` WRITE;
/*!40000 ALTER TABLE `categoria` DISABLE KEYS */;
INSERT INTO `categoria` VALUES (2,'Bebidas',1,10.00),(3,'Panificados',1,30.00),(9,'Fiambreria',1,29.00),(10,'Galletitas',1,5.00),(18,'Lacteos',0,12.00),(21,'Otro',1,50.00),(22,'Articulo de limpieza',1,30.00),(23,'bazar',1,15.00),(24,'Alfajor',1,0.00),(25,'Mercaderias',1,50.00),(26,'Pastas',1,45.00);
/*!40000 ALTER TABLE `categoria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cc_estado`
--

DROP TABLE IF EXISTS `cc_estado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cc_estado` (
  `id` int NOT NULL AUTO_INCREMENT,
  `cliente_id` int NOT NULL,
  `saldo` decimal(10,2) NOT NULL DEFAULT '0.00',
  `limite_credito` decimal(10,2) NOT NULL DEFAULT '0.00',
  `habilitada` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  UNIQUE KEY `cliente_id` (`cliente_id`),
  UNIQUE KEY `uq_cc_estado_cliente` (`cliente_id`),
  CONSTRAINT `fk_cc_estado_cliente` FOREIGN KEY (`cliente_id`) REFERENCES `cliente` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cc_estado`
--

LOCK TABLES `cc_estado` WRITE;
/*!40000 ALTER TABLE `cc_estado` DISABLE KEYS */;
INSERT INTO `cc_estado` VALUES (1,1,0.44,0.00,1),(7,5,1240.40,0.00,1);
/*!40000 ALTER TABLE `cc_estado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cc_movimiento`
--

DROP TABLE IF EXISTS `cc_movimiento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cc_movimiento` (
  `id` int NOT NULL AUTO_INCREMENT,
  `cliente_id` int NOT NULL,
  `fecha_hora` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `tipo` enum('DEBITO','CREDITO') NOT NULL,
  `concepto` varchar(150) DEFAULT NULL,
  `venta_id` int DEFAULT NULL,
  `monto` decimal(12,2) NOT NULL,
  `usuario_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_ccm_usuario` (`usuario_id`),
  KEY `fk_ccm_venta` (`venta_id`),
  KEY `idx_ccm_cliente_fecha` (`cliente_id`,`fecha_hora`),
  CONSTRAINT `fk_ccm_cliente` FOREIGN KEY (`cliente_id`) REFERENCES `cliente` (`id`),
  CONSTRAINT `fk_ccm_usuario` FOREIGN KEY (`usuario_id`) REFERENCES `usuario` (`idusuario`),
  CONSTRAINT `fk_ccm_venta` FOREIGN KEY (`venta_id`) REFERENCES `venta` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cc_movimiento`
--

LOCK TABLES `cc_movimiento` WRITE;
/*!40000 ALTER TABLE `cc_movimiento` DISABLE KEYS */;
INSERT INTO `cc_movimiento` VALUES (2,1,'2025-11-01 01:43:20','CREDITO','Prueba',NULL,100.00,1),(3,1,'2025-11-01 01:55:53','CREDITO','Pago',NULL,1000.00,1),(4,1,'2025-11-01 01:56:02','CREDITO','Pago',NULL,2000.00,1),(6,1,'2025-11-01 02:15:48','CREDITO','Pago',NULL,2800.00,1);
/*!40000 ALTER TABLE `cc_movimiento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cierres_caja`
--

DROP TABLE IF EXISTS `cierres_caja`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cierres_caja` (
  `id` int NOT NULL AUTO_INCREMENT,
  `apertura_id` int NOT NULL,
  `fecha` date NOT NULL,
  `empleado_id` int NOT NULL,
  `total_ventas` decimal(12,2) NOT NULL DEFAULT '0.00',
  `ventas_efectivo` decimal(12,2) NOT NULL DEFAULT '0.00',
  `ventas_tarjeta` decimal(12,2) NOT NULL DEFAULT '0.00',
  `ventas_ctacte` decimal(12,2) NOT NULL DEFAULT '0.00',
  `retiros_total` decimal(12,2) NOT NULL DEFAULT '0.00',
  `saldo_real` decimal(12,2) NOT NULL DEFAULT '0.00',
  `diferencia` decimal(12,2) NOT NULL DEFAULT '0.00',
  `observaciones` varchar(255) DEFAULT NULL,
  `creado_en` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `idx_fecha` (`fecha`),
  KEY `fk_cierre_apertura` (`apertura_id`),
  CONSTRAINT `fk_cierre_apertura` FOREIGN KEY (`apertura_id`) REFERENCES `caja_apertura` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cierres_caja`
--

LOCK TABLES `cierres_caja` WRITE;
/*!40000 ALTER TABLE `cierres_caja` DISABLE KEYS */;
INSERT INTO `cierres_caja` VALUES (1,1,'2025-11-01',1,6841.28,0.00,0.00,6841.28,0.00,950.00,950.00,'Cierre del d√≠a','2025-11-02 00:29:33'),(6,3,'2025-11-03',1,0.00,0.00,0.00,0.00,0.00,1250.00,250.00,'Cierre del d√≠a','2025-11-03 18:18:35'),(7,4,'2025-11-03',1,0.00,0.00,0.00,0.00,0.00,1250.00,250.00,'Cierre del d√≠a','2025-11-03 18:18:43'),(8,5,'2025-11-03',1,0.00,0.00,0.00,0.00,0.00,40000.00,30000.00,'','2025-11-03 23:40:33'),(9,6,'2025-11-03',1,0.00,0.00,0.00,0.00,100.00,1250.00,-18650.00,'Cierre del turno','2025-11-03 23:53:06'),(10,14,'2025-11-03',1,0.00,0.00,0.00,0.00,100.00,150000.00,140100.00,'','2025-11-04 00:32:31'),(11,15,'2025-11-03',1,217600.00,217600.00,0.00,0.00,100.00,240000.00,2500.00,'sobro dinero por venta de caramelos','2025-11-04 01:52:24'),(12,16,'2025-11-03',1,0.00,0.00,0.00,0.00,0.00,0.00,-10000.00,'','2025-11-04 02:10:41'),(13,17,'2025-11-03',1,0.00,0.00,0.00,0.00,2000.00,240000.00,232000.00,'asd','2025-11-04 02:37:03'),(14,18,'2025-11-03',1,0.00,0.00,0.00,0.00,100.00,0.00,-9900.00,'','2025-11-04 02:42:18'),(15,19,'2025-11-03',1,0.00,0.00,0.00,0.00,0.00,100000.00,90000.00,'asdasd','2025-11-04 02:45:09'),(16,20,'2025-11-03',1,5280.00,5280.00,0.00,0.00,5000.00,20000.00,-280.00,'','2025-11-04 03:04:27'),(17,21,'2025-11-06',12,2200.00,2200.00,0.00,0.00,0.00,102200.00,0.00,'funciona','2025-11-06 16:45:16'),(18,22,'2025-11-06',12,5500.00,5500.00,0.00,0.00,0.00,5500.00,0.00,'todo ok','2025-11-06 16:53:03'),(19,23,'2025-11-06',12,11000.00,11000.00,0.00,0.00,0.00,0.00,-11000.00,'','2025-11-06 18:10:27'),(20,24,'2025-11-06',12,3300.00,3300.00,0.00,0.00,0.00,0.00,-3300.00,'','2025-11-06 19:54:36'),(21,25,'2025-11-06',12,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'','2025-11-06 22:16:20'),(22,26,'2025-11-06',12,7500.00,7500.00,0.00,0.00,0.00,0.00,-7500.00,'','2025-11-06 22:21:56'),(23,27,'2025-11-06',12,5500.00,5500.00,0.00,0.00,0.00,0.00,-5500.00,'','2025-11-06 22:25:16'),(24,28,'2025-11-07',12,2200.00,2200.00,0.00,0.00,0.00,0.00,-2200.00,'','2025-11-08 01:20:46'),(25,29,'2025-11-11',12,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'','2025-11-11 06:39:03');
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
  `condicion_iva` enum('Responsable Inscripto','Monotributista','Consumidor Final','Exento') DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `dni` (`dni`),
  UNIQUE KEY `email_UNIQUE` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` VALUES (1,'Federico','Molina','38962453','','3644657148','mz 7 pc 12 Barrio Pro.Mu.Vi','fede.099molina@gmail.com',1,'Consumidor Final'),(4,'gabi','Vera','23333332','','33333333','mz 7 pc 23','fede@gmail.com',1,'Consumidor Final'),(5,'Elias','Ramirez','42746919','','3644222298','Barrio anbtoc√±','elias@gmail.com',1,'Consumidor Final'),(11,'Marcelo','Concelo','12457805','','3644896278','Na√±ta','123abc@gmail.com',1,'Consumidor Final'),(12,'Roberto','Gonzales','42746123','12341234895','3644564455','ss','gonza@gmail.com',1,'Responsable Inscripto');
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
  `monto_iva_total` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`id_compra`),
  KEY `empleado_id` (`empleado_id`),
  KEY `proveedor_id` (`proveedor_id`),
  CONSTRAINT `compra_ibfk_1` FOREIGN KEY (`empleado_id`) REFERENCES `usuario` (`idusuario`),
  CONSTRAINT `compra_ibfk_2` FOREIGN KEY (`proveedor_id`) REFERENCES `proveedor` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `compra`
--

LOCK TABLES `compra` WRITE;
/*!40000 ALTER TABLE `compra` DISABLE KEYS */;
INSERT INTO `compra` VALUES (3,'2025-09-30 22:57:38',4500000.00,1,3,'Boleta','0001-00000001',NULL),(4,'2025-09-30 23:25:14',30000.00,1,3,'Boleta','0001-00000002',NULL),(5,'2025-10-07 14:30:48',38600.00,1,3,'Boleta','0001-00000003',NULL),(6,'2025-11-01 03:27:12',6509.00,1,3,'Boleta','0001-00000004',NULL),(7,'2025-11-01 17:23:13',16000.00,1,3,'Boleta','0001-00000005',NULL),(8,'2025-11-04 14:22:50',15000.00,1,3,'Boleta','0001-00000006',NULL),(9,'2025-11-04 14:26:18',1500.00,1,3,'Boleta','0001-00000007',NULL),(10,'2025-11-06 01:33:45',7500.00,12,8,'Boleta','0001-00000008',NULL),(11,'2025-11-06 01:47:11',1000.00,12,8,'Boleta','0001-00000009',NULL),(12,'2025-11-06 01:48:09',8000.00,12,8,'Boleta','0001-00000010',NULL),(13,'2025-11-06 15:00:34',20000.00,12,8,'Boleta','0001-00000011',NULL),(14,'2025-11-06 17:02:32',31000.00,12,3,'Boleta','0001-00000012',NULL),(15,'2025-11-06 17:52:15',1000.00,12,8,'Factura A','0001-00000013',NULL),(16,'2025-11-06 18:57:29',2420.00,12,8,'Factura A','0001-00000014',420.00),(17,'2025-11-06 19:09:49',9994.60,12,8,'Nota de Cr√©dito','0001-00000015',1734.60),(18,'2025-11-07 22:13:37',2420.00,12,9,'Factura A','0001-00000016',420.00);
/*!40000 ALTER TABLE `compra` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cuenta_corriente_cliente`
--

DROP TABLE IF EXISTS `cuenta_corriente_cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cuenta_corriente_cliente` (
  `cliente_id` int NOT NULL,
  `saldo` decimal(12,2) NOT NULL DEFAULT '0.00',
  `limite_credito` decimal(12,2) NOT NULL DEFAULT '0.00',
  `habilitada` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`cliente_id`),
  CONSTRAINT `fk_cc_cliente` FOREIGN KEY (`cliente_id`) REFERENCES `cliente` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cuenta_corriente_cliente`
--

LOCK TABLES `cuenta_corriente_cliente` WRITE;
/*!40000 ALTER TABLE `cuenta_corriente_cliente` DISABLE KEYS */;
INSERT INTO `cuenta_corriente_cliente` VALUES (1,0.44,0.00,1),(4,0.00,0.00,1),(5,1240.40,0.00,1),(11,0.00,0.00,1);
/*!40000 ALTER TABLE `cuenta_corriente_cliente` ENABLE KEYS */;
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
  `monto_iva` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `compra_id` (`compra_id`),
  KEY `producto_id` (`producto_id`),
  CONSTRAINT `detalle_compra_ibfk_1` FOREIGN KEY (`compra_id`) REFERENCES `compra` (`id_compra`),
  CONSTRAINT `detalle_compra_ibfk_2` FOREIGN KEY (`producto_id`) REFERENCES `producto` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalle_compra`
--

LOCK TABLES `detalle_compra` WRITE;
/*!40000 ALTER TABLE `detalle_compra` DISABLE KEYS */;
INSERT INTO `detalle_compra` VALUES (1,3,3,30,4500000.00,150000.00,0.00,'2025-09-30 22:57:38',NULL),(2,4,8,20,30000.00,1500.00,2000.00,'2025-09-30 23:25:14',NULL),(3,5,8,20,32000.00,1600.00,1400.00,'2025-10-07 14:30:48',NULL),(4,5,4,6,6600.00,1100.00,1000.00,'2025-10-07 14:30:48',NULL),(6,6,43,10,6509.00,650.90,1000.60,'2025-11-01 03:27:12',NULL),(7,7,8,10,16000.00,1600.00,1760.00,'2025-11-01 17:23:13',NULL),(8,8,45,10,15000.00,1500.00,3000.00,'2025-11-04 14:22:50',NULL),(9,9,45,1,1500.00,1500.00,3000.00,'2025-11-04 14:26:18',NULL),(10,10,3,5,7500.00,1500.00,1650.00,'2025-11-06 01:33:45',NULL),(11,11,3,1,1000.00,1000.00,1100.00,'2025-11-06 01:47:11',NULL),(12,12,3,8,8000.00,1000.00,1100.00,'2025-11-06 01:48:09',NULL),(13,13,3,20,20000.00,1000.00,1100.00,'2025-11-06 15:00:34',NULL),(14,14,40,10,31000.00,3100.00,3999.00,'2025-11-06 17:02:32',NULL),(15,15,3,1,1000.00,1000.00,1100.00,'2025-11-06 17:52:15',NULL),(16,16,3,2,2420.00,1000.00,1100.00,'2025-11-06 18:57:29',420.00),(17,17,3,2,2420.00,1000.00,1100.00,'2025-11-06 19:09:49',420.00),(18,17,41,5,7574.60,1252.00,1377.20,'2025-11-06 19:09:49',1314.60),(20,18,3,2,2420.00,1000.00,1100.00,'2025-11-07 22:13:37',420.00);
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
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalle_venta`
--

LOCK TABLES `detalle_venta` WRITE;
/*!40000 ALTER TABLE `detalle_venta` DISABLE KEYS */;
INSERT INTO `detalle_venta` VALUES (1,1,8,10,2000.00),(2,2,2,10,1500.00),(3,3,2,10,1500.00),(4,3,41,4,1852.00),(6,4,2,10,1500.00),(7,5,31,10,2500.00),(8,6,4,10,100000.00),(9,7,8,10,1400.22),(10,8,3,10,3000.00),(15,13,44,2,620.20),(16,15,8,10,1760.00),(17,16,12,2,100000.00),(18,18,8,3,1760.00),(19,19,3,2,1100.00),(20,20,3,5,1100.00),(21,21,3,10,1100.00),(22,22,3,3,1100.00),(23,23,2,5,1500.00),(24,24,3,5,1100.00),(25,25,3,2,1100.00);
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
INSERT INTO `negocio` VALUES (1,'MaxiKiosco Molina','101010','av. codigo 123',_binary 'ˇ\ÿˇ\‡\0JFIF\0\0\0\0\0\0ˇ\€\0Ñ\0	( \Z%!1\"%)+...383-7(-.+\n\n\n\r0%&-//-----------0-----+/----------------------------ˇ¿\0\0π\"\0ˇ\ƒ\0\0\0\0\0\0\0\0\0\0\0\0\0\0ˇ\ƒ\0N\0\n\0\0\0\0!1AQa\"qÅë2B°±¡#3RrsÇí≤\—4Sb$5ctÉ¢≥\·ÒTdÑ£\¬%ì¥\‚ˇ\ƒ\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0ˇ\ƒ\0*\0\0\0\0\0\0\0\0!1AQ\"2aq#B±¡R°\·ˇ\⁄\0\0\0?\08\√]\√C™ø\Ô@\Ïn}¥É|Òy}\»H≠ká˘#~\\ªxk\ÿh]\À\›?=\”ˆÄ®\Œ^âùs\Z™jº\Ã}\ÀÚ§)`j@\Ô⁄≠≠çVü £™\Ã\ﬂ\ÃÒ$˚\Í=µî\◊H8L1EN,ŒíPæ˝Ú;\Ã{ibÙc˜\Õ˝Ù˛u6FH\“4à¶\◊vYŒ≠#\¬=ï~üíR.Qml\Ë\‚>Ú:u.É°∞\–€∑ïZ¥<U˘\‘o‰µèsDv)_ùOI)\◊&Ñ?ì,D$ºü¢\·¸´Éf¿Û_µè\Ô¸\’lM(/öÙ–än\'Gõlµ\◊ß\€j\Z[\\\ÔJOæ¶\›…§*ö\‰\–¿±\€w[\Ìm>\Íâx[-¨$-o¥§\‚	Ä\‹ˇ\0⁄•@diíï◊â®`\ÌxW+\’\nJÅJ®±bªI™≤é\◊i5⁄Ñ=^ØW*vΩ5\ ıYBÅÆ\“+¢°\◊i \◊jdäq_8˙´\ yPz\«(\·¬πÜù	\Àı\œÛÆ≥ÆFu\≈\Â\nıRzebà{E<§Nî\⁄”ßhˆ÷îö#H“î\–\Á\„LZ\€\n\À\—;\œ\nîE1lGQ_D˚+≠D¶\“ e∫ñ\0\‡<+®o!K\r÷ä\ÿJO*Q4§∑K\Ë\Í\∆IÆS˝$\ƒT¢X\‘W∫:tê7èMªhBc\“\'I#>}ú\ÍMQmÇ~ }b=ı{”£\Áß\ƒU^\—Y\À\Õ7\nV4òê 	$ír\0q≠E§»π.t\”Hµ ˙Cø)DÓ••\‰\”˜áèeRh\ÀL\Ï“¶ôn\‘\Ÿ\Ã8àÇ©\ƒ<\‘\ÊU\ZÅx®\Ì\ﬁ\Ïƒ©iL\ÁíL&4<™µ«π4≤¿Rí*/ÜIÛÚ\ﬁ`úÜµ\rçßAÃÄ\·à\»\ﬂ\nr1ª:\À\…‘Ω\Ï_]Ü\Ì\€UÖI\¬™ Çï\'(à\ 33˘˘›±@Ù¯è∫´Õás^Tª±^\"É\€U+i#\œ\Î*$ÄÅû^pß\ÿ8ta]\Õ8jy±+Àê]ÿ†”µ∂É•ô\Ó\Î;ß\›^˛Q[Nñgø¯ˆäø1\Â∞\À\r ®LHì$	\Œ§Ò\„BJæmÒïô\Ÿ\‹p§{k\Ãﬁ∂î+•¥Y¿î)8“§\‚F\"	QDôOTN[™¸\≈Ÿï\Â¸Ö\’\—U\◊=\Íó¡‹§\Î\Ã9UÄ≠ßf\Z°u\–iªVQå¶˙G/Ù•¢¯oL*\Ó\œ:}∞7\n\ÎnJg∫∏iÆ\«VòõE\‚\⁄¥Ñ∏¨*Rd!Ppòù9RSmJè\…83\Zå>\—Nöª˝¥\€\ \”=‚µ©v*æC1k∂ë!∂\«#3Ï®ñ´U\·\Ê\‡H\"±á™>t&9QVtãb∫ä\Ï5”ÇﬂëF˛\n;E¶€éP\◊V3q1íF#N¥\“_¯kâ	¬ëÑ æ4åı\0\·\›Oi5|I*!`\ÓP\¬{DîüC¬≠\«\‰´)\€b\‹r*Bºp\“ÕÜ\€˚∆ªÀá\‘E^\ÁJìSJ.\ V\Ó\ÎO§\Í\'ê#^\Íqª∫\“á\·	í?\"*\ﬁMxW•l†;<\È\÷\—?\›«Ø-õå.«öÄû©\Ã	Ñû∂\È#(“ØbôhBîù«¨;¸\·\„ü⁄©HõïNl¯\'Âñü°\€9\’mÛut\r(•\ÁI\\ \‚Rt\ƒb¸\ﬁh©I°˝≤p¶\Œ\Ô\»Ú´QLµ»ß6Iàüzp\ \"•1≥\Ã62I$Hï(®ê†Aú\ŒD¯\‘\‡d\r\ŸxRú\Í¥G±ó\'‹ÅmπX	Ríà$™§ıI\0\0˜TÜÆVBÇPﬂçfr\"ù3öíîÇ \Á9x\◊Yl\·ZåèvSﬂ≠M+±V˚ù¥2úûIëàØ∫\ŒR@e∏P‹Ñ\Ô:kN%5\À*uO\Õ1\‹s¨ª™¥Æƒ∑\‹f¡eh†∂âIêp&JUöwn\Õ?bß6\⁄âHû\0\nçhHKàY (2@ëí{àè∂j`EB)p\Ë\‡§ﬁÉ#\ƒ(¯TåqU˜≠•¥≠))X9ù\ƒô\Â\nû\Íî’°\nå+J§H\¬Aë\«*äJ\Í\»„µé+\ÿ\Î\ƒW¢;\“W\Î\’\‡j\ (Æ;iXÜ@∫Û@\nI)\–(ÑUs	8[;æhˆ\Z≤J™%E]Úp\◊EqU¿j\ 2Ø2*\€f∂q\ÎSjZ6Çe[\Ãgë“´.ª•\ÎKâJ†@+)8R7ô9\Õı≠XØÜl≈ª$%\…)òJâ\».Ií£\Èq5ƒÇÉïIùIjJ\“3UÑ\Ê[\nP	ìñ`$f£≤ì¬™Ò\‰;El\Í-\€–†Å–∏$¸\’úHW#$É\⁄8Vi∂˜Jl∂éçjÄZS>h*\",≤\Ì\ÂZñ)E[\ÓEí-\“F¥ãr∫ä\Ï5≈Æ+÷ªäa\«Ba	mJƒ¨¶ıF˛\›9\◊JQ≠\…\Ï›é8⁄ñÇîúÉx§ÇFJ*è\œ\÷5|_}° ü9D8â\»∆è\⁄B\Ÿia3ÆßR|k+\⁄b\À\ÔñY\'ê\Íî\…\¬Dô¡3ûgﬁßà\»“ª§1Ü+™,.Õß[äB0\'ô8Äû \Í£¬âX8ÄPP ˛£ë¨Æ\ƒ˙lÀáïπ“•í\ní\nî¢zÂ∫¥∂âtfìö\–7\r˚O∫µ\·ÛJI\Í\„øs9`ìÿªé5\€iK|\‘DÅŸº\€◊í[H$\»\"ReYOTUE\Èn	io)IRD\'\·\‘≤%]™´Ò>\'ÀçG\‹L8u;|,óÖ©\€C≤¢õ;c¨¥Ñëè)i$è;1≠9kº‹ë\÷)\0\r›ßS\€U;¥\Èc•´\n]t∏F$ıÑØõ Në¨’ù˚±\∆\⁄r¡i-π ≠8÷¶c)Rbp \·\–»à•ûíß´˘≤\¬?©Tã\ﬁÒE≠∂>=D≠ =.∫\0\¬©$´&\„B[\ƒ\ÈQ#$î†ÒN!ô\ÊGu;p\›(≤48‹Ä\·\0\À\—ÖyLºõ(¬µ )¿ïap \‰x\Œ\ÕÙ\Ã\÷:õ\‹^Z\\\Ó<ˇ\0 ã$™UiY\ÃI¿D\Ó33\›®\∆‡ªê\‚KãÖ\ÊoÛπˇ\0°¨üd∂e\ÀsÑ!E-ß\Â\"@\‡\0ﬁ£\√(\ﬂ\œgπ\ÏIaî≤ïî òì\ZìjMRñà\ÈE\Õjv¿ù≤Ωæ6vK\À$©xPï4\÷‰ÇÄ\0*3úLw\Zπ\Ôu\Ÿ\ﬂ\ƒTJ	¿I2™\œ\“\Z˜F˙\–ˆ∫\Ím\€SIZ†˚kh)*¬§≠-\Ãb\ZPã˚\Î,®≤°\’?*\Ó.	JR7ú…Ñ∆§R\ R\’këï\È¶ÿ≠ç∏HBÅ)â$N`\Â®#0FFõæ-ÇŒûî¡$%\“P Ö\·Ns\∆@°v∂Æ\√dê\À\Ï®\÷q\0¨É©\ƒU°)›ñ\\™%∂\ÈîaB¿ﬁ§®\‰LSR\…7\Zˇ\0b\ÎuZ ^6∑^%Jƒ≤u \0ç*5\ÿ&\ﬂK\n/b	\≈\r%@\‚\0y\«<\‡úÄ\‰iª\÷˜:6¿B@ÛS\0ve∫Æ,vºL∑1#\’Æ=î<	kŸóôµ\—S∂7rûF&¿\È†À¨üõ;\Ã\Ê;¿°\rÑy\≈Z¶JR\\◊´\0x*`Go\n?yS˙˝~¥\„]k)0:ê\0:Ò\Ô>&ç,K^†Q\»Ù\Èc∂z]\n\√\Á!E+IâI\‚ É¿‘ìYìñı¢\÷˚ç™IªB@Ç7\Èù\‹W˙Upz3íπ¶}ï∏fW•ôñ-≠3^êk†\”	Äha£\r∂?\Êüˆ*¶$\’s~k`\≈?\Ï58\Z—ë¬™\Ê*nk©5Eè-†$´bG&5à\"≥-¥ªù(!EQ\÷\0±0Sƒèul.∞1£5î◊Ñ\Áë\0¯\Z\€\∆\0SyaPOY) \·ú\"FÏïó˙WJ∑;w±›ìÚê”ç%6ßN¶\…¶ò\ﬁF£è*Õ∂\Áhïnµó\’CH\¬\ﬁPp\‚íU\Ã\Î©õ\÷œÖ\¬uú¸uı”æOnèÖﬁç4°-\Ê∑F\‚Ñuà=™¬üµOC#»®Vpå75˝ì±)VV≠6¿\ÀN$7ª¯V¥ù\‰A√∫|}^J]é–µò\Í-<\‚ÆöΩ-*]Æ\–≤R\⁄\¬>nM\ƒ}\Ô]5Xp\ŸZ≥•ò‡¢åé|£?ıÉÆA¢m\›yÕ¢ \Œ∏eá\‘d\«fQ∑7\„\Ã\€\ÌHo)-†*:¡∞ôÄ≠u*û\ŒU¨©†m\…#)b7d\”\‹h:ˆŸ¶\Ì6øå’©k\nDíú∑3\ﬂA»ìU%h,[Ωå\‚Î∫≠/ñ‘îu:A*\‹0ê¢I&µG\Ô\““äû\È¢SÖ9%&<\–7òú\Õ@º\‹¬ûâ¥ahz#)ÅCi≥)JVQw[M˙Lí8Û\Ó†yΩE\ÂÎñûÅµæQ\“$êåFùp$ê`\rf3äΩ\Ì-)Eˆ±£•=d-X∞¨˘\›mTì®ù3£øÇñô%^iIJ¥X§AL˜˜\÷mm\Ëí\Œ\0T\\C§)X•)ú%	\√\"g9&#ùg-∂˚óí]AtXî\È\Ë@d˘\«\Õ@Ne\≈\…\0*Ov±Z6\…_≠¥\◊¡\Ó\À*ûBTªCä\Ëõ[ä»ôÇ¢;\0\Ó°Ç\‰Sân\∆IJûl;i1jÃÉ(l\»\…N+	 ˙)ÆY\Ó\Êôa,∂ú(HÑÅ®;\…3ôöqp*˘ìÂç§´¢\»\Í3¬¢ï!XH0AFjuˆZº,ÿ¨KCÅJ@ç\ÈYq\"5NJ:¨˚\ EŒ†\ÔNî¸U¶Ê∏§\‚qÅôWè\nÖ\‰a\Â¶ÛBR¢§9ån!)$Ob†˜Uøk\"\⁄H⁄ùqõΩñl≠êújÇ£ë;\‹uQø_–®WØî[ü™]R’ë\¬\€jQ2H	Ç:\Ô°\œ*V¨.\ŸL\Âåœ´\›4~\Ÿ:\ËYs-G\Ÿ≥\Îj{\≈(ùªcziR4K\÷3yØ\nYuøÉ©/Ùã1•! \n2|\r3¥Z9IO\∆!\«|èu˘=\\\"÷ë¡ïx\Ì¨ïé\œy£E&Né_é∑k\¬\ZX[∞ÑúîyA\Ìœ≥Zº∫,(∞•M!ANÆ\È\”MG\Õ|f™∂2 ÑÙñµå\–p5;îG]^#\Ì\Zëko˙E(ïÉ#	)î\Í°\·\ﬂX\À+zz˚u\'∫\· í{\Ëøf’ä\Ã\Ÿ\‰GÅ#\ÿ(¨\‘I\·;ª(\◊cúñ˘´PÒÉ\Ô´˚H\Œ}\‚]tØ\◊\Î:n\‘p†ûG\Ÿ>\Í~j∑h\¬\¬\œüfTëûYÃï+äî|M&\’ b£\€˙Mçp ¯˛t\Â≠C	4ˇ\0j\Á7nŒÇTÇ]ó⁄Ö_39%gPx+à\ÁFB±[˝h;\Ã˚´`ª_\Èm{\ Dˆ\Ë}`\”xf¯bŸ†πB9#˚Sˇ\0Ñ’Ä™÷º\‘j{ö±ßRí)KI™,ª[\Ót¡∞òAlíØ\„&0å˜\0I\ÌìmsÜ≠âS\ƒ)/0î\È\0\Z»çıß\Ïe\Ì´\rû\—2V\⁄q}4ı\\x*Üˆµ¥Æ–∂∞\‚ZlvßQ;ïâ®éq\"y\◊$ø\‡\Ècëó\ﬂ)î\»\‘g˘—ßê+§:∂JÖù@\08\Áé&˛\Ìºd≤â\Ó≠C\»\ 0›±ºæÒı§g\‹\¬ˆ3\‚x$≥g\n∂\⁄\“GúY9\ËAé\…@û@\‘\Ì±_ÛG\«ı.~ù\"\ÔPˇ\0\‘-3˚ÜΩN,u3∂ã5£\ÍW¯M1@u∂+¢∂\Ÿ¡F{“§\‚HÒLUe•\‰†8∞¢B◊îÅ%)Ríw\ƒ\Ín\Ÿ>P9i\‰\Z\·\–«çm=¥J\ƒJÑÄ@\≈*\œ044\‹Pl}»óÖ°0THì\ﬁù\◊:Û\Õ$\"J†\…:\√H˜Ò”ùPΩy§©)ú FDd \rx´8ˇ\0|¢€Ø®DùqÇtÄ÷óP\‰=µ[H\»db=& ±§\'q\Î \Ì án$∂Õ¢\»]2Ö)í#)0ô¬°=ïMnµ©\’\‚Q\‰9R\Ô\À)GF\"ZNß#î\»\ÂSJ	%\‚˙õn]çØcÆ7\Z[\Ân©jv—åª\'\Z\€BAJV°ßYKwF\÷\ÎD\"w\0ST;&\ÈUôóTòRöJé∫¨b#\◊SØ5ê√ä\»ıúúf}~™ëΩ*˘-\’\Ì¡ù[mµ]Œ¥ç\€3\≈¿\œD•b\ƒ\'pM°C\ÏSûGˆh6≥jp´§qtI\ 8“ûëYL©AA;°$\ÔUsé‘á˙\Èl\Ÿ\ÿ[¡\0§(-9»Ç¶õI\‰£ è6\Z–∑ïj¥8\0*ËêîçÑ•KJ\0\‹\\F\\™ß*F°`∑ïı\‰ ∏8Gv\Z¥z\◊fb\œa¶ê¶≠\r!dM∏§\„AùBN%Fê\ZÚ¶\Ê&î~j\«n±N˘Dnnã/&\Ï\Á˛\ÿ´K\Ï<ù7]ã{ö\Î¯+v¥\Í:AÅf&\¬1\"8\Ê≤\„ïgÛÿû=â˝F∑CãM\‘\ \\R‘•!J\÷!)ítHFº(ÿôµ©?\«\Ì¶ ®\›\Ó^Ñ\›\Ì£zÒØ\Ô(\·ıaØX]\∆\“Vu#>—ëıäù6î hÑ•?tPl\r\√iqÒ˘R\◊{¸Ü™ãvﬁ´â\‡AÒ\Ó°HŒØv5\»yI˘\»>#1\Ô≠\‚u$c\"∏∞\ﬂ\r\Ì´∏X#â\⁄}\‘E4∑nı8™|?:zO\“ƒ¢ΩHb∏\Îs;âıö[C*n\‘r=ïŒΩŒÅSeÛ\ÎV\ÿ\◊Ò1ázO®\Á\Ìö…¨Ü≠b-º?8\Ô˜z\Ëu4J\‚¬ÜìÒi?ÛN˛T¿j3#\‚ø\Íúˆ*ü–àã)I¶\Èi´(¢Ú+oñ-Vu@,Z\0	KôÑâ\“J˜\rt1#§æî•dèÅ≠d©\‘\‰{£√ïPl\Î\ f˘µ7à$Zl¯Òeí\€19\‰H\Œui≤W;\Õ^Nï©\◊\Ë’Ö\«k%i\0\«)X\ 5\Á\\YKSM(*L\Œ\Ï\‡îîôê0¿ôXç\Êkiÿãëv;L∏>0ï8±¡N\¬yÄô\‚(\'\…e\”\”\ﬁßV%:\·ßHß\‡èhMj6Öª≠$ûD\Ô<`eL\‡Üî\‰¡gùµUóbÚP˘\÷uO\Ÿq${M9∂4\ÍW¯MBNWì_\ƒ\”\√\√\nΩ\’3kS6;A\‡ÀüÑ—£…Ç.\◊ *\»\‡æ\ÈÅ\Ô\‹NY\‡Ûë($Û@ ¯GõH~%|\–Gèn\Í∫Vbµ §•a\'@\0JyıI\œrwgC ïYºfii¥\…V©ô\Âªı\ŸQ\◊\'2j˝wJI:\”7≠\ÿ\ﬁ!∫\'æÖ—¥ëßçÚ\r\∆t~ˆ\Œ¸&\œgQ\n\«\—!)PP\0%+Éñ™$,v`ûD	Mnè´fLyÅ\n\œLíqˇ\0lUxôµ(%ÕìSR∞∂\Ã\»m	FÄ\0û\‡0˚©õ\›3gtn¿®\ﬂËöíR\"9sˆTS\nT A⁄ü£ò2\Îñ\‘HÄ!W}•ΩuSK\∆&7Å\Ì≠\…\“n\Ïq\÷\‚º¯+6∏láL\Ã)6ãeóΩ\À<$ú¥ƒö\‘\Ó4twcOâJπı\∆3¯®YÇ\·\‰Ã∂û\”“∑h\ŒaF9ô{¥\ÕÆª*\Á)ñRúıQJR=t*µbf\÷yOâ4gr\Âé\…3H2¡lòÄ3ô(|%ˆñ˛Ñ\ﬂ8ú#\Ã@m	L\·(8ZL\Ó\n\÷O\0ûwÇ\Ì\‚2\’\“Lû≤≥\Zà:2æ9úÜíF∞IX\ﬂ	JS‹™\ÿf1?hx˙\ %ì$w\'¸Tv\Í-Çj\‰ëaµ\¬TÆtã7»¥Æ@û\≈k\ÌûÍáµÜYTjTë\‚°Vå†ti∞Å\Íä]{P_\ÿiG1S\Ó∞\⁄˙X~ˆ^˙®J∫¿AÉ\›˙û˙õg8Vì¿É\‡jì¶F≠\Zt\–&\€.VÑÿö8Q ≥˝´\\øæ\Í#¸lFÙV62¶Wú¯~ΩU#w*ä ≤û9¯\“yî∂3\◊X\·ï\Ïıß“Æ|üP4.Q/ûz£\›Wcê†|}ÙY=\Ï\ƒV\‘jç|ó˝Sû\≈S\È®WZÒYPx\⁄=∏L\‘\ƒWJ\Á\…rvîäE)5≥&}¥ñûÇ˙±;πJ¿r\‹\·¿D¿/J‘¨≠°/<º)∆¥$\‚\0R§DŒÄÄ~\›d~[—Ç\—fSf\‘»å0©\Z÷õny’ßO≈∏¨Œ©(Jô\“0\œ,5\√j°˜¸ˇ\0”§∑ìDo%≠tvW\\ˇ\0âµ\⁄ÇB\Ài(Q\Ô¢+K∫ô\‚b3\Â˙\ÂC\€\Êæ¬ú˛EsÛú8\Ã¯ö∂∑ΩÑIP9\∆S\ÃÓÆè\nÖ9vPπ\"≤©G2]-+Ú©;XøÊ∂ü©sˆT\Ÿ»µ\ÿ\’˝lH”¨⁄Ü\\≥©õN±KG‘π¯MTy69¢æâÁ®¨û∆¨%Û\≈q\·\'\’5™\ÌÄ∞\·\À$Ú¨ï\ÂAX›âGºü\»\nàˆÖ\√\»\ÎTãı@Y\÷xàÒ1K≤\Ê*∑kChN\‚©=\√/m%ç^DÜ&\Í-î+8\ﬁ@\Á\'∫∑]õV U¿%?Ø\n≈∂a\‡áqë0ï\»\‰\"µçÉynY\Íıqk#(Ñ\‚¬ë\Ÿ\0\ÁM‰ÉñT˙!xKN6ªÖ£*≠æ≈©Yd2¯j[\ÔDÚ\Àı\ÀJ™z\ÿsA\ D\',â3ô\»«Æå`Ã¨wâ÷§\‰mç8{Vú\n5≥\ﬂJ¢ò`¡XV\—\Ÿ˙vg\„\ZP=™ôÒö€Ø\◊2ÒˆPsÉ`\Âò\»rµéG‘£∫ãˆ%\“liß§\0àﬁ©\ G?\‘\–5µXWiO~\ŸM≤ä˛f°1\◊P\»\∆E\Ó®\÷≈ß∏ã¯êí1IsS*VG39ıè˚˚c\Ÿ\√cRˇ\0x\Í\’\‹¯MDºVÉ¡ìÅ@∫[]\Ì`≤2ç!¥\œjÜ#\Î&¶WÈ¢†ΩVS\ﬂ\Èñ\œ\“G\„dœö;*%\ËôA\ÌO\„-ì’°/iæ•Y?S\ƒ≤@W®è\n±:¶Ω¿ÛK\‹±YQû\ÍΩ√ù\\ó®æP~”≤Ñû)\’Y\ÂÙˆ+BπQõVà≥É¸\Í#\›@O+\Œt\ﬁG¯ÖqØ\ z‹®Dq\ÀÛı\„L∑•z‘©Xû”ß´\€K*S†\Ÿ\÷\ ss\“\nJPQ\'∆óeT\ZM†˘\√v]\ÈP˜T∫C&∂¯0π5mûTÿêØW±Ud\›TÏ°õ^Øb™’∫\Ëc\·}	Oóˆ(\◊Q\\5\‘QAOïõ\≈\≈ZôR\⁄Rá\0I≤	Y@)B@eï=µ;EéÍªêïıî í±àßxú\'^um\Âb\Îm\ƒc8É\ÕõBYùQRÉä\"1a∞Ç Dà2h∂≤\Ïm§©Ä\ŸWF˚≠2î\ póíJÒË†í@\¬wNö\◊&.:bò˚OSfõ±iJ\Ó\Î§àe	T$$e¯QEù\r-å(@¿FCàô\ƒxì¨úÛ°&9\›)h\ÍÇÛgπ\≈@\"älvÑ°XDéØ,ÑG™ú±zvë *Ã∞<\€C~ëv\‘Õ§≥ëf¥dse\Ã\ŒìîLö\Ê\’<Ñ∫\∆ÄÕ¨˜8ôéY\‘Õßµ©VkDª	\Ë\\BÜgÅë™\\õ+vä⁄ìf\"êDßXN`\Êê1\Êr¨\∆\÷eg¥˛U£mÍßêÍê¶Õù≤R§•XúyPu\…;≥8U}fQ+Q\›4∂pÿâ6w¿I$\ƒk;™¶˙¥Öå§¶\ƒx\Í\0\’nídvˆU]˛\√iÑ®I\œ\ÊÉÀô•ÒV∞ô/ISaª\›ZR¥ÇîúC\Z•(ÃÑ\·≈§\Œ\Í\ﬁ.+(eÜôô-°)\“&wô¨od.≤Û¨ìÉä?Ö*\≈\'à$(\rt5¥!\Œ]≥¨~ç<›∂,ñ\¬-ã¥◊èá=Ù+µ\◊\ÿh*∏H<µ\ÂVw˚˙¬¥\Ìr\ﬁ\'\◊YM˘h*Q$ö\“VStGº\Ô%:\ÔJ≠\≈ü\Á[•¸¯\À=FUÛ\·A0ë©Å\ﬁr≠\¬¯WyJbOe\ƒÙ\r\·ü&[\‰˚ºÛÒLQ>Õú6Y‚≥ó\Ÿ\"Öˆó\Âg\Ábø÷ã\€m(aÄÄ®V÷åÒ4¢òÙfu\‡j˙\"˙≤æÙf|çT\‹wd\Íˆ\Zº∑#p™´X*8tOJ\“\Ô¯¡ä;Ò\Ã\Í}∞ ®YzáR∫\ﬁ:áªÒ\nqï\ÂI∂é¢˚	ŒòaÒ§˜\n\¬\‡\—[¥M\ MY‹∂≤\„(Q\‘uU⁄úßø#\ﬂPØPH9*6»Ωq≥ºé\—\’Wµ>^aÙâáè\⁄b\ÕæÛ\Ô°3ûrè\”\Ÿ\„WΩ£$r\'\’TñT|X\Áü\ÂD\»ˇ\0LA~Ihgy2jNÍéáF\È=∆û+\ÀC\·@@µ*ûxì˜êR=dxR[U7xÆ\nAÑ©$\È†P&∫÷îW\Ì0Ω∆Ø±\Ÿ\›\Ì˝zøÚ´Ñ\ÍÉe\Ã]R?|Øx´;°\“A\ÃiN√ÖÙÑ\Â\À˚µ\Ó•YUM\⁄úpÆ∞h¿ä+`ã0	\Ã Ö\ÓB±8≥\≈D\n£⁄ª\≈¿·ÇßSå\0û≤e \„˘ΩP0Û&âº° ≠)nD\n\“B≥n>\⁄⁄ªAUí≈ôÇ\“I\–z9FXéZ…åìdé?SØü\Ë\Í\À`ø\»\Í≠≤\⁄\\IOF-HQ2J–É	\Ï$gŒéúF¡:\0	ù\„ùP˘+d1s6H\Î:•∏y\‚^ˆıRöµ¥πàgr\œı∫}ó v\‹+‚∫ß\”Ns\÷t\„≠si6q•2ßôu”Å≤‚Ç∫\»=\\Qè \À=FBò\€uå-§:\—∑ú≤\ÂWñ¥•wn\'%dYì8!≤:E$+<Ù1óÖE…§W\›wo¡l´S§|bô@≈Ñ)MAp\»óÑà$ú\ŒY≥\n\ xkZ\Ó\◊[eéå†©kL!	T≤RNå≤:˜\÷B\ÿ¬¨∑z\Œ˛\Í[8lbj)=pBNYkER[\›^\"f2\Ìèx3\ﬂE©µeê\0û<hz\ﬁ€ä\n+DÙrT£!Dù¿\ÔH&cÖcï^T\Ë+ÚxÖ(íP\0ëTz±\« s£\ÁﬂÅòÇ<<˘9≥ÑŸä\‚\n\’3\…#Ú\œçΩhd\'ëÒ\Ó¶j¡]¢áh\Ô\r`Úêy∞Ò¨\Ó⁄π=ß}\ÌÛ\·\'];\„ø\’C ç\Z(ô6\·gÆŒòüçG=	ˆV•¥O\·ûqòS\ÿk:\ÿ\‚k\ÈHKm∏µ\ÍAnG>æ\\\ÎH}\‘4êÇe≤\0\¬bSîDn•<Cı!ØΩ,\ÕˆëR¶\œ3\Ïï\ÿ\≈g≥\Á¶\0;öÉCªh\ R\‡¿e$Çh3V˚=h˛l\Ÿ>Çï˛(â≠-\‚â˚1nÆm-#rOjgÙSµU`\·\Ã\’5\ÿqZ˘ ,v®ßÆ£Ãí|\\,–≤ÚÇc\‡a\‘JT8Ç<DU}Å \ŸVi5Sfh\Êà$d8sXFòı\‡\ﬂV®,tvîVˆ≤ˆë\·Vˆ\Ê\…©G¥í<(iˆaYeEŸ†9ˆm\ZàBG\Œz\«\ÁMæòHpä]\ÍzV\Ï\Í\‹Dˆ\'\÷)V\—Xî∂K±®≠\€ \ÿQ\'îx©†\ÂQ\‘hHù¿“ã|û\“MS4∏!^Ëîöf\Ô\Õ)\Èõ…ë†´KSªCàPÇïf;@>˙#^Äk\‹h72∞\›\ﬂ\ƒi\Î∫\“RO<™5\ÿˆeru_äπ`TÄy\njtæºñ\Õ¸≤\·*ô4˚Uäí\›2Ö\ÿ;\ÂFˆCIh\‚KIRF†ÄIﬂ¶\Ì’õ\Ìº-´*PVŒê˘*\"˘\»eœùP>µòƒ•	$\¬FÄpúπö1≥\\ù{¥˛ıMuw\√hB\‘N\\\»ﬂ°\·\ÀX£éò˛∑7FÉm⁄´ç¶¨juXòm¥\€k\\Åà\Ô °≥\Â\ \‰OJå≤ñgMOUdâ Æ-keejiù\Â	íyòœæÖ\Ô+\ZeBuìé£Ez5h[}ƒíg\·%ÄD\‚<≤£u\⁄\«˛ôÉ2MïCëÒd2#Ø\n\œY≥A“¥AiBn¬Ç\ÍzCf\\\'AÑÑú\Œ]ÙHÚç∂òìg8@ït∏g!=P\ÕQñ§Ú¨y/C§AÛàı\≈j;b\€\ÿ:\≈\"0ôJï\0ííJAR\’¿\0ôä\Ã^G∆∫p∆¨$¿q\„≠-Å-0LUU˜nw\níò¿z§Å÷ù\‡ù*jì\Êìœ´\Ó5\÷˚!\‘b+\0-gD$\…8}-\0†bèØπºè\“h7=ô∂Ù)HÑ\Í£\„>5˙´\0A\œS\ƒœÖ:ãjF6‘ïßäL¿\◊=\‡\≈TﬁØH\«\Zqæk¡ﬁ∑Xıdbçp\Œq\Œ7Tê\n\‘R!$í\0dÅ\‡E\"ıv{ˇ\0ﬁü`\ryeW\‰\Ó Ö)\“L©*A#¯á˛\‰∞*M\Îd\\ïÃÇI\À8\œ}T\Ïï’ò;à(≠e\"N&Dû*WÄ´vØDìâ$ˆh|tûTı∂9â≠	˜”Ñ¢¢†G~Ui≥ñVûëﬁà>⁄´æ\›+*Q\‚<f¨v]p”Äk>\·\ \"ˆò~\·˚†√≤uR\’\ËQ ªU¢\‘:vcBÓª≥IHèºGu(–≥-\¬\‚{\r§\ÁPõµè\‚>º˝ı4\näáO0™=\‘ln\÷2°ªj:\‘MiP˝¥gF\∆˜4^‹ä\«fHﬁá=Ú=Fü¥äÉ≤\Î\…\‘Ú\n˜~U6—°¨K\‹j>\“:k™ÅK:T,ÆKxûBx≠#\≈@U\÷‹¶/KGP|YED∏\Ï¯Ìåè\Î{ÇÅ>°R¸•∑7ÉÎû¢R\÷\"uãhÑ\Œıuìê\„úQ\‚Æ ©7Aˇ\0\Ÿ\\˙\≈{i7.hI\ÂQ.ô7±#Æw\Ê:\⁄\–\≈\›w\ﬁK°	˜EâG\Ë\Z\ﬁ2˚4∂*SB≥ª)æDë—∏¨\‰¸\‡ê®\–nP©\Õ\ﬂ˜£)bü¢í\n\Õ0¶\ƒ\À\Ì(Ñ\∆Ò#¬ãˆùı\⁄á\ óz¿-A\Î6≠¿NGY°kV™\ÌÑQù\Ô˝a˙ªGµ4Ñ\ﬂf+êYç¶∑7!6\«˚\·XT÷îô[m©FT¶“•ÑíêMdj[´ac\‰ô˙ñˇ\0£4å¶\»Jk:8{n“î´[2î≥R\n\'$\Ô\–O<\Ë&¥Ùcˇ\0RØ˛∞©H¡›§B:$!!XR1bâY,ú\Ã\Èë\–iêåˆ\’r%≈®\„XúÚ\√TgQ åØ?êG\“o\ÿjåj[\Õf\\ö@˜ÚiyZ\Ì@ˆÇ*ï6;S\Í-%∑]RL\¬PLnì!ŒèÛGej˜W\Ï¨˝KÑV¢ïòó\Õvõ∂\’dXed¿ëú\»\ÎŒÆl\Àu\€2\›Y¢dÅ k∫âº∞~\–\◊‘ßÒ9U?ÙmØ∞˛[2π\›^5LG|\’˝\…`\∆Tì¢@ò\◊\Õ\0\n†fåˆkEs\ÏMjF\"SﬁóYm\È\0ñÒ(ÿí†\'éì\ﬂQÆ∑±-,ëìÆÑ\ŒÙ‚Åó: \⁄ëG\“?‰¢Ü.è\⁄˙\‰~!C{\ÿU±y¥6â’¥\näDb$ü4Á∂ªpêÙˇ\0Òê}U;k?h_\Ÿ¸\"´\ÓoOµ˙\ƒ4ï1õQá¨\ÈNÅ\‰wúB{ÄÀº\—h!Iƒû∞í$i ¡œ∂É\Ì,\œ\÷ˇ\0\ÁG[1˚*~õü\Êä/ñß$ò\'ë¡:∫\Óï:®v\–’û\÷\\WY8TôI\0ìò:g¿\Õh˚?Øè\·¨\‡~\–ˇ\0◊Ω˛b®y±\∆+cxrJOrE¶®≠bØ_™KUÖêˆ\œ.\Á$ß\’V∂ÖeTó7À∑Ù™\Ê\”S\'∏ë\‡`\ZpiL&û\ZU[l@\ﬁ,\œñ™¥v\Ôàs<v\ÎL\Ó…£—§Od˛Ö@Ú˝\"\œ\⁄ˇ\0-U}aÙ?∂€ø\ŒU9á\⁄+ô\”%›ózE\‹˚ uzrëﬂùFn∆Üú!\"$ ë9N†\›V\◊o\ÏØˇ\0i˜\nÖh˘SÙS¯•∞\ﬁ\‚\ÓﬂêQ˘÷óø\¬üuNB™\ﬂ˚0˛\—hˇ\00\‘\‘\÷\‚S?ˇ\Ÿ');
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
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `permiso`
--

LOCK TABLES `permiso` WRITE;
/*!40000 ALTER TABLE `permiso` DISABLE KEYS */;
INSERT INTO `permiso` VALUES (1,1,'menuusuario','2025-06-19 23:50:07'),(2,1,'menumantenedor','2025-06-19 23:50:07'),(3,1,'menuventas','2025-06-19 23:50:07'),(4,1,'menucompras','2025-06-19 23:50:07'),(5,1,'menuclientes','2025-06-19 23:50:07'),(6,1,'menuproveedores','2025-06-19 23:50:07'),(7,1,'menureportes','2025-06-19 23:50:07'),(8,1,'menuacercade','2025-06-19 23:50:07'),(9,1,'menuventas','2025-06-19 23:55:21'),(10,1,'menucompras','2025-06-19 23:55:21'),(11,1,'menuclientes','2025-06-19 23:55:21'),(12,1,'menuproveedores','2025-06-19 23:55:21'),(13,1,'menuacercade','2025-06-19 23:55:21'),(14,2,'menuventas','2025-06-20 00:44:37'),(15,2,'menucompras','2025-06-20 00:44:37'),(16,2,'menuclientes','2025-06-20 00:44:37'),(17,2,'menuproveedores','2025-06-20 00:44:37'),(18,2,'menuacercade','2025-06-20 00:44:37'),(19,1,'ajusteprecio','2025-11-10 21:47:21');
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
  `preciocompra` decimal(10,2) DEFAULT NULL,
  `descripcion` varchar(250) DEFAULT NULL,
  `fecharegistro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `estado` tinyint NOT NULL DEFAULT '1',
  `codigo` varchar(13) NOT NULL,
  `stock_minimo` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `codigo_UNIQUE` (`codigo`),
  KEY `categoria_id` (`categoria_id`),
  CONSTRAINT `producto_ibfk_1` FOREIGN KEY (`categoria_id`) REFERENCES `categoria` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto`
--

LOCK TABLES `producto` WRITE;
/*!40000 ALTER TABLE `producto` DISABLE KEYS */;
INSERT INTO `producto` VALUES (2,'secco',5,2639.25,2,0.00,'3 litros4','2025-11-11 02:50:57',1,'10011010',5),(3,'Coca cola',10,1725.00,2,1000.00,'2.25 litros','2025-11-11 01:54:35',1,'111011012',5),(4,'pan',12,1173.00,3,1100.00,'20 kilos','2025-11-11 02:54:39',1,'2002202',5),(8,'Gaseosa',13,3096.72,2,0.00,'1 litro','2025-11-04 21:34:08',1,'1010100',4),(12,'yerba',18,150000.00,25,1400.00,'1 kg','2025-11-11 02:54:53',1,'21212121',0),(22,'Masita diversion',5,25000.00,21,2000.00,'dwd','2025-10-11 01:28:00',1,'1241556',NULL),(31,'Sidra',12,4398.75,2,2000.00,'adad','2025-11-04 21:53:12',1,'491915051051',6),(40,'Ravioles',28,5998.50,26,3100.00,'nadad','2025-11-11 02:55:30',1,'INT-4',9),(41,'Lavandina',15,1615.45,22,1252.00,'nada','2025-11-11 02:56:03',1,'INT-5',6),(43,'Detergente ariel',23,1173.70,22,650.90,'adadd','2025-11-11 02:55:57',1,'INT-6',0),(44,'Queso Roquefort',3,930.30,9,480.00,'adad','2025-10-11 12:27:33',1,'INT-7',NULL),(45,'Galletitas Terrabusi 500gr',41,3000.00,25,1500.00,'250 gr','2025-11-04 14:40:30',1,'100110100',NULL);
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
  `porcentaje_aumento` decimal(5,2) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `cuit` (`cuit`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proveedor`
--

LOCK TABLES `proveedor` WRITE;
/*!40000 ALTER TABLE `proveedor` DISABLE KEYS */;
INSERT INTO `proveedor` VALUES (3,'Taborda Matias','20123456785','3624555555','Av. Siempre Viva 123',1,'2025-09-23 08:35:45','contacto@norte.com','Distribuidora Norte',10.00),(4,'Arcor','00997733664','3644223344','ada',1,'2025-10-08 21:34:13','qwrqwr@gmail.com','',0.00),(8,'Manaos','09987674637','3562674455','calle hiporito hiyrogoyen ',1,'2025-10-11 01:58:57','manaookk@gmail.com','Manao SRL',30.00),(9,'Coca Cola','11924488472','3644229933','Av 22 de Mayo',1,'2025-11-06 22:04:08','coca@gmail.com','Coca SRL',25.00),(10,'Terrabusi','22233311155','3644116249','dd',1,'2025-11-07 23:50:03','terra@terrasrl.com','Terra SRL',15.00);
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
  `motivo` varchar(150) DEFAULT NULL,
  `referencia` varchar(150) DEFAULT NULL,
  `fecha_hora` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `apertura_id` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `empleado_id` (`empleado_id`),
  KEY `idx_retiros_fecha` (`fecha_hora`),
  KEY `ix_retiro_apertura` (`apertura_id`),
  KEY `ix_ret_emp_fecha` (`empleado_id`,`fecha_hora`),
  CONSTRAINT `fk_retiro_apertura` FOREIGN KEY (`apertura_id`) REFERENCES `caja_apertura` (`id`),
  CONSTRAINT `retiros_ibfk_1` FOREIGN KEY (`empleado_id`) REFERENCES `usuario` (`idusuario`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `retiros`
--

LOCK TABLES `retiros` WRITE;
/*!40000 ALTER TABLE `retiros` DISABLE KEYS */;
INSERT INTO `retiros` VALUES (1,1,100.00,'Cambio','Caja chica','2025-11-03 20:52:44',6),(2,1,10000.00,'','','2025-11-03 23:10:54',11),(3,1,1000.00,'gastos','asd','2025-11-03 23:25:05',11),(4,1,2000.00,'gastos','Molina','2025-11-03 23:36:14',17),(5,1,100.00,'Prueba','TEST','2025-11-03 23:41:16',18),(6,1,5000.00,'gastos','Molina','2025-11-03 23:55:48',20);
/*!40000 ALTER TABLE `retiros` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trg_retiro_set_apertura` BEFORE INSERT ON `retiros` FOR EACH ROW BEGIN
  IF NEW.apertura_id IS NULL THEN
    SET NEW.apertura_id = (
      SELECT ca.id
      FROM caja_apertura ca
      WHERE ca.empleado_id = NEW.empleado_id
        AND NEW.fecha_hora >= ca.abierto_en
        AND (ca.cerrado_en IS NULL OR NEW.fecha_hora <= ca.cerrado_en)
      ORDER BY ca.abierto_en DESC, ca.id DESC
      LIMIT 1
    );
  END IF;

  IF NEW.apertura_id IS NULL THEN
    SIGNAL SQLSTATE '45000'
      SET MESSAGE_TEXT = 'No hay APERTURA de caja abierta para registrar el retiro.';
  END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

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
  `escliente` tinyint DEFAULT '0',
  `esproveedor` tinyint DEFAULT '0',
  PRIMARY KEY (`idusuario`),
  UNIQUE KEY `dni` (`dni`),
  KEY `rol_id` (`rol_id`),
  CONSTRAINT `usuario_ibfk_1` FOREIGN KEY (`rol_id`) REFERENCES `rol` (`idrol`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'Federicooo','Molina','38962453','3644657148',1,'FNMolina','123456789','fede.099molina@gmail.com',1,1,0),(2,'Hector','Ramirez','38862453','3644657148',2,'EliasR','123456789','what@gmail.com',1,0,0),(12,'Prueba','Prueba','12312356','3644332255',1,'admin','admin','prueba@gmail.com',1,1,1),(17,'elias','ramirewa','12345678','3644555503',1,'124','1234','afmalf@gmaiol.com',1,0,0),(19,'Matias','Alex','1234093482','1159478201',2,'admin','adminn','elias@gmail.com',1,1,0),(22,'roberto jose','Moreno','222222223','3644656565',2,'rober2','123456','rober@gmail.com',1,1,0),(23,'David','Suarez','34568849','3731585078',1,'ProfSuarez','123','davidsuarez19990@gmail.com',1,1,1),(24,'Manzana','Podrida','34534567','3644882273',2,'admin2','admin2','nadamisma@gmail.com',1,1,0);
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
  `apertura_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `empleado_id` (`empleado_id`),
  KEY `cliente_id` (`cliente_id`),
  KEY `ix_venta_apertura` (`apertura_id`),
  KEY `ix_venta_emp_fecha` (`empleado_id`,`fecharegistro`),
  CONSTRAINT `fk_venta_apertura` FOREIGN KEY (`apertura_id`) REFERENCES `caja_apertura` (`id`) ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT `venta_ibfk_1` FOREIGN KEY (`empleado_id`) REFERENCES `usuario` (`idusuario`),
  CONSTRAINT `venta_ibfk_2` FOREIGN KEY (`cliente_id`) REFERENCES `cliente` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venta`
--

LOCK TABLES `venta` WRITE;
/*!40000 ALTER TABLE `venta` DISABLE KEYS */;
INSERT INTO `venta` VALUES (1,'2025-10-06 20:49:44',1,NULL,20000.00,20000.00,0.00,'Boleta','0001-00000001',7),(2,'2025-10-25 16:22:14',1,NULL,15000.00,16000.00,1000.00,'Boleta','0001-00000002',8),(3,'2025-10-28 16:26:17',1,NULL,22408.00,30000.00,7592.00,'Boleta','0001-00000003',9),(4,'2025-10-28 16:27:41',1,NULL,15000.00,20000.00,5000.00,'Boleta','0001-00000004',9),(5,'2025-10-29 15:33:19',1,NULL,25000.00,30000.00,5000.00,'Boleta','0001-00000005',10),(6,'2025-10-29 15:41:49',1,NULL,1000000.00,2000000.00,1000000.00,'Boleta','0001-00000006',10),(7,'2025-10-31 20:25:32',1,NULL,14002.20,20000.00,5997.80,'Boleta','0001-00000007',11),(8,'2025-10-31 20:41:07',1,1,30000.00,0.00,0.00,'Boleta','0001-00000008',11),(9,'2025-10-31 20:44:56',1,1,5000.00,0.00,0.00,'Boleta','0001-00000009',11),(10,'2025-10-31 21:17:15',1,1,5000.00,0.00,0.00,'Boleta','0001-00000010',11),(11,'2025-11-01 01:22:06',1,1,2800.44,0.00,0.00,'Boleta','0001-00000011',11),(12,'2025-11-01 02:15:04',1,1,2800.44,0.00,0.00,'Boleta','0001-00000012',11),(13,'2025-11-01 03:27:42',1,5,1240.40,0.00,0.00,'Boleta','0001-00000013',11),(14,'2025-11-03 20:52:44',1,NULL,500.00,500.00,0.00,'TICKET','A-0001',6),(15,'2025-11-03 22:50:28',1,NULL,17600.00,20000.00,2400.00,'Boleta','0001-00000015',15),(16,'2025-11-03 22:51:23',1,NULL,200000.00,200000.00,0.00,'Boleta','0001-00000016',15),(17,'2025-11-03 23:41:04',1,NULL,500.00,500.00,0.00,'TICKET','TEST-1',18),(18,'2025-11-04 00:03:53',1,NULL,5280.00,6000.00,720.00,'Boleta','0001-00000018',20),(19,'2025-11-06 13:40:07',12,NULL,2200.00,2200.00,0.00,'Boleta','0001-00000019',21),(20,'2025-11-06 13:50:54',12,NULL,5500.00,5500.00,0.00,'Boleta','0001-00000020',22),(21,'2025-11-06 15:09:30',12,NULL,11000.00,11000.00,0.00,'Boleta','0001-00000021',23),(22,'2025-11-06 16:53:59',12,NULL,3300.00,3300.00,0.00,'Boleta','0001-00000022',24),(23,'2025-11-06 19:21:40',12,5,7500.00,7500.00,0.00,'Boleta','0001-00000023',26),(24,'2025-11-06 19:25:10',12,5,5500.00,5500.00,0.00,'Boleta','0001-00000024',27),(25,'2025-11-07 22:20:16',12,5,2200.00,2200.00,0.00,'Boleta','0001-00000025',28);
/*!40000 ALTER TABLE `venta` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trg_venta_set_apertura` BEFORE INSERT ON `venta` FOR EACH ROW BEGIN
  IF NEW.apertura_id IS NULL THEN
    SET NEW.apertura_id = (
      SELECT ca.id
      FROM caja_apertura ca
      WHERE ca.empleado_id = NEW.empleado_id
        AND NEW.fecharegistro >= ca.abierto_en
        AND (ca.cerrado_en IS NULL OR NEW.fecharegistro <= ca.cerrado_en)
      ORDER BY ca.abierto_en DESC, ca.id DESC
      LIMIT 1
    );
  END IF;

  -- si sigue NULL, no hay caja abierta para ese horario
  IF NEW.apertura_id IS NULL THEN
    SIGNAL SQLSTATE '45000'
      SET MESSAGE_TEXT = 'No hay APERTURA de caja abierta para esa venta.';
  END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `venta_mediopago`
--

DROP TABLE IF EXISTS `venta_mediopago`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `venta_mediopago` (
  `id` int NOT NULL AUTO_INCREMENT,
  `venta_id` int DEFAULT NULL,
  `medio_pago` enum('Efectivo','Debito','Credito','Transferencia','CuentaCorriente') NOT NULL,
  `monto` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `venta_id` (`venta_id`),
  CONSTRAINT `venta_mediopago_ibfk_1` FOREIGN KEY (`venta_id`) REFERENCES `venta` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venta_mediopago`
--

LOCK TABLES `venta_mediopago` WRITE;
/*!40000 ALTER TABLE `venta_mediopago` DISABLE KEYS */;
INSERT INTO `venta_mediopago` VALUES (1,7,'Efectivo',14002.20),(2,8,'CuentaCorriente',30000.00),(3,9,'CuentaCorriente',5000.00),(4,10,'CuentaCorriente',5000.00),(8,15,'Efectivo',17600.00),(9,16,'Efectivo',200000.00),(10,18,'Efectivo',5280.00),(11,19,'Efectivo',2200.00),(12,20,'Efectivo',5500.00),(13,21,'Efectivo',11000.00),(14,22,'Efectivo',3300.00),(15,23,'Efectivo',7500.00),(16,24,'Efectivo',5500.00),(17,25,'Efectivo',2200.00);
/*!40000 ALTER TABLE `venta_mediopago` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `trg_vm_after_upd_ins` AFTER INSERT ON `venta_mediopago` FOR EACH ROW BEGIN
  DECLARE v_total DECIMAL(10,2);
  DECLARE v_sum   DECIMAL(10,2);

  SELECT montototal INTO v_total FROM venta WHERE id = NEW.venta_id;
  SELECT IFNULL(SUM(monto),0) INTO v_sum FROM venta_mediopago WHERE venta_id = NEW.venta_id;

  IF v_sum > v_total + 0.01 THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT='Suma de medios de pago supera montototal';
  END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Temporary view structure for view `vw_aperturas_caja`
--

DROP TABLE IF EXISTS `vw_aperturas_caja`;
/*!50001 DROP VIEW IF EXISTS `vw_aperturas_caja`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vw_aperturas_caja` AS SELECT 
 1 AS `apertura_id`,
 1 AS `fecha`,
 1 AS `empleado_id`,
 1 AS `monto_inicial`,
 1 AS `abierta`,
 1 AS `abierto_en`,
 1 AS `cerrado_en`,
 1 AS `saldo_cierre`,
 1 AS `observaciones`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vw_caja_resumen_apertura`
--

DROP TABLE IF EXISTS `vw_caja_resumen_apertura`;
/*!50001 DROP VIEW IF EXISTS `vw_caja_resumen_apertura`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vw_caja_resumen_apertura` AS SELECT 
 1 AS `apertura_id`,
 1 AS `fecha`,
 1 AS `empleado_id`,
 1 AS `monto_inicial`,
 1 AS `abierta`,
 1 AS `abierto_en`,
 1 AS `cerrado_en`,
 1 AS `ventas_efectivo`,
 1 AS `ventas_tarjeta`,
 1 AS `ventas_ctacte`,
 1 AS `retiros_total`,
 1 AS `saldo_cierre`,
 1 AS `diferencia`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vw_cierres_caja`
--

DROP TABLE IF EXISTS `vw_cierres_caja`;
/*!50001 DROP VIEW IF EXISTS `vw_cierres_caja`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `vw_cierres_caja` AS SELECT 
 1 AS `cierre_id`,
 1 AS `apertura_id`,
 1 AS `fecha`,
 1 AS `empleado_id`,
 1 AS `total_ventas`,
 1 AS `ventas_efectivo`,
 1 AS `ventas_tarjeta`,
 1 AS `ventas_ctacte`,
 1 AS `retiros_total`,
 1 AS `saldo_real`,
 1 AS `diferencia`,
 1 AS `observaciones`,
 1 AS `creado_en`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping events for database 'maxikiosco'
--

--
-- Dumping routines for database 'maxikiosco'
--
/*!50003 DROP PROCEDURE IF EXISTS `SP_AbrirCaja` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_AbrirCaja`(
  IN  p_fecha DATE,
  IN  p_empleado_id INT,
  IN  p_monto_inicial DECIMAL(12,2),
  IN  p_observaciones VARCHAR(255),
  OUT p_ok TINYINT,
  OUT p_mensaje VARCHAR(255)
)
proc: BEGIN
  DECLARE v_id INT;
  SET p_ok := 0; SET p_mensaje := '';

  -- ¬øya existe una apertura ABIERTA de ese empleado en esa fecha?
  SELECT id INTO v_id
  FROM caja_apertura
  WHERE fecha = p_fecha AND empleado_id = p_empleado_id AND abierta = 1
  ORDER BY id DESC LIMIT 1;

  IF v_id IS NOT NULL THEN
    SET p_mensaje := 'Ese empleado ya tiene una apertura ABIERTA para esa fecha.';
    LEAVE proc;
  END IF;

  INSERT INTO caja_apertura(fecha, empleado_id, monto_inicial, abierta, abierto_en, observaciones)
  VALUES (p_fecha, p_empleado_id, p_monto_inicial, 1, NOW(), p_observaciones);

  SET p_ok := 1;
  SET p_mensaje := 'Caja abierta correctamente.';
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_CC_ObtenerEstado` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_CC_ObtenerEstado`(
  IN  p_ClienteId INT,
  OUT p_Saldo     DECIMAL(12,2),
  OUT p_Limite    DECIMAL(12,2),
  OUT p_Habilitada TINYINT
)
BEGIN
  SELECT COALESCE(saldo,0), COALESCE(limite_credito,0), COALESCE(habilitada,1)
    INTO p_Saldo, p_Limite, p_Habilitada
  FROM cuenta_corriente_cliente
  WHERE cliente_id = p_ClienteId;

  IF p_Saldo IS NULL THEN
    SET p_Saldo = 0;
    SET p_Limite = 0;
    SET p_Habilitada = 1;
  END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_CC_RegistrarPago` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_CC_RegistrarPago`(
  IN  p_ClienteId  INT,
  IN  p_Monto      DECIMAL(12,2),
  IN  p_UsuarioId  INT,
  IN  p_Concepto   VARCHAR(150),
  OUT resultado    TINYINT,
  OUT mensaje      VARCHAR(250)
)
BEGIN
  DECLARE v_saldo      DECIMAL(12,2) DEFAULT 0;
  DECLARE v_limite     DECIMAL(12,2) DEFAULT 0;
  DECLARE v_habilitada TINYINT       DEFAULT 1;

  SET resultado = 0;
  SET mensaje   = '';

  proc: BEGIN

    IF p_Monto IS NULL OR p_Monto <= 0 THEN
      SET mensaje = 'Monto inv√°lido';
      LEAVE proc;
    END IF;

    START TRANSACTION;

    /* Asegurar cuenta */
    INSERT INTO cuenta_corriente_cliente (cliente_id, saldo, limite_credito, habilitada)
    VALUES (p_ClienteId, 0, 0, 1)
    ON DUPLICATE KEY UPDATE cliente_id = VALUES(cliente_id);

    /* Leer estado con lock */
    SELECT saldo, COALESCE(limite_credito,0), COALESCE(habilitada,1)
      INTO v_saldo, v_limite, v_habilitada
    FROM cuenta_corriente_cliente
    WHERE cliente_id = p_ClienteId
    FOR UPDATE;

    /* No permitir sobrepago */
    IF p_Monto > v_saldo THEN
      SET mensaje = CONCAT('El monto excede el saldo (', FORMAT(v_saldo,2,'es_AR'), ').');
      ROLLBACK;
      LEAVE proc;
    END IF;

    /* Insertar movimiento CREDITO (pago) */
    INSERT INTO cc_movimiento
      (cliente_id, fecha_hora, tipo, concepto, venta_id, monto, usuario_id)
    VALUES
      (p_ClienteId, NOW(), 'CREDITO',
       IFNULL(NULLIF(p_Concepto,''),'Pago CC'), NULL, p_Monto, p_UsuarioId);

    /* Bajar saldo */
    UPDATE cuenta_corriente_cliente
       SET saldo = GREATEST(saldo - p_Monto, 0)
     WHERE cliente_id = p_ClienteId;

    /* Snapshot (√∫ltimo estado por cliente) */
    SELECT saldo INTO v_saldo
      FROM cuenta_corriente_cliente
     WHERE cliente_id = p_ClienteId;

    INSERT INTO cc_estado (cliente_id, saldo, limite_credito, habilitada)
    VALUES (p_ClienteId, v_saldo, v_limite, v_habilitada)
    ON DUPLICATE KEY UPDATE
      saldo = VALUES(saldo),
      limite_credito = VALUES(limite_credito),
      habilitada = VALUES(habilitada);

    COMMIT;

    SET resultado = 1;
    SET mensaje   = 'OK';

  END proc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_CC_RegistrarVentaFiada` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_CC_RegistrarVentaFiada`(
  IN  p_ClienteId  INT,
  IN  p_VentaId    INT,
  IN  p_Monto      DECIMAL(12,2),
  IN  p_UsuarioId  INT,
  OUT resultado    TINYINT,
  OUT mensaje      VARCHAR(250)
)
BEGIN
  DECLARE v_saldo      DECIMAL(12,2);
  DECLARE v_limite     DECIMAL(12,2);
  DECLARE v_habilitada TINYINT;

  SET resultado = 0;
  SET mensaje  = '';

  /* ===== Bloque etiquetado ===== */
  proc: BEGIN

    IF p_Monto IS NULL OR p_Monto <= 0 THEN
      SET mensaje = 'Monto inv√°lido';
      LEAVE proc;
    END IF;

    START TRANSACTION;

    /* Asegura fila de CC */
    INSERT INTO cuenta_corriente_cliente (cliente_id, saldo, limite_credito, habilitada)
    VALUES (p_ClienteId, 0, 0, 1)
    ON DUPLICATE KEY UPDATE cliente_id = VALUES(cliente_id);

    SELECT saldo, COALESCE(limite_credito,0), COALESCE(habilitada,1)
      INTO v_saldo, v_limite, v_habilitada
    FROM cuenta_corriente_cliente
    WHERE cliente_id = p_ClienteId
    FOR UPDATE;

    IF v_habilitada = 0 THEN
      ROLLBACK;
      SET mensaje = 'Cuenta corriente deshabilitada para este cliente';
      LEAVE proc;
    END IF;

    IF v_limite > 0 AND (v_saldo + p_Monto) > v_limite THEN
      ROLLBACK;
      SET mensaje = CONCAT('L√≠mite de cr√©dito excedido. Saldo: ',
                           FORMAT(v_saldo,2), ' + Monto: ', FORMAT(p_Monto,2),
                           ' > L√≠mite: ', FORMAT(v_limite,2));
      LEAVE proc;
    END IF;

    INSERT INTO cc_movimiento
      (cliente_id, fecha_hora, tipo, concepto, venta_id, monto, usuario_id)
    VALUES
      (p_ClienteId, NOW(), 'DEBITO',
       CONCAT('Venta fiada #', p_VentaId), p_VentaId, p_Monto, p_UsuarioId);

    UPDATE cuenta_corriente_cliente
       SET saldo = saldo + p_Monto
     WHERE cliente_id = p_ClienteId;

    /* Snapshot estado (requiere UNIQUE en cliente_id, ver abajo) */
    INSERT INTO cc_estado (cliente_id, saldo, limite_credito, habilitada)
    VALUES (p_ClienteId, v_saldo + p_Monto, v_limite, v_habilitada)
    ON DUPLICATE KEY UPDATE
      saldo = VALUES(saldo),
      limite_credito = VALUES(limite_credito),
      habilitada = VALUES(habilitada);

    COMMIT;

    SET resultado = 1;
    SET mensaje  = 'OK';

  END proc;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_CerrarCaja` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_CerrarCaja`(
  IN  p_fecha DATE,
  IN  p_empleado_id INT,
  IN  p_saldo_real DECIMAL(12,2),
  IN  p_observaciones VARCHAR(255),
  OUT p_ok TINYINT,
  OUT p_mensaje VARCHAR(255)
)
proc: BEGIN
  DECLARE v_apertura_id INT;
  DECLARE v_monto_inicial DECIMAL(12,2) DEFAULT 0.00;
  DECLARE v_efe DECIMAL(12,2) DEFAULT 0.00;
  DECLARE v_tar DECIMAL(12,2) DEFAULT 0.00;   -- Debito/Credito/Transferencia
  DECLARE v_cca DECIMAL(12,2) DEFAULT 0.00;
  DECLARE v_ret DECIMAL(12,2) DEFAULT 0.00;
  DECLARE v_total DECIMAL(12,2) DEFAULT 0.00;
  DECLARE v_esperado DECIMAL(12,2) DEFAULT 0.00;
  DECLARE v_dif DECIMAL(12,2) DEFAULT 0.00;

  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
    ROLLBACK; SET p_ok := 0; SET p_mensaje := 'Error SQL al cerrar caja.';
  END;

  SET p_ok := 0; SET p_mensaje := '';
  START TRANSACTION;

  -- Tomar la apertura ABIERTA de ese empleado y fecha
  SELECT id, monto_inicial
    INTO v_apertura_id, v_monto_inicial
  FROM caja_apertura
  WHERE fecha = p_fecha AND empleado_id = p_empleado_id AND abierta = 1
  ORDER BY id DESC LIMIT 1;

  IF v_apertura_id IS NULL THEN
    SET p_mensaje := 'No hay apertura ABIERTA para ese empleado y fecha.';
    ROLLBACK; LEAVE proc;
  END IF;

  -- Evitar doble cierre
  IF EXISTS (SELECT 1 FROM cierres_caja WHERE apertura_id = v_apertura_id) THEN
    SET p_mensaje := 'La apertura ya tiene un cierre.';
    ROLLBACK; LEAVE proc;
  END IF;

  -- >>> SUMAS POR APERTURA (no por fecha)
  SELECT IFNULL(SUM(mp.monto),0) INTO v_efe
    FROM venta v JOIN venta_mediopago mp ON mp.venta_id = v.id
   WHERE v.apertura_id = v_apertura_id AND mp.medio_pago = 'Efectivo';

  SELECT IFNULL(SUM(mp.monto),0) INTO v_tar
    FROM venta v JOIN venta_mediopago mp ON mp.venta_id = v.id
   WHERE v.apertura_id = v_apertura_id AND mp.medio_pago IN ('Debito','Credito','Transferencia');

  SELECT IFNULL(SUM(mp.monto),0) INTO v_cca
    FROM venta v JOIN venta_mediopago mp ON mp.venta_id = v.id
   WHERE v.apertura_id = v_apertura_id AND mp.medio_pago = 'CuentaCorriente';

  SELECT IFNULL(SUM(r.monto),0) INTO v_ret
    FROM retiros r
   WHERE r.apertura_id = v_apertura_id;

  SET v_total    = v_efe + v_tar + v_cca;
  SET v_esperado = v_monto_inicial + v_efe - v_ret;
  SET v_dif      = p_saldo_real - v_esperado;

  INSERT INTO cierres_caja(
    apertura_id, fecha, empleado_id,
    total_ventas, ventas_efectivo, ventas_tarjeta, ventas_ctacte,
    retiros_total, saldo_real, diferencia, observaciones
  ) VALUES (
    v_apertura_id, p_fecha, p_empleado_id,
    v_total, v_efe, v_tar, v_cca,
    v_ret, p_saldo_real, v_dif, p_observaciones
  );

  UPDATE caja_apertura
     SET abierta = 0,
         cerrado_en = NOW(),
         saldo_cierre = p_saldo_real,
         observaciones = COALESCE(p_observaciones, observaciones)
   WHERE id = v_apertura_id;

  COMMIT; SET p_ok := 1; SET p_mensaje := 'Caja cerrada correctamente.';
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
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
    IN p_id INT,
    IN p_nombre_categoria VARCHAR(50),
    IN p_estado TINYINT,
    IN p_porcentaje_aumento DECIMAL(5,2),
    OUT p_resultado INT,
    OUT mensaje VARCHAR(250)
)
BEGIN
    SET p_resultado = 1;
    SET mensaje = '';

    IF NOT EXISTS (SELECT * FROM categoria WHERE nombre_categoria = p_nombre_categoria AND id != p_id) THEN
        UPDATE categoria 
        SET nombre_categoria = p_nombre_categoria,
            estado = p_estado,
            porcentaje_aumento = p_porcentaje_aumento
        WHERE id = p_id;

        SET mensaje = 'Categor√≠a editada correctamente';
    ELSE
        SET p_resultado = 0;
        SET mensaje = 'Error: No se puede repetir la descripci√≥n de una categor√≠a';
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
    
    -- NUEVOS PARAMETROS
    IN p_cuit VARCHAR(15), 
    IN p_condicion_iva VARCHAR(50),
    
    OUT respuesta TINYINT,
    OUT mensaje VARCHAR(250)
)
BEGIN
    
    SET respuesta = 0;
    SET mensaje = '';

    -- Se actualiza la tabla con los nuevos campos
    UPDATE cliente
    SET dni = p_documento,
        nombre = p_nombre,
        apellido = p_apellido,
        telefono = p_telefono,
        domicilio = p_domicilio,
        email = p_email,
        estado = p_estado,
        -- ACTUALIZACION DE NUEVAS COLUMNAS
        cuit = p_cuit,
        condicion_iva = p_condicion_iva
    WHERE id = p_idcliente;

    
    IF ROW_COUNT() > 0 THEN
        SET respuesta = 1;
        -- Mensaje de exito sin acentos
        SET mensaje = 'Cliente actualizado correctamente'; 
    ELSE
        -- Mensaje de error sin acentos
        SET mensaje = 'No se encontro el cliente o no hubo cambios';
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
    IN p_precioventa DECIMAL(10, 2),
    IN p_categoria_id INT,
    IN p_descripcion VARCHAR(20),
    IN p_fecharegistro DATETIME,
    IN p_estado TINYINT,
    IN p_codigo VARCHAR(13),
    IN p_stock_minimo INT, 
    OUT mensaje VARCHAR(250),
    OUT resultado INT
)
BEGIN
    DECLARE existe_nombre INT DEFAULT 0;
    DECLARE existe_codigo INT DEFAULT 0;

    SET mensaje = '';
    SET resultado = 1;
    
    -- 1. Verificar si existe otro producto con el MISMO NOMBRE y DIFERENTE ID (Esto ya estaba bien)
    SELECT COUNT(*) INTO existe_nombre
    FROM producto 
    WHERE id != p_id AND nombre = p_nombre;

    -- 2. Verificar si existe otro producto con el MISMO C√ìDIGO y DIFERENTE ID.
    --    PERO solo si el c√≥digo NO es un c√≥digo autogenerado 'INT-%'.
    SELECT COUNT(*) INTO existe_codigo
    FROM producto 
    WHERE id != p_id 
      AND codigo = p_codigo
      AND p_codigo NOT LIKE 'INT-%'; -- ‚¨ÖÔ∏è CORRECCI√ìN APLICADA AQU√ç.

    -- 3. Proceder a la edici√≥n si no hay duplicados.
    IF (existe_nombre = 0 AND existe_codigo = 0) THEN
        UPDATE producto 
        SET nombre = p_nombre,
            stock = p_stock,
            precioventa = p_precioventa,
            categoria_id = p_categoria_id,
            descripcion = p_descripcion,
            fecharegistro = p_fecharegistro,
            estado = p_estado,
            codigo = p_codigo,
            stock_minimo = p_stock_minimo 
        WHERE id = p_id;

        SET mensaje = 'El producto se edit√≥ con √©xito';
        SET resultado = 1;
    ELSE
        SET resultado = 0;
        IF existe_nombre > 0 THEN
            SET mensaje = 'Error: ya existe otro producto con ese nombre';
        ELSEIF existe_codigo > 0 THEN
            SET mensaje = 'Error: ya existe otro producto con ese c√≥digo';
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
    IN p_porcentaje_aumento DECIMAL(5,2),
    OUT resultado TINYINT,
    OUT mensaje VARCHAR(250)
)
BEGIN
    SET resultado = 0; -- Inicializamos en 0 (Fallo)
    SET mensaje = '';

    IF NOT EXISTS(SELECT 1 FROM proveedor WHERE cuit = p_cuit and id != p_id ) THEN 
        UPDATE proveedor 
        SET 
            nombre = p_nombre,
            cuit = p_cuit, 
            razonsocial = p_razonsocial,
            telefono = p_telefono,
            direccion = p_direccion,
            estado = p_estado,
            email = p_email,
            porcentaje_aumento = p_porcentaje_aumento 
        WHERE id = p_id;
        
        -- Si el update fue exitoso, establecemos el resultado a 1
        SET resultado = 1;
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
    
    -- ‚¨áÔ∏è NUEVOS PAR√ÅMETROS AGREGADOS ‚¨áÔ∏è
    IN p_escliente TINYINT,
    IN p_esproveedor TINYINT,
    
    OUT respuesta tinyint,
    OUT mensaje VARCHAR(250)
)
BEGIN
    
    SET respuesta = 0;
    SET mensaje = '';

    IF NOT EXISTS (SELECT 1 FROM usuario WHERE dni = p_documento 
    AND idusuario <> p_idusuario) THEN
        UPDATE usuario set 
            dni = p_documento,
            nombre = p_nombre,
            apellido = p_apellido,
            email = p_email,
            usuario_cuenta = p_usuario_cuenta,
            contrasenia = p_contrasenia,
            rol_id =  p_rol_id,
            telefono =  p_telefono,
            estado = p_estado,
            
            escliente = p_escliente,     -- Nueva actualizaci√≥n
            esproveedor = p_esproveedor  -- Nueva actualizaci√≥n

        WHERE idusuario = p_idusuario;

        SET respuesta = 1;
        SET mensaje = 'Usuario editado correctamente';
    ELSE
		SET mensaje = 'Error: El documento ya est√° registrado por otro usuario.'; 
		SET respuesta = 0;
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
        SET mensaje = 'Categor√≠a eliminada correctamente';
    
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
/*!50003 DROP PROCEDURE IF EXISTS `SP_GetAperturaAbierta` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_GetAperturaAbierta`(
  OUT p_existe TINYINT,
  OUT p_apertura_id INT
)
BEGIN
  SELECT IFNULL(id,0), IFNULL(id,0)
  INTO p_apertura_id, p_apertura_id
  FROM caja_apertura
  WHERE abierta = 1
  ORDER BY abierto_en DESC
  LIMIT 1;

  SET p_existe = IF(p_apertura_id > 0, 1, 0);
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
    IN p_estado TINYINT,
    IN p_porcentaje_aumento DECIMAL(5,2),
    OUT p_resultado INT,
    OUT mensaje VARCHAR(250)
)
BEGIN
    SET p_resultado = 0;
    SET mensaje = '';

    IF NOT EXISTS (SELECT * FROM categoria WHERE nombre_categoria = p_nombre_categoria) THEN
        INSERT INTO categoria(nombre_categoria, estado, porcentaje_aumento)
        VALUES (p_nombre_categoria, p_estado, p_porcentaje_aumento);

        SET p_resultado = LAST_INSERT_ID();
        SET mensaje = 'Categor√≠a creada correctamente';
    ELSE
        SET mensaje = 'Error: Ya existe esa categor√≠a';
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
    IN p_domicilio VARCHAR(50),
    IN p_estado TINYINT,
    
    -- ‚¨áÔ∏è NUEVOS PAR√ÅMETROS AGREGADOS ‚¨áÔ∏è
    IN p_cuit VARCHAR(15), 
    IN p_condicion_iva VARCHAR(50), 
    OUT idclienteresultado INT,
    OUT mensaje VARCHAR(250)
)
BEGIN
    
    SET idclienteresultado = 0;
    SET mensaje = '';

    IF NOT EXISTS (SELECT 1 FROM cliente WHERE dni = p_documento) THEN
        INSERT INTO cliente (
            nombre, apellido, dni, telefono, domicilio, email, estado,
            -- ‚¨áÔ∏è NUEVAS COLUMNAS ‚¨áÔ∏è
            cuit, condicion_iva
        )
        VALUES ( 
            p_nombre, p_apellido, p_documento, p_telefono, p_domicilio, p_email, p_estado,
            -- ‚¨áÔ∏è NUEVOS VALORES ‚¨áÔ∏è
            p_cuit, p_condicion_iva
        );

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
  IN  p_montototal      DECIMAL(10,2),   
  IN  p_monto_iva_total DECIMAL(10,2),   
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
      cantidad     INT NOT NULL,
      monto_iva       DECIMAL(10,2) NOT NULL,
      precio_bruto    DECIMAL(10,2) NOT NULL
    ) ENGINE=Memory;

    TRUNCATE det_tmp;

    INSERT INTO det_tmp (
	  producto_id, 
	  preciocompra, 
	  precioventa, 
	  cantidad,
	  monto_iva,      
	  precio_bruto  
	)
    SELECT
	  j.producto_id,
	  j.preciocompra,
	  j.precioventa,
	  j.cantidad,
	  j.monto_iva,    
	  j.precio_bruto  
    
    FROM JSON_TABLE(
           p_detallecompra, '$[*]'
           COLUMNS(
             producto_id  INT            PATH '$.producto_id',
             preciocompra DECIMAL(10,2)  PATH '$.preciocompra',
             precioventa  DECIMAL(10,2)  PATH '$.precioventa',
             cantidad     INT            PATH '$.cantidad',
             monto_iva    DECIMAL(10,2)   PATH '$.monto_iva',
             precio_bruto DECIMAL(10,2)   PATH '$.precio_bruto'
           )
         ) AS j;

    
    SELECT COUNT(*) INTO v_rows FROM det_tmp;
    IF v_rows = 0 THEN
      SET resultado = 0;
      SET mensaje = 'El detalle est√° vac√≠o';
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
    
    INSERT INTO compra (fecharegistro, montototal, empleado_id, proveedor_id, tipodocumento, numerodocumento, monto_iva_total)
        VALUES (
          NOW(),
          p_montototal,    
          p_empleado_id,
          p_proveedor_id,
          p_tipodocumento,
          p_numerodocumento,
          p_monto_iva_total 
        );

    SET v_compra_id = LAST_INSERT_ID();
	
    INSERT INTO detalle_compra (compra_id, producto_id, cantidad, montototal, preciocompra, precioventa, fecharegistro, monto_iva)
        SELECT
            v_compra_id,
            producto_id,
            cantidad,
            cantidad * precio_bruto, 
            preciocompra,           
            precioventa,
            NOW(),
            monto_iva               
        FROM det_tmp;

	UPDATE producto p
        JOIN (
            SELECT
                producto_id,
                SUM(cantidad)     AS qty,
                -- Usamos el PRECIO NETO (preciocompra) para actualizar el costo del producto
                MAX(preciocompra) AS pc, 
                MAX(precioventa)  AS pv
            FROM det_tmp
            GROUP BY producto_id
        ) dc ON dc.producto_id = p.id
        SET p.stock      = p.stock + dc.qty,
            p.preciocompra = dc.pc, -- Costo de inventario (PRECIO NETO)
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
    IN p_nombre VARCHAR(60),
    IN p_stock INT,
    IN p_precioventa decimal(10, 2), -- Corregido float - decimal
    IN p_categoria_id INT,
    IN p_descripcion VARCHAR(20),
    IN p_fecharegistro DATETIME,
    IN p_estado TINYINT,
    IN p_codigo VARCHAR(13),
    IN p_stock_minimo INT, 
    OUT mensaje VARCHAR(250),
    OUT resultado INT
)
BEGIN
    DECLARE existe_nombre INT DEFAULT 0;
    DECLARE existe_codigo INT DEFAULT 0;

    SET mensaje = '';
    SET resultado = 0; -- Inicializamos el resultado en 0 (Error)

    -- 1. Verificar si ya existe otro producto con el MISMO NOMBRE
    SELECT COUNT(1) INTO existe_nombre
    FROM producto 
    WHERE nombre = p_nombre;

    -- 2. Verificar si ya existe otro producto con el MISMO C√ìDIGO
    --    PERO solo si el c√≥digo NO es un c√≥digo interno ('INT-%')
    IF p_codigo NOT LIKE 'INT-%' THEN
        SELECT COUNT(1) INTO existe_codigo
        FROM producto 
        WHERE codigo = p_codigo;
    END IF;

    -- 3. Insertar solo si NO hay conflictos
    IF existe_nombre = 0 AND existe_codigo = 0 THEN
        INSERT INTO producto(nombre, stock, precioventa, categoria_id, descripcion, estado, codigo, stock_minimo)
        VALUES (p_nombre, p_stock, p_precioventa, p_categoria_id, p_descripcion, p_estado, p_codigo, p_stock_minimo);
        
        SET resultado = LAST_INSERT_ID();
        SET mensaje = 'El producto se registr√≥ con √©xito';
    ELSE
        -- Devolver el error espec√≠fico
        IF existe_nombre > 0 THEN
            SET mensaje = 'Error: Ya existe un producto registrado con ese nombre.';
        ELSEIF existe_codigo > 0 THEN
            SET mensaje = 'Error: Ya existe un producto registrado con ese c√≥digo de barra.';
        END IF;
    END IF;
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
    IN p_porcentaje_aumento DECIMAL(5,2), -- üéØ NUEVO PAR√ÅMETRO
    OUT resultado INT,
    OUT mensaje VARCHAR(250)
)
BEGIN
    SET resultado = 0;
    SET mensaje = '';

    IF NOT EXISTS (SELECT 1 FROM proveedor WHERE cuit = p_cuit) THEN
        INSERT INTO proveedor(nombre, cuit, razonsocial , telefono, direccion, estado, fecharegistro, email, porcentaje_aumento)
        VALUES (p_nombre, p_cuit, p_razonsocial, p_telefono, p_direccion, p_estado, NOW(), p_email, p_porcentaje_aumento);

        SET resultado = LAST_INSERT_ID();
        SET mensaje = 'El proveedor fue registrado con √©xito';
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
    
    -- ‚¨áÔ∏è NUEVOS PAR√ÅMETROS AGREGADOS ‚¨áÔ∏è
    IN p_escliente TINYINT,
    IN p_esproveedor TINYINT,
    
    OUT idusuarioresultado INT,
    OUT mensaje VARCHAR(250)
)
BEGIN
    
    SET idusuarioresultado = 0;
    SET mensaje = '';

    IF NOT EXISTS (SELECT 1 FROM usuario WHERE dni = p_documento) THEN
        INSERT INTO usuario (
            dni, 
            nombre, 
            apellido, 
            email, 
            usuario_cuenta, 
            contrasenia, 
            rol_id, 
            telefono, 
            estado, 
            escliente,           -- Nueva columna
            esproveedor          -- Nueva columna
        )
        VALUES (
            p_documento, 
            p_nombre, 
            p_apellido, 
            p_email, 
            p_usuario_cuenta, 
            p_contrasenia, 
            p_rol_id, 
            p_telefono, 
            p_estado,
            p_escliente,         -- Nuevo valor
            p_esproveedor        -- Nuevo valor
        );

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
  IN  p_ClienteId       INT,
  IN  p_MedioPago       VARCHAR(30),           -- 'Efectivo','Debito','Credito','Transferencia','CuentaCorriente'
  IN  p_TipoDocumento   VARCHAR(45),
  IN  p_NumeroDocumento VARCHAR(45),
  IN  p_NombreCliente   VARCHAR(150),
  IN  p_MontoPago       DECIMAL(10,2),
  IN  p_DetalleVenta    JSON,
  OUT resultado         TINYINT,
  OUT mensaje           VARCHAR(250)
)
BEGIN
  -- ===== Variables =====
  DECLARE v_VentaId     BIGINT;
  DECLARE v_MontoTotal  DECIMAL(10,2);
  DECLARE v_Insuf       INT DEFAULT 0;
  DECLARE v_esCC        TINYINT DEFAULT 0;
	
  -- ===== HANDLER (debe ir antes de cualquier SET/SELECT) =====
  DECLARE EXIT HANDLER FOR SQLEXCEPTION
  BEGIN
	  GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE, @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
	  ROLLBACK;
	  SET resultado = 0;
	  SET mensaje = CONCAT('Error SQL ', @errno, ': ', @text);
	END;
    
  -- BEGIN
    -- ROLLBACK;
    -- SET resultado = 0;
	-- SET mensaje  = 'Error al registrar la venta';
  -- END;

  -- Ahora s√≠, sentencias ejecutables
  SET v_esCC = (p_MedioPago = 'CuentaCorriente');

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

    -- Solo exigimos pago suficiente si NO es CuentaCorriente
    IF (v_esCC = 0) AND (p_MontoPago < v_MontoTotal) THEN
      SET resultado = 0;
      SET mensaje   = 'El monto de pago es insuficiente';
      LEAVE proc;
    END IF;

    START TRANSACTION;

    -- Chequeo de stock
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
    VALUES (
      NOW(), p_IdUsuario, NULLIF(p_ClienteId,0),
      v_MontoTotal,
      IF(v_esCC=1, 0, p_MontoPago),
      IF(v_esCC=1, 0, GREATEST(p_MontoPago - v_MontoTotal, 0)),
      p_TipoDocumento, p_NumeroDocumento
    );

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
/*!50003 DROP PROCEDURE IF EXISTS `SP_ReporteCompras` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_ReporteCompras`(
  IN p_fechainicio DATE,
  IN p_fechafin    DATE,
  IN p_idproveedor INT
)
BEGIN
  -- Incluimos hasta el final del d√≠a p_fechafin usando < fecha_siguiente
  SELECT 
    DATE_FORMAT(c.fecharegistro, '%d/%m/%Y') AS fecha_formateada,
    c.tipodocumento,
    c.numerodocumento,
    c.montototal,
    CONCAT_WS(' ', COALESCE(u.nombre,''), COALESCE(u.apellido,'')) AS nombrecompletousuario,
    pr.cuit AS documentoproveedor,
    pr.razonsocial,
    p.codigo AS codigoproduct,
    p.nombre,
    ca.nombre_categoria,
    dc.precioventa,
    dc.preciocompra,
    dc.cantidad,
    dc.montototal AS subtotal
  FROM compra c
  INNER JOIN usuario u       ON u.idusuario   = c.empleado_id
  INNER JOIN proveedor pr     ON pr.id         = c.proveedor_id
  INNER JOIN detalle_compra dc ON dc.compra_id = c.id_compra
  INNER JOIN producto p      ON p.id          = dc.producto_id
  INNER JOIN categoria ca    ON ca.id         = p.categoria_id
  WHERE c.fecharegistro >= p_fechainicio
    AND c.fecharegistro <  DATE_ADD(p_fechafin, INTERVAL 1 DAY)
    AND (p_idproveedor IS NULL OR pr.id = p_idproveedor);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SP_ReporteVentas` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_ReporteVentas`(
  IN p_fechainicio DATE,
  IN p_fechafin    DATE
)
BEGIN
  SELECT 
    v.fecharegistro                                   AS fecharegistro,
    DATE_FORMAT(v.fecharegistro, '%d/%m/%Y %H:%i:%s') AS fecha_formateada,
    v.tipodocumento,
    v.numerodocumento,
    v.montototal,

    CONCAT_WS(' ', COALESCE(u.nombre,''), COALESCE(u.apellido,'')) AS nombrecompletousuario,

    CONCAT_WS(' ', COALESCE(c.nombre,''), COALESCE(c.apellido,'')) AS nombrecompletocliente,
    c.dni AS documentocliente,

    p.codigo           AS codigoproduct,
    p.nombre           AS nombre,
    ca.nombre_categoria AS nombre_categoria,          -- <<< ac√° el cambio

    dv.precio_unitario AS precioventa,
    dv.cantidad        AS cantidad,
    (dv.precio_unitario * dv.cantidad) AS subtotal

  FROM venta v
  LEFT JOIN usuario       u  ON u.idusuario = v.empleado_id
  LEFT JOIN cliente       c  ON c.id        = v.cliente_id
  LEFT JOIN detalle_venta dv ON dv.venta_id = v.id
  LEFT JOIN producto      p  ON p.id        = dv.producto_id
  LEFT JOIN categoria     ca ON ca.id       = p.categoria_id
  WHERE v.fecharegistro >= p_fechainicio
    AND v.fecharegistro <  DATE_ADD(p_fechafin, INTERVAL 1 DAY);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `vw_aperturas_caja`
--

/*!50001 DROP VIEW IF EXISTS `vw_aperturas_caja`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vw_aperturas_caja` AS select `ca`.`id` AS `apertura_id`,`ca`.`fecha` AS `fecha`,`ca`.`empleado_id` AS `empleado_id`,`ca`.`monto_inicial` AS `monto_inicial`,`ca`.`abierta` AS `abierta`,`ca`.`abierto_en` AS `abierto_en`,`ca`.`cerrado_en` AS `cerrado_en`,`ca`.`saldo_cierre` AS `saldo_cierre`,`ca`.`observaciones` AS `observaciones` from `caja_apertura` `ca` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vw_caja_resumen_apertura`
--

/*!50001 DROP VIEW IF EXISTS `vw_caja_resumen_apertura`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vw_caja_resumen_apertura` AS select `ca`.`id` AS `apertura_id`,`ca`.`fecha` AS `fecha`,`ca`.`empleado_id` AS `empleado_id`,`ca`.`monto_inicial` AS `monto_inicial`,`ca`.`abierta` AS `abierta`,`ca`.`abierto_en` AS `abierto_en`,`ca`.`cerrado_en` AS `cerrado_en`,coalesce((select sum(`mp`.`monto`) from (`venta` `v` join `venta_mediopago` `mp` on((`mp`.`venta_id` = `v`.`id`))) where ((`v`.`apertura_id` = `ca`.`id`) and (`mp`.`medio_pago` = 'Efectivo'))),0) AS `ventas_efectivo`,coalesce((select sum(`mp`.`monto`) from (`venta` `v` join `venta_mediopago` `mp` on((`mp`.`venta_id` = `v`.`id`))) where ((`v`.`apertura_id` = `ca`.`id`) and (`mp`.`medio_pago` in ('Debito','Credito','Transferencia','Tarjeta')))),0) AS `ventas_tarjeta`,coalesce((select sum(`mp`.`monto`) from (`venta` `v` join `venta_mediopago` `mp` on((`mp`.`venta_id` = `v`.`id`))) where ((`v`.`apertura_id` = `ca`.`id`) and (`mp`.`medio_pago` = 'CuentaCorriente'))),0) AS `ventas_ctacte`,coalesce((select sum(`r`.`monto`) from `retiros` `r` where (`r`.`apertura_id` = `ca`.`id`)),0) AS `retiros_total`,`ca`.`saldo_cierre` AS `saldo_cierre`,(`ca`.`saldo_cierre` - ((`ca`.`monto_inicial` + coalesce((select sum(`mp`.`monto`) from (`venta` `v` join `venta_mediopago` `mp` on((`mp`.`venta_id` = `v`.`id`))) where ((`v`.`apertura_id` = `ca`.`id`) and (`mp`.`medio_pago` = 'Efectivo'))),0)) - coalesce((select sum(`r`.`monto`) from `retiros` `r` where (`r`.`apertura_id` = `ca`.`id`)),0))) AS `diferencia` from `caja_apertura` `ca` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vw_cierres_caja`
--

/*!50001 DROP VIEW IF EXISTS `vw_cierres_caja`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vw_cierres_caja` AS select `cc`.`id` AS `cierre_id`,`cc`.`apertura_id` AS `apertura_id`,`cc`.`fecha` AS `fecha`,`cc`.`empleado_id` AS `empleado_id`,`cc`.`total_ventas` AS `total_ventas`,`cc`.`ventas_efectivo` AS `ventas_efectivo`,`cc`.`ventas_tarjeta` AS `ventas_tarjeta`,`cc`.`ventas_ctacte` AS `ventas_ctacte`,`cc`.`retiros_total` AS `retiros_total`,`cc`.`saldo_real` AS `saldo_real`,`cc`.`diferencia` AS `diferencia`,`cc`.`observaciones` AS `observaciones`,`cc`.`creado_en` AS `creado_en` from `cierres_caja` `cc` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-11-11 14:22:11
