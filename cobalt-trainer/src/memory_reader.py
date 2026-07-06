"""Low-level memory reading utilities for game process."""

import ctypes
import struct
from ctypes import wintypes

class MemoryReader:
    """Reads process memory given a PID and base address."""
    
    def __init__(self, pid: int):
        self.pid = pid
        self.handle = None
        self._open_process()
    
    def _open_process(self):
        PROCESS_VM_READ = 0x0010
        kernel32 = ctypes.WinDLL('kernel32', use_last_error=True)
        self.handle = kernel32.OpenProcess(PROCESS_VM_READ, False, self.pid)
        if not self.handle:
            raise RuntimeError(f"Failed to open process {self.pid}")
    
    def read_int32(self, address: int) -> int:
        """Read a 4-byte signed integer from process memory."""
        buffer = ctypes.create_string_buffer(4)
        bytes_read = ctypes.c_size_t(0)
        kernel32 = ctypes.WinDLL('kernel32', use_last_error=True)
        success = kernel32.ReadProcessMemory(
            self.handle, 
            ctypes.c_void_p(address),
            buffer, 
            4, 
            ctypes.byref(bytes_read)
        )
        if not success:
            raise RuntimeError(f"Failed to read memory at {hex(address)}")
        return struct.unpack('<i', buffer.raw)[0]
    
    def close(self):
        if self.handle:
            kernel32 = ctypes.WinDLL('kernel32')
            kernel32.CloseHandle(self.handle)
            self.handle = None