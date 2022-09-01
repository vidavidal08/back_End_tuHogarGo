-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema inmobi_casas
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `inmobi_casas` ;

-- -----------------------------------------------------
-- Schema inmobi_casas
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `inmobi_casas` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `inmobi_casas` ;

-- -----------------------------------------------------
-- Table `inmobi_casas`.`planes`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `inmobi_casas`.`planes` ;

CREATE TABLE IF NOT EXISTS `inmobi_casas`.`planes` (
  `idPlan` INT NOT NULL AUTO_INCREMENT,
  `descripcion` VARCHAR(45) CHARACTER SET 'utf8mb3' NULL DEFAULT NULL,
  `dias_duracion` INT NULL DEFAULT NULL,
  `precio` VARCHAR(250) CHARACTER SET 'utf8mb3' NULL DEFAULT NULL,
  PRIMARY KEY (`idPlan`))
ENGINE = InnoDB
AUTO_INCREMENT = 4;


-- -----------------------------------------------------
-- Table `inmobi_casas`.`roles`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `inmobi_casas`.`roles` ;

CREATE TABLE IF NOT EXISTS `inmobi_casas`.`roles` (
  `idRole` INT NOT NULL AUTO_INCREMENT,
  `Descripcion` VARCHAR(250) CHARACTER SET 'utf8mb3' NULL DEFAULT NULL,
  PRIMARY KEY (`idRole`))
ENGINE = InnoDB
AUTO_INCREMENT = 4;


-- -----------------------------------------------------
-- Table `inmobi_casas`.`usuarios`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `inmobi_casas`.`usuarios` ;

CREATE TABLE IF NOT EXISTS `inmobi_casas`.`usuarios` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `RolId` INT NOT NULL,
  `PlanId` INT NOT NULL,
  `Nombre` VARCHAR(250) CHARACTER SET 'utf8mb3' NOT NULL,
  `Apellidos` VARCHAR(250) CHARACTER SET 'utf8mb3' NOT NULL,
  `FechaNacimiento` DATE NOT NULL,
  `PaisId` INT NOT NULL,
  `EstadoId` INT NOT NULL,
  `FechaAlta` DATETIME NOT NULL,
  `Email` VARCHAR(450) COLLATE 'utf8mb3_unicode_ci' NOT NULL,
  `Pass` VARCHAR(1000) COLLATE 'utf8mb3_unicode_ci' NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `FK_ROL` (`RolId` ASC) VISIBLE,
  INDEX `FK_PLAN` (`PlanId` ASC) VISIBLE,
  CONSTRAINT `FK_PLAN`
    FOREIGN KEY (`PlanId`)
    REFERENCES `inmobi_casas`.`planes` (`idPlan`),
  CONSTRAINT `FK_ROL`
    FOREIGN KEY (`RolId`)
    REFERENCES `inmobi_casas`.`roles` (`idRole`)
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 2;


-- -----------------------------------------------------
-- Table `inmobi_casas`.`contratos`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `inmobi_casas`.`contratos` ;

CREATE TABLE IF NOT EXISTS `inmobi_casas`.`contratos` (
  `idContrato` INT NOT NULL AUTO_INCREMENT,
  `idUsuario` INT NULL DEFAULT NULL,
  `fecha_compra` DATETIME NULL DEFAULT NULL,
  `fecha_expiracion` INT NULL DEFAULT NULL,
  `status` TINYINT NULL DEFAULT NULL,
  PRIMARY KEY (`idContrato`),
  INDEX `FK_USUARIO` (`idUsuario` ASC) VISIBLE,
  CONSTRAINT `FK_USUARIO`
    FOREIGN KEY (`idUsuario`)
    REFERENCES `inmobi_casas`.`usuarios` (`Id`)
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `inmobi_casas`.`inmuebles`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `inmobi_casas`.`inmuebles` ;

CREATE TABLE IF NOT EXISTS `inmobi_casas`.`inmuebles` (
  `idInmueble` INT NOT NULL AUTO_INCREMENT,
  `idDescripcion` VARCHAR(250) CHARACTER SET 'utf8mb3' NULL DEFAULT NULL,
  PRIMARY KEY (`idInmueble`))
ENGINE = InnoDB
AUTO_INCREMENT = 8;


-- -----------------------------------------------------
-- Table `inmobi_casas`.`publicaciones`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `inmobi_casas`.`publicaciones` ;

CREATE TABLE IF NOT EXISTS `inmobi_casas`.`publicaciones` (
  `idPublicaciones` INT NOT NULL AUTO_INCREMENT,
  `idUsuario` INT NULL DEFAULT NULL,
  `titulo` VARCHAR(255) CHARACTER SET 'utf8mb3' NULL DEFAULT NULL,
  `descripcion` VARCHAR(250) CHARACTER SET 'utf8mb3' NULL DEFAULT NULL,
  `idInmueble` INT NULL DEFAULT NULL,
  `precio` DOUBLE NULL DEFAULT NULL,
  `recamaras` INT NULL DEFAULT NULL,
  `banos` INT NULL DEFAULT NULL,
  `mediosBanos` INT NULL DEFAULT NULL,
  `garage` INT NULL DEFAULT NULL,
  `superficieTerreno` VARCHAR(200) CHARACTER SET 'utf8mb3' NULL DEFAULT NULL,
  `superficieConstruida` VARCHAR(200) CHARACTER SET 'utf8mb3' NULL DEFAULT NULL,
  `jardin` VARCHAR(200) CHARACTER SET 'utf8mb3' NULL DEFAULT NULL,
  PRIMARY KEY (`idPublicaciones`),
  INDEX `FK_INMUEBLE` (`idInmueble` ASC) VISIBLE,
  INDEX `FK_IDUSUARIO` (`idUsuario` ASC) VISIBLE,
  CONSTRAINT `FK_IDUSUARIO`
    FOREIGN KEY (`idUsuario`)
    REFERENCES `inmobi_casas`.`usuarios` (`Id`)
    ON UPDATE CASCADE,
  CONSTRAINT `FK_INMUEBLE`
    FOREIGN KEY (`idInmueble`)
    REFERENCES `inmobi_casas`.`inmuebles` (`idInmueble`)
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `inmobi_casas`.`templates_correos`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `inmobi_casas`.`templates_correos` ;

CREATE TABLE IF NOT EXISTS `inmobi_casas`.`templates_correos` (
  `idTemplates_Correos` INT NOT NULL AUTO_INCREMENT,
  `descripcion` VARCHAR(255) CHARACTER SET 'utf8mb3' NULL DEFAULT NULL,
  `HTML_string` VARCHAR(255) CHARACTER SET 'utf8mb3' NULL DEFAULT NULL,
  PRIMARY KEY (`idTemplates_Correos`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
