"""Entry point for Cobalt Trainer."""

import sys
import psutil
from src.trainer_core import CobaltTrainer

def find_enshrouded_pid() -> int:
    """Find the Enshrouded process ID."""
    for proc in psutil.process_iter(['pid', 'name']):
        if proc.info['name'] and 'enshrouded' in proc.info['name'].lower():
            return proc.info['pid']
    raise RuntimeError("Enshrouded process not found. Start the game first.")

def main():
    try:
        pid = find_enshrouded_pid()
        print(f"[Cobalt] Found Enshrouded (PID: {pid})")
        trainer = CobaltTrainer(pid)
        trainer.run()
    except RuntimeError as e:
        print(f"[Cobalt] Error: {e}")
        sys.exit(1)
    except KeyboardInterrupt:
        print("\n[Cobalt] Interrupted by user.")
        sys.exit(0)

if __name__ == "__main__":
    main()