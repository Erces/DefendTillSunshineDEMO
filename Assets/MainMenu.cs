using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.HighDefinition;
using Cinemachine;
public class MainMenu : MonoBehaviour
{
    public Button newgameButton;
    public GameObject Settings, G_Settings, loadingScreen,changeColortext;
    public CinemachineVirtualCamera camera;
    public Slider slider;

    void Start()
    {
        int a = PlayerPrefs.GetInt("tutorial");
        Screen.lockCursor = false;
    }
    
    // Update is called once per frame
    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void StartDemo(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }
    IEnumerator LoadAsynchronously ( int sceneIndex)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        yield return new WaitForSecondsRealtime(5);


        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            yield return null;
        }
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("tutorial") == 1)
        {
            newgameButton.interactable = true;
        }
        else
        {
            newgameButton.interactable = true;
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ToggleSettings()
    {
        Settings.SetActive(!Settings.activeSelf);
        changeColortext.SetActive(!changeColortext.activeSelf);
        if (camera.Priority == 15)
        {
            camera.Priority = 1;
        }
        else if (camera.Priority == 1)
        {
            camera.Priority = 15;
        }

    }
   
    public void ToggleGraphicSettings()
    {
        G_Settings.SetActive(!G_Settings.activeSelf);
    }
    public void Low()
    {
        QualitySettings.SetQualityLevel(0);
        PlayerPrefs.SetInt("PP", 0);
    }
    public void Medium()
    {
        QualitySettings.SetQualityLevel(1);
        PlayerPrefs.SetInt("PP", 1);
    }
    public void High()
    {
       
        QualitySettings.SetQualityLevel(2);
        PlayerPrefs.SetInt("PP", 2);
    }
    public void Ultra()
    {
        QualitySettings.SetQualityLevel(3);
        PlayerPrefs.SetInt("PP", 3);
    }
}
