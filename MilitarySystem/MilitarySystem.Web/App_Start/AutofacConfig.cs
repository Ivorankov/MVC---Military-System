namespace MilitarySystem.Web
{
    using System.Data.Entity;
    using System.Reflection;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Mvc;

    using MilitarySystem.Data;
    using MilitarySystem.Data.Contracts;
    using MilitarySystem.Data.Repositories;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Services.Contracts;
    using Controllers;
    using Services;
    using MilitarySystem.Models;
    using System.Web;
    using Microsoft.Owin.Security;
    using Microsoft.AspNet.Identity;

    public class AutofacConfig
    {
        public static void RegisterAutofac()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // Register services
            RegisterServices(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<MilitarySystemContext>().As<IMilitarySystemContext>();


            builder.RegisterGeneric(typeof(GenericRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerRequest();

            //builder.RegisterType<UserStore<User>>().As<IUserStore<User>>().InstancePerLifetimeScope();
            //builder.RegisterType<ApplicationUserManager>().InstancePerLifetimeScope();
            //builder.RegisterType<ApplicationSignInManager>().InstancePerLifetimeScope();
            //builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication);

            //var servicesAssembly = Assembly.GetAssembly(typeof(IUsersService));
            //builder.RegisterType<UsersService>().As<IUsersService>();

            var servicesAssembly = Assembly.Load("MilitarySystem.Services");
            builder.RegisterAssemblyTypes(servicesAssembly).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AssignableTo<BaseController>().PropertiesAutowired();
        }
    }
}