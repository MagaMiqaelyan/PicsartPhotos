namespace PicsartPhotos
{
    public class Photo
    {
        public string ID { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string[] Tags { get; set; }
        public bool Mature { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Date { get; set; }
        public User User { get; set; }
        public string Type { get; set; }
        public bool Public { get; set; }
        public int LikesCount { get; set; }
        public int ViewsCount { get; set; }
        public int CommentsCount { get; set; }
        public int StreamsCount { get; set; }
        public int ForksCount { get; set; }
        public int SourcesCount { get; set; }
        public bool ShowEditHistory { get; set; }
        public bool HasSimilars { get; set; }
    }
}
