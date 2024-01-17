namespace FoodJournalWebApp.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public required List<Ingredient> Ingredients { get; set; }
        public DateTime Time { get; set; }
        public WellnessCheck? WellnessCheck { get; set; } = null;
    }
}
