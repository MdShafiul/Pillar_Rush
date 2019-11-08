using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{

    public AudioClip audio1;
    public AudioClip audio2;
    public AudioClip audio3;

    private MeshRenderer MeshRenderer;
    private MeshCollider MeshCollider;



//    public AudioClip audio_storm;

    AudioSource mAudioSource;

    private float score = 0.0f;

    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 30;

    public bool check = false;
    public GameObject deathMenu;
    public GameObject hideBack;
    public GameObject explosion;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI deathScore;

    // Start is called before the first frame update
    void Start()
    {

        PlayerPrefs.SetInt("Check_Death", 0);

        MeshRenderer = GetComponent<MeshRenderer>();
        MeshCollider = GetComponent<MeshCollider>();
        mAudioSource = GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("Check_Sound") == 0)
            mAudioSource.Stop();

        MeshRenderer.enabled = true;
        MeshCollider.enabled = true;

        check = false;
        deathMenu.SetActive(false);
        hideBack.SetActive(true);
        explosion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (check)
            return;

 //       mAudioSource.PlayOneShot(audio_storm, 0.75F);

        if (score >= scoreToNextLevel)
            LevelUp();

        if (score >= 30.0f)
        {
            GameObject[] foat_text = GameObject.FindGameObjectsWithTag("+5");

            foreach (GameObject go in foat_text)
            {
                go.SetActive(false);
            }
        }

        score += Time.deltaTime * difficultyLevel;
        scoreText.text = ((int)score).ToString();
    }

    void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
            return;

        scoreToNextLevel *= 2;
        difficultyLevel++;

        GetComponent<PlayerMotor>().SetSpeed(difficultyLevel);

        Debug.Log(difficultyLevel);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {

            if (PlayerPrefs.GetInt("Check_Sound") == 1)
                mAudioSource.PlayOneShot(audio1 , 1.0F);

            other.gameObject.SetActive(false);
            score += 5.0f;
        }

        else if (other.gameObject.CompareTag("Enemy"))
        {

            mAudioSource.Stop();
            PlayerPrefs.SetInt("Check_Death", 1);
            MeshRenderer.enabled = false;
            MeshCollider.enabled = false;

            if (PlayerPrefs.GetInt("Check_Sound") == 1)
                mAudioSource.PlayOneShot(audio2 , 1.0F);
            explosion.SetActive(true);

            check = true;
            deathMenu.SetActive(true);
            hideBack.SetActive(false);
            deathScore.text = ((int)score).ToString();

            if( PlayerPrefs.GetFloat("Best") < score )
                PlayerPrefs.SetFloat("Best", score);

            scoreText.text = "";
        }

    }

    public void Play()
    {
        if (PlayerPrefs.GetInt("Check_Sound") == 1)
            mAudioSource.PlayOneShot(audio3, 1.0F);
        SceneManager.LoadScene("Game");
    }

    public void Home()
    {
        if (PlayerPrefs.GetInt("Check_Sound") == 1)
            mAudioSource.PlayOneShot(audio3, 1.0F);
        SceneManager.LoadScene("Main");
    }

}
