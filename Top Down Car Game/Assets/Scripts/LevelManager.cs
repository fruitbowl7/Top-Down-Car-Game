using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public GameObject PausePanel;
    public GameObject GameOverPanel;
    public TextMeshProUGUI CoinCountText;
    public TextMeshProUGUI GasAmountText;
    public TextMeshProUGUI CountDownTimerText;

    private int _countDownTimer = 3;
    [SerializeField] private int _coinsCollected = 0;
    [SerializeField] private int _gasAmount = 10;
    [SerializeField] private int _currentGasAmount = 10;
     [SerializeField] private bool _isGameActive = false;

    void Awake() 
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        CoinCountText.text = _coinsCollected.ToString();
        GasAmountText.text = _gasAmount.ToString();
        StartCoroutine(StartCountDownTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool StartGame()
    {
        _isGameActive = true;
        return _isGameActive;
     }

    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
    }

    public void ReplayButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HomeButtonPressed()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void PauseButtonPressed()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }

    public void PlayButtonPressed()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }

    public void UpdateLevelCoinCount(int amount)
    {
        _coinsCollected += amount;
        CoinCountText.text = _coinsCollected.ToString();
    }

    public void UpdateGasAmount(int amount)
    {
       if(_currentGasAmount < _gasAmount)
       {
         _currentGasAmount += amount;
        GasAmountText.text = _currentGasAmount.ToString();
       }
       
    }

    public void StartGasMeter()
    {
        StartCoroutine(UpdateGasMeter());
    }

    private void StartCoroutine(IEnumerable enumerable)
    {
        throw new NotImplementedException();
    }

    IEnumerator StartCountDownTimer()
    {
        yield return new WaitForSeconds(0.25f);
        CountDownTimerText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);

        while(_countDownTimer > 0)
        {
            CountDownTimerText.text = _countDownTimer.ToString();
            yield return new WaitForSeconds(1f);
            _countDownTimer--; //_countDownTimer = _countDownTimer - 1;
        }

        CountDownTimerText.text = "GO!";
        _isGameActive = true;
        yield return new WaitForSeconds(1f);
        CountDownTimerText.gameObject.SetActive(false);
    }
    
    IEnumerable UpdateGasMeter()
    {
        while(_currentGasAmount > 0)
        {
            yield return new WaitForSeconds(3f);
            _currentGasAmount--;
            GasAmountText.text = _currentGasAmount.ToString();
        }
    }
}