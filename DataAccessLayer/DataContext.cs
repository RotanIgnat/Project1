using Microsoft.EntityFrameworkCore;
using ModelBloger;
using System.Configuration;

namespace DataAccessLayer
{
    /// <summary>
    /// Контекст базы данных для Entity Framework.
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>Таблица блогеров.</summary>
        public DbSet<Blogger> Bloggers { get; set; }

        /// <summary>
        /// Конструктор: создаёт БД, если её нет.
        /// </summary>
        /// <returns>Ничего не возвращает.</returns>
        public DataContext()
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Настройка подключения к БД.
        /// </summary>
        /// <param name="optionsBuilder">Построитель опций EF.</param>
        /// <returns>Ничего не возвращает.</returns>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConfigurationManager
                .ConnectionStrings["DefaultConnection"]
                .ConnectionString;

            optionsBuilder.UseSqlServer(connectionString);
        }

        /// <summary>
        /// Настройка модели: говорим EF, что Id задаём мы сами, а не БД.
        /// </summary>
        /// <param name="modelBuilder">Построитель модели EF.</param>
        /// <returns>Ничего не возвращает.</returns>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blogger>()
                .Property(b => b.Id)
                .ValueGeneratedNever();
        }
    }
}