using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;

namespace greeble.Content.Surface.Critters.Kiwi;

public class Kiwi : ModNPC
{
    public override void SetStaticDefaults()
    {
        Main.npcFrameCount[Type] = 9;
        NPCID.Sets.CountsAsCritter[Type] = true;
        NPCID.Sets.TakesDamageFromHostilesWithoutBeingFriendly[Type] = true;
        NPCID.Sets.TownCritter[Type] = true;
        Main.npcCatchable[Type] = true;
        NPCID.Sets.ShimmerTransformToNPC[Type] = NPCID.Shimmerfly;
    }
    
    public override void SetDefaults()
    {
        NPC.CloneDefaults(NPCID.Bunny);
        NPC.width = 26;
        NPC.height = 22;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
    }
    
    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        bestiaryEntry.AddTags(BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
            new FlavorTextBestiaryInfoElement(this.GetLocalization("Bestiary").Value));
    }

    public override void AI()
    {
        NPC.spriteDirection = NPC.direction;
    }

    public override void FindFrame(int frameHeight)
    {
        NPC.frameCounter++;
        
        if (NPC.IsABestiaryIconDummy)
        {
            if (NPC.frameCounter > 2)
            {
                NPC.frameCounter = 0;
                NPC.frame.Y += frameHeight;

                if (NPC.frame.Y > frameHeight * 8)
                {
                    NPC.frame.Y = frameHeight;
                }
            }
            return;
        }
        
        if (NPC.velocity.Y == 0)
        {
            if (NPC.velocity.X == 0)
            {
                NPC.frame.Y = 0;
            }
            else
            {
                if (NPC.frameCounter > 2)
                {
                    NPC.frameCounter = 0;
                    NPC.frame.Y += frameHeight;
                    if (NPC.frame.Y > frameHeight * 8)
                    {
                        NPC.frame.Y = frameHeight;
                    }
                }
            }
        }
    }
}