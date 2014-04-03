SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `find_bus_schema` DEFAULT CHARACTER SET utf8 ;
USE `find_bus_schema` ;

-- -----------------------------------------------------
-- Table `find_bus_schema`.`itinerarioview`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `find_bus_schema`.`itinerarioview` (
  `Descricao` VARCHAR(20) NULL DEFAULT NULL,
  `HoraChegada` VARCHAR(6) NULL DEFAULT NULL,
  `HoraSaida` VARCHAR(6) NULL DEFAULT NULL,
  `SegundaFeira` BINARY(1) NULL DEFAULT NULL,
  `TercaFeira` BINARY(1) NULL DEFAULT NULL,
  `QuartaFeira` BINARY(1) NULL DEFAULT NULL,
  `QuintaFeira` BINARY(1) NULL DEFAULT NULL,
  `SextaFeira` BINARY(1) NULL DEFAULT NULL,
  `Sabado` BINARY(1) NULL DEFAULT NULL,
  `Domingo` BINARY(1) NULL DEFAULT NULL)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `find_bus_schema`.`tblbairro`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `find_bus_schema`.`tblbairro` (
  `BairroId` INT(11) NOT NULL AUTO_INCREMENT,
  `Descricao` VARCHAR(50) NOT NULL,
  `DataInclusaoRegistro` DATETIME NOT NULL,
  PRIMARY KEY (`BairroId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `find_bus_schema`.`tblrua`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `find_bus_schema`.`tblrua` (
  `RuaId` INT(11) NOT NULL AUTO_INCREMENT,
  `Descricao` VARCHAR(50) NOT NULL,
  `DataInclusaoRegistro` DATETIME NOT NULL,
  PRIMARY KEY (`RuaId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `find_bus_schema`.`tblbairrorua`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `find_bus_schema`.`tblbairrorua` (
  `BairroRuaId` INT(11) NOT NULL AUTO_INCREMENT,
  `BairroId` INT(11) NOT NULL,
  `RuaId` INT(11) NOT NULL,
  PRIMARY KEY (`BairroRuaId`, `BairroId`, `RuaId`),
  INDEX `FK_tblBairroRua` (`BairroId` ASC),
  INDEX `FK_tblBairroRua2` (`RuaId` ASC),
  CONSTRAINT `FK_tblBairroRua`
    FOREIGN KEY (`BairroId`)
    REFERENCES `find_bus_schema`.`tblbairro` (`BairroId`),
  CONSTRAINT `FK_tblBairroRua2`
    FOREIGN KEY (`RuaId`)
    REFERENCES `find_bus_schema`.`tblrua` (`RuaId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `find_bus_schema`.`tblcidade`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `find_bus_schema`.`tblcidade` (
  `CidadeId` INT(11) NOT NULL AUTO_INCREMENT,
  `Descricao` VARCHAR(50) NOT NULL,
  `Uf` VARCHAR(50) NOT NULL,
  `DataInclusaoRegistro` DATETIME NOT NULL,
  PRIMARY KEY (`CidadeId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `find_bus_schema`.`tblcidadebairro`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `find_bus_schema`.`tblcidadebairro` (
  `CidadeBairroId` INT(11) NOT NULL AUTO_INCREMENT,
  `CidadeId` INT(11) NOT NULL,
  `BairroId` INT(11) NOT NULL,
  PRIMARY KEY (`CidadeBairroId`, `CidadeId`, `BairroId`),
  INDEX `FK_tblCidadeBairro` (`CidadeId` ASC),
  INDEX `FK_tblCidadeBairro2` (`BairroId` ASC),
  CONSTRAINT `FK_tblCidadeBairro`
    FOREIGN KEY (`CidadeId`)
    REFERENCES `find_bus_schema`.`tblcidade` (`CidadeId`),
  CONSTRAINT `FK_tblCidadeBairro2`
    FOREIGN KEY (`BairroId`)
    REFERENCES `find_bus_schema`.`tblbairro` (`BairroId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `find_bus_schema`.`tblrota`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `find_bus_schema`.`tblrota` (
  `RotaId` INT(11) NOT NULL AUTO_INCREMENT,
  `Descricao` VARCHAR(50) NOT NULL,
  `DataInclusaoRegistro` DATETIME NOT NULL,
  PRIMARY KEY (`RotaId`))
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `find_bus_schema`.`tblitinerario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `find_bus_schema`.`tblitinerario` (
  `ItinerarioId` INT(11) NOT NULL AUTO_INCREMENT,
  `RotaId` INT(11) NOT NULL,
  `DiaSemana` VARCHAR(20) NOT NULL,
  `HoraSaida` VARCHAR(6) NOT NULL,
  `HoraChegada` VARCHAR(6) NOT NULL,
  PRIMARY KEY (`ItinerarioId`),
  INDEX `FK_rotaitinerario` (`RotaId` ASC),
  CONSTRAINT `FK_rotaitinerario`
    FOREIGN KEY (`RotaId`)
    REFERENCES `find_bus_schema`.`tblrota` (`RotaId`))
ENGINE = InnoDB
AUTO_INCREMENT = 8
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `find_bus_schema`.`tblusuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `find_bus_schema`.`tblusuario` (
  `UsuarioId` INT(11) NOT NULL AUTO_INCREMENT,
  `NomeUsuario` VARCHAR(50) NOT NULL,
  `UsuarioSenha` VARCHAR(32) NOT NULL,
  `DataInclusaoRegistro` DATETIME NOT NULL,
  `NiveldoAcesso` INT(11) NOT NULL,
  PRIMARY KEY (`UsuarioId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `find_bus_schema`.`tbllogin`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `find_bus_schema`.`tbllogin` (
  `LoginId` INT(11) NOT NULL AUTO_INCREMENT,
  `UsuarioId` INT(11) NOT NULL,
  `UsuarioSenha` VARCHAR(32) NOT NULL,
  PRIMARY KEY (`LoginId`),
  INDEX `FK_tblLogin` (`UsuarioId` ASC),
  CONSTRAINT `FK_tblLogin`
    FOREIGN KEY (`UsuarioId`)
    REFERENCES `find_bus_schema`.`tblusuario` (`UsuarioId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `find_bus_schema`.`tblponto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `find_bus_schema`.`tblponto` (
  `PontoId` INT(11) NOT NULL AUTO_INCREMENT,
  `Latitude` VARCHAR(50) NOT NULL,
  `Longitude` VARCHAR(50) NOT NULL,
  `PontoParada` TINYINT(1) NOT NULL,
  `DataInclusaoRegistro` DATETIME NOT NULL,
  PRIMARY KEY (`PontoId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `find_bus_schema`.`tblrotaponto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `find_bus_schema`.`tblrotaponto` (
  `RotaPontoId` INT(11) NOT NULL AUTO_INCREMENT,
  `RotaId` INT(11) NOT NULL,
  `PontoId` INT(11) NOT NULL,
  `OrdemPonto` INT(11) NOT NULL,
  `Quilometragem` DECIMAL(10,0) NOT NULL,
  PRIMARY KEY (`RotaPontoId`, `RotaId`, `PontoId`),
  INDEX `FK_tblRotaPonto` (`RotaId` ASC),
  INDEX `FK_tblRotaPonto2` (`PontoId` ASC),
  CONSTRAINT `FK_tblRotaPonto`
    FOREIGN KEY (`RotaId`)
    REFERENCES `find_bus_schema`.`tblrota` (`RotaId`),
  CONSTRAINT `FK_tblRotaPonto2`
    FOREIGN KEY (`PontoId`)
    REFERENCES `find_bus_schema`.`tblponto` (`PontoId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `find_bus_schema`.`tblruaponto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `find_bus_schema`.`tblruaponto` (
  `RuaPontoId` INT(11) NOT NULL AUTO_INCREMENT,
  `RuaId` INT(11) NOT NULL,
  `PontoId` INT(11) NOT NULL,
  PRIMARY KEY (`RuaPontoId`, `RuaId`, `PontoId`),
  INDEX `FK_tblRuaPonto` (`RuaId` ASC),
  INDEX `FK_tblRuaPonto2` (`PontoId` ASC),
  CONSTRAINT `FK_tblRuaPonto`
    FOREIGN KEY (`RuaId`)
    REFERENCES `find_bus_schema`.`tblrua` (`RuaId`),
  CONSTRAINT `FK_tblRuaPonto2`
    FOREIGN KEY (`PontoId`)
    REFERENCES `find_bus_schema`.`tblponto` (`PontoId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

USE `find_bus_schema` ;

-- -----------------------------------------------------
-- procedure USP_SEL_Itinerario
-- -----------------------------------------------------

DELIMITER $$
USE `find_bus_schema`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `USP_SEL_Itinerario`(CodigoRota int)
    COMMENT 'Author: Humberto/Eduardo  Created in: 2014/03/19  Reason: Retornar um itinerario de uma rota determinada pelo código rota '
BEGIN
	select itinerario.RotaId,rota.descricao, HoraSaida, HoraChegada,
	case when DiaSemana = 'Segunda-Feira' then 'x' else '-' end as 'Segunda',
	case when DiaSemana = 'Terca-Feira' then 'x' else '-' end as 'Terca',
	case when DiaSemana = 'Quarta-Feira' then 'x' else '-' end as 'Quarta',
	case when DiaSemana = 'Quinta-Feira' then 'x' else '-' end as 'Quinta',
	case when DiaSemana = 'Sexta-Feira' then 'x' else '-' end as 'Sexta',
	case when DiaSemana = 'Sabado' then 'x' else '-' end as 'Sabado',
	case when DiaSemana = 'Domingo' then 'x' else '-' end as 'Domingo'
	from tblitinerario itinerario
	inner join tblrota rota on rota.rotaid =  itinerario.rotaid
	where rota.rotaid = case when CodigoRota = 0 then rota.rotaid else CodigoRota end
	group by itinerario.RotaId,rota.descricao, HoraSaida, HoraChegada
	order by HoraSaida, RotaId asc ;
END$$

DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
