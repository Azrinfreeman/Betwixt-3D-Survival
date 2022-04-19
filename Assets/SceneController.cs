using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSceneToLevel2()
    {
        StartCoroutine(LoadLevel2());
    }
    IEnumerator LoadLevel2()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level2");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
