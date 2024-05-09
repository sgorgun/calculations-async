namespace Calculations.ConsoleClient;
internal static class Program
{
    /// <summary>
    /// Calculates the sum from 1 to n synchronously.
    /// The value of n is set by the user from the console.
    /// The user can change the boundary n during the calculation, which causes the calculation to be restarted,
    /// this should not crash the application.
    /// After receiving the result, be able to continue calculations without leaving the console.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task Main()
    {
        while (true)
        {
            Console.WriteLine("Enter the number n to calculate the sum from 1 to n:");
            if (!int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("Invalid input. Please try again.");
                continue;
            }

            try
            {
                using var cancellationTokenSource = new CancellationTokenSource();
                var sum = await Calculator.CalculateSumAsync(n, cancellationTokenSource.Token, null);
                Console.WriteLine($"The sum from 1 to {n} is {sum}.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Press any key to continue or 'q' to quit:");
            var key = Console.ReadKey();
            if (key.KeyChar == 'q')
            {
                break;
            }
        }
    }
}
