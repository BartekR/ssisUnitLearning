CREATE TABLE meta.Packages
(
	Id SMALLINT IDENTITY(1, 1) NOT NULL CONSTRAINT PK_meta_Packages PRIMARY KEY CLUSTERED, 
    Name VARCHAR(255) NOT NULL, 
    SourceSystemId TINYINT NOT NULL, 

    CONSTRAINT FK_Packages_2_SourceSystems
		FOREIGN KEY (SourceSystemId) REFERENCES meta.SourceSystems(Id)
)
