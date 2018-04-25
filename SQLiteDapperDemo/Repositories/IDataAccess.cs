using SQLiteDapperDemo.Models;
using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
namespace SQLiteDapperDemo.Repositories
{
	public interface IDataAccess
    {
		void InsertName(string Name);

		Name GetName(int id);

		void DeleteName(int Id);

		void UpdateName(int Id, string Name);
        
		List<Name> GetNames();
    }
}
