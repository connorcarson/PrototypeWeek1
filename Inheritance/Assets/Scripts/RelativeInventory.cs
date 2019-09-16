using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativeInventory : MonoBehaviour
{
    public Collider2D dorothy;
    public Collider2D eugene;
    public Collider2D rhonda;
    public Collider2D phillip;
    public Collider2D joff;
    public Collider2D sasha;
    public Collider2D puddles;

    private Camera _cam;
    public bool _showTooltip;
    private string _tooltip;
    private RelativeDatabase _database;
    
    public GUISkin slotSkin;

    public List<Relative> relativeInventory = new List<Relative>();

    private int _id;

    private void Awake()
    {
        _cam = Camera.main;
        _database = GameObject.FindGameObjectWithTag("RelativeDatabase").GetComponent<RelativeDatabase>();
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _database.relativeList.Count; i++)
        {
            relativeInventory.Add(_database.relativeList[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider == dorothy)
        {
            _id = 0;
            _showTooltip = true;
            _tooltip = CreatTooltip(relativeInventory[_id]);
        }

        if (hit.collider == eugene)
        {
            _id = 1;
            _showTooltip = true;
            _tooltip = CreatTooltip(relativeInventory[_id]);
        }
        if (hit.collider == rhonda)
        {
            _id = 2;
            _showTooltip = true;
            _tooltip = CreatTooltip(relativeInventory[_id]);
        }
        if (hit.collider == phillip)
        {
            _id = 3;
            _showTooltip = true;
            _tooltip = CreatTooltip(relativeInventory[_id]);
        }
        if (hit.collider == joff)
        {
            _id = 4;
            _showTooltip = true;
            _tooltip = CreatTooltip(relativeInventory[_id]);
        }
        if (hit.collider == sasha)
        {
            _id = 5;
            _showTooltip = true;
            _tooltip = CreatTooltip(relativeInventory[_id]);
        }
        if (hit.collider == puddles)
        {
            _id = 6;
            _showTooltip = true;
            _tooltip = CreatTooltip(relativeInventory[_id]);
        }
        else if (hit.collider == null)
        {
            _showTooltip = false;
        }


    }

    private void OnGUI()
    {
        GUI.skin = slotSkin;

        if (_showTooltip)
        {
            switch (_id)
            {
                case 0:
                    GUI.Box(new Rect(Event.current.mousePosition.x + 20f, Event.current.mousePosition.y, 250, 150), _tooltip, slotSkin.GetStyle("Slot2"));
                    break;
                case 2:
                    GUI.Box(new Rect(Event.current.mousePosition.x + 20f, Event.current.mousePosition.y - 250, 430, 270), _tooltip, slotSkin.GetStyle("Slot2"));
                    break;
                case 3:
                    GUI.Box(new Rect(Event.current.mousePosition.x + 20f, Event.current.mousePosition.y - 250, 430, 270), _tooltip, slotSkin.GetStyle("Slot2"));
                    break;
                case 4:
                    GUI.Box(new Rect(Event.current.mousePosition.x + 20f, Event.current.mousePosition.y - 250, 430, 270), _tooltip, slotSkin.GetStyle("Slot2"));
                    break;
                case 5:
                    GUI.Box(new Rect(Event.current.mousePosition.x - 420f, Event.current.mousePosition.y - 250, 430, 280), _tooltip, slotSkin.GetStyle("Slot2"));
                    break;
                case 6:
                    GUI.Box(new Rect(Event.current.mousePosition.x - 420f, Event.current.mousePosition.y - 250 , 430, 220), _tooltip, slotSkin.GetStyle("Slot2"));
                    break;
                default:
                    GUI.Box(new Rect(Event.current.mousePosition.x + 20f, Event.current.mousePosition.y, 430, 270), _tooltip, slotSkin.GetStyle("Slot2"));
                    break;
            }
            //GUI.Box(new Rect(Event.current.mousePosition.x + 20f, Event.current.mousePosition.y, 230, 100), _tooltip, slotSkin.GetStyle("Slot2"));
        }
    }

    string CreatTooltip(Relative relative)
    {
        _tooltip = "<color=#000000><b>" + relative.relativeName + "</b></color>\n\n" +
                   "<color=#000000>" + "Relation: " + relative.relativeRelation + 
                   "\n\nAge: " + relative.relativeAge + 
                   "\n\nDescription: " + relative.relativeDescription + "</color>";
        return _tooltip;
    }
}
