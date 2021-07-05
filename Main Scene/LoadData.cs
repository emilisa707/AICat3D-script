using System;
using UnityEngine;
using System.IO;

[System.Serializable]

public class LoadData : MonoBehaviour
{
    CheckData checkData;

    public string petName = "";
    public int age;
    public int money;
    public int weight;

    public int diciplineHungry;
    public int diciplineCleanliness;
    public int diciplineHappiness;
    public int social;
    public int patTotal;

    public bool breakfast;
    public DateTime breakfastParameterTimer;
    public int breakfastLevel;
    public int totBreakfast;
    public bool dontWantBreakfast;

    public bool alreadyPoop;
    public int poopMinute;
    public DateTime poopParameterTimer;
    public int poopLevel;
    public bool poopOutStatus;

    public bool alreadyPee1;
    public int peeMinute1;
    public DateTime pee1ParameterTimer;
    public int pee1Level;
    public bool peeOutStatus;

    public bool alreadyPee2;
    public int peeMinute2;
    public DateTime pee2ParameterTimer;
    public int pee2Level;

    public bool lunch;
    public DateTime lunchParameterTimer;
    public int lunchLevel;
    public int totLunch;
    public bool dontWantLunch;

    public bool giveWater;
    public int thristyMinute;
    public DateTime thristyParameterTimer;
    public int thristyLevel;

    public bool dinner;
    public DateTime dinnerParameterTimer;
    public int dinnerLevel;
    public int totDinner;
    public bool dontWantDinner;

    public bool dirtyFoodBox;
    public bool dirtyLitterBox;
    public bool isVeryHungry;

    public bool playInMorning;
    public DateTime happinessInMorningParameterTimer;
    public int happinessInMorningLevel;

    public bool playInNight;
    public DateTime happinessInNightParameterTimer;
    public int happinessInNightLevel;

    public bool playingWithToy;

    public int health;
    public int cleanliness;
    public int hairBallLevel;

    public bool susahBAB;
    public bool cacingan;

    public bool comb;
    public bool hairball;

    public bool isDirty;
    public bool isVeryDirty;

    public bool isSick;
    public bool isSad;
    public bool isDied;



    public DateTime date, time;

    public DateTime healthParameterTimer, cleanlinessParameterTimer;

