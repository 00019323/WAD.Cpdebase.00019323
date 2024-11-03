namespace WAD.Codebase._00019323.Models
{
    public class Newspaper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public DateTime Founded { get; set; }

        // Navigation property
        public ICollection<Article> Articles { get; set; }
    }
}
