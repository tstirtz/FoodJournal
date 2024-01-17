using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoodJournalWebApp.Models;

namespace FoodJournalWebApp.Data
{
    public class FoodJournalWebAppContext : DbContext
    {
        public FoodJournalWebAppContext (DbContextOptions<FoodJournalWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<FoodJournalWebApp.Models.PhysiologicalFeedback> PhysiologicalFeedback { get; set; } = default!;

        public DbSet<FoodJournalWebApp.Models.WellnessCheck> WellnessCheck { get; set; } = default!;

        public DbSet<FoodJournalWebApp.Models.Ingredient> Ingredient { get; set; } = default!;

        public DbSet<FoodJournalWebApp.Models.Meal> Meal { get; set; } = default!;

        public DbSet<FoodJournalWebApp.Models.Day> Day { get; set; } = default!;
    }
}
