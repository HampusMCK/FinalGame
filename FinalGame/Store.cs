using System;

public class Store//All buyable items
{

    public List<Item> tool = new List<Item>();

    public Store()
    {
        tool.Add(new Item() { name = "Stick", power = 10, price = 5 });
        tool.Add(new Item() { name = "Metal Rod", power = 20, price = 10 });
        tool.Add(new Item() { name = "Axe", power = 30, price = 15 });
        
        tool.Add(new Item() { name = "Sledgehammer", power = 50, price = 30 });
        tool.Add(new Item() { name = "Pickaxe", power = 75, price = 45 });
        tool.Add(new Item() { name = "Drill", power = 100, price = 60 });
    }
}
