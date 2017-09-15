using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Magic.Leecher {
    public class Leecher3 : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Poison Leecher");
            Tooltip.SetDefault("Shoots a poisonous leech!.");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.WaterBolt);
            item.damage = 50;
            item.shoot = mod.ProjectileType("TinierLeech");
            item.mana = 15;
            item.knockBack = 3f;
            item.shootSpeed = 25.0f;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Leecher2"), 1);
            recipe.AddIngredient(ItemID.Fireblossom, 10);
            recipe.AddIngredient(ItemID.Obsidian, 20);
            recipe.AddIngredient(ItemID.MagmaStone, 1);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
            //recipe = new ModRecipe(mod);
            //recipe.AddIngredient(mod.ItemType("Leecher2"), 1);
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
                Main.projectile[pro].ai[1] = 3;
            }
            return false; // return false because we don't want tmodloader to shoot projectile
        }
    }
}