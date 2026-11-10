using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using ModelBloger;

namespace DataAccessLayer
{
    /// <summary>
    /// Репозиторий для работы с сущностью "Блогер" через Dapper.
    /// </summary>
    public class DapperRepository : IRepository<Blogger>
    {
        private readonly string connectionString;

        /// <summary>
        /// Конструктор репозитория Dapper.
        /// </summary>
        /// <param name="connectionString">Строка подключения к БД.</param>
        /// <returns>Ничего не возвращает.</returns>
        public DapperRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Добавляет блогера в БД.
        /// </summary>
        /// <param name="obj">Блогер для добавления.</param>
        /// <returns>Ничего не возвращает.</returns>
        public void Create(Blogger obj)
        {
            using var db = new SqlConnection(connectionString);
            string sql = "INSERT INTO Bloggers (Id, Name, Subscribers, Platform, Topic) " +
                         "VALUES (@Id, @Name, @Subscribers, @Platform, @Topic)";
            db.Execute(sql, obj);
        }

        /// <summary>
        /// Возвращает всех блогеров из БД.
        /// </summary>
        /// <returns>Список блогеров.</returns>
        public IEnumerable<Blogger> ReadAll()
        {
            using var db = new SqlConnection(connectionString);
            string sql = "SELECT * FROM Bloggers";
            return db.Query<Blogger>(sql).ToList();
        }

        /// <summary>
        /// Возвращает блогера по ID.
        /// </summary>
        /// <param name="id">ID блогера.</param>
        /// <returns>Блогер или null.</returns>
        public Blogger ReadById(int id)
        {
            using var db = new SqlConnection(connectionString);
            string sql = "SELECT * FROM Bloggers WHERE Id = @id";
            return db.QueryFirstOrDefault<Blogger>(sql, new { id });
        }

        /// <summary>
        /// Обновляет данные блогера в БД.
        /// </summary>
        /// <param name="obj">Обновлённый блогер.</param>
        /// <returns>Ничего не возвращает.</returns>
        public void Update(Blogger obj)
        {
            using var db = new SqlConnection(connectionString);
            string sql = "UPDATE Bloggers SET Name = @Name, Subscribers = @Subscribers, " +
                         "Platform = @Platform, Topic = @Topic WHERE Id = @Id";
            db.Execute(sql, obj);
        }

        /// <summary>
        /// Удаляет блогера из БД.
        /// </summary>
        /// <param name="obj">Удаляемый блогер.</param>
        /// <returns>Ничего не возвращает.</returns>
        public void Delete(Blogger obj)
        {
            using var db = new SqlConnection(connectionString);
            string sql = "DELETE FROM Bloggers WHERE Id = @Id";
            db.Execute(sql, obj);
        }
    }
}