using System;
using System.Reflection;
using HarmonyLib;
using AntiPause;

namespace AntiPause.HarmonyPatcher
{
	// Token: 0x0200000B RID: 11
	internal static class Patcher
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600003C RID: 60 RVA: 0x0000272E File Offset: 0x0000092E
		// (set) Token: 0x0600003D RID: 61 RVA: 0x00002735 File Offset: 0x00000935
		internal static bool isPatched { get; private set; }

		// Token: 0x0600003E RID: 62 RVA: 0x00002740 File Offset: 0x00000940
		internal static void Patch()
		{
			if (!Patcher.isPatched)
			{
				if (Patcher._harmony == null)
				{
					Patcher._harmony = new Harmony(Patcher.harmonyId);
				}
				try
				{
					Plugin.Log.Info("Applying Harmony patches");
					Patcher._harmony.PatchAll(Assembly.GetExecutingAssembly());
					Patcher.isPatched = true;
				}
				catch (Exception ex)
				{
					Plugin.Log.Info("Error applying Harmony patches: " + ex.Message);
                    Plugin.Log.Info(ex.Message);
				}
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000027BC File Offset: 0x000009BC
		internal static void Unpatch()
		{
			if (Patcher._harmony != null && Patcher.isPatched)
			{
				try
				{
                    Plugin.Log.Info("Removing Harmony patches");
					Patcher._harmony.UnpatchSelf();
					Patcher.isPatched = false;
				}
				catch (Exception ex)
				{
                    Plugin.Log.Error("Error removing Harmony patches: " + ex.Message);
                    Plugin.Log.Error(ex.Message);
				}
			}
		}

		// Token: 0x04000012 RID: 18
		internal static readonly string harmonyId = "com.github.renschi147.patchTest";

		// Token: 0x04000014 RID: 20
		private static Harmony _harmony;
	}
}
