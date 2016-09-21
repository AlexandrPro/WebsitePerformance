-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema website_performance
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema website_performance
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `website_performance` DEFAULT CHARACTER SET utf8 ;
USE `website_performance` ;

-- -----------------------------------------------------
-- Table `website_performance`.`website`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `website_performance`.`website` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `url` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `website_performance`.`links`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `website_performance`.`links` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `url` VARCHAR(50) NOT NULL,
  `site_id` INT(11) NOT NULL,
  `test_count` INT(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  INDEX `fk_links_to_websites_idx` (`site_id` ASC),
  CONSTRAINT `fk_links_to_websites`
    FOREIGN KEY (`site_id`)
    REFERENCES `website_performance`.`website` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `website_performance`.`test`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `website_performance`.`test` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `link_id` INT(11) NOT NULL,
  `number` INT(11) NOT NULL,
  `time` FLOAT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_test_to_link_idx` (`link_id` ASC),
  CONSTRAINT `fk_test_to_link`
    FOREIGN KEY (`link_id`)
    REFERENCES `website_performance`.`links` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
