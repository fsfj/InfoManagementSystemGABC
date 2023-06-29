using InfoManagementSystem.Data;
using InfoManagementSystem.Repositories;
using InfoManagementSystem.Repositories.Interfaces;
using InfoManagementSystem.Services;
using InfoManagementSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace InfoManagementSystem.App_Start
{
    public class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IMDBContext>();
            container.RegisterType<IConnectionFactory, ConnectionFactory>();
            //Employee
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            container.RegisterType<IEmployeeService, EmployeeService>();
            //Branch
            container.RegisterType<IBranchRepository, BranchRepository>();
            container.RegisterType<IBranchService, BranchService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}