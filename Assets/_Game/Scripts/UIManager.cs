using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    //public static UIManager Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            instance = FindObjectOfType<UIManager>();
    //        }
    //        return instance;
    //    }
    //}

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] Text coinText;
    public void SetCoin(int coin)
    {
        coinText.text = coin.ToString();
    }
}
