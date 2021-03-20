using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IAPControllerLab : MonoBehaviour,IStoreListener
{

    IStoreController controller;
    public string[] product;
    public Text cointext;
    public Text epintext;

    public bool delete = true;

    public InputField inputfield;
    public GameObject inputpnl;
    public GameObject coinPaymentPnl;

    public GameObject devamCoinGive;

    private void Start()
    {
        Value = PlayerPrefs.GetInt("mypara");
        IAPStart();
    }
   
    private void IAPStart()
    {
        var module = StandardPurchasingModule.Instance();

        ConfigurationBuilder builder = ConfigurationBuilder.Instance(module);
        
        foreach(string item in product)
        {
            builder.AddProduct(item,ProductType.Consumable);
        }
        UnityPurchasing.Initialize(this, builder);

    }
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        this.controller = controller;
    }
    
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("Error" + error.ToString());
    }
    public void OnPurchaseFailed(Product i, PurchaseFailureReason p)
    {
        Debug.Log("Error while buying" + p.ToString());
    }
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
    {
        // satın alma gerçekleştiği zaman aktif olacak fonksiyon

        if (string.Equals(e.purchasedProduct.definition.id,product[0],StringComparison.Ordinal))
        {
            //element 0 ı aldıgın zaman
            
            Add100Altin();
            return PurchaseProcessingResult.Complete;

        }
        else if (string.Equals(e.purchasedProduct.definition.id, product[1], StringComparison.Ordinal))
        {
            //element 1 ı aldıgın zaman
            Add200Altin();
            return PurchaseProcessingResult.Complete;

        }
        else if (string.Equals(e.purchasedProduct.definition.id, product[2], StringComparison.Ordinal))
        {
            //element 2 ı aldıgın zaman
            Add300Altin();

            return PurchaseProcessingResult.Complete;
        }
        else if (string.Equals(e.purchasedProduct.definition.id, product[3], StringComparison.Ordinal))
        {
            //element 3 ı aldıgın zaman
            Add400Altin();

            return PurchaseProcessingResult.Complete;
        }
        else if (string.Equals(e.purchasedProduct.definition.id, product[4], StringComparison.Ordinal))
        {
            //element 4 ı aldıgın zaman
            Add500Altin();

            return PurchaseProcessingResult.Complete;
        }
        else if (string.Equals(e.purchasedProduct.definition.id, product[5], StringComparison.Ordinal))
        {
            //element 5 ı aldıgın zaman
            Add600Altin();

            return PurchaseProcessingResult.Complete;
        }
        else
        {
            return PurchaseProcessingResult.Pending;
        }
    }
    private void AddCoin(int coin)
    {
        cointext.text = coin.ToString() + " altın satın aldı";

        Add50Altin();
    }
   
    public void IAPButton(string id )
    {
        Product proc = controller.products.WithID(id);
        if(proc != null && proc.availableToPurchase)
        {
            Debug.Log("Buying...");
            controller.InitiatePurchase(proc);

        }
        else
        {
            Debug.Log("Not ");
        }
    }
    /////////////////////////////
    
    public int Value;
    public Text CoinAmount;

    public int My_Money;
    public GameObject MoneyEnoughTxt;

    void Update()
    {
       CoinAmount.text = "" + Value;
    }

    public void Add50Altin()
    {
        Value += 50;
        PlayerPrefs.SetInt("mypara", Value);
        cointext.text = "50 ALTIN SATIN ALINDI";
    }
    public void Add100Altin()
    {
        Value += 100;
        PlayerPrefs.SetInt("mypara", Value);
        cointext.text = "100 ALTIN SATIN ALINDI";
    }

    public void Add200Altin()
    {
        Value += 200;
        PlayerPrefs.SetInt("mypara", Value);
        cointext.text = "200 ALTIN SATIN ALINDI";
    }
    public void Add300Altin()
    {
        Value += 300;
        PlayerPrefs.SetInt("mypara", Value);
        cointext.text = "300 ALTIN SATIN ALINDI";
    }
    public void Add400Altin()
    {
        Value += 400;
        PlayerPrefs.SetInt("mypara", Value);
        cointext.text = "400 ALTIN SATIN ALINDI";
    }
    public void Add500Altin()
    {
        Value += 500;
        PlayerPrefs.SetInt("mypara", Value);
        cointext.text = "500 ALTIN SATIN ALINDI";
    }

    public void Add600Altin()
    {
        Value += 600;
        PlayerPrefs.SetInt("mypara", Value);
        cointext.text = "600 ALTIN SATIN ALINDI";
    }
    public void Add10000Altin()
    {
        Value += 100000;
        PlayerPrefs.SetInt("mypara", Value);  
    }

    public void GiveCoin()
    {

        if (Value >= 30)
        {
            devamCoinGive.SetActive(true);

            Value -= 30;

            PlayerPrefs.SetInt("mypara", Value);

            Time.timeScale = 1;
        }
        else if (Value < 30)
        {
            MoneyEnoughTxt.SetActive(true);
        }
    }
    public void DontGiveCoin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Time.timeScale = 1;
    }

    public void epinkullan()
    {
        if (inputfield.text == "JLuRFA8gUeNVkTHt6ry9")
        {
            Add10000Altin();
            epintext.text = " E-PİN KULLANILDI. ALINAN ALTIN SAYISI: 100.000";
            
        }
        else if (inputfield.text == "48uMnJGNapVp9yMjPBYU")
        {
            Add500Altin();
            epintext.text = " E-PİN KULLANILDI. ALINAN ALTIN SAYISI: 500";
            
        }
        else
            epintext.text = " HATALI GİRİŞ YAPTINIZ.";
    }
    public void epinkullanAC()
    {
        inputpnl.SetActive(true);

    }
    public void epinkullanAkapa()
    {
        inputpnl.SetActive(false);
    }
    public void altınAlPnlAc()
    {
        coinPaymentPnl.SetActive(true);
    }
    public void altınAlPnlKpa()
    {
        coinPaymentPnl.SetActive(false);
    }
    public void menu()
    {
        SceneManager.LoadScene(0);

    }

}
