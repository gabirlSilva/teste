using Oracle.ManagedDataAccess.Client;
using System.Text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System.Windows.Forms;

namespace Bdsh.Sync.Tools
{
    public enum DatabaseType
    {
        SQLServer,
        Oracle
    };

    public enum DatabaseCompare
    {
        Tables,
        Constraints
    };

    public enum DatabaseStructureCompareResult
    {
        CSVReadError,
        CSVComnpareError,
        WriteFileError,
        Success
    }

    public enum DataBaseStructureResult
    {
        BadConnectionString,
        ConnectionError,
        ExecutionError,
        WriteFileError,
        Success
    };

    public class DatabaseCSVInfo
    {
        public string Directory { get; set; }
        public string Sufix { get; set; }
    }

    public class DatabaseLogicalStructureCompareConfig
    {
        [YamlMember(Alias = "db1", ApplyNamingConventions = false)]
        public DatabaseCSVInfo DB1 { get; set; }

        [YamlMember(Alias = "db2", ApplyNamingConventions = false)]
        public DatabaseCSVInfo DB2 { get; set; }
        public DatabaseCSVInfo Output { get; set; }
        public Comparion[] Comparisons { get; set; }

        public class Comparion
        {
            public string Table { get; set; }

            [YamlMember(Alias = "id_columns", ApplyNamingConventions = false)]
            public string[] IdColumns { get; set; }

            [YamlMember(Alias = "diff_columns", ApplyNamingConventions = false)]
            public string[] DiffColumns { get; set; }
        }
    }

    public class Database
    {
        public class PhysicalStructure
        {
            #region Collect

            public static DataBaseStructureResult GenerateStructureCSV(DatabaseType dbType, string connectionString, string csvPath, string csvName = null)
            {
                try
                {
                    switch (dbType)
                    {
                        case DatabaseType.SQLServer:
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                string columnssQuery = "SELECT table_name, ordinal_position, column_name, data_type, numeric_precision, numeric_scale, character_maximum_length, datetime_precision, is_nullable, column_default FROM information_schema.columns ORDER BY table_name , ordinal_position;";
                                string constraintQuery = "SELECT KCU1.table_name, KCU1.constraint_name, KCU1.ordinal_position, KCU1.column_name, KCU2.table_name AS \"referenced_table_name\", KCU2.constraint_name AS \"referenced_constraint_name\", KCU2.column_name AS \"referenced_column_name\", SFK.is_disabled FROM information_schema.key_column_usage KCU1 LEFT JOIN information_schema.referential_constraints RC ON KCU1.constraint_name = RC.constraint_name LEFT JOIN information_schema.key_column_usage KCU2 ON RC.unique_constraint_name = KCU2.constraint_name LEFT JOIN sys.foreign_keys SFK ON SFK.NAME = RC.constraint_name ORDER BY KCU1.table_name, KCU1.constraint_name DESC, KCU1.ordinal_position;";

                                try { connection.Open(); }
                                catch { connection.Close(); return DataBaseStructureResult.ConnectionError; }

                                SqlDataReader reader;
                                SqlCommand command = new SqlCommand(columnssQuery + constraintQuery, connection);

                                try { reader = command.ExecuteReader(); }
                                catch { connection.Close(); return DataBaseStructureResult.ExecutionError; }

                                try { WriteStructureCSV(reader, csvPath); }
                                catch { return DataBaseStructureResult.WriteFileError; }
                                finally { reader.Close(); connection.Close(); }
                            }
                            break;

                        case DatabaseType.Oracle:
                            using (OracleConnection connection = new OracleConnection(connectionString))
                            {
                                string columnsQuery = "SELECT table_name, column_id, column_name, data_type, data_precision, data_scale, data_length, nullable, low_value, high_value, data_default FROM user_tab_columns ORDER BY table_name, column_id";
                                string constraintQuery = "SELECT UCC1.table_name, UCC1.constraint_name, UCC1.position, UCC1.column_name, UCC2.table_name AS \"R_TABLE_NAME\", UCC2.constraint_name AS \"R_CONSTRAINT_NAME\", UCC2.column_name AS \"R_COLUMN_NAME\" FROM user_cons_columns UCC1 LEFT JOIN user_constraints UC ON UCC1.constraint_name = UC.constraint_name LEFT JOIN user_cons_columns UCC2 ON UC.r_constraint_name = UCC2.constraint_name ORDER BY UCC1.table_name, UCC1.constraint_name Desc, UCC1.position";

                                try { connection.Open(); }
                                catch { connection.Close(); return DataBaseStructureResult.ConnectionError; }

                                OracleDataReader columnsReader;
                                OracleDataReader constraintsReader;

                                OracleCommand columnsCommand = new OracleCommand(columnsQuery, connection);
                                OracleCommand constraintsCommand = new OracleCommand(constraintQuery, connection);

                                try
                                {
                                    columnsReader = columnsCommand.ExecuteReader();
                                    constraintsReader = constraintsCommand.ExecuteReader();
                                }
                                catch (Exception e)
                                { connection.Close(); MessageBox.Show(e.Message); return DataBaseStructureResult.ExecutionError; }

                                try { WriteStructureCSV(columnsReader, constraintsReader, csvPath); }
                                catch { return DataBaseStructureResult.WriteFileError; }
                                finally { columnsReader.Close(); constraintsReader.Close(); connection.Close(); }
                            }
                            break;
                    }
                }
                catch
                {
                    return DataBaseStructureResult.BadConnectionString;
                }

