using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class HouseTableManager : MonoBehaviour
{
	public Transform entryContainer;
	public Transform entryTemplate;
    public float width, height;

    private Transform[][] buttons;

    public void InitializeTable()
    {
    	entryTemplate.gameObject.SetActive(false);
        buttons = new Transform[3][]; 
        buttons[0] = new Transform[10];
        buttons[1] = new Transform[10];
        buttons[2] = new Transform[10];
        BuildTable();
    }

    private void BuildTable()
    {
        for (int x = 0; x < 3; x++) 
        {
            for (int y = 0; y < 10; y++)
            {   
                Transform entryTransform = Instantiate(entryTemplate, entryContainer);
                RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>() as RectTransform;
                entryRectTransform.anchoredPosition = new Vector2(width * x, -height * y);
                entryTransform.gameObject.SetActive(false);
                buttons[x][y] = entryTransform;
            }
        }
        Debug.LogError("[TableManager] Table Constructed!");
    }

    public void NewHouse(HouseHold house)
    {

        for(int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                Transform button = buttons[x][y];
                if (button != null)
                {
                    RectTransform rect = button.GetComponent<RectTransform>() as RectTransform;
                    TextMeshProUGUI textBox = rect.GetComponentInChildren<TextMeshProUGUI>() as TextMeshProUGUI;

                    if (textBox != null) 
                    {
                        if (textBox.text == "PLACEHOLDER NAME")
                        {
                            textBox.text = house.name;
                            button.gameObject.SetActive(true);
                            return;
                        }
                    }
                    else
                    { 
                        throw new ArgumentException("[TableManager] Unable to find button textbox!");
                    }
                }
                else
                {
                    throw new ArgumentException("[TableManager] Unable to find table!");
                } 
            }
        }
    }






}
