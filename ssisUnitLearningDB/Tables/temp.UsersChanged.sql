CREATE TABLE temp.UsersChanged
(
	Id INT,
	Name VARCHAR(50) NULL,
	Login CHAR(12) NULL,
	IsActive BIT NOT NULL,
	SourceSystemId TINYINT NOT NULL
)
