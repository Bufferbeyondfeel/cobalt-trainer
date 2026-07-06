"""Core trainer logic with hotkey handling and memory patching."""

import time
import keyboard
from src.memory_reader import MemoryReader

class CobaltTrainer:
    """Main trainer class managing game modifications."""
    
    def __init__(self, pid: int, health_offset: int = 0x1A2B3C):
        self.pid = pid
        self.health_offset = health_offset
        self.reader = MemoryReader(pid)
        self.active = True
        self._setup_hotkeys()
    
    def _setup_hotkeys(self):
        keyboard.add_hotkey('f1', self._toggle_infinite_health)
        keyboard.add_hotkey('f2', self._max_mana)
        print("[Cobalt] Hotkeys: F1=Infinite Health, F2=Max Mana")
    
    def _toggle_infinite_health(self):
        print("[Cobalt] Infinite Health toggled (simulated)")
    
    def _max_mana(self):
        print("[Cobalt] Max Mana applied (simulated)")
    
    def get_health(self) -> int:
        """Read current health from game memory."""
        base_address = 0x400000  # Example base address
        return self.reader.read_int32(base_address + self.health_offset)
    
    def run(self):
        """Main loop - keep trainer alive and listening."""
        print("[Cobalt] Trainer running. Press ESC to exit.")
        while self.active:
            if keyboard.is_pressed('esc'):
                self.active = False
            time.sleep(0.1)
        self.shutdown()
    
    def shutdown(self):
        keyboard.unhook_all()
        self.reader.close()
        print("[Cobalt] Trainer stopped.")