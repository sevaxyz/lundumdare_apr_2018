using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayExitOnClick : MonoBehaviour {

    public void onPlayClicked()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void onExitClicked()
    {
        Application.Quit();
    }
}
