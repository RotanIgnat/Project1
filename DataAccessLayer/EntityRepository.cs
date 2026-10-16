using ModelBloger;
using ModelBloger.ModelBloger;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    /// <summary>
    /// Репозиторий на Entity Framework.
    /// </summary>
    /// <typeparam name="T">Тип сущности.</typeparam>
    public class EntityRepository<T> : IRepository<T> where T : class, IDomainObject, new()
    {
        private readonly DataContext context;

        /// <summary>Конструктор.</summary>
        public EntityRepository()
        {
            context = new DataContext();
        }

        /// <summary>Добавляет объект в БД.</summary>
        /// <param name="obj">Объект для добавления.</param>
        public void Create(T obj)
        {
            context.Set<T>().Add(obj);
            context.SaveChanges();
        }

        /// <summary>Возвращает все объекты.</summary>
        /// <returns>Список объектов.</returns>
        public IEnumerable<T> ReadAll()
        {
            return context.Set<T>().ToList();
        }

        /// <summary>Возвращает объект по ID.</summary>
        /// <param name="id">ID объекта.</param>
        /// <returns>Объект или null.</returns>
        public T ReadById(int id)
        {
            return context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        /// <summary>Обновляет объект.</summary>
        /// <param name="obj">Обновлённый объект.</param>
        public void Update(T obj)
        {
            T origin = context.Set<T>().FirstOrDefault(x => x.Id == obj.Id);
            if (origin != null)
            {
                context.Entry(origin).CurrentValues.SetValues(obj);
                context.SaveChanges();
            }
        }

        /// <summary>Удаляет объект.</summary>
        /// <param name="obj">Удаляемый объект.</param>
        public void Delete(T obj)
        {
            context.Set<T>().Remove(obj);
            context.SaveChanges();
        }
    }
}