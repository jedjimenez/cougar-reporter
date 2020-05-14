using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
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
                    firstName = item.Object.firstName,
                    lastName = item.Object.lastName,
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
        public static async Task<List<Ticket>> GetAllRepairs()
        {
            try
            {
                var repairlist = (await firebase
                .Child("Users")
                .OnceAsync<Ticket>()).Select(item =>
                new Ticket
                {
                    RepairType = item.Object.RepairType,
                    Building = item.Object.Building,
                    RoomNum = item.Object.RoomNum,
                    Description = item.Object.Description
                }).ToList();
                return repairlist;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }
        //retrieve data of the specific user     
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

        public static async Task<Ticket> GetRepair(string username)
        {
            try
            {
                var allRepair = await GetUser(username);
                return allRepair.Child("Users").Child(RepairType, Building, RoomNum, Description);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }
        //add user information to the database  
        public static async Task<bool> AddUser(string fName, string lName, string username, string password, string type, string id)
        {
            try
            {
                await firebase.Child("Users").PostAsync(new RegisteredUsers() {firstName = fName, lastName = lName, UserName = username, Password = password, AccountType = type, UserId = id });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //add Ticket Information to the database
        public static async Task AddInfo(string repair, string build, string roomNum, string desc)
        {
            try
            {
                var addInfo = (await firebase.Child("Users").OnceAsync<RegisteredUsers>()).Where(a => a.Object.UserName == u).FirstOrDefault();

                await firebase
                .Child("Users").Child(addInfo.Key)
                .PostAsync(new Ticket() {RepairType = repair, Building = build, RoomNum = roomNum, Description = desc });
                
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
            
            }
        }
    }
}
