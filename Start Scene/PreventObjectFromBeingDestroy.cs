using UnityEngine;

public class PreventObjectFromBeingDestroy : MonoBehaviour {

    private static PreventObjectFromBeingDestroy playerInstance;

	void Awake () {
        DontDestroyOnLoad(gameObject);
        if (playerInstance == null)
        {
            playerInstance = this;
        }else
        {
            Destroy(gameObject);
        }
	}
	
}
