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
    public class ToHashSet : AsyncEnumerableTests
    {
        [Fact]
        public async Task ToHashSet_Null()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.ToHashSetAsync<int>(default));
            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.ToHashSetAsync<int>(default, CancellationToken.None));

            await Assert.ThrowsAsync<ArgumentNullException>(() => AsyncEnumerable.ToHashSetAsync(default, EqualityComparer<int>.Default, CancellationToken.None));
        }

        [Fact]
        public async Task ToHashSet1()
        {
            var xs = new[] { 1, 2, 1, 2, 3, 4, 1, 2, 3, 4 };
            var res = xs.ToAsyncEnumerable().ToHashSetAsync();
            Assert.True((await res).OrderBy(x => x).SequenceEqual(new[] { 1, 2, 3, 4 }));
        }
    }
}
