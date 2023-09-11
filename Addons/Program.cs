class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("[1] Lifebar");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write("Select Addon to debug: ");
            string input = Console.ReadLine();
            bool convertable = int.TryParse(input, out int result);
            int convertedinput = 0;
            if (convertable)
            {
                convertedinput = Convert.ToInt32(input);
            }
            Console.Clear();
            switch (convertedinput)
            {
                case 1:
                    Console.ResetColor();
                    Console.Write("Enter HP: ");
                    int input1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("Enter max HP: ");
                    int input2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("Should there be a line at the end? [y]: ");
                    string input3 = Console.ReadLine();
                    bool line = false;
                    if(input3 == "y")
                    {
                        line = true;
                    }
                    Addon.TurnToLifebar(input1, input2, line); 
                    Console.WriteLine("Debug finished");
                    Console.ReadKey();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Addon {0} does not exist", input);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.ResetColor();
                    break;
            }
        }
    }
}
class Addon
{
    public static void TurnToLifebar(int i, int s, bool line)
    {
        Console.Write("[");
        for(int turns = 0; turns < (s / 10); turns++)
        {
            Console.ResetColor();
            if(i > (turns * 10))
            {
                if(turns <= 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("#");
                }
                else if(turns <= 5)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("#");
                }
                else if((turns < (s / 10)))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("#");
                }
                else if((turns * 10) < i)
                {
                    Console.Write("-");
                }
            }
            else
            {
                Console.ResetColor();
                Console.Write("-");
            }
        }
        Console.ResetColor();
        Console.Write("]");
        if (line)
        {
            Console.WriteLine();
        }
    }
}