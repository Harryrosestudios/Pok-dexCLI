using SimplePokedex.Services;
using SimplePokedex.Helpers;

namespace SimplePokedex
{
    class Program
    {
        private static PokeApiService _apiService;

        static async Task Main(string[] args)
        {
            _apiService = new PokeApiService();
            
            DisplayWelcomeMessage();
            
            bool running = true;
            while (running)
            {
                DisplayMenu();
                var choice = GetUserChoice();
                
                switch (choice)
                {
                    case "1":
                        await SearchPokemon();
                        break;
                    case "2":
                        await SearchItem();
                        break;
                    case "3":
                        await SearchMove();
                        break;
                    case "4":
                        running = false;
                        DisplayGoodbyeMessage();
                        break;
                    default:
                        DisplayInvalidChoiceMessage();
                        break;
                }
                
                if (running && choice != "4")
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void DisplayWelcomeMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║         WELCOME TO POKEDEX CLI         ║");
            Console.WriteLine("║    Search Pokemon, Items, and Moves    ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
        }

        static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Please select what you want to search:");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("  1. Pokemon");
            Console.WriteLine("  2. Item");
            Console.WriteLine("  3. Move");
            Console.WriteLine("  4. Exit");
            Console.WriteLine();
        }

        static string GetUserChoice()
        {
            Console.Write("Enter your choice (1-4): ");
            return Console.ReadLine()?.Trim() ?? "";
        }

        static async Task SearchPokemon()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== POKEMON SEARCH ===");
            Console.ResetColor();
            Console.WriteLine();
            
            Console.Write("Enter Pokemon name or ID: ");
            var searchTerm = Console.ReadLine()?.Trim();
            
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a Pokemon name or ID.");
                Console.ResetColor();
                return;
            }

            await PerformSearch(async () => 
            {
                var pokemon = await _apiService.GetPokemonAsync(searchTerm);
                DisplayHelper.DisplayPokemon(pokemon);
            });
        }

        static async Task SearchItem()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== ITEM SEARCH ===");
            Console.ResetColor();
            Console.WriteLine();
            
            Console.Write("Enter Item name: ");
            var searchTerm = Console.ReadLine()?.Trim();
            
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter an item name.");
                Console.ResetColor();
                return;
            }

            await PerformSearch(async () => 
            {
                var item = await _apiService.GetItemAsync(searchTerm);
                DisplayHelper.DisplayItem(item);
            });
        }

        static async Task SearchMove()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== MOVE SEARCH ===");
            Console.ResetColor();
            Console.WriteLine();
            
            Console.Write("Enter Move name: ");
            var searchTerm = Console.ReadLine()?.Trim();
            
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a move name.");
                Console.ResetColor();
                return;
            }

            await PerformSearch(async () => 
            {
                var move = await _apiService.GetMoveAsync(searchTerm);
                DisplayHelper.DisplayMove(move);
            });
        }

        static async Task PerformSearch(Func<Task> searchAction)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Searching...");
            Console.ResetColor();
            
            try
            {
                await searchAction();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error occurred: {ex.Message}");
                Console.ResetColor();
            }
        }

        static void DisplayInvalidChoiceMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nInvalid choice. Please select a number between 1-4.");
            Console.ResetColor();
            Thread.Sleep(2000);
            Console.Clear();
        }

        static void DisplayGoodbyeMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Thank you for using Pokedex CLI!");
            Console.WriteLine("Goodbye!");
            Console.ResetColor();
        }
    }
}
