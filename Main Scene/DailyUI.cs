using UnityEngine;
using UnityEngine.UI;

public class DailyUI : MonoBehaviour
{
    LoadData loadData;
    public Text breakfastStatus;
    public Text peeStatus;
    public Text pooStatus;

    public Text playInMorningStatus;

    public Text lunchStatus;
    public Text drinkStatus;

    public Text pee2Status;
    public Text playInNightStatus;
    public Text dinnerStatus;

    private void Start()
    {
        loadData = FindObjectOfType<LoadData>();
    }

    void Update()
    {
        breakfastStatus.GetComponent<Text>().text = loadData.breakfast + " ";
        peeStatus.GetComponent<Text>().text = loadData.alreadyPee1 + " ";

        pooStatus.GetComponent<Text>().text = loadData.alreadyPoop + " ";
        playInMorningStatus.GetComponent<Text>().text = loadData.playInMorning + " ";

        lunchStatus.GetComponent<Text>().text = loadData.lunch + " ";
        drinkStatus.GetComponent<Text>().text = loadData.giveWater + " ";

        pee2Status.GetComponent<Text>().text = loadData.alreadyPee2 + " " ;
        playInNightStatus.GetComponent<Text>().text = loadData.playInNight + "";
        dinnerStatus.GetComponent<Text>().text = loadData.dinner + " " ;
    }
}
