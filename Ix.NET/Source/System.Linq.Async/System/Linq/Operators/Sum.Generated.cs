﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information. 

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.Linq
{
    public static partial class AsyncEnumerable
    {
        public static Task<int> SumAsync(this IAsyncEnumerable<int> source)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return SumCore(source, CancellationToken.None);
        }

        public static Task<int> SumAsync(this IAsyncEnumerable<int> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return SumCore(source, cancellationToken);
        }

        public static Task<int> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int> selector)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, CancellationToken.None);
        }

        public static Task<int> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, cancellationToken);
        }

        public static Task<int> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<int>> selector)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, CancellationToken.None);
        }

        public static Task<int> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<int>> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, cancellationToken);
        }

        private static async Task<int> SumCore(IAsyncEnumerable<int> source, CancellationToken cancellationToken)
        {
            var sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    checked
                    {
                        sum += e.Current;
                    }
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        private static async Task<int> SumCore<TSource>(IAsyncEnumerable<TSource> source, Func<TSource, int> selector, CancellationToken cancellationToken)
        {
            var sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    var value = selector(e.Current);

                    checked
                    {
                        sum += value;
                    }
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        private static async Task<int> SumCore<TSource>(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<int>> selector, CancellationToken cancellationToken)
        {
            var sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    var value = await selector(e.Current).ConfigureAwait(false);

                    checked
                    {
                        sum += value;
                    }
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        public static Task<long> SumAsync(this IAsyncEnumerable<long> source)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return SumCore(source, CancellationToken.None);
        }

        public static Task<long> SumAsync(this IAsyncEnumerable<long> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return SumCore(source, cancellationToken);
        }

        public static Task<long> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, long> selector)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, CancellationToken.None);
        }

        public static Task<long> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, long> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, cancellationToken);
        }

        public static Task<long> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<long>> selector)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, CancellationToken.None);
        }

        public static Task<long> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<long>> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, cancellationToken);
        }

        private static async Task<long> SumCore(IAsyncEnumerable<long> source, CancellationToken cancellationToken)
        {
            var sum = 0L;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    checked
                    {
                        sum += e.Current;
                    }
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        private static async Task<long> SumCore<TSource>(IAsyncEnumerable<TSource> source, Func<TSource, long> selector, CancellationToken cancellationToken)
        {
            var sum = 0L;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    var value = selector(e.Current);

                    checked
                    {
                        sum += value;
                    }
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        private static async Task<long> SumCore<TSource>(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<long>> selector, CancellationToken cancellationToken)
        {
            var sum = 0L;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    var value = await selector(e.Current).ConfigureAwait(false);

                    checked
                    {
                        sum += value;
                    }
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        public static Task<float> SumAsync(this IAsyncEnumerable<float> source)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return SumCore(source, CancellationToken.None);
        }

        public static Task<float> SumAsync(this IAsyncEnumerable<float> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return SumCore(source, cancellationToken);
        }

        public static Task<float> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, float> selector)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, CancellationToken.None);
        }

        public static Task<float> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, float> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, cancellationToken);
        }

        public static Task<float> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<float>> selector)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, CancellationToken.None);
        }

        public static Task<float> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<float>> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, cancellationToken);
        }

        private static async Task<float> SumCore(IAsyncEnumerable<float> source, CancellationToken cancellationToken)
        {
            var sum = 0.0f;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    sum += e.Current;
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        private static async Task<float> SumCore<TSource>(IAsyncEnumerable<TSource> source, Func<TSource, float> selector, CancellationToken cancellationToken)
        {
            var sum = 0.0f;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    var value = selector(e.Current);

                    sum += value;
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        private static async Task<float> SumCore<TSource>(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<float>> selector, CancellationToken cancellationToken)
        {
            var sum = 0.0f;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    var value = await selector(e.Current).ConfigureAwait(false);

                    sum += value;
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        public static Task<double> SumAsync(this IAsyncEnumerable<double> source)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return SumCore(source, CancellationToken.None);
        }

        public static Task<double> SumAsync(this IAsyncEnumerable<double> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return SumCore(source, cancellationToken);
        }

        public static Task<double> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, double> selector)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, CancellationToken.None);
        }

        public static Task<double> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, double> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, cancellationToken);
        }

        public static Task<double> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<double>> selector)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, CancellationToken.None);
        }

        public static Task<double> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<double>> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, cancellationToken);
        }

        private static async Task<double> SumCore(IAsyncEnumerable<double> source, CancellationToken cancellationToken)
        {
            var sum = 0.0;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    sum += e.Current;
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        private static async Task<double> SumCore<TSource>(IAsyncEnumerable<TSource> source, Func<TSource, double> selector, CancellationToken cancellationToken)
        {
            var sum = 0.0;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    var value = selector(e.Current);

                    sum += value;
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        private static async Task<double> SumCore<TSource>(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<double>> selector, CancellationToken cancellationToken)
        {
            var sum = 0.0;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    var value = await selector(e.Current).ConfigureAwait(false);

                    sum += value;
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        public static Task<decimal> SumAsync(this IAsyncEnumerable<decimal> source)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return SumCore(source, CancellationToken.None);
        }

        public static Task<decimal> SumAsync(this IAsyncEnumerable<decimal> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return SumCore(source, cancellationToken);
        }

        public static Task<decimal> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, CancellationToken.None);
        }

        public static Task<decimal> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, decimal> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, cancellationToken);
        }

        public static Task<decimal> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<decimal>> selector)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, CancellationToken.None);
        }

        public static Task<decimal> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<decimal>> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, cancellationToken);
        }

        private static async Task<decimal> SumCore(IAsyncEnumerable<decimal> source, CancellationToken cancellationToken)
        {
            var sum = 0m;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    sum += e.Current;
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        private static async Task<decimal> SumCore<TSource>(IAsyncEnumerable<TSource> source, Func<TSource, decimal> selector, CancellationToken cancellationToken)
        {
            var sum = 0m;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    var value = selector(e.Current);

                    sum += value;
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        private static async Task<decimal> SumCore<TSource>(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<decimal>> selector, CancellationToken cancellationToken)
        {
            var sum = 0m;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    var value = await selector(e.Current).ConfigureAwait(false);

                    sum += value;
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        public static Task<int?> SumAsync(this IAsyncEnumerable<int?> source)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return SumCore(source, CancellationToken.None);
        }

        public static Task<int?> SumAsync(this IAsyncEnumerable<int?> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return SumCore(source, cancellationToken);
        }

        public static Task<int?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int?> selector)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, CancellationToken.None);
        }

        public static Task<int?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, int?> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, cancellationToken);
        }

        public static Task<int?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<int?>> selector)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, CancellationToken.None);
        }

        public static Task<int?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<int?>> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, cancellationToken);
        }

        private static async Task<int?> SumCore(IAsyncEnumerable<int?> source, CancellationToken cancellationToken)
        {
            var sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    checked
                    {
                        sum += e.Current.GetValueOrDefault();
                    }
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        private static async Task<int?> SumCore<TSource>(IAsyncEnumerable<TSource> source, Func<TSource, int?> selector, CancellationToken cancellationToken)
        {
            var sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    var value = selector(e.Current);

                    checked
                    {
                        sum += value.GetValueOrDefault();
                    }
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        private static async Task<int?> SumCore<TSource>(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<int?>> selector, CancellationToken cancellationToken)
        {
            var sum = 0;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    var value = await selector(e.Current).ConfigureAwait(false);

                    checked
                    {
                        sum += value.GetValueOrDefault();
                    }
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        public static Task<long?> SumAsync(this IAsyncEnumerable<long?> source)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return SumCore(source, CancellationToken.None);
        }

        public static Task<long?> SumAsync(this IAsyncEnumerable<long?> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return SumCore(source, cancellationToken);
        }

        public static Task<long?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, long?> selector)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, CancellationToken.None);
        }

        public static Task<long?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, long?> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, cancellationToken);
        }

        public static Task<long?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<long?>> selector)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, CancellationToken.None);
        }

        public static Task<long?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<long?>> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, cancellationToken);
        }

        private static async Task<long?> SumCore(IAsyncEnumerable<long?> source, CancellationToken cancellationToken)
        {
            var sum = 0L;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    checked
                    {
                        sum += e.Current.GetValueOrDefault();
                    }
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        private static async Task<long?> SumCore<TSource>(IAsyncEnumerable<TSource> source, Func<TSource, long?> selector, CancellationToken cancellationToken)
        {
            var sum = 0L;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    var value = selector(e.Current);

                    checked
                    {
                        sum += value.GetValueOrDefault();
                    }
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        private static async Task<long?> SumCore<TSource>(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<long?>> selector, CancellationToken cancellationToken)
        {
            var sum = 0L;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    var value = await selector(e.Current).ConfigureAwait(false);

                    checked
                    {
                        sum += value.GetValueOrDefault();
                    }
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        public static Task<float?> SumAsync(this IAsyncEnumerable<float?> source)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return SumCore(source, CancellationToken.None);
        }

        public static Task<float?> SumAsync(this IAsyncEnumerable<float?> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return SumCore(source, cancellationToken);
        }

        public static Task<float?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, float?> selector)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, CancellationToken.None);
        }

        public static Task<float?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, float?> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, cancellationToken);
        }

        public static Task<float?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<float?>> selector)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, CancellationToken.None);
        }

        public static Task<float?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<float?>> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, cancellationToken);
        }

        private static async Task<float?> SumCore(IAsyncEnumerable<float?> source, CancellationToken cancellationToken)
        {
            var sum = 0.0f;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    sum += e.Current.GetValueOrDefault();
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        private static async Task<float?> SumCore<TSource>(IAsyncEnumerable<TSource> source, Func<TSource, float?> selector, CancellationToken cancellationToken)
        {
            var sum = 0.0f;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    var value = selector(e.Current);

                    sum += value.GetValueOrDefault();
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        private static async Task<float?> SumCore<TSource>(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<float?>> selector, CancellationToken cancellationToken)
        {
            var sum = 0.0f;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    var value = await selector(e.Current).ConfigureAwait(false);

                    sum += value.GetValueOrDefault();
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        public static Task<double?> SumAsync(this IAsyncEnumerable<double?> source)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return SumCore(source, CancellationToken.None);
        }

        public static Task<double?> SumAsync(this IAsyncEnumerable<double?> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return SumCore(source, cancellationToken);
        }

        public static Task<double?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, double?> selector)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, CancellationToken.None);
        }

        public static Task<double?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, double?> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, cancellationToken);
        }

        public static Task<double?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<double?>> selector)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, CancellationToken.None);
        }

        public static Task<double?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<double?>> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, cancellationToken);
        }

        private static async Task<double?> SumCore(IAsyncEnumerable<double?> source, CancellationToken cancellationToken)
        {
            var sum = 0.0;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    sum += e.Current.GetValueOrDefault();
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        private static async Task<double?> SumCore<TSource>(IAsyncEnumerable<TSource> source, Func<TSource, double?> selector, CancellationToken cancellationToken)
        {
            var sum = 0.0;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    var value = selector(e.Current);

                    sum += value.GetValueOrDefault();
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        private static async Task<double?> SumCore<TSource>(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<double?>> selector, CancellationToken cancellationToken)
        {
            var sum = 0.0;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    var value = await selector(e.Current).ConfigureAwait(false);

                    sum += value.GetValueOrDefault();
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        public static Task<decimal?> SumAsync(this IAsyncEnumerable<decimal?> source)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return SumCore(source, CancellationToken.None);
        }

        public static Task<decimal?> SumAsync(this IAsyncEnumerable<decimal?> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));

            return SumCore(source, cancellationToken);
        }

        public static Task<decimal?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, decimal?> selector)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, CancellationToken.None);
        }

        public static Task<decimal?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, decimal?> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, cancellationToken);
        }

        public static Task<decimal?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<decimal?>> selector)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, CancellationToken.None);
        }

        public static Task<decimal?> SumAsync<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<decimal?>> selector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (selector == null)
                throw Error.ArgumentNull(nameof(selector));

            return SumCore(source, selector, cancellationToken);
        }

        private static async Task<decimal?> SumCore(IAsyncEnumerable<decimal?> source, CancellationToken cancellationToken)
        {
            var sum = 0m;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    sum += e.Current.GetValueOrDefault();
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        private static async Task<decimal?> SumCore<TSource>(IAsyncEnumerable<TSource> source, Func<TSource, decimal?> selector, CancellationToken cancellationToken)
        {
            var sum = 0m;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    var value = selector(e.Current);

                    sum += value.GetValueOrDefault();
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

        private static async Task<decimal?> SumCore<TSource>(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<decimal?>> selector, CancellationToken cancellationToken)
        {
            var sum = 0m;

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    var value = await selector(e.Current).ConfigureAwait(false);

                    sum += value.GetValueOrDefault();
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return sum;
        }

    }
}
