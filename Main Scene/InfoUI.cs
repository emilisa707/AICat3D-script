using UnityEngine;
using UnityEngine.UI;

public class InfoUI : MonoBehaviour
{
    LoadData loadData;

    public Text totBreakfast;
    //    public Text poopParameterTimer;
    //    public Text pee1ParameterTimer;
    //    public Text pee2ParameterTimer;
    public Text totLunch;
    //public Text thristyParameterTimer;
    public Text totDinner;
    //public Text healthParameterTimer;
    //public Text happinessInMorningParameterTimer;
    //public Text happinessInNightParameterTimer;
    //public Text cleanlinessParameterTimer;
    //public Text date;

    private void Start()
    {
        loadData = FindObjectOfType<LoadData>();
    }
    void Update()
    {

        totBreakfast.GetComponent<Text>().text = loadData.totBreakfast + " ";
        //poopParameterTimer.GetComponent<Text>().text = loadData.poopParameterTimer + " ";
        //pee1ParameterTimer.GetComponent<Text>().text = loadData.pee1ParameterTimer + " ";
        //pee2ParameterTimer.GetComponent<Text>().text = loadData.pee2ParameterTimer + " ";
        totLunch.GetComponent<Text>().text = loadData.totLunch + " ";

        //thristyParameterTimer.GetComponent<Text>().text = loadData.thristyParameterTimer + " ";
        totDinner.GetComponent<Text>().text = loadData.totDinner + " ";

        //healthParameterTimer.GetComponent<Text>().text = loadData.healthParameterTimer + " ";
        //happinessInMorningParameterTimer.GetComponent<Text>().text = loadData.happinessInMorningParameterTimer + " ";
        ////happinessInNightParameterTimer.GetComponent<Text>().text = loadData.happinessInNightParameterTimer + " ";

        //cleanlinessParameterTimer.GetComponent<Text>().text = loadData.cleanlinessParameterTimer + " ";
        //date.GetComponent<Text>().text = loadData.date + "";
    }
}