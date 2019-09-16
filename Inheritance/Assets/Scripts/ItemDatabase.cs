using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> itemList = new List<Item>();

    private void Start()
    {
        itemList.Add(new Item("Money", 0, "A big, fat pile of cash in the amount of 30 million US dollars."));
        itemList.Add(new Item("Great-Great-Grandmother's Jewels", 1, "A massive red ruby set in a solid gold pendant."));
        itemList.Add(new Item("Lamborghini Veneno", 2, "A flashy, yellow luxury vehicle worth 4.5 million at the time it was purchased."));
        itemList.Add(new Item("Letters", 3, "A bundle of love letters from all of your past liaisons. Their contents are romantic, and at times, explicit."));
        itemList.Add(new Item("Jar of Toe Nail Clippings", 4, "A glass jar containing years of your toe nail clippings. Everyone has their eccentricities, right?"));
        itemList.Add(new Item("Gift Cards", 5, "A stack of mostly-used gift cards, each with a balance of a dollar or less."));
        itemList.Add(new Item("Recipe Book", 6, "An old, hand-written tome containing beloved family recipes from generations back."));
        itemList.Add(new Item("Diamond Encrusted Dildo", 7, "It's pretty much exactly what it sounds like."));
        itemList.Add(new Item("Property Deed", 8, "Title to your Hampton summer home. It's a modest 10 bedroom, 15 bath house."));
        itemList.Add(new Item("Startup Company", 9, "Your failing startup company that develops mind-reading Bluetooth headsets for dogs."));
        itemList.Add(new Item("Second-Best Bed", 10, "Your second-best bed. Who could possibly deserve your first-best?"));
        itemList.Add(new Item("Dog Collar", 11, "A leather, gold and diamond dog collar designed by Louis Vuitton"));
    }
}
