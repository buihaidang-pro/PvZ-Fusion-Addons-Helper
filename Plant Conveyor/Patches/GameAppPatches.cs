using HarmonyLib;
using Il2Cpp;

namespace PlantConveyor.Patches
{
    [HarmonyPatch(typeof(GameAPP))]
    public static class GameAppPatches
    {
        [HarmonyPatch(nameof(GameAPP.Awake))]
        [HarmonyPostfix]
        private static void PostAwake() => DefinePlantIDsList();
        private static void DefinePlantIDsList()
        {
            Core.Instance.PlantIDs = new();
            foreach (PlantType plantType in System.Enum.GetValues(typeof(PlantType)))
            {
                int id = (int)plantType;
                if (id >= 0)
                    Core.Instance.PlantIDs.Add(id);
            }
        }
    }
}
