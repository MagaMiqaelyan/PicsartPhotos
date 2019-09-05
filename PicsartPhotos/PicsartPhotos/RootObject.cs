using System.Collections.Generic;

namespace PicsartPhotos
{
    public class RootObject
    {
        public string Success { get; set; }
        public int Total { get; set; }
        public string[] Metadata { get; set; }
        public List<Photo> Resoponse { get; set; }
    }
}
