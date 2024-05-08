using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   [Range(10f, 60f)]
   [SerializeField] private float maxTime;
   [SerializeField] private TMP_Text countText;
   [SerializeField] private Image timeBar;

  

    void Update()
    {
       if (maxTime > 0)
       {
        maxTime -= Time.deltaTime;
       }
       else if (maxTime < 0)
       {
        maxTime = 0;
       }

       if (maxTime <= 0)
       {
         LoseLevel();
       }

       int minutes = Mathf.FloorToInt(maxTime / 60);
       int seconds = Mathf.FloorToInt(maxTime % 60);
       countText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


    public void WinLevel()
    {
        SceneManager.LoadScene("WinScene");
    }

    public void LoseLevel()
    {
        SceneManager.LoadScene("LoseScene");
    }   
}
