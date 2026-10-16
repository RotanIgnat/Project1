using ModelBloger.ModelBloger;

namespace ModelBloger
{
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
    }
    public class Blogger : IDomainObject
    {
        public string Name { get; set; }
        public int Id {  get; set; }
        public int Subscribers { get; set; }
        public string Platform { get; set; }
        public string Topic { get; set; }
        public Blogger(
            int id,
            string name,
            int subscribers,
            string platform,
            string topic
            )
        {
            Name = name;
            Id = id;
            Subscribers = subscribers;
            Platform = platform;
            Topic = topic;
        }
    }

}
