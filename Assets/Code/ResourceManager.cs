﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public Text coinText;
    public RectTransform powerBar;
    public RectTransform foodBar;
    public Text currentComputingText;
    public Text computingTresholdText;

    private float coin, currentPower, powerTreshold, currentFood, foodTreshold, currentComputing, computingNeed;
    private Vector2 powerSize, foodSize;

    // Start is called before the first frame update
    void Start()
    {
        coin = 1000;

        powerSize = powerBar.sizeDelta;
        foodSize = foodBar.sizeDelta;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Pay(float amount)
    {
        if (coin >= amount)
        {
            coin -= amount;

            // update text
            coinText.text = "$ " + coin;

            return true;
        }
        else
            return false;
    }

    public bool AdjustCurrentPower(float amount)
    {
        if (currentPower + amount > powerTreshold)
        {
            currentPower += amount;

            // update bar
            if (currentPower > 0)
                powerBar.sizeDelta = new Vector2(powerSize.x * (currentPower - powerTreshold) / currentPower, powerSize.y);

            return true;
        }
        else
            return false;
    }
    public bool AdjustPowerTreshold(float amount)
    {
        if (currentPower >= powerTreshold + amount)
        {
            powerTreshold += amount;

            // update bar
            if (currentPower > 0)
                powerBar.sizeDelta = new Vector2(powerSize.x * (currentPower - powerTreshold) / currentPower, powerSize.y);

            return true;
        }
        else
            return false;
    }

    public bool AdjustCurrentFood(float amount)
    {
        if (currentFood + amount > foodTreshold)
        {
            currentFood += amount;

            //print("Current food: " + currentFood);

            // update bar
            if (currentFood > 0)
                foodBar.sizeDelta = new Vector2(foodSize.x * (currentFood - foodTreshold) / currentFood, foodSize.y);

            return true;
        }
        else
            return false;
    }
    public bool AdjustFoodTreshold(float amount)
    {
        if (currentFood >= foodTreshold + amount)
        {
            foodTreshold += amount;

            //print("Food treshold: " + foodTreshold);

            // update bar
            if (currentFood > 0)
                foodBar.sizeDelta = new Vector2(foodSize.x * (currentFood - foodTreshold) / currentFood, foodSize.y);

            return true;
        }
        else
            return false;
    }

    public bool ChangeCurrentComputing(float amount)
    {
        if (currentComputing + amount > computingNeed)
        {
            currentComputing += amount;
            
            // update text
            currentComputingText.text = currentComputing.ToString();

            return true;
        }
        else
            return false;
    }
    public bool ChangeComputingNeed(float amount)
    {
        computingNeed += amount;

        // update text
        computingTresholdText.text = currentComputing.ToString();

        // kill player
        if (computingNeed > currentComputing)
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        return true;
    }
}