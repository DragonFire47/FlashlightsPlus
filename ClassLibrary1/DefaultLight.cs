using HarmonyLib;
using UnityEngine;
using UnityEngine.XR;

namespace FlashlightsPlus
{
	[HarmonyPatch(typeof(PLPlayerController), "HandleFlashlight")]
	class DefaultLight
	{
		static void Postfix(PLPawn ___MyPawn)
		{
			if (Global.LColor == 0)
			{
				___MyPawn.Flashlight.color = Color.white;
			}
			if (XRSettings.enabled)
			{
				___MyPawn.Flashlight.spotAngle = 360f;
				___MyPawn.Flashlight.range = 60f;
				___MyPawn.Flashlight.intensity = 1f;
			}
			else
			{
				___MyPawn.Flashlight.spotAngle = 56.5f + 20 * (Global.LSize - 1);
				___MyPawn.Flashlight.range = 60f - 30 * (Global.LSize - 1);
				if (Global.LSize != 0)
				{
					___MyPawn.Flashlight.intensity = 2f / Global.LSize;
				}
				else
				{
					___MyPawn.Flashlight.intensity = 4f;
				}
			}
		}
	}
}
