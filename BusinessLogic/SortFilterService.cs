using System;
using System.Collections.Generic;
using System.Linq;
using ModelBloger;
using DataAccessLayer;

namespace BusinessLogic
{
    /// <summary>
    /// Сервис для фильтрации и сортировки блогеров.
    /// </summary>
    public class SortFilterService : ISortFilterService
    {
        private readonly IRepository<Blogger> repository;
        private string? currentFilterPlatform = null;
        private bool sortBySubscribers = false;
        private string? sortByPlatformPriority = null;

        public SortFilterService(IRepository<Blogger> repository)
        {
            this.repository = repository;
        }

        public void FilterByPlatform(string platform) => currentFilterPlatform = platform;
        public void ClearFilter() => currentFilterPlatform = null;
        public string? GetCurrentFilter() => currentFilterPlatform;

        public void SortSubscribers()
        {
            sortBySubscribers = true;
            sortByPlatformPriority = null;
            currentFilterPlatform = null;
        }

        public void SortSubscribersWithPlatformPriority(string targetPlatform)
        {
            sortByPlatformPriority = targetPlatform;
            sortBySubscribers = false;
            currentFilterPlatform = null;
        }

        public long GetSubscribersByPlatform(string platform)
        {
            return repository.ReadAll()
                .Where(b => b.Platform.Equals(platform, StringComparison.OrdinalIgnoreCase))
                .Sum(b => (long)b.Subscribers);
        }

        public List<Blogger> ReadTable()
        {
            List<Blogger> list = repository.ReadAll().ToList();

            if (currentFilterPlatform != null)
            {
                list = list.Where(b => b.Platform.Equals(currentFilterPlatform, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (sortByPlatformPriority != null)
            {
                list = list.OrderByDescending(b => b.Platform.Equals(sortByPlatformPriority, StringComparison.OrdinalIgnoreCase))
                           .ThenByDescending(b => b.Subscribers).ToList();
            }
            else if (sortBySubscribers)
            {
                list = list.OrderByDescending(b => b.Subscribers).ToList();
            }

            return list;
        }
    }
}