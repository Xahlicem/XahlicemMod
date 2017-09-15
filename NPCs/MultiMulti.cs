using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace XahlicemMod.NPCs {
    class MultiMulti : GlobalNPC {
        public override void SetDefaults(NPC npc) {
            float num = -0.5f;
            for (int i = 0; i < Main.player.Length; i++)
                if (Main.player[i].active) num += 0.5f;
            npc.lifeMax += (int)(npc.lifeMax * num);
        }
    }
}