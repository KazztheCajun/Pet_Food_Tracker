using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventTableManager : MonoBehaviour
{
    public Transform entryContainer;
	public Transform entryTemplate;
	public Transform dayList;

	private float templateHeight = 23f;
    private Pet currentPet;


	public void InitializeTable()
    {
    	entryTemplate.gameObject.SetActive(false);
    	
    	for (int i = 0; i < 5; i++) 
    	{
    		Transform entryTransform = Instantiate(entryTemplate, entryContainer);
    		RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
    		entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
    		entryTransform.gameObject.SetActive(true);
    	}
    }

    public void LoadPet(Pet pet)
    {
    	if (pet == null)
    	{
    		throw new ArgumentException("[EventTableManager] Unable to load Pet.");
    	}

    	BuildDropdown(pet);
        currentPet = pet;
    }

    public void UpdateTable(int index)
    {
        ClearTable();

        try
        {
            List<ItemEvent> log = currentPet.log.calendar[index].events;
            BuildDropdown(currentPet);

            int count = 0;
            foreach(ItemEvent e in log)
            {
                Transform entryTransform = Instantiate(entryTemplate, entryContainer);
                RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
                entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * count);
                SetData(entryRectTransform, e);
                entryTransform.gameObject.SetActive(true);
                count++;
            }
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e);
        }
    }

    private void BuildDropdown(Pet pet)
    {
        TMP_Dropdown dropdown = dayList.GetComponent<TMP_Dropdown>();
        dropdown.ClearOptions();

        List<Day> calendar = pet.log.calendar;
//        calendar.Sort();
        List<string> days = new List<string>();

        foreach(Day d in calendar)
        {
            days.Add(d.ToString());
        }

        if (days.Count == 0)
        {
            days.Add("No days tracked yet.");
        }

        dropdown.AddOptions(days);
    }

    private void SetData(Transform entry, ItemEvent data)
    {
    	TextMeshProUGUI name = entry.GetChild(0).GetComponent<TextMeshProUGUI>() as TextMeshProUGUI;
    	TextMeshProUGUI mass = entry.GetChild(1).GetComponent<TextMeshProUGUI>() as TextMeshProUGUI;

    	name.text = data.itemID.ToString();
    	mass.text = data.startMass.ToString();
    }

    private void ClearTable()
    {
        foreach (Transform child in entryContainer)
        {
            if (child.name != "Entry Template")
            {
                Destroy(child.gameObject);
            }
        }
    }
}
