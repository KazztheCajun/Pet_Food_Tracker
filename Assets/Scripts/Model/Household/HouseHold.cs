using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;

[Serializable]
public class HouseHold : IComparable , IEquatable<HouseHold> {

    /**
     * This class represents a household that has pets.
     *
     * @param stable The ArrayList holding the pet data
	*
     */

    public String name;

    private List<Pet> stable;
    private List<string> owners;

    public HouseHold(String name) {
        this.stable = new List<Pet>();
        this.owners = new List<string>();
        this.name = name;
    }
    
    // Override
    public int CompareTo(System.Object o) {
    	if (o == null) 
    	{
    		return 1;
    	}

    	HouseHold other = o as HouseHold;
        if (other != null) 
        {
            return this.name.CompareTo(other.name);
        }
        else
        {
           throw new ArgumentException("Object is not a Household");
        }
    }

    // Equatable
    public bool Equals(HouseHold other)
    {
        if (other == null)
        {
            return false;
        }
        if (this.name == other.name)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Comparable
    public override bool Equals(System.Object o)
    {
        if (o == null)
        {
            return false;
        }
        if (o == this)
        {
            return true;
        }

        HouseHold h = o as HouseHold;
        if (h == null)
        {
            return false;
        }

        return name.Equals(h.name);
    }

    // Getters

    public override int GetHashCode()
    {
        return this.name.GetHashCode();
    }

    public Pet GetPet(int index) 
    {
        return stable[index] as Pet;    
    }

    // uses a ArgumentException to indicate a given pet doesn't exist
    public Pet GetPet(Pet pet) {
        int index = stable.BinarySearch(pet);
        if (index == -1) 
        {
            throw new ArgumentException("Unable to find that pet.");
        }

        return stable[index] as Pet;
    }
    
    public List<Pet> GetStable() 
    {   
        return stable;
    }
    
    public int GetStableSize() 
    {
        return stable.Count;
    }

    // Setters
    public void AddPet(Pet pet) 
    {
        this.stable.Add(pet);
    }

    public void AddOwner(String name) 
    {
        this.owners.Add(name);
    }

    // To String
    public override String ToString() 
    {
        StringBuilder s = new StringBuilder("Household: " + name + "\n");
        foreach (Pet p in stable)
        {
            s.Append("\n" + p + "\n\n");
        }
        return s.ToString();
    }

}

