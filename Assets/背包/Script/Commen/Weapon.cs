using UnityEngine;
using System.Collections;
using System.Linq;
using System.Text;

public class Weapon : Item
{

    public int Damage { get; private set; }

    public Weapon(int id, string name, string descript, int buyprice, int sellprice, string icon,int damage)
        :base(id,name,descript,buyprice,sellprice,icon)
    {
        this.Damage = damage;
        base.ItemType = ItemTypes.Weapon;
    }
}
