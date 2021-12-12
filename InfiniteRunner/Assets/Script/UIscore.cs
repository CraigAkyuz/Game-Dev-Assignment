using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIscore : MonoBehaviour
{
    public GameObject PlayerController;
    public Text scoreText;
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + GetComponent<PlayerController>().returnScore();
    }
    public void restartLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
