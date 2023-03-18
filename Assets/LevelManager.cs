using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static bool isPersist = true;
    private static LevelManager instance = null;
    public static LevelManager Instance
    {
        //getter
        get
        {
            //Make sure that we only have one instance of this in the game
            if (instance == null) // We don't have any instance yet
            {
                // NOTE: We can have multiple attempts in making our new instance
                // 1. We can try to find an existing game object in the scene that has the component
                // 2. We can try loading an existing prefab in our assets and set that as the instance
                // 3. Create a new gameobject and attach the script and set it as the instance

                // Attempt to find an existing game object in the scene that has the component
                instance = FindObjectOfType<LevelManager>();
                // If we still didn't find an instance, let's just create our own instance
                if (instance == null)
                {
                    //Generate our own instance by creating a new gameobject
                    GameObject go = new GameObject();
                    //Add the component and set it as the instance
                    instance = go.AddComponent<LevelManager>();
                    go.name = "LevelManager";
                    //Make sure the object persists
                    // Make sure that this gameobject will persist in between scenes
                    if (isPersist) DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }
   
    // We still need to assign the instance here in our own gameobject
    private void Awake()
    {
        //Is there any instance yet?
        if(instance == null)
        {
            instance = this;
            if (isPersist) DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //If there is already an existing, 
            Destroy(this.gameObject);
        }
    }

    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadLevel(string sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}
