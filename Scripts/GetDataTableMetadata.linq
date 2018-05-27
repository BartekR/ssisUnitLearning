<Query Kind="Statements" />

// use this code in Linqpad (http://linqpad.net) using C# Statement(s)
string factoryInvariantName = "System.Data.OleDb";
System.Data.DataTable expectedDataTable;
System.Data.DataTable metadata = new System.Data.DataTable("metadata");

metadata.Columns.Add("ColumnName", typeof(System.String));
metadata.Columns.Add("Value", typeof(System.String));
metadata.Columns.Add("Type", typeof(System.String));
metadata.Columns.Add("Length", typeof(System.Int32));
metadata.Columns.Add("MaxLength", typeof(System.Int32));


var dbFactory = System.Data.Common.DbProviderFactories.GetFactory(factoryInvariantName);

System.Data.Common.DbConnection conn = dbFactory.CreateConnection();
conn.ConnectionString = "Data Source=127.0.0.1;Initial Catalog=ssisUnitLearningDB;Provider=SQLNCLI11.1;User ID=sa;Password=123qwe!@#;Auto Translate=False;";

System.Data.Common.DbCommand dbCommand = dbFactory.CreateCommand();

dbCommand.Connection = conn;
dbCommand.CommandText = "SELECT TOP 1 * FROM dbo.Users;";

dbCommand.Connection.Open();

using (IDataReader expectedReader = dbCommand.ExecuteReader())
{
    var ds = new DataSet();

    ds.Load(expectedReader, LoadOption.OverwriteChanges, new[] { "Results" });
    expectedDataTable = ds.Tables[0];
}

expectedDataTable.Dump();

//System.Diagnostics.Debug.Print(expectedDataTable.Rows.Count.ToString());

foreach (DataRow row in expectedDataTable.Rows)
{
	for(int x = 0; x < expectedDataTable.Columns.Count; x++)
	{
		metadata.Rows.Add(new object[] {
			expectedDataTable.Columns[x].ColumnName.ToString(), 
			row[x].ToString(),
			row[x].GetType().ToString(),
			row[x].GetType().ToString() == "System.String" ? row[x].ToString().Length : -1,
			expectedDataTable.Columns[x].MaxLength
		});
		metadata.AcceptChanges();
	}
}

metadata.Dump();

//System.Diagnostics.Debug.Print(expectedDataTable.ToString());