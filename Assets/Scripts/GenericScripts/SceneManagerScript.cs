using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    int nextSceneToLoad, loadPreviousScene;

    private void Start()
    {

        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        loadPreviousScene = nextSceneToLoad - 1;
    }



    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneToLoad);
    }

    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(loadPreviousScene);
    }
}