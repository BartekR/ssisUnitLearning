USE ssisUnitLearningDB;
GO

DROP TABLE IF EXISTS dbo.TruncateSample;
GO

CREATE TABLE dbo.TruncateSample
(
	Id INT NOT NULL PRIMARY KEY, 
    Filler CHAR(20) NOT NULL
)
;


INSERT INTO dbo.TruncateSample (Id, Filler)
VALUES
	(1, REPLICATE('A', 20)),
	(2, REPLICATE('B', 20)),
	(3, REPLICATE('C', 20)),
	(4, REPLICATE('D', 20)),
	(5, REPLICATE('E', 20))
;