using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour {

    Slider healthSlider;
    Slider cleanlinessSlider;

    Cat cat;
    LoadData loadData;
    CatAnimation petAnimation;

    public int money;
    public int angryValue;

    public GameObject moneyText;
    public GameObject diedPanel;

    public GameObject bottomButton;
    public GameObject interaction;
    public GameObject cleanning;
    public GameObject treathment;
    public GameObject playing;

    public GameObject tempatMakan;
    public GameObject tempatMandi;
    public GameObject litterbox;
    public GameObject mainan;
    public GameObject shit;
    public GameObject splat;

    public DateTime takeAbathDate;

    Text petNameLabel;
    GameObject nameStorage;
    Text petAgelabel;
    Text petWeightLabel;
    Text stateLabel;

    int modulus, day, week, month;

    void Awake()
    {
        petAnimation = FindObjectOfType<CatAnimation>();
        cat = FindObjectOfType<Cat>();
        loadData = FindObjectOfType<LoadData>();

        nameStorage = GameObject.FindWithTag("nameInput");
        petNameLabel = GameObject.FindGameObjectWithTag("nameLabel").GetComponent<Text>();

        if (nameStorage != null)
        {
            petNameLabel.text = nameStorage.GetComponent<KeepNameInputValue>().petName;
        }
        else

            petNameLabel.text = loadData.petName;

        healthSlider = GameObject.FindGameObjectWithTag("healthBar").GetComponent<Slider>();
        cleanlinessSlider = GameObject.FindGameObjectWithTag("cleanlinessBar").GetComponent<Slider>();

        petAgelabel = GameObject.FindGameObjectWithTag("ageLabel").GetComponent<Text>();
        petWeightLabel = GameObject.FindGameObjectWithTag("weightLabel").GetComponent<Text>();
        stateLabel = GameObject.FindGameObjectWithTag("stateLabel").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = loadData.health;
        cleanlinessSlider.value = loadData.cleanliness;
        stateLabel.text = cat.state + "";

        if (loadData.age > 30)
        {
            modulus = loadData.age % 30;
            month = (loadData.age - modulus) / 30;
            if (modulus > 7)
            {
                week = (modulus - (modulus % 7)) / 7;
                day = modulus % 7;
            }
            else
            {
                week = 0;
                day = modulus % 7;
            }
        }
        else
        {
            month = 0;
        }

        petAgelabel.text = month + " M " + week + " W " + day + " D ";
        petWeightLabel.text = loadData.weight + " g";
    }


    public void EatButton()
    {
        loadData.dirtyFoodBox = true;
        tempatMakan.SetActive(false);

        switch (loadData.time.Hour)
        {
            case 6:
                

                if (loadData.breakfast && loadData.totBreakfast < 2)
                {

                    loadData.weight += 10;
                    loadData.totBreakfast += 1;
                    loadData.dontWantBreakfast = false;
                    petAnimation.SetAnimationState(CatAnimation.State.eat);

                }

                else if (!loadData.breakfast)
                {
                    petAnimation.SetAnimationState(CatAnimation.State.eat);
                    loadData.breakfastLevel = 100;
                    loadData.diciplineHungry += 1;
                    loadData.breakfast = true;
                    loadData.totBreakfast += 1;
                }

                else if (loadData.totBreakfast == 2)
                {
                    loadData.dontWantBreakfast = true;
                    petAnimation.SetAnimationState(CatAnimation.State.dontWantEat);

                }
                break;
            case 14:

                if (loadData.lunch && loadData.totLunch < 2)
                {

                    loadData.weight += 10;
                    loadData.totLunch += 1;
                    loadData.dontWantLunch = false;
                    petAnimation.SetAnimationState(CatAnimation.State.eat);

                }

                else if (!loadData.lunch)
                {
                    loadData.lunchLevel = 100;
                    loadData.diciplineHungry += 1;
                    loadData.lunch = true;
                    loadData.totLunch += 1;
                    petAnimation.SetAnimationState(CatAnimation.State.eat);
                }

                else if (loadData.totLunch == 2)
                {
                    loadData.dontWantLunch = true;
                    petAnimation.SetAnimationState(CatAnimation.State.dontWantEat);
                }
                break;
            case 21:

                if (loadData.dinner && loadData.totDinner < 2)
                {
                    loadData.weight += 10;
                    loadData.totDinner += 1;
                    loadData.dontWantDinner = false;
                    petAnimation.SetAnimationState(CatAnimation.State.eat);

                }

                else if (!loadData.dinner)
                {
                    loadData.dinnerLevel = 100;
                    loadData.diciplineHungry += 1;
                    loadData.dinner = true;
                    loadData.totDinner += 1;
                    petAnimation.SetAnimationState(CatAnimation.State.eat);
                }

                else if (loadData.totDinner == 2)
                {
                    loadData.dontWantDinner = true;
                    petAnimation.SetAnimationState(CatAnimation.State.dontWantEat);
                }
                break;
        }


    }

    
    public void Drinking()
    {
        tempatMakan.SetActive(true);
        loadData.giveWater = true;
        petAnimation.SetAnimationState(CatAnimation.State.drink);
    }

    public void ToiletButton()
    {
        litterbox.SetActive(true);
        loadData.alreadyPee1 = true;
        loadData.alreadyPoop = true;
        loadData.dirtyLitterBox = true;
        petAnimation.SetAnimationState(CatAnimation.State.pee);
    }


    public void PatButton()
    {
        loadData.social += 1;
    }

    public void CleanningLitterBox()
    {
        loadData.dirtyLitterBox = false;
    }

    public void CleanningFoodBox()
    {
        loadData.dirtyFoodBox = false;
        tempatMakan.SetActive(false);
    }

    public void CleanningRoom()
    {
        Debug.Log("masuk ga");
        loadData.poopOutStatus = false;
        loadData.peeOutStatus = false;
        shit.SetActive(false);
        splat.SetActive(false);
    }

    public void Comb()
    {
        loadData.hairball = false;
        loadData.comb = true;
    }

    public void Powder()
    {
        loadData.cleanliness += 50;
    }

    public void BathButton()
    {
        loadData.money += 10;
        loadData.cleanliness += 100;
        loadData.social += 1;
        if (loadData.isDirty)
        {
            loadData.diciplineCleanliness += 1;
            petAnimation.SetAnimationState(CatAnimation.State.bath);
        }
        else if (loadData.isVeryDirty)
        {
            loadData.diciplineCleanliness -= 1;
            loadData.isVeryDirty = false;
            petAnimation.SetAnimationState(CatAnimation.State.bath);
        }

        takeAbathDate = DateTime.Today;
    }

    public void MedButton()
    {
        loadData.health += 100;
        loadData.cacingan = false;
        petAnimation.SetAnimationState(CatAnimation.State.med);
    }


    public void GiveAToyButton()
    {
        loadData.playingWithToy = true;
        mainan.SetActive(true);
        if(DateTime.Now.Hour == 7)
        {
            loadData.playInMorning = true;
        }
        else if(DateTime.Now.Hour == 19 || DateTime.Now.Hour == 20)
        {
            loadData.playInNight = true;
        }
    }
    

    public void PlayingWithCat()
    {
        
    }

    public void AwakeButton()
    {
        angryValue += 1;
        petAnimation.SetAnimationState(CatAnimation.State.disturbed);
    }

    public void ResetButton()
    {
        Game.ResetPlayer();
        SceneManager.LoadScene(0);
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
