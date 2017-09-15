using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.Items.Magic.Eater {
    public class Eater1 : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Midget Eater");
            Tooltip.SetDefault("Shoots a tiny eater!.");
        }
        public override void SetDefaults() {
            item.CloneDefaults(ItemID.BeeGun);
            item.damage = 5;
            item.shoot = mod.ProjectileType("EaterProj");
            item.mana = 8;
            item.knockBack = 1.5f;
            item.shootSpeed = 6f;
            item.rare = 2;
            item.value = 10000;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RottenChunk, 15);
            recipe.AddIngredient(ItemID.VilePowder, 30);
            recipe.AddIngredient(ItemID.WormTooth, 10);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
            //recipe = new ModRecipe(mod);
            //recipe.AddIngredient(mod.ItemType("Soul"), 5000);
            //recipe.SetResult(this);
            //recipe.AddRecipe();
        }

        public override Vector2? HoldoutOffset() {
            return new Vector2(-5, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            //int numberProjectiles = 1;
            //numberProjectiles += Main.rand.Next(2); // 4 or 5 shots
            //for (int i = 0; i < numberProjectiles; i++) {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
            // If you want to randomize the speed to stagger the projectiles
            float scale = 1f - (Main.rand.NextFloat() * .3f);
            perturbedSpeed = perturbedSpeed * scale;
            int pro = Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            Main.projectile[pro].ai[1] = 1;
            //}
            return false; // return false because we don't want tmodloader to shoot projectile
        }
    }
}