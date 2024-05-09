namespace Calculations;

/// <summary>
/// Presents methods for the calculation of the sum.
/// </summary>
public static class Calculator
{
    /// <summary>
    /// Calculates the sum from 1 to n synchronously.
    /// </summary>
    /// <param name="n">The last number in the sum.</param>
    /// <returns>A sum: 1 + 2 + ... + n.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Throw if n less or equals zero.</exception>
    public static long CalculateSum(int n)
    {
        if (n <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "n must be greater than zero.");
        }

        long sum = 0;
        for (int i = 1; i <= n; i++)
        {
            sum += i;
        }

        return sum;
    }

    /// <summary>
    /// Calculates the sum from 1 to n asynchronously.
    /// </summary>
    /// <param name="n">The last number in the sum.</param>
    /// <param name="token">The cancellation token for the cancellation of the asynchronous operation.</param>
    /// <param name="progress">Presents current status of the asynchronous operation in form of the current value of sum and index.</param>
    /// <returns>A task that represents the asynchronous sum: 1 + 2 + ... + n.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Throw if n less or equals zero.</exception>
    public static Task<long> CalculateSumAsync(int n, CancellationToken token, IProgress<(int, long)>? progress = null)
    {
        if (n <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "n must be greater than zero.");
        }

        return Task.Run(
            () =>
        {
            long sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += i;
                progress?.Report((i, sum));
                token.ThrowIfCancellationRequested();
            }

            return sum;
        }, token);
    }
}
