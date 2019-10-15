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

using System.Text;
using Catalyst.Abstractions.Hashing;
using Catalyst.Core.Lib.Config;
using Catalyst.Core.Lib.Extensions;
using Catalyst.Core.Modules.Hashing;
using Catalyst.Protocol.Rpc.Node;
using FluentAssertions;
using TheDotNetLeague.MultiFormats.MultiBase;
using TheDotNetLeague.MultiFormats.MultiHash;
using Xunit;
using Xunit.Abstractions;

namespace Catalyst.Cli.Tests.IntegrationTests.Commands
{
    public sealed class GetDeltaCommandTests : CliCommandTestsBase
    {
        public GetDeltaCommandTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Cli_Can_Request_Node_Info()
        {
            IHashProvider hashProvider = new HashProvider(HashingAlgorithm.GetAlgorithmMetadata("blake2b-256"));
            var hash = hashProvider.ComputeUtf8MultiHash("hello");

            var result = Shell.ParseCommand("getdelta", "-h", hash.ToBase32(), NodeArgumentPrefix, ServerNodeName);
            result.Should().BeTrue();

            var request = AssertSentMessageAndGetMessageContent<GetDeltaRequest>();
            request.DeltaDfsHash.ToByteArray().ToBase32().Should().Be(hash.ToBase32());
        }
    }
}