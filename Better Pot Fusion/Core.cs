using Il2Cpp;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(Better_Pot_Fusion.Core), "Better Pot Fusion", "231.0.0", "dynaslash & TuanAnh2901", null)]
[assembly: MelonGame("LanPiaoPiao", "PlantsVsZombiesRH")]

namespace Better_Pot_Fusion
{
    public class Core : MelonMod
    {

        private Dictionary<int, int> plantMixDictionary = new Dictionary<int, int>
        {
            { 26, 1112}, // Cabbage
			{ 28, 1114}, // Kernel
			{ 29, 1130}, // Garlic
			{ 30, 1133}, // Umbrella
			{ 31, 1136}, // Marigold
			{ 32, 1125}, // Melon
            { 1, 1184 }, // Sunflower
		};

        public override void OnInitializeMelon()
        {
            MelonLogger.Msg("Better Pot Fusion is loaded!");
        }

        public override void OnUpdate()
        {
            if (Board.Instance != null && Mouse.Instance.theItemOnMouse != null && Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftShift))
            {
                TryFusion();
            }
        }

        private void TryFusion()
        {
            // Try iterating through plants on the board using reflection for v3.6.1 API
            var board = Board.Instance;
            var entityType = board.GetType();
            
            // Try different possible field names for plant collections
            var plantsField = entityType.GetField("plants") ?? entityType.GetField("_plants") ?? entityType.GetField("plantList") ?? entityType.GetField("_plantList");
            if (plantsField == null) return;
            
            var plants = plantsField.GetValue(board) as Il2CppSystem.Collections.Generic.List<Plant>;
            if (plants == null) return;
            
            for (int i = 0; i < plants.Count; i++)
            {
                var plant = plants[i];
                if (plant != null && plant.thePlantColumn == Mouse.Instance.theMouseColumn && plant.thePlantRow == Mouse.Instance.theMouseRow)
                {
                    int targetPlantType = GetTargetPlantType(plant);

                    if (targetPlantType != 0)
                    {
                        if (CreatePlant.Instance.SetPlant(plant.thePlantColumn, plant.thePlantRow, (PlantType)targetPlantType, null, Vector2.zero, true, true) != null)
                        {
                            UpdateSunAndCooldowns();
                            plant.Die(0);
                        }
                    }
                    break;
                }
            }
        }

        private int GetTargetPlantType(Plant plant)
        {
            int plantTypeOnMouse = (int)Mouse.Instance.thePlantTypeOnMouse;

            if ((int)plant.thePlantType == 27)
            {
                return GetMixData(plantTypeOnMouse);
            }
            else if ((int)plant.thePlantType == 1137 && plantTypeOnMouse == 1)
                return 936;

            return 0;
        }

        private int GetMixData(int plantTypeOnMouse)
        {
            return plantMixDictionary.TryGetValue(plantTypeOnMouse, out int mixPlantType) ? mixPlantType : 0;
        }

        private void UpdateSunAndCooldowns()
        {
            if (Mouse.Instance.thePlantOnGlove == null)
            {
                Board.Instance.theSun -= Mouse.Instance.theCardOnMouse.theSeedCost;
                Mouse.Instance.theCardOnMouse.CD = 0f;
                Mouse.Instance.theCardOnMouse.PutDown();
                UnityEngine.Object.Destroy(Mouse.Instance.theItemOnMouse);
                Mouse.Instance.ClearItemOnMouse(false);
            }
            else
            {
                Mouse.Instance.thePlantOnGlove.GetComponent<Plant>().Die(0);
                Mouse.Instance.thePlantOnGlove = null;
                Glove.Instance.CD = 0f;
                UnityEngine.Object.Destroy(Mouse.Instance.theItemOnMouse);
                Mouse.Instance.ClearItemOnMouse(true);
            }
        }
    }
}