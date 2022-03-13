using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject Currency;
    [SerializeField] GameObject Camera;

    [SerializeField] Slider LevelBar;

    [SerializeField] Text CurrentLeveltxt;
    [SerializeField] Text NextLevel;

    ParticleSystem[] Particles;

    Animator animator;

    int levelBarValue;


    void Start()
    {
        Particles = new ParticleSystem[4];

        LevelBar.maxValue = 10;
        LevelBar.value = 0;

        animator = GetComponentInChildren<Animator>();

        Particles[0] = GetComponentsInChildren<ParticleSystem>()[0];
        Particles[1] = GetComponentsInChildren<ParticleSystem>()[1];
        Particles[2] = GetComponentsInChildren<ParticleSystem>()[2];
        Particles[3] = GetComponentsInChildren<ParticleSystem>()[3];
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


}


