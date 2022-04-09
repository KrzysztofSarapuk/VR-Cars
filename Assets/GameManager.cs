using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    private float restartTimer = 0f;
    public GameObject helpPanel;
    public Text restartText;
    private Color fullColor, transparentColor;

    void Start () {
        fullColor = restartText.color;
        fullColor.a = 1;
        transparentColor = restartText.color;
        transparentColor.a = 0;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown (KeyCode.H) && !helpPanel.activeSelf) {
            helpPanel.SetActive (true);
            Time.timeScale = 0;
        } else if (Input.GetKey (KeyCode.R)) {
            restartTimer += Time.deltaTime;
            float percent = restartTimer / 1;
            restartText.color = Color.Lerp (transparentColor, fullColor, percent);
        } else {
            restartTimer = 0;
            restartText.color = transparentColor;
        }
        if (restartTimer >= 1) {
            restartTimer = 0;
            SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
        }
    }
}