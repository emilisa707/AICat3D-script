using System;
using UnityEngine;

public abstract class ResetDataStatus : MonoBehaviour
{
    protected LoadData loadData;

    public void ResetStatus()
    {
        loadData = FindObjectOfType<LoadData>();

        Debug.Log("Reset Status");

        loadData.patTotal = 0;
        loadData.breakfastLevel = 100;
        loadData.totBreakfast = 0;
        loadData.breakfastParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 0, 0);
        loadData.dontWantBreakfast = false;

        loadData.lunchLevel = 100;
        loadData.totLunch = 0;
        loadData.lunchParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 14, 0, 0);
        loadData.dontWantLunch = false;

        loadData.dinnerLevel = 100;
        loadData.totDinner = 0;
        loadData.dinnerParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 21, 0, 0);
        loadData.dontWantDinner = false;

        loadData.happinessInMorningLevel = 100;
        loadData.happinessInMorningParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 7, 0, 0);

        loadData.happinessInNightLevel = 100;
        loadData.happinessInNightParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 19, 0, 0);

        loadData.playingWithPlayerInMorning = false;
        loadData.playingWithPlayerInNight = false;

        loadData.peeMinute1 = UnityEngine.Random.Range(0, 29);
        loadData.peeMinute2 = UnityEngine.Random.Range(0, 29);
        loadData.poopMinute = UnityEngine.Random.Range(0, 29);
        loadData.thristyMinute = UnityEngine.Random.Range(0, 29);
        int index = 0;
        while (Mathf.Abs(loadData.poopMinute - loadData.peeMinute1) < 10 && index < 100)
        {
            loadData.poopMinute = UnityEngine.Random.Range(0, 29);
            index++;
        }

        loadData.pee1Level = 100;
        loadData.pee1ParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, loadData.peeMinute1, 0);

        loadData.pee2Level = 100;
        loadData.pee2ParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 19, loadData.peeMinute2, 0);

        loadData.poopLevel = 100;
        loadData.poopParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, loadData.poopMinute, 0);

        loadData.thristyLevel = 100;
        loadData.thristyParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 14, loadData.thristyMinute, 0);


        if (!loadData.breakfast) {
            loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 0, 0, 0);
            loadData.healthParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 0, 0, 0);
            loadData.cacingan = true;
            loadData.isDirty = true;
            loadData.diciplineHungry -= 1;
        } else {
            loadData.breakfast = false;
        }

        if (!loadData.alreadyPoop) {
            loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 0, 0, 0);
            loadData.poopOutStatus = true;
            loadData.diciplineCleanliness -= 1;
        } else {
            loadData.alreadyPoop = false;
        }

        if (!loadData.alreadyPee1)
        {
            loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 0, 0, 0);
            loadData.peeOutStatus = true;
            loadData.diciplineCleanliness -= 1;
        } else {
            loadData.alreadyPee1 = false;
        }

        if(!loadData.playInMorning)
        {
            loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 0, 0, 0);
            loadData.healthParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 0, 0, 0);
            loadData.cacingan = true;
            loadData.isDirty = true;
            loadData.diciplineHappiness -= 1;
            loadData.social -= 1;
        } else {
            loadData.playInMorning = false;
        }

        if (!loadData.lunch)
        {
            loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 0, 0, 0);
            loadData.healthParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 0, 0, 0);
            loadData.cacingan = true;
            loadData.isDirty = true;
            loadData.diciplineHungry -= 1;
        } else {
            loadData.lunch = false;
        }

        if (!loadData.giveWater)
        {
            loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 0, 0, 0);
            loadData.healthParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 0, 0, 0);
            loadData.cacingan = true;
            loadData.isDirty = true;
        } else {
            loadData.giveWater = false;
        }

        if (!loadData.alreadyPee2)
        {
            loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 0, 0, 0);
            loadData.peeOutStatus = true;
            loadData.diciplineCleanliness -= 1;
        } else {
            loadData.alreadyPee2 = false;
        }

        if (!loadData.playInNight)
        {
            loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 0, 0, 0);
            loadData.healthParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 0, 0, 0);
            loadData.cacingan = true;
            loadData.isDirty = true;
            loadData.diciplineHappiness -= 1;
            loadData.social -= 1;
        } else {
            loadData.playInNight = false;
        }

        if (!loadData.dinner)
        {
            loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 0, 0, 0);
            loadData.healthParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 0, 0, 0);
            loadData.cacingan = true;
            loadData.isDirty = true;
            loadData.diciplineHungry -= 1;
        } else {
            loadData.dinner = false;
        }

        if(!loadData.comb) {
            loadData.hairball = true;
        } else  {
            loadData.comb = false;
        }

        CheckingStatus();
    }

    public abstract void CheckingStatus();

    public void CheckHealthy()
    {
        loadData = FindObjectOfType<LoadData>();

        if (loadData.cacingan && !loadData.isSick)
        {
            loadData.healthParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 00, 00, 00);

        }
    }
}
