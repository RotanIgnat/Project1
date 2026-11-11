using Ninject.Modules;
using DataAccessLayer;
using ModelBloger;
using System.Configuration;

namespace BusinessLogic
{
    /// <summary>
    /// Модуль конфигурации для DI-контейнера Ninject.
    /// Устанавливает соответствия между интерфейсами и их реализациями.
    /// </summary>
    public class SimpleConfigModule : NinjectModule
    {
        /// <summary>
        /// Загружает правила внедрения зависимостей.
        /// </summary>
        /// <returns>Ничего не возвращает.</returns>
        public override void Load()
        {
            //Entity Framework
            Bind<IRepository<Blogger>>().To<EntityRepository>().InSingletonScope();

            /* daper
             Bind<IRepository<Blogger>>()
                 .To<DapperRepository>()
                 .WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
                 .InSingletonScope();
            */
        }
    }
}