                return DataBaseStructureResult.Success;
            }

            private static void WriteStructureCSV(SqlDataReader reader, string csvPath)
            {
                StreamWriter csv = new StreamWriter(csvPath, false, Encoding.UTF8);

                csv.WriteLine("sep=;");

                csv.WriteLine("table_name;ordinal_position;column_name;data_type;numeric_precision;numeric_scale;character_maximum_length;datetime_precision;is_nullable;column_default");

                while (reader.Read())
                {
                    for (int i = 0; i < 10; i++)
                        csv.Write("\"" + reader.GetValue(i) + "\"" + (i == 9 ? "" : ";"));
                    csv.WriteLine();
                }

                csv.WriteLine("\n");

                reader.NextResult();

                csv.WriteLine("table_name;constraint_name;ordinal_position;column_name;referenced_table_name;referenced_constraint_name;referenced_column_name;is_disabled");

                while (reader.Read())
                {
                    for (int i = 0; i < 8; i++)
                        csv.Write("\"" + reader.GetValue(i) + "\"" + (i == 7 ? "" : ";"));
                    csv.WriteLine();
                }

                csv.Close();
            }


            private static void WriteStructureCSV(OracleDataReader readerColumns, OracleDataReader readerConstraints, string csvPath)
            {
                StreamWriter csv = new StreamWriter(csvPath, false, Encoding.Unicode);
                csv.WriteLine("sep=;");

                csv.WriteLine("table_name;column_id;column_name;data_type;data_precision;data_scale;data_length;nullable;low_value;high_value;data_default");

                while (readerColumns.Read())
                {
                    for (int i = 0; i < 11; i++)
                        csv.Write("\"" + readerColumns.GetValue(i) + "\"" + (i == 9 ? "" : "; "));
                    csv.WriteLine();
                }

                csv.WriteLine("\n");

                csv.WriteLine("TABLE_NAME;CONSTRAINT_NAME;POSITION;COLUMN_NAME;R_TABLE_NAME;R_CONSTRAINT_NAME;R_COLUMN_NAME");

                while (readerConstraints.Read())
                {
                    for (int i = 0; i < 7; i++)
                        csv.Write("\"" + readerConstraints.GetValue(i) + "\"" + (i == 9 ? "" : "; "));
                    csv.WriteLine();
                }

                csv.Close();
            }

            #endregion

            #region Compare

            private static (DataTable Tables, DataTable Constraints) GetStructureDataTables(string csvPath)
            {
                StreamReader csv = new StreamReader(csvPath);

                var firstLine = csv.ReadLine();

                var header = firstLine == "sep=;" ? csv.ReadLine() : firstLine.Trim(';');

                DataTable tables = new DataTable();
                DataTable constraints = new DataTable();

                header.Split(';').Select(column => tables.Columns.Add(column.Trim('"'))).ToArray();

                while (true)
                {
                    string csvRow = csv.ReadLine().Trim(';');

                    if (string.IsNullOrWhiteSpace(csvRow.Trim(';')))
                        break;

                    DataRow tableRow = tables.NewRow();

                    var itemArray = csvRow.Split(';').Select(value => value.Trim('"')).ToArray();

                    Array.Resize(ref itemArray, tables.Columns.Count);

                    itemArray = itemArray.Select(x => x ?? "").ToArray();

                    tableRow.ItemArray = itemArray;

                    tables.Rows.Add(tableRow);
                }

                csv.ReadLine();
                csv.ReadLine().Trim(';').Split(';').Select(constraint => constraints.Columns.Add(constraint.Trim('"'))).ToArray();

                while (!csv.EndOfStream)
                {
                    string csvRow = csv.ReadLine().Trim(';');

                    DataRow tableRow = constraints.NewRow();

                    var itemArray = csvRow.Split(';').Select(value => value.Trim('"')).ToArray();

                    Array.Resize(ref itemArray, constraints.Columns.Count);

                    itemArray = itemArray.Select(x => x ?? "").ToArray();

                    tableRow.ItemArray = itemArray;

                    constraints.Rows.Add(tableRow);
                }

                csv.Close();

                return (tables, constraints);
            }

