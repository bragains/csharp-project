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

        public void AddUser(User user)
        {
            Users.Add(user);
            this.SaveChanges();     
        }

        public User GetUser(int id)
        {
            return (from user in Users
             where user.ID == id
             select user).First();
        }

        public void EditUser(User user)
        {
            this.Entry(user).State = EntityState.Modified;
            this.SaveChanges();
        }

        public User RetrieveUser(int id)
        {
            return (from user in Users
                    where user.ID == id
                    select user).First();
        }

        public void RemoveUser(User user)
        {
            this.Entry(user).State = EntityState.Deleted;
            this.SaveChanges();
        }


    }
}