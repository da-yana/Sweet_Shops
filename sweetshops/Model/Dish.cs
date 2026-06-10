using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace sweetshops.Model
{
    public class Dish : EFModel
    {
        public GroupDish GroupDish { get; set; } = new();

        [Required(ErrorMessage = "Название блюда обязательно")]
        [StringLength(100, ErrorMessage = "Название не может превышать 100 символов")]
        public string DishName { get; set; } = "";

        [Required(ErrorMessage = "Цена обязательна")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Цена должна быть положительной")]
        [JsonIgnore]
        public decimal Price { get; set; }

        [StringLength(500, ErrorMessage = "Описание не может превышать 500 символов")]
        public string DescriptionDish { get; set; } = "";

        [StringLength(200, ErrorMessage = "Ингредиенты не могут превышать 200 символов")]
        [JsonIgnore]
        public string Ingredients { get; set; } = "";

        [Range(1, 1440, ErrorMessage = "Время приготовления должно быть от 1 до 1440 минут")]
        [JsonIgnore]
        public int CookingTimeMinutes { get; set; }

        [Required(ErrorMessage = "Укажите группу блюда")]
        public int GroupDishId { get; set; }

        [StringLength(200, ErrorMessage = "Название не может превышать 200 символов")]
        public string? Title { get; set; }
    }
}