// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Connections;

namespace Microsoft.AspNetCore.SignalR.Client
{
    /// <summary>
    /// A factory abstraction for creating connections to a SignalR server.
    /// </summary>
    public interface IConnectionFactory
    {
        /// <summary>
        /// Creates a new connection to a SignalR server using the specified <see cref="TransferFormat"/>.
        /// </summary>
        /// <param name="transferFormat">The transfer format the connection should use.</param>
        /// <returns>
        /// A <see cref="Task"/> that on completion indicates the connection is complete.
        /// The value of the task is a <see cref="ConnectionContext"/> for the new connection.
        /// </returns>
        Task<ConnectionContext> ConnectAsync(TransferFormat transferFormat, CancellationToken cancellationToken = default);

        // Current plan for IAsyncDisposable is that DisposeAsync will NOT take a CancellationToken
        // https://github.com/dotnet/csharplang/blob/195efa07806284d7b57550e7447dc8bd39c156bf/proposals/async-streams.md#iasyncdisposable
        /// <summary>
        /// Disposes the specified <see cref="ConnectionContext"/>.
        /// </summary>
        /// <param name="connection">The connection to dispose.</param>
        /// <returns>A <see cref="Task"/> that on completion indicates the connection is disposed.</returns>
        Task DisposeAsync(ConnectionContext connection);
    }
}