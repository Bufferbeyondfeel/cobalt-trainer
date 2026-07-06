using System;
using System.Diagnostics;
using MemorySharp;

namespace cobalt_trainer.Core
{
    public class MemoryManager : IDisposable
    {
        private SharpMemory _memory;
        private readonly string _processName;
        private bool _attached;

        public MemoryManager(string processName)
        {
            _processName = processName;
            _attached = false;
        }

        public bool AttachToProcess()
        {
            try
            {
                var processes = Process.GetProcessesByName(_processName);
                if (processes.Length == 0)
                {
                    Console.WriteLine($"Process '{_processName}' not found.");
                    return false;
                }

                _memory = new SharpMemory(processes[0].Id);
                _attached = true;
                Console.WriteLine($"Attached to {_processName} (PID: {processes[0].Id})");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to attach: {ex.Message}");
                return false;
            }
        }

        public void WriteBytes(IntPtr address, byte[] data)
        {
            if (!_attached) return;
            _memory.WriteBytes(address, data);
        }

        public byte[] ReadBytes(IntPtr address, int size)
        {
            if (!_attached) return new byte[size];
            return _memory.ReadBytes(address, size);
        }

        public void Dispose()
        {
            _memory?.Dispose();
        }
    }
}