using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using StudentMng.Contracts;
using StudentMng.Services;
using StudentMng.DAL.Repositories;
using StudentMng.DAL.Utils;


namespace StudentMng
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<DbConnectionFactory>();
            container.RegisterSingleton<IStudentServices,StudentService>();
            container.RegisterType<IStudentRepository, StudentRepository>();
            
            //User part
            container.RegisterSingleton<IUserService, UserService>();
            container.RegisterType<IUserRepo, UserRepo>();
            

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));//set the resolver for MVC to use Unity
        }
    }
}