namespace FoodJournalWebApp.Models
{
    public class Day
    {
        public int Id { get; set; }
        public List<Meal>? Meals { get; set; }
        public DateTime Date { get; set; }
        public WellnessCheck? DailyWellnessCheck { get; set; } = null;
    }
}
