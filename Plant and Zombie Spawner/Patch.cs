using HarmonyLib;
using Il2Cpp;

namespace Plant_and_Zombie_Spawner
{
    internal class Patch
    {
        [HarmonyPatch(typeof(AlmanacCardUI))]
        public class GetSeedType
        {

            public static int SeedType = -1;

            [HarmonyPostfix]
            [HarmonyPatch("OnMouseDown")]
            public static void OnMouseDown(AlmanacCardUI __instance)
            {
                GetSeedType.SeedType = (int)__instance.PlantType;
            }
        }

        [HarmonyPatch(typeof(AlmanacCardUI))]
        public class GetZombieType
        {

            public static int ZombieType = -1;

            [HarmonyPostfix]
            [HarmonyPatch("OnMouseDown")]
            public static void OnMouseDown(AlmanacCardUI __instance)
            {
                if (__instance.ZombieType != null)
                    GetZombieType.ZombieType = (int)__instance.ZombieType;
            }
        }
    }
}
