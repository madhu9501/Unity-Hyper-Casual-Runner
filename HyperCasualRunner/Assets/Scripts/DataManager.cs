using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    [SerializeField] Text[] _coinTexts;
    int _coin;

    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null)
            Destroy(gameObject);
        else
            Instance = this;

        _coin = PlayerPrefs.GetInt("coins", 0);
    }

    // Update is called once per frame
    void Start()
    {
        UpdateCoinTexts();
    }

    void UpdateCoinTexts()
    {
        foreach(Text coinText in _coinTexts)
        {
            coinText.text = _coin.ToString();
        }
    }

    public void AddCoin(int amount)
    {
        _coin += amount;
        UpdateCoinTexts();
        PlayerPrefs.SetInt("coins", _coin );
    }
}
