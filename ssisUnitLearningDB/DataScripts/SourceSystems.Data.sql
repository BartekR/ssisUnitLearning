WITH SourceSystems AS (
SELECT *
FROM (VALUES
	(1, 'Flat files from the \\network\share'),
	(2, 'SQL Server 2017')
) x (Id, Name)
)
MERGE INTO meta.SourceSystems tgt
USING SourceSystems src

	ON tgt.Id = src.Id

WHEN MATCHED
AND EXISTS (SELECT tgt.* EXCEPT SELECT src.*)
THEN UPDATE SET
	tgt.Name	= src.Name

WHEN NOT MATCHED BY TARGET
THEN INSERT (
	Id,
	Name
) VALUES (
	src.Id,
	src.Name
)
;