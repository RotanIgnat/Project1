using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelBloger
{
    public class Logic
    {
        private List<Blogger> bloggers = new List<Blogger>()
        {
            new Blogger(1, "MrBeast", 310000000, "YouTube", "Entertainment"),
            new Blogger(2, "Kuplinov Play", 16200000, "YouTube", "Gaming"),
            new Blogger(3, "Wylsacom", 10100000, "YouTube", "Tech"),
            new Blogger(4, "xQc", 12000000, "Twitch", "Just Chatting"),
            new Blogger(5, "Buster", 3800000, "Twitch", "Gaming"),
            new Blogger(6, "CodeBeauty", 1500000, "YouTube", "Education"),
            new Blogger(7, "TechNews", 450000, "Telegram", "Tech"),
            new Blogger(8, "PewDiePie", 111000000, "YouTube", "Vlogs"),
            new Blogger(9, "Shroud", 10900000, "Twitch", "Shooters"),
            new Blogger(10, "PythonGuy", 120000, "Telegram", "Education")
        };

        private string currentFilterPlatform = null;

        /// <summary>
        /// Добавляет нового блогера в полный список.
        /// </summary>
        /// <param name="blogger">Блогер для добавления.</param>
        /// <returns>Ничего не возвращает.</returns>
        public void AddBlogger(Blogger blogger)
        {
            bloggers.Add(blogger);
        }

        /// <summary>
        /// Удаляет блогера по его ID из полного списка.
        /// </summary>
        /// <param name="id">ID блогера для удаления.</param>
        /// <returns>Ничего не возвращает.</returns>
        public void RemoveBlogger(int id)
        {
            Blogger blogger = bloggers.Find(x => x.Id == id);
            if (blogger != null)
            {
                bloggers.Remove(blogger);
            }
        }

        /// <summary>
        /// Изменяет данные блогера по его ID в полном списке.
        /// </summary>
        /// <param name="name">Новое имя блогера.</param>
        /// <param name="id">ID блогера для изменения.</param>
        /// <param name="subscribers">Новое количество подписчиков.</param>
        /// <param name="platform">Новая платформа.</param>
        /// <param name="topic">Новая тематика.</param>
        /// <returns>Ничего не возвращает.</returns>
        public void Change(
            string name,
            int id,
            int subscribers,
            string platform,
            string topic)
        {
            Blogger blogger = bloggers.Find(x => x.Id == id);
            if (blogger != null)
            {
                blogger.Name = name;
                blogger.Topic = topic;
                blogger.Subscribers = subscribers;
                blogger.Platform = platform;
            }
        }

        /// <summary>
        /// Проверяет, существует ли блогер с указанным ID.
        /// </summary>
        /// <param name="id">ID для проверки.</param>
        /// <returns>true — если блогер с таким ID есть, иначе false.</returns>
        public bool IdExists(int id)
        {
            return bloggers.Any(b => b.Id == id);
        }

        /// <summary>
        /// Ищет блогера по ID в полном списке.
        /// </summary>
        /// <param name="id">ID блогера.</param>
        /// <returns>Блогер с указанным ID или null, если не найден.</returns>
        public Blogger FindById(int id)
        {
            return bloggers.FirstOrDefault(b => b.Id == id);
        }

        /// <summary>
        /// Возвращает ПОЛНЫЙ список блогеров, без учёта фильтра.
        /// Используется для сортировок, поиска, подсчётов — всего, что должно работать на всей базе.
        /// </summary>
        /// <returns>Полный список блогеров.</returns>
        public List<Blogger> GetAllBloggers()
        {
            return bloggers;
        }

        /// <summary>
        /// Возвращает список блогеров для показа пользователю.
        /// Если установлен фильтр — только блогеров указанной платформы.
        /// </summary>
        /// <returns>Список блогеров с учётом фильтра.</returns>
        public List<Blogger> ReadTable()
        {
            if (currentFilterPlatform == null)
            {
                return bloggers;
            }

            List<Blogger> result = new List<Blogger>();

            foreach (Blogger b in bloggers)
            {
                if (b.Platform.Equals(currentFilterPlatform, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(b);
                }
            }

            return result;
        }

        /// <summary>
        /// Устанавливает фильтр по платформе. Список будет показывать только её блогеров.
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
        /// <returns>Название платформы или null, если фильтр не установлен.</returns>
        public string GetCurrentFilter()
        {
            return currentFilterPlatform;
        }

        /// <summary>
        /// Сортирует полный список блогеров по убыванию числа подписчиков и сбрасывает фильтр.
        /// </summary>
        /// <returns>Ничего не возвращает.</returns>
        public void SortSubscribers()
        {
            bloggers.Sort((x, y) => y.Subscribers.CompareTo(x.Subscribers));
            currentFilterPlatform = null;
        }

        /// <summary>
        /// Двухуровневая сортировка полного списка и сброс фильтра.
        /// </summary>
        /// <param name="targetPlatform">Платформа, которая должна быть вверху.</param>
        /// <returns>Ничего не возвращает.</returns>
        public void SortSubscribersWithPlatformPriority(string targetPlatform)
        {
            bloggers = bloggers
                .OrderByDescending(b => b.Platform.Equals(targetPlatform, StringComparison.OrdinalIgnoreCase))
                .ThenByDescending(b => b.Subscribers)
                .ToList();

            currentFilterPlatform = null;
        }

        /// <summary>
        /// Возвращает сумму подписчиков всех блогеров указанной платформы.
        /// Работает по полному списку, независимо от фильтра.
        /// </summary>
        /// <param name="platform">Название платформы.</param>
        /// <returns>Суммарное число подписчиков блогеров этой платформы.</returns>
        public long GetSubscribersByPlatform(string platform)
        {
            long total = 0;

            foreach (Blogger b in bloggers)
            {
                if (b.Platform.Equals(platform, StringComparison.OrdinalIgnoreCase))
                {
                    total += b.Subscribers;
                }
            }

            return total;
        }
    }
}