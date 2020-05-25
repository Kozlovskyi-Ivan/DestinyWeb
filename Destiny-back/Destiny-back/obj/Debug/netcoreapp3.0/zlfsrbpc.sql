  IF EXISTS(SELECT 1 FROM information_schema.tables 
  WHERE table_name = '
'__EFMigrationsHistory'' AND table_schema = DATABASE()) 
BEGIN
CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

END;

CREATE TABLE `Milestones` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Hash` bigint NOT NULL,
    `name` text NULL,
    `description` text NULL,
    `QuestItemHash` bigint NOT NULL,
    `VendorHash` bigint NOT NULL,
    `ImageUrl` text NULL,
    `StartDate` datetime NOT NULL,
    `EndDate` datetime NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Activites` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `MilestoneId` int NULL,
    `ActivityHash` bigint NOT NULL,
    `name` text NULL,
    `description` text NULL,
    `icon` text NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Activites_Milestones_MilestoneId` FOREIGN KEY (`MilestoneId`) REFERENCES `Milestones` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Modifiers` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `ActivityId` int NULL,
    `ModifierHash` bigint NOT NULL,
    `name` text NULL,
    `description` text NULL,
    `icon` text NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Modifiers_Activites_ActivityId` FOREIGN KEY (`ActivityId`) REFERENCES `Activites` (`Id`) ON DELETE CASCADE
);

CREATE INDEX `IX_Activites_MilestoneId` ON `Activites` (`MilestoneId`);

CREATE INDEX `IX_Modifiers_ActivityId` ON `Modifiers` (`ActivityId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20200525032029_asd', '3.1.4');

