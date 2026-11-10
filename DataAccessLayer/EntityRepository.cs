using System.Collections.Generic;
using System.Linq;
using ModelBloger;

namespace DataAccessLayer
{
    /// <summary>
    /// Репозиторий для работы с сущностью "Блогер" через Entity Framework.
    /// </summary>
    public class EntityRepository : IRepository<Blogger>
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
        /// Добавляет блогера в БД.
        /// </summary>
        /// <param name="obj">Блогер для добавления.</param>
        /// <returns>Ничего не возвращает.</returns>
        public void Create(Blogger obj)
        {
            context.Bloggers.Add(obj);
            context.SaveChanges();
        }

        /// <summary>
        /// Возвращает всех блогеров из БД.
        /// </summary>
        /// <returns>Список блогеров.</returns>
        public IEnumerable<Blogger> ReadAll()
        {
            return context.Bloggers.ToList();
        }

        /// <summary>
        /// Возвращает блогера по ID.
        /// </summary>
        /// <param name="id">ID блогера.</param>
        /// <returns>Блогер или null.</returns>
        public Blogger ReadById(int id)
        {
            return context.Bloggers.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Обновляет данные блогера в БД.
        /// </summary>
        /// <param name="obj">Обновлённый блогер.</param>
        /// <returns>Ничего не возвращает.</returns>
        public void Update(Blogger obj)
        {
            Blogger origin = context.Bloggers.FirstOrDefault(x => x.Id == obj.Id);
            if (origin != null)
            {
                origin.Name = obj.Name;
                origin.Subscribers = obj.Subscribers;
                origin.Platform = obj.Platform;
                origin.Topic = obj.Topic;

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Удаляет блогера из БД.
        /// </summary>
        /// <param name="obj">Удаляемый блогер.</param>
        /// <returns>Ничего не возвращает.</returns>
        public void Delete(Blogger obj)
        {
            context.Bloggers.Remove(obj);
            context.SaveChanges();
        }
    }
}