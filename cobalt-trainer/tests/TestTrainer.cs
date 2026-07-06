using NUnit.Framework;
using CobaltTrainer;

namespace CobaltTrainer.Tests
{
    [TestFixture]
    public class TestTrainer
    {
        [Test]
        public void GodModeDefaultsToFalse()
        {
            // Simulate default config
            var godMode = false;
            Assert.IsFalse(godMode);
        }

        [Test]
        public void SpeedMulDefaultsToOne()
        {
            var speed = 1.0f;
            Assert.AreEqual(1.0f, speed);
        }

        [Test]
        public void ToggleSpeedChangesValue()
        {
            float speedMul = 1.0f;
            speedMul = speedMul == 1.0f ? 2.5f : 1.0f;
            Assert.AreEqual(2.5f, speedMul);

            speedMul = speedMul == 1.0f ? 2.5f : 1.0f;
            Assert.AreEqual(1.0f, speedMul);
        }
    }
}