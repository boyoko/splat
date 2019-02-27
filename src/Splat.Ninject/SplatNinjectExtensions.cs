﻿// Copyright (c) 2019 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using Ninject;

namespace Splat.Ninject
{
    /// <summary>
    /// Extension methods for the Ninject adapter.
    /// </summary>
    public static class SplatNinjectExtensions
    {
        /// <summary>
        /// Initializes an instance of <see cref="NinjectDependencyResolver"/> that overrides the default <see cref="Locator"/>.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public static void UseNinjectDependencyResolver(this IKernel kernel) =>
            Locator.SetLocator(new NinjectDependencyResolver(kernel));
    }
}
