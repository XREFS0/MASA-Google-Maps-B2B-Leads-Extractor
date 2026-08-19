using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MASAGooGLExtractor
{
	// Token: 0x0200000C RID: 12
	public class Database
	{
		// Token: 0x06000040 RID: 64 RVA: 0x00003870 File Offset: 0x00001A70
		public Database(DBSettings Settings)
		{
			string myConnectionString = string.Format("server={0};port={1};uid={2};pwd={3};database={4};Convert Zero Datetime=True", new object[] { Settings.MySqlServer, Settings.Port, Settings.User, Settings.Password, Settings.Database });
			try
			{
				this.Connection = new MySqlConnection();
				this.Connection.ConnectionString = myConnectionString;
				this.Connection.Open();
			}
			catch (MySqlException ex)
			{
				MessageBox.Show(string.Format("Database connection error!{0}{1}", Environment.NewLine, ex.Message));
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00003920 File Offset: 0x00001B20
		public long Insert(string Table, List<string> Values, bool ReturnLastInsertID)
		{
			MySqlCommand Command = this.Connection.CreateCommand();
			Command.CommandText = string.Format("INSERT INTO `{0}` VALUES(null ", Table);
			foreach (string Value in Values)
			{
				MySqlCommand mySqlCommand = Command;
				mySqlCommand.CommandText += string.Format(", \"{0}\"", Value);
			}
			MySqlCommand mySqlCommand2 = Command;
			mySqlCommand2.CommandText += ")";
			Command.ExecuteNonQuery();
			if (ReturnLastInsertID)
			{
				return Command.LastInsertedId;
			}
			return 0L;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000039CC File Offset: 0x00001BCC
		public void Insert(string Table, List<string> Values)
		{
			MySqlCommand Command = this.Connection.CreateCommand();
			Command.CommandText = string.Format("INSERT INTO `{0}` VALUES(", Table);
			foreach (string Value in Values)
			{
				MySqlCommand mySqlCommand = Command;
				mySqlCommand.CommandText += string.Format("\"{0}\",", Value);
			}
			Command.CommandText = Command.CommandText.Substring(0, Command.CommandText.Length - 1) + ")";
			try
			{
				Command.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				File.AppendAllText("db_operations.log", string.Format("{0} {1}{2}", ex.Message, Command.CommandText, Environment.NewLine));
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003AB4 File Offset: 0x00001CB4
		public List<object[]> Select(string Table, string Term)
		{
			List<object[]> Results = new List<object[]>();
			MySqlCommand mySqlCommand = this.Connection.CreateCommand();
			mySqlCommand.CommandText = string.Format("SELECT * FROM `{0}` WHERE {1}", Table, Term);
			MySqlDataReader Reader = mySqlCommand.ExecuteReader();
			while (Reader.Read())
			{
				try
				{
					object[] values = new object[Reader.FieldCount];
					Reader.GetValues(values);
					Results.Add(values);
				}
				catch
				{
				}
			}
			Reader.Close();
			return Results;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00003B2C File Offset: 0x00001D2C
		public List<object[]> Select(string Request)
		{
			List<object[]> Results = new List<object[]>();
			if (this.Connection.State != ConnectionState.Open)
			{
				this.Connection.Open();
			}
			MySqlCommand Command = this.Connection.CreateCommand();
			Command.CommandText = Request;
			MySqlDataReader Reader = null;
			try
			{
				Reader = Command.ExecuteReader();
			}
			catch
			{
			}
			if (Reader != null)
			{
				while (Reader.Read())
				{
					try
					{
						object[] values = new object[Reader.FieldCount];
						Reader.GetValues(values);
						Results.Add(values);
					}
					catch (Exception e)
					{
						File.AppendAllText(this.SQLlog, string.Format("{0}{1}", e.Message, Environment.NewLine));
					}
				}
				Reader.Close();
			}
			return Results;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00003BEC File Offset: 0x00001DEC
		public int IntScalarSelect(string Request)
		{
			MySqlCommand mySqlCommand = this.Connection.CreateCommand();
			mySqlCommand.CommandText = string.Format(Request, Array.Empty<object>());
			MySqlDataReader Reader = mySqlCommand.ExecuteReader();
			while (Reader.Read())
			{
				try
				{
					return Reader.GetInt32(0);
				}
				catch
				{
				}
			}
			Reader.Close();
			return 0;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00003C4C File Offset: 0x00001E4C
		public void DoRequest(string Request)
		{
			MySqlCommand Command = this.Connection.CreateCommand();
			Command.CommandText = string.Format(Request, Array.Empty<object>());
			try
			{
				Command.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				File.AppendAllText("db_operations.log", string.Format("{0} {1}{2}", ex.Message, Command.CommandText, Environment.NewLine));
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003CB8 File Offset: 0x00001EB8
		public long GetLastId()
		{
			MySqlCommand Command = this.Connection.CreateCommand();
			Command.CommandText = string.Format("SELECT LAST_INSERT_ID()", Array.Empty<object>());
			try
			{
				return (long)Command.ExecuteScalar();
			}
			catch (Exception ex)
			{
				File.AppendAllText("db_operations.log", string.Format("{0} {1}{2}", ex.Message, Command.CommandText, Environment.NewLine));
			}
			return 0L;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00003D30 File Offset: 0x00001F30
		public void Update(string Table, string[] Fields, string[] Values, string Term)
		{
			MySqlCommand Command = this.Connection.CreateCommand();
			string UpdateData = "";
			for (int i = 0; i < Values.Length; i++)
			{
				if (i == 0)
				{
					UpdateData += string.Format("`{0}`=\"{1}\"", Fields[i], Values[i]);
				}
				else
				{
					UpdateData += string.Format(", `{0}`=\"{1}\"", Fields[i], Values[i]);
				}
			}
			Command.CommandText = string.Format("UPDATE `{0}` SET {1} WHERE {2}", Table, UpdateData, Term);
			try
			{
				Command.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				File.AppendAllText("db_operations.log", string.Format("{0} {1}{2}", ex.Message, Command.CommandText, Environment.NewLine));
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003DE8 File Offset: 0x00001FE8
		public DatabaseObject GetObject(string Table, int Id)
		{
			DatabaseObject Obj = null;
			List<object[]> Items = this.Select(string.Format("SELECT Id,name FROM {0} WHERE Id={1}", Table, Id));
			if (Items.Count > 0)
			{
				Obj = new DatabaseObject
				{
					Id = Convert.ToInt32(Items[0][0]),
					Name = (string)Items[0][1]
				};
			}
			return Obj;
		}

		// Token: 0x04000018 RID: 24
		public MySqlConnection Connection;

		// Token: 0x04000019 RID: 25
		private string SQLlog = "SQLlog.txt";
	}
}
