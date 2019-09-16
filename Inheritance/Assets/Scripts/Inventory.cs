using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private ItemDatabase _database;
    public Texture inventoryFrame;
    public int slotsX = 3;
    public int slotsY = 4;
    private float _iconWidth = 100;
    private float _iconHeight = 100;

    public AudioClip click;
    public AudioSource audioSource;
    
    public GUISkin slotSkin;
    private GUIStyle _style;
    private Vector2 _size;
    
    private bool _showInventory;
    private bool _showTooltip;
    public bool draggingItem;
    
    private string _tooltip;

    public Item _draggedItem;
    private int _draggedIndex;
    private Camera _cam;

    public Collider2D dorothy;

    public List<Item> inventory = new List<Item>();
    public List<Item> slots = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        
        for (int i = 0; i < (slotsX * slotsY); i++)
        {
            slots.Add(new Item());
            inventory.Add(new Item());
        }
        
        _database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();

        for (int i = 0; i < _database.itemList.Count; i++)
        {
            AddItem(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            _showInventory = !_showInventory;
            audioSource.PlayOneShot(click, 0.7f);
        }

        if (_showInventory)
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                for (int i = 0; i < _database.itemList.Count; i++)
                {
                    inventory[i] = _database.itemList[i];
                }
                audioSource.PlayOneShot(click, 0.7f);
            }
        }

        Vector2 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider && hit.collider != dorothy && Input.GetMouseButtonUp(0) && draggingItem)
        {
            draggingItem = false;
            audioSource.PlayOneShot(click, 0.7f);
        }
    }
    
    private void OnGUI()
    {
        _tooltip = "";
        GUI.skin = slotSkin;

        if (_showInventory)
        {
            DrawInventory();
            if (_showTooltip)
            {
                GUI.Box(new Rect(Event.current.mousePosition.x + 20f, Event.current.mousePosition.y, 230, 100), _tooltip, slotSkin.GetStyle("Slot2"));
            }

            if (draggingItem)
            {
                GUI.DrawTexture(new Rect(Event.current.mousePosition.x - 100, Event.current.mousePosition.y, _iconWidth, _iconHeight), _draggedItem.itemIcon);
            }
        }
    }

    void DrawInventory()
    {
        Event e = Event.current;
        int i = 0;

        for (int y = 0; y < slotsY; y++)
        {
            for (int x = 0; x < slotsX; x++)
            {
                Rect slotRect = new Rect(x * 100, y * 100, 100, 100 );
                GUI.Box(slotRect, "", slotSkin.GetStyle("Slot"));
                slots[i] = inventory[i];

                if (slots[i].itemName != null)
                {
                    GUI.DrawTexture(slotRect, slots[i].itemIcon);
                    if(slotRect.Contains(e.mousePosition))
                    {
                        if (e.button == 0 && e.type == EventType.MouseDrag && !draggingItem)
                        {
                            draggingItem = true;
                            _draggedItem = slots[i];
                            _draggedIndex = i;
                            inventory[i] = new Item();
                        }
                        if (e.type == EventType.MouseUp && draggingItem)
                        {
                            inventory[_draggedIndex] = inventory[i];
                            inventory[i] = _draggedItem;
                            draggingItem = false;
                            _draggedItem = null;
                            audioSource.PlayOneShot(click, 0.7f);
                        }
                        _showTooltip = true;
                        _tooltip = CreateTooltip(slots[i]);
                    }
                }
                else
                {
                    if (slotRect.Contains(e.mousePosition))
                    {
                        if (e.type == EventType.MouseUp && draggingItem)
                        {
                            inventory[i] = _draggedItem;
                            draggingItem = false;
                            _draggedItem = null;
                            audioSource.PlayOneShot(click, 0.7f);
                        }
                    }
                }

                if (_tooltip == "")
                {
                    _showTooltip = false;
                }
                i++;
            }
        }
    }

    string CreateTooltip(Item item)
    {
        _tooltip = "<color=#000000><b>" + item.itemName + "</b></color>\n\n" +
                   "<color=#000000>" + item.itemDescription + "</color>";
        return _tooltip;
    }

    void AddItem(int id)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemName == null)
            {
                for (int j = 0; j < _database.itemList.Count; j++)
                {
                    if (_database.itemList[j].itemID == id)
                    {
                        inventory[i] = _database.itemList[j];   
                    }
                }
                break;
            }
        }
    }

    void RemoveItem(int id)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemID == id)
            {
                inventory[i] = new Item();
                break;
            }
        }
    }

    bool InventoryContains(int id)
    {
        bool result = false;
        for (int i = 0; i < inventory.Count; i++)
        {
            result = inventory[i].itemID == id;
            if (result)
            {
                break;
            }
        }
        return result;
    }

}
