using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HouseManager : MonoBehaviour
{
    [HideInInspector] public List<HouseHold> list;
    public Transform input;
    public Transform displayList;
    public Transform template;

    public void InitializeHouses()
    {
    	list = new List<HouseHold>();
    }

    public void NewHouse()
    {
        string name = input.GetComponent<TextMeshProUGUI>().text; // Get the string entered into the box

        if (name != null && name != "") // Check for null or empty string
        {
            HouseHold temp = new HouseHold(name);
            if (!list.Contains(temp)) // Check if house exists already
            {
                list.Add(temp); // Make new one if not
                AddHouse(name);
                Debug.Log(name + " was created.");
            }
            else 
            {
                throw new InvalidOperationException("[HouseManager] House already exists with that name.");
            }
        }
        else 
        {
            throw new InvalidOperationException("[HouseManager] Attempted to create house with invalid name string.");
        }
    }

    public HouseHold GetHouse(string name)
    {
        if (list.Contains(new HouseHold(name)))
        {
           return list.Find(x => x.name == name);
        }
        else 
        {
            throw new ArgumentException("[HouseManager] Unable to find a house named " + name + ".");
        }
    }

    private void AddHouse(string name)
    {
    	Transform temp = Instantiate(template, displayList);
        temp.gameObject.SetActive(true);
    	temp.GetComponentInChildren<TextMeshProUGUI>().text = name;
    }

    private void RemoveHouse(HouseHold h)
    {
    	list.Remove(h);
    	foreach (Transform c in displayList)
    	{
    		if (c.GetComponent<TextMeshProUGUI>().text == h.name)
    		{
    			Destroy(c.gameObject);
    		}
    	}
    }
}
