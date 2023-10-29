using PulsarModLoader;

namespace FlashlightsPlus
{
	public class Mod : PulsarMod
	{
		public override string Version
		{
			get
			{
				return "0.2.0";
			}
		}

		public override string Author
		{
			get
			{
				return "DeathsVendetta, Dragon, and Engbot";
			}
		}

        public override string LongDescription
		{
			get
			{
				return "Provides multiple options for flashlight modification";
			}
		}

		public override string Name
		{
			get
			{
				return "FlashlightsPlus";
			}
		}

		public override string HarmonyIdentifier()
		{
			return "DeathsVendetta.Pulsar.FlashlightsPlus";
		}
	}
}
