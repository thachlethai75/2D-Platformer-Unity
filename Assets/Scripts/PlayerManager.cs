using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;


public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject pauseScreen;
    public static bool isGameOver;
    public static Vector2 lastCheckpoint = new Vector2(0, 0);
    public static int numberCoin;
    public CinemachineVirtualCamera vCam;
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] GameObject[] playerPrefabs;
    int characterIndex;
    // Start is called before the first frame update
    private void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("SelectCharacter", 0);
        GameObject player = Instantiate(playerPrefabs[characterIndex], lastCheckpoint, Quaternion.identity);
        vCam.m_Follow = player.transform;
        numberCoin = PlayerPrefs.GetInt("NumberOfCoin", 0);
        isGameOver = false;
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckpoint;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text ="Coin:" +numberCoin.ToString();
        if(isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    public void Home()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
