using HarmonyLib;
using UnityEngine;

namespace BrigherSuitColors;

[ContentWarningPlugin("Brighter Suit Colors", "1.0.0", true)]

[HarmonyPatch(typeof(PlayerVisor))]
public class PlayerVisorPatch
{
    [HarmonyPatch("Update")]
    [HarmonyPrefix]
    private static void UpdatePatch(PlayerVisor __instance)
    {
        if (__instance == null || __instance.visorColor == null)
        {
            return;
        }

        Color color = __instance.visorColor.Value;
        SkinnedMeshRenderer[] componentsInChildren = __instance.transform.GetChild(1).GetComponentsInChildren<SkinnedMeshRenderer>();
        for (int i = 0; i < componentsInChildren.Length; i++)
        {
            componentsInChildren[i].material.color = color;
        }
    }
}