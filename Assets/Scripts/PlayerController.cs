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
   

    Animator animator;

    int levelBarValue;
    int Current_DiamondAmount = 0;

    void Start()
    {
        Particles = new ParticleSystem[4];
        
        LevelBar.maxValue = 10;
        LevelBar.value = 0;
        LoadGameData();

        animator = GetComponentInChildren<Animator>();
        TopPlayScreen = GameObject.Find("TopPlayScreen");
        Particles[0] = GetComponentsInChildren<ParticleSystem>()[0];
        Particles[1] = GetComponentsInChildren<ParticleSystem>()[1];
        Particles[2] = GetComponentsInChildren<ParticleSystem>()[2];
        Particles[3] = GetComponentsInChildren<ParticleSystem>()[3];
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
            LevelBar.value = levelBarValue;
            animator.SetBool("hasState", true);
            GameInfo.CurrentGoldAmount++;
            other.GetComponent<AudioSource>().Play();
            Particles[0].Play();
            Particles[2].Play();
        }
        if (other.CompareTag("Diamond"))
        {
            levelBarValue++;
            LevelBar.value = levelBarValue;
            animator.SetBool("hasState", true);
            Current_DiamondAmount++;

            other.GetComponent<AudioSource>().Play();
            GameInfo.CurrentDiamondAmount++;
            if (GameInfo.CurrentDiamondAmount % 5 == 0) Particles[1].Play();
            else Particles[0].Play();
            Particles[3].Play();

        }
        if (other.CompareTag("Obstacle"))
        {
            if (GameInfo.CurrentGoldAmount > 0) GameInfo.CurrentGoldAmount--;
            if (GameInfo.CurrentDiamondAmount > 0) GameInfo.CurrentDiamondAmount--;
            Particles[3].Play();
            other.GetComponent<AudioSource>().Play();
            levelBarValue--;
            LevelBar.value = levelBarValue;

        }
        if (other.name == "Finish")
        {
            Camera.GetComponent<FinishLineCamera>().Rotate();
            GetComponent<CharacterInput>().enabled = false;
            animator.Play("Dance");
        }
    }

    private void OnApplicationQuit()
    {
        SaveGameData();
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


