using HarmonyLib;
using UnityEngine;
using UnityEngine.XR;

namespace FlashlightsPlus
{
    [HarmonyPatch(typeof(PLPlayerController), "HandleFlashlight")]
	class FlashlightPatch
	{
		static void Postfix(PLPawn __MyPawn)
		{
			if (XRSettings.enabled)
			{
				__MyPawn.Flashlight.spotAngle = 360f;
				__MyPawn.Flashlight.range = 60f;
				__MyPawn.Flashlight.intensity = 1f;
			}
			else
			{
                __MyPawn.Flashlight.spotAngle = 56.5f;// + 20 * (Global.LSize - 1);
                __MyPawn.Flashlight.range = 60f - 30;// * (Global.LSize - 1);

                /*
				if (Global.LSize != 0)
				{
					__MyPawn.Flashlight.intensity = 2f / Global.LSize;
				}
				else
				{
					__MyPawn.Flashlight.intensity = 4f;
				}
                */
            }

            if (Global.LColor == 1)
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

                __MyPawn.Flashlight.color = gradient.Evaluate(num);
            }
            else if (Global.LColor == 2 && __MyPawn.Flashlight.color != PLPlayer.GetClassColorFromID(__MyPawn.MyPlayer.GetClassID()))
            {
                __MyPawn.Flashlight.color = PLPlayer.GetClassColorFromID(__MyPawn.MyPlayer.GetClassID());
            }
            else //if (Global.LColor == 0)
            {
                __MyPawn.Flashlight.color = Color.white;
            }
        }
	}
}