            private static ((DataTable OnlyDB1, DataTable OnlyDB2, DataTable UnionDiff) Tables,
                            (DataTable OnlyDB1, DataTable OnlyDB2, DataTable UnionDiff) Constraints)
            CompareStructure((DataTable Tables, DataTable Constraints) db1, (DataTable Tables, DataTable Constraints) db2)
            {
                bool ContainsField(DataTable tableDiff, DataRow row, DatabaseCompare compareType)
                {
                    switch (compareType)
                    {
                        case DatabaseCompare.Tables:
                            foreach (DataRow row2 in tableDiff.Rows)
                                if ((string)row[0] == (string)row2[0]
                                 && (string)row[1] == (string)row2[1])
                                    return true;
                            break;

                        case DatabaseCompare.Constraints:
                            foreach (DataRow row2 in tableDiff.Rows)
                                if ((string)row[0] == (string)row2[0]
                                 && (string)row[1] == (string)row2[1]
                                 && (string)row[2] == (string)row2[2])
                                    return true;
                            break;
                    }

                    return false;
                }

                DataTable ToDataTable(IEnumerable<DataRow> erc)
                    => (erc.Count() == 0) ? new DataTable() : erc.CopyToDataTable();

                #region Tables

                var tables1Diff = ToDataTable(db1.Tables.AsEnumerable().Except(db2.Tables.AsEnumerable(), DataRowComparer.Default));
                var tables2Diff = ToDataTable(db2.Tables.AsEnumerable().Except(db1.Tables.AsEnumerable(), DataRowComparer.Default));

                var tables1Only = ToDataTable(tables1Diff.AsEnumerable().Where(row => !ContainsField(tables2Diff, row, DatabaseCompare.Tables)));
                var tables2Only = ToDataTable(tables2Diff.AsEnumerable().Where(row => !ContainsField(tables1Diff, row, DatabaseCompare.Tables)));

                var table1UnionDiff = ToDataTable(tables1Diff.AsEnumerable().Where(row => ContainsField(tables2Diff, row, DatabaseCompare.Tables)));
                table1UnionDiff.Columns.Add("DB").SetOrdinal(0);
                foreach (DataRow row in table1UnionDiff.Rows) row["DB"] = "DB1";

                var table2UnionDiff = ToDataTable(tables2Diff.AsEnumerable().Where(row => ContainsField(tables1Diff, row, DatabaseCompare.Tables)));
                table2UnionDiff.Columns.Add("DB").SetOrdinal(0);
                foreach (DataRow row in table2UnionDiff.Rows) row["DB"] = "DB2";

                var tablesUnionDiff = ToDataTable(table1UnionDiff.AsEnumerable().Concat(table2UnionDiff.AsEnumerable()));
                if (tablesUnionDiff.Rows.Count != 0)
                    tablesUnionDiff.DefaultView.Sort = "table_name ASC, ordinal_position ASC, DB ASC";
                tablesUnionDiff = tablesUnionDiff.DefaultView.ToTable();

                #endregion

                #region Constraints

                var constraints1Diff = ToDataTable(db1.Constraints.AsEnumerable().Except(db2.Constraints.AsEnumerable(), DataRowComparer.Default));
                var constraints2Diff = ToDataTable(db2.Constraints.AsEnumerable().Except(db1.Constraints.AsEnumerable(), DataRowComparer.Default));

                var constraints1Only = ToDataTable(constraints1Diff.AsEnumerable().Where(row => !ContainsField(constraints2Diff, row, DatabaseCompare.Constraints)));
                var constraints2Only = ToDataTable(constraints2Diff.AsEnumerable().Where(row => !ContainsField(constraints1Diff, row, DatabaseCompare.Constraints)));

                var constraint1UnionDiff = ToDataTable(constraints1Diff.AsEnumerable().Where(row => ContainsField(constraints2Diff, row, DatabaseCompare.Constraints)));
                constraint1UnionDiff.Columns.Add("DB").SetOrdinal(0);
                foreach (DataRow row in constraint1UnionDiff.Rows) row["DB"] = "DB1";

                var constraint2UnionDiff = ToDataTable(constraints2Diff.AsEnumerable().Where(row => ContainsField(constraints1Diff, row, DatabaseCompare.Constraints)));
                constraint2UnionDiff.Columns.Add("DB").SetOrdinal(0);
                foreach (DataRow row in constraint2UnionDiff.Rows) row["DB"] = "DB2";

                var constraintsUnionDiff = ToDataTable(constraint1UnionDiff.AsEnumerable().Concat(constraint2UnionDiff.AsEnumerable()));
                if (constraintsUnionDiff.Rows.Count != 0)
                    constraintsUnionDiff.DefaultView.Sort = "table_name ASC, constraint_name ASC, ordinal_position ASC, DB ASC";
                constraintsUnionDiff = constraintsUnionDiff.DefaultView.ToTable();

                #endregion

                return ((tables1Only, tables2Only, tablesUnionDiff), (constraints1Only, constraints2Only, constraintsUnionDiff));
            }

