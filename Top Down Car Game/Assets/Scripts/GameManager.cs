using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private int _coinCount = 0;

    public int amount { get; private set; }

    void Awake() 
    {
       if(Instance != null && Instance != this) 
       {
            Destroy(gameObject);
       }
       else
       {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
       }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCoinCount()
    {
        _coinCount += amount;
    }

    public int GetCoinCount()
    {
        return _coinCount;
    }
}
