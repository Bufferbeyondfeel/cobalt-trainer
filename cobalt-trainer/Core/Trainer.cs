using System;

namespace cobalt_trainer.Core
{
    public class Trainer
    {
        private readonly MemoryManager _memory;
        public bool GodModeEnabled { get; private set; }
        public bool StaminaEnabled { get; private set; }

        // Example addresses (would be real offsets in a real project)
        private const IntPtr GodModeAddress = (IntPtr)0x12345678;
        private const IntPtr StaminaAddress = (IntPtr)0x87654321;
        private const IntPtr ResourceBaseAddress = (IntPtr)0xAABBCCDD;

        public Trainer(MemoryManager memory)
        {
            _memory = memory;
            GodModeEnabled = false;
            StaminaEnabled = false;

            if (!_memory.AttachToProcess())
            {
                Console.WriteLine("Could not attach to game. Some features may not work.");
            }
        }

        public void ToggleGodMode()
        {
            GodModeEnabled = !GodModeEnabled;
            byte[] data = GodModeEnabled ? new byte[] { 0x01 } : new byte[] { 0x00 };
            _memory.WriteBytes(GodModeAddress, data);
        }

        public void ToggleStamina()
        {
            StaminaEnabled = !StaminaEnabled;
            byte[] data = StaminaEnabled ? new byte[] { 0x01 } : new byte[] { 0x00 };
            _memory.WriteBytes(StaminaAddress, data);
        }

        public void MaxResources()
        {
            // Write max values for resources (example: 9999)
            byte[] resourceData = BitConverter.GetBytes(9999);
            _memory.WriteBytes(ResourceBaseAddress, resourceData);
        }
    }
}