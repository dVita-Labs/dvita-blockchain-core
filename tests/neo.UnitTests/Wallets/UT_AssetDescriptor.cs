using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Neo.SmartContract.Native;
using System;

namespace Neo.UnitTests.Wallets
{
    [TestClass]
    public class UT_AssetDescriptor
    {
        [TestMethod]
        public void TestConstructorWithNonexistAssetId()
        {
            var snapshot = TestBlockchain.GetTestSnapshot();
            Action action = () =>
            {
                var descriptor = new Neo.Wallets.AssetDescriptor(snapshot, ProtocolSettings.Default, UInt160.Parse("01ff00ff00ff00ff00ff00ff00ff00ff00ff00a4"));
            };
            action.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void Check_GAS()
        {
            var snapshot = TestBlockchain.GetTestSnapshot();
            var descriptor = new Neo.Wallets.AssetDescriptor(snapshot, ProtocolSettings.Default, NativeContract.GAS.Hash);
            descriptor.AssetId.Should().Be(NativeContract.GAS.Hash);
            descriptor.AssetName.Should().Be(nameof(GasToken));
            descriptor.ToString().Should().Be(nameof(GasToken));
            descriptor.Symbol.Should().Be("DVG");
            descriptor.Decimals.Should().Be(8);
        }

        [TestMethod]
        public void Check_NEO()
        {
            var snapshot = TestBlockchain.GetTestSnapshot();
            var descriptor = new Neo.Wallets.AssetDescriptor(snapshot, ProtocolSettings.Default, NativeContract.DVITA.Hash);
            descriptor.AssetId.Should().Be(NativeContract.DVITA.Hash);
            descriptor.AssetName.Should().Be(nameof(DvitaToken));
            descriptor.ToString().Should().Be(nameof(DvitaToken));
            descriptor.Symbol.Should().Be("DVITA");
            descriptor.Decimals.Should().Be(0);
        }
    }
}
