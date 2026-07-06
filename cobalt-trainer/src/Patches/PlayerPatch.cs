using HarmonyLib;
using UnityEngine;

namespace CobaltTrainer.Patches
{
    [HarmonyPatch(typeof(Player))]
    internal class PlayerPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("TakeDamage")]
        static bool Prefix_TakeDamage(ref float damage)
        {
            if (CobaltTrainer.IsGodMode())
            {
                damage = 0f;
                return false;
            }
            return true;
        }

        [HarmonyPostfix]
        [HarmonyPatch("Update")]
        static void Postfix_Update(Player __instance)
        {
            if (CobaltTrainer.IsGodMode())
            {
                __instance.Stamina = __instance.MaxStamina;
                __instance.Mana = __instance.MaxMana;
            }
        }
    }
}