            private static void WriteStructureCompareCSV(string filePathDB1, string filePathDB2, string outputPath,
                                                                 (DataTable OnlyDB1, DataTable OnlyDB2, DataTable UnionDiff) tables,
                                                                 (DataTable OnlyDB1, DataTable OnlyDB2, DataTable UnionDiff) constraints,
                                                                 bool baseFromConnectionString)
            {
                StreamWriter csv = new StreamWriter(outputPath, false, Encoding.Unicode);

                csv.WriteLine("sep=;");
                csv.WriteLine($"DB1: {filePathDB1.Split('\\').Last()}");
                if (baseFromConnectionString)
                    csv.WriteLine($"DB2: (Carregado a partir de uma string de conexão)");
                else
                    csv.WriteLine($"DB2: {filePathDB2.Split('\\').Last()}");
                csv.WriteLine();

                if (tables.OnlyDB1.AsEnumerable().Count() == 0
                    && tables.OnlyDB2.AsEnumerable().Count() == 0
                    && tables.UnionDiff.AsEnumerable().Count() == 0)
                {
                    csv.WriteLine("Não há diferenças entre as tabelas da DB1 e da DB2");
                    csv.WriteLine();
                }
                else
                {
                    csv.WriteLine("Tabelas:");
                    csv.WriteLine();
                    if (tables.OnlyDB1.AsEnumerable().Count() != 0)
                    {
                        csv.WriteLine("Tabelas apenas na DB1: ");
                        csv.WriteLine(string.Join(";", tables.OnlyDB1.Columns.Cast<DataColumn>().Select(col => col.ColumnName)));
                        foreach (string line in tables.OnlyDB1.AsEnumerable().Select(row => string.Join(";", row.ItemArray))) csv.WriteLine(line);
                        csv.WriteLine();
                    }
                    if (tables.OnlyDB2.AsEnumerable().Count() != 0)
                    {
                        csv.WriteLine("Tabelas apenas na DB2: ");
                        csv.WriteLine(string.Join(";", tables.OnlyDB2.Columns.Cast<DataColumn>().Select(col => col.ColumnName)));
                        foreach (string line in tables.OnlyDB2.AsEnumerable().Select(row => string.Join(";", row.ItemArray))) csv.WriteLine(line);
                        csv.WriteLine();
                    }
                    if (tables.UnionDiff.AsEnumerable().Count() != 0)
                    {
                        csv.WriteLine("Tabelas com alterações entre a DB1 e a DB2: ");
                        csv.WriteLine(string.Join(";", tables.UnionDiff.Columns.Cast<DataColumn>().Select(col => col.ColumnName)));
                        foreach (string line in tables.UnionDiff.AsEnumerable().Select(row => string.Join(";", row.ItemArray))) csv.WriteLine(line);
                        csv.WriteLine();
                    }
                }


                if (constraints.OnlyDB1.AsEnumerable().Count() == 0
                    && constraints.OnlyDB2.AsEnumerable().Count() == 0
                    && constraints.UnionDiff.AsEnumerable().Count() == 0)
                {
                    csv.WriteLine("Não há diferenças entre as constraints da DB1 e da DB2");
                }
                else
                {
                    csv.WriteLine("Constraints:");
                    csv.WriteLine();
                    if (constraints.OnlyDB1.AsEnumerable().Count() != 0)
                    {
                        csv.WriteLine("Constraints apenas na DB1: ");
                        csv.WriteLine(string.Join(";", constraints.OnlyDB1.Columns.Cast<DataColumn>().Select(col => col.ColumnName)));
                        foreach (string line in constraints.OnlyDB1.AsEnumerable().Select(row => string.Join(";", row.ItemArray))) csv.WriteLine(line);
                        csv.WriteLine();
                    }
                    if (constraints.OnlyDB2.AsEnumerable().Count() != 0)
                    {
                        csv.WriteLine("Constraints apenas na DB2: ");
                        csv.WriteLine(string.Join(";", constraints.OnlyDB2.Columns.Cast<DataColumn>().Select(col => col.ColumnName)));
                        foreach (string line in constraints.OnlyDB2.AsEnumerable().Select(row => string.Join(";", row.ItemArray))) csv.WriteLine(line);
                        csv.WriteLine();
                    }
                    if (constraints.UnionDiff.AsEnumerable().Count() != 0)
                    {
                        csv.WriteLine("Constraints com alterações entre a DB1 e a DB2: ");
                        csv.WriteLine(string.Join(";", constraints.UnionDiff.Columns.Cast<DataColumn>().Select(col => col.ColumnName)));
                        foreach (string line in constraints.UnionDiff.AsEnumerable().Select(row => string.Join(";", row.ItemArray))) csv.WriteLine(line);
                    }
                }

                csv.Close();
            }

            public static DatabaseStructureCompareResult GenerateStructureCompareCSV(string filePathDB1, string filePathDB2, string outputPath, bool baseFromConnectionString)
            {
                (DataTable, DataTable) db1;
                (DataTable, DataTable) db2;

                try
                {
                    db1 = GetStructureDataTables(filePathDB1);
                    db2 = GetStructureDataTables(filePathDB2);
                }
                catch { return DatabaseStructureCompareResult.CSVReadError; }

                (DataTable OnlyDB1, DataTable OnlyDB2, DataTable UnionDiff) tables;
                (DataTable OnlyDB1, DataTable OnlyDB2, DataTable UnionDiff) constraints;

                try { (tables, constraints) = CompareStructure(db1, db2); }
                catch { return DatabaseStructureCompareResult.CSVComnpareError; }

                try { WriteStructureCompareCSV(filePathDB1, filePathDB2, outputPath, tables, constraints, baseFromConnectionString); }
                catch { return DatabaseStructureCompareResult.WriteFileError; }

                return DatabaseStructureCompareResult.Success;
            }

            #endregion
        }

        public class LogicalStructure
        {
            #region Collect

