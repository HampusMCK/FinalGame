using System;

public class MagicStore
{
    public List<Magic> tool = new List<Magic>();

    public MagicStore()
    {
        tool.Add( new Magic{name = "Enchantment level 1", price = 200, desc = "Double the streangth", effect = 2});
        tool.Add( new Magic{name = "Enchantment level 2", price = 300, desc = "Triple the streangth", effect = 3});
        tool.Add( new Magic{name = "Enchantment level 3", price = 400, desc = "Quadruple the streangth", effect = 4});
    }
}
