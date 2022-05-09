﻿using Microsoft.AspNetCore.Mvc;
using AccountService.Models;

namespace AccountService.Microservice.Data
{
    public interface IUserDAL
    {
        ActionResult AddUser(UserModel user);
        List<UserModel> GetUsers();
        UserModel UpdateUser(UserModel user);
        UserModel GetUserById(int id);
        public ActionResult DeleteUserById(int id);
    }
}
