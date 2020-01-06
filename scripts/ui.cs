using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ui : MonoBehaviour
{
    [SerializeField]
    public bool saveDataBOOL = false;
    public AudioSource theme;
    [SerializeField]
    private GameObject scoreOBJ, helthOBJ;
    public string menu = "Menu", game = "Game";
    public GameObject shopOBJ, ammoTXT, ammoOBJ, highScoreOBJ, highScore, pauseMenu, MainMenu, settingsMenu, menuSettings, scoreText, helthCount, player, menuObj;
    private bool gameIsPaused, alive = false;
    [HideInInspector]
    public float helthc = 0, score = 0, highScoreNUM = 0, ammo = 0, actualScore;
    [HideInInspector]
    public playerData playerDat;
    [HideInInspector]
    public GameObject mngOBJ;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    public void Start()
    {
        playerDat = GetComponent<playerData>();
        if (Application.persistentDataPath + "/user.virus" != null) { playerDat.loadPlayer(); }
        highScoreNUM = playerDat.score;
        Menu();
    }
    // Update is called once per fra
    void Update()
    {
        ammoTXT.GetComponent<Text>().text = ammo.ToString();
        menuObj = GameObject.FindGameObjectWithTag("maneger");
        if (alive) {
            scoreText.GetComponent<Text>().text = score.ToString(); }
        helthCount.GetComponent<Text>().text = helthc.ToString();
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && !MainMenu.active && !settingsMenu.active) {
            if (gameIsPaused) {
                Resume();
            } else {

                Pause();
            }
        }/*
        if (Input.GetKeyDown("y"))
        {
            Instantiate(player, menuObj.transform);

        }*/
    }
    //public int score = 0, scoreCounter = 0;

    public IEnumerator gameTime() {
        yield return new WaitForSeconds(180);
        if (alive)
        {
            // Menu();
        }
    }

    public void Pause()
    {
        shopOBJ.SetActive(false);
        scoreOBJ.SetActive(true);
        helthOBJ.SetActive(true);
        ammoOBJ.SetActive(true);
        highScoreOBJ.SetActive(true);
        settingsMenu.SetActive(false);
        MainMenu.SetActive(false);
        menuSettings.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void Resume()
    {
        shopOBJ.SetActive(false);
        scoreOBJ.SetActive(true);
        helthOBJ.SetActive(true);
        ammoOBJ.SetActive(true);
        highScoreOBJ.SetActive(false);
        settingsMenu.SetActive(false);
        MainMenu.SetActive(false);
        menuSettings.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    public void Quit()
    {
        playerDat.savePlayer();
        //save
        Application.Quit();
    }
    public void Menu()
    {
        if (playerDat.score < actualScore)
        {
            playerDat.score = actualScore;
            highScoreNUM = actualScore;
        }
        playerDat.savePlayer();
        playerDat.loadPlayer();
        shopOBJ.SetActive(false);
        highScoreNUM = playerDat.score;
        highScore.GetComponent<Text>().text = highScoreNUM.ToString();
        StopAllCoroutines();
        alive = false;
        scoreText.GetComponent<Text>().text = score.ToString();
        SceneManager.LoadScene(menu);
        highScoreOBJ.SetActive(true);
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(false);
        MainMenu.SetActive(true);
        menuSettings.SetActive(false);
        ammoOBJ.SetActive(false);
        scoreOBJ.SetActive(true);
        helthOBJ.SetActive(false);
    }
    public void Play()
    {
        shopOBJ.SetActive(false);
        alive = true;
        score = 0;
        highScoreOBJ.SetActive(false);
        StartCoroutine(gameTime());
        SceneManager.LoadScene(game);
        Time.timeScale = 1f;
        score = 0;
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(false);
        MainMenu.SetActive(false);
        menuSettings.SetActive(false);
        ammoOBJ.SetActive(true);
        scoreOBJ.SetActive(true);
        helthOBJ.SetActive(true);
        playerDat.setStartVariebles();
    }
    public void assignGun()
    {
        //mngOBJ = GameObject.FindGameObjectWithTag("maneger");
        if (mngOBJ.GetComponent<maneger>().player.GetComponent<moawment>().currentGun == null)
        {
            playerDat.LoadGun("semi_auto");
            mngOBJ.GetComponent<maneger>().player.GetComponent<moawment>().equipGun();
        }
    }
    public void Settings()
    {
        shopOBJ.SetActive(false);
        highScoreOBJ.SetActive(false);
        menuSettings.SetActive(false);
        settingsMenu.SetActive(true);
        pauseMenu.SetActive(false);
        MainMenu.SetActive(false);
        ammoOBJ.SetActive(false);
        scoreOBJ.SetActive(false);
        helthOBJ.SetActive(false);
        Time.timeScale = 0f;
    }
    public void MenuSettings()
    {
        shopOBJ.SetActive(false);
        highScoreOBJ.SetActive(false);
        menuSettings.SetActive(true);
        pauseMenu.SetActive(false);
        MainMenu.SetActive(false);
        settingsMenu.SetActive(false);
        ammoOBJ.SetActive(false);
        scoreOBJ.SetActive(false);
        helthOBJ.SetActive(false);
    }
    public void Shop()
    {
        shopOBJ.SetActive(true);
        highScoreOBJ.SetActive(false);
        menuSettings.SetActive(false);
        pauseMenu.SetActive(false);
        MainMenu.SetActive(false);
        settingsMenu.SetActive(false);
        ammoOBJ.SetActive(false);
        scoreOBJ.SetActive(false);
        helthOBJ.SetActive(false);
        highScore.SetActive(false);
    }
    public void TurnMuzicOFF(float amount)
    {
        theme.volume = amount;
    }
}
