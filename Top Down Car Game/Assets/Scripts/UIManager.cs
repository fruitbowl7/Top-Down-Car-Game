using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("Coin Count Text") != null)
        {
            Debug.Log("I Found The Coin Count Text");
        }
        else
        {
            Debug.Log("I can't find the Coin Count Text");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

     public void RaceButtonPressed()
    {
        SceneManager.LoadScene("Game Mode");
    }
    
    public void SingleRaceButtonPressed()
    {
        SceneManager.LoadScene("Single Race");
    }

    public void CupRaceButtonPressed()
    {
        SceneManager.LoadScene("Corse 1");
    }
}