            public static DataBaseStructureResult GenerateStructureCSV(DatabaseType dbType, string connectionString, string[] tables, string csvsDirectory, string csvsName, string prefix)
            {
                try
                {
                    switch (dbType)
                    {
                        case DatabaseType.SQLServer:
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                try { connection.Open(); }
                                catch { connection.Close(); return DataBaseStructureResult.ConnectionError; }

                                string tablesQuery = "";
                                foreach (string table in tables)
                                {
                                    switch (table)
                                    {
                                        default:
                                            tablesQuery += $"select * from {prefix}{table};";
                                            break;
                                        case "prefixo_storedProcedures":
                                            spData(table, tables, "sp_stored_procedures;", csvsDirectory, csvsName, connection);
                                            tables = tables.Where(val => val != table).ToArray();
                                            break;
                                        case "prefixo_tabelas":
                                            tablesQuery += "select sysobjects.name as tabela, crdate as create_datetime from sysobjects where sysobjects.type = 'u' order by sysobjects.name;";
                                            break;
                                        case "prefixo_functions":
                                            tablesQuery += "select sysobjects.name as função, xtype as tipo from sys.sysobjects where xtype = 'AF' or xtype = 'FN' or xtype = 'FS' or xtype = 'FT' or xtype = 'IF' or xtype = 'TF' order by xtype;";
                                            break;
                                        case "users":
                                            tablesQuery += "select * from sys.sysusers;";
                                            break;
                                        case "tabelas_existentes":
                                            tablesQuery += "select sysusers.name as [owner], sysobjects.name as tabela, crdate as create_datetime from sysobjects join sysusers on sysusers.uid = sysobjects.uid where sysobjects.type in ('u') and sysobjects.name not like 'dt%' order by sysobjects.name, sysusers.name;";
                                            break;
                                        case "colunas_existentes":
                                            tablesQuery += "select sysusers.name as [owner], sysobjects.name as tabela, syscolumns.name as coluna, systypes.name as datatype, syscolumns.length, syscolumns.isnullable, syscolumns.colorder from syscolumns inner join sysobjects on sysobjects.id = syscolumns.id inner join sysusers on sysusers.uid = sysobjects.uid inner join systypes on systypes.xtype = syscolumns.xtype where sysobjects.type = 'u' and sysobjects.name <> 'dtproperties' order by sysobjects.name, sysusers.name, syscolumns.colorder;";
                                            break;
                                        case "objetos_existentes":
                                            tablesQuery += "select sysusers.name as [owner], sysobjects.name as objeto, sysobjects.type as tipo, crdate as create_datetime from sysobjects join sysusers on sysusers.uid = sysobjects.uid where sysobjects.type not in ('u','s','d','SQ','F','K','IT') and sysobjects.name not like 'dt%' order by sysobjects.type desc, sysobjects.name, sysusers.name;";
                                            break;
                                        case "foreignKeys_existentes":
                                            tablesQuery += "select sysusers.name as [owner], sysobjects.name as objeto, sysobjects.type as tipo, crdate as create_datetime from sysobjects join sysusers on sysusers.uid = sysobjects.uid where sysobjects.type in ('F') and sysobjects.name not like 'dt%' order by sysobjects.type desc, sysobjects.name , sysusers.name;";
                                            break;
                                        case "primaryKeys":
                                            tablesQuery += "select sysindexes.name, sysusers.name+'.'+sysobjects.name as name, rowcnt from sysindexes join sysobjects on sysindexes.id = sysobjects.id join sysusers on sysusers.uid = sysobjects.uid where sysobjects.type = 'u' and sysobjects.name <> 'dtproperties' and sysindexes.name not like '_WA%' order by sysobjects.name;";
                                            break;
                                        case "database_size_name":
                                            spData(table, tables, "sp_spaceused;", csvsDirectory, csvsName, connection);
                                            tables = tables.Where(val => val != table).ToArray();
                                            break;
                                    }
                                }

                                if (tablesQuery != "")
                                    using (SqlCommand command = new SqlCommand(tablesQuery, connection))
                                    {
                                        SqlDataReader reader;

                                        try { reader = command.ExecuteReader(); }
                                        catch { connection.Close(); return DataBaseStructureResult.ExecutionError; }

                                        try { WriteStructureCSV(tables, reader, csvsDirectory, csvsName); }
                                        catch { return DataBaseStructureResult.WriteFileError; }
                                        finally { reader.Close(); }
                                    }
                            }
                            break;

                        case DatabaseType.Oracle:
                            using (OracleConnection connection = new OracleConnection(connectionString))
                            {
                                //string[] tablesQuerys = tables.Select(t => $"select * from {prefix}{t}").ToArray();
                                string[] tablesQuerys = new string[tables.Length];

                                for (int t = 0; t < tables.Length; t++)
                                {
                                    switch (tables[t])
                                    {
                                        default:
                                            tablesQuerys[t] = $"SELECT * FROM {prefix}{tables[t]};";
                                            break;
                                        case "prefixo_storedProcedures":
                                            tablesQuerys[t] = @"SELECT owner, name AS procedure_name, type, line, text, origin_con_id FROM ALL_SOURCE WHERE type = 'PROCEDURE';";
                                            break;
                                        case "prefixo_tabelas":
                                            tablesQuerys[t] = "SELECT owner, table_name AS tabela, tablespace_name FROM ALL_TABLES;";
                                            break;
                                        case "prefixo_functions":
                                            tablesQuerys[t] = @"SELECT owner, name AS função, type, line, text, origin_con_id FROM ALL_SOURCE WHERE type = 'FUNCTION';";
                                            break;
                                        case "users":
                                            tablesQuerys[t] = "SELECT * FROM ALL_USERS;";
                                            break;
                                        case "tabelas_existentes":
                                            tablesQuerys[t] = @"SELECT owner, table_name, tablespace_name, num_rows FROM ALL_TABLES WHERE owner = 'BDS' ORDER BY table_name;";
                                            break;
                                        case "colunas_existentes":
                                            tablesQuerys[t] = @"SELECT owner, table_name, column_name, data_type, data_length, nullable, column_id FROM ALL_TAB_COLUMNS WHERE owner = 'BDS' ORDER BY table_name, column_name;";
                                            break;
                                        case "objetos_existentes":
                                            tablesQuerys[t] = @"SELECT owner, object_name, object_type, created from ALL_OBJECTS WHERE owner = 'BDS' ORDER BY object_type,object_name;";
                                            break;
                                        case "foreignKeys_existentes":
                                            tablesQuerys[t] = @"SELECT owner,constraint_name,constraint_type,table_name,r_owner,r_constraint_name,delete_rule,status,last_change from ALL_CONSTRAINTS ORDER BY table_name,constraint_name;";
                                            break;
                                        case "primaryKeys":
                                            tablesQuerys[t] = @"SELECT owner,constraint_name,constraint_type,table_name,status,last_change,index_name FROM ALL_CONSTRAINTS  WHERE owner = 'BDS' and constraint_type = 'P' ORDER BY table_name,constraint_name;";
                                            break;
                                        case "database_size_name":
                                            //spData(table, tables, "sp_spaceused;", csvsDirectory, csvsName, connection);
                                            //tables = tables.Where(val => val != table).ToArray();
                                            break;
                                    }
                                }

                                try { connection.Open(); }
                                catch { connection.Close(); return DataBaseStructureResult.ConnectionError; }

                                OracleCommand[] commands = null;
                                try
                                {
                                    commands = tablesQuerys.Select(q => new OracleCommand(q, connection)).ToArray();
                                }
                                catch (Exception e)
                                {
                                    System.Windows.Forms.MessageBox.Show($"Mensagem: {e.Message}\nOrigem do Erro: {e.TargetSite}");
                                }

                                OracleDataReader[] readers = new OracleDataReader[tables.Length];

                                try
                                {
                                    for (int i = 0; i < tables.Length; i++)
                                        readers[i] = commands[i].ExecuteReader();
                                }
                                catch (Exception e) { connection.Close(); System.Windows.Forms.MessageBox.Show($"Mensagem: {e.Message}\nOrigem do Erro: {e.TargetSite}"); return DataBaseStructureResult.ExecutionError; }

                                try { WriteStructureCSV(tables, readers, csvsDirectory, csvsName); }
                                catch { return DataBaseStructureResult.WriteFileError; }
                                finally
                                {
                                    foreach (var reader in readers)
                                        reader.Close();

                                    connection.Close();
                                }
                            }
                            break;
                    }
                }
                catch
                {
                    return DataBaseStructureResult.BadConnectionString;
                }

