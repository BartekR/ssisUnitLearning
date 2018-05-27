<Query Kind="Statements" />

//=================================================================================
// An example of serialising DataTable to XML for ssisUnit: (Linqpad, C# statement)
//=================================================================================

DataTable table = new DataTable("Results");

/*
Name			varchar(50)
Login			char(12)
IsActive		bit
SourceId		int
SourceSystemId	tinyint
IsDeleted		bit
*/

DataColumn name = new DataColumn("Name", typeof(System.String));
name.MaxLength = 50;
table.Columns.Add(name);

DataColumn login = new DataColumn("Login", typeof(System.String));
login.MaxLength = 12;
table.Columns.Add(login);

table.Columns.Add("IsActive", typeof(System.Boolean));
table.Columns.Add("Id", typeof(System.Int32));
table.Columns.Add("SourceSystemId", typeof(System.Byte));
table.Columns.Add("IsDeleted", typeof(System.Boolean));


//'Name 1', 'Login 1', 1, 1, 2, 0),
//'Name 2', 'Login 2', 1, 2, 2, 0),
//'Name 3', 'Login 3', 0, 3, 2, 0)
table.Rows.Add(new object[] { "Name 1", "Login 1     ", 1, 1, 2, 0 });
table.Rows.Add(new object[] { "Name 2", "Login 2     ", 1, 2, 2, 0 });
table.Rows.Add(new object[] { "Name 3", "Login 3     ", 0, 3, 2, 0 });

table.AcceptChanges();

System.IO.StringWriter writer = new System.IO.StringWriter();
table.WriteXml(writer, XmlWriteMode.WriteSchema, true);
//table.WriteXml(writer, XmlWriteMode.WriteSchema);
//table.WriteXml(writer);

System.Diagnostics.Debug.Print(writer.ToString());