﻿using EmployeeApplication.Repositories;

namespace EmployeeApplication.Services
{
    public class Service : IService
    {
        Manager manager = new Manager();
        public bool Login(string email, string password)
        {
           return manager.Login(email, password);
        }
    }
}
