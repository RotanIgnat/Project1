using System.Collections.Generic;
using ModelBloger;

namespace DataAccessLayer
{
    /// <summary>
    /// Интерфейс репозитория — набор CRUD-операций над сущностью.
    /// </summary>
    /// <typeparam name="T">Тип сущности (реализующий IDomainObject).</typeparam>
    public interface IRepository<T> where T : IDomainObject, new()
    {
        /// <summary>
        /// Добавить запись в БД.
        /// </summary>
        /// <param name="obj">Объект для добавления.</param>
        /// <returns>Ничего не возвращает.</returns>
        void Create(T obj);

        /// <summary>
        /// Прочитать все записи.
        /// </summary>
        /// <returns>Список всех объектов.</returns>
        IEnumerable<T> ReadAll();

        /// <summary>
        /// Прочитать запись по ID.
        /// </summary>
        /// <param name="id">ID искомого объекта.</param>
        /// <returns>Объект или null, если не найден.</returns>
        T ReadById(int id);

        /// <summary>
        /// Обновить запись.
        /// </summary>
        /// <param name="obj">Обновлённый объект.</param>
        /// <returns>Ничего не возвращает.</returns>
        void Update(T obj);

        /// <summary>
        /// Удалить запись.
        /// </summary>
        /// <param name="obj">Удаляемый объект.</param>
        /// <returns>Ничего не возвращает.</returns>
        void Delete(T obj);
    }
}