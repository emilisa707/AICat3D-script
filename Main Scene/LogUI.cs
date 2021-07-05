using UnityEngine;
using UnityEngine.UI;

public class LogUI : MonoBehaviour
{
    LoadData loadData;

    public Text breakfastParameterTimer;
    public Text poopParameterTimer;
    public Text pee1ParameterTimer;
    public Text pee2ParameterTimer;
    public Text lunchParameterTimer;
    public Text thristyParameterTimer;
    public Text dinnerParameterTimer;
    public Text healthParameterTimer;
    public Text happinessInMorningParameterTimer;
    public Text happinessInNightParameterTimer;
    public Text cleanlinessParameterTimer;
    public Text date;

    private void Start()
    {
        loadData = FindObjectOfType<LoadData>();
    }
    void Update()
    {

            breakfastParameterTimer.GetComponent<Text>().text = loadData.breakfastParameterTimer + " ";
            poopParameterTimer.GetComponent<Text>().text = loadData.poopParameterTimer + " ";
            pee1ParameterTimer.GetComponent<Text>().text = loadData.pee1ParameterTimer + " ";
            pee2ParameterTimer.GetComponent<Text>().text = loadData.pee2ParameterTimer + " ";
            lunchParameterTimer.GetComponent<Text>().text = loadData.lunchParameterTimer + " ";

            thristyParameterTimer.GetComponent<Text>().text = loadData.thristyParameterTimer + " ";
            dinnerParameterTimer.GetComponent<Text>().text = loadData.dinnerParameterTimer + " ";

            healthParameterTimer.GetComponent<Text>().text = loadData.healthParameterTimer + " ";
            happinessInMorningParameterTimer.GetComponent<Text>().text = loadData.happinessInMorningParameterTimer + " ";
            happinessInNightParameterTimer.GetComponent<Text>().text = loadData.happinessInNightParameterTimer + " ";

            cleanlinessParameterTimer.GetComponent<Text>().text = loadData.cleanlinessParameterTimer + " ";
            date.GetComponent<Text>().text = loadData.date + "";
    }
}