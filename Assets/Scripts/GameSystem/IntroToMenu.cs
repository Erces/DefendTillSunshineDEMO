using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class IntroToMenu : MonoBehaviour
{
    public PlayableDirector director;
    public Slider slider;
    public GameObject ui;
    public int sceneCount;
    
    void OnEnable()
    {
        director.stopped += OnPlayableDirectorStopped;
    }
    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (director == aDirector)
        {
            Debug.Log("STOPPED");
            StartDemo(sceneCount);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Obsolete]
    public void StartDemo(int sceneIndex)
    {
        Screen.lockCursor = false;
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }
    IEnumerator LoadAsynchronously(int sceneIndex)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        slider.gameObject.SetActive(true);
        ui.SetActive(true);
        yield return new WaitForSecondsRealtime(5);


        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            yield return null;
        }
    }
}
