using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Melee {
    public class CorruptSpear1 : ModItem {
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("An example spear");
        }

        public override void SetDefaults() {
            item.damage = 15;
            item.useStyle = 5;
            item.useAnimation = 30;
            item.useTime = 35;
            item.shootSpeed = 2.4f;
            item.knockBack = 6.5f;
            item.width = 32;
            item.height = 32;
            item.scale = 1f;
            item.rare = 5;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("CSProj");
            item.value = 1000;
            item.noMelee = true; // Important because the spear is acutally a projectile instead of an item. This prevents the melee hitbox of this item.
            item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
            item.melee = true;
            item.autoReuse = true; // Most spears dont autoReuse, but it's possible
        }
        public override Vector2? HoldoutOffset() {
            return new Vector2(20, 0);
        }

        public override bool CanUseItem(Player player) {
            return player.ownedProjectileCounts[item.shoot] < 1; // This is to ensure the spear doesn't bug out when using autoReuse = true
        }
    }
}