namespace ModelBloger
{
    /// <summary>
    /// Базовый интерфейс для сущностей предметной области.
    /// Требует наличие свойства Id.
    /// </summary>
    public interface IDomainObject
    {
        /// <summary>
        /// Уникальный идентификатор сущности.
        /// </summary>
        int Id { get; set; }
    }

    /// <summary>
    /// Сущность "Блогер".
    /// </summary>
    public class Blogger : IDomainObject
    {
        /// <summary>Имя или никнейм блогера.</summary>
        public string Name { get; set; }

        /// <summary>Уникальный идентификатор блогера.</summary>
        public int Id { get; set; }

        /// <summary>Количество подписчиков.</summary>
        public int Subscribers { get; set; }

        /// <summary>Платформа (например, YouTube, Twitch).</summary>
        public string Platform { get; set; }

        /// <summary>Тематика канала (например, Gaming, Tech).</summary>
        public string Topic { get; set; }

        /// <summary>
        /// Конструктор с параметрами для создания блогера.
        /// </summary>
        /// <param name="id">Уникальный идентификатор.</param>
        /// <param name="name">Имя блогера.</param>
        /// <param name="subscribers">Количество подписчиков.</param>
        /// <param name="platform">Платформа.</param>
        /// <param name="topic">Тематика.</param>
        /// <returns>Ничего не возвращает.</returns>
        public Blogger(int id, string name, int subscribers, string platform, string topic)
        {
            Name = name;
            Id = id;
            Subscribers = subscribers;
            Platform = platform;
            Topic = topic;
        }

        /// <summary>
        /// Пустой конструктор, необходимый для Entity Framework.
        /// </summary>
        /// <returns>Ничего не возвращает.</returns>
        public Blogger() { }
    }
}