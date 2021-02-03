using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Date : IComparable
{

	public int year;
    public int month;
    public int day;

    public Date(int year, int month, int day) {
        this.year = year;
        this.month = month;
        this.day = day;
    }

    //Override
    public override String ToString() {
        return $"{month} {day}, {year}";
    }

    //Override
    public override bool Equals(System.Object o) {
        if (o == null) {
            return false;
        }
        if (o == this) {
            return true;
        }

        Date d = o as Date;

        if (d == null)
        {
        	return false;
        }

        return (year == d.year && month == d.month && day == d.day);
    }

    //Override
    public override int GetHashCode() {
        int prime = 31;
        int result = prime * (year + month + day);
        return result;
    }

    //Override
    public int CompareTo(System.Object d) {

        if (d == null)
        {
        	return 1;
        }

        Date date = d as Date;
        if (date != null)
        {
        	int yearCheck = this.year.CompareTo(date.year);
        	if (yearCheck != 0)
        	{
        		return yearCheck;
        	}
        	else 
        	{
        		int monthCheck = this.month.CompareTo(date.month);
        		if (monthCheck != 0)
        		{
        			return monthCheck;
        		}
        		else 
        		{
        			return this.month.CompareTo(date.day);
        		}
        	}
         
        }
        else 
        {
        	return 1;
        }
    }
    
}
