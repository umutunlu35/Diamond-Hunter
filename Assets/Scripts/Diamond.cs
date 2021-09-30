using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diamond : MonoBehaviour
{
    public GameObject diamond;
    public GManager gManager;
    public AudioSource gemSound;
    Vector3 diamondPlaceVector;
    public Text diamondScoreText;
    private int diamondScore;
    public int diamondCount = 5;
    private bool spawnController = false;
    private bool positionController = false;
    private float timer = 2f;
    private bool timerCountDown = false;
    float x, z;
    Animator animator;

    private void Start()
    {
        diamondScore = 0;
        diamondScoreText.text = diamondScore + "/ 100";
        animator = gameObject.GetComponent<Animator>();
        gemSound = GetComponent<AudioSource>();
    }
    void GeneratePosition()
    {
        if (!positionController)
        {
            positionController = true;
            x = Random.Range(-3.5f, 3.5f);
            z = Random.Range(-5.5f, 5.5f);
            diamondPlaceVector = new Vector3(x, 0.55f, z);
            positionController = false;
        }
    }
    void PlaceDiamonds()
    {
        if (!spawnController)
        {
            spawnController = true;
            GameObject Diamondd = Instantiate(diamond, diamondPlaceVector, Quaternion.Euler(-90, 0, 0));
            spawnController = false;
        }
    }

    void FinishGame()
    {
        if (diamondScore >= 100)
        {
            gManager.FinishLevel();
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Diamond")
        {
            timerCountDown = true;
            animator.SetTrigger("Collect");
        }
    }

    void OnTriggerStay(Collider collision)
    {
        if (timer <= 0 && collision.gameObject.tag == "Diamond")
        {
            diamondCount -= 1;
            diamondScore += 10;
            diamondScoreText.text = diamondScore + "/ 100";
            PlayerPrefs.SetInt("Score", diamondScore);
            GeneratePosition();
            PlaceDiamonds();
            Invoke("FinishGame", 1.1f);
            gemSound.Play();
            Destroy(collision.gameObject);
            timer = 2f;
            timerCountDown = false;
        }
    }

    private void Update()
    {
        if (timer > 0 && timerCountDown == true)
        {
            timer -= Time.deltaTime;
        }
        //Debug.Log(timer);
    }
}
