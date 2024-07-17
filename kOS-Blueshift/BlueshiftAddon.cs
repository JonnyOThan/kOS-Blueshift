using System;
using kOS;
using kOS.AddOns;
using kOS.Safe.Encapsulation;
using kOS.Safe.Utilities;
using kOS.Suffixed;
using kOS.Suffixed.PartModuleField;

namespace kOS_Blueshift
{
	// Token: 0x02000003 RID: 3
	[kOSAddon("BLUESHIFT")]
	[KOSNomenclature("BlueshiftAddon")]
	public class BlueshiftAddon : Addon
	{
		// Token: 0x06000008 RID: 8 RVA: 0x00002190 File Offset: 0x00000390
		static BlueshiftAddon()
		{
			PartModuleFieldsFactory.RegisterConstructionMethod("WBIJumpGate", (PartModule partModule, SharedObjects shared) => new WBIJumpGateModuleFields(partModule, shared));
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000021AC File Offset: 0x000003AC
		public BlueshiftAddon(SharedObjects shared) : base(shared)
		{
			this.InitializeSuffixes();
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000021BB File Offset: 0x000003BB
		public override BooleanValue Available()
		{
			return true;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000021C3 File Offset: 0x000003C3
		private void InitializeSuffixes()
		{
		}
	}
}
