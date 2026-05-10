using HarmonyLib;
using Il2Cpp;

namespace No_Craters
{
    internal class Patch
    {
        // Prevent DoomShroom from creating craters when exploding
        [HarmonyPatch(typeof(DoomShroom))]
        public class DoomShroom_Patch
        {
            // Skip the entire AnimExplode method to prevent crater creation
            [HarmonyPrefix]
            [HarmonyPatch("AnimExplode")]
            private static bool AnimExplode(DoomShroom __instance)
            {
                __instance.Die(Plant.DieReason.Default);
                return false; // Skip original method
            }
        }

        // Prevent IceDoom from creating craters when exploding
        [HarmonyPatch(typeof(IceDoom))]
        public class IceDoom_Patch
        {
            // Skip the entire AnimExplode method to prevent crater creation
            [HarmonyPrefix]
            [HarmonyPatch("AnimExplode")]
            private static bool AnimExplode(IceDoom __instance)
            {
                __instance.Die(Plant.DieReason.Default);
                return false; // Skip original method
            }
        }
    }
}
