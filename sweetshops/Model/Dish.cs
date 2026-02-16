namespace sweetshops.Model
{
    public class Dish : EFModel
    {
        public string? CategoriesDish  { get; set; }
        public int Price { get; set; }
        public int CookingTime { get; set; }

    }
}
