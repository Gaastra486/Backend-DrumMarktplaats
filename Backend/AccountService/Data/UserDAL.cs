

using AccountService.Microservice.Context;
using AccountService.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Microservice.Data
{
    public class UserDAL : IUserDAL
    {
        private readonly UserDbContext db;

        public UserDAL(UserDbContext db)
        {
            this.db = db;
        }

        public List<UserModel> GetUsers() => db.User.ToList();

        public UserModel UpdateUser(UserModel user)
        {
            db.User.Update(user);
            db.SaveChanges();
            return db.User.Where(x => x.Id == user.Id).FirstOrDefault();
        }

        public ActionResult AddUser(UserModel user)
        {
            db.User.Add(user);
            db.SaveChanges();
            return new OkResult();
        }

        public UserModel GetUserById(int id)
        {
            return db.User.Where(x => x.Id == id).FirstOrDefault();
        }

        public ActionResult DeleteUserById(int id)
        {
            db.User.Remove(db.User.Where(x => x.Id == id).FirstOrDefault());
            db.SaveChanges();
            return new OkResult();
        }
    }
}
