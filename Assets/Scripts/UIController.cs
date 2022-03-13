using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject TopPlayScreen;
    [SerializeField] GameObject LevelEndScreen;
    [SerializeField] GameObject CurrentLevelCanvas;

    //[SerializeField] TextMeshProUGUI Gold;
    [SerializeField] TextMeshProUGUI StackAmount;

    [SerializeField] Text UpdateGold;
    [SerializeField] Text UpdateDiamond;
    [SerializeField] Text CurrentLevelText;
    [SerializeField] Text NextLevelText;


   
  


    bool hasUpgrade;


  


    void Start()
    {
       
       
         StackAmount.text =GameInfo.StartStackAmount.ToString();
        CurrentLevelText.text = (GameInfo.CurrentLevelNumber).ToString();
        NextLevelText.text=(GameInfo.CurrentLevelNumber+1).ToString();
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Finish")
        {
            CurrentLevelCanvas.SetActive(false);
            UpdateDiamond.text = GameInfo.CurrentDiamondAmount.ToString();
            UpdateGold.text = GameInfo.CurrentGoldAmount.ToString();
            LevelEndScreen.SetActive(true);
        }
    }
    public void UpgradeButton()
    {
        if (!hasUpgrade)
        {
           
            GameInfo.StartStackAmount += GameInfo.CurrentDiamondAmount+GameInfo.CurrentGoldAmount;
            
            GameInfo.CurrentDiamondAmount = 0;
            GameInfo.CurrentGoldAmount = 0;
            UpdateDiamond.text = 0.ToString();
            UpdateGold.text = 0.ToString();
            StackAmount.text = GameInfo.StartStackAmount.ToString();
            GetComponent<PlayerController>().SaveGameData();
            
            hasUpgrade = true;

        }
    }

    public void NextLevelButton()
    {
        GameInfo.CurrentLevelNumber++;
        if (GameInfo.Current_LevelNumber == 5) GameInfo.Current_LevelNumber = 0;

        GameInfo.Current_LevelNumber++;
        Application.LoadLevel(GameInfo.Current_LevelNumber);
    }

    public void TopPlayButton()
    {
        Time.timeScale = 1;
        TopPlayScreen.SetActive(false);
    }
}
