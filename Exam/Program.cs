using System;
using System.Collections.Generic;


namespace Exam
{
    // Класс представляет структуру данных для хранения информации о рецепте.
    class Recipe
    {
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> Instructions { get; set; }
    }

    // Класс представляет приложение для управления рецептами.
    class RecipeApp
    {
        private List<Recipe> recipes;

        // Конструктор класса RecipeApp. Инициализирует коллекцию рецептов.
        public RecipeApp()
        {
            recipes = new List<Recipe>();
        }

        // Метод для добавления новых рецептов в коллекцию.
        public void AddRecipe(params Recipe[] newRecipes)
        {
            foreach (var newRecipe in newRecipes)
            {
                recipes.Add(newRecipe);
                Console.WriteLine($"Рецепт '{newRecipe.Name}' успешно добавлен!");
            }
        }

        // Метод для просмотра списка всех рецептов.
        public void ViewAllRecipes()
        {
            Console.WriteLine("Список рецептов:");

            foreach (Recipe recipe in recipes)
            {
                Console.WriteLine($"- {recipe.Name}");
            }
        }

        // Метод для просмотра деталей конкретного рецепта.
        public void ViewRecipeDetails(string recipeName)
        {
            Recipe recipe = recipes.Find(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if (recipe != null)
            {
                Console.WriteLine($"Название: {recipe.Name}");
                Console.WriteLine("Ингредиенты:");
                foreach (string ingredient in recipe.Ingredients)
                {
                    Console.WriteLine($"- {ingredient}");
                }
                Console.WriteLine("Инструкции:");
                foreach (string instruction in recipe.Instructions)
                {
                    Console.WriteLine($"- {instruction}");
                }
            }
            else
            {
                Console.WriteLine($"Рецепт с названием '{recipeName}' не найден.");
            }
        }

        // Метод для поиска рецепта по названию.
        public void SearchRecipe()
        {
            Console.WriteLine("Введите название блюда для поиска:");
            string searchQuery = Console.ReadLine();

            Recipe recipe = recipes.Find(r => r.Name.Equals(searchQuery, StringComparison.OrdinalIgnoreCase));

            if (recipe != null)
            {
                ViewRecipeDetails(recipe.Name);
            }
            else
            {
                Console.WriteLine($"Рецепт с названием '{searchQuery}' не найден.");
            }
        }

        // Метод для удаления рецепта из коллекции.
        public void RemoveRecipe()
        {
            Console.WriteLine("Введите название рецепта, который хотите удалить:");
            string recipeName = Console.ReadLine();

            Recipe recipe = recipes.Find(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if (recipe != null)
            {
                recipes.Remove(recipe);
                Console.WriteLine($"Рецепт '{recipeName}' успешно удален.");
            }
            else
            {
                Console.WriteLine($"Рецепт с названием '{recipeName}' не найден.");
            }
        }
    }

    // Основной класс программы.
    class Program
    {
        // Точка входа в программу.
        static void Main()
        {
            // Создание экземпляра приложения для управления рецептами.
            RecipeApp recipeApp = new RecipeApp();

            // Инициализация нескольких рецептов для начальных данных.
            Recipe recipe1 = new Recipe
            {
                Name = "Салат Цезарь",
                Ingredients = new List<string> { "Куриное филе", "Салат Романо", "Хлебные кубики", "Пармезан", "Соус Цезарь" },
                Instructions = new List<string>
            {
                "Подготовьте ингредиенты: обжарьте куриное филе, подрумяньте хлебные кубики.",
                "На большой тарелке уложите листья салата Романо.",
                "Выложите сверху кусочки жареного куриного филе, хлебные кубики, посыпьте Пармезаном.",
                "Полейте салат соусом Цезарь и аккуратно перемешайте."
            }
            };

            Recipe recipe2 = new Recipe
            {
                Name = "Греческий суп",
                Ingredients = new List<string> { "Помидоры", "Огурцы", "Красный лук", "Перец", "Оливки", "Фета", "Оливковое масло" },
                Instructions = new List<string>
            {
                "Нарежьте помидоры, огурцы, красный лук и перец.",
                "Добавьте оливки и кубики Феты.",
                "Полейте суп оливковым маслом и хорошо перемешайте."
            }
            };

            Recipe recipe3 = new Recipe
            {
                Name = "Омлет с овощами",
                Ingredients = new List<string> { "Яйца", "Помидоры", "Брокколи", "Лук", "Сыр", "Соль", "Перец" },
                Instructions = new List<string>
            {
                "Нарежьте помидоры, лук, брокколи и сыр.",
                "Венчиком взбейте яйца и добавьте нарезанные овощи.",
                "Приправьте солью и перцем по вкусу.",
                "Вылейте смесь на сковороду и жарьте до готовности."
            }
            };

            // Добавление исходных рецептов в приложение.
            recipeApp.AddRecipe(recipe1, recipe2, recipe3);

            // Основной цикл программы для взаимодействия с пользователем.
            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Добавить новый рецепт");
                Console.WriteLine("2. Просмотреть все рецепты");
                Console.WriteLine("3. Посмотреть детали рецепта");
                Console.WriteLine("4. Поиск рецепта");
                Console.WriteLine("5. Удалить рецепт");
                Console.WriteLine("6. Выход");

                Console.Write("Выберите действие (1-6): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        recipeApp.AddRecipe();
                        break;
                    case "2":
                        recipeApp.ViewAllRecipes();
                        break;
                    case "3":
                        Console.WriteLine("Введите название рецепта для просмотра деталей:");
                        string recipeName = Console.ReadLine();
                        recipeApp.ViewRecipeDetails(recipeName);
                        break;
                    case "4":
                        recipeApp.SearchRecipe();
                        break;
                    case "5":
                        recipeApp.RemoveRecipe();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Пожалуйста, введите число от 1 до 6.");
                        break;
                }
            }
        }
    }
}