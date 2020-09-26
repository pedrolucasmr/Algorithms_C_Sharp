DROP DATABASE IF EXISTS algorithms;
CREATE DATABASE algorithms;
USE algorithms;
CREATE TABLE runs(aName VARCHAR(255), timeNotation VARCHAR(255), spaceNotation VARCHAR(255),runStart TIME,runEnd TIME,totalTime TIME,entries INT);

DELIMITER // 
CREATE PROCEDURE insertNewRun(IN iAName VARCHAR(255),IN iTimeNotation varchar(255),IN iSpaceNotation VARCHAR(255),IN iRunStart TIME,IN iRunEnd TIME,IN iTotalTime TIME,IN iEntries INT)
BEGIN
INSERT INTO runs(aName,timeNotation,spaceNotation,runStart,runEnd,totalTime,entries) VALUES(iAName,iTimeNotation,iSpaceNotation,iRunStart,iRunEnd,iTotalTime,iEntries);
END//

CREATE PROCEDURE GetAllRuns(OUT oAName VARCHAR(255),OUT oTimeNotation varchar(255),OUT oSpaceNotation VARCHAR(255),OUT oRunStart TIMESTAMP,OUT oRunEnd TIMESTAMP,OUT oTotalTime TIMESTAMP,OUT oEntries INT)
BEGIN
SELECT * FROM runs;
END//

CREATE PROCEDURE GetSpecificRuns(IN iType VARCHAR(255),OUT oAName VARCHAR(255),OUT oTimeNotation varchar(255),OUT oSpaceNotation VARCHAR(255),OUT oRunStart TIMESTAMP,OUT oRunEnd TIMESTAMP,OUT oTotalTime TIMESTAMP,OUT oEntries INT)
BEGIN
SELECT * FROM runs WHERE aName=iType;
END//
	