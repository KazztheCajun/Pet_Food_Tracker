using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Log {

    /**
     * This class holds the log of events for a tracked pet. It uses a HasMap
     * with the key = date of day to be tracked and value = the log of Events
     * for the day.
     *
     * @param calendar The ArrayList holding the log of feeding events
     */
    public List<Day> calendar;

    // Constructor
    public Log() {
        this.calendar = new List<Day>();
    }

    // Getters
    // Setters

    public void AddEvent(ItemEvent i, Date date) 
    {
        Day day = new Day(date);
        int index = calendar.BinarySearch(day);
        
        if (index <= -1) 
        {
            day.AddEvent(i);
            this.calendar.Add(day);
        }
        else 
        {
            day = calendar[index];
            day.AddEvent(i);
        }
    }

    public Day GetDay(Date date)
    {
        return calendar.Find(x => x.date == date);
    }

    public override String ToString() 
    {
        if (calendar.Count > 0) 
        {
            StringBuilder s = new StringBuilder();
            foreach (Day d in calendar)
            {
                s.Append(d);
            }
            return s.ToString();
        }

        return "No Log Entries";
    }
}
