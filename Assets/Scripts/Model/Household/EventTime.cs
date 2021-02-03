using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EventTime : IComparable
{
    private int hours;
    private int minutes;

    public EventTime(int hours, int minutes) {
        this.hours = hours;
        this.minutes = minutes;
    }
    
    // Setters
    public void SetHours(int hours) {
        this.hours = hours;
    }

    public void SetMinutes(int minutes) {
        this.minutes = minutes;
    }

    // Getters
    public int GetHours() {
        return hours;
    }

    public int GetMinutes() {
        return minutes;
    }
    

    public override String ToString() {
        return string.Format("{0}:{1}", this.hours, this.minutes);
    }

    // Override
    public int CompareTo(System.Object o) {
    	if (o == null) 
    	{
    		return 1;
    	}

    	EventTime t = o as EventTime;
    	if (o != null) 
        {
            int hourCheck = hours.CompareTo(t.GetHours());
            if (hourCheck != 0)
            {
            	return hourCheck;
            }
            else 
            {
            	return minutes.CompareTo(t.GetMinutes());
            }
        }
        else
        {
           throw new ArgumentException("Object is not a Time");
        }
    }
}

