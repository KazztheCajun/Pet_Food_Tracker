using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *  This object provides methods for creating and maintaining an Item inventory
 *  @author AAron
 */
public class InventoryManager {
    
    private ArrayList inventory;
    private IDGenerator idGen;
    
    public  InventoryManager(IDGenerator idGen) 
    {
        inventory = new ArrayList();
        this.idGen = idGen;   
    }
    
    public void AddItem(Item item)  
    {
        if (!inventory.Contains(item))
        {
            inventory.Add(item);
        }
        else 
        {
            throw new ArgumentException("Inventory already contains this item.");
        }
    }
    
    public void BuildInventory(String path) 
    {
        /**
         * This Method builds a brand new inventory from a folder of text files
         */

        try
        {
            var txtFiles = Directory.GetFiles(path);

            foreach (string currentFile in txtFiles)
            {
                inventory.Add(CreateItemFromInfo(GetInfoFromFile(currentFile)));
            }
        }
        catch (Exception e)
        {
            throw new Exception($"[InventoryManager] {e}");
        }  
    }

    private String[] GetInfoFromFile(String path) 
    {
        // Create an instance of StreamReader to read from a file.
        // The using statement also closes the StreamReader.
        String[] info = new String[8];
        using (StreamReader sr = new StreamReader(path)) 
        {    
            info[0] = sr.ReadLine(); // Produce Name
            info[1] = sr.ReadLine(); // Protein Type
            info[2] = sr.ReadLine(); // Caloric Units
            info[3] = sr.ReadLine(); // Unit Type
            info[4] = sr.ReadLine(); // Nutrition info 1
            info[5] = sr.ReadLine(); // Nutrition info 2
            info[6] = sr.ReadLine(); // Nutrition info 3
            info[7] = sr.ReadLine(); // Nutrition info 4  
        }

        return info;
    }

    private Item CreateItemFromInfo(String[] info)
    {
        Calories cals = new Calories(Convert.ToDouble(info[2]), Calories.GetUnitsFromString(info[3]));
        Nutrients nuts = new Nutrients(Convert.ToDouble(info[4]), Convert.ToDouble(info[5]), Convert.ToDouble(info[6]), Convert.ToDouble(info[7]));
        Item item = new Item(info[1], idGen.GetNewID(), cals, nuts);
        return item;
    }
    
    public ArrayList getItemList(int index) 
    {
        return inventory;
    }
}
