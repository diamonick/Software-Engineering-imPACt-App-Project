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
            _database.CreateTableAsync<Event>().Wait();
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

        public Task<User> GetUserByRole(string role)
        {
            return _database.Table<User>()
                            .Where(i => i.Role == role)
                            .FirstOrDefaultAsync();
        }

        public Task<User> GetUserByUniversity(string university)
        {
            return _database.Table<User>()
                            .Where(i => i.University == university)
                            .FirstOrDefaultAsync();
        }

        public Task<User> GetUserByLocation(string location)
        {
            return _database.Table<User>()
                            .Where(i => i.Location == location)
                            .FirstOrDefaultAsync();
        }

        public Task<User> GetUserByMajor(string major)
        {
            return _database.Table<User>()
                            .Where(i => i.Major == major)
                            .FirstOrDefaultAsync();
        }

        public Task<User> GetUserByClassification(string classification)
        {
            return _database.Table<User>()
                            .Where(i => i.Classification == classification)
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

        public Task<int> SaveEventAsync(Event Event)
        {
            if (Event.ID != 0)
            {
                return _database.UpdateAsync(Event);
            }
            else
            {
                return _database.InsertAsync(Event);
            }
        }

        public Task<Event> GetEventByKeyword(string keyword)
        {
            return _database.Table<Event>()
                            .Where(i => i.Keyword == keyword)
                            .FirstOrDefaultAsync();
        }

        public Task<int> DeleteEventAsync(Event Event)
        {
            return _database.DeleteAsync(Event);
        }
    }
}
