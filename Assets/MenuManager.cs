using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public GameObject helpPanel;

    public void closeHelpPanel () {
        helpPanel.SetActive (false);
        Time.timeScale = 1;
    }

    private void Update () {
        if (Input.GetKeyDown (KeyCode.Escape) && helpPanel.activeSelf) {
            closeHelpPanel ();
        }
    }
}