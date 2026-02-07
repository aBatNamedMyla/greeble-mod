using greeble.Content.Surface.Critters.Kiwi;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace greeble.Content.Surface.Items.Food;

public class KiwiFruit : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 5;
        Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
        ItemID.Sets.IsFood[Type] = true;
    }

    public override void SetDefaults()
    {
        Item.DefaultToFood(24, 24, BuffID.WellFed, 18000);
        Item.value = Item.buyPrice(0, 0, 5, 0);
        Item.rare = ItemRarityID.Blue;
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<KiwiItem>(), 1)
            .AddTile(TileID.Sawmill)
            .Register();
    }

    public override void OnCreated(ItemCreationContext context)
    {
        if (context is RecipeItemCreationContext)
        { 
            SoundEngine.PlaySound(SoundID.Item177, Main.LocalPlayer.Center);
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                int npcIndex = NPC.NewNPC(new EntitySource_Misc("murder"), (int)Main.LocalPlayer.position.X, (int)Main.LocalPlayer.position.Y + 16, ModContent.NPCType<SlicedKiwi>());
                NetMessage.SendData(MessageID.SyncNPC,npcIndex);
            }
        }
    }
}