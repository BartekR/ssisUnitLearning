WITH Packages AS (
SELECT *
FROM (VALUES
	('10_ProjectCM', 2),
	('15_Users_Dataset', 2),
	('20_DataFlow', 2)
) x (Name, SourceSystemId)
)
MERGE INTO meta.Packages tgt
USING Packages src

	ON tgt.Name = src.Name

WHEN MATCHED
AND EXISTS (SELECT tgt.Name, tgt.SourceSystemId EXCEPT SELECT src.Name, src.SourceSystemId)
THEN UPDATE SET
	tgt.SourceSystemId	= src.SourceSystemId

WHEN NOT MATCHED BY TARGET
THEN INSERT (
	Name,
	SourceSystemId
) VALUES (
	src.Name,
	src.SourceSystemId
)
;