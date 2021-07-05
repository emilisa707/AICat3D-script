using Firebase;
using Firebase.Analytics;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;

public class FirebaseInit : MonoBehaviour
{
    private string dataURL = "https://ailoadData-fb186.firebaseio.com/";
    private DatabaseReference databaseReference;
    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(continuationAction: task =>
        {
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        });

        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(dataURL);
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
