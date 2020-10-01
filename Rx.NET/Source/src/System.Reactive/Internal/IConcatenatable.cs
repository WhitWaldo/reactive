﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT License.
// See the LICENSE file in the project root for more information. 

#nullable disable

using System.Collections.Generic;

namespace System.Reactive
{
    internal interface IConcatenatable<out TSource>
    {
        IEnumerable<IObservable<TSource>> GetSources();
    }
}
