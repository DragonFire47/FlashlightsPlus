using HarmonyLib;
using UnityEngine;
using UnityEngine.XR;

namespace FlashlightsPlus
{
	[HarmonyPatch(typeof(PLPlayerController), "HandleFlashlight")]
    class RainbowLight
	{
		static void Postfix(PLPawn ___MyPawn)
		{
			float num = Mathf.PingPong(Time.time / 2f, 1f);
			Gradient gradient = new Gradient();
			GradientColorKey[] array = new GradientColorKey[6];
			array[0].color = Color.blue;
			array[0].time = 0f;
			array[1].color = Color.cyan;
			array[1].time = 0.2f;
			array[2].color = Color.green;
			array[2].time = 0.4f;
			array[3].color = Color.yellow;
			array[3].time = 0.6f;
			array[4].color = Color.magenta;
			array[4].time = 0.8f;
			array[5].color = Color.red;
			array[5].time = 1f;
			GradientAlphaKey[] array2 = new GradientAlphaKey[2];
			array2[0].alpha = 1f;
			array2[0].time = 0f;
			array2[1].alpha = 1f;
			array2[1].time = 1f;
			gradient.SetKeys(array, array2);

			if (Global.LColor == 1)
			{
				___MyPawn.Flashlight.color = gradient.Evaluate(num);
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
