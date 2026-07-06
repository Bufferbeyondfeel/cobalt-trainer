using HarmonyLib;
using UnityEngine;

namespace CobaltTrainer.Patches
{
    [HarmonyPatch(typeof(PlayerMovement))]
    internal class MovementPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("ApplyMovement")]
        static void Postfix_ApplyMovement(PlayerMovement __instance, ref Vector3 moveDirection)
        {
            float mul = CobaltTrainer.GetSpeedMul();
            if (mul != 1f)
            {
                moveDirection *= mul;
            }
        }
    }
}