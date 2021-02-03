using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Day : IComparable
{
    /**
     * This class holds all the Event objects for a Log day.
     *
     * @param events HashMap holding all the events for a Day Object
	*
     */
    public List<ItemEvent> events;
    public Date date;

    // Constructor
    public Day(Date date) 
    {
        this.events = new List<ItemEvent>();
        this.date = date;
    }

    public void AddEvent(ItemEvent itemEvent) 
    {
        this.events.Add(itemEvent);
    }
    
    // Advanvced Getters and Setters
    
    
    // Basic Getters and Setters


    // Override
    public override int GetHashCode() 
    {
        int hash = 31;
        hash = 79 * hash + date.GetHashCode();
        return hash;
    }

    // Override
    public override bool Equals(System.Object obj) 
    {
        if (this == obj) 
        {
            return true;
        }
        if (obj == null) 
        {
            return false;
        }

        Day other = obj as Day;

        return this.date.Equals(other.date);
    }
    
    // toString

    public override String ToString() 
    {
        return date.ToString();
    }

    // Override
    public int CompareTo(System.Object day) 
    {
        // returns 0 if equal ; -1 if this day is cronologically before otherDay ; 1 if this day is after than otherDay
        if (day == null)
        {
            return 1;
        }
        Day d = day as Day;
        if (d != null)
        {
            return this.date.CompareTo(d.date);
        }
        else 
        {
            throw new ArgumentException("Object was not a Day.");
        }
    }
}