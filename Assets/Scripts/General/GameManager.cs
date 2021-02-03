using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

[System.Serializable] public class UnityEventHouseHold:UnityEvent<HouseHold> {}
[System.Serializable] public class UnityEventPet:UnityEvent<Pet> {}
[System.Serializable] public class UnityEventDay:UnityEvent<Day> {} 
[System.Serializable] public class UnityEventInt:UnityEvent<int> {} 


public class GameManager : MonoBehaviour
{

    public Transform canvas;
    public TextMeshProUGUI houseTitle;
    public TextMeshProUGUI petTitle;

    public UnityEvent AppStart;

    public UnityEventInt NewItemEvent;

    public UnityEventHouseHold NewHouse;
    public UnityEventHouseHold UpdateLoadedHouse;

    public UnityEventPet NewPet;
    public UnityEventPet LoadNewPet;

    [HideInInspector] public HouseManager households;
    [HideInInspector] public HouseHold currentHouse;
    [HideInInspector] public Pet currentPet;

    private IDGenerator gen;

    void Start() 
    {
        AppStart.Invoke();
//    	LoadAppData();
    	currentHouse = null;
        currentPet = null;
    	houseTitle.text = "No house selected...";
        petTitle.text = "No Pet loaded...";
        gen = new IDGenerator();
    }

    public void CreateNewPet()
    {
        if (currentHouse != null)
        {
            Transform w = canvas.Find("View - Create Pet");

            string name = w.Find("Name Field").GetComponent<TMP_InputField>().text;
            string age = w.Find("Age Field").GetComponent<TMP_InputField>().text;
            string weight = w.Find("Weight Field").GetComponent<TMP_InputField>().text;
            string breed = w.Find("Breed Field").GetComponent<TMP_InputField>().text;

            Pet pet = new Pet(name, Convert.ToInt32(age), breed, Convert.ToDouble(weight), gen.GetNewID());
            currentHouse.GetStable().Add(pet);
            NewPet.Invoke(pet);
            Debug.Log(name + " was added to" + currentHouse.name);
        }
        else 
        {
            throw new ArgumentException("[GameManager] No House loaded!");
        }
    }

    public void CreateNewItemEvent()
    {
        // Get date and build Date object
        DateTime currentDate = DateTime.Today;
        Date date = new Date(currentDate.Year, currentDate.Month, currentDate.Day);

        // Get ItemEvent info
        Transform d = canvas.Find("View - Create Item Event").Find("Dropdown");
        TMP_Dropdown list = d.GetComponent<TMP_Dropdown>();

        if (list == null)
        {
            throw new InvalidOperationException("[GameManager] Unable to find the dropdown list");
        }

        string text = canvas.Find("View - Create Item Event").Find("Mass Field").GetComponent<TMP_InputField>().text;

        EventTime time = new EventTime(currentDate.Hour, currentDate.Minute);

        string optionText = list.itemText.text;

        // Build event
        ItemEvent e = new ItemEvent(1111, time, Convert.ToInt32(text), optionText);

        // Add it to the current pet's log
        Log log = currentPet.log;
        log.AddEvent(e, date);
        int index = log.calendar.Count - 1;
        if (index < 0)
        {
            throw new ArgumentException($"[GameManager] Unable to find {date} in the loaded pet's Log.");
        }
        NewItemEvent.Invoke(index);
    }

    public void LoadHouse() 
    {
        GameObject o = EventSystem.current.currentSelectedGameObject;
        TextMeshProUGUI t = o.GetComponentInChildren<TextMeshProUGUI>();
        string name = t.text;
        try 
        {
    		currentHouse = households.GetHouse(name);
    	} 
    	catch (InvalidOperationException i)
    	{
    		Debug.LogError(i.Message);
    	}
    	houseTitle.text = currentHouse.name;
        UpdateLoadedHouse.Invoke(currentHouse);
    }

    public void LoadPet()
    {
        GameObject o = EventSystem.current.currentSelectedGameObject;
        Transform container = o.transform.parent;
        Pet pet = container.gameObject.GetComponent<PetTableEntry>().pet;

        if (pet == null)
        {
            throw new InvalidOperationException("[GameManager] Unable to find pet object in pet list");
        }

        currentPet = pet;
        petTitle.text = pet.name;
        LoadNewPet.Invoke(pet);
    }

    public void ClearHouse()
    {
        currentHouse = null;
        houseTitle.text = "No house selected...";
        UpdateLoadedHouse.Invoke(currentHouse);
    }
}    
/*
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/HouseHoldData.dat");

        HouseData data = new HouseData();
        data.houses = households;

        bf.Serialize(file, data);
        file.Close();
        Debug.Log("HouseHold data has been saved!");
    }

    public void LoadAppData()
    {
        Debug.Log(Application.persistentDataPath);
        if (File.Exists(Application.persistentDataPath + "/HouseHoldData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/HouseHoldData.dat", FileMode.Open);
            HouseData data = (HouseData)bf.Deserialize(file);
            if (data != null)
            {
                this.households = data.houses;
            }
            else
            {
                this.households = new List<HouseHold>(30);
            }
        }
        else 
        {
            this.households = new List<HouseHold>(30);
        }
    }
}

[Serializable]
class HouseData
{
    public List<HouseHold> houses;
}
*/