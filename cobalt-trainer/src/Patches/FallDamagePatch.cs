using HarmonyLib;

namespace CobaltTrainer.Patches
{
    [HarmonyPatch(typeof(FallDamage))]
    internal class FallDamagePatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("ApplyFallDamage")]
        static bool Prefix_ApplyFallDamage()
        {
            if (CobaltTrainer.IsGodMode())
                return false;
            return true;
        }
    }
}