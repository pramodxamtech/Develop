using DatarynxApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace DatarynxApp.Services
{
    public class DBService
    {
        static object locker = new object();
        ISQLiteService SQLite
        {
            get
            {
                return DependencyService.Get<ISQLiteService>();
            }
        }
        readonly SQLiteConnection connection;
        readonly string DatabaseName;

        public DBService(string databaseName)
        {
            DatabaseName = databaseName;
            connection = SQLite.GetConnection(DatabaseName);
        }

        public void CreateTable<T>()
        {
            lock (locker)
            {
                connection.CreateTable<T>();
            }
        }

        public long GetSize()
        {
            return SQLite.GetSize(DatabaseName);
        }

        public int SaveItem<T>(T item)
        {
            lock (locker)
            {
                var id = ((BaseItem)(object)item).ID;
                if (id != 0)
                {
                    connection.Update(item);
                    return id;
                }
                else
                {
                    return connection.Insert(item);
                }
            }
        }

        public void ExecuteQuery(string query)
        {
            lock (locker)
            {
                connection.Execute(query);
            }
        }

        public List<T> Query<T>(string query, object[] args) where T : new()
        {
            lock (locker)
            {
                return connection.Query<T>(query, args);
            }
        }

        public IEnumerable<T> GetItems<T>() where T : new()
        {
            lock (locker)
            {
                return (from i in connection.Table<T>() select i).ToList();
            }
        }
        public int DeleteItem<T>(int id)
        {
            lock (locker)
            {
                return connection.Delete<T>(id);
            }
        }

        public bool ItemExists<T>(string UserId)
        {
            lock (locker)
            {
                string cmdText = "SELECT Id FROM " + typeof(T).Name + " WHERE UserId=" + UserId;
                var cmd = connection.CreateCommand(cmdText, typeof(T).Name);
                return cmd.ExecuteScalar<string>() != null;
            }
        }
        public bool TableExists(string TableName)
        {
            lock (locker)
            {
                var val = connection.Query<Table>("SELECT name FROM sqlite_master WHERE type = 'table' AND name = ? ", new object[] { TableName });
                if (val.Count > 0)
                {
                    return true;
                }
                return false;
            }
        }
        public int DeleteAll<T>()
        {
            lock (locker)
            {
                return connection.DeleteAll<T>();
            }
        }


    }

}
