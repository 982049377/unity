using UnityEngine;
using System.Collections;

public enum ItemTypes{
    Weapon,
    Consumable,
    Armor
}

public class Item
{
    public int ID { get; private set; }
    public string Name { get; private set; }
    public string Descript { get; private set; }
    public int BuyPrice { get; private set; }
    public int SellPrice { get; private set; }
    public string Icon { get; private set; }
    public ItemTypes ItemType { get; protected set; }

    public Item(int id, string name, string descript, int buyprice, int sellprice, string icon)
    {
        this.ID = id;
        this.Name = name;
        this.Descript = descript;
        this.BuyPrice = buyprice;
        this.SellPrice = sellprice;
        this.Icon = icon;
    }
}
