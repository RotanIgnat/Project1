using Ninject.Modules;
using DataAccessLayer;
using ModelBloger;

namespace BusinessLogic
{
    /// <summary>
    /// Модуль конфигурации DI.
    /// </summary>
    public class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            // Репозиторий (Singleton)
            Bind<IRepository<Blogger>>().To<EntityRepository>().InSingletonScope();

            // Сервисы
            Bind<IBloggerService>().To<BloggerService>();
            Bind<ISortFilterService>().To<SortFilterService>();

            // Логика
            Bind<ILogic>().To<Logic>();
        }
    }
}