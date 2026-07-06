"""Unit tests for memory reader module."""

import unittest
from unittest.mock import patch, MagicMock
from src.memory_reader import MemoryReader

class TestMemoryReader(unittest.TestCase):
    
    @patch('src.memory_reader.ctypes.WinDLL')
    def test_open_process_success(self, mock_windll):
        mock_kernel32 = MagicMock()
        mock_kernel32.OpenProcess.return_value = 12345
        mock_windll.return_value = mock_kernel32
        
        reader = MemoryReader(1234)
        self.assertEqual(reader.pid, 1234)
        self.assertEqual(reader.handle, 12345)
    
    @patch('src.memory_reader.ctypes.WinDLL')
    def test_open_process_failure(self, mock_windll):
        mock_kernel32 = MagicMock()
        mock_kernel32.OpenProcess.return_value = 0
        mock_windll.return_value = mock_kernel32
        
        with self.assertRaises(RuntimeError):
            MemoryReader(9999)
    
    @patch('src.memory_reader.ctypes.WinDLL')
    def test_read_int32(self, mock_windll):
        mock_kernel32 = MagicMock()
        mock_kernel32.OpenProcess.return_value = 12345
        mock_kernel32.ReadProcessMemory.return_value = True
        mock_windll.return_value = mock_kernel32
        
        reader = MemoryReader(1234)
        # Simulate ReadProcessMemory writing to buffer
        def side_effect(handle, addr, buf, size, bytes_read):
            buf.value = b'\x10\x00\x00\x00'  # little-endian 16
            bytes_read.contents.value = 4
            return True
        mock_kernel32.ReadProcessMemory.side_effect = side_effect
        
        result = reader.read_int32(0x1000)
        self.assertEqual(result, 16)

if __name__ == '__main__':
    unittest.main()