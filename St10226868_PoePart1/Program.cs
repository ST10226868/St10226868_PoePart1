

using System;

namespace St10226868_POE
{
    class Recipe
    {
        private string[] ingredients;
        private string[] steps;

        public Recipe(int numIngredients, int numSteps)
        {
            ingredients = new string[numIngredients];
            steps = new string[numSteps];
        }
        //method that adds more recipes
        public void AddIngredient(int index, string name, double quantity, string unit)
        {
            ingredients[index] = $"{name} - {quantity} {unit}";
        }

        public void AddStep(int index, string step)
        {
            steps[index] = step;
        }
        //method to display the recipe
        public void DisplayRecipe()
        {
            Console.WriteLine("Ingredients:");
            foreach (string ingredient in ingredients)
            {
                Console.WriteLine("- " + ingredient);
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + steps[i]);
            }
        }
        //method to scale the recipe
        public void ScaleRecipe(double factor)
        {
            for (int i = 0; i < ingredients.Length; i++)
            {
                string[] parts = ingredients[i].Split(" - ");
                string name = parts[0];
                double quantity = double.Parse(parts[1].Split(" ")[0]) * factor;
                string unit = parts[1].Split(" ")[1];
                ingredients[i] = $"{name} - {quantity} {unit}";
            }
        }
        //method to reset the recipe
        public void ResetQuantities()
        {
            
            string[] originalIngredients = new string[ingredients.Length];
            Array.Copy(ingredients, originalIngredients, ingredients.Length);
            ingredients = originalIngredients;
        }
    }

    class Program
    {//method that will display the entire program
        static void Main(string[] args)
        {//message that will welcome the user to the app
            Console.WriteLine("Welcome to the Recipe App!");

            Console.WriteLine("---------------------------");

            Console.WriteLine("\nEnter the number of ingredients:");
            int numOfIngredients = int.Parse(Console.ReadLine());

            Console.WriteLine("\nPlease enter the number of steps:");
            int numSteps = int.Parse(Console.ReadLine());

            Recipe recipe = new Recipe(numOfIngredients, numSteps);

            for (int i = 0; i < numOfIngredients; i++)
            {
                Console.WriteLine($"\nEnter ingredient #{i + 1} name:");
                string name = Console.ReadLine();

                Console.WriteLine($"Enter ingredient #{i + 1} quantity:");
                double quantity = double.Parse(Console.ReadLine());

                Console.WriteLine($"Enter ingredient #{i + 1} unit of measurement:");
                string unit = Console.ReadLine();

                recipe.AddIngredient(i, name, quantity, unit);
            }

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"\nEnter step #{i + 1} description:");
                string step = Console.ReadLine();

                recipe.AddStep(i, step);
            }

            Console.WriteLine("\nRecipe has been added!");

            while (true)
            {
                Console.WriteLine("\nWhat would you like to do next?");
                Console.WriteLine("1. Display recipe");
                Console.WriteLine("2. Scale recipe");
                Console.WriteLine("3. Reset quantities");
                Console.WriteLine("4. Clear data and enter a new recipe");
                Console.WriteLine("5. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        recipe.DisplayRecipe();
                        break;
                    case 2:
                        Console.WriteLine("\nBy what factor do you want to scale the recipe? (0.5/half, 2/double, 3/triple)");
                        double factor = double.Parse(Console.ReadLine());

                        Console.WriteLine($"\nRecipe scaled by {factor}x!");
                        recipe.DisplayRecipe();
                        break;
                    case 3:
                        recipe.ResetQuantities();
                        Console.WriteLine("\nQuantities has been reset to original values!");
                        recipe.DisplayRecipe();
                        break;
                    case 4:
                        Console.WriteLine("\nEnter the number of ingredients:");
                        numOfIngredients = int.Parse(Console.ReadLine());

                        Console.WriteLine("\nEnter the number of steps:");
                        numSteps = int.Parse(Console.ReadLine());

                        recipe = new Recipe(numOfIngredients, numSteps);

                        for (int i = 0; i < numOfIngredients; i++)
                        {
                            Console.WriteLine($"\nEnter ingredient #{i + 1} name:");
                            string name = Console.ReadLine();

                            Console.WriteLine($"Enter ingredient #{i + 1} quantity:");
                            double quantity = double.Parse(Console.ReadLine());

                            Console.WriteLine($"Enter ingredient #{i + 1} unit of measurement:");
                            string unit = Console.ReadLine();

                            recipe.AddIngredient(i, name, quantity, unit);
                        }

                        for (int i = 0; i < numSteps; i++)
                        {
                            Console.WriteLine($"\nEnter step #{i + 1} description:");
                            string step = Console.ReadLine();

                            recipe.AddStep(i, step);
                        }

                        Console.WriteLine("\nRecipe has been added!");
                        break;
                    case 5:
                        Console.WriteLine("\nThank you for using the Recipe App!");
                        return;
                    default:
                        Console.WriteLine("\nThat is an invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}


