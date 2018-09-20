using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.UI;

namespace XahlicemMod {

    public class XahlicemPlayer : ModPlayer {
        public override void Initialize() { }

        public override void ResetEffects() { }

        public override void PreUpdate() { }

        public override void ProcessTriggers(TriggersSet triggersSet) { }

        public override void SetControls() { }

        public override void PreUpdateBuffs() { }

        public override void PostUpdateBuffs() { }

        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff) { }

        public override void PostUpdateEquips() { }

        public override void PostUpdateMiscEffects() { }

        public override void PostUpdateRunSpeeds() { }

        public override void PreUpdateMovement() { }

        public override void PostUpdate() { }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit) { }

        public override void UpdateDead() { }

        public override void OnRespawn(Player player) { }

        public override TagCompound Save() {
            return base.Save();
        }

        public override void Load(TagCompound tag) { }

        public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath) { }

        public override void clientClone(ModPlayer clone) { }
    }
}