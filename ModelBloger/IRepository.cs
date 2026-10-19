using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBloger
{
    /// <summary>
    /// Интерфейс репозитория — набор CRUD-операций над сущностью.
    /// </summary>
    /// <typeparam name="T">Тип сущности (реализующий IDomainObject).</typeparam>
    public interface IRepository<T> where T : IDomainObject, new()
    {
        /// <summary>Добавить запись в БД.</summary>
        void Create(T obj);

        /// <summary>Прочитать все записи.</summary>
        IEnumerable<T> ReadAll();

        /// <summary>Прочитать запись по ID.</summary>
        T ReadById(int id);

        /// <summary>Обновить запись.</summary>
        void Update(T obj);

        /// <summary>Удалить запись.</summary>
        void Delete(T obj);
    }
}
