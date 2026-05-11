using HarmonyLib;
using Il2Cpp;

namespace Plant_and_Zombie_Spawner
{
    internal class Patch
    {
        [HarmonyPatch(typeof(AlmanacPlantMenu), nameof(AlmanacPlantMenu.SelectCard))]
        public static class AlmanacPlantMenu_SelectCard_Patch
        {
            [HarmonyPrefix]
            public static void Prefix(AlmanacCardUI card)
            {
                if (card == null) return;
                GetSeedType.SeedType = (int)card.PlantType;
            }
        }

        [HarmonyPatch(typeof(AlmanacZombieMenu), nameof(AlmanacZombieMenu.SelectCard))]
        public static class AlmanacZombieMenu_SelectCard_Patch
        {
            [HarmonyPrefix]
            public static void Prefix(AlmanacCardUI card)
            {
                if (card == null) return;
                GetZombieType.ZombieType = (int)card.ZombieType;
            }
        }

        public class GetSeedType
        {
            public static int SeedType = -1;
        }

        public class GetZombieType
        {
            public static int ZombieType = -1;
        }
    }
}
