namespace sweetshops.Model
{
    public class GroupDish : EFModel
    {
        public List<Dish> Dishs { get; set; } = new List<Dish>();
        public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    }
}
