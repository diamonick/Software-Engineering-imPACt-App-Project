using System;
using SQLite;

namespace imPACt.iOS
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}