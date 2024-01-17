namespace FoodJournalWebApp.Models
{
    public class PhysiologicalFeedback
    {
        public int Id { get; set; }
        public string Sentiment { get; set; } = string.Empty;
        public string Descriptor { get; set; } = string.Empty;
    }
}
