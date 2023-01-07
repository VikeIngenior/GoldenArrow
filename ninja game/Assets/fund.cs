using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class fund : MonoBehaviour
{
    public GameObject obstacle;
    public TextMeshProUGUI remTime; //Text to show time on the screen
    public GameObject win_panel;
    private GameObject obstacleClone;
    private Rigidbody rb;
    private int randNum;

    float countTime = 60f;

    void Start()
    {
        //Random time to instantiate new obstacles for both coming from left and right side
        float randomStartLeft = Random.Range(0f, 5f) + 1;
        float randomStartRight = Random.Range(0f, 5f) + 1;

        InvokeRepeating("Spawner", 1f, 2.2f);
    }
    void Spawner()
    {
        randNum = Random.Range(0, 3);
        if(randNum == 0)
        {
            obstacleClone = Instantiate(obstacle, new Vector3(9, 0.7f, 0), Quaternion.identity);
            Destroy(obstacleClone, 3.0f);
            rb = obstacleClone.GetComponent<Rigidbody>();
        }
        if(randNum == 1)
        {
            obstacleClone = Instantiate(obstacle, new Vector3(-9, 0.7f, 0), Quaternion.identity);
            Destroy(obstacleClone, 3.0f);
            rb = obstacleClone.GetComponent<Rigidbody>();

        }
        if(randNum == 2)
        {
            obstacleClone = Instantiate(obstacle, new Vector3(9, 0.7f, 0), Quaternion.identity);
            Destroy(obstacleClone, 3.0f);
            rb = obstacleClone.GetComponent<Rigidbody>();
            obstacleClone = Instantiate(obstacle, new Vector3(-9, 0.7f, 0), Quaternion.identity);
            Destroy(obstacleClone, 3.0f);
            rb = obstacleClone.GetComponent<Rigidbody>();

        }

    }
    void Update()
    {
        Debug.Log(randNum);
        //Countdown
        remTime.text = ((int) countTime).ToString();
        if (countTime > 0)
        {
            countTime -= Time.deltaTime;
        }
        else
        {
            win_panel.SetActive(true);
            countTime = 0;
            Time.timeScale = 0;
        }
        
    }
    public void play_again()
    {
        SceneManager.LoadScene(0);
        countTime = 60.1f;
        Time.timeScale = 1;

    }



}
