using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Magic.Leecher {
    public class Leecher5 : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Death Leecher");
            Tooltip.SetDefault("Shoots a deadly leech!.");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.WaterBolt);
            item.damage = 100;
            item.shoot = mod.ProjectileType("TinyLeech");
            item.mana = 25;
            item.knockBack = 3f;
            item.shootSpeed = 25.0f;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Leecher4"), 1);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddIngredient(ItemID.SoulofNight, 15);
            recipe.AddIngredient(ItemID.Ichor, 5);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this);
            recipe.AddRecipe();
            //recipe = new ModRecipe(mod);
            //recipe.AddIngredient(mod.ItemType("Leecher4"), 1);
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
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); // 10 degree spread.
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