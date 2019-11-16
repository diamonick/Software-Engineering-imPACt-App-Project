using imPACt.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace imPACt.Helper
{

    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://impact-9f78a.firebaseio.com/");

        //public async Task<List<User>> GetAllUsers()
        //{

        //    return (await firebase
        //      .Child("Users")
        //      .OnceAsync<User>()).Select(item => new User
        //      {
        //          Name = item.Object.Name,
        //          UserID = item.Object.UserID
        //      }).ToList();
        //}

        public async Task AddUser(int userID, string name)
        {

            await firebase
              .Child("Users")
              .PostAsync(new User() { UserID = userID, Name = name });
        }

        //public async Task<User> GetUser(int userID)
        //{
        //    var allUsers = await GetAllUsers();
        //    await firebase
        //      .Child("Users")
        //      .OnceAsync<User>();
        //    return allUsers.Where(a => a.UserID == userID).FirstOrDefault();
        //}

        public async Task UpdateUser(int userID, string name)
        {
            var toUpdateUser = (await firebase
              .Child("Users")
              .OnceAsync<User>()).Where(a => a.Object.UserID == userID).FirstOrDefault();

            await firebase
              .Child("Users")
              .Child(toUpdateUser.Key)
              .PutAsync(new User() { UserID = userID, Name = name });
        }

        public async Task DeleteUser(int userID)
        {
            var toDeleteUser = (await firebase
              .Child("Users")
              .OnceAsync<User>()).Where(a => a.Object.UserID == userID).FirstOrDefault();
            await firebase.Child("Users").Child(toDeleteUser.Key).DeleteAsync();

        }
    }

}