using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ModelBloger
{
    public class Blogger
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
