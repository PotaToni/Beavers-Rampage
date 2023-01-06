using System;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class IAPManager : MonoBehaviour, IStoreListener
{
    public static IAPManager instance;
    [SerializeField] Text text;
    [SerializeField] Text text2;
    [SerializeField] Text text3;
    [SerializeField] Text text4;

    private static IStoreController m_StoreController;
    private static IExtensionProvider m_StoreExtensionProvider;

    private string rocketLauncher = "rocket_launcher";
    private string coins1000 = "coin_1000";
    private string coins5000 = "coin_5000";
    private string coins10000 = "coin_10000";

    GameObject gameControl;
    //Step 1 create your products



    //************************** Adjust these methods **************************************
    public void InitializePurchasing()
    {
        if (IsInitialized()) { return; }
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        //Step 2 choose if your product is a consumable or non consumable

        builder.AddProduct(rocketLauncher, ProductType.NonConsumable);
        builder.AddProduct(coins1000, ProductType.Consumable);
        builder.AddProduct(coins5000, ProductType.Consumable);
        builder.AddProduct(coins10000, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }


    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }


    //Step 3 Create methods

    public void BuyRocketLauncher()
    {
        BuyProductID(rocketLauncher);
    }

    public void BuyCoins1000()
    {
        BuyProductID(coins1000);
    }

    public void BuyCoins5000()
    {
        BuyProductID(coins5000);
    }

    public void BuyCoins10000()
    {
        BuyProductID(coins10000);
    }



    //Step 4 modify purchasing
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (String.Equals(args.purchasedProduct.definition.id, rocketLauncher, StringComparison.Ordinal))
        {
            FindObjectOfType<GameControl>().gameObject.GetComponent<GameControl>().owned[5] = true;
            gameControl = FindObjectOfType<GameControl>().gameObject;
            gameControl.GetComponent<GameControl>().SavePlayer();
        }
        else if (String.Equals(args.purchasedProduct.definition.id, coins1000, StringComparison.Ordinal))
        {
            FindObjectOfType<GameControl>().gameObject.GetComponent<GameControl>().purchase1000();
            gameControl = FindObjectOfType<GameControl>().gameObject;
            gameControl.GetComponent<GameControl>().SavePlayer();
        }
        else if (String.Equals(args.purchasedProduct.definition.id, coins5000, StringComparison.Ordinal))
        {
            FindObjectOfType<GameControl>().gameObject.GetComponent<GameControl>().purchase5000();
            gameControl = FindObjectOfType<GameControl>().gameObject;
            gameControl.GetComponent<GameControl>().SavePlayer();
        }
        else if (String.Equals(args.purchasedProduct.definition.id, coins10000, StringComparison.Ordinal))
        {
            FindObjectOfType<GameControl>().gameObject.GetComponent<GameControl>().purchase10000();
            gameControl = FindObjectOfType<GameControl>().gameObject;
            gameControl.GetComponent<GameControl>().SavePlayer();
        }
        else
        {
            Debug.Log("Purchase Failed");
        }
        return PurchaseProcessingResult.Complete;
    }










    //**************************** Dont worry about these methods ***********************************
    private void Awake()
    {
        TestSingleton();
    }

    void Start()
    {
        if (m_StoreController == null) { InitializePurchasing(); }
    }


    private void TestSingleton()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void BuyProductID(string productId)
    {
        if (IsInitialized())
        {
            Product product = m_StoreController.products.WithID(productId);
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                m_StoreController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }

    public void RestorePurchases()
    {
        if (!IsInitialized())
        {
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            Debug.Log("RestorePurchases started ...");

            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
            apple.RestoreTransactions((result) => {
                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
            });
        }
        else
        {
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: PASS");
        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
        text.text = m_StoreController.products.WithID("rocket_launcher").metadata.localizedPriceString;
        text2.text = m_StoreController.products.WithID("coin_1000").metadata.localizedPriceString;
        text3.text = m_StoreController.products.WithID("coin_5000").metadata.localizedPriceString;
        text4.text = m_StoreController.products.WithID("coin_10000").metadata.localizedPriceString;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}