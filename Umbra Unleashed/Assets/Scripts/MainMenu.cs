using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//************** use UnityOSC namespace...
using UnityOSC;
//****************************************************************

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditsMenu;

    public int sceneIndex;

    private void Start() {
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);

        //************* Instantiate the OSC Handler...
	    OSCHandler.Instance.Init ();
		OSCHandler.Instance.SendMessageToClient ("pd", "/unity/trigger", "ready");
		OSCHandler.Instance.SendMessageToClient ("pd", "/unity/gamestart", 1);
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/playseq", 1);
        //****************************************
    }

    public void ShowMain() {
        mainMenu.SetActive(true);
    }

    public void StartGame() {
        //************* Send OSC message to PD...
            OSCHandler.Instance.SendMessageToClient("pd", "/unity/buttonClicked", 1);
        //****************************************
        SceneManager.LoadScene(sceneIndex);
    }

    public void HideMain() {
        mainMenu.SetActive(false);
    }

    public void ShowCredits() {
        //************* Send OSC message to PD...
           OSCHandler.Instance.SendMessageToClient("pd", "/unity/buttonClicked", 1);
        //****************************************
        creditsMenu.SetActive(true);
    }

    public void HideCredits() {
        //************* Send OSC message to PD...
           OSCHandler.Instance.SendMessageToClient("pd", "/unity/buttonClicked", 1);
        //****************************************
        creditsMenu.SetActive(false);
    }

   public void QuitGame()
    {
        Debug.Log("quitting application");
        //************* Send OSC message to PD...
           OSCHandler.Instance.SendMessageToClient("pd", "/unity/buttonClicked", 1);
        //****************************************
        Application.Quit();
    }
}
