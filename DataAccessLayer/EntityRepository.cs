using System.Collections.Generic;
using System.Linq;
using ModelBloger;

namespace DataAccessLayer
{
    /// <summary>
    /// Репозиторий на Entity Framework.
    /// </summary>
    /// <typeparam name="T">Тип сущности.</typeparam>
    public class EntityRepository<T> : IRepository<T> where T : class, IDomainObject, new()
    {
        private readonly DataContext context;

        /// <summary>
        /// Конструктор репозитория Entity Framework.
        /// </summary>
        /// <returns>Ничего не возвращает.</returns>
        public EntityRepository()
        {
            context = new DataContext();
        }

        /// <summary>
        /// Добавляет объект в БД.
        /// </summary>
        /// <param name="obj">Объект для добавления.</param>
        /// <returns>Ничего не возвращает.</returns>
        public void Create(T obj)
        {
            context.Set<T>().Add(obj);
            context.SaveChanges();
        }

        /// <summary>
        /// Возвращает все объекты из БД.
        /// </summary>
        /// <returns>Список объектов.</returns>
        public IEnumerable<T> ReadAll()
        {
            return context.Set<T>().ToList();
        }

        /// <summary>
        /// Возвращает объект по ID.
        /// </summary>
        /// <param name="id">ID объекта.</param>
        /// <returns>Объект или null.</returns>
        public T ReadById(int id)
        {
            return context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Обновляет объект в БД.
        /// </summary>
        /// <param name="obj">Обновлённый объект.</param>
        /// <returns>Ничего не возвращает.</returns>
        public void Update(T obj)
        {
            T origin = context.Set<T>().FirstOrDefault(x => x.Id == obj.Id);
            if (origin != null)
            {
                context.Entry(origin).CurrentValues.SetValues(obj);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Удаляет объект из БД.
        /// </summary>
        /// <param name="obj">Удаляемый объект.</param>
        /// <returns>Ничего не возвращает.</returns>
        public void Delete(T obj)
        {
            context.Set<T>().Remove(obj);
            context.SaveChanges();
        }
    }
}