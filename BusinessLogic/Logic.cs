using System;
using System.Collections.Generic;
using System.Linq;
using ModelBloger;
using DataAccessLayer;

namespace BusinessLogic
{
    /// <summary>
    /// Класс бизнес-логики для управления блогерами.
    /// </summary>
    public class Logic
    {
        private readonly IRepository<Blogger> repository;

        /// <summary>
        /// Конструктор бизнес-логики.
        /// </summary>
        /// <param name="repository">Репозиторий для работы с данными.</param>
        public Logic(IRepository<Blogger> repository)
        {
            this.repository = repository;
        }

        // Переменные состояния для фильтрации и сортировки
        private string currentFilterPlatform = null;
        private bool sortBySubscribers = false;
        private string sortByPlatformPriority = null;

        /// <summary>
        /// Добавляет нового блогера в базу данных.
        /// </summary>
        /// <param name="blogger">Блогер для добавления.</param>
        /// <returns>Ничего не возвращает.</returns>
        public void AddBlogger(Blogger blogger)
        {
            repository.Create(blogger);
        }

        /// <summary>
        /// Удаляет блогера по его ID из базы данных.
        /// </summary>
        /// <param name="id">ID блогера для удаления.</param>
        /// <returns>Ничего не возвращает.</returns>
        public void RemoveBlogger(int id)
        {
            Blogger blogger = repository.ReadById(id);
            if (blogger != null)
            {
                repository.Delete(blogger);
            }
        }

        /// <summary>
        /// Изменяет данные блогера по его ID в базе данных.
        /// </summary>
        /// <param name="name">Новое имя блогера.</param>
        /// <param name="id">ID блогера для изменения.</param>
        /// <param name="subscribers">Новое количество подписчиков.</param>
        /// <param name="platform">Новая платформа.</param>
        /// <param name="topic">Новая тематика.</param>
        /// <returns>Ничего не возвращает.</returns>
        public void Change(string name, int id, int subscribers, string platform, string topic)
        {
            Blogger blogger = repository.ReadById(id);
            if (blogger != null)
            {
                blogger.Name = name;
                blogger.Topic = topic;
                blogger.Subscribers = subscribers;
                blogger.Platform = platform;

                repository.Update(blogger); // Обновляем только если нашли
            }
        }

        /// <summary>
        /// Проверяет, существует ли блогер с указанным ID.
        /// </summary>
        /// <param name="id">ID для проверки.</param>
        /// <returns>true — если блогер с таким ID есть, иначе false.</returns>
        public bool IdExists(int id)
        {
            return repository.ReadById(id) != null;
        }

        /// <summary>
        /// Ищет блогера по ID в полном списке.
        /// </summary>
        /// <param name="id">ID блогера.</param>
        /// <returns>Блогер с указанным ID или null, если не найден.</returns>
        public Blogger FindById(int id)
        {
            return repository.ReadById(id);
        }

        /// <summary>
        /// Возвращает ПОЛНЫЙ список блогеров, без учёта фильтра.
        /// </summary>
        /// <returns>Полный список блогеров.</returns>
        public List<Blogger> GetAllBloggers()
        {
            return repository.ReadAll().ToList();
        }

        /// <summary>
        /// Возвращает список блогеров для показа пользователю с учётом фильтра и сортировки.
        /// </summary>
        /// <returns>Список блогеров.</returns>
        public List<Blogger> ReadTable()
        {
            List<Blogger> list = repository.ReadAll().ToList();

            if (currentFilterPlatform != null)
            {
                List<Blogger> filteredList = new List<Blogger>();
                foreach (Blogger b in list)
                {
                    if (b.Platform.Equals(currentFilterPlatform, StringComparison.OrdinalIgnoreCase))
                    {
                        filteredList.Add(b);
                    }
                }
                list = filteredList;
            }

            if (sortByPlatformPriority != null)
            {
                list = list.OrderByDescending(b => b.Platform.Equals(sortByPlatformPriority, StringComparison.OrdinalIgnoreCase))
                           .ThenByDescending(b => b.Subscribers)
                           .ToList();
            }
            else if (sortBySubscribers)
            {
                list = list.OrderByDescending(b => b.Subscribers).ToList();
            }

            return list;
        }

        /// <summary>
        /// Устанавливает фильтр по платформе.
        /// </summary>
        /// <param name="platform">Название платформы.</param>
        /// <returns>Ничего не возвращает.</returns>
        public void FilterByPlatform(string platform)
        {
            currentFilterPlatform = platform;
        }

        /// <summary>
        /// Сбрасывает фильтр по платформе.
        /// </summary>
        /// <returns>Ничего не возвращает.</returns>
        public void ClearFilter()
        {
            currentFilterPlatform = null;
        }

        /// <summary>
        /// Возвращает текущую платформу, по которой установлен фильтр.
        /// </summary>
        /// <returns>Название платформы или null.</returns>
        public string GetCurrentFilter()
        {
            return currentFilterPlatform;
        }

        /// <summary>
        /// Включает сортировку по убыванию подписчиков.
        /// </summary>
        /// <returns>Ничего не возвращает.</returns>
        public void SortSubscribers()
        {
            sortBySubscribers = true;
            sortByPlatformPriority = null;
            currentFilterPlatform = null;
        }

        /// <summary>
        /// Включает двухуровневую сортировку.
        /// </summary>
        /// <param name="targetPlatform">Платформа, которая должна быть вверху.</param>
        /// <returns>Ничего не возвращает.</returns>
        public void SortSubscribersWithPlatformPriority(string targetPlatform)
        {
            sortByPlatformPriority = targetPlatform;
            sortBySubscribers = false;
            currentFilterPlatform = null;
        }

        /// <summary>
        /// Возвращает сумму подписчиков всех блогеров указанной платформы.
        /// </summary>
        /// <param name="platform">Название платформы.</param>
        /// <returns>Суммарное число подписчиков.</returns>
        public long GetSubscribersByPlatform(string platform)
        {
            return repository.ReadAll()
                .Where(b => b.Platform.Equals(platform, StringComparison.OrdinalIgnoreCase))
                .Sum(b => (long)b.Subscribers);
        }
    }
}