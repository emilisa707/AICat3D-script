using System;
using UnityEngine;


public class CatBehaviour : MonoBehaviour
{
    CatAnimation petAnimation;
    UIControl uiControl;
    LoadData loadData;
    Cat cat;

    public void Awake()
    {
        petAnimation = FindObjectOfType<CatAnimation>();
        uiControl = FindObjectOfType<UIControl>();
        loadData = FindObjectOfType<LoadData>();
        cat = FindObjectOfType<Cat>();

    }
    void Update()
    {
        TimeSpan takeAbathTimerSpan = uiControl.takeAbathDate - DateTime.Today;

        if (takeAbathTimerSpan.TotalDays == 7)
        {
            loadData.isVeryDirty = true;
        }

        if (loadData.dirtyFoodBox)
        {
            uiControl.tempatMakan.SetActive(true);
        }

        if (loadData.poopOutStatus)
        {
            uiControl.shit.SetActive(true);
        }

        if (loadData.peeOutStatus)
        {
            uiControl.splat.SetActive(true);
        }

        Cleanliness();
        Health();
    }

    #region Breakfast Methode
    public void BreakfastBehavior()
    {
        loadData.playingWithToy = false;
        petAnimation.SetAnimationState(CatAnimation.State.hungry);
        if (loadData.breakfastLevel < 0)
        {
            loadData.diciplineHungry -= 1;
            loadData.cleanliness -= 1;
            loadData.cacingan = true;
            loadData.breakfast = true;
            loadData.totBreakfast += 1;
            cat.state = Cat.State.isGoOut;
            petAnimation.SetAnimationState(CatAnimation.State.goOut);
        }

       else if (loadData.breakfastLevel > 0)
        {
            loadData.isVeryHungry = false;
        }
    }
    #endregion

    #region Lunch Methode
    public void LunchBehavior()
    {
        loadData.playingWithToy = false;


        petAnimation.SetAnimationState(CatAnimation.State.hungry);
        if (loadData.lunchLevel < 0 )
        {
            loadData.isVeryHungry = true;
            loadData.diciplineHungry -= 1;
            loadData.cleanliness -= 1;
            loadData.cacingan = true;
            loadData.lunch = true;
            loadData.totLunch += 1;
            cat.state = Cat.State.isGoOut;
            petAnimation.SetAnimationState(CatAnimation.State.goOut);
        }

        else if (loadData.lunchLevel > 0 )
        {
            loadData.isVeryHungry = false;
        }
    }
    #endregion

    #region Dinner Methode
    public void DinnerBehavior()
    {
        loadData.playingWithToy = false;


        petAnimation.SetAnimationState(CatAnimation.State.hungry);
        if (loadData.breakfastLevel < 0 || loadData.lunchLevel < 0 || loadData.dinnerLevel < 0)
        {
            loadData.isVeryHungry = true;
            loadData.diciplineHungry -= 1;
            loadData.cleanliness -= 1;
            loadData.cacingan = true;
            loadData.dinner = true;
            loadData.totDinner += 1;
            cat.state = Cat.State.isGoOut;
            petAnimation.SetAnimationState(CatAnimation.State.goOut);
        }

        else if (loadData.breakfastLevel > 0 || loadData.lunchLevel > 0 || loadData.dinnerLevel > 0)
        {
            loadData.isVeryHungry = false;
        }
    }

    #endregion

    #region Pee Methode
    public void Pee()
    {
        loadData.playingWithToy = false;
        if (loadData.pee1Level < 0 || loadData.pee2Level < 0)
        {
            loadData.pee1Level = 0;
            loadData.pee2Level = 0;
            loadData.peeOutStatus = true;
        }

        else if (loadData.pee1Level > 0 || loadData.pee2Level > 0)
        {
            loadData.peeOutStatus = false;
        }
    }
    #endregion

    #region Poop Methode
    public void Poop()
    {
        loadData.playingWithToy = false;
        if (loadData.poopLevel < 0)
        {
            loadData.poopLevel = 0;
            loadData.poopOutStatus = true;

        }

        else if (loadData.poopLevel > 0)
        {
            loadData.poopOutStatus = false;
        }
    }
    #endregion

    #region HappinessInMorning Methode
    public void HappinessInMorning()
    {
        petAnimation.SetAnimationState(CatAnimation.State.play);
        if (loadData.happinessInMorningLevel < 0)
        {
            loadData.happinessInMorningLevel = 0;
        }

        else if (loadData.happinessInMorningLevel > 100)
        {
            loadData.happinessInMorningLevel = 100;
        }
    }
    #endregion

    #region HappinessInNight Methode
    public void HappinessInNight()
    {
        petAnimation.SetAnimationState(CatAnimation.State.play);
        if (loadData.happinessInNightLevel < 0)
        {
            loadData.happinessInNightLevel = 0;
        }

        else if (loadData.happinessInNightLevel > 100)
        {
            loadData.happinessInNightLevel = 100;
        }
    }
    #endregion

    #region Health Methode
    void Health()
    {
        if (loadData.health < 0)
        {
            loadData.isDied = true;
            loadData.isSick = false;
            Debug.Log("innalillahi wa inna ilaihi roji'un");
        }

        else if (loadData.health > 100)
        {
            loadData.health = 100;
        }

        else if (loadData.health < 20)
        {
            loadData.isSick = true;
            Debug.Log("i am sick, help");
        }

        else if (loadData.health > 20)
        {
            loadData.isSick = false;
        }

    }
    #endregion

    #region Thristy Methode
    public void Drink()
    {
        loadData.playingWithToy = false;
        petAnimation.SetAnimationState(CatAnimation.State.thristy);
        if (loadData.thristyLevel < 0)
        {
            loadData.thristyLevel = 0;
        }
    }
    #endregion

    #region Cleanliness Methode
    public void Cleanliness()
    {

        if (loadData.cleanliness < 0)
        {
            loadData.cleanliness = 0;
        }

        else if (loadData.cleanliness > 100)
        {
            loadData.cleanliness = 100;
            loadData.isDirty = false;
        }
        if (loadData.cleanliness < 1)
        {
            loadData.isVeryDirty = true;
            loadData.isDirty = false;
            Debug.Log("why so many bug here");
        }
        else if (loadData.cleanliness > 0)
        {
            loadData.isVeryDirty = false;
        }

    }
    #endregion

    #region Lick Methode
    public void Licking()
    {
        loadData.playingWithToy = false;
        petAnimation.SetAnimationState(CatAnimation.State.licking);
        if(loadData.hairball)
        {
            loadData.hairBallLevel += 5;
            loadData.hairball = false;
        }
    }
    #endregion

    #region Sleep Methode
    public void Sleeping()
    {
        loadData.playingWithToy = false;
        petAnimation.SetAnimationState(CatAnimation.State.sleeping);
    }
    #endregion

    #region Observe Methode
    public void Observing()
    {
        loadData.playingWithToy = false;
        petAnimation.SetAnimationState(CatAnimation.State.observing);
    }
    #endregion

    #region Lick Methode
    public void GoOut()
    {
        loadData.playingWithToy = false;
        petAnimation.SetAnimationState(CatAnimation.State.goOut);
        if (loadData.hairball)
        {
            loadData.hairBallLevel += 5;
            loadData.hairball = false;
        }
    }
    #endregion

    #region Died Methode
    public void Died()
    {
        petAnimation.SetAnimationState(CatAnimation.State.died);
    }

    public void Sick()
    {
        petAnimation.SetAnimationState(CatAnimation.State.sick);
    }

    #endregion
}