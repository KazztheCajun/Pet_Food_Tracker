using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PetTableManager : MonoBehaviour
{
	public Transform entryContainer;
	public Transform entryTemplate;

    private int entryCount;

    public void InitializeTable()
    {
    	entryTemplate.gameObject.SetActive(false);
        entryCount = 0;
    }

    public void UpdateTable(HouseHold house)
    {
        ClearTable();

        if (house == null)
        {
            return;
        }

        try
        {
            List<Pet> stable = house.GetStable();

            foreach(Pet p in stable)
            {
                Transform entryTransform = Instantiate(entryTemplate, entryContainer);
                RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
                SetData(entryRectTransform, p);
                entryTransform.gameObject.SetActive(true);
                entryCount++;
            }
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e);
        }
    }

    public void AddPetToTable(Pet pet)
    {
        Transform entryTransform = Instantiate(entryTemplate, entryContainer);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        SetData(entryRectTransform, pet);
        entryTransform.gameObject.SetActive(true);
        entryCount++;
    }

    private void SetData(Transform template, Pet data)
    {
        TextMeshProUGUI name = template.GetChild(0).GetComponent<TextMeshProUGUI>() as TextMeshProUGUI;
        TextMeshProUGUI age = template.GetChild(1).GetComponent<TextMeshProUGUI>() as TextMeshProUGUI;
        TextMeshProUGUI weight = template.GetChild(2).GetComponent<TextMeshProUGUI>() as TextMeshProUGUI;
        TextMeshProUGUI breed = template.GetChild(3).GetComponent<TextMeshProUGUI>() as TextMeshProUGUI;
        TextMeshProUGUI calories = template.GetChild(4).GetComponent<TextMeshProUGUI>() as TextMeshProUGUI;

        name.text = data.name;
        age.text = data.age.ToString();
        weight.text = data.weight.ToString();
        breed.text = data.breed;
        calories.text = "250LBS";

        template.gameObject.GetComponent<PetTableEntry>().pet = data;
    }

    private void ClearTable()
    {
        foreach (Transform child in entryContainer)
        {
            if (child.name != "Entry Template")
            {
                Destroy(child.gameObject);
                entryCount = 0;
            }
        }
    }
}
