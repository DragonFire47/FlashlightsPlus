using PulsarModLoader.Chat.Commands.CommandRouter;

namespace FlashlightsPlus
{
	internal class Commands : ChatCommand
	{
		public override string[] CommandAliases()
		{
			return new string[] { "flashlightsplus", "fp" };
		}

		public override string Description()
		{
			return "Runs sub-commands.";
		}

		public override void Execute(string arguments)
		{
            string[] args = arguments.Split(new char[] { ' ' });
			int[] CommandArgs = new int[2];
			bool[] ArgConvertSuccess = new bool[2];
			string text = args[0].ToLower();
			if (args.Length >= 1 && !string.IsNullOrEmpty(text))
			{
				bool flag2 = args.Length >= 2;
				if (flag2)
				{
					ArgConvertSuccess[0] = int.TryParse(args[1], out CommandArgs[0]);
				}
				string text2 = text;
				if (!(text2 == "ft") && !(text2 == "flashlighttype"))
				{
					if (!(text2 == "fc") && !(text2 == "flashlightcolor"))
					{
						PLServer.Instance.AddNotification("not a valid subcommand. Subcommands: FlashlightType, FlashlightColor ; The short version of the commands are their capital letters, ie: FlashlightColor = fc", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
					}
					else
					{
						bool flag3 = ArgConvertSuccess[0];
						if (flag3)
						{
							bool flag4 = CommandArgs[0] > 2;
							if (flag4)
							{
								PLServer.Instance.AddNotification("cannot input a value higher than 2", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
							}
							else
							{
								Global.LColor = CommandArgs[0];
								bool flag5 = CommandArgs[0] == 0;
								if (flag5)
								{
									PLServer.Instance.AddNotification("Set flashlight color to White", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
								}
								else
								{
									bool flag6 = CommandArgs[0] == 1;
									if (flag6)
									{
										PLServer.Instance.AddNotification("Set flashlight color to Rainbows", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
									}
									else
									{
										PLServer.Instance.AddNotification("Set flashlight color to Class", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
									}
								}
							}
						}
						else
						{
							PLServer.Instance.AddNotification("Use a number. example: /FlashlightColor 2", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
						}
					}
				}
				else
				{
					bool flag7 = ArgConvertSuccess[0];
					if (flag7)
					{
						bool flag8 = CommandArgs[0] > 2;
						if (flag8)
						{
							PLServer.Instance.AddNotification("cannot input a value higher than 2", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
						}
						else
						{
							Global.LSize = CommandArgs[0];
							bool flag9 = CommandArgs[0] == 0;
							if (flag9)
							{
								PLServer.Instance.AddNotification("Set flashlight type to Tight Beam", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
							}
							else
							{
								bool flag10 = CommandArgs[0] == 1;
								if (flag10)
								{
									PLServer.Instance.AddNotification("Set flashlight type to Normal Beam", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
								}
								else
								{
									PLServer.Instance.AddNotification("Set flashlight type to Wide Beam", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
								}
							}
						}
					}
					else
					{
						PLServer.Instance.AddNotification("Use a number. example: /FlashlightType 2", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
					}
				}
			}
		}
	}
}