                return DataBaseStructureResult.Success;
            }

            private static void WriteStructureCSV(string[] tables, SqlDataReader reader, string csvsDirectory, string csvsName)
            {
                foreach (var table in tables)
                {
                    using (StreamWriter csv = new StreamWriter(Path.Combine(csvsDirectory, $"{table}-{csvsName}"), false, Encoding.Unicode))
                    {
                        csv.WriteLine("sep=;");
                        string column = "";
                        bool isprefix = table.Split('_')[0] == "prefixo" ? true : false;
                        if (isprefix)
                        {
                            csv.Write("prefix;");
                            switch (table.Split('_')[1])
                            {
                                case "storedProcedures":
                                    column = "PROCEDURE_NAME";
                                    break;
                                case "functions":
                                    column = "função";
                                    break;
                                case "tabelas":
                                    column = "tabela";
                                    break;
                            }
                        }

                        for (int i = 0; i < reader.FieldCount; i++)
                            csv.Write("\"" + reader.GetName(i) + "\";");

                        csv.WriteLine();
                        while (reader.Read())
                        {
                            if (isprefix)
                            {
                                string[] data = reader[column].ToString().Split('_');
                                if (data.Length <= 1)
                                    continue;
                                else
                                    csv.Write("\"" + data[0] + "\";");
                            }

                            for (int i = 0; i < reader.FieldCount; i++)
                                csv.Write("\"" + reader.GetValue(i) + "\";");

                            csv.WriteLine();
                        }

                        csv.WriteLine("\n");
                    }
                    reader.NextResult();
                }
            }

