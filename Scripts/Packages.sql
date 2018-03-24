USE ssisUnitLearningDB;
GO

WITH Packages AS (
SELECT *
FROM (VALUES
	(1, '10_ProjectCM', 2)
) x (Id, Name, SourceSystemId)
)
MERGE INTO meta.Packages tgt
USING Packages src

	ON tgt.Id = src.Id

WHEN MATCHED
AND EXISTS (SELECT tgt.* EXCEPT SELECT src.*)
THEN UPDATE SET
	tgt.Name			= src.Name,
	tgt.SourceSystemId	= src.SourceSystemId

WHEN NOT MATCHED BY TARGET
THEN INSERT (
	Id,
	Name,
	SourceSystemId
) VALUES (
	src.Id,
	src.Name,
	src.SourceSystemId
)
;