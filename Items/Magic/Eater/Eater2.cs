using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Magic.Eater {
    public class Eater2 : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Eater");
            Tooltip.SetDefault("Shoots tiny eaters!.");
        }
        public override void SetDefaults() {
            item.CloneDefaults(mod.ItemType("Eater1"));
            item.damage *= 2;
            item.mana = (int)(item.mana * 1.25);
            item.value = (int)(item.value * 5);
            item.rare++;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Eater1"), 1);
            recipe.AddIngredient(ItemID.Bone, 30);
            recipe.AddIngredient(ItemID.ShadowScale, 25);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
            //recipe = new ModRecipe(mod);
            //recipe.AddIngredient(mod.ItemType("Eater1"), 1);
            //recipe.AddIngredient(ItemID.DirtBlock, 1);
            //recipe.SetResult(this);
            //recipe.AddRecipe();
        }

        public override Vector2? HoldoutOffset() {
            return new Vector2(-5, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int numberProjectiles = 1;
            for (int i = 0; i < numberProjectiles; i++) {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
                // If you want to randomize the speed to stagger the projectiles
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                int pro = Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                Main.projectile[pro].ai[1] = 2;
            }
            return false; // return false because we don't want tmodloader to shoot projectile
        }
    }
}