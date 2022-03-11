using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject TopPlayScreen;
    [SerializeField] GameObject LevelEndScreen;
   
    [SerializeField] TextMeshProUGUI Gold;
    [SerializeField] TextMeshProUGUI Diamond;

    [SerializeField] Text UpdateGold;
    [SerializeField] Text UpdateDiamond;

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
     

    }


    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Finish")
        {
           
            UpdateGold.text = GameInfo.CurrentDiamondAmount.ToString();
            UpdateDiamond.text = GameInfo.CurrentGoldAmount.ToString();
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
             Gold.text  = GameInfo.GoldAmount.ToString();
            Diamond.text = GameInfo.DiamondAmount.ToString();
            hasUpgrade = true;

        }
       

    }
    public void TopPlayButton()
    {
        Time.timeScale = 1;
        TopPlayScreen.SetActive(false);
    }
}
