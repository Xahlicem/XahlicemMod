using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Magic.Eater {
    public class Eater5 : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Eater of Inferno");
            Tooltip.SetDefault("Shoots flaming tiny eaters!.");
        }
        public override void SetDefaults() {
            item.CloneDefaults(mod.ItemType("Eater4"));
            item.damage *= 2;
            item.mana = (int)(item.mana * 1.25);
            item.value = (int)(item.value * 5);
            item.rare++;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Eater4"), 1);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddIngredient(ItemID.SoulofNight, 15);
            recipe.AddIngredient(ItemID.CursedFlame, 5);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this);
            recipe.AddRecipe();
            //recipe = new ModRecipe(mod);
            //recipe.AddIngredient(mod.ItemType("Eater4"), 1);
            //recipe.AddIngredient(ItemID.DirtBlock, 1);
            //recipe.SetResult(this);
            //recipe.AddRecipe();
        }

        public override Vector2? HoldoutOffset() {
            return new Vector2(-5, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int numberProjectiles = 1;
            numberProjectiles += Main.rand.Next(2); // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++) {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
                // If you want to randomize the speed to stagger the projectiles
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                int pro = Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                Main.projectile[pro].ai[1] = 5;
            }
            return false; // return false because we don't want tmodloader to shoot projectile
        }
    }
}