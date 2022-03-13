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

    [SerializeField] TextMeshProUGUI StackAmount;

    [SerializeField] Text UpdateGold;
    [SerializeField] Text UpdateDiamond;
    [SerializeField] Text CurrentLevelText;
    [SerializeField] Text NextLevelText;

    bool hasUpgrade;
   

    void Start()
    {

        if (GameInfo.StartStackAmount==0)LoadGameData();
        else
        {
            StackAmount.text = GameInfo.StartStackAmount.ToString();
            CurrentLevelText.text = (GameInfo.CurrentLevelNumber).ToString();
            NextLevelText.text = (GameInfo.CurrentLevelNumber + 1).ToString();
        }
        
    }

    private void OnApplicationQuit()
    {
        SaveGameData();
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

    private IEnumerator IncreaseStack()
    {
        float elapsedTime = 0f;
        float timeIncrement = 0.05f;
        float totalStack=GameInfo.CurrentDiamondAmount + GameInfo.CurrentGoldAmount;

        while (elapsedTime < totalStack)
        {
            yield return new WaitForSeconds(timeIncrement);

            GameInfo.StartStackAmount++;
          
            StackAmount.text = GameInfo.StartStackAmount.ToString();
              totalStack--;
        }
    }


    public void UpgradeButton()
    {
        if (!hasUpgrade)
        {
            PlayerPrefs.SetInt("StackAmount", GameInfo.StartStackAmount);
            StackAmount.text = PlayerPrefs.GetInt("StackAmount", 0).ToString();
            Debug.Log(PlayerPrefs.GetInt("StackAmount", 0));
            GetComponent<AudioSource>().Play();
            StartCoroutine(IncreaseStack());
            GameInfo.CurrentDiamondAmount = 0;
            GameInfo.CurrentGoldAmount = 0;
            UpdateDiamond.text = 0.ToString();
            UpdateGold.text = 0.ToString();

            hasUpgrade = true;

        }
    }

    public void NextLevelButton()
    {
        if (GameInfo.Current_LevelNumber == 4) GameInfo.Current_LevelNumber = -1;

        GameInfo.Current_LevelNumber++;
        GameInfo.CurrentLevelNumber++;
        SceneManager.LoadSceneAsync(GameInfo.Current_LevelNumber);

    }

    public void TopPlayButton()
    {
        Time.timeScale = 1;
        TopPlayScreen.SetActive(false);
    }
    public void SaveGameData()
    {
        
        PlayerPrefs.SetInt("CurrentLevel", GameInfo.CurrentLevelNumber + 1);
        PlayerPrefs.SetInt("StackAmount", GameInfo.StartStackAmount);
        PlayerPrefs.SetInt("CurrentGoldUpgrade", GameInfo.CurrentGoldAmount);
        PlayerPrefs.SetInt("CurrentDiamondUpgrade", GameInfo.CurrentDiamondAmount);
    }

    public void LoadGameData()
    {
        GameInfo.CurrentLevelNumber = PlayerPrefs.GetInt("CurrentLevel", 1);
        GameInfo.StartStackAmount = PlayerPrefs.GetInt("StackAmount", 0);
        GameInfo.CurrentGoldAmount = PlayerPrefs.GetInt("CurrentGoldAmount", 0);
        GameInfo.CurrentDiamondAmount = PlayerPrefs.GetInt("CurrentDiamondAmount", 0);
    }
}
