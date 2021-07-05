using System;
using UnityEngine;

public class CheckData : MonoBehaviour
{
    LoadData loadData;

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

        CheckStatus();
    }

    public  void CheckStatus()
    {
        loadData = FindObjectOfType<LoadData>();

        Debug.Log("CheckStatus");

        DateTime currentTime = DateTime.Now;

        switch (currentTime.Hour)
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                break;
            case 6:
                if (currentTime.Minute > 29) {
                    if (!loadData.breakfast) {
                        loadData.cacingan = true;
                        if (!loadData.isDirty) {
                            loadData.isDirty = true;
                            loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                        }
                        loadData.breakfast = true;
                        loadData.totBreakfast += 1;
                        loadData.diciplineHungry += 1;
                    }
                }

                if (currentTime.Minute > loadData.peeMinute1 + 5) {
                    if (!loadData.alreadyPee1) {
                        loadData.peeOutStatus = true;
                        if (!loadData.isDirty)
                        {
                            loadData.isDirty = true;
                            loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                        }
                        loadData.alreadyPee1 = true;
                        loadData.diciplineCleanliness -= 1;
                    }
                }

                if (currentTime.Minute > loadData.poopMinute + 5) {
                    if (!loadData.alreadyPoop) {
                        loadData.poopOutStatus = true;
                        if (!loadData.isDirty) {
                            loadData.isDirty = true;
                            loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                        }
                        loadData.alreadyPoop = true;
                        loadData.diciplineCleanliness -= 1;
                    }
                }
                break;

            case 7:
                if (!loadData.breakfast) {
                    loadData.cacingan = true;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                    }
                    loadData.breakfast = true;
                    loadData.totBreakfast += 1;
                    loadData.diciplineHungry -= 1;
                }

                if (!loadData.alreadyPoop) {
                    loadData.poopOutStatus = true;
                    loadData.alreadyPoop = true;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                    }
                    loadData.diciplineCleanliness -= 1;
                }

                if (!loadData.alreadyPee1) {
                    loadData.peeOutStatus = true;
                    loadData.alreadyPee1 = true;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                    }
                    loadData.diciplineCleanliness -= 1;
                }
                break;

            case 8:
            case 9:
            case 10:
            case 11:
            case 12:
            case 13:
                if (!loadData.breakfast) {
                    loadData.cacingan = true;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                    }
                    loadData.breakfast = true;
                    loadData.totBreakfast += 1;
                    loadData.diciplineHungry -= 1;
                }

                if (!loadData.alreadyPoop) {
                    loadData.poopOutStatus = true;
                    loadData.alreadyPoop = true;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                    }
                    loadData.diciplineCleanliness -= 1;
                }
                if (!loadData.alreadyPee1) {
                    loadData.peeOutStatus = true;
                    loadData.alreadyPee1 = true;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                    }
                    loadData.diciplineCleanliness -= 1;
                }

                if (!loadData.playInMorning) {
                    loadData.diciplineHappiness -= 1;
                    loadData.playInMorning = true;
                }
                break;

            case 14:
                if (!loadData.breakfast) {
                    loadData.cacingan = true;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                    }
                    loadData.breakfast = true;
                    loadData.totBreakfast += 1;
                }

                if (!loadData.alreadyPoop) {
                    loadData.poopOutStatus = true;
                    loadData.alreadyPoop = true;
                    loadData.diciplineCleanliness -= 1;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                    }
                }

                if (!loadData.alreadyPee1) {
                    loadData.peeOutStatus = true;
                    loadData.alreadyPee1 = true;
                    loadData.diciplineCleanliness -= 1;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                    }
                }

                if (currentTime.Minute > 29) {
                    if (!loadData.lunch) {
                        loadData.cacingan = true;
                        if (!loadData.isDirty) {
                            loadData.isDirty = true;
                            loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 14, 30, 0);
                        }
                        loadData.lunch = true;
                        loadData.totLunch += 1;
                        loadData.diciplineHungry -= 1;
                    }
                }

                if (currentTime.Minute > loadData.thristyMinute + 10)
                {
                    if (!loadData.giveWater) {
                        loadData.cacingan = true;
                        if (!loadData.isDirty) {
                            loadData.isDirty = true;
                            loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 14, 30, 0);
                        }
                        loadData.giveWater = true;
                    }
                }

                if (!loadData.playInMorning) {
                    loadData.diciplineHappiness -= 1;
                    loadData.playInMorning = true;
                }
                break;

            case 15:
            case 16:
            case 17:
            case 18:
                if (!loadData.breakfast) {
                    loadData.cacingan = true;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                    }
                    loadData.breakfast = true;
                    loadData.totBreakfast += 1;
                    loadData.diciplineHungry -= 1;
                }

                if (!loadData.alreadyPoop) {
                    loadData.poopOutStatus = true;
                    loadData.alreadyPoop = true;
                    loadData.diciplineCleanliness -= 1;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                    }
                }

                if (!loadData.alreadyPee1) {
                    loadData.peeOutStatus = true;
                    loadData.alreadyPee1 = true;
                    loadData.diciplineCleanliness -= 1;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                    }
                }

                if (!loadData.lunch) {
                    loadData.cacingan = true;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 14, 30, 0);
                    }
                    loadData.lunch = true;
                    loadData.totLunch += 1;
                    loadData.diciplineHungry -= 1;
                }

                if (!loadData.giveWater) {
                    loadData.cacingan = true;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 14, 30, 0);
                    }
                    loadData.giveWater = true;
                }

                if (!loadData.playInMorning) {
                    loadData.diciplineHappiness -= 1;
                    loadData.playInMorning = true;
                }

                break;

            case 19:
                if (!loadData.breakfast)
                {
                    loadData.cacingan = true;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                    }
                    loadData.breakfast = true;
                    loadData.totBreakfast += 1;
                    loadData.diciplineHungry -= 1;
                }

                if (!loadData.alreadyPoop) {
                    loadData.poopOutStatus = true;
                    loadData.alreadyPoop = true;
                    loadData.diciplineCleanliness -= 1;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                    }
                }

                if (!loadData.alreadyPee1) {
                    loadData.peeOutStatus = true;
                    loadData.alreadyPee1 = true;
                    loadData.diciplineCleanliness -= 1;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                    }
                }

                if (!loadData.lunch) {
                    loadData.cacingan = true;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 14, 30, 0);
                    }
                    loadData.lunch = true;
                    loadData.totLunch += 1;
                    loadData.diciplineHungry -= 1;
                }

                if (!loadData.giveWater) {
                    loadData.cacingan = true;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 14, 30, 0);
                    }
                    loadData.giveWater = true;
                }

                if (currentTime.Minute > loadData.peeMinute2 + 5)
                {
                    if (!loadData.alreadyPee2) {
                        loadData.peeOutStatus = true;
                        loadData.alreadyPee2 = true;
                        loadData.diciplineCleanliness -= 1;
                        if (!loadData.isDirty) {
                            loadData.isDirty = true;
                            loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 19, 30, 0);
                        }
                    }
                }

                if (!loadData.playInMorning) { 
                    loadData.diciplineHappiness -= 1;
                    loadData.playInMorning = true;
                }
                break;

            case 20:
                if (!loadData.breakfast) {
                    loadData.cacingan = true;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                    }
                    loadData.breakfast = true;
                    loadData.totBreakfast += 1;
                    loadData.diciplineHungry -= 1;
                }

                if (!loadData.alreadyPoop) { 
                    loadData.poopOutStatus = true;
                    loadData.alreadyPoop = true;
                    loadData.diciplineCleanliness -= 1;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                    }
                }

                if (!loadData.alreadyPee1) {
                    loadData.peeOutStatus = true;
                    loadData.alreadyPee1 = true;
                    loadData.diciplineCleanliness -= 1;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                    }
                }

                if (!loadData.lunch) {
                    loadData.cacingan = true;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 14, 30, 0);
                    }
                    loadData.lunch = true;
                    loadData.totLunch += 1;
                    loadData.diciplineHungry -= 1;
                }

                if (!loadData.giveWater) {
                    loadData.cacingan = true;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 14, 30, 0);
                    }
                    loadData.giveWater = true;
                }

                if (currentTime.Minute > loadData.peeMinute2 + 5) {
                    if (!loadData.alreadyPee2) {
                        loadData.peeOutStatus = true;
                        loadData.alreadyPee2 = true;
                        loadData.diciplineCleanliness -= 1;
                        if (!loadData.isDirty) { 
                            loadData.isDirty = true;
                            loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 19, 30, 0);
                        }
                    }
                }

                if (!loadData.playInMorning) {
                    loadData.diciplineHappiness -= 1;
                    loadData.playInMorning = true;
                }

                break;

            case 21:
                if (!loadData.breakfast) {
                    loadData.cacingan = true;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                    }
                    loadData.breakfast = true;
                    loadData.totBreakfast += 1;
                    loadData.diciplineHungry -= 1;
                }

                if (!loadData.alreadyPoop) {
                    loadData.poopOutStatus = true;
                    loadData.alreadyPoop = true;
                    loadData.diciplineCleanliness -= 1;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                    }
                }
                if (!loadData.alreadyPee1) {
                    loadData.peeOutStatus = true;
                    loadData.alreadyPee1 = true;
                    loadData.diciplineCleanliness -= 1;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                    }
                }

                if (!loadData.lunch) {
                    loadData.cacingan = true;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 14, 30, 0);
                    }
                    loadData.lunch = true;
                    loadData.totLunch += 1;
                    loadData.diciplineHungry -= 1;
                }

                if (!loadData.giveWater) {
                    loadData.cacingan = true;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 14, 30, 0);
                    }
                    loadData.giveWater = true;
                }

                if (currentTime.Minute > loadData.peeMinute2 + 5) {
                    if (!loadData.alreadyPee2)
                    {
                        loadData.peeOutStatus = true;
                        loadData.alreadyPee2 = true;
                        loadData.diciplineCleanliness -= 1;
                        if (!loadData.isDirty)  {
                            loadData.isDirty = true;
                            loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 19, 30, 0);
                        }
                    }
                }

                if (currentTime.Minute > 29) {
                    if (!loadData.dinner) {
                        loadData.cacingan = true;
                        if (!loadData.isDirty) {
                            loadData.isDirty = true;
                            loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 21, 30, 0);
                        }
                        loadData.dinner = true;
                        loadData.totDinner += 1;
                        loadData.diciplineHungry -= 1;
                    }
                }

                if (!loadData.playInMorning) {
                    loadData.diciplineHappiness -= 1;
                    loadData.playInMorning = true;
                }

                if(!loadData.playInNight) {
                    loadData.diciplineHappiness -= 1;
                    loadData.playInNight = true;
                }
                break;

            case 22:
            case 23:
                if (!loadData.breakfast) {
                    loadData.cacingan = true;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                    }
                    loadData.breakfast = true;
                    loadData.totBreakfast += 1;
                    loadData.diciplineHungry -= 1;
                }

                if (!loadData.alreadyPoop) {
                    loadData.poopOutStatus = true;
                    loadData.alreadyPoop = true;
                    loadData.diciplineCleanliness -= 1;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                    }
                }

                if (!loadData.alreadyPee1) {
                    loadData.peeOutStatus = true;
                    loadData.alreadyPee1 = true;
                    loadData.diciplineCleanliness -= 1;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                    }
                }

                if (!loadData.lunch) {
                    loadData.cacingan = true;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 14, 30, 0);
                    }
                    loadData.lunch = true;
                    loadData.totLunch += 1;
                    loadData.diciplineHungry -= 1;
                }

                if (!loadData.giveWater) {
                    loadData.cacingan = true;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 14, 30, 0);
                    }
                    loadData.giveWater = true;
                }

                if (currentTime.Minute > loadData.peeMinute2 + 5) {
                    if (!loadData.alreadyPee2) {
                        loadData.peeOutStatus = true;
                        loadData.alreadyPee2 = true;
                        loadData.diciplineCleanliness -= 1;
                        if (!loadData.isDirty) {
                            loadData.isDirty = true;
                            loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 19, 30, 0);
                        }
                    }
                }

                if (!loadData.dinner) {
                    loadData.cacingan = true;
                    if (!loadData.isDirty) {
                        loadData.isDirty = true;
                        loadData.cleanlinessParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 6, 30, 0);
                    }
                    loadData.dinner = true;
                    loadData.totDinner += 1;
                    loadData.diciplineHungry -= 1;
                }

                if (!loadData.playInMorning) {
                    loadData.diciplineHappiness -= 1;
                    loadData.playInMorning = true;
                }

                if (!loadData.playInNight) {
                    loadData.diciplineHappiness -= 1;
                    loadData.playInNight = true;
                }
                break;
        }

        if (loadData.hairball)
        {
            loadData.hairBallLevel += 1;
            loadData.hairball = false;
        }
        Debug.Log("breakfast parameter timer" + loadData.breakfastParameterTimer);
        Debug.Log("poop parameter timer" + loadData.poopParameterTimer);
        Debug.Log("pee1 parameter timer" + loadData.pee1ParameterTimer);
        Debug.Log("pee2 parameter timer" + loadData.pee2ParameterTimer);
        Debug.Log("lunch parameter timer" + loadData.lunchParameterTimer);
        Debug.Log("thristy parameter timer" + loadData.thristyParameterTimer);
        Debug.Log("dinner parameter timer" + loadData.dinnerParameterTimer);
        Debug.Log("health parameter timer" + loadData.healthParameterTimer);
        Debug.Log("happiness parameter timer" + loadData.happinessInMorningParameterTimer);
        Debug.Log("happiness in night parameter timer" + loadData.happinessInNightParameterTimer);
        Debug.Log("cleanliness parameter timer" + loadData.cleanlinessParameterTimer);
        Debug.Log("Date : " + loadData.date);

    }

    public void CheckHealthy()
    {
        loadData = FindObjectOfType<LoadData>();

        if (loadData.cacingan && !loadData.isSick)
        {
            loadData.healthParameterTimer = new DateTime(loadData.date.Year, loadData.date.Month, loadData.date.Day, 00, 00, 00);

        }
    }
}
