namespace Aujourdhui.ViewModels
{
    public class IngredientVM
    {
        #region Constant
        public const double CaloriesPerProtein = 4;
        public const double CaloriesPerFat = 9;
        public const double CaloriesPerCarbohydrates = 4.1;
        public const double CaloriesPerAlcohol = 7;
        #endregion

        #region Computed
        public double TotalProteinCalories => Protein * CaloriesPerProtein;
        public double TotalFatCalories => Fat * CaloriesPerFat;
        public double TotalCarbohydratesCalories => Carbohydrates * CaloriesPerCarbohydrates;
        public double TotalAlcoholCalories => Alcohol * CaloriesPerAlcohol;
        public double TotalCalories => TotalProteinCalories + TotalFatCalories + TotalCarbohydratesCalories + TotalAlcoholCalories;
        #endregion


        public string Name { get; set; }
        public int ExpirationInDays { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double Carbohydrates { get; set; }
        public double Alcohol { get; set; }
        public double Calories { get; set; }
        public int FirmID { get; set; }
        //public Firm Firm { get; set; }

        //public ICollection<PurchasedIngredient> PurchasedIngredients { get; set; }
    }
}
