namespace FoodJournalWebApp.Models
{
    public class WellnessCheck
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public PhysiologicalFeedback PhysiologicalFeedback { get; set; }
    }
}
