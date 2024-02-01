using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Steamworks;

public class PlayfabManager : MonoBehaviour
{
    private string username;
    private string password;
    public ItemV2[] Items;
    public static PlayfabManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("instance error playfabmanager");
            return;
        }
        instance = this;
    }
    void Start()
    {
        username = PlayerPrefs.GetString("USERNAME");
        password = PlayerPrefs.GetString("PASSWORD");
        if (!SteamManager.Initialized)
        {
            return;

        }
        Login();

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Login()
    {
        string id = SteamUser.GetSteamID().ToString();
        Debug.Log(id);

        string user = "user" + Random.Range(0,4000);
        string pswd = "pswd" + Random.Range(0, 4000);
        RegisterPlayFabUserRequest request = new RegisterPlayFabUserRequest();
        request.Username = user;
        request.Password = pswd;
        request.Email = "test@test.com";

     

        if (username == string.Empty && password == string.Empty)
        {
            PlayFabClientAPI.RegisterPlayFabUser(request, result => {
                PlayerPrefs.SetString("USERNAME", user);
                PlayerPrefs.SetString("PASSWORD", pswd);
                PlayerPrefs.Save();

                Debug.Log("User Account Created");
            }, error => { Debug.Log(error.ErrorMessage); });
        }
        else
        {
            LoginWithPlayFabRequest loginRequest = new LoginWithPlayFabRequest();

            loginRequest.Username = username;
            loginRequest.Password = password;
            PlayFabClientAPI.LoginWithPlayFab(loginRequest, result => {
                Debug.Log("Logged in!");


            }, error => { Debug.Log(error.ErrorMessage); });
        }



    }


  
}