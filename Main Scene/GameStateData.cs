using System;

[Serializable] 
public class GameStateData
{
    public string petName;
    public int age;
    public int money;
    public int weight;

    public int diciplineHungry;
    public int diciplineHappiness;
    public int diciplineCleanliness;
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

    public bool cacingan;
    public bool comb;
    public bool hairball;

    public bool dinner;
    public DateTime dinnerParameterTimer;
    public int dinnerLevel;
    public int totDinner;
    public bool dontWantDinner;

    public bool playInMorning;
    public DateTime happinessInMorningParameterTimer;
    public int happinessInMorningLevel;

    public bool playInNight;
    public DateTime happinessInNightParameterTimer;
    public int happinessInNightLevel;

    public bool isPlayingWithToy;

    public bool dirtyFoodBox;
    public bool dirtyLitterBox;
    public bool isVeryHungry;

    public bool susahBAB;
    public bool isDirty;

    public bool isSick;
    public bool isSad;
    public bool isDied;
    public bool isVeryDirty;

    public int healthLevel, cleanlinessLevel, hairBallLevel;
    public DateTime healthParameterTimer, cleanlinessParameterTimer;
       
    public DateTime lastTimeLogOut, lastRecordedDate;

    public GameStateData (LoadData loadData)
    {
        petName = loadData.petName;
        age = loadData.age;
        money = loadData.money;
        weight = loadData.weight;

        diciplineHungry = loadData.diciplineHungry;
        diciplineHappiness = loadData.diciplineHappiness;
        diciplineCleanliness = loadData.diciplineCleanliness;
        social = loadData.social;
        patTotal = loadData.patTotal;

        breakfast = loadData.breakfast;
        breakfastParameterTimer = loadData.breakfastParameterTimer;
        breakfastLevel = loadData.breakfastLevel;
        totBreakfast = loadData.totBreakfast;
        dontWantBreakfast = loadData.dontWantBreakfast;

        alreadyPoop = loadData.alreadyPoop;
        poopMinute = loadData.poopMinute;
        poopParameterTimer = loadData.poopParameterTimer;
        poopLevel = loadData.poopLevel;
        poopOutStatus = loadData.poopOutStatus;

        alreadyPee1 = loadData.alreadyPee1;
        peeMinute1 = loadData.peeMinute1;
        pee1ParameterTimer = loadData.pee1ParameterTimer;
        pee1Level = loadData.pee1Level;
        peeOutStatus = loadData.peeOutStatus;

        alreadyPee2 = loadData.alreadyPee2;
        peeMinute2 = loadData.peeMinute2;
        pee2ParameterTimer = loadData.pee2ParameterTimer;
        pee2Level = loadData.pee2Level;

        lunch = loadData.lunch;
        lunchParameterTimer = loadData.lunchParameterTimer;
        lunchLevel = loadData.lunchLevel;
        totLunch = loadData.totLunch;
        dontWantLunch = loadData.dontWantLunch;

        giveWater = loadData.giveWater;
        thristyMinute = loadData.thristyMinute;
        thristyParameterTimer = loadData.thristyParameterTimer;
        thristyLevel = loadData.thristyLevel;

        cacingan = loadData.cacingan;
        comb = loadData.comb;

        dinner = loadData.dinner;
        dinnerParameterTimer = loadData.dinnerParameterTimer;
        dinnerLevel = loadData.dinnerLevel;
        totDinner = loadData.totDinner;
        dontWantDinner = loadData.dontWantDinner;

        dirtyFoodBox = loadData.dirtyFoodBox;
        dirtyLitterBox = loadData.dirtyLitterBox;
        isVeryHungry = loadData.isVeryHungry;

        susahBAB = loadData.susahBAB;

        playInMorning = loadData.playInMorning;
        happinessInMorningParameterTimer = loadData.happinessInMorningParameterTimer;
        happinessInMorningLevel = loadData.happinessInMorningLevel;

        playInNight = loadData.playInNight;
        happinessInNightLevel = loadData.happinessInNightLevel;
        happinessInNightParameterTimer = loadData.happinessInNightParameterTimer;

        isPlayingWithToy = loadData.playingWithToy;

        isDirty = loadData.isDirty;
        isSick = loadData.isSick;
        isSad = loadData.isSad;
        isDied = loadData.isDied;
        isVeryDirty = loadData.isVeryDirty;

        healthLevel = loadData.health;
        cleanlinessLevel = loadData.cleanliness;
        healthParameterTimer = loadData.healthParameterTimer;
        cleanlinessParameterTimer = loadData.cleanlinessParameterTimer;

        hairBallLevel = loadData.hairBallLevel;
        hairball = loadData.hairball;

        lastRecordedDate = loadData.date;
        lastTimeLogOut = loadData.time;
}
}
