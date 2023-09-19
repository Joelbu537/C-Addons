class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Addon Debugger";
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[1] Lifebar");
            Console.WriteLine("[2] CheckMax");
            Console.WriteLine("[3] Loading Symbol");
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
                    if (input3 == "y")
                    {
                        line = true;
                    }
                    Addon.TurnToLifebar(input1, input2, line);
                    break;
                case 2:
                    Console.Write("Enter current HP: ");
                    int input4 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("Enter max HP: ");
                    int input5 = Convert.ToInt32(Console.ReadLine());
                    int lives = Addon.CheckMax(input4, input5);
                    Console.WriteLine("Your HP are now: {0}", lives);
                    break;
                case 3:
                    Console.Clear();
                    Console.Write("Enter turns: ");
                    int turns = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("Enter waiting time: ");
                    int wait = Convert.ToInt32(Console.ReadLine());
                    Addon.LoadingSymbol(turns, wait);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Addon {0} does not exist", input);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.ResetColor();
                    continue;
            }
            Console.WriteLine("Debug finished");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
class Addon
{
    public static void TurnToLifebar(int i, int s, bool line)
    {
        Console.Write("[");
        for (int turns = 0; turns < (s / 10); turns++)
        {
            Console.ResetColor();
            if (i > (turns * 10))
            {
                if (turns <= 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("#");
                }
                else if (turns <= 5)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("#");
                }
                else if ((turns < (s / 10)))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("#");
                }
                else if ((turns * 10) < i)
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
    public static int CheckMax(int i, int max)
    {
        if(i > max)
        {
            i = max;
        }
        if(i < 0)
        {
            i = 0;
        }
        return i;
    }
    public static void LoadingSymbol(int turns, int wait)
    {
        for(int i = 0; i < turns; i++)
        {
            Console.Write("|");
            Thread.Sleep(wait);
            Console.Clear();
            Console.Write("/");
            Thread.Sleep(wait);
            Console.Clear();
            Console.Write("-");
            Thread.Sleep(wait);
            Console.Clear();
            Console.Write("\\");
            Thread.Sleep(wait);
            Console.Clear();
        }
    }
}
