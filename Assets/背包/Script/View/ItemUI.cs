using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemUI : MonoBehaviour {

    public Text ItemName;

    public void UpdateName(string name) {
        ItemName.text = name;
    }

//    public Image ItemImage;
//
//    public void UpdateImage(Sprite s) {
//        ItemImage.sprite = s;
//    }
}
