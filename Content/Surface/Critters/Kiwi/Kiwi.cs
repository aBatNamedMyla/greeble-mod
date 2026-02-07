using greeble.Content.Surface.Items.Food;
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
        NPC.catchItem = ModContent.ItemType<KiwiItem>();
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
    
    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.Player.ZoneForest && !Main.dayTime && !Main.bloodMoon)
        {
            return 0.1f;
        }
        return 0f;
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

    public override void HitEffect(NPC.HitInfo hit)
    {
        if (NPC.life > 0)
        {
            
        }
        else
        {
            Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("KiwiGore_Head").Type, NPC.scale);
            Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("KiwiGore_Leg0").Type, NPC.scale);
            Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("KiwiGore_Leg1").Type, NPC.scale);
        }
    }
}

public class KiwiItem : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 5;
    }
    
    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.Bunny);
        Item.width = 24;
        Item.height = 22;
        Item.makeNPC = ModContent.NPCType<Kiwi>();
        Item.value = Item.buyPrice(0, 0, 5, 0);
        Item.rare = ItemRarityID.White;
    }
    
    
}