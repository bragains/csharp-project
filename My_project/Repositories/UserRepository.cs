using My_project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace My_project.Repositories
{
    public class UserRepository : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserRepository() : base("UserRepository")
        {

        }


        //add user to database
        public void AddUser(User user)
        {
            Users.Add(user);
            this.SaveChanges();     
        }

        //retrieve user for editing
        public User GetUser(int id)
        {
            return (from user in Users
             where user.ID == id
             select user).First();
        }

        //edit user information using GetUser command
        public void EditUser(User user)
        {
            this.Entry(user).State = EntityState.Modified;
            this.SaveChanges();
        }


        //retrieve user to delete from database
        public User RetrieveUser(int id)
        {
            return (from user in Users
                    where user.ID == id
                    select user).First();
        }


        //delete user from database
        public void RemoveUser(User user)
        {
            this.Entry(user).State = EntityState.Deleted;
            this.SaveChanges();
        }


    }
}