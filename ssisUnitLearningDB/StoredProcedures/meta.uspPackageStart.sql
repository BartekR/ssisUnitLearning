CREATE PROCEDURE meta.uspPackageStart
	@packageName VARCHAR(255)
AS

DECLARE
	@packageId	SMALLINT
;

SELECT
	@packageId = p.Id
FROM meta.Packages p
WHERE
	1 = 1
	AND p.Name = @packageName
;

INSERT INTO meta.Audit (PackageId)
VALUES (@packageId)
;

SELECT AuditId = SCOPE_IDENTITY()
;