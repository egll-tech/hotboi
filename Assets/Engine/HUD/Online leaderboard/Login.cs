﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Login : MonoBehaviour {
    public UserData userdata;
    public DataLoader dataloader;
    string LoginURL = "https://localhost/sweetboi/Login.php";

    public void LogIn() {
        StartCoroutine(LoginToDB(userdata.GetUsername(), userdata.password));
    }
    public void LogOut() {
        userdata.ResetLocalUserData(); //log out and reset data
    }
    
    IEnumerator LoginToDB(string username, string password) {
        WWWForm form = new WWWForm();
        print("user: " + username + " pass " + password);
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);
        WWW www = new WWW(LoginURL, form); 
        yield return www;
        string result = www.text;
        if (result.ToLower().Trim() == "success".ToLower()) {
            userdata.SetUsername(username);
            Debug.Log("Login success ");
            userdata.isLoggedIn = true;
            dataloader.LoadData();
        } else {
            Debug.Log("Could not log in ");
        }
    }
}
