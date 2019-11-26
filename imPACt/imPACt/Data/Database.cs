using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using imPACt.Models;

namespace imPACt.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

        public Task<List<User>> GetUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<User> GetUserAsync(int id)
        {
            return _database.Table<User>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<User> GetUserByEmail(string email)
        {
            return _database.Table<User>()
                            .Where(i => i.Email == email)
                            .FirstOrDefaultAsync();
        }

        public Task<User> GetCurrentUser()
        {
            return _database.Table<User>()
                            .Where(i => i.LoggedIn == true)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveUserAsync(User User)
        {
            if (User.ID != 0)
            {
                return _database.UpdateAsync(User);
            }
            else
            {
                return _database.InsertAsync(User);
            }
        }

        public Task<int> DeleteUserAsync(User User)
        {
            return _database.DeleteAsync(User);
        }
    }
}
