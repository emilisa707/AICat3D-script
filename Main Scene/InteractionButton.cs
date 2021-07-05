using UnityEngine;
using UnityEngine.UI;

public class InteractionButton : MonoBehaviour
{
    LoadData loadData;
    Cat cat;

    public Button interactionButton;
    public Button treathmentButton;
    public Button cleanningButton;

    public Button eatButton;
    public Button playButton;
    public Button waterButton;
    public Button litterBoxButton;
    public Button patButton;

    public Button cleanningLitterBoxButton;
    public Button cleanningFoodBoxButton;
    public Button cleanningRoomButton;

    public Button combButton;
    public Button powderButton;
    public Button BathButton;
    public Button giveMedButton;

    public Button giveAToyButton;
    public Button playingWithCatButton;



    // Start is called before the first frame update
    void Awake()
    {
        loadData = FindObjectOfType<LoadData>();
        cat = FindObjectOfType<Cat>(); 
    }

    // Update is called once per frame
    void Update()   
    {
        if(cat.state == Cat.State.isBreakfast || cat.state == Cat.State.isLunch || cat.state == Cat.State.isDinner || cat.state == Cat.State.isLicking) {
            eatButton.enabled = true;
            eatButton.GetComponent<Image>().color = Color.white;
        } else {
            eatButton.enabled = false;
            eatButton.GetComponent<Image>().color = Color.grey;
        }


        if(cat.state == Cat.State.isSleep) {
            interactionButton.enabled = false;
            interactionButton.GetComponent<Image>().color = Color.grey;
        } else {
            interactionButton.enabled = true;
            interactionButton.GetComponent<Image>().color = Color.white;
        }


        if(cat.state == Cat.State.isThristy) {
            waterButton.enabled = true;
            waterButton.GetComponent<Image>().color = Color.white;
        } else {
            waterButton.enabled = false;
            waterButton.GetComponent<Image>().color = Color.grey;
        }


        if (cat.state == Cat.State.isPee1 || cat.state == Cat.State.isPee2 || cat.state == Cat.State.isPoop) {
            litterBoxButton.enabled = true;
            litterBoxButton.GetComponent<Image>().color = Color.white;
        } else {
            litterBoxButton.enabled = false;
            litterBoxButton.GetComponent<Image>().color = Color.gray;
        }


        if (loadData.dirtyFoodBox) {
            cleanningFoodBoxButton.enabled = true;
            cleanningFoodBoxButton.GetComponent<Image>().color = Color.white;
        } else {
            cleanningFoodBoxButton.enabled = false;
            cleanningFoodBoxButton.GetComponent<Image>().color = Color.grey;
        }


        if (loadData.dirtyLitterBox) {
            cleanningLitterBoxButton.enabled = true;
            cleanningLitterBoxButton.GetComponent<Image>().color = Color.white;
        } else {
            cleanningLitterBoxButton.enabled = false;
            cleanningLitterBoxButton.GetComponent<Image>().color = Color.gray;
        }


        if (loadData.poopOutStatus || loadData.peeOutStatus) {
            cleanningRoomButton.enabled = true;
            cleanningRoomButton.GetComponent<Image>().color = Color.white;
        } else {
            cleanningRoomButton.enabled = false;
            cleanningRoomButton.GetComponent<Image>().color = Color.gray;
        }


        if (loadData.isDirty || loadData.isVeryDirty)
        {
            powderButton.enabled = true;
            powderButton.GetComponent<Image>().color = Color.white;
        } else {
            powderButton.enabled = false;
            powderButton.GetComponent<Image>().color = Color.gray;
        }


        if (loadData.isVeryDirty) {
            BathButton.enabled = true;
            BathButton.GetComponent<Image>().color = Color.white;
        } else {
            BathButton.enabled = false;
            BathButton.GetComponent<Image>().color = Color.grey;
        }

        
        if (loadData.cacingan && cat.state != Cat.State.isSleep)
        {
            giveMedButton.enabled = true;
            giveMedButton.GetComponent<Image>().color = Color.white;
        } else {
            giveMedButton.enabled = false;
            giveMedButton.GetComponent<Image>().color = Color.gray;
        }


        if ((cat.state == Cat.State.isPlayInMorning || cat.state == Cat.State.isPlayInNight) && !loadData.playingWithToy)
        {
            playButton.enabled = true;
            playButton.GetComponent<Image>().color = Color.white;
        } else{
            playButton.enabled = false;
            playButton.GetComponent<Image>().color = Color.grey;
        }

        if(!cleanningFoodBoxButton.enabled && !cleanningLitterBoxButton.enabled && !cleanningRoomButton.enabled)
        {
            cleanningButton.enabled = false;
            cleanningButton.GetComponent<Image>().color = Color.grey;
        } else {
            cleanningButton.enabled = true;
            cleanningButton.GetComponent<Image>().color = Color.white;
        }

        if(loadData.patTotal > 4)
        {
            patButton.enabled = false;
            patButton.GetComponent<Image>().color = Color.grey;
        } else
        {
            patButton.enabled = true;
            patButton.GetComponent<Image>().color = Color.white;

        }
    }

}
