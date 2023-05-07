using System;
using System.IO;
using Microsoft.Data.Sqlite;
using Dapper;
using System.Diagnostics;
using SQLiteDapperDemo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace SQLiteDapperDemo.Repositories
{
	public class SQLIteDataAccess : IDataAccess
    {
		private const string fileName = "MyDatabase.db";

		private IDbConnection connection = null;

        public SQLIteDataAccess()
        {
			string connectionString = $"FileName={fileName}";
			connection = new SqliteConnection(connectionString);
			if(!File.Exists(fileName))
			{
				FileStream fileStream = File.Create(fileName);
				fileStream.Close();

				try
				{
					connection.Open();
					connection.Execute("Create Table Names(Id INTEGER Primary Key AUTOINCREMENT, Name Text) ");
				}
				catch (Exception ex)
				{
					Trace.WriteLine(ex.Message);
				}
				finally
				{
					connection.Close();
				}

			}
        }

		public void DeleteName(int Id)
		{
			try
            {
                connection.Open();
				connection.Execute("Delete from Names Where Id = @Id", new {Id = Id});
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
		}

		public Name GetName(int id)
		{
			Name results = null;
            try
            {
                connection.Open();
				results = connection.QuerySingle<Name>("Select * from Names where Id = @Id", new {id = id});
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return results;		
		}

		public System.Collections.Generic.List<Name> GetNames()
		{
			List<Name> results = null;
			try
            {
                connection.Open();
				results = connection.Query<Name>("Select * from Names").ToList();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
			return results;
		}

		public void InsertName(string Name)
		{
			try
            {
                connection.Open();
				connection.Execute("Insert into Names (Name) values (@Name)", new { Name = Name });
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
		}

		public void UpdateName(int Id, string Name)
		{
			try
            {
                connection.Open();
                connection.Execute("Update Names set Name = @Name Where Id = @Id", 
				                   new { Name = Name, Id = Id });
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
		}
	}
}
