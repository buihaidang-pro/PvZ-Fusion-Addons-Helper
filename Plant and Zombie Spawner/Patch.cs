using HarmonyLib;
using Il2Cpp;

namespace Plant_and_Zombie_Spawner
{
    internal class Patch
    {
        // TODO: v3.6.1 broke AlmanacCardUI patches — OnMouseDown, OnClick, OnPointerClick, and OnEnable
        // no longer exist on AlmanacCardUI. The class was likely refactored in the game update.
        // The core spawn functionality (Core.cs OnUpdate) still works — just select a seed type
        // by setting Patch.GetSeedType.SeedType manually or via the Almanac when it opens.

        public class GetSeedType
        {
            public static int SeedType = -1;

            // Hook SetSeedType if/when the game calls it
            // [HarmonyPostfix]
            // [HarmonyPatch("SetSeedType")]
            // public static void SetSeedType(AlmanacCardUI __instance)
            // {
            //     GetSeedType.SeedType = (int)__instance.PlantType;
            // }
        }

        public class GetZombieType
        {
            public static int ZombieType = -1;

            // [HarmonyPostfix]
            // [HarmonyPatch("SetZombieType")]
            // public static void SetZombieType(AlmanacCardUI __instance)
            // {
            //     if (__instance.ZombieType != null)
            //         GetZombieType.ZombieType = (int)__instance.ZombieType;
            // }
        }
    }
}
