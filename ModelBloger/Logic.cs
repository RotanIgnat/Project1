using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModelBloger
{
    public class Logic
    {
        private List<Blogger> bloggers = new List<Blogger>()
        {
            new Blogger(1, "MrBeast", 310000000, "YouTube", "Entertainment"),
            new Blogger(2, "Kuplinov Play", 16200000, "YouTube", "Gaming"),
            new Blogger(3, "Wylsacom", 10100000, "YouTube", "Tech"),
            new Blogger(4, "xQc", 12000000, "Twitch", "Just Chatting"),
            new Blogger(5, "Buster", 3800000, "Twitch", "Gaming"),
            new Blogger(6, "CodeBeauty", 1500000, "YouTube", "Education"),
            new Blogger(7, "TechNews", 450000, "Telegram", "Tech"),
            new Blogger(8, "PewDiePie", 111000000, "YouTube", "Vlogs"),
            new Blogger(9, "Shroud", 10900000, "Twitch", "Shooters"),
            new Blogger(10, "PythonGuy", 120000, "Telegram", "Education")
        };

        public void AddBlogger(Blogger blogger)
        {
            bloggers.Add(blogger);
        }
        public void RemoveBlogger(int id)
        {
            Blogger blogger = bloggers.Find(x => x.Id == id);
            if (blogger != null)
            {
                bloggers.Remove(blogger);
            }
        }
        public void Change(
            string name,
            int id,
            int subscribers,
            string platform,
            string topic)
        {
            Blogger blogger = bloggers.Find(x => x.Id == id);
            if (blogger != null)
            {
                blogger.Name = name;
                blogger.Topic = topic;
                blogger.Subscribers = subscribers;
                blogger.Platform = platform;
            }
        }
        public bool IdExists(int id)
        {
            return bloggers.Any(b => b.Id == id);
        }
        public List<Blogger> ReadTable()
        {
            return bloggers;
        }
        public void SortSubscribers()
        {
            bloggers.Sort((x, y) => y.Subscribers.CompareTo(x.Subscribers));
        }
        public void FilterByPlatform(string platform)
        {
            bloggers.Sort((x, y) =>
            {
                bool x2 = x.Platform.Equals(platform, StringComparison.OrdinalIgnoreCase);
                bool y2 = y.Platform.Equals(platform, StringComparison.OrdinalIgnoreCase);
                return y2.CompareTo(x2);
            });
        }
        public void SortSubscribersWithPlatformPriority(string targetPlatform)
        {
            bloggers = bloggers
                .OrderByDescending(b => b.Platform.Equals(targetPlatform, StringComparison.OrdinalIgnoreCase))
                .ThenByDescending(b => b.Subscribers)
                .ToList();
        }
    }
}
