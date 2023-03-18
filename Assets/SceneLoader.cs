using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public int sceneToLoad;
    
    public void LoadScene()
    {
        //Call the LevelManager to load the scene that we want
        LevelManager.Instance.LoadLevel(sceneToLoad);
    }
}
