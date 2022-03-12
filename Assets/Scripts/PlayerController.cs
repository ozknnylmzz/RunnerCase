using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject Currency;
    ParticleSystem[] Particles;
   
    [SerializeField] Slider LevelBar;
    [SerializeField] Text CurrentLeveltxt;
    [SerializeField] Text NextLevel;
    [SerializeField] GameObject Camera;
    GameObject TopPlayScreen;
    GameObject LevelEndScreen;

    Animator animator;

    int levelBarValue;

    void Start()
    {
        Particles = new ParticleSystem[4];
        LoadGameData();
        animator = GetComponentInChildren<Animator>();
        TopPlayScreen = GameObject.Find("TopPlayScreen");
        LevelEndScreen = GameObject.Find("LevelEndScreen");
        Particles[0] = GetComponentsInChildren<ParticleSystem>()[0];
        Particles[1] = GetComponentsInChildren<ParticleSystem>()[1];
        Particles[2] = GetComponentsInChildren<ParticleSystem>()[2];
        Particles[3] = GetComponentsInChildren<ParticleSystem>()[3];



    }


    void Update()
    {

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
            levelBarValue++;
            LevelBar.value=levelBarValue;
            animator.SetBool("hasState", true);
            GameInfo.CurrentGoldAmount++;
            //goldtxt.text = goldAmount.ToString();
            Particles[1].Play();
            Particles[2].Play();
            //player üstünde particle ve ses
            //altýn objesýný yok et 
            //uý kýsmýný setle
        }
        if (other.CompareTag("Diamond"))
        {
            levelBarValue++;
            LevelBar.value = levelBarValue;
            animator.SetBool("hasState", true);

            GameInfo.CurrentDiamondAmount++;
            Particles[0].Play();
            Particles[3].Play();

        }
        if (other.CompareTag("Obstacle"))
        {
            if (GameInfo.CurrentGoldAmount > 0) GameInfo.CurrentGoldAmount--;
            if (GameInfo.CurrentDiamondAmount > 0) GameInfo.CurrentDiamondAmount--;
            Particles[3].Play();
            levelBarValue--;
            LevelBar.value = levelBarValue;

        }
        if (other.name == "Finish")
        {
            Camera.GetComponent<FinishLineCamera>().Rotate();
            GetComponent<CharacterInput>().enabled = false;
            animator.Play("Dance");

            SaveGameData();
        }
    }

    

    private void OnApplicationQuit()
    {
        SaveGameData();
    }

    private void SaveGameData()
    {
        PlayerPrefs.SetInt("CurrentLevel", GameInfo.CurrentLevelNumber + 1);
        PlayerPrefs.SetInt("GoldAmount", GameInfo.GoldAmount);
        PlayerPrefs.SetInt("DiamondAmount", GameInfo.DiamondAmount);
        //PlayerPrefs.SetInt("CurrentGoldUpgrade", GameInfo.CurrentGoldAmount);
        //PlayerPrefs.SetInt("CurrentDiamondUpgrade", GameInfo.CurrentDiamondAmount);
        
    }



    private void LoadGameData()
    {
        LevelBar.maxValue = 10;
        LevelBar.value = 0;
        GameInfo.CurrentLevelNumber = PlayerPrefs.GetInt("CurrentLevel", 1);
        GameInfo.GoldAmount = PlayerPrefs.GetInt("GoldAmount", 0);
        GameInfo.DiamondAmount = PlayerPrefs.GetInt("DiamondAmount", 0);
        GameInfo.CurrentGoldAmount = 0;
        GameInfo.CurrentDiamondAmount = 0;

    }
}


