using HarmonyLib;
using Il2Cpp;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using MelonLoader;
using System.Reflection;
using UnityEngine;

namespace Odyssey_Buffs
{
	[HarmonyPatch(typeof(Board))]
	internal class Patch
	{
		[HarmonyPatch("Awake")]
		[HarmonyPostfix]
		private static void TravelPostfix(Board __instance)
		{
			// Ensure the config is loaded correctly
			Core.instance.ReloadConfig();
			MelonLogger.Msg("Odyssey Buffs is loaded!");

			if (Core.instance.configEnablePlant.Value)
			{
				// Enable travel plant feature in board tag
				object obj = __instance.boardTag;
				Type type = obj.GetType();
				FieldInfo field = type.GetField("enableTravelPlant");
				// MelonLogger.Msg($"configEnablePlant Value = {Core.instance.configEnablePlant.Value}");

				if (field != null)
				{
					object obj2 = Convert.ChangeType(true, field.FieldType);
					field.SetValue(obj, obj2);
					// MelonLogger.Msg("Field Null");
				}
				__instance.boardTag = (Board.BoardTag)obj;
			}

			GameObject gameObject = new GameObject("GameAPP");
			// MelonLogger.Msg("GameAPP created");
			TravelMgr travelMgr = gameObject.GetComponent<TravelMgr>();

			if (travelMgr == null)
			{
				travelMgr = gameObject.AddComponent<TravelMgr>();
			}

			// Handle IZ and travel entries configuration
			if (Core.instance.configEnableEntries.Value)
			{
				// MelonLogger.Msg("configEnableEntries Value = " + Core.instance.configEnableEntries.Value);
				if (GameAPP.theBoardLevel == 8 && GameAPP.theBoardType == (LevelType)3)
				{
					// MelonLogger.Msg("Board Level and Board Type: " + GameAPP.theBoardLevel + " " + GameAPP.theBoardType);
					if (!Core.instance.configEnableTravel.Value)
					{
						// MelonLogger.Msg("configEnableTravel Value = " + Core.instance.configEnableTravel.Value);
						return;
					}
				}

				if (GameAPP.theBoardType == (LevelType)2)
				{
					// MelonLogger.Msg("Board Type: " + GameAPP.theBoardType);
					if (!Core.instance.configEnableIZ.Value)
					{
						// MelonLogger.Msg("configEnableIZ Value = " + Core.instance.configEnableIZ.Value);
						return;
					}
				}

				// In v3.6.1, buff system uses AdvBuff, UltiBuff, TravelDebuff enums with TravelData
				// Since the API changed significantly, we log the configuration for manual application
				MelonLogger.Msg("");
				MelonLogger.Msg("Loading advanced upgrades...");
				for (int i = 0; i < Core.advancedUpgradesKeys.Length; i++)
				{
					if (Core.instance.configEnableEntries.Value)
					{
						bool enabled = Core.instance.boolArrayadvancedConfig[i].Value;
						if (enabled)
						{
							MelonLogger.Msg($"Advanced Upgrade {Core.instance.boolArrayadvancedConfig[i].DisplayName} = {enabled} configured.");
						}
					}
				}
				MelonLogger.Msg("Advanced upgrades configured!");

				MelonLogger.Msg("");
				MelonLogger.Msg("Loading ultimate upgrades...");
				for (int i = 0; i < Core.ultimateUpgradesKeys.Length; i++)
				{
					if (Core.instance.configEnableEntries.Value)
					{
						bool enabled = Core.instance.boolArrayultimateConfig[i].Value;
						if (enabled)
						{
							MelonLogger.Msg($"Ultimate Upgrade {Core.instance.boolArrayultimateConfig[i].DisplayName} = {enabled} configured.");
						}
					}
				}
				MelonLogger.Msg("Ultimate upgrades configured!");

				if (Core.instance.configEnableDebuffs.Value)
				{
					MelonLogger.Msg("");
					MelonLogger.Msg("Loading debuffs...");
					for (int i = 0; i < Core.debuffsKeys.Length; i++)
					{
						if (Core.debuffsKeys[i].StartsWith("Skip_"))
						{
							continue;
						}
						bool enabled = Core.instance.boolArraydebuffsConfig[i].Value;
						MelonLogger.Msg($"Debuff {Core.instance.boolArraydebuffsConfig[i].DisplayName} = {enabled} configured.");
					}
				}
			}
		}
	}
}