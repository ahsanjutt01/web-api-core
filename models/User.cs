using System;
using System.Collections.Generic;
using System.Linq;

namespace demo_api.models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Work { get; set; }
    }

    public class UserRepo
    {
        private static List<User> userList = new List<User>
        {
            new User { Id = 1, FullName = "John Doe", Email = "john@example.com", Age = 28, Work = "Developer", Password = "dev123" },
            new User { Id = 2, FullName = "Jane Smith", Email = "jane@example.com", Age = 24, Work = "Designer", Password = "dev123" },
            new User { Id = 3, FullName = "Alex Johnson", Email = "alex@example.com", Age = 30, Work = "Manager", Password = "dev123" },
            new User { Id = 4, FullName = "Emily Brown", Email = "emily@example.com", Age = 22, Work = "Intern", Password = "dev123" },
            new User { Id = 5, FullName = "Michael Lee", Email = "michael@example.com", Age = 35, Work = "Consultant", Password = "dev123" }
        };


        // Add a new user
        public static User AddUser(User newUser)
        {
            newUser.Id = userList.Count + 1;
            userList.Add(newUser);
            return newUser;
        }

        // Update an existing user
        public static User UpdateUser(int id, User updatedUser)
        {
            var existingUser = userList.FirstOrDefault(u => u.Id == id);
            if (existingUser != null)
            {
                existingUser.FullName = updatedUser.FullName;
                existingUser.Email = updatedUser.Email;
                existingUser.Age = updatedUser.Age;
                existingUser.Work = updatedUser.Work;
            }
            return existingUser;
        }

        // Remove a user
        public static bool RemoveUser(int id)
        {
            var userToRemove = userList.FirstOrDefault(u => u.Id == id);
            if (userToRemove != null)
            {
                userList.Remove(userToRemove);
                return true;
            } else
            {
                return false;
            }
        }
        public static User GetUserById(int id)
        {
            var user = userList.FirstOrDefault(u => u.Id == id);
            return user;
        }


        public static User Login(LoginModel model)
        {
            var user = userList.FirstOrDefault(u => u.Email == model.Email);
            if(user == null)
            {
                return null;
            }
            if(user.Password == model.Password)
            {
                return user;

            } else
            {
                return null;
            }
        }

        // Get random users
        public static List<User> GetRandomUsers()
        {
            return userList;
        }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

}
