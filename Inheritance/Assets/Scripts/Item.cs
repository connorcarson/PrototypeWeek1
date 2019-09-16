﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public int itemID;
    public string itemDescription;
    public Texture2D itemIcon;

    public enum ItemType
    {
        //Put item types in here if needed
    }

    public Item(string name, int id, string description)
    {
        itemName = name;
        itemID = id;
        itemDescription = description;
        itemIcon = Resources.Load<Texture2D>("ItemIcons/" + name);
    }

    public Item()
    {
        //slot constructor
    }
}