    private void Awake()
    {
        checkData = FindObjectOfType<CheckData>();

        string path = Application.persistentDataPath + "/saveFile.dat";
        if (File.Exists(path))
        {
            Debug.Log("filenya ada");
            GameStateData data = Game.LoadPlayer();

            petName = data.petName;
            age = data.age;
            money = data.money;
            weight = data.weight;

            diciplineHungry = data.diciplineHungry;
            diciplineCleanliness = data.diciplineCleanliness;
            diciplineHappiness = data.diciplineHappiness;
            social = data.social;
            patTotal = data.patTotal;

            breakfast = data.breakfast;
            breakfastParameterTimer = data.breakfastParameterTimer;
            breakfastLevel = data.breakfastLevel;
            totBreakfast = data.totBreakfast;
            dontWantBreakfast = data.dontWantBreakfast;

            alreadyPoop = data.alreadyPoop;
            poopMinute = data.poopMinute;
            poopParameterTimer = data.poopParameterTimer;
            poopLevel = data.poopLevel;
            poopOutStatus = data.poopOutStatus;

            alreadyPee1 = data.alreadyPee1;
            peeMinute1 = data.peeMinute1;
            pee1ParameterTimer = data.pee1ParameterTimer;
            pee1Level = data.pee1Level;
            peeOutStatus = data.peeOutStatus;

            alreadyPee2 = data.alreadyPee2;
            peeMinute2 = data.peeMinute2;
            pee2ParameterTimer = data.pee2ParameterTimer;
            pee2Level = data.pee2Level;

            lunch = data.lunch;
            lunchParameterTimer = data.lunchParameterTimer;
            lunchLevel = data.lunchLevel;
            totLunch = data.totLunch;
            dontWantLunch = data.dontWantLunch;

            giveWater = data.giveWater;
            thristyMinute = data.thristyMinute;
            thristyParameterTimer = data.thristyParameterTimer;
            thristyLevel = data.thristyLevel;

            cacingan = data.cacingan;
            comb = data.comb;

            dinner = data.dinner;
            dinnerParameterTimer = data.dinnerParameterTimer;
            dinnerLevel = data.dinnerLevel;
            totDinner = data.totDinner;
            dontWantDinner = data.dontWantDinner;

            dirtyFoodBox = data.dirtyFoodBox;
            dirtyLitterBox = data.dirtyLitterBox;
            isVeryHungry = data.isVeryHungry;

            susahBAB = data.susahBAB;

            playInMorning = data.playInMorning;
            happinessInMorningParameterTimer = data.happinessInMorningParameterTimer;
            happinessInMorningLevel = data.happinessInMorningLevel;

            playInNight = data.playInNight;
            happinessInNightParameterTimer = data.happinessInNightParameterTimer;
            happinessInNightLevel = data.happinessInNightLevel;

            playingWithToy = data.isPlayingWithToy;

            isDirty = data.isDirty;
            isSick = data.isSick;
            isSad = data.isSad;
            isDied = data.isDied;
            isVeryDirty = data.isVeryDirty;

            health = data.healthLevel;
            cleanliness = data.cleanlinessLevel;
            hairBallLevel = data.hairBallLevel;
            hairball = data.hairball;

            healthParameterTimer = data.healthParameterTimer;
            cleanlinessParameterTimer = data.cleanlinessParameterTimer;

            date = data.lastRecordedDate;
            time = data.lastTimeLogOut;

            if (DateTime.Today > date)
            {
                Debug.Log("kemaren-kemaren terakhir login");

                TimeSpan dateSpan = DateTime.Today - date;
                int totaldays = (int)dateSpan.TotalDays;
                age += totaldays;
                if (totaldays > 2)
                {
                    isDied = true;
                }
                else
                {
                    Debug.Log("kemaren terakhir login");
                    date = DateTime.Today;
                    checkData.ResetStatus();
                    checkData.CheckHealthy();
                }

            }
            else
            {
                Debug.Log("hari ini terakhir login");
                checkData.CheckStatus();

            }
        }
        else
        {
            Debug.Log("file tidak ada");
            CreateData();
        }
    }

