using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Gamemaster : MonoBehaviour
{
    public int points = 0;
    public int highscore = 0;

    public Text pointtext;
    public Text Hightext;
    public Text Inputtext;

    // Use this for initialization
    void Start()
    {
       //PlayerPrefs.DeleteAll();// xóa bộ nhớ đệm điểm cao
        Hightext.text = ("HighScore: " + PlayerPrefs.GetInt("highscore"));
        highscore = PlayerPrefs.GetInt("highscore", 0);
        // gán highscore lại bằng 0
        //PlayerPrefs.SetInt("highscore", 0);
        //highscore = 0;
        if (PlayerPrefs.HasKey("points"))
        {
            Scene ActiveScreen = SceneManager.GetActiveScene();
            if (ActiveScreen.buildIndex == 1) //level 1 sẽ reset lại điểm
            {
                PlayerPrefs.DeleteKey("points");            
                points = 0;              

            }
            else
                points = PlayerPrefs.GetInt("points");//lưu giá trị điểm qua màn sau
        }
    }

    // Update is called once per frame
    void Update()
    {
        pointtext.text = ("Score: " + points);
    }
}
