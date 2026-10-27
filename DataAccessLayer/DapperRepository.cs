using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using ModelBloger;

namespace DataAccessLayer
{
    /// <summary>
    /// Репозиторий на Dapper. Работает через SQL-запросы.
    /// </summary>
    /// <typeparam name="T">Тип сущности.</typeparam>
    public class DapperRepository<T> : IRepository<T> where T : IDomainObject, new()
    {
        private readonly string connectionString;
        private readonly string tableName;

        /// <summary>
        /// Конструктор репозитория Dapper.
        /// </summary>
        /// <param name="connectionString">Строка подключения к БД.</param>
        /// <param name="tableName">Имя таблицы (например, "Bloggers").</param>
        /// <returns>Ничего не возвращает.</returns>
        public DapperRepository(string connectionString, string tableName)
        {
            this.connectionString = connectionString;
            this.tableName = tableName;
        }

        /// <summary>
        /// Добавляет запись в БД.
        /// </summary>
        /// <param name="obj">Объект для добавления.</param>
        /// <returns>Ничего не возвращает.</returns>
        public void Create(T obj)
        {
            using var db = new SqlConnection(connectionString);
            // ИСПРАВЛЕНО: добавлен Id и @Id
            string sql = $"INSERT INTO {tableName} (Id, Name, Subscribers, Platform, Topic) " +
                         "VALUES (@Id, @Name, @Subscribers, @Platform, @Topic)";
            db.Execute(sql, obj);
        }

        /// <summary>
        /// Возвращает все записи из БД.
        /// </summary>
        /// <returns>Список объектов.</returns>
        public IEnumerable<T> ReadAll()
        {
            using var db = new SqlConnection(connectionString);
            string sql = $"SELECT * FROM {tableName}";
            return db.Query<T>(sql).ToList();
        }

        /// <summary>
        /// Возвращает запись по ID.
        /// </summary>
        /// <param name="id">ID записи.</param>
        /// <returns>Объект или null.</returns>
        public T ReadById(int id)
        {
            using var db = new SqlConnection(connectionString);
            string sql = $"SELECT * FROM {tableName} WHERE Id = @id";
            return db.QueryFirstOrDefault<T>(sql, new { id });
        }

        /// <summary>
        /// Обновляет запись в БД.
        /// </summary>
        /// <param name="obj">Обновлённый объект.</param>
        /// <returns>Ничего не возвращает.</returns>
        public void Update(T obj)
        {
            using var db = new SqlConnection(connectionString);
            string sql = $"UPDATE {tableName} SET Name = @Name, Subscribers = @Subscribers, " +
                         "Platform = @Platform, Topic = @Topic WHERE Id = @Id";
            db.Execute(sql, obj);
        }

        /// <summary>
        /// Удаляет запись из БД.
        /// </summary>
        /// <param name="obj">Удаляемый объект.</param>
        /// <returns>Ничего не возвращает.</returns>
        public void Delete(T obj)
        {
            using var db = new SqlConnection(connectionString);
            string sql = $"DELETE FROM {tableName} WHERE Id = @Id";
            db.Execute(sql, obj);
        }
    }
}