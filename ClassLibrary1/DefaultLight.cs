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
			bool flag = Global.LColor == 0;
			if (flag)
			{
				___MyPawn.Flashlight.color = Color.white;
			}
			bool enabled = XRSettings.enabled;
			if (enabled)
			{
				___MyPawn.Flashlight.spotAngle = 360f;
				___MyPawn.Flashlight.range = 60f;
				___MyPawn.Flashlight.intensity = 1f;
			}
			else
			{
				___MyPawn.Flashlight.spotAngle = 56.5f + (float)(20 * (Global.LSize - 1));
				___MyPawn.Flashlight.range = 60f - (float)(30 * (Global.LSize - 1));
				bool flag2 = Global.LSize != 0;
				if (flag2)
				{
					___MyPawn.Flashlight.intensity = 2f / (float)Global.LSize;
				}
				else
				{
					___MyPawn.Flashlight.intensity = 4f;
				}
			}
		}
	}
}
