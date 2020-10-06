DROP DATABASE algorithms;
CREATE DATABASE algorithms;
USE algorithms;
CREATE TABLE runs(aName VARCHAR(255), timeNotation VARCHAR(255), spaceNotation VARCHAR(255),runStart TIME,runEnd TIME,totalTime INT,entries INT);

DELIMITER // 
CREATE PROCEDURE insertNewRun(IN iAName VARCHAR(255),IN iTimeNotation varchar(255),IN iSpaceNotation VARCHAR(255),IN iRunStart TIME,IN iRunEnd TIME,IN iTotalTime INT,IN iEntries INT)
BEGIN
INSERT INTO runs(aName,timeNotation,spaceNotation,runStart,runEnd,totalTime,entries) VALUES(iAName,iTimeNotation,iSpaceNotation,iRunStart,iRunEnd,iTotalTime,iEntries);
END//

CREATE PROCEDURE GetAllRuns()
BEGIN
SELECT * FROM runs ORDER BY entries ASC;
END//

CREATE PROCEDURE GetSpecificRuns(IN iType VARCHAR(255))
BEGIN
SELECT * FROM runs WHERE aName=iType ORDER BY entries ASC;
END//
SELECT * FROM runs;

CREATE PROCEDURE GetRunResults(IN iType VARCHAR(255),out oTotalTime INT,out oEntries INT)
BEGIN
SELECT totalTime,entires INTO oTotalTime,oEntries FROM runs WHERE aName=iType ORDER BY entries ASC;
END//
drop procedure GetRunResults;

CREATE PROCEDURE GetAllRunsResults()
BEGIN
SELECT aName,totalTime,entries FROM runs ORDER BY entries ASC;
END//
SELECT * FROM runs;
