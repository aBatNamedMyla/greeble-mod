using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace greeble.Content.Surface.Items.Food;

public class Kiwi : ModItem
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
        Item.value = Item.buyPrice(0, 0, 20, 0);
        Item.rare = ItemRarityID.Blue;
    }
}