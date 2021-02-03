using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemEvent : IComparable
{
    /**
     * This class represents an Event where a tracked pet was given some food, a
     * treat, or some other nutritional item 
	*
     */
    public int itemID;
    public EventTime time;
    public double startMass;
    public double endMass;
    public String note;

    // Constructor
    public ItemEvent(int item, EventTime time, double mass, String note) {
        this.itemID = item;
        this.time = time;
        this.startMass = mass;
        this.note = note;
    }

    // Getters

    // Setters
    public void SetItem(int id) {
        this.itemID = id;
    }

    public void SetNote(String note) {
        this.note = note;
    }

    public void SetTime(EventTime time) {
        this.time = time;
    }

    public void SetEndMass(double endMass) {
        this.endMass = endMass;
    }

    // To String
    public override String ToString() {
        return string.Format("{0} at {1} with {2:0.00}", itemID, time, startMass);
    }

    // Override
    public int CompareTo(System.Object o) 
    {
        if (o == null)
        {
            return 1;
        }

        ItemEvent i = o as ItemEvent;
        if (i != null)
        {
            return time.CompareTo(i.time);
        }
        else
        {
            throw new ArgumentException("Object was not an ItemEvent.");
        }
    }
}

