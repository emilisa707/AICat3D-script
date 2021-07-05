using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class StartMenuManager : MonoBehaviour {

    public GameObject flashText;
    string path;

	void Start () {
        path = Application.persistentDataPath + "/saveFile.dat";
        InvokeRepeating("flashTheText", 0f, 0.5f);
   	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonUp(0))
        {
            if (File.Exists(path))
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                SceneManager.LoadScene(1);
            }
        }
	}

    void flashTheText()
    {
        if (flashText.activeInHierarchy)
            flashText.SetActive(false);
        else
            flashText.SetActive(true);
    }
}
