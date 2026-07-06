using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace CobaltTrainer
{
    [BepInPlugin("cobalt.trainer", "Cobalt Trainer", "1.0.0")]
    public class CobaltTrainer : BaseUnityPlugin
    {
        private static CobaltTrainer Instance;

        public static ConfigEntry<bool> GodMode;
        public static ConfigEntry<bool> NoClip;
        public static ConfigEntry<float> SpeedMul;

        private void Awake()
        {
            Instance = this;
            GodMode = Config.Bind("General", "GodMode", false, "Infinite health/stamina/mana");
            NoClip = Config.Bind("General", "NoClip", false, "Disable collision");
            SpeedMul = Config.Bind("General", "SpeedMul", 1.0f, "Movement multiplier");

            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "cobalt.trainer.patches");
            Logger.LogInfo("Cobalt Trainer loaded.");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F5)) GodMode.Value = !GodMode.Value;
            if (Input.GetKeyDown(KeyCode.F6)) NoClip.Value = !NoClip.Value;
            if (Input.GetKeyDown(KeyCode.F7)) SpeedMul.Value = SpeedMul.Value == 1.0f ? 2.5f : 1.0f;
        }

        public static bool IsGodMode() => GodMode?.Value ?? false;
        public static bool IsNoClip() => NoClip?.Value ?? false;
        public static float GetSpeedMul() => SpeedMul?.Value ?? 1.0f;
    }
}