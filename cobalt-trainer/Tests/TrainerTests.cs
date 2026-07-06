using System;
using cobalt_trainer.Core;
using Xunit;

namespace cobalt_trainer.Tests
{
    public class TrainerTests
    {
        [Fact]
        public void GodMode_Toggle_ChangesState()
        {
            var memory = new MemoryManager("NotRunningProcess");
            var trainer = new Trainer(memory);

            bool initial = trainer.GodModeEnabled;
            trainer.ToggleGodMode();
            bool toggled = trainer.GodModeEnabled;

            Assert.NotEqual(initial, toggled);
        }

        [Fact]
        public void Stamina_Toggle_ChangesState()
        {
            var memory = new MemoryManager("NotRunningProcess");
            var trainer = new Trainer(memory);

            bool initial = trainer.StaminaEnabled;
            trainer.ToggleStamina();
            bool toggled = trainer.StaminaEnabled;

            Assert.NotEqual(initial, toggled);
        }

        [Fact]
        public void MaxResources_DoesNotThrow()
        {
            var memory = new MemoryManager("NotRunningProcess");
            var trainer = new Trainer(memory);

            var ex = Record.Exception(() => trainer.MaxResources());
            Assert.Null(ex);
        }
    }
}