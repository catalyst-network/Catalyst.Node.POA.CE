#region LICENSE

/**
* Copyright (c) 2019 Catalyst Network
*
* This file is part of Catalyst.Node <https://github.com/catalyst-network/Catalyst.Node>
*
* Catalyst.Node is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 2 of the License, or
* (at your option) any later version.
*
* Catalyst.Node is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with Catalyst.Node. If not, see <https://www.gnu.org/licenses/>.
*/

#endregion

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Catalyst.Abstractions;
using Catalyst.Abstractions.Cli;
using Catalyst.Abstractions.Consensus;
using Catalyst.Abstractions.Contract;
using Catalyst.Abstractions.Dfs;
using Catalyst.Abstractions.KeySigner;
using Catalyst.Abstractions.Mempool;
using Catalyst.Abstractions.P2P;
using Catalyst.Abstractions.Rpc;
using Catalyst.Core.Lib;
using Catalyst.Core.Lib.Cli;
using Catalyst.Core.Lib.Mempool.Documents;
using Catalyst.Core.Modules.Authentication;
using Catalyst.Core.Modules.Consensus;
using Catalyst.Core.Modules.Cryptography.BulletProofs;
using Catalyst.Core.Modules.Dfs;
using Catalyst.Core.Modules.KeySigner;
using Catalyst.Core.Modules.Keystore;
using Catalyst.Core.Modules.Ledger;
using Catalyst.Core.Modules.Mempool;
using Catalyst.Core.Modules.P2P.Discovery.Hastings;
using Catalyst.Core.Modules.Rpc.Server;
using Catalyst.Core.Modules.Web3;
using Catalyst.Modules.POA.Consensus;
using Catalyst.Modules.POA.P2P;
using Serilog;

namespace Catalyst.Node.POA.CE
{
    public class CatalystNodePoa : ICatalystNode
    {
        public IConsensus Consensus { get; }
        private readonly IContract _contract;
        private readonly IDfs _dfs;
        private readonly ILedger _ledger;
        private readonly IKeySigner _keySigner;
        private readonly ILogger _logger;
        private readonly IMempool<MempoolDocument> _memPool;
        private readonly IPeerService _peer;
        private readonly IRpcServer _rpcServer;
        private readonly IPeerClient _peerClient;
        private readonly IPeerSettings _peerSettings;

        public CatalystNodePoa(IKeySigner keySigner,
            IPeerService peer,
            IConsensus consensus,
            IDfs dfs,
            ILedger ledger,
            ILogger logger,
            IRpcServer rpcServer,
            IPeerClient peerClient,
            IPeerSettings peerSettings,
            IMempool<MempoolDocument> memPool,
            IContract contract = null)
        {
            _peer = peer;
            _peerClient = peerClient;
            _peerSettings = peerSettings;
            Consensus = consensus;
            _dfs = dfs;
            _ledger = ledger;
            _keySigner = keySigner;
            _logger = logger;
            _rpcServer = rpcServer;
            _memPool = memPool;
            _contract = contract;
        }

        public async Task StartSockets()
        {
            await _rpcServer.StartAsync().ConfigureAwait(false);
            await _peerClient.StartAsync().ConfigureAwait(false);
            await _peer.StartAsync().ConfigureAwait(false);
        }

        public async Task RunAsync(CancellationToken ct)
        {
            _logger.Information("Starting the Catalyst Node");
            _logger.Information("using PeerIdentifier: {0}", _peerSettings.PeerId);

            await StartSockets().ConfigureAwait(false);
            Consensus.StartProducing();

            bool exit;

            do
            {
                await Task.Delay(300, ct); //just to get the exit message at the bottom

                _logger.Debug("Type 'exit' to exit, anything else to continue");
                exit = string.Equals(Console.ReadLine(), "exit", StringComparison.OrdinalIgnoreCase);
            } while (!ct.IsCancellationRequested && !exit);

            _logger.Debug("Stopping the Catalyst Node");
        }

        public static void RegisterNodeDependencies(ContainerBuilder containerBuilder)
        {
            // core modules
            containerBuilder.RegisterType<CatalystNodePoa>().As<ICatalystNode>();
            containerBuilder.RegisterType<ConsoleUserOutput>().As<IUserOutput>();
            containerBuilder.RegisterType<ConsoleUserInput>().As<IUserInput>();

            // core modules
            containerBuilder.RegisterModule(new CoreLibProvider());
            containerBuilder.RegisterModule(new MempoolModule());
            containerBuilder.RegisterModule(new ConsensusModule());
            containerBuilder.RegisterModule(new LedgerModule());
            containerBuilder.RegisterModule(new DiscoveryHastingModule());
            containerBuilder.RegisterModule(new RpcServerModule());
            containerBuilder.RegisterModule(new BulletProofsModule());
            containerBuilder.RegisterModule(new KeystoreModule());
            containerBuilder.RegisterModule(new KeySignerModule());
            containerBuilder.RegisterModule(new RpcServerModule());
            containerBuilder.RegisterModule(new DfsModule());
            containerBuilder.RegisterModule(new ConsensusModule());
            containerBuilder.RegisterModule(new BulletProofsModule());
            containerBuilder.RegisterModule(new AuthenticationModule());
            containerBuilder.RegisterModule(new ApiModule("http://*:5005",
                new List<string> {"Catalyst.Core.Modules.Web3"}));

            // node modules
            containerBuilder.RegisterModule(new PoaConsensusModule());
            containerBuilder.RegisterModule(new PoaP2PModule());
        }
    }
}
