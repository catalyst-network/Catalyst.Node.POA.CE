/**
 * (C) Copyright 2019 Catalyst-Network
 *
 * Author USER ${USER}$
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; version 2
 * of the License.
 */

using Autofac;
using Catalyst.Abstractions.FileSystem;
using Catalyst.Abstractions.P2P;
using Catalyst.Abstractions.P2P.Discovery;
using Catalyst.Core.Lib.P2P.Repository;
using Catalyst.Modules.POA.P2P.Discovery;
using Serilog;

namespace Catalyst.Modules.POA.P2P
{
    public class PoaP2PModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PoaPeer>();
            
            builder.Register(c => new PoaDiscovery(
                c.Resolve<IPeerRepository>(),
                c.Resolve<IFileSystem>(),
                c.Resolve<ILogger>()
            )).As<IPeerDiscovery>()
                .SingleInstance();
            
            builder.Register(c => new PeerHeartbeatChecker(
                c.Resolve<ILogger>(),
                c.Resolve<IPeerRepository>(),
                c.Resolve<IPeerChallenger>(),
                10,
                1000
            )).As<IHealthChecker>()
                .SingleInstance();
        }
    }
}