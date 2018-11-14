﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information. 

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.Linq
{
    public static partial class AsyncEnumerableEx
    {
        public static Task<IList<TSource>> MinByAsync<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (keySelector == null)
                throw Error.ArgumentNull(nameof(keySelector));

            return MinByCore(source, keySelector, comparer: null, CancellationToken.None);
        }

        public static Task<IList<TSource>> MinByAsync<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (keySelector == null)
                throw Error.ArgumentNull(nameof(keySelector));

            return MinByCore(source, keySelector, comparer: null, cancellationToken);
        }

        public static Task<IList<TSource>> MinByAsync<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (keySelector == null)
                throw Error.ArgumentNull(nameof(keySelector));

            return MinByCore(source, keySelector, comparer, CancellationToken.None);
        }

        public static Task<IList<TSource>> MinByAsync<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (keySelector == null)
                throw Error.ArgumentNull(nameof(keySelector));

            return MinByCore(source, keySelector, comparer, cancellationToken);
        }

        public static Task<IList<TSource>> MinByAsync<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<TKey>> keySelector)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (keySelector == null)
                throw Error.ArgumentNull(nameof(keySelector));

            return MinByCore<TSource, TKey>(source, keySelector, comparer: null, CancellationToken.None);
        }

        public static Task<IList<TSource>> MinByAsync<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<TKey>> keySelector, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (keySelector == null)
                throw Error.ArgumentNull(nameof(keySelector));

            return MinByCore<TSource, TKey>(source, keySelector, comparer: null, cancellationToken);
        }

        public static Task<IList<TSource>> MinByAsync<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<TKey>> keySelector, IComparer<TKey> comparer)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (keySelector == null)
                throw Error.ArgumentNull(nameof(keySelector));

            return MinByCore(source, keySelector, comparer, CancellationToken.None);
        }

        public static Task<IList<TSource>> MinByAsync<TSource, TKey>(this IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<TKey>> keySelector, IComparer<TKey> comparer, CancellationToken cancellationToken)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (keySelector == null)
                throw Error.ArgumentNull(nameof(keySelector));

            return MinByCore(source, keySelector, comparer, cancellationToken);
        }

        private static Task<IList<TSource>> MinByCore<TSource, TKey>(IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer, CancellationToken cancellationToken)
        {
            if (comparer == null)
            {
                comparer = Comparer<TKey>.Default;
            }

            return ExtremaBy(source, keySelector, (key, minValue) => -comparer.Compare(key, minValue), cancellationToken);
        }

        private static Task<IList<TSource>> MinByCore<TSource, TKey>(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<TKey>> keySelector, IComparer<TKey> comparer, CancellationToken cancellationToken)
        {
            if (comparer == null)
            {
                comparer = Comparer<TKey>.Default;
            }

            return ExtremaBy(source, keySelector, (key, minValue) => -comparer.Compare(key, minValue), cancellationToken);
        }

        private static async Task<IList<TSource>> ExtremaBy<TSource, TKey>(IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TKey, int> compare, CancellationToken cancellationToken)
        {
            var result = new List<TSource>();

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                if (!await e.MoveNextAsync().ConfigureAwait(false))
                    throw Error.NoElements();

                var current = e.Current;
                var resKey = keySelector(current);
                result.Add(current);

                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    var cur = e.Current;
                    var key = keySelector(cur);

                    var cmp = compare(key, resKey);
                    if (cmp == 0)
                    {
                        result.Add(cur);
                    }
                    else if (cmp > 0)
                    {
                        result = new List<TSource> { cur };
                        resKey = key;
                    }
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return result;
        }

        private static async Task<IList<TSource>> ExtremaBy<TSource, TKey>(IAsyncEnumerable<TSource> source, Func<TSource, ValueTask<TKey>> keySelector, Func<TKey, TKey, int> compare, CancellationToken cancellationToken)
        {
            var result = new List<TSource>();

            var e = source.GetAsyncEnumerator(cancellationToken);

            try
            {
                if (!await e.MoveNextAsync().ConfigureAwait(false))
                    throw Error.NoElements();

                var current = e.Current;
                var resKey = await keySelector(current).ConfigureAwait(false);
                result.Add(current);

                while (await e.MoveNextAsync().ConfigureAwait(false))
                {
                    var cur = e.Current;
                    var key = await keySelector(cur).ConfigureAwait(false);

                    var cmp = compare(key, resKey);
                    if (cmp == 0)
                    {
                        result.Add(cur);
                    }
                    else if (cmp > 0)
                    {
                        result = new List<TSource> { cur };
                        resKey = key;
                    }
                }
            }
            finally
            {
                await e.DisposeAsync().ConfigureAwait(false);
            }

            return result;
        }
    }
}
