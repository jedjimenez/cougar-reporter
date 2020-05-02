using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;

namespace cougar_reporter.Models
{
    class FirebaseHelper
    {
       public static FirebaseClient firebase = new FirebaseClient("https://cougarreporter.firebaseio.com/");

        //Read All    
        public static async Task<List<RegisteredUsers>> GetAllUser()
        {
            try
            {
                var userlist = (await firebase
                .Child("Users")
                .OnceAsync<RegisteredUsers>()).Select(item =>
                new RegisteredUsers
                {
                    UserName = item.Object.UserName,
                    Password = item.Object.Password,
                    AccountType = item.Object.AccountType
                }).ToList();
                return userlist;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Read     
        public static async Task<RegisteredUsers> GetUser(string username)
        {
            try
            {
                var allUsers = await GetAllUser();
                await firebase
                .Child("Users")
                .OnceAsync<RegisteredUsers>();
                return allUsers.Where(a => a.UserName == username).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Insert a user    
        public static async Task<bool> AddUser(string username, string password, int type, string id)
        {
            try
            {
                await firebase
                .Child("Users")
                .PostAsync(new RegisteredUsers() { UserName = username, Password = password, AccountType = type, UserId = id });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

    }
}
