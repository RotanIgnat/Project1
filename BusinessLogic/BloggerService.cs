using System.Collections.Generic;
using System.Linq;
using ModelBloger;
using DataAccessLayer;

namespace BusinessLogic
{
    /// <summary>
    /// Сервис для работы с блогерами (CRUD).
    /// </summary>
    public class BloggerService : IBloggerService
    {
        private readonly IRepository<Blogger> repository;

        public BloggerService(IRepository<Blogger> repository)
        {
            this.repository = repository;
        }

        public void AddBlogger(Blogger blogger) => repository.Create(blogger);

        public void RemoveBlogger(int id)
        {
            var blogger = repository.ReadById(id);
            if (blogger != null) repository.Delete(blogger);
        }

        public void Change(string name, int id, int subscribers, string platform, string topic)
        {
            var blogger = repository.ReadById(id);
            if (blogger != null)
            {
                blogger.Name = name;
                blogger.Topic = topic;
                blogger.Subscribers = subscribers;
                blogger.Platform = platform;
                repository.Update(blogger);
            }
        }

        public bool IdExists(int id) => repository.ReadById(id) != null;
        public Blogger? FindById(int id) => repository.ReadById(id);
        public List<Blogger> GetAllBloggers() => repository.ReadAll().ToList();
    }
}