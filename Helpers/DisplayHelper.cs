using SimplePokedex.Models;

namespace SimplePokedex.Helpers
{
    public static class DisplayHelper
    {
        public static void DisplayPokemon(Pokemon pokemon)
        {
            if (pokemon == null)
            {
                DisplayNotFound("Pokemon");
                return;
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"╔{'═'.Repeat(40)}╗");
            Console.WriteLine($"║ POKEMON: {pokemon.Name.ToUpper().PadRight(29)} ║");
            Console.WriteLine($"║ #{pokemon.Id.ToString().PadLeft(4, '0').PadRight(37)} ║");
            Console.WriteLine($"╚{'═'.Repeat(40)}╝");
            Console.ResetColor();
            
            Console.WriteLine();
            Console.WriteLine($"Height: {pokemon.Height / 10.0}m");
            Console.WriteLine($"Weight: {pokemon.Weight / 10.0}kg");
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nTypes: {string.Join(", ", pokemon.Types.Select(t => Capitalize(t.Type.Name)))}");
            Console.ResetColor();
            
            Console.WriteLine("\nBase Stats:");
            foreach (var stat in pokemon.Stats)
            {
                var statName = Capitalize(stat.Stat.Name).PadRight(20);
                var statValue = stat.BaseStat.ToString().PadLeft(3);
                var bar = CreateStatBar(stat.BaseStat);
                
                Console.Write($"  {statName} {statValue} ");
                DisplayStatBar(bar, stat.BaseStat);
                Console.WriteLine();
            }
        }

        public static void DisplayItem(Item item)
        {
            if (item == null)
            {
                DisplayNotFound("Item");
                return;
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"╔{'═'.Repeat(40)}╗");
            Console.WriteLine($"║ ITEM: {item.Name.ToUpper().PadRight(32)} ║");
            Console.WriteLine($"║ #{item.Id.ToString().PadLeft(4, '0').PadRight(37)} ║");
            Console.WriteLine($"╚{'═'.Repeat(40)}╝");
            Console.ResetColor();
            
            Console.WriteLine();
            Console.WriteLine($"Cost: {item.Cost:N0} Pokédollars");
            
            var effect = item.EffectEntries?.FirstOrDefault(e => e.Language.Name == "en");
            if (effect != null)
            {
                Console.WriteLine("\nEffect:");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(WrapText(effect.Effect, 60, "  "));
                Console.ResetColor();
            }
        }

        public static void DisplayMove(Move move)
        {
            if (move == null)
            {
                DisplayNotFound("Move");
                return;
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"╔{'═'.Repeat(40)}╗");
            Console.WriteLine($"║ MOVE: {move.Name.ToUpper().PadRight(32)} ║");
            Console.WriteLine($"║ #{move.Id.ToString().PadLeft(4, '0').PadRight(37)} ║");
            Console.WriteLine($"╚{'═'.Repeat(40)}╝");
            Console.ResetColor();
            
            Console.WriteLine();
            Console.WriteLine($"Type: {Capitalize(move.Type.Name)}");
            Console.WriteLine($"Category: {Capitalize(move.DamageClass.Name)}");
            Console.WriteLine($"Power: {(move.Power.HasValue ? move.Power.Value.ToString() : "—")}");
            Console.WriteLine($"Accuracy: {(move.Accuracy.HasValue ? $"{move.Accuracy.Value}%" : "—")}");
            Console.WriteLine($"PP: {move.PP}");
        }

        private static void DisplayNotFound(string type)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"╔{'═'.Repeat(40)}╗");
            Console.WriteLine($"║ {type.ToUpper()} NOT FOUND!".PadRight(41) + "║");
            Console.WriteLine($"╚{'═'.Repeat(40)}╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Please check the spelling and try again.");
        }

        private static string CreateStatBar(int value)
        {
            int barLength = (int)Math.Round(value / 255.0 * 20);
            return new string('█', barLength) + new string('░', 20 - barLength);
        }

        private static void DisplayStatBar(string bar, int value)
        {
            if (value >= 100)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (value >= 70)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else if (value >= 40)
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            
            Console.Write($"[{bar}]");
            Console.ResetColor();
        }

        private static string Capitalize(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            var words = text.Split('-', ' ');
            return string.Join(" ", words.Select(w => 
                char.ToUpper(w[0]) + w.Substring(1).ToLower()));
        }

        private static string WrapText(string text, int maxLineLength, string indent = "")
        {
            var words = text.Split(' ');
            var lines = new List<string>();
            var currentLine = indent;

            foreach (var word in words)
            {
                if (currentLine.Length + word.Length + 1 > maxLineLength)
                {
                    lines.Add(currentLine.TrimEnd());
                    currentLine = indent + word + " ";
                }
                else
                {
                    currentLine += word + " ";
                }
            }

            if (!string.IsNullOrWhiteSpace(currentLine))
                lines.Add(currentLine.TrimEnd());

            return string.Join("\n", lines);
        }
    }

    // Extension method for string repeat
    public static class StringExtensions
    {
        public static string Repeat(this char c, int count)
        {
            return new string(c, count);
        }
    }
}
