using DatarynxApp.Common;
using DatarynxApp.Services;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatarynxApp.Droid.Services.SQLiteService))]
namespace DatarynxApp.Droid.Services
{
    public class SQLiteService : ISQLiteService
    {
        public SQLiteConnection GetConnection(string databaseName)
        {
            return new SQLiteConnection(GetPath(databaseName));
        }

        public long GetSize(string databaseName)
        {
            var fileInfo = new FileInfo(GetPath(databaseName));
            return fileInfo != null ? fileInfo.Length : 0;
        }

        string GetPath(string databaseName)
        {
            if (string.IsNullOrWhiteSpace(databaseName))
            {
                throw new ArgumentException("Invalid database name", nameof(databaseName));
            }
            var sqliteFilename = $"{databaseName}.db3";
            var path = Path.Combine(Constants.Folder, sqliteFilename);
            return path;
        }
    }
}