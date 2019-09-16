using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Relative
{
    public string relativeName;
    public int relativeID;
    public int relativeAge;
    public string relativeRelation;
    public string relativeDescription;

    public Relative(string name, int id, int age, string relation, string description)
    {
        relativeName = name;
        relativeID = id;
        relativeAge = age;
        relativeRelation = relation;
        relativeDescription = description;
    }

    public Relative()
    {
        
    }
}
