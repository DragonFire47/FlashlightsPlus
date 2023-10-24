using HarmonyLib;
using UnityEngine.XR;

namespace FlashlightsPlus
{
	[HarmonyPatch(typeof(PLPlayerController), "HandleFlashlight")]
	class ClassLight
	{
		static void Postfix(PLPlayerController __instance)
		{
			if (Global.LColor == 2 && __instance.MyPawn.Flashlight.color != PLPlayer.GetClassColorFromID(__instance.MyPawn.MyPlayer.GetClassID()))
			{
				__instance.MyPawn.Flashlight.color = PLPlayer.GetClassColorFromID(__instance.MyPawn.MyPlayer.GetClassID());
			}


			if (XRSettings.enabled)
			{
				__instance.MyPawn.Flashlight.spotAngle = 360f;
				__instance.MyPawn.Flashlight.range = 60f;
				__instance.MyPawn.Flashlight.intensity = 1f;
			}
			else
			{
				__instance.MyPawn.Flashlight.spotAngle = 56.5f + 20 * (Global.LSize - 1);
				__instance.MyPawn.Flashlight.range = 60f - 30 * (Global.LSize - 1);

				if (Global.LSize != 0)
				{
					__instance.MyPawn.Flashlight.intensity = 2f / Global.LSize;
				}
				else
				{
					__instance.MyPawn.Flashlight.intensity = 4f;
				}
			}
		}
	}
}