            private static void spData(string table, string[] tables, string cmd, string csvsDirectory, string csvsName, SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand(cmd, connection))
                {
                    SqlDataReader reader;
                    try { reader = command.ExecuteReader(); }
                    catch { connection.Close(); throw; }
                    string[] tbl = tables.Where(val => val == table).ToArray();
                    try { WriteStructureCSV(tbl, reader, csvsDirectory, csvsName); }
                    catch { throw; }
                    finally { reader.Close(); }
                }
            }

            private static void WriteStructureCSV(string[] tables, OracleDataReader[] reader, string csvsDirectory, string csvsName)
            {
                for (int i = 0; i < tables.Length; i++)
                {
                    StreamWriter csv = new StreamWriter(Path.Combine(csvsDirectory, $"{tables[i]}-{csvsName}"));
                    try
                    {
                        csv.WriteLine("sep=;");
                        string column = "";
                        bool isprefix = tables[i].Split('_')[0] == "prefixo" ? true : false;
                        if (isprefix)
                        {
                            csv.Write("prefix;");
                            switch (tables[i].Split('_')[1])
                            {
                                case "storedProcedures":
                                    column = "PROCEDURE_NAME";
                                    break;
                                case "functions":
                                    column = "função";
                                    break;
                                case "tabelas":
                                    column = "tabela";
                                    break;
                            }
                        }

                        csv.WriteLine("sep=;");

                        for (int j = 0; j < reader[i].FieldCount; j++)
                            csv.Write("\"" + reader[i].GetName(j) + "\";");

                        csv.WriteLine();

                        while (reader[i].Read())
                        {
                            if (isprefix)
                            {
                                string[] data = reader[i][column].ToString().Split('_');
                                if (data.Length <= 1)
                                    continue;
                                else
                                    csv.Write("\"" + data[0] + "\";");
                            }

                            for (int j = 0; j < reader[i].FieldCount; j++)
                                csv.Write("\"" + reader[i].GetValue(j) + "\";");

                            csv.WriteLine();
                        }

                        csv.Close();
                    } catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }

            #endregion



            #region Compare

            public static DatabaseLogicalStructureCompareConfig GetConfig(string configPath)
            {
                return new DeserializerBuilder()
                          .WithNamingConvention(new CamelCaseNamingConvention())
                          .Build()
                          .Deserialize<DatabaseLogicalStructureCompareConfig>(new StreamReader(configPath));
            }

            private static (DataTable DB1, DataTable DB2) GetStructureCompareTables(string tableName, DatabaseCSVInfo db1, DatabaseCSVInfo db2)
            {
                DataTable GetDataTableFromCSV(string path)
                {
                    StreamReader csv = new StreamReader(path);

                    DataTable table = new DataTable();

                    string firstLine = csv.ReadLine();

                    string header = firstLine == "sep=;" ? csv.ReadLine() : firstLine.Trim(';');

                    header.Split(';').Select(column => table.Columns.Add(column.Trim('"'))).ToArray();

                    while (!csv.EndOfStream)
                    {
                        DataRow tableRow = table.NewRow();

                        tableRow.ItemArray = csv.ReadLine().Trim(';').Split(';').Select(value => value.Trim('"')).ToArray();

                        table.Rows.Add(tableRow);
                    }

                    csv.Close();

                    return table;
                }

                var db1CSVPath = Path.Combine(db1.Directory, $"{tableName}-{db1.Sufix}.csv");
                var db2CSVPath = Path.Combine(db2.Directory, $"{tableName}-{db2.Sufix}.csv");

                var db1Table = GetDataTableFromCSV(db1CSVPath);
                var db2Table = GetDataTableFromCSV(db2CSVPath);

                return (db1Table, db2Table);
            }

            private static (DataTable OnlyDB1, DataTable OnlyDB2, DataTable UnionDiff) CompareStructure((DataTable DB1, DataTable DB2) table, string[] idColumns, string[] diffColumns)
            {
                DataTable ToDataTable(IEnumerable<DataRow> edr)
                    => (edr.Count() == 0) ? new DataTable() : edr.CopyToDataTable();

                DataTable GetTableDiff(DataTable dt1, DataTable dt2)
                {
                    var compareColumns = idColumns.Concat(diffColumns).ToArray();

                    bool IsEqual(DataRow dr1, DataRow dr2)
                    {
                        foreach (var column in compareColumns)
                            if (dr1[column].ToString() != dr2[column].ToString())
                                return false;

                        return true;
                    }

                    return ToDataTable(dt1.AsEnumerable().Where(dr1 => !dt2.AsEnumerable().Any(dr2 => IsEqual(dr1, dr2))));
                }

                DataTable GetTableOnly(DataTable dt1, DataTable dt2)
                {
                    bool IsEqual(DataRow dr1, DataRow dr2)
                    {
                        foreach (var column in idColumns)
                            if (dr1[column].ToString() != dr2[column].ToString())
                                return false;

                        return true;
                    }

                    return ToDataTable(dt1.AsEnumerable().Where(dr1 => !dt2.AsEnumerable().Any(dr2 => IsEqual(dr1, dr2))));
                }

                DataTable GetTableUnion(DataTable dt1, DataTable dt2)
                {
                    bool IsEqual(DataRow dr1, DataRow dr2)
                    {
                        foreach (var column in idColumns)
                            if (dr1[column].ToString() != dr2[column].ToString())
                                return false;

                        return true;
                    }

                    return ToDataTable(dt1.AsEnumerable().Where(dr1 => dt2.AsEnumerable().Any(dr2 => IsEqual(dr1, dr2))));
                }

                var diffDB1 = GetTableDiff(table.DB1, table.DB2);
                var diffDB2 = GetTableDiff(table.DB2, table.DB1);

                var onlyDB1 = GetTableOnly(diffDB1, diffDB2);
                var onlyDB2 = GetTableOnly(diffDB2, diffDB1);

                var unionDiffDB1 = GetTableUnion(diffDB1, diffDB2);
                unionDiffDB1.Columns.Add("DB").SetOrdinal(0);
                foreach (DataRow row in unionDiffDB1.Rows) row["DB"] = "DB1";

                var unionDiffDB2 = GetTableUnion(diffDB2, diffDB1);
                unionDiffDB2.Columns.Add("DB").SetOrdinal(0);
                foreach (DataRow row in unionDiffDB2.Rows) row["DB"] = "DB2";

                var unionDiff = ToDataTable(unionDiffDB1.AsEnumerable().Concat(unionDiffDB2.AsEnumerable()));
                if (unionDiff.Rows.Count != 0)
                    unionDiff.DefaultView.Sort = string.Join(" ASC, ", idColumns) + " ASC, DB ASC";
                unionDiff = unionDiff.DefaultView.ToTable();

                return (onlyDB1, onlyDB2, unionDiff);
            }

            private static void WriteStructureCompareCSV(DatabaseCSVInfo db1, DatabaseCSVInfo db2, DatabaseCSVInfo output,
                                                         DatabaseLogicalStructureCompareConfig.Comparion comparison,
                                                         (DataTable OnlyDB1, DataTable OnlyDB2, DataTable UnionDiff) compare)
            {
                StreamWriter csv = new StreamWriter(Path.Combine(output.Directory, $"{comparison.Table}-{output.Sufix}.csv"), false, Encoding.Unicode);

                csv.WriteLine("sep=;");
                if (db1.Sufix == "--load-from-database")
                    csv.WriteLine($"DB1: (Carregado a partir de uma string de conexão)");
                else
                    csv.WriteLine("DB1: " + Path.Combine(db1.Directory, $"{comparison.Table}-{db1.Sufix}.csv"));
                if (db2.Sufix == "--load-from-database")
                    csv.WriteLine($"DB2: (Carregado a partir de uma string de conexão)");
                else
                    csv.WriteLine("DB2: " + Path.Combine(db2.Directory, $"{comparison.Table}-{db2.Sufix}.csv"));
                csv.WriteLine();

                csv.WriteLine($"Tabela analisada: {comparison.Table}");
                csv.WriteLine();

                if (compare.OnlyDB1.AsEnumerable().Count() == 0
                && compare.OnlyDB2.AsEnumerable().Count() == 0
                && compare.UnionDiff.AsEnumerable().Count() == 0)
                {
                    csv.WriteLine("Não há diferenças entre os registros das duas tabelas");
                    csv.WriteLine();
                }
                else
                {
                    if (compare.OnlyDB1.AsEnumerable().Count() != 0)
                    {
                        csv.WriteLine("Registros apenas na DB1: ");
                        csv.WriteLine(string.Join(";", compare.OnlyDB1.Columns.Cast<DataColumn>().Select(col => col.ColumnName)));
                        foreach (string line in compare.OnlyDB1.AsEnumerable().Select(row => string.Join(";", row.ItemArray))) csv.WriteLine(line);
                        csv.WriteLine();
                    }
                    if (compare.OnlyDB2.AsEnumerable().Count() != 0)
                    {
                        csv.WriteLine("Registros apenas na DB2: ");
                        csv.WriteLine(string.Join(";", compare.OnlyDB2.Columns.Cast<DataColumn>().Select(col => col.ColumnName)));
                        foreach (string line in compare.OnlyDB2.AsEnumerable().Select(row => string.Join(";", row.ItemArray))) csv.WriteLine(line);
                        csv.WriteLine();
                    }
                    if (compare.UnionDiff.AsEnumerable().Count() != 0)
                    {
                        csv.WriteLine("Registros com alterações entre a DB1 e a DB2: ");
                        csv.WriteLine(string.Join(";", compare.UnionDiff.Columns.Cast<DataColumn>().Select(col => col.ColumnName)));
                        foreach (string line in compare.UnionDiff.AsEnumerable().Select(row => string.Join(";", row.ItemArray))) csv.WriteLine(line);
                        csv.WriteLine();
                    }
                }

                csv.Close();
            }

            public static DatabaseStructureCompareResult GenerateStructureCompareCSV(DatabaseLogicalStructureCompareConfig config)
            {
                foreach (var comparison in config.Comparisons)
                    try
                    {
                        var tables = GetStructureCompareTables(comparison.Table, config.DB1, config.DB2);
                        try
                        {
                            var result = CompareStructure(tables, comparison.IdColumns, comparison.DiffColumns);
                            try
                            {
                                WriteStructureCompareCSV(config.DB1, config.DB2, config.Output, comparison, result);
                            }
                            catch { return DatabaseStructureCompareResult.WriteFileError; }
                        }
                        catch { return DatabaseStructureCompareResult.CSVComnpareError; }
                    }
                    catch { return DatabaseStructureCompareResult.CSVReadError; }

                return DatabaseStructureCompareResult.Success;
            }

            #endregion
        }
    }
}
