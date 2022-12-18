﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Calculations
{
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
