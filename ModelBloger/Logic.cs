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

        /// <summary>
        /// Добавляет нового блогера в список.
        /// </summary>
        /// <param name="blogger">Блогер для добавления.</param>
        public void AddBlogger(Blogger blogger)
        {
            bloggers.Add(blogger);
        }

        /// <summary>
        /// Удаляет блогера по его ID, если он существует.
        /// </summary>
        /// <param name="id">ID блогера для удаления.</param>
        public void RemoveBlogger(int id)
        {
            Blogger blogger = bloggers.Find(x => x.Id == id);
            if (blogger != null)
            {
                bloggers.Remove(blogger);
            }
        }

        /// <summary>
        /// Изменяет данные блогера по его ID.
        /// </summary>
        /// <param name="name">Новое имя блогера.</param>
        /// <param name="id">ID блогера для изменения.</param>
        /// <param name="subscribers">Новое количество подписчиков.</param>
        /// <param name="platform">Новая платформа.</param>
        /// <param name="topic">Новая тематика.</param>
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
        /// Возвращает весь список блогеров.
        /// </summary>
        /// <returns>Список блогеров.</returns>
        public List<Blogger> ReadTable()
        {
            return bloggers;
        }

        /// <summary>
        /// Сортирует блогеров по убыванию числа подписчиков.
        /// </summary>
        public void SortSubscribers()
        {
            bloggers.Sort((x, y) => y.Subscribers.CompareTo(x.Subscribers));
        }

        /// <summary>
        /// Двухуровневая сортировка: сначала блогеры указанной платформы, затем по подписчикам.
        /// </summary>
        /// <param name="targetPlatform">Платформа, которая должна быть вверху.</param>
        public void SortSubscribersWithPlatformPriority(string targetPlatform)
        {
            bloggers = bloggers
                .OrderByDescending(b => b.Platform.Equals(targetPlatform, StringComparison.OrdinalIgnoreCase))
                .ThenByDescending(b => b.Subscribers)
                .ToList();
        }

        /// <summary>
        /// Возвращает список блогеров, у которых платформа совпадает с указанной.
        /// </summary>
        /// <param name="platform">Название платформы для фильтрации.</param>
        /// <returns>Список блогеров только этой платформы.</returns>
        public List<Blogger> FilterByPlatform(string platform)
        {
            List<Blogger> result = new List<Blogger>();

            foreach (Blogger b in bloggers)
            {
                if (b.Platform.Equals(platform, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(b);
                }
            }

            return result;
        }

        /// <summary>
        /// Возвращает сумму подписчиков всех блогеров указанной платформы.
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