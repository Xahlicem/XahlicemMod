using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace XahlicemMod.Projectiles {
    public class TinyLeech : ModProjectile {

        public override void SetStaticDefaults() {
            //ProjectileID.Sets.Homing[projectile.type] = true;
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults() {
            //projectile.CloneDefaults(ProjectileID.TinyEater);
            projectile.friendly = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.width = 14;
            projectile.height = 16;
            projectile.timeLeft = 60;
        }

        public override bool OnTileCollide(Vector2 velocityChange) {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 1);
            Main.dust[dust].velocity *= Main.rand.NextFloat();           
            if (projectile.velocity.X != velocityChange.X) {                projectile.velocity.X = -velocityChange.X / 1.5F; //Goes in the opposite direction with half of its x velocity
                            }           
            if (projectile.velocity.Y != velocityChange.Y) {                projectile.velocity.Y = -velocityChange.Y / 1.5F; //Goes in the opposite direction with half of its y velocity
                            }           
            return false;       
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            //target.StrikeNPCNoInteraction(target.lifeMax, knockback, -target.direction, crit);
            target.AddBuff(BuffID.Venom, 300);
            Main.player[projectile.owner].AddBuff(173, 5 * 60);
        }

        public override void AI() {

            projectile.frame = (int)(projectile.localAI[0] * 2f);
            projectile.rotation = (float) Math.Atan2((double) projectile.velocity.Y, (double) projectile.velocity.X) + MathHelper.ToRadians(90f);

            // Offset by 90 degrees here

            if (projectile.spriteDirection == -1) {
                projectile.rotation -= MathHelper.ToRadians(90f);
            }

            if (projectile.localAI[0] <= 0f) {
                AdjustMagnitude(ref projectile.velocity);
                projectile.localAI[0] = 1.9f;
            }

            projectile.localAI[0] -= 0.1f;
            Vector2 move = Vector2.Zero;
            float distance = 225f;
            bool target = false;

            for (int k = 0; k < 200; k++) {
                if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5) {
                    Vector2 newMove = Main.npc[k].Center - projectile.Center;
                    float distanceTo = (float) Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);

                    if (distanceTo < distance) {
                        move = newMove;
                        distance = distanceTo;
                        target = true;
                    }
                }
            }

            if (target) {
                AdjustMagnitude(ref move);
                projectile.velocity = (10 * projectile.velocity + move) / 11f;
                AdjustMagnitude(ref projectile.velocity);
            }

            if (projectile.localAI[0] <= 0.5f) {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 28);
                Main.dust[dust].velocity /= 1f + Main.rand.NextFloat();
                Main.dust[dust].scale /= 2f + Main.rand.NextFloat();
            }

        }

        public override void Kill(int timeLeft) {
            for (int i = 0; i < 5; i++) {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 5);
                Main.dust[dust].velocity *= Main.rand.NextFloat();
            }
        }

        private void AdjustMagnitude(ref Vector2 vector) {
            float magnitude = (float) Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 9f) {
                vector *= 9f / magnitude;
            }
        }

    }
}