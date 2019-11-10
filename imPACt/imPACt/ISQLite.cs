using System;
using SQLite;

namespace IntroToSQLite
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}