namespace ProjetoExemplo.Models
{

    public class LivrosViewModel
    {
        public string Query { get; set; }
        public List<VolumeInfo> Livros { get; set; }
    }

    public class Volume
    {
        public string Kind { get; set; }
        public string Id { get; set; }
        public string Etag { get; set; }
        public string SelfLink { get; set; }
        public VolumeInfo VolumeInfo { get; set; }
    }

    public class VolumeInfo
    {
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public string Publisher { get; set; }
        public string PublishedDate { get; set; }
        public string Description { get; set; }
        public List<IndustryIdentifier> IndustryIdentifiers { get; set; }
        public int PageCount { get; set; }
        public string Language { get; set; }
        public ImageLinks ImageLinks { get; set; }
    }

    public class IndustryIdentifier
    {
        public string Type { get; set; }
        public string Identifier { get; set; }
    }

    public class ImageLinks
    {
        public string SmallThumbnail { get; set; }
        public string Thumbnail { get; set; }
    }

    public class BooksResponse
    {
        public string Kind { get; set; }
        public int TotalItems { get; set; }
        public List<Volume> Items { get; set; }
    }

    
}