    void CreateData()
    {
        Debug.Log("Buat Data pertama kali");

        date = DateTime.Today;
        time = DateTime.Now;

        GameObject nameStorage = GameObject.FindGameObjectWithTag("nameInput");
        petName = nameStorage.GetComponent<KeepNameInputValue>().petName;
        age = 60;
        money = 100;
        weight = 100;

        diciplineHungry = 0;
        diciplineHappiness = 0;
        diciplineCleanliness = 0;
        social = 0;
        patTotal = 0;

        peeMinute1 = UnityEngine.Random.Range(0, 29);
        peeMinute2 = UnityEngine.Random.Range(0, 29);
        poopMinute = UnityEngine.Random.Range(0, 29);
        int index = 0;
        while (Mathf.Abs(poopMinute - peeMinute1) < 10 && index < 100)
        {
            poopMinute = UnityEngine.Random.Range(0, 29);
            index++;
        }

        breakfastParameterTimer = new DateTime(date.Year, date.Month, date.Day, 6, 0, 0);
        breakfastLevel = 100;
        totBreakfast = 0;
        dontWantBreakfast = false;


        poopParameterTimer = new DateTime(date.Year, date.Month, date.Day, 6, poopMinute, 0);
        poopLevel = 100;
        poopOutStatus = false;

        pee1ParameterTimer = new DateTime(date.Year, date.Month, date.Day, 6, peeMinute1, 0);
        pee1Level = 100;
        peeOutStatus = false;

        pee2ParameterTimer = new DateTime(date.Year, date.Month, date.Day, 19, peeMinute2, 0);
        pee2Level = 100;

        lunchParameterTimer = new DateTime(date.Year, date.Month, date.Day, 14, 0, 0);
        lunchLevel = 100;
        totLunch = 0;
        dontWantLunch = false;

        thristyMinute = UnityEngine.Random.Range(0, 29);
        thristyParameterTimer = new DateTime(date.Year, date.Month, date.Day, 14, thristyMinute, 0);
        thristyLevel = 100;

        dinnerParameterTimer = new DateTime(date.Year, date.Month, date.Day, 21, 0, 0);
        dinnerLevel = 100;
        totDinner = 0;
        dontWantDinner = false;

        dirtyFoodBox = false;
        dirtyLitterBox = false;
        isVeryHungry = false;
        susahBAB = false;

        cacingan = false;
        playingWithToy = false;

        isDirty = false;
        isSick = false;
        isSad = false;
        isDied = false;

        
        happinessInMorningLevel = 100;
        happinessInMorningParameterTimer = new DateTime(date.Year, date.Month, date.Day, 7, 0, 0);
        happinessInNightLevel = 100;
        happinessInNightParameterTimer = new DateTime(date.Year, date.Month, date.Day, 19, 0, 0);

        health = 100;
        cleanliness = 100;
        hairBallLevel = 0;

        healthParameterTimer = DateTime.Now;
        cleanlinessParameterTimer = DateTime.Now;

        CheckInitialStatus();

       
    }

