﻿// Copyright (c) 2019 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Threading;

namespace Splat
{
    /// <summary>
    /// A Locator which will host the container for dependency injection based operations.
    /// </summary>
    public static class Locator
    {
        private static readonly InternalLocator _locator;

        static Locator()
        {
            _locator = new InternalLocator();
        }

        /// <summary>
        /// Gets the read only dependency resolver. This class is used throughout
        /// libraries for many internal operations as well as for general use
        /// by applications. If this isn't assigned on startup, a default, highly
        /// capable implementation will be used, and it is advised for most people
        /// to simply use the default implementation.
        /// </summary>
        /// <value>The dependency resolver.</value>
        public static IReadonlyDependencyResolver Current => _locator.Current;

        /// <summary>
        /// Gets the mutable dependency resolver.
        /// The default resolver is also a mutable resolver, so this will be non-null.
        /// Use this to register new types on startup if you are using the default resolver.
        /// </summary>
        public static IMutableDependencyResolver CurrentMutable => _locator.CurrentMutable;

        internal static IDependencyResolver Internal => _locator.Internal;

        /// <summary>
        /// Allows setting the dependency resolver.
        /// </summary>
        /// <param name="dependencyResolver">The dependency resolver to set.</param>
        public static void SetLocator(IDependencyResolver dependencyResolver)
        {
            _locator.SetLocator(dependencyResolver);
        }

        /// <summary>
        /// This method allows libraries to register themselves to be set up
        /// whenever the dependency resolver changes. Applications should avoid
        /// this method, it is usually used for libraries that depend on service
        /// location.
        /// </summary>
        /// <param name="callback">A callback that is invoked when the
        /// resolver is changed. This callback is also invoked immediately,
        /// to configure the current resolver.</param>
        /// <returns>When disposed, removes the callback. You probably can
        /// ignore this.</returns>
        public static IDisposable RegisterResolverCallbackChanged(Action callback)
        {
            return _locator.RegisterResolverCallbackChanged(callback);
        }

        /// <summary>
        /// This method will prevent resolver changed notifications from happening until
        /// the returned <see cref="IDisposable"/> is disposed.
        /// </summary>
        /// <returns>A disposable which when disposed will indicate the change
        /// notification is no longer needed.</returns>
        public static IDisposable SuppressResolverCallbackChangedNotifications()
        {
            return _locator.SuppressResolverCallbackChangedNotifications();
        }

        /// <summary>
        /// Indicates if the we are notifying external classes of updates to the resolver being changed.
        /// </summary>
        /// <returns>A value indicating whether the notifications are happening.</returns>
        public static bool AreResolverCallbackChangedNotificationsEnabled()
        {
            return _locator.AreResolverCallbackChangedNotificationsEnabled();
        }
    }
}
