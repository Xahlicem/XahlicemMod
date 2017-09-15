using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XahlicemMod.NPCs.Enemy
{
	// This ModNPC serves as an example of a complete AI example.
	public class VelKoz : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vel");
			Main.npcFrameCount[npc.type] = 4; // make sure to set this for your modnpcs.
		}

		public override void SetDefaults()
		{
			npc.width = 100;
            npc.scale *= 0.7f;
			npc.height = 85;
			npc.aiStyle = 30;
			aiType = NPCID.FlyingFish;
			animationType = NPCID.FlyingFish;
			npc.noGravity = true;
			npc.damage = 60;
			npc.defense = 25;
			npc.lifeMax = 750;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			//npc.alpha = 175;
			//npc.color = new Color(0, 80, 255, 100);
			npc.value = 50000f;
            npc.knockBackResist = 1f;
			npc.buffImmune[BuffID.Confused] = false; // npc default to being immune to the Confused debuff. Allowing confused could be a little more work depending on the AI. npc.confused is true while the npc is confused.
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			// we would like this npc to spawn in the overworld.
			return SpawnCondition.Mummy.Chance * 0.5f;
		}
public override void FindFrame(int frameHeight)
		{
			npc.FaceTarget();
			// This makes the sprite flip horizontally in conjunction with the npc.direction.
			//npc.spriteDirection = npc.direction;
		}
	}
}