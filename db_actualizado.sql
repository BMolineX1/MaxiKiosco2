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
  `porcentaje_aumento` decimal(5,2) DEFAULT '0.00',
  PRIMARY KEY (`id`),
  UNIQUE KEY `nombre_categoria` (`nombre_categoria`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoria`
--

LOCK TABLES `categoria` WRITE;
/*!40000 ALTER TABLE `categoria` DISABLE KEYS */;
INSERT INTO `categoria` VALUES (2,'Bebidas',1,10.00),(3,'Panificados',0,30.00),(9,'Fiambreria',1,29.00),(10,'Galletitas',1,5.00),(18,'Lacteos',0,12.00),(21,'Otro',1,50.00),(22,'Articulo de limpieza',1,30.00);
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
  `razonsocial` varchar(100) DEFAULT NULL,
  `condicion_iva` enum('Responsable Inscripto','Monotributista','Consumidor Final','Exento') DEFAULT NULL,
  `tipo_cliente` enum('Minorista','Mayorista') DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `dni` (`dni`),
  UNIQUE KEY `email_UNIQUE` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` VALUES (1,'Federico','Molina','38962453','','3644657148','mz 7 pc 12 Barrio Pro.Mu.Vi','fede.099molina@gmail.com',1,'','Consumidor Final','Mayorista'),(4,'gabi','Vera','2333333333','','33333333','mz 7 pc 23','fede@gmail.com',1,'','Consumidor Final','Mayorista'),(5,'Elias','Ramirez','42746919','','3644222298','Barrio anbtocÃ±','elias@gmail.com',1,'','Consumidor Final','Minorista'),(11,'Marcelo','Concelo','1245780536','20888999678','3644896278','NaÃ±ta','123abc@gmail.com',1,'Limpa S.R.L','Responsable Inscripto','Mayorista');
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
INSERT INTO `negocio` VALUES (1,'MaxiKiosco Molina','101010','av. codigo 123',_binary '‰PNG\r\n\Z\n\0\0\0\rIHDR\0\0™\0\0W\0\0\0\ØMO–\0\0\0sRGB\0®\Î\é\0\0\0gAMA\0\0±üa\0\0\0	pHYs\0\0\Ã\0\0\Ã\Ço¨d\0\0ªõIDATx^\ìı|Tg7ş¿\æGš¢ôƒc \íjª›ö& 5j\ä\Ö\í.¡ö¡C\ê*%\Õ\êF6²\Ù[\ïÛ?J†\êj\í~[ˆ)\ÆJ1)b\Ù\Õ]‚?Ö²£·¥ÁºqÔ¶´+¡82XD\ÌLòı\ãœkr\æ}®¹&I2™¼\ÇûQ¹®w®\ëMœ9\\sÎ™\ëx-Z4ªª*\r\r\É\æŒ`tt©TJv\0¼^/\Ê\Ë\Ëq\á\ÂŒ\Én\0€\ß\ïGYYÎŸ?/»²°=Ö¢\ÇZôX‹k\Ñc-z¬Eµ\èÍ§ZÎœ9ƒ\ÊeUYmŞ¬?€\'j\ÏdVVVbxxX6g”••!NkW³\0\àñx\à÷û‘J¥0>®^¯>Ÿ£££²+k\Ñc-z¬Eµ\è±=Ö¢\ÇZôX‹\Ş|ª%‘H¸\Îdz*++İ™\0–,Y‚S§N\É\æYÁZôX‹k\Ñc-z¬Eµ\è±=Ö¢7Ÿjv/2yO¦…µ°…µ°\'Ö¢\ÇZôX‹k\Ñ+¥ZxO&\Í.2‰ˆˆˆ¨\à¸\È$\"\"\"¢‚\ã\"“ˆˆˆˆ\n‹L\"\"\"\"*8.2‰ˆˆˆ¨\à¸\È$\"\"\"¢‚ó\Ô\Ö\Öj÷\É\\¸p!Î=+›3ü~?\Ò\é´v\×w\Ø;\Ã{½^Œs|>_\Î=™Ö¢\ÇZôJ±–ššš¼9\étZveY°`q5ŸÏ—÷\ï<™\ßkq+õZe÷¤k™\É÷k\É\ÆZr\Ï\ÃZ\Üò\Õ288\è\Ú\'“›±\ÛXkQŠ±–İ»wË®)S‡bÀZô\æb-?ş8v\ì\Ø!›‹ò}\ÄZ²±\Ö\ât©µ\è6c\ç\"\Ó\ÆZX‹RŒµ\ìŞ½;v\ìÀ\ã?.SˆfM[[\0p‘\éÀZôX‹^)Õ¢[dòL\"\"\"\"*8.2‰ˆˆˆ¨\à¸\È$\"\"\"¢‚\ã\"“ˆfQ\Ñd\Ù\ì\"\Z–&D“I$“\É)ı\\\ä°õ32\â=!™JDD“ÀE&Í¦\å¨H!&\Û3Bè¾¥CO\Êvƒp=j;\Ğ0…Efûš\0\0›úHô¡%`ı¹zc¯L%\"¢IğTVVj¿]¾d\Éœ:uJ6\Ï\nÖ¢\ÇZôJ±–={ö\à{\î)½o—‡£H\Ö÷#°¦¡8¶\ã\0V¶¢1$µ\à@eZk †\Î@b=qt­\rZ?;Ø‰Àšv ©ñmÀÀ\ÉF4Ö°\0€õó\Õ}\ë\ß\Õ\ë\'\è\ÛTƒ1\0 Ñ‡–\êf¨¥¤UÇ–\Ì\â2r8i\×`¹±×®{}Kİµªñšº]s7\ïW“–†¶¶6øı~\Üw\ß}²« \nõ>*Ö¢\ÇZô\æS-\Ã\Ã\Ã\îo—B\ét\Ú\Õ\æ\0“\ÊI¥R®vj3`\Ù.c2óL&‡µ¸ƒµ\è£\Øj\Ñm|[\n\"õ5ˆõ·\0j*ƒ®]lµ\Î&b\å:Äº\ÔY\Å´‡£\èª<`mĞ‰V\ërøuUQ\Õ@ ğt±\0ª7\İ\Û\ê0°\É>C\Ù1‚º\Æz7VOŒ1\ÄX`ª:FµZB=q¬n±ó[0°r;º›€ĞŠ\n ¶Îªµ#†\à\Ú.\Ô÷t\"¬Ãº¦v\îR466\æz\Í:_»\Åô>b-\î`-ú`-ú0Õ¢\ãM¥R\Ğ\Åøø¸«\Í°.²]…\ÚC)N»údl—ÁZôÁZôQŠµ”\æ\"3„\åKö¥ğ\êkgû®«Bğ\äqô^W=ˆ^„\Ğ}K\rPÛš¹WR]­¨@\âP‹}i<‚ú\Úú\Ã\0Ğ‹\æ­¨\Ûe\ß_¹¹&kö\È\á$\êû\å%õ\ìšZ\×\\\Ûe\ÏÙ…Æ •³ne±«Ö¬ù›–£#8¾\ß<w)\Éõú-\Æ÷k\É\Ö\â\îK±W»Š|µ\èğL\"š%5¨\n\àø~uo\æ\0Ú—“C+*!R_cŸU¬AU0†Nû¤Š†p\ëV}ö¹H\Ç=¡8’Û€-³–\ê¥~	MM÷fZQ\æıV-\ÖB6û\Ì\'®«Bp°1\Ã\ÜDDó™D4;œ\Â\Æ:ûŒ%\ì3…À@gcJÔ ^-\n\ÃQ$\ã\İ9…pœµ™K\áM\İX_k•{©¾4Ôv\0\Ø#Á:¬k²ºB=q$G²s²ÎœN\\ş\Ï57\Ñ|\ÂE&\Í\n\ç\Â2\ël`\Ó:\ÔA\Õ¢qWô¢yk*6Û—Ÿo²¿\\“ı\ítu\0Ú»ùÛª0’\0°ª\ëk\ZÕŒ£\Û^DÊŸ\Ú\Ñ\Ğ1‚Fû’wW\å\ëJÎœ¬ù\'.µk\ç&\"šgø\ìrka-J1\Ö\Âg—S1\â³\Ë\İX‹k\Ñ+¥Zø\ìr\"\"\"\"š^¯\×]x<W›3\0s\Ä$\Ú\È×¯\Â4\ZÇ”\ã$ûdl—ašGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦¢b—\ëõ\ë$ûdl—‘k\ç8¦\'\Ù\'sd»\Ó<jS“\ì“9²]†i5)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûdl—ašGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸ\ìWrn\Æ^QQ‘‘\Ù<+X‹k\Ñ+\ÅZJv3vš\Ófj3öB½\nµ\è±½ùT‹n3v\Ï\âÅ‹µ‹\ÌeË–\áÄ‰²9£¼¼©T\ni{Pu\í>¯×‹²²2cXKN¬E¯k\á=™TŒ\Ú\Ú\Ú\àñx°s\çN\Ù\áû\È4k\Ñc-z¬\Å\íô\éÓ®E¦wllºwµ9öÑ²\İÙ¯\È>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“9²]†i5)\ÇIö\É\Ù.\Ã4\ZÇ”CT\ìr½~dŸÌ‘\í2r\Í\áÇ”\ã$ûdl—ašGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“ıŠş\":\Ñ%\àF6\Ö\ÂZ”b¬\å\ßø:„şğ‡2…hV,_¾UUUø\ãÿ\È-ŒX‹k\Ñ+¥Zt[q‘ic-¬E)\ÆZ¢\Ñ(üq<ıô\Ó2…hVTWWchhˆ‹Lµ\è±½Rª…‹LÖ’…µÌZø\Å*FÜŒİµ\è±½RªE·\È\ä=™DDDDTp¾+®¸\"\ì\Õlªy\å•W\âÜ¹s®v>ŸÈ³q§\×ŞœS¶\ÉÈ—\ÃZôÁZôQŠµ\Ü|ó\Í8r\ä†‡‡AT,V¯^\r¯×‹şğ‡®×¬\n\äyL&§P\ï£|óL&‡µèƒµ\èc>\Õr\î\Ü9\\y\ÕUpÊ¹û’%Kp\ê\Ô)\Ù<+X‹k\Ñ+\ÅZ¸;£™ÚŒ½P\ï£B`-z¬Eo>Õ¢İŒ÷dZXkQŠ±Ş“IÅˆ÷dº±=Ö¢WJµğL\"\"\"\"š\\dQÁq‘IT²B\è\'‘L&qòdÑ°\ìŸ\ê‰#y8\"[\Ñ—?§k\ÂQ$“Ö¼\Ù…œˆˆJ™D¥ªi\ê‚1tXº4€\Ó\ÂpR\"ˆ&»\Ğ”\íB¸@\0@\0ƒ@\âP‹ı\ç´\Ë\\\"\"*Y\\d\Íe\á¨\æ$¬\á®FQƒ\Öø#x\Äqö1\ÔŸ8»¨ù\Ù\Èa»/ŞŠ‰[¸C\è×£?Ğ‰˜3¹©ñx7BÎ¶\\\ÂQ$3¹êŒ¨ıßn\Ä\íš2gI›&\Úx”ˆh\î\á\"“¨$µ£aSˆ¡³ú‹\È\ì®¢k\å\0Z-\è[Úš}\é;Ek­uö3°u™³–½h®Öœ‰\ÜßŒ\ê\êfô\Êvp?bÁ*\Ô`\â,k¿=w\ÍJ`K €@G5›£ˆ ‚\è®:l²Îˆ¶ª@«fALDDÅ‹‹L¢9(s6rs\rP\ÛjŸy\ÌF1´¢6¢+™DÒ¾ô]S?±x‹\Ô\×\0ƒı\ÖbrÿA$œ?}©\Ú\Ñ?Xƒú0€\ëªTó\0ˆ=l/T\Ãıˆ¡\Ëÿi9*D\ã.\ëLf\×\Ú P[Ï³™DDsˆ§¶¶V»O\æÂ…qö\ìYÙœ\á÷û‘N§1>®ıñÌñccc\ÆŸÏ—sO&…µ\è±½R¬\å\î»\ï\Æ]w\İ\å\Ş\'3E²¾5®sŒ\Ö\å\æ]U8\è\Äòxª sE]•\\ù¡«½­hE§\İB·ıs÷sFM¶“»\Ç3r8‰õ\Ã-¨\ŞhŸ\ë´\ë\íD+\êûh\Ë9\"ˆ&\×c\è+¨»­\nxgQkkk\Ã\ÕW_={öÈ®¢|±–l¬%÷<¬\Å-_-ƒƒƒ®}2¹»µ°¥kÉ¹û™\rˆ\"¹¹}›ªÑ¼\ßZ\à\ÕmÁl·ŸıõHn:\rho\êF|W#F²”—¸\ÈDİ‡·£®v\Ä^@Z54´¶\á¨=?ê“­¨8dıl¨\'n]\æŸ\ì¥yšÜŒİµ\è±½Rª…›±•špƒ~™K¸-‡`_†¶w@«¿s°­\É$’Ûª0’\ïrùT¾ø\0\è\ÅÁad]*€\Ä\Òõ™\Ëÿ±´\Û÷”bm—}¹|\\`\Í)\\d•ªıÍ¨4 ½h®8óØ»±:³ÅZ ön¬\Îü\ïö5v_u\Z?giGCÀÑ–\ç‹?\íkÙ‹X„°ne±~±0>º%SS\ÖØªN^6\'\"šs¸\È$¢bï³‰>tN\âR;\Ím\\d\Ñ±Î‚²\Î|ZgY³\ÏvQ)\à\"“ˆˆˆˆ\n‹L\"\"\"\"*8Oee¥v£%K–\àÔ©S²yV°=Ö¢WŠµ\ìÙ³÷\Üs{##{{  p\áğ‹/\É/ñLPûdfSİ¹‡\å\ÄX\0€Aµ—¦F8jm\ï³¶F’\Í4gµµµÁ\ï÷\ã¾û\î“]U¨÷Q!°=Ö¢7Ÿjvma\ä	ƒ\ÚEfee%†‡3£s)++C:\Öî•¤”••!•Ji7í„½\ç’\Ï\ç\Ã\è\è¨\ì\Ê\ÂZôX‹^)\ÖòÀ\à\Ş{\ï\Ú\"3³Ofş…]¾Efö&\î\Ö^™jK÷>™TJ\Ú\Ú\Ú\àõz\Ñ\Ñ\Ñ!»€\"|±7Ö¢\ÇZôLµ$	\×\"Ó›J¥ ‹ññqW›3\0`ll\ÌÕ®B™N§]}2G¶\Ë`-ú`-ú(\ÅZtohÀ>k¨}¦w\Ñ]¢­ñGğH<™yFyæ‘”É¤ög#‡\í¾x+\Ô\áÂ¹Å‘õxHûNeŸ\Ìp\Ôñ\è\Ëº\ãID\Ãö{º·k\Ê<K½i¢-™Œò‘’E*\×\ë·\ßG¬%;X‹»/\ÅZ\\\í*òÕ¢\Ã{2‰J’µ™y1tV™Ï®\á¨õ\äœ@\0@ú–¶N,\ê\ìş\Ö\Ú:¶¡B]\ÏA}m}½y÷\É\Ì\îG,X…\Z\0hZ‡º`ıö\Ü5+-\01\Ôl\"‚¢»\ê0°\É\Ú\'³\åPZ5b\"\"*^\\d\ÍA™³‘›k€\ÚVû\Ìcş3Š¡@°]Iû‰?A ¦~bñ©¯\Ô\ÓxöÄ€\ë‰?!t\Ç[j4\ï—}ù´£°õa\0\×Ue=õ\'ö°½P\r÷#†\n,ÿ§\å¨@\Ğ~2Q]kƒ@m=\Ïf\Í!\\d\ÍA™§ötÄ¬/\á¸öŸ4Pù\â©?ùEMn¶\æşQ>\íı1\Ô\ÔG©¯q?õ\Ç\Å>£Ê§ş\ÍI\\d\Í#½Ï\0µ\ë\Ñİ„\Ì}‘ñ‰óŸ\íı±‰3†M\ëP—¹\\A4YşÀÅœÁtw¢ë±¾v\âR9\à8›\Z®G\rFpü£\Ç1‚\Z¬·kõ\Ä\'u¦–ˆˆŠ™DsY¸a\ng\"­ü–C°/Cw¡ñdgö7¿\Ã\r\è¬Ak2‰\ä¶*ŒØ—\Ë#‡[Q»İxOhj_ü\0ô\â\à0².•@b\éú\Ì\åÿXG\Ú\í{J±¶Ë¾\\>‚\ÎÉ©%\"¢¢\àY¼x±ök«Ë–-Ã‰\'dsFyy9R©\Ò\é´\ì\Ê(//Ç…ds†\×\ëEYY™1¬%\'Ö¢WŠµ\ìŞ½;v\ì˜\ÚFEÉ¹÷\æÄŸ\ër›£¹¨­­\r;w\î”]@¾Ló°=Ö¢\ÇZ\ÜNŸ>\í\Ú\Â(\çf\ì‘Í³‚µ\è±½R¬\å\â6c/6\Öşš5‰>´d\ÎJr‘9—\Í\Ôf\ì…zk\Ñc-zó©\íf\ì<“ia-z¬Eo¦k)3™TJx&Óµ\è±½RªEw&\Ó;66]Œ»Úœ{ƒh\Ù\î\ìWdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“9²]†i5)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûdl—ašGc\Ê!*v¹^¿N²O\æ\Èv¹\æpc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“9²]†i5)\ÇIö\É~…_ü!\"\"\"¢‚\ã\"“ˆˆˆˆ\n‹L\"\"\"\"*8Ï¢E‹´_ü©ªª\Â\ĞĞl\ÎX°`FGG‘\ÊõPt¯7sƒh®kõ~¿eee8ş¼\ì\Ê\ÂZôX‹^)\Ö\Ò\ßß‘‘ü\êW¿’)D³bÉ’%ø\Ş÷¾‡.`Ç²»(\ßG¬%ka-N—ZË™3g\\_ü\á\"\Ó\ÆZX‹RŒµ|\å+_Á¿øE<ö\Øc2…hV\\v\Ùe¸ıö\Û166\ÆE¦k\Ñc-z¥T‹v‘µ‹\Ì\Ê\ÊJ\ËæŒ²²2¤\Ói\íD\0\àñx\à÷û‘J¥0>®^¯>Ÿ£££²+k\Ñc-z¥X\Ë<€{ï½—[QQikkƒ\×\ëEGG‡\ì*\Ê÷k\É\ÆZX‹Ó¥Ö’H$Ü‹\Ì\\›±/Y²§N’Í³‚µ\è±½R¬¥46c§R3S›±\ê}T¬Eµ\èÍ§Z´›±ór¹…µ°¥k\áf\ìTŒ\Ú\Ú\Ú\0€—\ËX‹k\Ñ+¥Zt—\Ëù\ír\"\"\"\"*8.2‰ˆˆˆ¨\à¸\È$\"\"\"¢‚\ã\"“ˆ\\\"‡“ˆ÷„\0DM&\rËŒÉˆ šŒ£»)O[S7\â‡Bw<‰d\ÒV—(\Í3Nhz\ç\'\"š‡¸\È$\"!„\åKe[4u#lEMVc\İÛªp`Í»\Ñ\\@ @`Sˆ¡3`ı¹zco\ÖO\\”pTn^§\ŞéŸˆh\â\"“h.G‘<‘­\0€PO\É\Ã\İg\èG¬¶d\Éd\ÖOYg*­6\ëc¨g;\Zƒ@p­cQV\Í\Ê\ì¹\Õ\Ïfjpœ<\\o·Ášg°eSV„[Qw´\íÎ¶,\Öx™3©\á(’ñn„\ìÿv¶\çŠwCoœø;:\ëÚ»P\×bÿ­Oö\ì\ì\Ôç¨6%¢y‹L¢RV[lµ\Ï\ÎÕ¶b;¶ \èD5¨‡\Ğo:\ì3x#h\Ü\Ö\rlÜ‚¾8´\Íû­ajĞ@ €\ÎÁ \Z[\"\ÖY\É\Í\è\Û@ Ğ‚¾¥­ˆ÷„¬*ú\Ğ \Ğ\ÇY\Ëv4T7CŒ\Ô\×`\äY\Ù\êÔ‹ƒG¨Xa-\Ö\"õ5H=hlDU¿=?\Z±½\'„£\èZ9`\Ío×•Y \î?‘\ÚzD\0´¯	 aR‹Ì©\Íê‰£\Ö\ï3Ğ‰\çBˆhñ\Ô\Ö\Öj÷\É\\¸p!Î=+›3ü~?\Ò\é´v\×w\Ø;\Ã{½^Œs|>_\Î=™Ö¢\ÇZôJ±–»\ï¾w\İuWfŸ\ÌPO]kƒ\ÙÉ‰>´8r¡¸µ\àªnF/\"ˆ&\×chS5š÷‡\Ğ\ïB\ÕÃÀfyù:¾M[€m]¨;Ú‚\ê5ˆ&­…hC\Ø³ò\0ıõH\Ş2”™\Ïjÿ1ú–¾\Íş¹^û,©š\Ó¾©ñ]u\ÈÔ±\Ø\ê\è\Ï\äT\á@ Á:\Ã\ÙÔø6`KõA¬Sù\×E5ó@\Ëğz÷\ïe°5\íöYI\Í|\Ò%\Ìß‰V´\Öf—8¤~¥§­­\rW_}5ö\ì\Ù#»Šò}\ÄZ²±–\Üó°·|µºö\É\äf\ì6\Ö\ÂZ”b¬%\çf\ì\á(’õıö\"*\Û\ä™bhı$º\ãE´\ÈT‹Ã‡Pw°¥º½aı\"¯ex½UŸ\æ÷qÑ‹\Ì)\Ìß‰V¬.\İE¥\Ä\Í\Ø\İX‹k\Ñ+¥Z¸;9\Ä0”°/C\İc©\î\Õ\Ì\ã\É!$‚uX\×\0!¬[DbØº´\\¹Îº?1\\/Î’J½8~2ˆª\ëd»Ô‹\æ‡GPwK .U€kşzŸj\×Û—¨­û)\'î‹¬AUp\ÇML­\É\ÏN ¸¶5\ë~\×\É\İûIDTz¸\È$š\Ë\Â\r9\Î\ÚMF/š«;«mµ¾¨²¹}›\ZĞ^?)¾ø#\íoFu\Ç\Zw%‘Lv¡ñd\'ª7ö¢w\ãô¡]\É$’õ@Lşœ\Ğ\ŞCMı$–µ\á~Œ¾\ì3„u\Û\ìùÑ‡-{pZÁU—5F=jû\Ñ>¥/ş\Ø&9\ï\ÆjtÖ 5™D2ÙŠŠC-“¼÷“ˆ¨ôğr¹µ°¥k\Éy¹|Î³¾|t¼Z]š\ÎA\\F8Š\äf 3sI;¿\È\á8–w\å¹TK\æ/E¼\\\î\ÆZôX‹^)\Õ\Â\Ë\åDTdz\Ñü0Ğšc&\Ø÷;&7\× ö°û\Û\é“¢.jYù‰ˆ\æ!.2‰hv\å¹\äß»±\Z€\Ør(Ü€ÀT\Î\"\æ™Ã¤ ó\ÍC\\dQÁy*++µ÷d.Y²§N’Í³‚µ\è±½R¬eÏ=¸\ç{JğLš\Ë\Ú\Ú\Ú\à÷ûq\ß}÷É®‚*\Ôû¨X‹kÑ›Oµ»\î\ÉôƒA\í\"³²²\Ã\ÃÃ²9£¬¬\étZ{ó§RVV†T*¥İ´öM¤>Ÿ£££²+k\Ñc-z¥X\Ë<€{\ï½w\Æ™‘\ÃI{¿\Ç\ì}2§Æ¹OfQ\ÇsË³6(o\êF¼¥Kß†F±:dn!…£Hn\Öm²+Àzò¡I»¡>Ü›\ê³¶¶6x½^ttt\È. \ßG¬Åµ\è±=S-‰DÂµ\Èô¦R)\èb||\Ü\Õ\æ\0sµ«PE¦\ÓiWŸÌ‘\í2X‹>X‹>J±\İzú„°|©l»4‘\Ã\Öv>€õˆK¬\í²·\n¡{[¬y7š«\í\Ç[n\êC1t¬?O\Ë\ê¾Jk\ÎAk1kı9÷\ÂpòzÑ¼u\ë\r_hR÷z-\èK\01õx\Ï9²ÀTr½~‹ñ}\ÄZ²ƒµ¸ûR¬\ÅÕ®\"_-:¼\'“h.G‘Ì±	õÄ‘<Ü\îx\Ò\Úóp\ÄjK&›®[†[mqt7ÁzşxP\ì“Y\Í\Ê\ì¹\Õ\Ïfj°6@·\Ú\ê\í6\ëY\á™\Å\âşƒH\Ø\áV\Ô\í4,\ê¬ñ2{Z†£HÆ»²ÿ\Û}Ø+\Şmm\0¯şŞ®º¦@\Í8\æ·ÿ\ÛÓ¸=v¦¦¦‰¶¬\Í\ì÷7\ã\0\ìá›ºw\ÔhT¨ù‰ˆf™D¥¬¶\ØjŸ¬m\ÅvlA Ğ‰jP¶.\éBA\ëA\ã¶n`\ãô%€Ä¡-™-j\ĞoŸñ³Ÿ\ÔÔø\æ\nôm²\Ï\Ä-mE¼\'d-PÑ‡–@\0~\èŸøÓ´uÁú\Ã@¤¾#Ïš\Î\ÛYOªXa-¹\"õ5H¨§\îQ\ÕoÏFl\ï	\á¨õ(Mu†pi\ë\Ô6]€p?bÁ*«vG­\0P³\Ø \ĞC\Í\æ(\"ˆ º«›¬\ßaË¡Š¬\í˜b\Ã@]c\ÈÚ¼~²g(8?\Ñl\â\"“hÊœ­\Û\\¨\'ö\èÎ”%pp?€ı\Ç1‚„ıÄš†°³\Ôl¶Ï‚m®q<*1[¬\ß:\×¶OA^W… \Z\Û^+\í\Ç+ªE`¸_ó\Äµ(j@;BX¾4¡\'eN¶Ş¾`\å:„\ìü\ÌSw}\è\Ã1\rB+*€ ıÄ¡d\Zƒ˜\Ü…²´£°õaû\ïi?%À\Ä^™\á~\ÄP\åÿ´\ÚOJZ÷X\Ö\Ög\Î&ö>;‚`¥v©mP¸ù‰ˆf™DsP\æ~¾0\Øy	÷ò%ì³‘*.ò‰8“\ÑÔx²ıScÿA \ë\Â\ëPµ°5P¿±?¦z\Üe¤¾&³À\Îm\âş\ÑB\İ\Ó9\Ûó™DóVC	ûò7\Ô=–“¼§\ï\É!$2g=\í3˜\ÃöÅ•\ë¬3ª\áú‰\Ë\åMİˆo¶d-€zqüdU\×e\Zr\èEó\Ã#¨»¥PgI\ÇYW5½Ï\0µö}öıŒñ\×ù\İüÂ\è\Ãz¬¯¸T\r8ÎŠ†\ëQƒÿ\èqŒ \ë\í9B=ñ\ìûCWT 1\ì>Ÿ›W\æ\'\"šM^¯\×]x<W›3\0s\Ä$\Ú\È×¯\Â4\ZÇ”\ã$ûdl—ašGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦œ¼.\áI6@/š«;S—\Û7W oS\ÚÑ‹\ã\'\Å¤ıÍ¨\î±/\Óv¡ñd\'ª7ö¢w\ãôÁ¾\\]ûry\İ\Û\Z\Ì\\Æø\âŠ:c—W¸#AL\\*·\Õm³\çG¶l\ì\Â\rh9W]Sú\â\r`]‚FÖ¥j\0H,]Ÿ¹µ \ÖÑ€v´£Áş¶¼u¹z™3\Ê!¬[i\×<+óÏŒ\\¯_\'\Ù\'sd»Œ\\s8\Ç1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“9²]†i5)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûd¿’s3öŠŠ\nŒŒŒ\È\æYÁZôX‹^)\ÖRº›±\ç\ßO°Ï²\Ş24±d8Š\äfLi?\ËHO7b\'»\0¡;Ş…ª‡\Õş ÖŸ\ëNa\ÏÎ¦n\Ä[£ú¢>`ş0S›±\ê}T¬Eµ\èÍ§Z´›±/^¼X»\È\\¶lNœ8!›3\Ê\ËË‘J¥N§eWFyy9.\\¸ ›3¼^/\Ê\ÊÊŒ9`-9±½R¬e÷\î\İØ±cG	.2\íc}\Î3²j\Óò˜sCø)/2#\èî‰¡yR4{\ãø¬MÑ§º\È¡;¾\Ø:\ÅûO\Í?3\Ú\Ú\Ú\àñx°s\çN\Ù\áû\È4k\Ñc-z¬\Å\íô\éÓ®E¦wllºwµ9öÑ²\İÙ¯\È>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“9²]†i5)\ÇIö\É\Ù.\Ã4\ZÇ”3/\ä¹ä¯¾\ä”õÄ¡p\Ã¿\à\Ò>\É&\0´£ÁõEª^4WOecø^4W_\Ìš\æ\äzı:\É>™#\Ûe\äš\Ã9)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûdl—ašGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'ûıEt\"\"\"\"¢KÀE&™DDDDTp\\dQÁq‘IDDDD\ç»\âŠ+\Â\Î\Í4U\\y\å•8wîœ«]…\Ï\çòl\Ü\éµ7\ç”m2ò\å°}°}”b-7\ß|39‚\á\áa‹Õ«W\Ã\ëõ\â‡?ü¡\ë5«y\Ş#“\É)\Ôû(\ß<“\Éa-ú`-ú˜Oµœ;wW^uœrnÆ¾d\Éœ:uJ6\Ï\nÖ¢\ÇZôJ±–\ÒİŒæ²™ÚŒ½P\ï£B`-z¬Eo>Õ¢İŒ}Ñ¢E\ÚEfUU†††dsÆ‚0::ŠT*%»\0{•«6\íÌµ’\ß\ïGYYÎŸ?/»²°=Ö¢WŠµ”ôf\ì4gµµµ\0v\ì\Ø!»Šò}\ÄZ²±\Ö\ât©µœ9sÆµÈ´\Î{™DDDDTp\\dQÁq‘IDDDD\ÇE&™DDDDTp\\dQÁyjkkµûd.\\¸gÏ•\Í~¿\ét\Z\ã\ã\Ú\Ï\ì?66f\Ìñù|9÷dRX‹k\Ñ+\ÅZ\î¾ûn\Üu\×]\Ü\'“ŠJ[[®¾új\ìÙ³Gv\åûˆµdc-¹\ça-nùjt\í“\É\Í\Øm¬…µ(\ÅX7c§b\Ä\Í\Ø\İX‹k\Ñ+¥Z¸;\Í.2‰ˆˆˆ¨\à¸\È$\"\"\"¢‚\ã\"“ˆˆˆˆ\n‹L\"\"\"\"*8.2‰ˆˆˆ¨\à<•••\Ú-Œ–,Y‚S§N\É\æYÁZôX‹^)Ö²g\Ï\Üs\Ï=\ÜÂˆŠJ[[ü~?\î»\ï>\ÙUP…zk\Ñc-zó©–\á\áa\×F`0¨]dVVVbxxX6g”••!Nk÷JR\Ê\ÊÊJ¥´›v\Â\Şs\É\çóattTvea-z¬E¯ky\àp\ï½÷r‘IE¥­­\r^¯²(\Â÷kqc-z¬E\ÏTK\"‘p-2½©T\nºwµ9\0\Æ\Æ\Æ\\\í*T‘\ét\Ú\Õ\'sd»Ö¢Ö¢R¬E÷†&*¹^¿\Åø>b-\ÙÁZ\Ü})\Ö\âjW‘¯Ş“IDDDD\ÇE&™DDDDTp\\dQÁq‘IDDDD\çõz½Ğ…\Ç\ãqµ9€1GL¢|ı*Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“9²]†i5)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûdl—ašGc\Ê!*v¹^¿N²O\æ\Èv¹\æpc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“9²]†i5)\ÇIö\É~%\çf\ì‘Í³‚µ\è±½R¬…›±S1š©\Í\Øõ>*Ö¢\ÇZô\æS-\Ú\Í\Ø/^¬]d.[¶\'Nœ\Í\å\å\åH¥RH§Ó²+£¼¼.\\\Í^¯eee\Æ°–œX‹^)Ö²{÷n\Ù<e^¯7³\Ï\Ùlc-zs±–\ìÜ¹S6Eø>2\Í\ÃZôX‹kq;}ú´{‘¹h\Ñ\"\í\"³ªª\nCCC²9cÁ‚Í½§×›)&×\Ê\ï÷£¬¬\çÏŸ—]YX‹k\Ñ+\ÅZjkks\Ö\âóù\à÷ûs¾ñ•¿ø\ÅøÕ¯~%›3ò`ÔltttN\×r\Ë-·\àøñ\ã8r\ä0ËµHsµ\İöb|±–l¬…µ8]j-gÎœ\á\"“µL`-¬\Åi>\ÔRQQüü\ç?\Ç\Û\ßşv`k\Ña-z¬Eµ\è±½\é®E·\È\Ôß©IDT‚n½õV¼ğ…/\Äò\å\Ë3‹L\"\"š\\dÑ¼PQQ}\èC\0€Å‹£­­M¦Qq‘IDóÂ­·ŞŠ«¯¾:ó\çW¼\â<›ID4¸\È$¢’WQQM›6á·¿ı-ÎŸ?3g\Î`ñ\â\Åø‡ø™JDD\â»\âŠ+\Â^Í¦šW^y%Î;\çjW\áóù€<wz\í\Í9e›Œ|9¬E¬E¬Eó¹–{\ï½¯|\å+\Ñ\ÙÙ‰\ãÇ\ã»\ßı.~ı\ë_\ãõ¯=şy<ñ\Ä®ŸSQ\èZd›3fú÷\"ÛœÁZôÁZôÁZô1Ÿj9w\î®¼\ê*8\åÜŒ}É’%8u\ê”l¬Eµ\è±½ù^\Ë+_ùJü\â¿À–-[ğ£ı‡Â›\ßüf<õ\ÔS3^K.³ñ{É…µ\è±=Ö¢7Ÿj\Ñn\Æ\Î-Œ,¬…µ(¬¥´kÙ¶mx\â	üÛ¿ı0ËµH¬Eµ\è±=Ö¢7İµp#\"\"\"\"š\\dQÁq‘IDDDD\ÇE&™DDDDTp\\dQÁq‘IDDDDç©­­\Õî“¹p\áBœ={V6gøı~¤\ÓiŒk<³cü\ØØ˜1\Ç\çó\åÜ“Ia-z¬Eµ\è±\Ëÿù?ÿ?ù\ÉOğ\È#\0³\\‹\ÄZôX‹k\Ñc-z\Ó]\Ë\à\à kŸLn\Ænc-¬Ea-¥]7cg-:¬…µ(¬\å\âj\áf\ìDDDD4#¸\È$\"\"\"¢‚\ã\"“ˆˆˆˆ\n‹L\"\"\"\"*8.2‰ˆˆˆ¨\à¸\È$\"\"\"¢‚óTVVj·0Z²d	N:%›gk\Ñc-z¬EµX¶lÙ‚ı\èG8t\è0ËµH¬Eµ\è±=Ö¢7İµ»¶0òƒA\í\"³²²\Ã\ÃÃ²9£¬¬\étZ»W’RVV†T*¥İ´öK>Ÿ£££²+k\Ñc-z¬EµX¶nİŠ\'x}}}À,\×\"±=Ö¢\ÇZôX‹\Şt×’H$\\‹Lo*•‚.\Æ\Ç\Ç]m\Î\0€±±1W»\nUd:võ\É\Ù.ƒµèƒµèƒµèƒµL´;Ç\ÍZd°}°}°}°}Lw-:¼\'“ˆˆˆˆ\n‹L\"\"\"\"*8.2‰ˆˆˆ¨\à¸\È$\"\"\"¢‚\ã\"“ˆˆˆˆ\n\Î\ëõz¡\Ç\ãjs\0c˜DùúU˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“9²]†i5)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûdl—ašGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Û=O\ÖØ¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“9²]†i5)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûdl—ašGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“ıJ\Î\Í\Ø+**022\"›gk\Ñc-z¬EµX\äf\ì³Y‹\ÄZôX‹k\Ñc-z\Ó]Ë°n3öÅ‹k™Ë–-Ã‰\'dsFyy9R©\Ò\é´\ì\Ê(//Ç…ds†\×\ëEYY™1¬%\'Ö¢\ÇZôX‹%\ã‰\'ÀÁƒY®Eb-z¬Eµ\è±½\é®\åô\éÓ®E¦w\ÌŞ˜X\Æøø¸«\Í\0Œ9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“9²]†i5)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûdl—ašGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èöñññ¬±Mó¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“9²]†i5)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûdl—ašGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'ûıEt\"\"\"\"¢KÀE&™DDDDTp\\dQÁq‘IDDDD\ç»\âŠ+\Â^Í¦šW^y%Î;\çjW\áóù€<wz\í\Í9e›Œ|9¬E¬E¬E¬ÅŠ††ŒŒŒ\àØ±cğ\Îr-2X‹>X‹>X‹>X‹>¦»–s\ç\Î\áÊ«®‚S\Î\ÍØ—,Y‚S§N\É\æYÁZôX‹k\Ñc-¹ûl\Ö\"±=Ö¢\ÇZôX‹\Şt×¢İŒ}Ñ¢E\ÚEfUU†††dsÆ‚0::ŠT*%»\0{•«6\íÌµ’\ß\ïGYYÎŸ?/»²°=Ö¢WŠµ\ìŞ½«V­’\İS\âñx0>®}»Ï¸Ù¬¥¼¼cccf¹i.Ö²s\çN\ìØ±C6\åûˆµdc-¬\Å\éRk9s\æ™¬ek™;µ\ìŞ½;v\ìÀ\ã?.SˆfM[[\0p‘\éÀZôX‹^)Õ¢[dZ×‰ˆˆˆˆ\nˆ‹L\"\"\"\"*8.2‰ˆˆˆ¨\à¸\È$¢\Â	G‘L&‘<‘=z\á(’\É8º›\Äÿ.ˆº\ãS¨%\'{œx7B\ÎÖ¸U\ïC…®{:~DD3‹L\"*˜H}õ?j\ë1\å¥]¸@5š÷Ë‹Õ‹\æ\ê\0k\Úe\Çõ\â\à\Ñ¬ÃºÌ¢/„u+ƒ@b\0\ß]èº‰ˆJ™DTM\İX_$cH õaÕ¡\ÎF\'­3\â¬ \à>{9l\ç:ÏŒ6u#®Ú’ID3sDuµ\Ë3™\Ù9ñ«‚\ÈaQ[2\êZ ÷ö\r  \ê\Z\íª›Ö¡.$D¯\ël¬\ZGı]Ä™P;\'«Fù÷$\"*\Ú\ÚZ\íF.\ÄÙ³ges†\ß\ïG:Î¹š\Ú1~llÌ˜\ãóùr~]^a-z¬E¯k¹û\î»q\×]wõF¡8º\Ö}›¶\0Ûº\Ğx²\Ó>‹Bw¼Áú6U£y\Ñd+*µ ú\ÙV$7WX\í\×E3ÿû`£\Z«\Z\Í\èF|W#F:Z0tKê¶ zc/\"‡“h]Ú‡–\êƒX\ïB#ú\ĞR\İô\ÄÑµvN,«:bV\rvNo8Š\ä\æ\Z\Ä:\è¯O¢µÖ®Í‡¬9»¬ŸŸ˜£\íaU·ı÷†£¦<sw®ˆ£kå€£\İı»(\æ3¤mmm¸úê«±g\Ï\ÙU”\ï#Ö’µä‡µ¸\å«eppĞµ…÷É´±Ö¢c-Å¿O¦½³–\Îj4\ï\Ï^ õ:lW¡K³°:Ş¢\Íp.õY\Ì­?$ú\ĞR}­jÑª[\ìD k¹½P\r !s\Ñ\ê\ëD«c.\Ç8k,\Ã\"Ú±8<Ş’Dk­ú‰˜µT\ç\"³!lŸ\İ\Õ\ëod/v\ç\Ğ\"\Ü\'3k\Ñc-z¥T÷\É$¢\éa_>Fm+’É¤½t\\^.\ërw\×\Ê´\è”ı\Ó+sÉ¼¥uA \Ö\ï¾×³}M\0M}H\0\0jĞª¹ô\î9œDrW6\èˆ\Én\"¢9‹L\"ºd‘–FCg €@ €@ }	 ¸r\İÄ½—™/\ÎÔ J\İÏ˜5Ê„Ø°ó‹6\Ö\â2~ø\r¨€ú¹–/\Ídc\È9—\î›\Ùûb \ÔÜ¢\î‹lEc…bNöÁ\Ú\ZC\æ~PÅ¾¿²\å8ª´²–š@/Ÿ¬B\r€ĞŠŠLşò¥°¾<´\ß\ÙNDT\Z¸\È$¢KA}-€Á~L,\Ù4\ß\ÈNŒ j[\Éd+j}\Ø\".G;õn¬F\ç`»\ìüÁNT¯ù\ß80\×v!™\ìBöÂ­\ÍÕˆÑ•LÚ—¢\åefwN\âP‹}\é|²\ì¿\ä\ßU\éEó\Ö>$gsc\rh\Ğ\Ş³\Ïl&\ÑZ92‘ÿp°k\êZ	$D\ÕubX\"¢9Š÷d\ÚXkQŠ±–\â¿\'\ÓDŞ“I¥‚÷dº±=Ö¢WJµğL\"\"\"\"š\\d\Ñ4³7E\çYL\"¢y\ÅSYY©½\\¾d\Éœ:uJ6\Ï\nÖ¢\ÇZôJ±–={ö\à{î™£—Ë©TµµµÁ\ï÷\ã¾û\î“]U¨÷Q!°=Ö¢7Ÿjv].÷ƒA\í\"³²²\Ã\ÃÃ²9£¬¬\étZ{]^)++C*•\Òn\Ú	ûú¾\Ï\ç\Ã\è\è¨\ì\Ê\ÂZôX‹^)\ÖòÀ\à\Ş{\ï\å\"“ŠJ[[¼^/:::dP„\ï#\Ö\â\ÆZôX‹©–D\"\áZdzS©t1>>\îjs\0Œ¹\ÚU¨\"\Óé´«O\æ\Èv¬E¬E¥X‹\î\rMTr½~‹ñ}\ÄZ²ƒµ¸ûR¬\ÅÕ®\"_-:¼\'“ˆˆˆˆ\n‹L\"\"\"\"*8\î“ic-¬E)\ÆZx\â	<ö\ØcøŸÿù™B4+^ñŠW\à\ìÙ³xúé§¹O¦k\Ñc-z¥T‹nŸL.2m¬…µ(\ÅX\Ë7¾ñ\r<üğ\Ãx\ì±\Çd\nÑ¬¨¨¨Àºu\ëpüøq.2X‹k\Ñ+¥Z¸\Èd-YX\ËÜ©en?ñ‡JŸø\ã\ÆZôX‹^)Õ¢[dz½^/t\áñx\\m\Î\0`\Ì“h#_¿\n\Ó<jS“\ì“9²]†i5)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûdl—ašGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rˆŠ]®×¯“\ì“9²]F®9œ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“9²]†i5)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûdl—ašGc\Êq’}²_É¹{EEFFFdó¬`-z¬E¯k\áf\ìTŒfj3öB½\nµ\è±½ùT‹v3öÅ‹k™Ë–-Ã‰\'dsFyy9R©\Ò\é´\ì\ÊP§Usñz½(++3æ€µ\ä\ÄZôJ±^.§b\Ô\Ö\ÖÇƒ;w\Ê. \ßG¦yX‹k\Ñc-n§OŸv-2½ccc\Ğ\Åøø¸«\Í°7ˆ–\í\Î~Eö\É\Ù.\Ã4\ZÇ”\ã$ûdl—ašGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦¢b—\ëõ\ë$ûdl—‘k\ç8¦\'\Ù\'sd»\Ó<jS“\ì“9²]†i5)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûdl—ašGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸ\ìWôÑ‰ˆˆˆˆ.™D49\á(’ñn„dû4ˆN\"\Ş\ã)\ÔGòpD6Q\â\"“ˆŠLË—\Ê6K\ï\ÆjÖ´\Ëf\"\"*B\\d\Íe\áh\Î3{\ÖY¿(¢\É$’É¤#/„\î¸İ–Œ£»	\0\"ˆ&\ã\è\î‰:\Ú#™Ÿ8«X…Võ³\ê¬f8Šd<Šh\\\Í1ñs\ã[g\'£a{˜g®\Õ\êÙ\Æ \\»İ®!\è\á8’\É(Rg2s:k±\ç±Ú¬~÷œDD4¸\È$*eµ@ €À¦>$j×£»	ˆ\îB\ã\ÉN:FĞ¸+\nkùDce?\0:ƒh\ÜUş@\0-‡®\\g-\â‚5À\Ã-\èC#¶«\Åg°C[¬‰¡;\Ş\nt&\Æ\ßf-\0\Û\×\Ğ |¡õ¨Tµ\ÄPsK7°qú@\â\Ğ4\ï·\êªŞ‚@ ½\ÎVs:6¢5l-x[kc\è\Ø:„Š óˆˆh&yı~?t\áñx\\mÎ€ıµyÙ®\Â\çó\0|>Ÿ«O…Ú¼S¶\Ë`-ú`-ú(\ÅZ<œB=q\ël\İ\æ\Z ¶\Õu6/#1„\0\ì?kw4\ëRt¬ß¾\ä\îGXnŸmT\í±\á0Øv\0½\Ï:÷U‹¡?\0½8x4`e\İ>‚\ãû UA f³}6qs\r¬\Ã:{|©·o\0	»ş(\Z¨n\Î^H\ÚFÕ¶\Ús\Æ0”°Z\"õ5™º±ÿ \ìvš>¹^¿\Åø>b-\ÙÁZ\Ü}~\Ö\âjW‘¯oYYt\áóù\\mÎ€=‘lW¡&ôÛ;Ò…*X¶\Ë0\ÍS\ÆZrk\Ñ\Ç\\¬E.2{7Vg\ÎşA	Ì±@›y	ôm²\Ïdª\í3’\Zû›Q­\ÎbnN\"™TgUi®ğ\Ú{ô\É(\Æ÷k\É\Ö\â\î+c-®vùj\Ññ?ºH¥R®6g\0À\èè¨«]…Ú¬óÂ…®>£££\0\àj—ÁZôÁZôQŠµ\äÚƒl\êzqü$PSo/\å\Âõ¨ÉœœŒ\ZÔ‡ „u+ƒH\ÇDC‰ \Z[\ÔøQ\ã\Â1\Ô·\î÷7X—ôe\Âµ÷Ç€\Úzk¾¦u¨\ã\åòi—\ë5^Œ\ï#Ö’¬\Å\İwµ¸\ÚU\ä«E‡÷d\Íe\á†)Ûº}Mú–Ú—\Ø7W oSƒuyyRb@}\Éd\ZÑ‡-\å¹\Ó^4Ww\"¦.\á;\Æ\×}ñ§w\ã¬\ì²rw5b¤£\íöB\Øú\âOv~^\átÖ 5™Dr[F.u\ÕJDDÍ³h\Ñ\"\íc%«ªª044$›3,X€\Ñ\ÑQ¤R)\ÙØ—P\Ô\ã‡r…Q§\\s­€Ö¢\ÇZôJ±>Vò\"4u#¾«›—\ëé’´µµ\0v\ì\Ø!»Šò}\ÄZ²±\Ö\ât©µœ9s\ÆıXÉ¬?\Íeaµ“uf™o¨\ÑL\ã\"“ˆJG¸Áñ…£\0ª]—ó‰ˆh¦p‘IDDDD\ÇE&QÉšx²\ÏÉ“\î/\İ8\éŸ	nı¼õsÎ§9Ÿ¤\á¼d¹¿eNDD¥‡‹L¢RÕ´uA\ë\é7K—ºŸ¶3¡\íO	\nX\ßŸxÔ¤\à¸d\İ9$µ\ØÊ·Ø‰ˆh®ó\Ô\Ö\Öj¿]¾p\áBœ={V6gøı~¤\ÓiŒk^¯ccc\ÆŸÏ—ó›L\nk\Ñc-z¥X\Ë\İwß»\îº\Ëı\íòp\Éú~\Í6FD“­¨€\Ä\ã¿ñZø¶š¡8º\Ö\ÚHv\"°¦\İj«<€ÀšvD\'\ÑZ C\Öc$\å5r8‰õ\Ã-¨\î[‡ø6`K\à3y{­ZoBKu3zBw¼U·`\è–.T\íC\Å\ÚF\Ä:\ìùšº\ßeµ1tr‘Zt\Ú\Ú\Úpõ\ÕWcÏ=²«(\ßG¬%k\É=kq\ËW\Ë\à\à \ë\Û\å\Ü\Â\È\ÆZX‹RŒµ\ä\Ü\Â(\ç\"S-Òªp Ğ‰\åñ.T=@t½\0:WØ‹\Ìşz$7\ÃZ\ĞÙ‹¼µ\èËˆ š\\¡Il\r”µ\ÈD\Ñd=ú3cO\ÔÖˆ>«¦pÔ¿õ9œ‹`*\Ü\ÂÈµ\è±½Rª…[•ˆI?»\\­¨\0‚\èJ\ÚªOÿ™Ô³¿Cè·ù˜n\í\è´Ÿt]‚j\0±‡\í3¡\êY\êÿ´¢q—u?g\×\Ú\àÄ“|ˆˆhN\à\"“hº¤g—«|“>;A4¹\Ø*\ÏlN^{5õD\êk\ë\Ï7¯u?\éD­¼\\ND4—p‘I4ô>;Ô®·\×h}c\Üù\Ü\ÏşV—º/\æ¦C¸}Xõµ1ô;ª®g©ô8FPƒõvm¡ø¤\Î\ÔQñ\à\"“h.›\ê³\Ë\Ã\rh9û2t\ZOvfoX\ã\Ùß‘Ã­¨\İnG¼\'d\İ÷9¥\Å_/#\ëR9\0$–®\Ï\\şu4 \íh\Ø\Ô¬µkŞµv“=SKDDE‹L¢Rµ¿Õ´£\Í\Õ—¸3—\Ú—\Ê{7Vgşwû\Z»¯º\rö\Ïe\ÚQ½±×šÃ°øk_#ŸºÂº•A÷¥ò£[2\ãf.\Å\ïoF5/•\ÍY\\d\Ñ‰ š´¾I\Şy‘÷t\Ñ\Üá©¬¬\Ôna´d\Éœ:uJ6\Ï\nÖ¢\ÇZôJ±–={ö\à{\îqoaD4‹\Ú\Ú\Ú\à÷ûq\ß}÷É®‚*\Ôû¨X‹kÑ›Oµ»¶0òƒA\í\"³²²\Ã\ÃÃ²9£¬¬\étZ»W’RVV†T*¥İ´öK>Ÿ£££²+k\Ñc-z¥X\Ë<€{ï½—‹L**mmmğz½\è\è\è]@¾X‹k\Ñc-z¦Z‰„k‘\éM¥R\Ğ\Åøø¸«\Í\0066\æjW¡ŠL§Ó®>™#\Ûe°}°}”b-º74Q1\Èõú-\Æ÷k\É\Ö\â\îK±W»Š|µ\èğL\"\"\"\"*8.2‰ˆˆˆ¨\à¸\È$\"\"\"¢‚ó,Z´H{³\×t?HEôPw°\Ö\âPŒµ|\ë[\ßÂ¿üË¿\à‡?ü¡L!šË—/\Ç\r7Ü€§Ÿ~\Z;v\ì\İEù>b-\ÙXkqº\ÔZÎœ9\ãú\â™6\Ö\ÂZ”b¬\åñ\ÇG4\Z\Å\ÓO?-SˆfEuu5\Æ\ÇÇ¹\ÈX‹k\Ñ+¥Z´‹\ÌÅ‹k™Ë–-Ã‰\'dsFyy9R©\Ò\é´\ì\ÊP\Å\ä\âõzQVVf\ÌkÉ‰µ\è•b-»w\ïÆ;¸…•¶¶6x<\ìÜ¹SvEø>2\Í\ÃZôX‹kq;}ú´{‘™k3öŠŠ\nŒŒŒ\È\æYÁZôX‹^)\Ö\Â\ÍØ©\Í\Ôf\ì…zk\Ñc-zó©\íf\ì<“ia-z¬Eo¦k\á™L*F<“\é\ÆZôX‹^)Õ¢;“\éƒ.\Æ\Ç\Ç]mÎ€½A´lwö+²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“9²]†i5)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûdl—ašGc\Êq’}2G¶\Ë0Í£\Æ1\å»\\¯_\'\Ù\'sd»Œ\\s8\Ç1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“9²]†i5)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûd¿\Â-Œˆˆˆˆ¨\à¸\È$\"\"\"¢‚\ã\"“¨dDM&‘\ÔD4,s ©q\Çñ\Õ\"\ï†ı§K\ÓÔø\á\È\Ä\"ˆ&\ã\èn’\íS\ê‰#™w.\"\"Ê‡‹L¢’Ñ†@\0@\0\èC‹ı\ç†B/2\ÃQ$w\Õa`“=_ +»&šB÷¶*X\Ó\ìoÆ–\áõÓ³X&\"¢iÁE&\Ñ\\N\ê¬[¨\'>qf\ÓÎ·\Î\Øu£;>\Ñ>‘E¹\ÏVF\êk8´\Íû\Õ½h\ŞÚ‚}™)-\á¨æŒªu\Æ1z8™\ÇY\ß\Ä\ÑV\Ô\íD»=T\ï\ÆÀ-\Ö\ÒPO<ç‚¶ªE\å<«\é<\Ëkÿ\İ \ê›\Äï‘ˆˆ&\Ï\ë÷û¡\Ç\ãjs\ì¯\Í\Ëv>Ÿ\0\àóù\\}*¼^k+\Ûe°}°}”b--E\×\Êû¬fú–¶Nœ¬­¶\ØÔ‡Dm+¶cN\ÄPƒú0º\î8¶8ÎW®C\Ô\×#\ÏöfÏ³¿\íû³\Û\"\è·\Ït\Ğr(šzµ¢bx´‡£\èZ;‚\Î@\0@\'F\Öv!\Z¶²\Ùs\Ä0„:¬kz7V£z£˜\0D\r\ØóÛºB\İñVTj±\Û+\Ğ\Z\ïF¨©ñ\Í\è\Û4ñ{Éµp¥\Ür½~‹ñ}\ÄZ²ƒµ¸ûü¬\ÅÕ®\"_-:Ş²²2\è\Â\çó¹Úœ{\"Ù®BM\è·w¤U°l—aš§Œµ\äÖ¢¹X‹\\df\Îüm®j[­ÿ\ã>\ÈĞŠ\n Øˆ®d\Éd\Zƒ˜X\ì%pp?€ı\Ç1‚úz­\Å\\\Â\ê\î\r·£W\Í\Ü\\c8ÑŸO{¸=s¶°km0«O- C+*€Á~ûŒe;úŠwaù\Ò†tşD/Ÿ¢\ê:g›[¬\ß\Z©·o\0‰`jPƒª ú»9Ú¯«BPııÑ‹ƒGVª¿#M–\×Ş£OF1¾XKv°w_kqµ«\ÈW‹÷üùó\ĞE*•rµ9\0FGG]\í*\Ôf.\\põ©\0W»Ö¢Ö¢R¬E\îAÖ»±z\â\Ş\ËÁN\ëW7CwnÀDŠ5\ê\"´Y\äp\É]U8 \æ\ì\ÅP±B,i›ºw^ŠFÈº\ËZ\ì3™Tzr½Æ‹ñ}\ÄZ²ƒµ¸ûÎ³W»Š|µ\èğL¢\×û\ìP»Ş¾?\ÑZøM\å²p\âu_d¤~\â,_{Áµ\Û÷<†Ğ½­°sb7£!¬[™}&S±ê«·§\êRü\Ç4g-Cš³›n\ê,m¨±Á\Äbˆa(D]£õwÎ´?9„DĞºü»¾Ä°ZHÑ¥\â\"“h.7\ä?+n°\îO\Üe_.?Ù™\ã~F7k1Ù…d2‰ú\á>ûò³=oÇˆ=¦5n\İ\Ñ1®u	ºfs\É\äv\àhXº\Ü}I?\Ü`\İ\'™L\"™´\îl[sO\Ü\Ã	 i\ê`]\Ş6}ñ\'†zûò<Ğ·µ½\èEsµu¯§\Õ>‚\Î\êfô\îoFu\æ\ï0µ\ß\å\çY´h‘ö\Ù\åUUU\Z\Z’\Í,À\è\è(R©”\ì\ìût\Ô3.\å¥>E]\×\ÏušUa-z¬E¯k™Ÿ\Ï.·¾°s¼º\íö}¨­\ÏV~;&ºhmmm\0€;vÈ®¢|±–l¬…µ8]j-gÎœq?»<\ëODDE£\Í­öf\ì\ÛW “L\"¢9ƒ‹L\"*^\êv€ıÍ¨6}±‰ˆˆŠ™DDDDTp\\dQÁyjkkµ_üY¸p!Î=+›3ü~?\Ò\é4\ÆÇµ?\Ç¯×‹±±1c\Ï\ç\Ëy“©\ÂZôX‹^)\Ör÷\İwã®»\îšg_ü¡b\×\ÖÖ†«¯¾\Z{ö\ì‘]Eù>b-\ÙXK\îyX‹[¾Z]_ü\á·\Ëm¬…µ(\ÅX\Ëüüv9;~»Üµ\è±½Rª…\ß.\'\"\"\"¢ÁE&™DDDDTp\\dQÁq‘IDDDD\ÇE&œ§²²R»…Ñ’%Kp\ê\Ô)\Ù<+X‹k\Ñ+\ÅZö\ìÙƒ{î¹‡[QQikkƒ\ß\ï\Ç}÷\İ\'»\nªP\ï£B`-z¬Eo>\Õ2<<\ì\Ú\Â\Èµ‹\Ì\Ê\ÊJ\ËæŒ²²2¤\Ói\í^IJYYR©”v\ÓN\Ø{.ù|>ŒÊ®,¬Eµ\è•b-<ğ\0\î½÷^.2©¨´µµÁ\ëõ¢££CvEø>b-n¬Eµ\è™jI$®E¦7•JA\ã\ã\ã®6g\0À\ØØ˜«]…*2N»údl—ÁZôÁZôQŠµ\è\Ş\ĞD\Å \×\ë·\ßG¬%;X‹»/\ÅZ\\\í*òÕ¢\Ã{2‰ˆˆˆ¨\à¸\È$*D“I$5\r\Ë\Üh\êF\Ü9\Ï\áˆÌ˜\á(\â=¡‰ÿš„£HÆ»‘\'+º\ã\Óô;%\"*!\\d•Œv4tÄ€DZ\ì?7zA\ÔÔø®FŒt\ØóZĞ·´ušDoÂ–½@¸*·£»I\æ\Ñl\à\"“h.G\'µ°õ\Ä]gC=q$w£;>\Ñ>‘Eî³•\êLa¤¥ÁÁN\Ç\âµ\Í[û¨]\î&1_\æÌ¡u\Ğj[‹Áptb.\ç\Âp\ÉxÑ¸ªWó³\0B=ë‡›\ÑkW\Ñ\Ş5€ºk´\È\á\\g«Ğª\Ær\ÕG]¿#ˆ\ß]\Ş3¥DD”ÁE&Q©GÑµrÀ>«iq\Ì,¾jë€­6õ!QÛŠ\íØ‚@ 1Ô >„®;-³£Á•\ëBË—‰\áXö<ûb D\Õu´®ú6\Ùó¡­a Ô³°Ï®vŒ q[\Ë\ÖÁ\nm\r °¦‘\Ã]h<\Ùi\×1‚\Æ]QDÂº•ÀĞ“Ÿ\Ù#µõˆ\0h_“\ãn°xx¢¶\í=!k1½¹b¢æ¥­™Kğ]kG\Ğ \è\Ä\ÈÚ®W\"\"’¼^¯ºğx<®6g\00\æˆI´‘¯_…i5)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûdl—ašGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9¹dÎ®m®j[\İgåœ¹+*€`#º’I$“]h5õö™º\Ä\0\î·gH` ¯@C	«»7Ü^u6ssMÖ¸¹µ£0ˆ\Æ]I$\ã\ëp°\ÚZ\ì\ÕT‘8z\Ğ:\ën@ z\â¤\Ş\ï`/jcı\íVs¸1T`yS\rª‚*G‰a(Q\å\ÆK\æ1ô‡ &¬¬®«BPı.\í¡À`?¬™\Û\Ñ?T¬¨\ã\Ío¹^¿N²O\æ\Èv¹\æpc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“9²]†i5)\ÇIö\É~\Å[^^]x½^W›3\0À\ï÷»\ÚelsFYYYŞœrÖ’3X‹>J±ù\î\İX=q\ï\å }†Ï´hS9*\Ö\Ø¶<\"‡“H\îª\Â5\0 \ÇO\ÂZœ95­C]0¡\'­³ˆ\êLa/3—4Ÿ\Ï\çz\Í:_»²\Í3ı>’m\Î`-ú`-ú`-\î\Ğñ^¸pºsµ9öL²]\æ\È6g¨Ce»Ö¢Ö¢R¬E\íOv1zŸ\ì{%Õ½SYô%u¢@¤~bQ\Ù\Şe]^Ÿ¸tB÷¶F y\Ñdô¢¹:€\ÎA+#6œ°/·;\î\Å|r	\Øg›Ö¡.˜™\ÂÁZ\ÔfÎ¾†\ëQƒß¯;k©;»)Y·\0!¬[´.û?9„D°\ë\ìß‘j·~w\Ö\åw ‚úZ`\ä\Ù1\Şü–N§]¯Y\çkW¶9c¦\ßG²\Í¬E¬E¬\Å:Ş±±1\èb||\Ü\Õ\æ\ØD\Ëvg¿\"ûdl—ašGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jSN^\á†üg%\Ã\rh9\ëòuÒº·±zc\ÎsY\Úûc®\íB2™DıpÁ*\Ô\0ÀşfT:\Í\ê\Ë8ö=“kÚ­o¹w\0­ö—eZ—öa\Ë\Æ^ôn¬F\çIû²ı\æ\Z\Ä:\Z\Ğn\ß\ÇÙ¸+‰\ä¶*ŒØ—\é¥ö5ö·×“I$7W oS\ÚÑ‹ƒGºFÇ‚9\\\Zûòv\î/şÄ€z»fXµa3ª;FÜ¿£pZU\Ø—VTj\Ñ\ß\ç9\åzı:\É>™#\Ûe\äš\Ã9)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûdl—ašGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'ûÏ¢E‹´©ªª\Â\ĞĞl\ÎX°`FGGs\ïònŸ–½`¯uü~?\Ê\Ê\ÊpşüyÙ•…µ\è±½R¬e÷\î\İØ±c+\éA4¾ö­‘\Ãq,\ïªF³ñL&J[[\0`Ç²«(\ßG¬%ka-N—ZË™3gÜ•\ÌúÑœÒÎ£u\Ö7\Ä\ÃQ´\â\0˜DDE‚‹L\"š\Óz7Vg.m\ç½u€ˆˆf™DDDDTp\\dQÁù®¸âŠ°W³©\æ•W^‰s\çÎ¹\ÚUø|> \ÏÆ^{o?\Ù&#_k\Ñk\ÑG)\Öró\Í7\ãÈ‘#Q±X½z5¼^/~ø\Ãº^³*\ç=2™œB½ò\Í3™Ö¢Ö¢ùTË¹s\çp\åUWÁ\ÉSYY©ıvù’%Kp\ê\Ô)\Ù<+X‹k\Ñ+\ÅZö\ìÙƒ{î¹‡\ß.§¢\Ò\Ö\Ö¿ßû\î»OvT¡\ŞG…ÀZôX‹\Ş|ªexx\Øõ\írnadc-¬E)\ÆZ¸…#na\ä\ÆZôX‹^)\Õ\Â-ŒˆˆˆˆhFp‘IDDDD\ÇE&™DDDDTp\\dQÁq‘IDDDD\ÇE&œ§¶¶V»O\æÂ…qö\ìYÙœ\á÷û‘N§1>®ıñÌñccc\ÆŸÏ—sO&…µ\è±½R¬\å\î»\ï\Æ]w\İ\Å}2©¨´µµ\áê«¯Æ={dWQ¾XK6Ö’{\Öâ–¯–ÁÁA\×>™ÜŒ\İ\ÆZX‹RŒµp3v*FÜŒİµ\è±½Rª…›±ÑŒ\à\"“ˆˆˆˆ\n‹L\"\"\"\"*8.2‰ˆˆˆ¨\à¸\È$\"\"\"¢‚\ã\"“ˆˆˆˆ\n\ÎSYY©\İ\ÂhÉ’%8u\ê”l¬Eµ\è•b-{ö\ìÁ=÷\Ü\Ã-Œ¨¨´µµÁ\ï÷\ã¾û\î“]U¨÷Q!°=Ö¢7Ÿjvma\ä	ƒ\ÚEfee%†‡‡esFYY\Ò\é´v¯$¥¬¬©TJ»i\'\ì=—|>FGGeWÖ¢\ÇZôJ±–x\0G‘]D³\îò\Ë/Ggg\'R©”k#\çb{±7Ö¢\ÇZôLµ$	÷\"“›±[XkQf²–k®¹W]u®¹\æ\Z¼\èE/Â‹^ô\",^¼8ë¿¯y\Íkp\àÀüú×¿–?\Øõz½Şœ\åê«¯\Æó\Ï?/›3ü~?\Æ\Æ\Ærş\ÕS%\äBÂ‰µÌ¿Zşü\Ïÿox\Ãğ»\ßı~¿\ã\ã\ãH\ÙÎ±±±\Ì{ME:\ÎüW\åœ<yû\Ø\Ç\äù\ŞG\Åôf-z¬E¯”j\Ñm\Æ\ÎE¦µ°¥ĞµTWW»\ê¿\å\å\åøõ¯‰Ó§Ogı\ï\åË—\ã¶\Ûn\ÃÚµkRK1ı^X‹\Û\\¬åª«®\ÂC=„mÛ¶\á?ø|>|>.»\ì2¼\à/@:†\×>\Ó\â÷û³ş[^^w½\ë]¨¬¬\Ä?øA9E\Ædk)¦\ßk\É\ÆZôJ©\İ\"“_ü!šFW_}5>û\Ù\Ïâµ¯}-şy9r<ğ\0>ö±¡±±oy\Ë[pó\Í7\ã}\ï{>ö±á®»\îÂ={\Ğ\××‡#G\à\æ›oöûİˆ.E2™\Äg>ó|\âŸÀ•W^‰t:?ı\éOø\Ãş€\ßÿş÷ø\Ío~ƒ_ÿú\×Ás\Ï=‡\ãÇ\ã™gÁSO=…_şò—x\ë[ßŠ\ÏşórX\"*\\dM£\çŸw\Şy\'®¾új|\å+_A__üq<ó\Ì3ø\İ\ï~\'Ó³¼\ï}\ï\ÃÉ“\'ñ\È#\È.¢¢Fñ\İ\ï~Ÿø\Ä\'d—\ÑÆñ½\ï}O=õ”\ì\"¢ÀE&\Ñ4û\çşgœ?6l]9UVV¢µµ•g1iÎ¸÷\Ş{ñ\â¿ó7#»´®¹\æ\ZlÜ¸{÷\î•]DT\"¸\È$š;w\îD[[*++e—Vkk+\î¿ÿ~ü\Ïÿü\ì\"*Zÿøÿˆ~ô£¸\îº\ëd—\Ëm·İ†¯ı\ë8q\â„\ì\"¢\áõ\Ú\ß4”\áñx\\mÎ€ıMF\Ù\î\ìwL¢|ı*Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“9²]†i5)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûdl—¡\æy\æ™gpÿı÷\ãş\á\\\ã\ÈZ\ŞúÖ·â•¯|%\î¿ÿ~G%¹\ç\Ê×¯B\Î#šZd¾¹òõ«0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô82\ç™gÁg?ûY|ò“ŸtTâ«²²7nDww·¶_†œG†®ÙŸ«™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“9²]†i5)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûd¿’s3öŠŠ\nŒŒŒ\È\æYÁZôX‹^1\×ò\àƒ\âk_û\Z¾ù\Íof\å9}õ«_Å—¾ô%|ÿûß—]—D\Ö2›X‹^©\Ôr\Çw\àÜ¹s¸\ç{d\0`Ë–-¸ùæ›±c\Ç\ìİ»WûMU§K©¥\ĞX‹kÑ›Oµh7c_¼x±v‘¹l\Ù2\ãeŒòòr¤\ì½\ÎrQ_u\Ï\Å\ëõ¢¬¬Ì˜Ö’k\Ñ+\ÖZjjjğ\îw¿ozÓ›ğ¶·½\r\çÏŸw\ÕòÁ~/{\ÙË²\ÎMG-:²Ö¢\ÇZ²]~ù\åØ·ov\ïŞC‡eõ½\ìe/Ãƒ>ˆ\Ö\ÖV455a\åÊ•Ø³g¾öµ¯e\å9]J-J1ü^Ö¢\ÇZô\æJ-§OŸv-2½cöÆ¾2\Æ\Ç\Ç]m\Î\0`\Ìq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“9²]\Æøø8/^Œ›nº	\ïy\Ï{ğ\Ë_ş?ş8>ü\ág\ÆQµ,[¶---ø\Â¾\àš\Ç4W¾~¦¿³\ZÇ”\ã$ûdl—ašGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qr\åü\áÀg?ûYü¿ÿ÷ÿPQQ‘Õ·q\ãF\ìÙ³ÿı\ßÿ-[¶\à\ãÿ8^÷º\×\á\ßøn¾ùf\×Xc—X‹\ê\Ï÷÷\Î×¯\Â4\ZÇ”\ã$ûdl—ašGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'ûıEt\"*ˆ×¾öµØ°ajkkñ\È#`\ïŞ½ø\ä\'?‰††¬Zµ*+÷\Ãş0¾ğ…/\à¹\ç\Ëj\'š‹ğ\ĞCemkT]]7¾ñø\ÊW¾’iû\Ù\Ï~†~ô£Ø¾};Ö¬Yƒıû÷\ã¯ÿú¯3ıD4wq‘I4\r–/_÷¼\ç=¸ù\æ›qúôi\ìİ»ÿş\ïÿ³g\Ï\âüùóØ¹s\'şş\ïÿ>“ÿ¶·½\rË–-\Ã<5\Ñ\\¶g\Ïx<|\à\0\ìo”\å+_Á¨\æ\ËGEkk+:::ğ®w½===x\ë[\ß*Óˆh\á\"“¨€\Ê\Ë\Ë\Ñ\ĞĞ€[o½Ë–-C__ö\îİ‹cÇe\å}ó›\ß\Äğğ0\Ş÷¾÷ö–EY9D¥à³Ÿı,n½õVlØ°¯y\Íkğ\àƒÊ”,ııı¸ıö\Ûñ\àƒ\âö\ÛoÇ—¾ô%\\ıõ2ˆ\æ\0.2‰\n¤ºº\Z6lÀM7İ„_ü\âØ»w/=šó^•;w\âı\ï?\î¸\ãü\ä\'?A¿L!šóN<‰ü\Ç\Ä\'>ñ‰)m¼ş\İ\ï~\ï}\ï{qğ\àA|\àÀÎ;¹\Ø$šc¸\È$ºD\×\\s\rÖ®]‹\r6\à/xö\îİ‹`xxX¦fy\î¹\çp\àÀ\Üt\ÓM<‹I%\í\Û\ßş6\Şò–·¿A\ËÁƒ±i\Ó&ô÷÷#‰à®»\îÂ«_ıj™FDE\Èµ[UVV\Zÿ‘,++C:\Îy–\Æ\ãñÀ\ï÷#•Ja|\\;¼^/|>Ÿöş\'Ö¢\ÇZôf²–?ÿó?\Ç\ë_ÿzTTT\à±\Ç\Ãc=†\ßü\æ7™¼™¬¥˜~/¬%k)\\-\ï}\ï{±q\ãF<ö\Øc\è\é\éÁ³\Ï>;kµ\è°=Ö¢WJµ$	\×F97c_²d	N:%›gk\Ñc-z3Q\ËÒ¥K±zõj¬^½\ZO>ù$9‚Ÿÿü\ç2mFj™,Ö¢\ÇZôŠ¹¿ßŸ¹\Ïó;\ßùö\îİ‹“\'Ofı\Ìt‘µ\Ì&Ö¢\ÇZô¦»–a\İf\ì‹-\Ò.2«ªª044$›3,X€\Ñ\ÑQ¤R)\Ù\Ø+kµig®U±\ß\ïGYYÎŸ?/»²°=Ö¢7µx½^\Üp\Ã\rx\ãßˆòòr|ÿû\ßÇ£>šss\Ú\é¬E)†ß‹\ÂZX‹2µ,\\¸·\İv\Şÿş÷\ãk_û\Zx\à$“I™6#µ(\Åğ{QX‹kÑ»\ÔZÎœ9\ãZdòL¢Iz\Å+^\r6\à–[nÁ‰\'ğµ¯}\r\Ñh4\ç“ˆ¦\×Ù³gñ…/|\ïx\Ç;\àõzñ­o}­­­x\á_(S‰hp‘I”\ÇÂ…ñö·¿6lÀ\âÅ‹±w\ï^<ô\ĞC\ÆO„D4sNŸ>ú§\Â;\ßùN\\s\Í5øÖ·¾…\Ûo¿>ŸO¦\Ñ\â\"“J\Î\ÈÈˆl\Êr\á\Â¤\r\Ïf\Ë\\X°`,X€Ÿı\ìg¸÷\Ş{±s\çN9r\étšg0‰ŠD\Ê~\Şòs\Ï=‡;\ï¼o{\Û\Ûğ­o}+V¬À¢E‹²\ŞÓ¹Lö=\ïøBD¸È¤’ó§?ıI6e³Ÿ\áj¢ş1:ş<~ı\ë_cxx\Ï?ÿ|\æ^•qûù®DTœ\ï\é.\à\äÉ“xú\é§q\æ\ÌÀñ\Îe²\ï\é|\Ç\"šÀE&\Ía!tÇ“H&³#\Z–y¶p7º›d\ã4u#~8\"[‰hÖ½“\Ç¢\"\ÄE&\Íq1t8¢!\Ç?,‘ú:\ÙDD%ƒ\Ç¢b\ÃE&•¦nÄ“QX\ç\"ˆ&\ã\è~(Š\Ö\Ú \ZwE\É:\Z·\Ïh„\Ğ#iwş¼\ÕoQ[3dŸA÷„&\æ&¢\âÁcÑ¬ò\Ô\Ö\ÖjoN[¸p!Î=+›3ü~?\Ò\ét\Î{\Û<¼^¯ñş7\ÇŸÏ—sO&…µ\è\Í÷Z~û\Û7c\ç‘{\Ñtf\Å\Ğh@{S7\â-ÀÀ\Ò:`k5š÷‘\Ãq,\ïª\ÆÁ\Æ8¶cª7ö\ÚÿpÔ£?Ğ‰\åñ.T=lıˆN¢¾?€şz\ë¿\ra \ÔGW\åº–#\Şr\Õk\Ú\0—]v***œEd\Ì\Æ\ï%Ö¢\ÇZô\æR-¿ÿ}\î}ôÿWÇ‚—¼\ä%Eó{)¦ÿX‹^)\Õ288\è\Ú\'“›±\ÛX\Ë\\¬%„\îx+W7À:\Ägõ8ÿ™ø‡\åxK­µ\Î\Ìú6m¶MŒê‰£õ\Ù-ºe{\æ&4ugşA‰#q¨%3‡4;¿=Ö¢\ÇZô\æR-ee·\àË±Å±\àu-‡Š\æ÷RLÿ±½Rª…›±\Óü¢«ò\0Tnw\İ\àN q¨\Åq\ï–ı‡K/Ÿ¢\ê:û\×UA(i_£~¶#k[\í\ËiDTtføX°\ÅñSDó™4\ÇÕ U|£4~t\É\Í@\çšv´¯9€ª]\ê^« \ZwÅ±®oVv9~F\İs\åÖ¾¦\Øl\ç\İR\Ô}^\êg[Qq¨S{ö„ˆfRq¶\Ë$š\Çx¹\Ü\ÆZJ§–bRL¿Ö¢\ÇZô\æR-eee•Í³¢˜~/¬Eµ\è]j-¼\\NDDDD3‚‹L\"\"\"\"*8.2©\ä¼ù\ÍoÆ­·ŞŠ;\î¸7\Şx#/^œ\Õù\å—\Ã\ï÷gµ9y½^\\~ù\åğzs¿=ü~?.¿ür\ÙLD³À\ï÷\Ï\Ø{zÕªUøÿş¿ÿ=ô\Şù\Îw\Ên\"rğTVVj\ï\É\\²d	N:%›gk\Ñc-\Ù^ô¢aõ\ê\Õx\ë[ßŠŸı\ìg8r\ä~úÓŸÊ´U¿…µ\è±=Ö¢§j¹\îº\ëpë­·\â\Úk¯\ÅŞ½{ño|C¦N»bü½Ö¢7İµ»\î\ÉôƒA\í\"³²²\Ã\ÃÃ²9£¬¬\étZ{ó§RVV†T*¥İ´ö§KŸÏ—÷†mÖ¢\ÇZ&¬Zµ\n¯ı\ëq\å•Wâ©§B___\ÎMg§»§\Ùş½8±=Ö¢\ÇZôd-\×_=6nÜˆ¿ø\Å\è\é\éÁw¿û\İY«Eš\Íß‹\ÄZôJ©–D\"\á^dò\Û\å\Ö27kY¾|9n¸\á¼\á\roÀÑ£Gñ_ÿõ_øÓŸş4+µ\è\Ì\Ö\ïE‡µ\è±=Ö¢—«–7¾ñ¸\í¶\Ûğ‚¼\0_ù\ÊWğ\ïÿş\ï2˜¡Z”bø½(¬E¯”j\á·Ë©d”——£¡¡·\Şz+–-[†‡~>ø ;&S‰ˆ¦\İ~ğ|\àÀŞ½{\Ñ\ÜÜŒû\ï¿7\ÜpƒL#šW¸È¤9§ºº\Z6lÀM7İ„_ü\âØ»w/úûûµŸ¬ˆˆfR4\ZEss3şõ_ÿÿ\çÿüttt\àúë¯—iDó™4g\\s\Í5¸ñ\Æ±a\Ã¼\à/ÀŞ½{q\àÀ\ã=&DD³¡¯¯¡P\ßÿş÷±m\Û6|şóŸÇ«_ıj™FTÒ¸È¤9\áú\ë¯\Ç{\Şó¬^½\Z>ú(ö\îİ‹\'xB¦•\Ş\Ş^466\â\Ç?ş1v\ìØH$‚+V\È4¢’\ÄE&µ\Ê\ÊJ¬_¿6lÀùó\çñ\ĞC\áĞ¡Cø\Ío~#S‰ˆŠ\ÖŞ½{q\ã7\âøñ\ãøÒ—¾„O~ò“¨¬¬”iD%\Å\ëõz¡\Ç\ãjs\0c˜DùúU˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\×\ë…\ß\ïÇ›\Şô&\Üz\ë­xÕ«^…¾¾>|õ«_\Å\Ïşs\×\Ï\Ê0Í£\æ2\å\ÈZt‘¯_…i5)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûdl—ašGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jœ\\9cccØ½{7\Şñwà·¿ı-şõ_ÿÿ÷ÿş_¼\èE/r1İµ¨ş|s\å\ëWašGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²Oö+97c¯¨¨À\ÈÈˆl¬E¯Tkyù\Ë_Õ«W\ãú\ë¯Ç‘#Gp\ä\È\ã¶R!k¹T¬Eµ\è±½R­%`Ã†\r…BØ»w/ö\îİ‹s\ç\ÎÉ´œ\nYË¥b-zó©–a\İf\ì‹/\Ö.2—-[†\'N\È\æŒòòr¤R)¤\ÓiÙ•¡öS\Ê\Å\ëõ¢¬¬Ì˜Ö’S©\Õpıõ\×\ãõ¯=~÷»\ß\á\ÑG\Å\ã?\éŸ\ÉZŠ\é÷\ÂZôX‹k\Ñ+\æZ*++q\Ûm·\á\ío;º»»ñ\àƒ\Â\ëõ\ÎJ-\Òlş^$Ö¢W,µœ>}Úµ\ÈôA\ã\ã\ã®6g\00\æ8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jSNMM\r\Şı\îwcÍš5ø\ïÿşo<ø\àƒx\ì±\Ç\\c\ÌD-N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“9²]†i5)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûdl—ašGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9Nª\íÄ‰Ø¾};\Ş÷¾÷\á¥/}):„w¿ûİ®Ÿ•ašg\ì\"k‘‘¯_…i5)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûdl—ašGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>Ù¯\è/¢Í`0ˆ›o¾\ï}\ï{\0_ı\êWño|‰DB¦•´cÇ\á;\îÀG?úQ\Ô\Ô\Ô\à\àÁƒx×»\Ş%Óˆ\æ.2iÖ¬^½\Z6l@mm->Œ‡z±XL¦\Í+?û\Ù\Ïğ\ÉO~Û¶m\Ã[\Şò8p\0k×®•iDE‹LšqË—/\Ç{\ŞólØ°\Éd{÷\îÅ¿ÿû¿\ã\ìÙ³2•ˆh\Şú\áˆÍ›7cÇ¸ù\æ›ñ\àƒbÍš52¨hq‘I3¦œ\Ï\'\"š²ü\àø\à?ˆ\î\în\Üv\Ûm¸ÿşûñ\Æ7¾Q¦.2iF¼\êU¯\Â{\ßû^>oœˆ\è\"=ò\È#¸õ\Ö[ño|mmmØ¶mş\×ÿú_2¨hx‚Á v£\Ê\ÊJ\ã3¡\Ë\ÊÊN§s.<ü~?R©\ÆÇµSÀ\ëõ\Â\çóattTvea-zs¡–k®¹¯ı\ëq\Ã\r7\àÔ©Sxô\ÑGñ£ıH¦\ÍH-J1ü^Ö¢\ÇZôX‹\Ş|­\åø\0\Zñ‹_ü===ø\Ù\Ï~–\Õ?“µ\Óï…µ\èMw-‰DÂµ…Q\Î\ÍØ—,Y‚S§N\É\æYÁZôŠ½–×¾öµX½z5^ü\âg6Uşù\ç³r¦ƒ®–\Ù\ÂZôX‹k\Ñc-zª–w¿û\İØ°a°w\ï^<û\ì³2u\Ú\ã\ï¥Ì§Z†u›±/Z´H»È¬ªª2>eeÁ‚E*•’]€½²V›v\æZûı~”••\áüùó²+\ËL\ÖòÓŸşTveñx<\Úül(öZü~?|>Ry6w-4]-³¥µ¼\ç=\ï\ÉÚœ^)\Æ÷k\É\ÆZÌµğ¸{qd-\å\å\åğz½yÿ¿²–\ÙT\ÈZxÜ¯–3g\Îp‘™¯–Ÿşô§xù\Ë_.»\é\"\\v\Ùeğx<9Ÿ@“·o\ß>\ìØ±ƒ;k)­ZxÜ¥b\Ä\ãn¶|µ\è™ü\âM›?ı\éO\\`\ÍS\\dQÁq‘IDDDD\ÇE\æ|\"™L\"\Ş\ÊjõÄ‘LF\Éj\Í-\ÔwaA4™DRE¼Sùi\"¢\Òa\åq°©ñdÑ°³\Ñ$‚\è\Û@\İq\Çq8Gw“\Õ9<•y‰¦‹\Ìy ´¢\0¬¬™hl\ê\Æöµ#ˆ\Z\ÂdŸ^S\ÄÈ³½²Y¯©ñd+\Ğ@ `E\Ë\Ñ:t\É,\Ñ|Ğ´\0¬\ÂÄ‘8„\îm\ì\ÃĞ“\Îdƒ¦\å¨HLö¸A4Ù…º£-™\ãp`\Ó\0\êvEAË—&&?/\ÑE\à\"s¨©\"6˜}HŠ´\Ôa c•\Ç\Ñk¢UŸt\'\ÎV:\ÎD\îvœg(\'>O°œ48>%÷nÜ‚>\Ôa]\Ó\Ä\ÙUklõ™\Ü9®ú¤Bw\Ü1G8j\å7u#\ïF÷a;\×>ı³DDE\âº*cÙ‹\Ãp+\êvbhi\ïWW—\äq\Ñ\ÙGwc‚\'M\Ç\í	¡õ¨8Ô‚ê“û›Qh@;jPÁñıp]uRg7#‡“ˆöX\Ç\ÖxO(\ï|D’§¶¶V»…\ÑÂ…qö\ìYÙœ\á÷û‘N§s\îE\åñx\àõz166f\ÌQû(š\Ìd-<òV¬X!»\ç°º\ãÛ‡Pw°¥º½Mİˆo­\ÃzlÁlGW\åÖ´\Û›õÚ´\ØÖ…ª‡­…b¨\'®•h©>ˆuñ‰v„£H\Ş2„–\êfL\Æ\"ˆÆ—£3«\Í\î9œD}†ni\Åñ\ê´gµeÏ·[Pİ·ñmvİ™\Ü\0\ZErs\rb4„U\Í\Õh¶\ÔŸ\Òğ\ĞCaß¾}”]Eù>b-\ÙXK\îœ\Ò<\îºYÇ´X¹\ØZ\æı\â\Øüpº2\Ç\Òº\Õq\ÎclQû\nQ\ç\n\çq.ûh\Ïh¿\Õ\Ù\æ`ÿ;°¥º5\ê¸\Z¶\Û[£zM\İñ.4¢-\Õ\Í@\ÖqU7_\é\áq7[¾Z][qŸL[\É\î×¦$[\í»ªp Ğ‰\åñ\íÀ\Ö-À¶\íÀ\Ö¨\ÚUş€µ\àƒZÈ\ÅP\ã\íŸX¨…£H\Ö÷#\Ğ_oı7³€‹ š\Ìşy\çÁ+{‘9q\Ğ;Ş’Dkm\ê\ç\Ôøra˜\Õ>ñó\íE\è\ÆŞ‰©ú´sş¹‹ûµec-¥UK\Éw]Ô±k\â\Ã{\ç\në¸µÛ±1°r]Ö‚\Ğ:®\Év5N\ã¶Z(Z-\îc³Cöq\ÓZ¼f.\ãv\"°Ÿwå¯ôğ¸›-_-\Ü\'s>ºÎ¾´²ÿ8F\0 i\êN@ó~ûR	\äı=\Ö}:ioÃ\ÖÖŸ\Õ3t÷©¹¤p+\Z1€ƒûö56\ra½}Y\È5®-R_ƒX¿}XkZ‡:\à\àşÖ­ú¬%¤\ë^Qõwh!\"šE\ê\Òt/Ÿ€Ö­Á½öñëK\×öOh\Û\Í\Ç\í\É\Ü_©¾À™9n†£H&\ëÑ¯\î?”°\Å\áz\Ôö[‹J\×q~òó\Ñü\ÆEf‰›X¼\Å0”\0–7Va «}â ±ÿ8F‚ö}’\0B=\Û\Ñxò\0şwÿ‚+\×Y_\Òi\ê\Æöµ\Ö©÷YG»º÷òayÆ°ı\'\Ñå¸§Mİˆo®@\ßV\ë\ÒL4¬\î\r\êDl\ér\àÙ‘‰/&5u#”7¦[sY‹G\ç½D@l8šz\Ç}›+\Ğ×¥û\ìND4‹´\ØpX±UG;Ñ9\Æ\Å0”¨A½:+¢ui:\Ã\Ù\í‘Ã­¨1·³/]·£°­\Î\ãp8Š®µ#8°™ckhE‡:\í3”´\Ú\Çú¬ş“šÈ‹Ì’–}\Æ¨A:­ûë€£Ñ‹v4tŒ q—u3w\×\Ê´¬iÂ\èC#º’I$·Ua$a/ö\Â\r\è<i·\Û\ßZ\Ô].i_@\'Z\'nb\ßU…\ë’O{W*6«\È[‡›\Ñ\îD\ßR;W65 ½8~2h×¶u€uVS|ª\îİ¸e\âg“­@Gi\ß\'DDs\Ë\Äñ\ÖR³\è\Ü\Ø\ë¸:Ó‹æ­\ã\âf\Ø÷´÷¢ù\áj\ìözÄ€“\Çs·\×qø–!´ˆ/ıôn<€‘µ]vN=`\ß~˜}…hróI¼\'\Ó6\î\r¢¹ˆ÷ec-¥U»TŒx\ÜÍ–¯Ş“IDDDD3‚‹L\"\"\"\"*8Oee¥örù’%Kp\ê\Ô)\Ù<+f²^¶¡b´o\ß>|ñ‹_\ÄÑ£Ge×¤\Í\äû(Ö¢7_k\áq—Š»S3<<\ì¾\\>::\n]¤\ÓiW›3\0L*\'•J¹\ÚU¤\Ói\0pµË˜\Ì<“É™L-D\Å*\×\ë·\ßG²]\Æd\æ™Lkq\Ç\\¬…¨X\åzı\ãûH¶Ë˜\Ì<“\É\ÉU‹7•JA\ã\ã\ã®6g\0À\ØØ˜«]…º)4N»údl—1“µ«\\¯\ßb|\Év¬Eóµ¢b•\ëõ[Œ\ï#\Ù.cºk\Ñ\á=™DDDDTp\\dQÁqŸL›\ß\ïÇ­·ŞŠ\Ï|\æ3\è\ì\ì”\İD³¦ªª\n¯|\å+ñ±}Œûµ\ÙXK\é\Ôò²—½ÿùŸÿ\É\ã.•ªª*,^¼Ÿû\Ü\çxÜµ\å«E·O&™6¿ßÿı¿ÿ7¾ô¥/\á/ÿò/e7Ñ¬©¨¨À\Ç?şq´··ó`gc-¥SË’%Kğ_ÿõ_<\îRQ©¨¨@kk+>ÿù\Ïó¸k\ËW™“¨…[iP1\â“\'²±–Òª…\Ç]*F<\îf\ËW‹n‘\éõz½Ğ…\Ç\ãqµ9€1GL¢|ı*Ló¨qL9N²O—CTŒ\äkV¾ve»\Ó{Dc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'Ù§\Ë!*Fò5+_»²]†\é=¢\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸ\ìWrn\Æ^QQ‘‘\Ù<+f²~¢¦bTˆMgò}”kÑ›¯µğ¸KÅˆ\Çİ©\Ñm\Æ\îY¼x±v‘¹l\Ù2œ8qB6g”——#•Je6\ÕQ§Usñz½(++3\æ`†k\áÁŠÑ¾}û\Ğ\ÑÑ¡½lSŒ\ï#SXKNóµw©ñ¸\ëfª\åô\éÓ®E¦wllºwµ9€1\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ût9D\ÅH¾f\åkW¶\Ë0½G\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“9²]†i5)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûdl—ašGc\Êq’}º¢b$_³òµ+\Ûe˜\Ş#jS“\ì“9²]†i5)\ÇIö\É~Eˆˆˆˆ\èp‘YMİˆ\'“H&O\à\Ùd\İM2A	¡;D4,\Û#ˆº~N×–-\ÔG2™tG¼!™LDTJx\Ü%*z\\d@¨±ÁÁNË°\"P\æı2cŠšºO¶¢F¶½«´ /\Ä:ÖŸ«›\Ñ+“‰ˆJ»DÅ‹\ÌIŠ\Ö}¢km¨mE¼ç¡¬OÁ‘\ÃŸr\ã=ò3®õ\é:™L\"y¸\Ş\ÑAt°eS\Îì¸f½\Èa\Ç|Mİˆ\'£ˆ¨O\è=Q»¦‰:³>™dED4[x\Ü%šÛ¸È¼T\á´J\0ƒ¨\ŞøT¦9\ÔG+:\íO¼Y»=\ëL¨g;\ZÑ‡–@\0~8>=·£Aó‰¸wc5ª7\ÊV½öş‚•ÖˆÖ§ı~´\0‚h¬\ìG @\Ë! q[7B\á(ºVXuZĞ·´UP\'\"*<\î\Í	^¿\ß]x<W›3`m^¶«ğù|\0\0Ÿ\Ï\ç\êS¡6\ï”\í2f²–lŸz[kšÍ¹>»\ÕTZŸ²­Oª­¨Auuvo\ëV‘8z\Ğ:¨…û\ËşñK\îG¬¶»X¿u¨\è\ë²şwo\ß\0Á*„VT\0ÁFt%“H&»\Ğj\êù©º\åzı\ãûH¶\Ë`-ú˜¯µd\ãq—ŠG®\×o1¾d»Œ\é®E\Ç[VV]ø|>W›3`O$\ÛU¨	ıö\ãt¡\n–\í2Ló”¸–l½h®¶\î·\éœ¸÷f²Ÿl‡Z\ìO\Ô\ê\çd\Ê4iGÿ`\r\ê\Ã\Ô\×\ÆĞŸ\ïò ú\äo\Ç\Zup¤b’\ëõ[Œ\ï#\Ù.\Ã4Ok\É¥ZK6w©x\äzı\ãûH¶\Ë0\ÍSV€Zt¼\çÏŸ‡.R©”«\Í\00::\êjW¡6\ë¼pá‚«O\Å\è\è(\0¸\Úe\Ìd-…N ¸¶\Ög\Ó¢I\ç½E½8x4\à\ÊuÖ·\Ãõyo6Ÿªö®>\à–õ¨\É\\²€ \ê\Z­³¡\Æ:C\è}v¨]o_R²\Î L\æŒÍ¼\\¯\ßb|\Év¬Eóµ–B\áq—\n-\×\ë·\ßG²]\Æt×¢£»VA\Z\íkh\È÷\ÉÔ¡wc5:k\Ğj_¶©8Ô’õó½· ö\å’z\ä½l3•\Ğ\0ûb\ÎK6¶•Û‘L&Ñµ\è\ÛÚŒ\ŞpƒuŸ\Ğ.û²\Í\É\ÎIŸ1 \"šN<\î\ÍmE‹i+YUU…¡¡!Ùœ±`ÁŒ\"•J\É.À¾®¯?”k\'xu\Ê5\×\nX™\ÉZJ\æñfMİˆ\ïªÂ@ƒı‰:‚h²\è˜\ÚA›ŠÃ¾}û°c\Ç\í\ãÍŠñ}\ÄZ²±s-<\îR1\âq7[¾ZÎœ9\ã~¬dÖŸ¨4„£H\îju:.\ÙÑ´\áq—È…‹\ÌRn\Ğ\Ü(ß†\0?MMw‰\\¸\È$\"\"\"¢‚\ã\"³\nú]\ë‘¹ŸX1\Ï\Ğ%¢y‹\Ç]¢¢\ÇEfòº‘\Ã\Ö7\"\0›ú€µ]šƒ£…\Ï\Ğ%¢ùŠ\Ç]¢\âç©­­\Õ~»|\áÂ…8{ö¬l\ÎğûıH§\Ó\×ş8<¼^/\Æ\ÆÆŒ9>Ÿ/\ç7™”™¬\å‘GÁŠ+d7\"‡“¨\ï\×\Ü[\"¹\Ù\Úm-q\è»Yû\Údğ\"‡­\'VX}-¨\ŞtÇ»Põp\0\r\áº\ãÖ“0C¬¶\"ós¬œª‡\è\\\ÇvlÉ±\Í\ÅD^CØšwıp‹•›ù¶c?\ê“\ë1thkk¬§P\Øó…z\â\Ös€ao\ÌM‹\ÎC=„}ûöappPv\åûˆµdc-¹sx\Ü\åq·Xñ¸›-_-ƒƒƒ®o—s#[¾­4r\ì\ì\Ë\']•XD“\ë1´©\ZU[»})f=†6m¶M¼ºV ¥º½\á(’›+2Ÿ\×v¹d\ì\"YßÀšvQ[+j\ìƒY¨Çÿ\á*t\İ2d\Õ!Ç¡¢Á­4²±–Òª…\Ç]w‹»\Ùò\Õ\Â-Œ¦l6Ÿ¡AtW6\å;\ĞiğºD4gñ¸KT*¸\È4š¥g\è6u#¬GÿE\ßg\Äg\è\Ñ\\\Å\ã.Q©\à\"sš\\ô3t›º\ßl\É{©ÆŒ\Ï\Ğ%¢ù†\Ç]¢\â\ÂE\æ$\Í\Ì3tC\è\ŞÖˆ`\æ2Š\Ñ0Ÿ¡KDó»Ds¿øc\Ëwúœ\ãºy\ÏĞ\Ëxz6\ÖRZµğ¸KÅˆ\Ç\İlùj\á\æ>C—ˆhfñ¸K\äâ©¬¬Ô\É\\²d	N:%›g\ÅL\ÖR2Ÿ¨©¤\ìÛ·_ü\âqô\èQ\Ù5i3ù>Ê‡µ\è\Í\×ZxÜ¥b\Ä\ã\î\Ô»\ÏdB\ét\Ú\Õ\æ\0“\ÊI¥R®v\ét\Z\0\\\í2&3\Ïdr&SQ±\Êõú-\Æ÷‘l—1™y&“\ÃZ\Ü1k!*V¹^¿\Åø>’\í2&3\ÏdrrÕ¢\ãM¥R\Ğ\Åøø¸«\Í\0066\æjW¡®×§\ÓiWŸÌ‘\í2f²¢b•\ëõ[Œ\ï#\Ù.ƒµ\èc¾\ÖBT¬r½~‹ñ}$\ÛeLw-:¼\'“ˆˆˆˆ\n‹L\"\"\"\"*8.2‰ˆˆˆ¨\à¸O¦\Í\ï÷#\n\áóŸÿ<n¹\å\ÙM4k–/_¿ıÛ¿\Å\Ç?şq\î\×fc-¥SKUU¾ÿı\ïó¸KEeùò\åX¿~=>÷¹\Ïñ¸k\ËW‹nŸL.2m~¿·\Şz+>ı\éO\ã3ŸùŒ\ì&š5/ù\Ëñº×½û\Ø\Çx°³±–Ò©\åe/{¾ÿı\ïó¸KE\å\å/9^úÒ—â³Ÿı,»¶|µh™‹/\Ö.2—-[†\'N\È\æŒòòr¤R©\ÌW\çuT1¹x½^”••s0Ãµp¿6*Fûö\íCGG‡ö`WŒ\ï#SXKNóµw©ñ¸\ëfª\åô\é\Ó\îEf®\Í\Ø+**022\"›g\ÅL\ÖÂƒ£Bl\n<“\ï£|X‹\Ş|­…\Ç]*F<\îNn3vÉ´ñ53~¢vc-zs±w©ñ¸\ëfªEw&\Ó;66]Œ»ÚœÀ˜\ã$ûdl—ašGc\Êq’}º¢b$_³òµ+\Ûe˜\Ş#jS“\ì“9²]†i5)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûdl—ašGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>]Q1’¯YùÚ•\í2L\ï5)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûd¿\Â-Œˆˆˆˆ¨\à¸\È$\"\"\"¢‚\ã\"sVEM\Æ\Ñ\İ E2ED¦LF8Šd¼¡I´\Å{B4™DRÑ°3ù\âD\ÛŸœ\"\Ó:?‘»…Ÿ(.2gS\ÓrTÈ¶õÄ‘\Ü\\#Z#ˆ\Ş2„-ß†@\0@\0\èC‹ı\ç†l\Ú\×@\Õ6q\Í\Ò>­óñ¸[ğù‰r\á\"s’\"‡s}\â¡;D´§ñ\Ì\'C«-™L\"y\ØşŒ\Ü4\Ño}r¡{[#‚¢\Ñqp¨?l\ç8>\r‡z\â™Oñ»\Õ1^´\ŞN„õ©y;¶ \åP\Â\Ñ„z\Ö7£7«Õ¡©q\Ç\'ú\Èak®PO\É\Ã\İî¿\ãª\í\è<Z‡\Ö0\ìOÏ“<K0\åùŸ\Ìó}Š\'¢¹ˆ\Ç]y\Ü\ãq—\æ¯\ß\ï‡.<«\Í°¿6/\ÛUø|>\0€\Ï\çsõ©ğz­5®l—1“µ\\¬š•À–@\0-‡¨Ù¼\Øjb¬­GDw\Õa`“õÉ±\åPZ× ykH o«:\Õ\0ıˆ­F8Š®µ#\èX\í#k»¬ƒ\é¶F\àP\0ú\áøôn@õFyHa\İJ`\èI\Ñ\ì´ÿ X\Ş\0\Ô\×&0\ĞgS[gı}ˆÕ¶\"\Z¶À­\è´>:1²v{\æ€\Óû\ìj\ê#ö§\ç´;\ç\ÉeJó‡\Ğo:\Ô\'ó‘¬0JU®\×o1¾d»Ö¢ùZ\Ë\Å\âq—\Ç\İ\é–\ëõ[Œ\ï#\Ù.cºk\Ññ–••A>Ÿ\Ï\Õ\æ\Ø\ÉvjB¿ı¸#]¨‚e»\Ó<e®%\Û\Ä\'\ã\ÖZ f³üô8!qô z\í7:8¸À“CH@]	¢q—õó]kƒöAPŠ¡?lıw\Èş@ZQö\ÛŒvôõB]p\â`\Ğ\ŞsŒ¡Sƒª\à\ï—\íN½8x¨kYõª¿\0@ó~LÌ¿\"„š\Ê P\Ûj¢mE\r‚\Ö\Ï\Âş{/]>Åƒ\Ï\Ô\æ¯\nNüÿ‘\Ü\\ë°®\Ä?U\çzı\ãûH¶\Ë0\ÍS\ÆZrF©Ö’\Ç]@\Ü\ãqw\æ\åzı\ãûH¶\Ë0\ÍSV€Zt¼\çÏŸ‡.R©”«\Í\00::\êjW¡6\ë¼pá‚«O\Å\è\è(\0¸\Úe\Ìd-\Ùz\Ñ\\m}j\ëbö\'8÷\'\ÖÉˆÙŸŠULò“\æ\ê\í\0V®C¤±°\Ş&	û½Š‹û½L˜\Úü	ô\Ùg(¬¨¶ˆ¥+\×\ë·\ßG²]k\Ñ\Ç|­%»&<\îÎ¬\\¯\ßb|\Év\Ó]‹Î¥]« \É\Ù#¨Ázû“x¨\'\îşb½Ï8>}GP_Œô‰‰O°‘zy³¹\ÃPæ’ˆÁşf8Y‡õ+1q\Ép\Ïÿl/b\Ã	×¶fÚ£\Îo)^W…\à\É\ãyV\ZS˜(Dc‹}N\âR¾!JD¥‰\Ç\İÉ™\Âü<\î\ÒTq‘9I\ík.\å[x\íh\Ø\Ô¬\í²/ÛŒ ³º½ûcDÜ€\în°\î%²/TjAC¸\Í[\'Æ«G¾\Ë6K\"y´÷ \Ç%\0HT`½º<3Ø‰†0Ğ»±\Zƒ5¢.+=R_ƒX»}œ\ÚAhró÷¢¹ÚºOÈºlS¾M\Åw†‚ˆ.\r»<\î\Ò\Ü\æY´h‘ö\Ù\åUUU\Z\Z’\Í,À\è\è(R©”\ì\ì›G\Õ3.s=nH]\×\ÏušU™\ÉZJ÷ºD\ãË­ƒ¬\ìrˆNbıpK\æL¨\'®•h\Éós&7O.—>iÚ·ov\ìØ¡}†n1¾XK6\Öb®…\Ç\İK=\îMn\\.}ş\Ò\Ä\ãn¶|µœ9s\Æı\ìò¬?Q	³¶¸Ø®¹y\Şb\İl\ßZÃK¸\Ç\'r¸Õ¼eGN…™Ÿˆ¨xğ¸Kó\Ïd\ÚJÿ5\ÍeüDµ”V-<\îR1\âq7[¾Zx&“ˆˆˆˆf™DDDDTp\Ú\ÚZ\í\åò…\â\ìÙ³²9\Ã\ï÷#Nc|\\û\ãğx<ğz½3\æø|¾œ§f•™¬\å‘GÁŠ+d÷4‰ š\\¡M\Õh¾.Š\äf óböqG‘¼eÈºI;u<?7¾M}\Ì\ÂQ\ÄWü\n#k\ß\æ|VEF¬\ãR¾É™[¨\'nm„,%ú.ı\Æò¦n\Ä[£zM®\ßZ\İñ.4\ê¦?4q£{±{è¡‡°o\ß>Ê®¢|±–l¬%w»<\î+w³\å«epp\Ğu¹œ÷d\Úf\åŞ ¦n\Äw\Õa `»\ãhU\Ïı\ê 3b©ùö¡ó ™=\â4±<Uö \Zê‰£õ\Ù\êüc6u#¾«\n.\æw<\ËxoP6\ÖRZµğ¸;xÜ½X<\îf\ËW\ïÉ¼‘ÃMo³X\ßÎ‹öt#´·e=\ã\Õ~ô\Öa{·²¦‰~k[\ë9¸A±_[ıa;Ç±ip¨\'nÿœ\ã\Ñjñ¢õv\"\Ú\Ñ\àxCoß€õx5\0¡õ\æo6u#\î\Ø[-rØš+\ÔGòp·û\ïc\ç¸\êš5\àœ?‚h2î¨=v<ól^\ç\ïÁYG\ï\ÆÀ-\Ö\ï+\ÔŸt-…šŸˆ¦»\î\ã\r»4—p‘Y 5+-\0Z%P³y;°5€@G\Ì~jB\Ñ]u°\Ç\Õr¨­‡kĞ¼µ	$Ğ·U„j€ş\0NÄ‚h\r[Ÿz­O\ÅVû\È\Ú.\ë`º­°/Ö¯½„\Z\ë\ìG;BX·zRf8\ì?ˆ\Ì\Ó)\"¨¯xF/jë¬¿OÀÚˆ7\Z¶?Å¢\Ó~´X\'F\Ön\Ï&«½?†`¥UûD­\0Dce¿ı»‚õA8j\í\Û hA\ßR«KC°¡Û»±zÒ—b\n7?\ÍwyÜ¥\â\ÆE¦\Ñ\Ä\'\ã\ÖZ fs\îO	û™¯½Ï\0	û\É	OYŸh›–£A4\î²~¾km\Ğñ\È.§ú\Ã\Ö‡\ìÂ¡@\æMØşA ¢şC¨NŒ\Úû5OPo\Î5\í\0jPÁq\ã3fO§hZ\nõw\0€Áö§t{ş!\ÔTõ\ä‡d+j0ñ¸µI÷#fÿj*ƒö\Ó*`\İ\Ó\Ôeı\ïŞ¾$‚U\Ö\ï!Øˆ®dÉ¤u¯OM½ú\rö\âø\É ª®ËŒ<9›Ÿˆ\n‡\Ç]€\Ç\İüó\Ó\\ÀE¦Q/š«­OÁƒ\Ö\rÚ@`ÒŸØ²\Å\ìO\Å*¦\ïş”PO\Éú~¦x\ÏOo\ß\0°r\"u€}ğ6IØŸ\èULı÷ÒşÁ\ZÔ‡#¨¯UzƒAõ	Şœ7O\Öl\ÏODn<\îšğ¸{©ó\ÓL\â\"s&\ì?\Ô`½ıI<\ÔÏº÷Ç¤÷\ÙÇ§\ï\êk‘ş/b 1ñ	6R?q\Ù&\Ô\Çvlo\Ä†2—dö7\ãÀ\É:¬_‰‰K6€{şg{N ¸¶5\ÓM\æºwÊ¬½«¸e=j2g\r\08>‡\Z\ëLÙ¿‡õö¥!\ëL\ÇÄ™–/M˜/K\åP˜ù‰¨\èğ¸›Sa{<\îR~\\dNRûšKùf^;\Z6õk»\ì\Ë6#Ö·\r÷Çˆ¸\İ%\Ü`\İKd_©8Ô‚†p/š·NŒWû²MS7¶¯\r\"h·[E\ÄyI&öş\á¸d\0‰\n¬W—g;\Ñ¶\îÁ\é¬uM\ípÀº\'i\ÎK&¶•\Û\í\ß¬{§\Â\r\Ö}:»\ì\Ë&\';\'>Á7­C]ó¬\ÌODÓ‚\Ç]ws\ÎOs‚§²²R»…Ñ’%Kp\ê\Ô)\Ù<+f²–\İJcFi¶\ÒĞˆNbığ\Ä>f¡¸uQŸ›AwOÍ“=¸¶·ˆ šl¦°w\\h²[i\è`ş™°o\ß>|ñ‹_\ÄÑ£Ge×¤\Í\äû(Ö¢7_k\áq—\Çİ©\Î?xÜš\á\áa÷F£££\ĞE:vµ9À¤rR©”«]E:\0W»Œ\É\Ì3™œ\É\ÔRº\Ú\Ñy´\Ûs~Ú´.E´\Ö\Æp`²*ğrÀy\É\Ç$ErW#p¨ó\â\ï“j\ê\Æö•è¼˜S!\æŸA¹^¿\Åø>’\í2&3\ÏdrX‹;\æb-¥‹\Ç]—B\Ì?ƒr½~‹ñ}$\ÛeLf\É\ä\äªE‡›±\ÛfeS`¢I\â¦À\ÙXKi\Õ\Â\ã.#w³å«…›±ÑŒ\à\"“ˆˆˆˆ\n‹L\"\"\"\"*8.2‰ˆˆˆ¨\à¸\È$\"\"\"¢‚óz½^\è\Â\ãñ¸ÚœÀ˜#&\ÑF¾~¦y\Ô8¦\'Ù§\Ë!*Fò5+_»²]†\é=¢\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì\Ó\å#ùš•¯]\Ù.\ÃôQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²Oö+97c¯¨¨À\ÈÈˆl3Y·Ò bTˆMgò}”kÑ›¯µğ¸KÅˆ\Çİ©\Ñm\Æ\îY¼x±v‘¹l\Ù2œ8qB6g”——#•J7\ÓUû)\å\âõzQVVf\ÌÁ\×Âƒ£}ûö¡££C»_[1¾L9`-9\Í\×ZxÜ¥b\Äã®›©–Ó§O»™Ş±±1\èb||\Ü\Õ\æ\0\Æ\'\Ù\'sd»\Ó<jS“\ì\Ó\å#ùš•¯]\Ù.\ÃôQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“9²]†i5)\ÇIö\érˆŠ‘|\Í\Ê×®l—az¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'ûıEt\"\"\"\"¢KÀE&™DDDDTp\\dQÁq‘IDDDD\çõûıĞ…\Ç\ãqµ9ö\×\æe»\nŸ\Ï\0ğù|®>jóN\Ù.c&k!*V¹^¿\Åø>’\í2X‹>\æk-D\Å*\×\ë·\ßG²]\Æt×¢“s3ö%K–\àÔ©S²yV\Ìd-Ü¯ŠQ!6\É÷Q>¬Eo¾\Ö\Â\ã.#w§F»û¢E‹´‹Ìªª*\r\r\É\æŒ`tt©TJvöjXmÚ™kÿ$¿ß²²2œ?^ve™\ÉZx°£b´o\ß>\ìØ±C»)p1¾XK6\Öb®…\Ç]*F<\îf\ËWË™3g\\‹L^« \"\"\"¢‚\ã\"“ˆˆˆˆ\n‹L\"\"\"\"*8.2‰ˆˆˆ¨\à¸\È$\"\"\"¢‚\ã\"“ˆˆˆˆ\n‹L\"\"\"\"*8Omm­vŸÌ…\â\ìÙ³²9\Ã\ï÷#Nc|\\û\ãğx<ğz½3\æø|¾œ{2)3Y\Ë#<‚+V\Èn¢Yõ\ĞCaß¾}”]Eù>b-\ÙXK\îw©Xñ¸›-_-ƒƒƒ®}2¹»›S1\ã¦À\ÙXKi\Õ\Â\ã.#w³å«…›±ÑŒ\à\"“ˆˆˆˆ\n‹L\"\"\"\"*8.2‰ˆˆˆ¨\à¸\È$\"\"\"¢‚\ã\"“ˆˆˆˆ\n\ÎSYY©\İ\ÂhÉ’%8u\ê”l3Y·Ò b´o\ß>|ñ‹_\ÄÑ£Ge×¤\Í\äû(Ö¢7_k\áq—Š»S3<<\ì\Ú\Â\Èµ‹\Ì\Ê\ÊJ\ËæŒ²²2¤\Ói\í^IJYYR©”v\ÓN\Ø{.ù|>ŒÊ®,3Y\ËOúS\ìÜ¹SvÍªU«V\á_ødWQ¾XK6\Öb®…\Ç]*F<îº™jI$®E¦¯¼¼<<66W]u~ó›ß¸\ÚU¨bR©”«O\è÷û1::š)Z†Ú¥şOú“«\Ï3YK®MH•«¯¾\Zü\ães†\ß\ï\0\íÿ°w\Ì÷ûı9û\áxÁ¨\Úsa-zS­e\éÒ¥øı\ïŸ\éŸ\ÍZ$U\Ës\Ï=‡¡¡!œ8q\"\çk·˜\ŞG¬%;X‹¹–b?\î.X°\0ñ\ßı\îwx\á_8«µ8\Íö\ïÅ©k\áq7;ò\Õrşüy\\y\ÕUÙ¿K>ñÇ’¯–—¾ô¥ø\å/Yµ(¬Eo*µ\\{\íµø\îw¿‹‡zÿøÇY¬E‡µ°\'Ö¢7µü\å_ş%>û\Ù\Ï\âE/zª««q\Í5\×\ÌZ-\Òlş^¤Ù¨\å\ÆoÄ·¿ım™6+µ\ä2Ÿj\á.Ò†\rğŸÿùŸ8t\è\ì¢9®ºº\Z\0ğ\Ş÷¾›6m’\İD4O]v\Ùe¸ë®»p\ß}÷¡ªª\nü\ãg\Çhfuvv\â\Ë_ş2ö\ìÙƒU«V\Én*\\d\Z\\{\íµ\è\é\éÁ§>õ)¼ğ…/Äüc™BsÜ«^õ*\\q\ÅxÁ^€~ô£ø›¿ù™BDó\Ì\r7Ü€\ï|\ç;¸ıö\Ûqõ\ÕWö%\Ô\Ñ<÷¼\Ñ\Ì9xğ \Ò\é4nº\é&\ìÛ·»w\ï\ÆÊ•+e\Z\Í2.2sx\ßûŞ‡oû\ÛX»v-‚Á \0\à¹ç“i4Ç½ı\ío\Ïü\ïk®¹Û¶mÃ7Ş˜•CDóÇ›\Şô&\ìİ»Ë–-ËºW;\×%DšÇ\ÃÙ³gûÌ›o¾ÀÁƒñš×¼F¦\Ó,\á\"S\ãû\ßÿ>¶mÛ–ù«88T\Z–.]\n\Ø÷’œ;w>Ÿ÷\ß?şú¯ÿZ¦\Ñ<ğ“Ÿüü\àñÁ~‡\Â\È\È\0\àøƒL¥Yt\ì\Ø1\\~ù\å€ıÿ\ÍÙ³g‘H$p\Ùe—ñ„Pñz½^\è\Â\ãñ¸Úœûòlwö;&\ÑF¾~¦y\Ô8¦\'\Ù\'s¼^/zzzğÑ~;v\ìÀğğ0~ó›\ß\àw¿ûÎ;gœGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨q<^õªW¡¼¼\Ï=÷¾şõ¯ã³Ÿı,\Şû\Ş÷¢§§\ßü\æ7sº\Ù\î\ì\Ï7W¾~¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“9²]†i5)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûdl—ašGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™ó\Û\ßşÿñÿgy«W¯\Æ\ßş\í\ß\âw¿û]\ægMó¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“9\ê\Ïj;Ó§O\ã\ÑG\Å\êÕ«ñWõWø\ío\ëúY9N¡k\É¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“ıJ\Î\Í\Ø+**2Ÿ\àf\Ûl\Ôr\Ùe—\á\Ö[o…\×\ë\Å\ßøF\Üp\Ã\rø\à?ˆx<>\ãµ\ä2¿—\\\æb-\ïÿûñ\á·\Ür^úÒ—\â†n@8–i—d²µ\ÌÖ¢\ÇZô\æ{-ŸúÔ§H$pÿı÷\ãSŸú\ŞúÖ·bÍš5³RK.ó½–®®.¼\å-oÁ>ğ¼ù\Ío\Æùó\çñOÿôO³RK.ó©\íf\ì‹/\Ö.2—-[†\'N\È\æŒòòr¤R)¤\ÓiÙ•¡¾ê‹\×\ëEYY™1³TË›\Şô&¼ó\ïDww7ÎŸ?\ï|\ç;ø»¿û;\Äb±¯%—\Ùø½\ä2Wkyñ‹_Œ_ı\êWx\Å+^\íÛ·cË–-8v\ìØ¬Ô’k\Ñc-z¬Eo*µ\Ô\Ô\Ô\àóŸÿ<\Z]_ö™\éZL\æ{-w\ß}7\Şğ†7\à\rox\Ê\Ê\ÊğÕ¯~===øñ<\ãµ\ä2¿—\\¦»–Ó§O»™\Ş1Í†›cccwµ9öF¦²\İÙ¯\È>™#\Ûe˜\æQ\ã˜rœdŸ\Ì\Ã\âÅ‹QWW‡\Ç{O<ñ|òI¼\á\roÀÁƒó¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sd»\Ó<jS“\ì“9²]†i5\Ê9u\ê\Æ\Æ\Æğ\ÔSO\áé§ŸÆŠ+•\ä+_¿Š©Ô¢\'\Ù\'sd»\Ó<jS“\ì“9²]†i5)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûdl—ašGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸ\Ì\Ãû\ßÿ~|ù\Ë_\Æ{?@g˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9N²O\æ\Èv¦y\Ô8¦\'\Ù\'sÔŸ?ò‘\ào|#\Æ\Æ\Æp\á\Â\Üy\çø\ä\'?‰—¼\ä%®Ÿ•\ãº–\\ašGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>Ù¯\è/¢\Ïs«W¯\ÆÂ…ñø\ãg\ÚL«*\rÇÃµ\×^+›‰hy\Ë[Ş‚¿ø\Åxø\á‡e¡”\ã[ÿƒƒƒ\è\è\èÀ‡?ü\á¬š=\\d\n\×^{-V­Z…#G\à\ÙgŸ•\İTÂ;†W¼\âX¸p¡\ì\"¢y\âø\0¾ü\å/\Ëfš#¾úÕ¯\âô\é\Óø\ÈG>\"»hp‘)¬^½\Z\ÉdG‘]T\â;†…\â¯x…\ì\"¢y\à\ïx~÷»\ß\á»\ßı®\ì¢9\ä_ø\Şü\æ7\ã/ÿò/e\Í0.2^÷º\×aõ\ê\Õxüñ\Çq\æ\Ì\ÙM%ndd$s6“ˆ\æÇƒ\Ûn»\r»w\ï–]4Çœ?w\Şy\'\î¸\ã¼\ä%/‘\İ4ƒ¸È´-\\¸uuuøÑ~Ä³˜ó\Ø\ÓO?\ÍE&\Ñ<ôş÷¿ƒƒƒx\â‰\'d\ÍAG\Å\îİ»q\Çw\È.šA¾+®¸\"\ì\Õlªy\å•W\âÜ¹s®v>ŸÈ³q§\×ŞœS¶\ÉÈ—3µ¼\éMo\Âõ\×_o~ó›øõ¯\í\êW1µL6‡µ\è\ãRj)//Ç7Şˆ\'xgÏuõË˜\ÎZœ‘o\É\ä°}°}Ì§Z^ô¢á®»\îB8\Æó\Ï?\ï\êw\Æt\×2•Ö¢UK,Ã›\ßüfTWW\ã‰\'\Èô\ÏF-²]E)\Õr\î\Ü9\\y\ÕUpÊ¹û’%Kp\ê\Ô)\Ù<+¦»–¥K—\â\Ö[o\ÅSO=…¯ı\ë²;\Ët\×2¬E\ïRjY¸p!¶nİŠ¯ı\ëxô\ÑGe÷”]J-…\ÆZôX‹\Ş|ª\å#ùR©v\î\Ü)»\\¦»–©`-z\ÎZ®º\ê*|\å+_Á;ğ½\ï}O¦N»bı½L\íf\ì‹-\Ò.2«ªª044$›3,X€\Ñ\ÑÑ¬\íœ¼öY!µÏ˜\ß\ïGYYÎŸ?/»²Lw-\ïz×»ğ\êW¿\Zûö\íÃ±c\Çdw–\é®Eô{Á<­\å\ïÿş\ïñ\Ç?ş_şò—g½–bú½°\Ö\âT*µ\\{\íµØ³gnº\é&œ?~VkQŠ\á÷¢”B-ox\Ãp\çw\âoş\æoğ«_ıjVk‘J©–3gÎ¸™\Öy\Ïy\ìÕ¯~u\æ\Ë>\ê9¨4¿;vÌµ);•&µe‘z>9•G}_û\Ú\×x\æ,˜×‹L¯×‹U«Vahh²›\æ©cÇ\á\å/9¿\0DT\âV­Z…\ê\êj|\å+_‘]Tb\î¿ÿ~¤\Ói|\èC’]4\æõ\"sõ\êÕ¸şú\ëq\ä\Èüş÷¿—\İ4O;v\Ï>û,^şò—\Ë.\"*!\Üx}~ùô§?w½\ë]¸\á†dM“y»\È\\´hQ\æ2ùÑ£Ge7\Ís\Ï<ó\Ïd•°¿ú«¿BYYş\í\ßşMvQ‰úõ¯Oú\Óø\Ø\Ç>†E‹\Énšóv‘¹j\Õ*,^¼˜{b’–Zdò“D¥‰g1\ç§\ï}\ï{ø\æ7¿‰O|\â²‹¦Á¼\\d¾\ìe/\Ã\êÕ«q\ä\È<õ\ÔS²›\Ï<ó®¸\â\n\Í$*A\ï}\ï{qüøqü\à?]4tuu\áò\Ë/\Ç\í·\ß.»¨À\æ\å\"sÕªUø\Ãş€\Ç\\v\0~õ«_ñ“D%\è/x\Ïb>ó™\Ï\à\Ö[o\Å\êÕ«e§¶¶V»O\æÂ…qö\ìYÙœ\á÷û‘N§1>®ıñÌñccc\ÆŸÏ—sO&¥µTWW#\n\á;\ßùN\Ö\"s6j1\å°·™®\å\ÆoDUUv\í\Ú%Sf¼–bú½°–l¬%÷<\ÅXKss3.\\ˆ/|\á®œ™®Å”\ÃZ\Ü\n]\Ë\r7Ü€÷½\ï}øû¿ÿ{œ;w.\Ó?µ˜\æ™+µºöÉœW›±{<lÜ¸\0°g\Ï\\¸p!“3Óµ\Óï…µdSµTWW\ã\ïş\î\ïp\Çw`dd$+g¦k)¦\ßk\É\ÆZ\æN-/zÑ‹ğõ¯k×®\å{šµ •J\áş\áPQQü\ã™şÙªEg.\Õ2\ï7c_µj^õªW\áÈ‘#YL\"cÇ\áÜ¹s¼dNT\"n¿ıv|ù\Ë_v-0işº÷\Ş{pë­·\Ê.*€y³\ÈƒXµj9‚ÁÁA\ÙM\ärö\ìYŞ—IT\"^óš\×\à\rox\ï\Å$—;\ï¼›6m\Â\ë^÷:\ÙE—h\Ş,2\ë\ê\ê°`Á~Ù‡¦„‹L¢\Òp\Ûm·a÷\î\İ•]4\Ï?~w\Şy\'\î¸\ã\\~ùå²›.Á¼XdşÙŸıV®\\‰\Çÿó?ÿ#»‰rR‹L>ı‡h\îz\Ë[Ş‚`0ˆıû÷\Ë.\"\0À7¿ùM<ö\ØcøÔ§>%»\èÌ‹E\æªU«púôiÅ¤);v\ìy\æ\\{\íµ²‹ˆ\æˆ\Ûo¿\Ï\'§¼>ÿù\ÏcÙ²e¸\å–[d]¤’_d\Ö\Õ\ÕaÕªUÀo~ó\ÙMd4>>\ÎK\æDs\Ø;\ßùNü\îw¿\Ãü\Ç\È.\"—;\ï¼ù\ÈGğš×¼Fv\ÑEğTVVj·0Z²d	N:%›g\Å\Å\Ör\ÅW`Ã†\r8w\îö\îİ«ı\ÊıT]l-Óµ\èº–n¸\ïx\Ç;°mÛ¶¬½\Ô&£Ğµ\\\nÖ¢\ÇZôJ¡Çƒù—A$Áÿ÷\Ë\î‹r±µLÖ¢w©µ466¢©©	·\İv\Û%¯.µ–Bš\îZ†‡‡][ù,XƒŒ…\âù\çŸwµ«ğù|H§\ÓH§Ó®>gN*•Ê™{ß¥\Ñ\ÑQWŸ3.¶–n¸ñC‡!™L\Îj-2‡µ¸£Xkù\ãÿˆo¼O=õN<‰±Y¬Eö±–œ9¬EŸ3Ÿj¹\í¶\Ûpşüy\ìİ»w\Ök‘9¬\Å\ÅR\Ë\Ïşs¼ò•¯\Ä\ßøF|\ï{\ßsõ\Í`-*§~/*\'W-\çÎÃ•W]\'o*•‚.\Æ\Ç\Ç]m\Î\0€±±1W»Š1û/N§]}2G¶Ë¸˜Z***°r\åJ<ö\Øcø\éO:«µ8c¶/\Î`-î¾”¦–\ç{O?ı4^ö²—¹r\ä\Ï\Ê(t-º`-\î~gl—ÁZô1\×k¹êª«ğ¾÷½÷\ßÿ¬\×\â\Ö\â\îKa-Ÿÿü\çñgögx\Ç;\Ş\á\êW93UK1ı^Lµ\è”\ì=™«W¯\Æ\Ø\Ø9\"»ˆ¦\ìé§Ÿ\æ}™Ds\È\í·ßpGºhŸşô§q\Çw\àU¯z•\ì¢I*\ÉE\æk^ó\Z¬^½\ZGÁğğ°\ì&š2õ\åŸ¿øÅ²‹ˆŠÌµ\×^‹›nº‰¯\Ó%‰\Çã™…&]œ’[dú|>¬Zµ\n¿ü\å/¹eÌ±c\Çğ‡?üg3‰\æ€|\àøò—¿Œ\ßşö·²‹hJz{{ñô\ÓO\ãŸø„\ì¢I(¹E\æ\êÕ«ñ\Ú×¾GÁÙ³ge7\ÑEùı\ïÏ­Œˆ\æ€U«V¡ººšûbRÁ|úÓŸ\Æk_ûZ\Üt\ÓM²‹ò(©Ef À\êÕ«ñø\ã\ã‡?ü¡\ì&º$O?ı47e\'*r\ê,&Q¡¤R)|úÓŸÆ§>õ)>ımŠ¼^¯ºğx<®6gÀŞƒL¶;û“h#_¿\n\Ó<jÇƒ×¿şõpõ\ç›+_¿Š\É\Ö\"Ûıù\æ\Ê×¯\Â4\ZÇ”\ã$ûdl—ašGc\Êq’}2G¶\Ë0Í£\Æ1\å89ÛŸ}öY¼\â¯\ÈZhÊŸ•aš\Ç{	µ\èrd»\Ó<jS“\ì“9²]†i5)\ÇIö\É\Ù.\Ã4\ZÇ”\ã$ûdl—ašGc\Êq’}2G¶\Ë0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ãx<¬]»—]vúúú\\ıù\æ\Ê×¯b²µ\Èvg¾¹òõ«0Í£\Æ1\å8\É>™#\Ûe˜\æQ\ã˜rœdŸÌ‘\í2Ló¨qL9Nª\í\'?ù	v\îÜ‰;\î¸#+Gş¬\Ó<jS“\ì“9²]†i5)\ÇIö\É~%\çf\ì‘Í³b2µ¼\ìe/Ã†\rğ\ÄO\à›\ßü¦\ì.˜\É\Ô2SX‹\Şt\Õ\âñx‡ñƒü\0\ßı\îwe·\Öt\Õr1X‹kÑ›‹µ\ìÛ·_ø\Âğè£Ê®‚™l-3µ\èMg-[·n\Åó\Ï?;v\È.­\é¬eª¦»\İf\ìoû\Û\ÚEfyy9.\\¸ ›3¼^/\Æ\Ç\Ç1>®ıqÀ\ÎQû*\éx<x<c&Y\Ë\âÅ‹q\ÅW\à¹\ç\Ó\æ\Îd-\Åô{\Ç\ã?;w\ÊnÀc÷\îİ²9£Ğµ\Ó\ï\åbjY¶l|>?>\ëµ(³ñ{\é\è\è\Ğ~±\Î\ëõ¢¬¬\Ì8\ì\ß\ã‰\'dsFyy9Rö†¿¹L\æ\ïSŠµ|\èC\ÂÊ•+eWF1¾^r)d-K–,ÁUW]…\'Ÿ|Rv3\\K1ı^&óo@®1>÷¹\Ï\á%/yIAk)¦\ß\Ë\Å\Ô\âóùğº×½Ç\Ãoû[m\ÓtÖ¢\Ã\ïöm\ßúöwğı\×L›\ç¯ş\ê¯r6\ÇL÷*}.Z½z5\0h?uy½^”Û‹L]?¹ı\Å_ü\Şü\æ7\ãK_úşø\Ç?\Ê\îy¡­­\r;v\ì\Ğ.2ı~?\Ê\Ê\ÊpşüyÙ•¥ªª\nCCC²9cÁ‚Í½Á¯ıÚ½p\áB\Î^©\Öò¡}c\Ü˜&i2ÿ\äz\í\Şu\×]xüñ\Çñ\Üs\ÏÉ®yÍ´Ğš\Ï\Şù\ÎwbğÇ±\ìE\æ¢E‹Jf‘Inmmm@ŒZd\ê\r”mÉ’%øô§?;v\à\Ç?ş±\ìö\íÛ—óõR\È\ÅT1-ìŠ©µ\ÈÔ½§‰¤\Éüëµ«™ÿü\Ïÿ,»ˆ\\>÷¹Ï¹™ú;5‰H\ëÔ©S\ÜÊˆˆˆh¸\È$š¢\Ï|\æ3üdODD”GI/2#‡“H\Èf\"\"šøo\0\Ñ\ì*\ÎEf8Šd2™y¡¸È‰ ~iZÖ´;Ú¨´EM&\r‹\æ¦nÄ“Q˜_AR\Ñd\İM²ˆ¦ÿ\r ‚\n¡;D¼\'$\Ú/\æ81?3\ç\"\0Cg €@ €@ ±\Úõ\ÆÿSk*ƒ\Ù\rM1tV7£7»u^òz½ğûı®ğù|€½ıAihG\ç¡j\ê³ÿ1Š´4\"8Ø)ıSÓ´²2|>Ÿ\ëõ\ä÷û\áµ7\ä•\í2<«\Í0¼nı\×n®:ü%\\K\é¼_ó\á¿…’\ëõ›ïµ«^·s_/š!¸rœ\Ë\ÌP\Ïz\Ô$pp¿£1ş\Û0%sò\ê‰g>\İ\Æ{B@8Š\ÖZ\0µ­öY¬º·u¡+™D2ó‰\Ãúô=¬~vş|ñ\Ú{ô\É(\Å´zû¨­wœµŒ ¾6¾®vûŒ¦:3bŸ\ÙG‘ŒG\Û\íñn„B÷¶FD\ã6ûÏª?“£ÎœD•gZşÿ\í\İ?h\\g\Ö\Çñ3wf³6‘dv`»\İB¸yÊ…\Ù\ÒJ\çd«¬KcDH™j\Ùo“\"c‚›„\İ\"duV\ÊM\n5Ai„šmÂ‚mf-\ÛIa\Î\ÌH[\è>\ãG¿9s$m.±=ú~\à4\çœ<\Ï!¹\Ñ}æ®ö\í\ã½z~ı5\Êß–\ÖH7-\Ík\Ô\ëõ‘\\V\Şø4Ÿ\"]»\ã\æhNğ,“ôÿ\ëÿŠ{À\Ñtw\íN\Î!\ÓÌ–\Öl³u\Ñ\Şş7¿joÿ_\Ë6ÿq\ÍV\ÊOÁö_\Şõ¢÷†ò+r_{os/™d¯ğ4g\Ãÿpf·ÿ`×–÷w¯l•¯p\ï\ØÖ•»ö]¶;f¶q\Ç./™\İú\ç]›ÿÏ½WÀ··lş³ôQi\Ëf;µ™™»³Ñ²ù\ëñ\Ç/“¢\ß\ï\ÛöööH¤‡²z®xm-ß³õ\îœ]J™/]*_©Ş²\ï>»h\ë7ö\Ş¹şÍ¬-¤ÿñ[³ö\à£òİ’Ö¼-,­ØµV­k][ıèš­¼;g÷?\Ê\ŞQ\ÉP]0[›™±™«\Ö-\ßi¹ú\Çûö\×ô\Ì\í\ÑWÏ“\àùó\ç#\×\Óöö¶õz=3³‘¼Æ¸k2…™Y¯\×É§H\×\î¸9¶\'x–‰úÿ5\Ä= *ã®«ƒ®\İq\íz=-\Ú\ÚF\Ë.Î—?\ß}\Û.¶6mm\éªı\í_f·\Ó\Ï\ì­\árôz™\Ûo°[fk\é\Şp\İVó{so°\è^2¡^\áC\æşJ\ìı½\ï\Ú]ıı¬\Ùğ£\ÏE[\Û0›ıı¾7À\íÍ³f›kå‡£Kk¶i³öfùr\ë\ß{lvº\Ù?ƒÉ±b÷~\è\ÚÜŸ\ËW™—\æ¬û\Ã=[y÷M›µ–\Í¶wÓº{¥e6|\Çs\Ë\î/›™m\Ú\ï²X^´\Å\åô\ntÁ\æòZ÷mš™-ß·ôg\0V–m%½›ùş¾n\0‡\Æ=\0\ÕZ\\Û´Ö•…½w\ç/–_£š³ó-³¹÷\Ë4\ïÏ™e‡¿øzY´Å¥ôn\æ]›Ï¿±\á\Ü\Â{É„z…™9\ï	\à[Y]·në¢½ı\î\ŞG\å\ë«\é[YùMk\Æff.\î{šK\ßÙ“\'w\íü?\ÊWŸZ·şùÄ|vŞ¾.\ß\Éğkq@–\Öl\Ó\æ\ì\ÒRùQyz!b][-?\åÚ‹ò]óƒ”o&¼Ó¹^¾“©\r\âˆ÷’Iğš2oÙ¥{¯(Vş½•½õ\"ÿÂŠ\İÿ½øå¥K67|§\n\Ç\Âò=[\ï¶\ì\â\Íwln\ã\ë½\Ë÷m\Ë\æ\ìòû‘Wÿş¯£}¦»jw–\Òõt°\î7wl±|\'À¯\Å=\0U\Ø{±2÷\çÿ·‹VşL·M{\ĞÍ¾:±ôİ‹\ï\ìÊ¦}ı—•ò\ãw­9x/yİ½Â‡\Ìı\ßÇ™+¿kcK—÷¾OW\æg¿¹n——Ê·²\Ë/}/şéº­](\ßúµ\Õ‡|\Ç\n¢üM\ÂVşJu\Ñ.\ßX5»r·ü¸|+ş\Í\Ó\åû¶•¾Ü½´f›­ù½_\"¸ôÀV»-;ÿGı^\ØûHfoŸKU\ë¶\Î‹&@µ¸ z‹wW­\Ûj™ıp¯üù¿b\×şp\Ç6/òz\É\ï\r\å\ï\0,<ybOnš­ônû\ï%“€¿]>\áówkù\Û\å8\nşvù~¿õ,ü\ír\Åa\î\ã®]şv9‚¿]\0\0€\ß‡L\0\0\0T\Ë\'\Ü|`§N²/¾øBKV«Õ¬(\nû\ä“O†‹\0ùê«¯\ì\Ë/¿´\r-Y­V³z½>ö£\å\äÄ‰ö\ì\Ù3M5\Z\r¶»\ëÿxJ\×\î\Î\ÎN\Ø3‰³¼÷\Ş{öó\Ï?»\ê0÷€q\×\î‡~h\ß~û-—\ãP¼\Ë9dN¸\Ã|‡\ïd\â(øN\æ~¿õ,|\'Gq˜{À¸k—\ïd\â(¼C&—\0\0 r2\0\0P9™\0\0\0¨‡L\0\0\0TC&\0\0\0*\Ç!\0\0\0•\ãy4\Z\r›‰©©)³ò1ÀQLMM\\O\Ó\Ó\Ó\Öl6\Í\ÊG\íD1\îšLaf\Öl6Gò)Òµ;n\é	…ÿ_qTã®«ƒ®\İF£¡KGR»yó&\ÏÉœpEQ\Ø\íÛ·5mV\Ş<?ÿüsûşû\ïµ¸\Şz\ë-ûô\ÓOm}}]KV…\Õ\ëu\ëõzZÚ§\İn[§\Ó\ÑôP³Ù´Á`\à>»/i6›\Ö\ï÷İ‡H\Û\Ïr\ã\Æ\rZ\Æ:\è0\î\Úıø\ã\í\áÃ‡š\\gÏ=üs2O:¥©}\ZFøŠºV«Y£Ñ°Z­¦¥¡¢(õJ‰Y|‡egg\ÇúışH¤›¦÷P\í¤\êY\Æyÿ^\Æa_še}}\İƒÁ\Èõ”_Sš\×\Ø\İ\İ\É\åafc¯\Û~¶Ï¸9ò\Ík¼n³x‡\äU¼^˜e¿—1Ë¸\ë÷ k÷\áÃ‡•\Ï2\Î\Ëø÷2³øš\å\Ç\Ô\Ôø¿øs˜¿<ñ*ıf\Å,>fñ1‹Y|\Ì\âc³ø&i–§OŸZû\Üù}¹ñGV\0\0\0\à\Ä!\0\0\0•\ã	\0\0€\Êq\È\0\0@åŠ¢(Ì‹Z­6’\Ë\Ã\Ê\ß4\Ò|^\Ï6q\ã zŠhŸ´NÔ“Óšöh^#\Ú\'­õä´¦=š×ˆöI\ëD=9­i\æ5¢}\Ò:QONkÚ£yhŸ´NÔ“Óšöh^#\Ú\'­õä´¦=š×ˆöI\ëD=9­i\æ5¢}\Ò:QONkÚ£yhŸ´NÔ“Óšöh^#\Ú\'­õä´¦=š×ˆöI\ëD=9­i\æ5¢}\Ò:QONkÚ£yhŸ´NÔ“Óšöh^#\Ú\'­õä´¦=š×ˆöI\ëD=9­i\æ5¢}\Ò:QONkÚ£yhŸ´NÔ“Óšöh^#\Ú\'­õä´¦õ¤\Ön·\İ\ß.Ÿµ­­-M¿\Ì\âc³ø˜\Å\Ç,>fñ1‹Y|\Çi–N§3ò\Û\åµÓ§O»‡\Ìs\çÎ…ašš²~¿>8ıªû8EQX³\Ù{ŒY\Æb³ø˜\Å\Ç,>fñ1‹Y|\Çi–Ç2‹óbwww$—‡•\Ö|^O´¦=š×ˆöI\ëD=9­i\æ5¢}\Ò:QONkÚ£yhŸ´NÔ“Óšöh^#\Ú\'­õä´¦=š×ˆöI\ëD=9­i\æ5¢}\Ò:QONkÚ£yhŸ´NÔ“Óšöh^#\Ú\'­õä´¦=š×ˆöI\ëD=9­i\æ5¢}\Ò:QONkÚ£yhŸ´NÔ“Óšöh^#\Ú\'­õä´¦=š×ˆöI\ëD=9­i\æ5¢}\Ò:QONkÚ£yhŸ´NÔ“Óšöh^#\Ú\'­õä´¦=š×ˆöI\ëD=9­i\æ5¢}\Ò:QONkZOü\Ñ\0\0€_C&\0\0\0*\Ç!\0\0\0•\ã	\0\0€\Êq\È\0\0@\åj­V\Ë}„Q»İ¶N§£\é¡f³iƒÁ`\ìo\Õj5k4\Z\Ö\ï÷mw\×\İÂŠ¢°z½n½^OKû0‹Y|\Ì\âc³ø˜\Å\Ç,>fñ§Yº\İ\î\È#Œ\Æ>ŒıÌ™3ö\è\Ñ#M¿\Ì\âc³ø˜\Å\Ç,>fñ1‹Y|\Çi–÷0ö7\Şx\Ã=d?\Ş<x \é¡\é\éi\ëõz\Ö\ï÷µdV¬\ÓC;ÇŠ†5›M\Û\Ş\Ş\Ö\Ò>\Ì\âc³ø˜\Å\Ç,>fñ1‹Y|\Çi–§OŸ2ùN&\0\0\0*\Ç!\0\0\0•\ã	\0\0€\Êq\È\0\0@\å8d\0\0 r2\0\0P9™\0\0\0¨\\\íÂ…\îs2Oœ8aÏ=\ÓôP£Ñ°Á`\à>õ\İ\Ê\'\ÃEa;;;aO½^ûL¦„Y|\Ì\âc³ø˜\Å\Ç,>fñ1‹\ï8Í²±±1òœL\Æ^bfI˜…Yr\Ì\âc³ø˜\Å7I³ğ0v\0\0\0ü&8d\0\0 r2\0\0P9™\0\0\0¨‡L\0\0\0TC&\0\0\0*Wk·\Û\î#ŒÎœ9c=\ÒôKÁ,>fñ1‹Y|\Ì\âc³ø˜\Åwœf\ét:#0ªµZ-÷\Ùn·­\Ó\éhz¨\Ùl\Ú`0pŸ•”4›M\ë÷û\îC;­|\æR½^·^¯§¥}˜\Å\Ç,>fñ1‹Y|\Ì\âc³ø\Ó,\İnw\äYŸššZ\Ú\Ù\Ù1“\'O\ÚO?ı4’O‘†\é÷û#µ4`£Ñ°^¯7Z#=¥ş—_~©\åÁ,~0‹\Ì\â³øÁ,~0‹\Ì\â³øqœf\Ù\ŞŞ¶ß<i9¾“	\0\0€\Êq\È\0\0@\å8d\0\0 r2\0\0P9™\0\0\0¨\\Q…yQ«\ÕFry˜Y\Ø#›¸qP=E´OZ\'\ê\ÉiM{4¯\í“Ö‰zrZ\Ó\ÍkDû¤u¢œÖ´Gó\Z\Ñ>i¨\'§5\íÑ¼F´OZ\'\ê\ÉiM{4¯\í“Ö‰zrZ\Ó\ÍkDû¤u¢œÖ´Gó\Z\Ñ>i¨\'§5\íÑ¼F´OZ\'\ê\ÉiM{4¯\í“Ö‰zrZ\Ó\ÍkDû¤u¢œÖ´Gó\Z\Ñ>i¨\'§5\íÑ¼F´OZ\'\ê\ÉiM{4¯\í“Ö‰zrZ\Ó\ÍkDû¤u¢œÖ´Gó\Z\Ñ>i¨\'§5\íÑ¼F´OZ\'\ê\ÉiM{4¯\í“Ö‰zrZ\Óz2öaì³³³¶µµ¥é—‚Y|\Ì\âc³ø˜\Å\Ç,>fñ1‹\ï8\Í\Òñ\Æ~úôi÷y\î\Ü9{øğ¡¦‡¦¦¦¬\ß\ï\Û`0\Ğ\Ò\Ğ\ÔÔ”=ş\\\ÓCEQX³\Ù{ŒY\Æb³ø˜\Å\Ç,>fñ1‹Y|\Çi–Ç2}˜fŠ\İ\İİ‘\\föä´¦=š×ˆöI\ëD=9­i\æ5¢}\Ò:QONkÚ£yhŸ´NÔ“Óšöh^#\Ú\'­õä´¦=š×ˆöI\ëD=9­i\æ5¢}\Ò:QONkÚ£yhŸ´NÔ“Óšöh^#\Ú\'­õä´¦=š×ˆöI\ëD=9­i\æ5¢}\Ò:QONkÚ£yhŸ´NÔ“Óšöh^#\Ú\'­õä´¦=š×ˆöI\ëD=9­i\æ5¢}\Ò:QONkÚ£yhŸ´NÔ“Óšöh^#\Ú\'­õä´¦=š×ˆöI\ëD=9­i\æ5¢}\Ò:QONkZOü\Ñ\0\0€_C&\0\0\0*\Ç!\0\0\0•\ã	\0\0€\Êq\È\0\0@\åj­V\Ë}„Q»İ¶N§£\é¡f³iƒÁ`\ìo\Õj5k4\Z\Ö\ï÷mw\×\İÂŠ¢°z½n½^OKû0‹Y|\Ì\âc³ø˜\Å\Ç,>fñ§Yº\İ\î\È#Œ\Æ>ŒıÌ™3ö\è\Ñ#M¿\Ì\âc³ø˜\Å\Ç,>fñ1‹Y|\Çi–ó0öÿFV&Ac£\0\0\0\0IEND®B`‚');
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
) ENGINE=InnoDB AUTO_INCREMENT=45 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto`
--

LOCK TABLES `producto` WRITE;
/*!40000 ALTER TABLE `producto` DISABLE KEYS */;
INSERT INTO `producto` VALUES (2,'secco',30,1500.00,2,1200.00,'3 litros4','2025-10-11 11:42:00',1,'10011010'),(3,'Coca-cola',70,0.00,2,150000.00,'2.25 litros','2025-10-11 12:25:55',1,'11101101'),(4,'pan',22,1000.00,3,1100.00,'20 kilos','2025-10-11 00:53:04',1,'2002202'),(8,'Gaseosa',30,1400.00,2,1600.00,'1 litro','2025-10-09 12:42:08',1,'1010100'),(12,'yerba',20,1600.00,9,1400.00,'1 kg','2025-10-10 20:21:29',0,'21212121'),(15,'Pure de tomate',10,130.99,2,900.69,'nada','2025-10-11 12:25:38',1,'125125'),(22,'Masita diversion',5,25000.00,21,2000.00,'dwd','2025-10-11 01:28:00',1,'1241556'),(31,'Sidra',16,2500.00,2,2000.00,'12','2025-10-08 00:22:34',1,'491915051051'),(38,'borra',2,12321233.00,21,123.00,'dd','2025-10-11 12:01:28',1,'INT-3'),(40,'Ravioles',3,279999.00,9,249999.00,'nadad','2025-10-11 00:54:08',1,'INT-4'),(41,'Lavandina',5,1852.00,2,1252.00,'nada','2025-10-11 12:07:17',1,'INT-5'),(43,'Detergente ariel',13,1000.60,2,650.90,'adadd','2025-10-11 12:25:16',1,'INT-6'),(44,'Queso Roquefort',5,620.20,9,480.00,'adad','2025-10-11 12:27:33',1,'INT-7');
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
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proveedor`
--

LOCK TABLES `proveedor` WRITE;
/*!40000 ALTER TABLE `proveedor` DISABLE KEYS */;
INSERT INTO `proveedor` VALUES (3,'Distribuidora Norte','20-12345678-9','3624-555555','Av. Siempre Viva 123',1,'2025-09-23 08:35:45','contacto@norte.com','Distribuidora Norte SRL'),(4,'Arcor','00997733664','3644223344','ada',1,'2025-10-08 21:34:13','qwrqwr@gmail.com',''),(8,'Manaos','09987674637','3562674455','calle hiporito hiyrogoyen ',1,'2025-10-11 01:58:57','manaookk@gmail.com','Manos SRl');
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
  `escliente` tinyint DEFAULT '0',
  `esproveedor` tinyint DEFAULT '0',
  PRIMARY KEY (`idusuario`),
  UNIQUE KEY `dni` (`dni`),
  KEY `rol_id` (`rol_id`),
  CONSTRAINT `usuario_ibfk_1` FOREIGN KEY (`rol_id`) REFERENCES `rol` (`idrol`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'Federicooo','Molina','38962453','3644657148',1,'FNMolina','123456789','fede.099molina@gmail.com',1,0,0),(2,'Hector','Ramirez','38862453','3644657148',2,'EliasR','123456789','what@gmail.com',1,0,0),(12,'Prueba','Prueba','12312356','3644332255',1,'admin','admin','prueba@gmail.com',1,1,1),(17,'elias','ramirewa','12345678','3644555503',1,'124','1234','afmalf@gmaiol.com',1,0,0),(19,'Matias','Alex','1234093482','1159478201',2,'admin','adminn','elias@gmail.com',1,1,0);
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

        SET mensaje = 'CategorÃ­a editada correctamente';
    ELSE
        SET p_resultado = 0;
        SET mensaje = 'Error: No se puede repetir la descripciÃ³n de una categorÃ­a';
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
    IN p_razonsocial VARCHAR(100),
    IN p_condicion_iva VARCHAR(50),
    IN p_tipo_cliente VARCHAR(50),
    
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
        razonsocial = p_razonsocial,
        condicion_iva = p_condicion_iva,
        tipo_cliente = p_tipo_cliente
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
    IN p_preciocompra DECIMAL(10, 2),
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
    
    -- 1. Verificar si existe otro producto con el MISMO NOMBRE y DIFERENTE ID (Esto ya estaba bien)
    SELECT COUNT(*) INTO existe_nombre
    FROM producto 
    WHERE id != p_id AND nombre = p_nombre;

    -- 2. Verificar si existe otro producto con el MISMO CÃ“DIGO y DIFERENTE ID.
    --    PERO solo si el cÃ³digo NO es un cÃ³digo autogenerado 'INT-%'.
    SELECT COUNT(*) INTO existe_codigo
    FROM producto 
    WHERE id != p_id 
      AND codigo = p_codigo
      AND p_codigo NOT LIKE 'INT-%'; -- â¬…ï¸ CORRECCIÃ“N APLICADA AQUÃ.

    -- 3. Proceder a la ediciÃ³n si no hay duplicados.
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

        SET mensaje = 'El producto se editÃ³ con Ã©xito';
        SET resultado = 1;
    ELSE
        SET resultado = 0;
        IF existe_nombre > 0 THEN
            SET mensaje = 'Error: ya existe otro producto con ese nombre';
        ELSEIF existe_codigo > 0 THEN
            SET mensaje = 'Error: ya existe otro producto con ese cÃ³digo';
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
    
    -- â¬‡ï¸ NUEVOS PARÃMETROS AGREGADOS â¬‡ï¸
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
            
            escliente = p_escliente,     -- Nueva actualizaciÃ³n
            esproveedor = p_esproveedor  -- Nueva actualizaciÃ³n

        WHERE idusuario = p_idusuario;

        SET respuesta = 1;
        SET mensaje = 'Usuario editado correctamente';
    ELSE
		SET mensaje = 'Error: El documento ya estÃ¡ registrado por otro usuario.'; 
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
        SET mensaje = 'CategorÃ­a eliminada correctamente';
    
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
        SET mensaje = 'CategorÃ­a creada correctamente';
    ELSE
        SET mensaje = 'Error: Ya existe esa categorÃ­a';
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
    
    -- â¬‡ï¸ NUEVOS PARÃMETROS AGREGADOS â¬‡ï¸
    IN p_cuit VARCHAR(15), 
    IN p_razonsocial VARCHAR(100),
    IN p_condicion_iva VARCHAR(50), 
    IN p_tipo_cliente VARCHAR(50),
    
    OUT idclienteresultado INT,
    OUT mensaje VARCHAR(250)
)
BEGIN
    
    SET idclienteresultado = 0;
    SET mensaje = '';

    IF NOT EXISTS (SELECT 1 FROM cliente WHERE dni = p_documento) THEN
        INSERT INTO cliente (
            nombre, apellido, dni, telefono, domicilio, email, estado,
            -- â¬‡ï¸ NUEVAS COLUMNAS â¬‡ï¸
            cuit, razonsocial, condicion_iva, tipo_cliente 
        )
        VALUES ( 
            p_nombre, p_apellido, p_documento, p_telefono, p_domicilio, p_email, p_estado,
            -- â¬‡ï¸ NUEVOS VALORES â¬‡ï¸
            p_cuit, p_razonsocial, p_condicion_iva, p_tipo_cliente
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
      SET mensaje = 'El detalle estÃ¡ vacÃ­o';
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
    IN p_nombre VARCHAR(60),
    IN p_stock INT,
    IN p_precioventa decimal(10, 2), -- Corregido float - decimal
    IN p_categoria_id INT,
    IN p_preciocompra decimal(10, 2), -- Corregido float - decimal
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
    SET resultado = 0; -- Inicializamos el resultado en 0 (Error)

    -- 1. Verificar si ya existe otro producto con el MISMO NOMBRE
    SELECT COUNT(1) INTO existe_nombre
    FROM producto 
    WHERE nombre = p_nombre;

    -- 2. Verificar si ya existe otro producto con el MISMO CÃ“DIGO
    --    PERO solo si el cÃ³digo NO es un cÃ³digo interno ('INT-%')
    IF p_codigo NOT LIKE 'INT-%' THEN
        SELECT COUNT(1) INTO existe_codigo
        FROM producto 
        WHERE codigo = p_codigo;
    END IF;

    -- 3. Insertar solo si NO hay conflictos
    IF existe_nombre = 0 AND existe_codigo = 0 THEN
        INSERT INTO producto(nombre, stock, precioventa, categoria_id, preciocompra, descripcion, estado, codigo)
        VALUES (p_nombre, p_stock, p_precioventa, p_categoria_id, p_preciocompra, p_descripcion, p_estado, p_codigo);
        
        SET resultado = LAST_INSERT_ID();
        SET mensaje = 'El producto se registrÃ³ con Ã©xito';
    ELSE
        -- Devolver el error especÃ­fico
        IF existe_nombre > 0 THEN
            SET mensaje = 'Error: Ya existe un producto registrado con ese nombre.';
        ELSEIF existe_codigo > 0 THEN
            SET mensaje = 'Error: Ya existe un producto registrado con ese cÃ³digo de barra.';
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
        SET mensaje = 'El proveedor fue registrado con Ã©xito';
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
    
    -- â¬‡ï¸ NUEVOS PARÃMETROS AGREGADOS â¬‡ï¸
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

-- Dump completed on 2025-10-11 12:50:18
