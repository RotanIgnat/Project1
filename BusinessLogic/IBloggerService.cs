using System.Collections.Generic;
using ModelBloger;

namespace BusinessLogic
{
    /// <summary>
    /// Интерфейс для CRUD-операций с блогерами.
    /// </summary>
    public interface IBloggerService
    {
        /// <summary>
        /// Добавляет нового блогера в базу данных.
        /// </summary>
        /// <param name="blogger">Блогер для добавления.</param>
        /// <returns>Ничего не возвращает.</returns>
        void AddBlogger(Blogger blogger);

        /// <summary>
        /// Удаляет блогера по его ID из базы данных.
        /// </summary>
        /// <param name="id">ID блогера для удаления.</param>
        /// <returns>Ничего не возвращает.</returns>
        void RemoveBlogger(int id);

        /// <summary>
        /// Изменяет данные блогера по его ID в базе данных.
        /// </summary>
        /// <param name="name">Новое имя блогера.</param>
        /// <param name="id">ID блогера для изменения.</param>
        /// <param name="subscribers">Новое количество подписчиков.</param>
        /// <param name="platform">Новая платформа.</param>
        /// <param name="topic">Новая тематика.</param>
        /// <returns>Ничего не возвращает.</returns>
        void Change(string name, int id, int subscribers, string platform, string topic);

        /// <summary>
        /// Проверяет, существует ли блогер с указанным ID.
        /// </summary>
        /// <param name="id">ID для проверки.</param>
        /// <returns>true — если блогер с таким ID есть, иначе false.</returns>
        bool IdExists(int id);

        /// <summary>
        /// Ищет блогера по ID в полном списке.
        /// </summary>
        /// <param name="id">ID блогера.</param>
        /// <returns>Блогер с указанным ID или null, если не найден.</returns>
        Blogger? FindById(int id);

        /// <summary>
        /// Возвращает ПОЛНЫЙ список блогеров, без учёта фильтра.
        /// </summary>
        /// <returns>Полный список блогеров.</returns>
        List<Blogger> GetAllBloggers();
    }
}