using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
{
    LoadData loadData;

    public Text diciplineHungerLabel;
    public Text diciplineHappinessLabel;
    public Text diciplineCleanlinessLabel;

    public Text poopOutStatus;
    public Text peeOutStatus;

    public Text cacinganStatus;

    public Text healthlabel;
    public Text happinessInMorningLabel;
    public Text happinessInNightLabel;
    public Text cleanlinessLabel;
    public Text hairball;

    private void Start()
    {
        loadData = FindObjectOfType<LoadData>();
    }
    void Update()
    {
        diciplineHungerLabel.GetComponent<Text>().text = loadData.diciplineHungry + " ";
        diciplineHappinessLabel.GetComponent<Text>().text = loadData.diciplineHappiness + " ";
        diciplineCleanlinessLabel.GetComponent<Text>().text = loadData.diciplineCleanliness + " ";

        poopOutStatus.GetComponent<Text>().text = loadData.poopOutStatus + " ";
        peeOutStatus.GetComponent<Text>().text = loadData.peeOutStatus + " ";

        cacinganStatus.GetComponent<Text>().text = loadData.cacingan + " ";
        healthlabel.GetComponent<Text>().text = loadData.health + " " ;

        happinessInMorningLabel.GetComponent<Text>().text = loadData.happinessInMorningLevel + " ";
        happinessInNightLabel.GetComponent<Text>().text = loadData.happinessInNightLevel + " ";
        cleanlinessLabel.GetComponent<Text>().text = loadData.cleanliness + " ";

    }
}
