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

using Catalyst.Cli.Commands;
using Catalyst.Cli.Tests.UnitTests.Helpers;
using Catalyst.Core.Lib.Extensions;
using Catalyst.Protocol.Rpc.Node;
using Microsoft.Reactive.Testing;
using NSubstitute;
using Serilog;
using Xunit;

namespace Catalyst.Cli.Tests.UnitTests.Commands.Response
{
    public sealed class GetPeerCountResponseTests
    {
        private readonly TestScheduler _testScheduler = new TestScheduler();

        [Fact]
        public void GetPeerCountResponse_Can_Get_Output()
        {
            //Arrange
            var getPeerCountResponse = new GetPeerCountResponse {PeerCount = 50};
            var commandContext = TestCommandHelpers.GenerateCliResponseCommandContext(_testScheduler);
            var getPeerCountCommand = new PeerCountCommand(commandContext, Substitute.For<ILogger>());

            //Act
            TestCommandHelpers.GenerateResponse(commandContext, getPeerCountResponse);

            _testScheduler.Start();

            //Assert
            commandContext.UserOutput.Received(1).WriteLine(getPeerCountResponse.ToJsonString());
        }
    }
}