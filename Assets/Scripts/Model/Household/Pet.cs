using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Pet : IComparable {

    /**
     * Represents a pet that a user wants to track
     * @param name String representation of the pet being tracked
     * @param weight Double value representing the weight of the pet
     * @param breed String of the breed
     * @param image String holding the location of the pet's photo
     * @param log Object that holds the feeding log of the pet
     * @param id Unique int value for each Pet object. A Pet == OtherPet if and
     * only if id == other id
	*
     */
    public string name;
    public int age;
    public double weight;
    public string breed;
    public Log log;

    private string image;
    private int id;
    

    // Constructor
    public Pet(string name, int age, string breed, double weight, int id) {
        this.name = name;
        this.age = age;
        this.weight = weight;
        this.breed = breed;
        this.log = new Log();
        this.image = null;
        this.id = id;
    }

    // Override
    public int CompareTo(System.Object pet) {
    	if (pet == null)
    	{
    		return 1;
    	}
    	Pet p = pet as Pet;
    	if (p != null)
    	{
        	return this.id.CompareTo(p.GetID());
        }
        else
        {
        	throw new ArgumentException("Object was not a Pet");
        }
    }

    // Override
    public override bool Equals(System.Object o) {
        if (o == null) {
            return false;
        }
        if (o == this) {
            return true;
        }

        Pet p = o as Pet;

        if (p == null)
        {
        	return false;
        }
        return (id == p.GetID());
    }

    // Override
    public override int GetHashCode() {
        int prime = 31;
        int result = prime * id;
        return result;
    }

    // Getters
    public string GetImage() {
        if (image != null) {
            return image;
        }

        return "No Image";
    }

    public int GetID() {
        return id;
    }

    // Setters
    // To String
    public override string ToString() {
        return string.Format("Name: {0} | Age: {1} | Breed: {2} | Weight: {4:0.00}", name, age, breed, weight);
    }
}

