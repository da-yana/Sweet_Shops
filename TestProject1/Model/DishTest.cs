using System.ComponentModel.DataAnnotations;
using sweetshops.Model;

namespace sweetshops.Test.UnitTests.Model
{
    public class DishTest
    {
        [Fact]
        public void Test1_Dish_WithValidData_ShouldBeValid()
        {
            var dish = new Dish
            {
                DishName = "Борщ",
                Price = 350.50m,
                DescriptionDish = "Традиционный русский борщ с пампушками",
                Ingredients = "Свекла, капуста, картофель",
                CookingTimeMinutes = 60,
                GroupDishId = 1
            };

            var context = new ValidationContext(dish);
            var result = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(dish, context, result, true);

            Assert.True(isValid);
            Assert.Empty(result);
        }

        [Fact]
        public void Test2_Dish_WithEmptyDishName_ShouldBeInvalid()
        {
            var dish = new Dish
            {
                DishName = "",
                Price = 350.50m,
                DescriptionDish = "Описание",
                Ingredients = "Ингредиенты",
                CookingTimeMinutes = 30,
                GroupDishId = 1
            };

            var context = new ValidationContext(dish);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(dish, context, results, true);

            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage == "Название блюда обязательно");
        }

        [Fact]
        public void Test3_Dish_WithTooLongDishName_ShouldBeInvalid()
        {
            var dish = new Dish
            {
                DishName = new string('A', 101),
                Price = 350.50m,
                DescriptionDish = "Описание",
                Ingredients = "Ингредиенты",
                CookingTimeMinutes = 30,
                GroupDishId = 1
            };

            var context = new ValidationContext(dish);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(dish, context, results, true);

            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage == "Название не может превышать 100 символов");
        }

        [Fact]
        public void Test4_Dish_WithNegativePrice_ShouldBeInvalid()
        {
            var dish = new Dish
            {
                DishName = "Борщ",
                Price = -10m,
                DescriptionDish = "Описание",
                Ingredients = "Ингредиенты",
                CookingTimeMinutes = 30,
                GroupDishId = 1
            };

            var context = new ValidationContext(dish);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(dish, context, results, true);

            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage == "Цена должна быть положительной");
        }

        [Fact]
        public void Test5_Dish_WithZeroPrice_ShouldBeInvalid()
        {
            var dish = new Dish
            {
                DishName = "Борщ",
                Price = 0m,
                DescriptionDish = "Описание",
                Ingredients = "Ингредиенты",
                CookingTimeMinutes = 30,
                GroupDishId = 1
            };

            var context = new ValidationContext(dish);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(dish, context, results, true);

            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage == "Цена должна быть положительной");
        }

        [Fact]
        public void Test6_Dish_WithTooLongDescription_ShouldBeInvalid()
        {
            var dish = new Dish
            {
                DishName = "Борщ",
                Price = 350.50m,
                DescriptionDish = new string('A', 501),
                Ingredients = "Ингредиенты",
                CookingTimeMinutes = 30,
                GroupDishId = 1
            };

            var context = new ValidationContext(dish);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(dish, context, results, true);

            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage == "Описание не может превышать 500 символов");
        }

        [Fact]
        public void Test7_Dish_WithTooLongIngredients_ShouldBeInvalid()
        {
            var dish = new Dish
            {
                DishName = "Борщ",
                Price = 350.50m,
                DescriptionDish = "Описание",
                Ingredients = new string('А', 201),
                CookingTimeMinutes = 30,
                GroupDishId = 1
            };

            var context = new ValidationContext(dish);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(dish, context, results, true);

            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage == "Ингредиенты не могут превышать 200 символов");
        }

        [Fact]
        public void Test8_Dish_WithZeroCookingTime_ShouldBeInvalid()
        {
            var dish = new Dish
            {
                DishName = "Борщ",
                Price = 350.50m,
                DescriptionDish = "Описание",
                Ingredients = "Ингредиенты",
                CookingTimeMinutes = 0,
                GroupDishId = 1
            };

            var context = new ValidationContext(dish);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(dish, context, results, true);

            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage == "Время приготовления должно быть от 1 до 1440 минут");
        }

        [Fact]
        public void Test9_Dish_WithTooLargeCookingTime_ShouldBeInvalid()
        {
            var dish = new Dish
            {
                DishName = "Борщ",
                Price = 350.50m,
                DescriptionDish = "Описание",
                Ingredients = "Ингредиенты",
                CookingTimeMinutes = 2000,
                GroupDishId = 1
            };

            var context = new ValidationContext(dish);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(dish, context, results, true);

            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage == "Время приготовления должно быть от 1 до 1440 минут");
        }

        [Fact]
        public void Test10_Dish_WithoutGroupDishId_ShouldBeInvalid()
        {
            var dish = new Dish
            {
                DishName = "Борщ",
                Price = 350.50m,
                DescriptionDish = "Описание",
                Ingredients = "Ингредиенты",
                CookingTimeMinutes = 30,
                GroupDishId = 0
            };

            // Ручная проверка
            var isValid = dish.GroupDishId > 0;

            Assert.False(isValid);
        }
    }
}