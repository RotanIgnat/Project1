using System.Collections.Generic;
using ModelBloger;

namespace BusinessLogic
{
    /// <summary>
    /// Класс бизнес-логики
    /// </summary>
    public class Logic : ILogic
    {
        private readonly IBloggerService _bloggerService;
        private readonly ISortFilterService _sortFilterService;

        public Logic(IBloggerService bloggerService, ISortFilterService sortFilterService)
        {
            _bloggerService = bloggerService;
            _sortFilterService = sortFilterService;
        }

        // Делегируем CRUD
        public void AddBlogger(Blogger blogger) => _bloggerService.AddBlogger(blogger);
        public void RemoveBlogger(int id) => _bloggerService.RemoveBlogger(id);
        public void Change(string name, int id, int subscribers, string platform, string topic) => _bloggerService.Change(name, id, subscribers, platform, topic);
        public bool IdExists(int id) => _bloggerService.IdExists(id);
        public Blogger? FindById(int id) => _bloggerService.FindById(id);
        public List<Blogger> GetAllBloggers() => _bloggerService.GetAllBloggers();

        // Делегируем сортировку
        public void FilterByPlatform(string platform) => _sortFilterService.FilterByPlatform(platform);
        public void ClearFilter() => _sortFilterService.ClearFilter();
        public string? GetCurrentFilter() => _sortFilterService.GetCurrentFilter();
        public void SortSubscribers() => _sortFilterService.SortSubscribers();
        public void SortSubscribersWithPlatformPriority(string targetPlatform) => _sortFilterService.SortSubscribersWithPlatformPriority(targetPlatform);
        public long GetSubscribersByPlatform(string platform) => _sortFilterService.GetSubscribersByPlatform(platform);
        public List<Blogger> ReadTable() => _sortFilterService.ReadTable();
    }
}