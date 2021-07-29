using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MainMenuManager : MonoBehaviour
{
    public DataTransfer dataTransfer; //gObject to pass the info between scenes
    public string playerName;
    public GameObject playerNameInputField;
    public TMP_Text textDisplayed;
    //you do not need to reffer a button in GameObject variable for it to make some incode function;

    private void Start()
    {
        dataTransfer = GameObject.Find("DataTransfer").GetComponent<DataTransfer>();
    }
    public void StorePlayerName()
    {
        dataTransfer.playerName = playerNameInputField.GetComponent<Text>().text;
        //refering to TextMeshPro objects is different than generic objects.
        //myTextObject.GetComponent<Text>().text    and  reference to TMPro text object will be like this   myTextObject.GetComponent<TMPro.TextMeshProUGUI>().text
        //if you are about to use TMPro objects - try adding "USING TMPro" and things will get better.
        if (playerNameInputField.GetComponent<Text>().text == "") //checks if the input field is empty
        {
            dataTransfer.playerName = "%username";
        }
        textDisplayed.text = "Welcome, " + dataTransfer.playerName + ". Press START to begin.";
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
         EditorApplication.ExitPlaymode();

#else 
         Application.Quit();

#endif
    }

}
