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
using System.Diagnostics;
using System.Threading;
using Autofac;
using Catalyst.Abstractions;
using Catalyst.Abstractions.Cli;
using Catalyst.Abstractions.Consensus.Cycle;
using Catalyst.Abstractions.Cryptography;
using Catalyst.Abstractions.Network;
using Catalyst.Abstractions.P2P;
using Catalyst.Abstractions.P2P.Discovery;
using Catalyst.Abstractions.Types;
using Catalyst.Core.Lib;
using Catalyst.Core.Lib.Cli;
using Catalyst.Core.Lib.Cryptography;
using Catalyst.Core.Lib.Kernel;
using Catalyst.Core.Lib.P2P;
using Catalyst.Core.Lib.P2P.Discovery;
using Catalyst.Core.Modules.Authentication;
using Catalyst.Core.Modules.Consensus;
using Catalyst.Core.Modules.Consensus.Cycle;
using Catalyst.Core.Modules.Cryptography.BulletProofs;
using Catalyst.Core.Modules.Dfs;
using Catalyst.Core.Modules.KeySigner;
using Catalyst.Core.Modules.Keystore;
using Catalyst.Core.Modules.Ledger;
using Catalyst.Core.Modules.Mempool;
using Catalyst.Core.Modules.P2P.Discovery.Hastings;
using Catalyst.Core.Modules.Rpc.Server;
using Catalyst.Modules.POA.Consensus;
using Catalyst.Modules.POA.P2P;
using Catalyst.Protocol.Common;
using CommandLine;
using DnsClient;

namespace Catalyst.Node.POA.CE
{
    internal class Options
    {
        [Option("ipfs-password", HelpText = "The password for IPFS.  Defaults to prompting for the password.")]
        public string IpfsPassword { get; set; }
        
        [Option("ssl-cert-password", HelpText = "The password for ssl cert.  Defaults to prompting for the password.")]
        public string SslCertPassword { get; set; }
        
        [Option("node-password", HelpText = "The password for the node.  Defaults to prompting for the password.")]
        public string NodePassword { get; set; }
        
        [Option('o', "overwrite-config", HelpText = "Overwrite the data directory configs.")]
        public bool OverwriteConfig { get; set; }

        [Option("network-file", HelpText = "The name of the network file")]
        public string OverrideNetworkFile { get; set; }
    }
    
    internal static class Program
    {
        private static readonly Kernel Kernel;

        static Program()
        {
            Kernel = Kernel.Initramfs();

            AppDomain.CurrentDomain.UnhandledException += Kernel.LogUnhandledException;
            AppDomain.CurrentDomain.ProcessExit += Kernel.CurrentDomain_ProcessExit;
        }

        /// <summary>
        ///     For ref what passing custom boot logic looks like, this is the same as Kernel.StartNode()
        /// </summary>
        /// <param name="args"></param>
        /// <param name="kernel"></param>
        /// <returns></returns>
        private static void CustomBootLogic(Kernel kernel)
        {
            // core modules
            Kernel.ContainerBuilder.RegisterType<CatalystNodePoa>().As<ICatalystNode>();

            Kernel.ContainerBuilder.RegisterType<ConsoleUserOutput>().As<IUserOutput>();
            Kernel.ContainerBuilder.RegisterType<ConsoleUserInput>().As<IUserInput>();
            Kernel.ContainerBuilder.RegisterType<HastingsDiscovery>().As<IPeerDiscovery>();
            Kernel.ContainerBuilder.RegisterType<Core.Lib.Network.DnsClient>().As<IDns>();
            Kernel.ContainerBuilder.RegisterType<LookupClient>().As<ILookupClient>().UsingConstructor();
            Kernel.ContainerBuilder.RegisterType<PeerIdValidator>().As<IPeerIdValidator>();
            Kernel.ContainerBuilder.RegisterType<Neighbours>().As<INeighbours>();
            Kernel.ContainerBuilder.RegisterType<IsaacRandomFactory>().As<IDeterministicRandomFactory>();
            Kernel.ContainerBuilder.RegisterType<CycleConfiguration>().As<ICycleConfiguration>();
            Kernel.ContainerBuilder.RegisterType<LedgerSynchroniser>().As<ILedgerSynchroniser>();

            // core modules
            Kernel.ContainerBuilder.RegisterModule(new CoreLibProvider());
            Kernel.ContainerBuilder.RegisterModule(new MempoolModule());
            Kernel.ContainerBuilder.RegisterModule(new ConsensusModule());
            Kernel.ContainerBuilder.RegisterModule(new LedgerModule());
            Kernel.ContainerBuilder.RegisterModule(new DiscoveryHastingModule());
            Kernel.ContainerBuilder.RegisterModule(new RpcServerModule());
            Kernel.ContainerBuilder.RegisterModule(new BulletProofsModule());
            Kernel.ContainerBuilder.RegisterModule(new KeystoreModule());
            Kernel.ContainerBuilder.RegisterModule(new KeySignerModule());
            Kernel.ContainerBuilder.RegisterModule(new RpcServerModule());
            Kernel.ContainerBuilder.RegisterModule(new DfsModule());
            Kernel.ContainerBuilder.RegisterModule(new ConsensusModule());
            Kernel.ContainerBuilder.RegisterModule(new BulletProofsModule());
            Kernel.ContainerBuilder.RegisterModule(new AuthenticationModule());

            // node modules
            kernel.ContainerBuilder.RegisterModule(new PoaConsensusModule());
            kernel.ContainerBuilder.RegisterModule(new PoaP2PModule());

            kernel.StartContainer();
//            BsonSerializationProviders.Init();
            kernel.Instance.Resolve<ICatalystNode>()
                .RunAsync(new CancellationToken())
                .Wait();
        }
        public static int Main(string[] args)
        {
            // Parse the arguments.
            Parser.Default
               .ParseArguments<Options>(args)
               .WithParsed(Run);

            return Environment.ExitCode;
        }
        
        private static void Run(Options options)
        {
            Kernel.Logger.Information("Catalyst.Node started with process id {0}",
                Process.GetCurrentProcess().Id.ToString());
            
            try
            {
                Kernel
                    .WithDataDirectory()
                    .WithNetworksConfigFile(Network.Devnet, options.OverrideNetworkFile)
//                    .WithComponentsConfigFile()
                    .WithSerilogConfigFile()
                    .WithConfigCopier()
                    .WithPersistenceConfiguration()
                    .BuildKernel(options.OverwriteConfig)
                    .WithPassword(PasswordRegistryTypes.DefaultNodePassword, options.NodePassword)
                    .WithPassword(PasswordRegistryTypes.IpfsPassword, options.IpfsPassword)
                    .WithPassword(PasswordRegistryTypes.CertificatePassword, options.SslCertPassword)
                    .StartCustom(CustomBootLogic);

                // .StartCustom(CustomBootLogic);
                
                Environment.ExitCode = 0;
            }
            catch (Exception e)
            {
                Kernel.Logger.Fatal(e, "Catalyst.Node stopped unexpectedly");
                Environment.ExitCode = 1;
            }
        }
    }
}
