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
            return "Runs sub-commands: FlashlightType, FlashlightColor ; The short version of the commands are their capital letters, ie: FlashlightColor = fc\"";
        }

        public override void Execute(string arguments)
        {
            string[] args = arguments.Split(new char[] { ' ' });
            switch (args[0].ToLower())
            {
                default:
                    PLServer.Instance.AddNotification("not a valid subcommand. Subcommands: FlashlightType, FlashlightColor ; The short version of the commands are their capital letters, ie: FlashlightColor = fc", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                    break;
                case "flashlighttype":
                case "ft":
                    if (args.Length > 1 && int.TryParse(args[1], out int type))
                    {
                        Global.LSize = type;
                        if (type == 0)
                        {
                            PLServer.Instance.AddNotification("Set flashlight type to Tight Beam", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                        }
                        else if (type == 1)
                        {
                            PLServer.Instance.AddNotification("Set flashlight type to Normal Beam", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                        }
                        else if (type == 2)
                        {
                            PLServer.Instance.AddNotification("Set flashlight type to Wide Beam", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                        }
                        else
                        {
                            PLServer.Instance.AddNotification("Value must be 0 (Tight), 1 (Normal), or 2 (Wide).", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                        }
                    }
                    else
                    {
                        PLServer.Instance.AddNotification("Use a number. example: /FlashlightType 2", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                    }
                    break;
                case "flashlightcolor":
                case "fc":
                    if (args.Length > 1 && int.TryParse(args[1], out int color))
                    {
                        Global.LColor = color;
                        if (color == 0)
                        {
                            PLServer.Instance.AddNotification("Set flashlight color to White", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                        }
                        else if (color == 1)
                        {
                            PLServer.Instance.AddNotification("Set flashlight color to Rainbows", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                        }
                        else if (color == 2)
                        {
                            PLServer.Instance.AddNotification("Set flashlight color to Class", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                        }
                        else
                        {
                            PLServer.Instance.AddNotification("Value must be 0 (white), 1 (rainbow), or 2 (Class).", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                        }
                    }
                    else
                    {
                        PLServer.Instance.AddNotification("Use a number. example: /FlashlightColor 2", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, false);
                    }
                    break;
            }
        }
    }
}
