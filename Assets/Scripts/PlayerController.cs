using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject Currency;
    [SerializeField] ParticleSystem Gold;
    [SerializeField] ParticleSystem Diamond;
    [SerializeField] Slider LevelBar;
    [SerializeField] Text CurrentLeveltxt;
    [SerializeField] Text NextLevel;
    [SerializeField] GameObject Camera;
     GameObject TopPlayScreen;
    GameObject LevelEndScreen;
  
    Animator animator;


    void Start()
    {
        //diamondtxt = Currency.GetComponentsInChildren<TextMeshProUGUI>()[0];
        //goldtxt = Currency.GetComponentsInChildren<TextMeshProUGUI>()[1];
        animator = GetComponentInChildren<Animator>();
        TopPlayScreen = GameObject.Find("TopPlayScreen");
        LevelEndScreen=GameObject.Find("LevelEndScreen");
        
        

    }


    void Update()
    {

    }



    private void OnEnable()
    {
        LevelBar.maxValue = 10;
        LevelBar.value = 0;
        LoadGameData();

    }
    public void TopPlayButton()
    {
        Time.timeScale = 1;
        TopPlayScreen.SetActive(false);
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Gold"))
        {

            animator.SetBool("hasState", false);

            Destroy(other.gameObject);

            //player üstünde particle ve ses
            //altýn objesýný yok et 
            //uý kýsmýný setle
        }
        if (other.CompareTag("Diamond"))
        {

            animator.SetBool("hasState", false);

            Destroy(other.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gold"))
        {
            LevelBar.value++;
            animator.SetBool("hasState", true);
            GameInfo.CurrentGoldAmount++;
            //goldtxt.text = goldAmount.ToString();
            Gold.Play();
            //player üstünde particle ve ses
            //altýn objesýný yok et 
            //uý kýsmýný setle
        }
        if (other.CompareTag("Diamond"))
        {
            LevelBar.value++;
            animator.SetBool("hasState", true);
            GameInfo.CurrentDiamondAmount++;
            Diamond.Play();

        }
        if (other.CompareTag("Obstacle"))
        {
            GameInfo.CurrentGoldAmount--;
            GameInfo.CurrentDiamondAmount--;
            LevelBar.value--;
            
        }
        if (other.name == "Finish")
        {
            Camera.GetComponent<FinishLineCamera>().Rotate();
            GetComponent<CharacterInput>().enabled = false;
            animator.Play("Dance");
            SaveGameData();
        }
    }



    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnApplicationQuit()
    {
        SaveGameData();
    }

    private void SaveGameData()
    {
        PlayerPrefs.SetInt("CurrentLevel", GameInfo.CurrentLevelNumber+1);
        PlayerPrefs.SetInt("GoldAmount", GameInfo.GoldAmount);
        PlayerPrefs.SetInt("DiamondAmount", GameInfo.DiamondAmount);
        PlayerPrefs.SetInt("CurrentGoldUpgrade", GameInfo.CurrentGoldAmount);
        PlayerPrefs.SetInt("CurrentDiamondUpgrade", GameInfo.CurrentDiamondAmount);
    }

    private void LoadGameData()
    {
        GameInfo.CurrentLevelNumber = PlayerPrefs.GetInt("CurrentLevel", 1);
        GameInfo.GoldAmount = PlayerPrefs.GetInt("GoldAmount", 0);
        GameInfo.DiamondAmount = PlayerPrefs.GetInt("DiamondAmount", 0);
        GameInfo.CurrentGoldAmount= PlayerPrefs.GetInt("CurrentGoldUpgrade", 0);
        GameInfo.CurrentDiamondAmount=PlayerPrefs.GetInt("CurrentDiamondUpgrade", 0);
        
    }
}


