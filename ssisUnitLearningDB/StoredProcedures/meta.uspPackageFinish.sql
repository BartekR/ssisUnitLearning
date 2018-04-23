CREATE PROCEDURE meta.uspPackageFinish
	@AuditId int = 0
AS

UPDATE meta.Audit SET
	DtFinished = SYSDATETIME()
WHERE
	1 = 1
	AND Id = @AuditId
;

RETURN 0
