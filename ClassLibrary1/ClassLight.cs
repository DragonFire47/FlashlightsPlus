using HarmonyLib;
using UnityEngine.XR;

namespace FlashlightsPlus
{
	[HarmonyPatch(typeof(PLPlayerController), "HandleFlashlight")]
	class ClassLight
	{
		static void Postfix(PLPlayerController __instance)
		{
			bool flag = Global.LColor == 2;
			if (flag)
			{
				bool flag2 = __instance.MyPawn.Flashlight.color != PLPlayer.GetClassColorFromID(__instance.MyPawn.MyPlayer.GetClassID());
				if (flag2)
				{
					__instance.MyPawn.Flashlight.color = PLPlayer.GetClassColorFromID(__instance.MyPawn.MyPlayer.GetClassID());
				}
			}
			bool enabled = XRSettings.enabled;
			if (enabled)
			{
				__instance.MyPawn.Flashlight.spotAngle = 360f;
				__instance.MyPawn.Flashlight.range = 60f;
				__instance.MyPawn.Flashlight.intensity = 1f;
			}
			else
			{
				__instance.MyPawn.Flashlight.spotAngle = 56.5f + (float)(20 * (Global.LSize - 1));
				__instance.MyPawn.Flashlight.range = 60f - (float)(30 * (Global.LSize - 1));
				bool flag3 = Global.LSize != 0;
				if (flag3)
				{
					__instance.MyPawn.Flashlight.intensity = 2f / (float)Global.LSize;
				}
				else
				{
					__instance.MyPawn.Flashlight.intensity = 4f;
				}
			}
		}
	}
}
