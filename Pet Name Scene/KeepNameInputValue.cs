using UnityEngine;

public class KeepNameInputValue : MonoBehaviour
{
    private static KeepNameInputValue playerInstance;

    public string petName = "";

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
