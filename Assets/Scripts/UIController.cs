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

    [SerializeField] TextMeshProUGUI Gold;
    [SerializeField] TextMeshProUGUI Diamond;

    [SerializeField] Text UpdateGold;
    [SerializeField] Text UpdateDiamond;
    [SerializeField] Text CurrentLevelText;
    [SerializeField] Text NextLevelText;


    string goldtxt;
    string diamondtxt;
    string diamondAmoutTxt;
    string goldAmoutTxt;


    bool hasUpgrade;


    void Start()
    {
        //diamondtxt = Diamond.GetComponentsInChildren<TextMeshProUGUI>()[0].text;
        //goldtxt = Gold.GetComponentsInChildren<TextMeshProUGUI>()[0].text;
        diamondAmoutTxt = LevelEndScreen.GetComponentsInChildren<Text>()[0].text;
        goldAmoutTxt = LevelEndScreen.GetComponentsInChildren<Text>()[1].text;
        CurrentLevelText.text = (GameInfo.CurrentLevelNumber).ToString();
        NextLevelText.text=(GameInfo.CurrentLevelNumber+1).ToString();
    }


    void Update()
    {

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
            Debug.Log("upgrade");
            GameInfo.DiamondAmount += GameInfo.CurrentDiamondAmount;
            GameInfo.GoldAmount += GameInfo.CurrentGoldAmount;
            GameInfo.CurrentDiamondAmount = 0;
            GameInfo.CurrentGoldAmount = 0;
            UpdateDiamond.text = 0.ToString();
            UpdateGold.text = 0.ToString();
            Gold.text = GameInfo.GoldAmount.ToString();
            Diamond.text = GameInfo.DiamondAmount.ToString();
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
