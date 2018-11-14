﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class Average : AsyncEnumerableTests
    {
        [Fact]
        public async Task Average_Null()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<int>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<int?>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<long>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<long?>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<double>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<double?>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<float>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<float?>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<decimal>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<decimal?>)));

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<int>), x => x));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<int?>), x => x));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<long>), x => x));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<long?>), x => x));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<double>), x => x));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<double?>), x => x));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<float>), x => x));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<float?>), x => x));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<decimal>), x => x));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<decimal?>), x => x));

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(AsyncEnumerable.Empty<int>(), default(Func<int, int>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(AsyncEnumerable.Empty<int>(), default(Func<int, int?>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(AsyncEnumerable.Empty<int>(), default(Func<int, long>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(AsyncEnumerable.Empty<int>(), default(Func<int, long?>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(AsyncEnumerable.Empty<int>(), default(Func<int, double>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(AsyncEnumerable.Empty<int>(), default(Func<int, double?>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(AsyncEnumerable.Empty<int>(), default(Func<int, float>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(AsyncEnumerable.Empty<int>(), default(Func<int, float?>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(AsyncEnumerable.Empty<int>(), default(Func<int, decimal>)));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(AsyncEnumerable.Empty<int>(), default(Func<int, decimal?>)));

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<int>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<int?>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<long>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<long?>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<double>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<double?>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<float>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<float?>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<decimal>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<decimal?>), CancellationToken.None));

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<int>), x => x, CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<int?>), x => x, CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<long>), x => x, CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<long?>), x => x, CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<double>), x => x, CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<double?>), x => x, CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<float>), x => x, CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<float?>), x => x, CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<decimal>), x => x, CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(default(IAsyncEnumerable<decimal?>), x => x, CancellationToken.None));

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(AsyncEnumerable.Empty<int>(), default(Func<int, int>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(AsyncEnumerable.Empty<int>(), default(Func<int, int?>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(AsyncEnumerable.Empty<int>(), default(Func<int, long>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(AsyncEnumerable.Empty<int>(), default(Func<int, long?>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(AsyncEnumerable.Empty<int>(), default(Func<int, double>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(AsyncEnumerable.Empty<int>(), default(Func<int, double?>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(AsyncEnumerable.Empty<int>(), default(Func<int, float>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(AsyncEnumerable.Empty<int>(), default(Func<int, float?>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(AsyncEnumerable.Empty<int>(), default(Func<int, decimal>), CancellationToken.None));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.AverageAsync(AsyncEnumerable.Empty<int>(), default(Func<int, decimal?>), CancellationToken.None));
        }

        [Fact]
        public async Task Average1()
        {
            var xs = new[] { 1, 2, 3 };
            var ys = xs.ToAsyncEnumerable();
            Assert.Equal(xs.Average(), await ys.AverageAsync());
            Assert.Equal(xs.Average(), await ys.AverageAsync(x => x));
        }

        [Fact]
        public async Task Average2()
        {
            var xs = new[] { 1, default(int?), 3 };
            var ys = xs.ToAsyncEnumerable();
            Assert.Equal(xs.Average(), await ys.AverageAsync());
            Assert.Equal(xs.Average(), await ys.AverageAsync(x => x));
        }

        [Fact]
        public async Task Average3()
        {
            var xs = new[] { 1L, 2L, 3L };
            var ys = xs.ToAsyncEnumerable();
            Assert.Equal(xs.Average(), await ys.AverageAsync());
            Assert.Equal(xs.Average(), await ys.AverageAsync(x => x));
        }

        [Fact]
        public async Task Average4()
        {
            var xs = new[] { 1L, default(long?), 3L };
            var ys = xs.ToAsyncEnumerable();
            Assert.Equal(xs.Average(), await ys.AverageAsync());
            Assert.Equal(xs.Average(), await ys.AverageAsync(x => x));
        }

        [Fact]
        public async Task Average5()
        {
            var xs = new[] { 1.0, 2.0, 3.0 };
            var ys = xs.ToAsyncEnumerable();
            Assert.Equal(xs.Average(), await ys.AverageAsync());
            Assert.Equal(xs.Average(), await ys.AverageAsync(x => x));
        }

        [Fact]
        public async Task Average6()
        {
            var xs = new[] { 1.0, default(double?), 3.0 };
            var ys = xs.ToAsyncEnumerable();
            Assert.Equal(xs.Average(), await ys.AverageAsync());
            Assert.Equal(xs.Average(), await ys.AverageAsync(x => x));
        }

        [Fact]
        public async Task Average7()
        {
            var xs = new[] { 1.0f, 2.0f, 3.0f };
            var ys = xs.ToAsyncEnumerable();
            Assert.Equal(xs.Average(), await ys.AverageAsync());
            Assert.Equal(xs.Average(), await ys.AverageAsync(x => x));
        }

        [Fact]
        public async Task Average8()
        {
            var xs = new[] { 1.0f, default(float?), 3.0f };
            var ys = xs.ToAsyncEnumerable();
            Assert.Equal(xs.Average(), await ys.AverageAsync());
            Assert.Equal(xs.Average(), await ys.AverageAsync(x => x));
        }

        [Fact]
        public async Task Average9()
        {
            var xs = new[] { 1.0m, 2.0m, 3.0m };
            var ys = xs.ToAsyncEnumerable();
            Assert.Equal(xs.Average(), await ys.AverageAsync());
            Assert.Equal(xs.Average(), await ys.AverageAsync(x => x));
        }

        [Fact]
        public async Task Average10()
        {
            var xs = new[] { 1.0m, default(decimal?), 3.0m };
            var ys = xs.ToAsyncEnumerable();
            Assert.Equal(xs.Average(), await ys.AverageAsync());
            Assert.Equal(xs.Average(), await ys.AverageAsync(x => x));
        }

        [Fact]
        public async Task Average11()
        {
            var xs = new int[0];
            var ys = xs.ToAsyncEnumerable();
            await Assert.ThrowsAsync<InvalidOperationException>(() => ys.AverageAsync());
        }

        [Fact]
        public async Task Average12()
        {
            var xs = new int?[0];
            var ys = xs.ToAsyncEnumerable();
            Assert.Null(await ys.AverageAsync());
        }

        [Fact]
        public async Task Average13()
        {
            var xs = new long[0];
            var ys = xs.ToAsyncEnumerable();
            await Assert.ThrowsAsync<InvalidOperationException>(() => ys.AverageAsync());
        }

        [Fact]
        public async Task Average14()
        {
            var xs = new long?[0];
            var ys = xs.ToAsyncEnumerable();
            Assert.Null(await ys.AverageAsync());
        }

        [Fact]
        public async Task Average15()
        {
            var xs = new double[0];
            var ys = xs.ToAsyncEnumerable();
            await Assert.ThrowsAsync<InvalidOperationException>(() => ys.AverageAsync());
        }

        [Fact]
        public async Task Average16()
        {
            var xs = new double?[0];
            var ys = xs.ToAsyncEnumerable();
            Assert.Null(await ys.AverageAsync());
        }

        [Fact]
        public async Task Average17()
        {
            var xs = new float[0];
            var ys = xs.ToAsyncEnumerable();
            await Assert.ThrowsAsync<InvalidOperationException>(() => ys.AverageAsync());
        }

        [Fact]
        public async Task Average18()
        {
            var xs = new float?[0];
            var ys = xs.ToAsyncEnumerable();
            Assert.Null(await ys.AverageAsync());
        }

        [Fact]
        public async Task Average19()
        {
            var xs = new decimal[0];
            var ys = xs.ToAsyncEnumerable();
            await Assert.ThrowsAsync<InvalidOperationException>(() => ys.AverageAsync());
        }

        [Fact]
        public async Task Average20()
        {
            var xs = new decimal?[0];
            var ys = xs.ToAsyncEnumerable();
            Assert.Null(await ys.AverageAsync());
        }
    }
}
