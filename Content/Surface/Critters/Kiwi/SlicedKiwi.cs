using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;

namespace greeble.Content.Surface.Critters.Kiwi;

public class SlicedKiwi : ModNPC
{
    public override void SetStaticDefaults()
    {
        Main.npcFrameCount[Type] = 12;
    }
    
    public override void SetDefaults()
    {
        NPC.width = 18;
        NPC.height = 16;
        NPC.aiStyle = -1;
        NPC.damage = 0;
        NPC.defense = 0;
        NPC.lifeMax = 1;
        NPC.immortal = true;
    }

    public override void OnSpawn(IEntitySource source)
    {
        NPC.direction = Main.rand.NextBool() ? 1 : -1;
        NPC.spriteDirection = NPC.direction;
    }
    
    public override void AI()
    {
        NPC.ai[0]++;
        
        NPC.velocity.X = 1f * NPC.direction;

        if (NPC.ai[0] >= 150)
        {
            NPC.alpha += 5;
            if (NPC.alpha >= 255)
            {
                NPC.life = 0;
            }
        }
    }

    public override void FindFrame(int frameHeight)
    {
        NPC.frameCounter++;
        if (NPC.frameCounter > 2)
        {
            NPC.frameCounter = 0;
            NPC.frame.Y += frameHeight;

            if (NPC.frame.Y > frameHeight * 11)
            {
                NPC.frame.Y = frameHeight;
            }
        }
    }
}