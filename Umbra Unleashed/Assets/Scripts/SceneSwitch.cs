using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//************** use UnityOSC namespace...
using UnityOSC;
//****************************************************************

public class SceneSwitch : MonoBehaviour
{
    public int scene;
    private PlayerStats ScriptReference;

    private void Start()
    {
        ScriptReference = GetComponent<PlayerStats>();
        //************* Instantiate the OSC Handler...
	    OSCHandler.Instance.Init ();
        //****************************************
    }
    
    void OnTriggerEnter(Collider other)
    {
        //************* Send OSC message to PD...
        OSCHandler.Instance.SendMessageToClient("pd", "/unity/tempo", 170);
        //****************************************
        SceneManager.LoadScene(scene);
        if(other.tag == "Player")
        {
            ScriptReference.SetMaxHealth();
        }
    }
}
