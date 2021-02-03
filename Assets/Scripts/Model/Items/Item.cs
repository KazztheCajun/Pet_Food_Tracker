using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : IComparable {

    /**
     * This class represents an item given to a pet that has nutritional or
     * caloric value.
     *
     * @param name String representation of the object
     * @param itemID Unique integer identifier for this object
     * @param caloricInfo Object containing all the caloric information for this
     * Item object.
     * @param nutrients Object containing all the non-caloric nutritional
     * information for this Item object
	*
     */

    private String name;
    private int itemID;
    private Calories calories;
    private Nutrients nutrients;

    public Item(String name, int id, Calories cals, Nutrients nut) {
        this.name = name;
        this.itemID = id;
        this.calories = cals;
        this.nutrients = nut;
    }

    public int CompareTo(System.Object o) {
        if (o == null)
        {
            return 1;
        }

        Item i = o as Item;
        if (i != null)
        {
            return itemID.CompareTo(i.GetID());
        }
        else 
        {
            throw new ArgumentException("Object was not an Item");
        }
    }

    // Getters
    public Calories GetCalories() {
        return calories;
    }

    public Nutrients GetNutrients() {
        return nutrients;
    }

    public String GetName() {
        return name;
    }

    public int GetID() {
        return itemID;
    }

    // toString
    public override String ToString() {
        return string.Format("{0}: \n  {1}\n  {2}", name, calories, nutrients);
    }

    // Override
    public override int GetHashCode() {
        int hash = 31;
        hash =  hash * this.itemID;
        return hash;
    }

    // Override
    public override bool Equals(System.Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj == null) {
            return false;
        }
        
        Item other = obj as Item;
        if (other == null) {return false;}

        return itemID.Equals(other.GetID());
    }

}
