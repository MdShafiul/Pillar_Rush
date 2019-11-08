using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class Home : MonoBehaviour
{

    AudioSource mAudioSource;

    public TextMeshProUGUI bestScore;

    public GameObject Info_Details;
    public GameObject Credit_Details;
    public GameObject Best_Details;

    public GameObject Box_Play;
    public GameObject Box_Logo;
    public GameObject Box_Best;
    public GameObject Box_Info;
    public GameObject Box_Quit;

    public GameObject Box_SoundOn;
    public GameObject Box_SoundOff;

    public bool Check_Best;
    public bool Check_Info;
    public bool Check_Credit;
    public bool Check_Logo;

    // Start is called before the first frame update
    void Start()
    {

//        PlayerPrefs.SetInt("Check_Sound", 1);
        PlayerPrefs.SetInt("Check_Death", 0);

        mAudioSource = GetComponent<AudioSource>();

        bestScore.text = ((int)PlayerPrefs.GetFloat("Best")).ToString();

        Info_Details.SetActive(false);
        Credit_Details.SetActive(false);
        Best_Details.SetActive(false);

        Box_Play.SetActive(true);
        Box_Logo.SetActive(true);
        Box_Best.SetActive(true);
        Box_Info.SetActive(true);
        Box_Quit.SetActive(true);

        if( PlayerPrefs.GetInt("Check_Sound") == 1 )
        {
            Box_SoundOn.SetActive(true);
            Box_SoundOff.SetActive(false);
        }

        else
        {
            Box_SoundOn.SetActive(false);
            Box_SoundOff.SetActive(true);
        }
        

        Check_Best = false;
        Check_Info = false;
        Check_Credit = false;
        Check_Logo = true;

    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Escape) )
        {
            Application.Quit();
        }



    }

    public void Play()
    {
        if (PlayerPrefs.GetInt("Check_Sound") == 1)
            mAudioSource.Play();
        SceneManager.LoadScene("Game");
    }

    public void Best()
    {

        if (PlayerPrefs.GetInt("Check_Sound") == 1)
            mAudioSource.Play();

        if ( Check_Best == false )
        {

            Check_Best = true;

            Best_Details.SetActive(true);

            Box_Play.SetActive(false);
            Box_Logo.SetActive(false);
            Box_Info.SetActive(false);
            Box_Quit.SetActive(false);

        }

        else
        {

            Check_Best = false;

            Best_Details.SetActive(false);

            Box_Play.SetActive(true);
            Box_Logo.SetActive(true);
            Box_Info.SetActive(true);
            Box_Quit.SetActive(true);

        }

    }

    public void Info()
    {

        if (PlayerPrefs.GetInt("Check_Sound") == 1)
            mAudioSource.Play();

        if (Check_Info == false)
        {

            Check_Info = true;

            Info_Details.SetActive(true);

            Box_Play.SetActive(false);
            Box_Best.SetActive(false);
            Box_Quit.SetActive(false);

        }

        else
        {

            Check_Info = false;

            Info_Details.SetActive(false);

            Box_Play.SetActive(true);
            Box_Best.SetActive(true);
            Box_Quit.SetActive(true);

        }

    }

    public void Credit()
    {

        if( PlayerPrefs.GetInt("Check_Sound") == 1 )
            mAudioSource.Play();

        if (Check_Credit == false)
        {

            Check_Credit = true;

            Credit_Details.SetActive(true);

            Box_Play.SetActive(false);
            Box_Best.SetActive(false);
            Box_Info.SetActive(false);
            Box_Quit.SetActive(false);

        }

        else
        {

            Check_Credit = false;

            Credit_Details.SetActive(false);

            Box_Play.SetActive(true);
            Box_Best.SetActive(true);
            Box_Info.SetActive(true);
            Box_Quit.SetActive(true);

        }

    }

    public void SoundFOn()
    {

        PlayerPrefs.SetInt("Check_Sound", 0);
//        mAudioSource.Play();

        Box_SoundOff.SetActive(true);
        Box_SoundOn.SetActive(false);

    }

    public void SoundFOff()
    {

        PlayerPrefs.SetInt("Check_Sound", 1);
        mAudioSource.Play();

        Box_SoundOn.SetActive(true);
        Box_SoundOff.SetActive(false);

    }

    public void Quit()
    {
        Application.Quit();
    }

}
