using UnityEngine;
using System.Collections;
using System.Linq;
using System.Text;

public class Consumable : Item {

    public int BackHp { get; private set; }
    public int BackMp { get; private set; }


    public Consumable(int id, string name, string descript, int buyprice, int sellprice, string icon,int backHp,int backMp)
        :base(id,name,descript,buyprice,sellprice,icon)
    {
        this.BackHp = backHp;
        this.BackMp = backMp;
        base.ItemType = ItemTypes.Consumable;
    }
}
