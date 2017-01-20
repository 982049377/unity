using UnityEngine;
using System.Collections;

public class Armor : Item
{
    public int Power { get; private set; }
    public int Defend { get; private set; }
    public int Agility { get; private set; }

    public Armor(int id, string name, string descript, int buyprice, int sellprice, string icon,int power,int defend,int agility)
        :base(id,name,descript,buyprice,sellprice,icon)
    {
        this.Power = power;
        this.Defend = defend;
        this.Agility = agility;
        base.ItemType = ItemTypes.Armor;
    }
}
