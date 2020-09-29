using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatarynxApp.Services
{
    public interface ISQLiteService
    {
        SQLiteConnection GetConnection(string databaseName);
        long GetSize(string databaseName);
    }
}
