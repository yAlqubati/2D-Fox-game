using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadNextScene()
    {
        int CurrentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

        if(CurrentSceneIndex == UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings-1)
        {
            // print ("Quit")
            Debug.Log("Quit");
            Application.Quit();
        }
            

        else
        UnityEngine.SceneManagement.SceneManager.LoadScene(CurrentSceneIndex+1);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            LoadNextScene();
        }
    }
}
