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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Catalyst.Core.Lib.Config;
using Catalyst.Protocol.Common;
using Catalyst.TestUtils;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Catalyst.Node.POA.CE.Tests.UnitTests.Config
{
    public sealed class ConfigCopierTests : FileSystemBasedTest
    {
        public ConfigCopierTests(ITestOutputHelper output) : base(output) { }

        private sealed class ConfigFilesOverwriteTestData : TheoryData<string, Network>
        {
            public ConfigFilesOverwriteTestData()
            {
                Add(Constants.NetworkConfigFile(Network.Mainnet), Network.Mainnet);
                Add(Constants.NetworkConfigFile(Network.Testnet), Network.Testnet);
                Add(Constants.NetworkConfigFile(Network.Devnet), Network.Devnet);
                Add(Constants.SerilogJsonConfigFile, Network.Devnet);
            }
        }

        [Theory]
        [ClassData(typeof(ConfigFilesOverwriteTestData))]
        [Trait(Traits.TestType, Traits.IntegrationTest)]
        public void RunConfigStartUp_Should_Not_Overwrite_An_Existing_Config_File(string moduleFileName,
            Network network)
        {
            RunConfigStartUp_Should_Not_Overwrite_Existing_Files(moduleFileName, network);
        }

        private void RunConfigStartUp_Should_Not_Overwrite_Existing_Files(string fileName, Network network = Network.Devnet)
        {
            var currentDirectory = FileSystem.GetCatalystDataDir();
            currentDirectory.Create();
            currentDirectory.Refresh();
            var existingFileInfo = new FileInfo(Path.Combine(currentDirectory.FullName, fileName));
            if (existingFileInfo.Directory != null && !existingFileInfo.Directory.Exists)
            {
                existingFileInfo.Directory.Create();
            }

            existingFileInfo.Create();
            existingFileInfo.Refresh();

            currentDirectory.Exists.Should().BeTrue("otherwise the test is not relevant");
            existingFileInfo.Exists.Should().BeTrue("otherwise the test is not relevant");

            new TestConfigCopier().RunConfigStartUp(currentDirectory.FullName, network);

            var expectedFileList = GetExpectedFileList(network).ToList();
            var configFiles = EnumerateConfigFiles(currentDirectory);

            configFiles.Should().BeEquivalentTo(expectedFileList);

            existingFileInfo.Length.Should().Be(0,
                "the bogus file should not have been overwritten");
        }

        private static IEnumerable<string> EnumerateConfigFiles(DirectoryInfo currentDirectory)
        {
            var filesOnDisk = currentDirectory.EnumerateFiles()
               .Select(f => f.Name);
            return filesOnDisk;
        }

        private static IEnumerable<string> GetExpectedFileList(Network network)
        {
            var requiredConfigFiles = new[]
            {
                Constants.NetworkConfigFile(network),
                Constants.SerilogJsonConfigFile
            };
            return requiredConfigFiles;
        }

        [Fact]
        [Trait(Traits.TestType, Traits.IntegrationTest)]
        public void RunConfigStartUp_Should_Create_Folder_If_Needed()
        {
            var currentDirectory = FileSystem.GetCatalystDataDir();
            currentDirectory.Exists.Should().BeFalse("otherwise the test is not relevant");

            var network = Network.Devnet;
            new TestConfigCopier().RunConfigStartUp(currentDirectory.FullName, network);

            var expectedFileList = GetExpectedFileList(network);
            var configFiles = EnumerateConfigFiles(currentDirectory);
            configFiles.Should().BeEquivalentTo(expectedFileList);
        }

        [Fact]
        public void Can_Copy_Overridden_Network_File()
        {
            var overrideFile = "TestOverride.json";
            var currentDirectory = FileSystem.GetCatalystDataDir();
            FileSystem.WriteTextFileToCddAsync(overrideFile,
                File.ReadAllText(Path.Combine(Constants.ConfigSubFolder, Constants.NetworkConfigFile(Network.Devnet))));
            new TestConfigCopier().RunConfigStartUp(currentDirectory.FullName, Network.Devnet, null, true, overrideFile);
            File.Exists(Path.Combine(currentDirectory.FullName, overrideFile)).Should().BeTrue();
        }

        internal class TestConfigCopier : ConfigCopier
        {
            protected override IEnumerable<string> RequiredConfigFiles(Network network, string overrideNetworkFile = null)
            {
                return new List<string>(GetExpectedFileList(network));
            }
        }
    }
}
