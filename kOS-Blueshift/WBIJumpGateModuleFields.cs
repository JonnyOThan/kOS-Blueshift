using System;
using System.Reflection;
using Blueshift;
using kOS.Safe.Encapsulation;
using kOS.Safe.Encapsulation.Suffixes;
using kOS.Safe.Utilities;
using kOS.Suffixed;
using kOS.Suffixed.PartModuleField;

namespace kOS.AddOns
{
	// Token: 0x02000002 RID: 2
	[KOSNomenclature("WBIJumpGateModule")]
	public class WBIJumpGateModuleFields : PartModuleFields
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public WBIJumpGateModuleFields(PartModule module, SharedObjects shared) : base(module, shared)
		{
			this.InitializeSuffixes();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002060 File Offset: 0x00000260
		private void InitializeSuffixes()
		{
			base.AddSuffix("HASDESTINATION", new Suffix<BooleanValue>(() => this.JumpGateModule.destinationVessel != null, ""));
			base.AddSuffix("DESTINATION", new SetSuffix<VesselTarget>(new SuffixGetDlg<VesselTarget>(this.GetDestination), new SuffixSetDlg<VesselTarget>(this.SetDestination), ""));
			base.AddSuffix("DESTINATIONS", new Suffix<ListValue<VesselTarget>>(new SuffixGetDlg<ListValue<VesselTarget>>(this.GetDestinations), ""));
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000020DC File Offset: 0x000002DC
		private ListValue<VesselTarget> GetDestinations()
		{
			ListValue<VesselTarget> listValue = new ListValue<VesselTarget>();
			foreach (Vessel vessel in this.JumpGateModule.jumpgates)
			{
				listValue.Add(VesselTarget.CreateOrGetExisting(vessel, this.shared));
			}
			return listValue;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000004 RID: 4 RVA: 0x00002140 File Offset: 0x00000340
		private WBIJumpGate JumpGateModule
		{
			get
			{
				return this.partModule as WBIJumpGate;
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x0000214D File Offset: 0x0000034D
		private void SetDestination(VesselTarget value)
		{
			if (!this.JumpGateModule.jumpgates.Contains(value.Vessel))
			{
				throw new InvalidOperationException($"{value} is not a valid destination");
			}

			this.JumpGateModule.jumpgateSelected(value.Vessel);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002160 File Offset: 0x00000360
		private VesselTarget GetDestination()
		{
			return VesselTarget.CreateOrGetExisting(this.JumpGateModule.destinationVessel, this.shared);
		}
	}
}
