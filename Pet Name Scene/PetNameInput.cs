using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PetNameInput : MonoBehaviour
{
    public GameObject petNameField;
    string petName;

    public void SubmitButtonAction()
    {
        if(petName != "")
        {
            petName = petNameField.GetComponent<InputField>().text;
            GameObject.FindGameObjectWithTag("nameInput").GetComponent<KeepNameInputValue>().petName = petName;
            SceneManager.LoadScene(2);
        }
    }
}
