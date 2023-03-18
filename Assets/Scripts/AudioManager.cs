using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Apply a singleton pattern
    #region SingletonImplementation
    public static bool isPersist = true;
    private static AudioManager instance = null;
    public static AudioManager Instance
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
                instance = FindObjectOfType<AudioManager>();
                // If we still didn't find an instance, let's just create our own instance
                if (instance == null)
                {
                    //Generate our own instance by creating a new gameobject
                    GameObject go = new GameObject();
                    //Add the component and set it as the instance
                    instance = go.AddComponent<AudioManager>();
                    go.name = "AudioManager";
                    //Make sure the object persists
                    // Make sure that this gameobject will persist in between scenes
                    if (isPersist) DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }
    #endregion

    private void Awake()
    {
        //Is there any instance yet?
        if (instance == null)
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

    public void PlayAudio(string clipName)
    {
        // Generate a gameobject with an AudioController component
        GameObject go = new GameObject();
        var audio = go.AddComponent<AudioController>();
        // Call the load clip
        audio.LoadClip(clipName);
    }
}