    void CheckInitialStatus()
    {
        Debug.Log("Memeriksa Status Pertama kali");
        switch(time.Hour)
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                breakfast = false;
                alreadyPoop = false;
                alreadyPee1 = false;
                alreadyPee2 = false;
                playInMorning = false;
                playInNight = false;
                lunch = false;
                giveWater = false;
                comb = false;
                dinner = false;
                break;

            case 6:
                if (time.Minute < 30)
                {
                    breakfastParameterTimer = DateTime.Now;
                    breakfast = false;

                    if (time.Minute < poopMinute)
                    {
                        alreadyPoop = false;
                    }
                    else
                    {
                        alreadyPoop = true;
                    }

                    if (time.Minute < peeMinute1)
                    {
                        alreadyPee1 = false;
                    }
                    else
                    {
                        alreadyPee1 = true;
                    }

                    playInMorning = false;
                    playInNight = false;
                    alreadyPee2 = false;
                    lunch = false;
                    giveWater = false;
                    comb = false;
                    dinner = false;
                }
                else
                {
                    breakfast = true;
                    totBreakfast += 2;
                    alreadyPoop = true;
                    alreadyPee1 = true;
                    playInMorning = false;
                    playInNight = false;
                    alreadyPee2 = false;
                    lunch = false;
                    giveWater = false;
                    comb = false;
                    dinner = false;
                }
                break;

            case 7:
                totBreakfast += 2;
                breakfast = true;
                alreadyPoop = true;
                alreadyPee1 = true;
                alreadyPee2 = true;
                happinessInMorningParameterTimer = DateTime.Now;
                playInMorning = false;
                playInNight = false;
                lunch = false;
                giveWater = false;
                comb = false;
                dinner = false;
                break;

            case 8:
            case 9:
            case 10:
            case 11:
            case 12:
            case 13:
                breakfast = true;
                totBreakfast += 2;
                alreadyPoop = true;
                alreadyPee1 = true;
                alreadyPee2 = true;
                playInMorning = true;
                playInNight = false;
                lunch = false;
                giveWater = false;
                comb = false;
                dinner = false;
                break;

            case 14:
                if (time.Minute < 30)
                {
                    breakfast = true;
                    alreadyPoop = true;
                    alreadyPee1 = true;
                    playInMorning = true;
                    playInNight = false;
                    alreadyPee2 = false;
                    lunchParameterTimer = DateTime.Now;
                    lunch = false;
                    if (time.Minute < thristyMinute)
                    {
                        giveWater = false;
                    }
                    else
                    {
                        giveWater = true;
                    }
                    comb = false;
                    dinner = false;
                }
                else
                {
                    breakfast = true;
                    alreadyPoop = true;
                    alreadyPee1 = true;
                    playInMorning = true;
                    playInNight = false;
                    alreadyPee2 = false;
                    lunch = true;
                    totLunch += 2;
                    giveWater = true;
                    comb = false;
                    dinner = false;
                }
                break;
            case 15:
            case 16:
            case 17:
            case 18:
                breakfast = true;
                alreadyPoop = true;
                alreadyPee1 = true;
                playInMorning = true;
                playInNight = false;
                alreadyPee2 = false;
                lunch = true;
                totLunch += 2;
                giveWater = true;
                comb = false;
                dinner = false;
                break;

            case 19:
                breakfast = true;
                alreadyPoop = true;
                alreadyPee1 = true;
                playInMorning = true;
                happinessInNightParameterTimer = DateTime.Now;
                playInNight = false;

                if (time.Minute < peeMinute2)
                {
                    alreadyPee2 = false;
                }
                else
                {
                    alreadyPee2 = true;
                }
                lunch = true;
                totLunch += 2;
                giveWater = true;
                comb = false;
                dinner = false;
                break;

            case 20:
                breakfast = true;
                alreadyPoop = true;
                alreadyPee1 = true;
                playInMorning = true;
                happinessInNightParameterTimer = DateTime.Now;
                playInNight = false;
                alreadyPee2 = true;
                lunch = true;
                totLunch += 2;
                giveWater = true;
                comb = false;
                dinner = false;
                break;

            case 21:
                if (time.Minute < 30)
                {
                    breakfast = true;
                    alreadyPoop = true;
                    alreadyPee1 = true;
                    playInMorning = true;
                    playInNight = true;
                    alreadyPee2 = true;
                    dinnerParameterTimer = DateTime.Now;
                    lunch = true;
                    giveWater = true;
                    comb = false;
                    dinner = false;
                }
                else
                {
                    breakfast = true;
                    alreadyPoop = true;
                    alreadyPee1 = true;
                    playInMorning = true;
                    playInNight = true;
                    alreadyPee2 = true;
                    lunch = true;
                    giveWater = true;
                    comb = true;
                    dinner = true;
                    totDinner += 2;
                }
                break;
            case 22:
            case 23:
                breakfast = true;
                alreadyPoop = true;
                alreadyPee1 = true;
                playInMorning = true;
                playInNight = true;
                alreadyPee2 = true;
                lunch = true;
                giveWater = true;
                comb = true;
                dinner = true;
                totDinner += 2;
                break;
                
        }

        Debug.Log("breakfast parameter timer: " + breakfastParameterTimer);
        Debug.Log("poop parameter timer : " + poopParameterTimer);
        Debug.Log("pee1 parameter timer : " + pee1ParameterTimer);
        Debug.Log("pee2 parameter timer : " + pee2ParameterTimer);
        Debug.Log("lunch parameter timer : " + lunchParameterTimer);
        Debug.Log("thristy parameter timer : " + thristyParameterTimer);
        Debug.Log("dinner parameter timer : " + dinnerParameterTimer);
        Debug.Log("health parameter timer : " + healthParameterTimer);
        Debug.Log("happiness parameter timer : " + happinessInMorningParameterTimer);
        Debug.Log("happiness in night parameter timer : " + happinessInNightParameterTimer);
        Debug.Log("cleanliness parameter timer : " + cleanlinessParameterTimer);
        Debug.Log("Date : " + date);
    }


    private void OnApplicationQuit()
    {
        Game.SavePlayer(this);
    }

    
}
