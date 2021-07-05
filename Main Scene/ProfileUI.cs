using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileUI : MonoBehaviour
{
    LoadData loadData;
    Cat cat;

    public Text nameProfile;
    public Text ageProfile;
    public Text weightProfile;

    public Text diciplineHungryProfile;
    public Text diciplineCleanlinessProfile;
    public Text diciplineHappinessProfile;
    public Text socialProfile;

    int diciplineHungry;
    int diciplineCleanliness;
    int diciplineHappiness;
    int social;
    int dayOnline;
    Text stateLabel;
    // Start is called before the first frame update
    void Start()
    {
        loadData = FindObjectOfType<LoadData>();
        cat = FindObjectOfType<Cat>();
        dayOnline = loadData.age - 60;
        stateLabel = GameObject.FindGameObjectWithTag("stateLabel").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cat.state == State.isBreakfast)
        {
            stateLabel.text = "The cat want to eat breakfast";
        }
        else if(cat.state == State.isDinner)
        {
            stateLabel.text = "The cat want to eat dinner";
        }
        else if (cat.state == State.isLicking)
        {
            stateLabel.text = "The cat is licking";
        }
        else if (cat.state == State.isLunch)
        {
            stateLabel.text = "The cat want to eat lunch";
        }
        else if (cat.state == State.isObserving)
        {
            stateLabel.text = "The cat is observing";
        }
        else if (cat.state == State.isPee1 || cat.state == State.isPee2)
        {
            stateLabel.text = "The cat want to pee";
        }
        else if (cat.state == State.isPlayInMorning || cat.state == State.isPlayInNight)
        {
            stateLabel.text = "The cat want to play";
        }
        else if (cat.state == State.isPoop)
        {
            stateLabel.text = "The cat want to poop";
        }
        else if (cat.state == State.isSick)
        {
            stateLabel.text = "The cat is sick";
        }
        else if (cat.state == State.isSleep)
        {
            stateLabel.text = "The cat is sleeping";
        }
        else if (cat.state == State.isThristy)
        {
            stateLabel.text = "The cat want to drink";
        }
        else if (cat.state == State.isDied)
        {
            stateLabel.text = "The cat is died";
        }

        if (dayOnline != 0)
        {
            if (loadData.diciplineHungry / dayOnline < 2)
            {
                diciplineHungryProfile.GetComponent<Text>().text = "Disobedient";
            }
            else
            {
                diciplineHungryProfile.GetComponent<Text>().text = "Obedient";
            }

            if (loadData.diciplineCleanliness / dayOnline < 2)
            {
                diciplineCleanlinessProfile.GetComponent<Text>().text = "dirty";
            }
            else
            {
                diciplineCleanlinessProfile.GetComponent<Text>().text = "like cleanliness";
            }

            if (loadData.diciplineHappiness / dayOnline < 1)
            {
                diciplineHappinessProfile.GetComponent<Text>().text = "stress";
            }
            else
            {
                diciplineHappinessProfile.GetComponent<Text>().text = "friendly";
            }
            if (loadData.social / dayOnline < 15)
            {
                socialProfile.GetComponent<Text>().text = "antisocial";
            }
            else
            {
                socialProfile.GetComponent<Text>().text = "love to be social";
            }


        }
        else
        {
            diciplineHungryProfile.GetComponent<Text>().text = "";
            diciplineCleanlinessProfile.GetComponent<Text>().text = "";
            diciplineHappinessProfile.GetComponent<Text>().text = "";
            socialProfile.GetComponent<Text>().text = "";
        }
        nameProfile.GetComponent<Text>().text = loadData.petName + "";
        ageProfile.GetComponent<Text>().text = loadData.age + "";
        weightProfile.GetComponent<Text>().text = loadData.weight + "" ;

        
    }
}
