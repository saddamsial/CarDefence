using System;
using System.Collections.Generic;
using System.Linq;
//using GameAnalyticsSDK;
using UnityEngine;
using UnityEngine.Purchasing;


//..
public class Receipt
{
    public string Store;
    public string TransactionID;
    public string Payload;

    public Receipt()
    {
        Store = TransactionID = Payload = "";
    }

    public Receipt(string store, string transactionID, string payload)
    {
        Store = store;
        TransactionID = transactionID;
        Payload = payload;
    }
}

public class PayloadAndroid
{
    public string json;
    public string signature;

    public PayloadAndroid()
    {
        json = signature = "";
    }

    public PayloadAndroid(string _json, string _signature)
    {
        json = _json;
        signature = _signature;
    }
}


public enum ProductIdentifier
{
    Pack1Coin = 0,
    Pack2Coin = 1,
    Pack3Coin = 2,
    Pack4Coin = 3,
    Pack5Coin = 4,
    Pack6Gem = 5,
    Pack7Gem = 6,
    Pack8Gem = 7,
    Pack9Gem = 8,
    Pack10Gem = 9,
    RemoveAds = 10,
    None = 11,
    MemberShip = 12,
    CarPack1 =13,
    CarPack2 =14,
    CarPack3 =15,
    NosChargesLevel1 = 16,
    NosChargesLevel2 = 17,
    NosChargesLevel3 = 18,
    NosPriceLevel1 = 19,
    NosPriceLevel2 = 20,
    NosPriceLevel3 = 21,
    ScoreCoefficientLevel1 = 22,
    ScoreCoefficientLevel2 = 23,
    ScoreCoefficientLevel3 = 24,
    GoodIntervalLevel1 = 25,
    GoodIntervalLevel2 = 26,
    GoodIntervalLevel3 = 27,
}


public class IAPManager : MonoBehaviour, IStoreListener
{
    private static IStoreController mStoreController;
    private static IExtensionProvider mStoreExtensionProvider;
    [SerializeField] private List<IAPItem> productDataList;

    public static IAPManager instance;
    public List<IAPItem> ProductDataList => productDataList;

    private ProductIdentifier currentProductIdentifier = ProductIdentifier.None;

    private void InitializePurchasing()
    {
        if (IsInitialized())
        {
            Debug.Log("nu se face build la IAP-uri");
            return;
        }

        InitializeBuilder();
    }

    private void InitializeBuilder()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        productDataList = Resources.LoadAll<IAPItem>(PathLocation.IapItemLocation).ToList();


        foreach (var productData in productDataList)
        {
            builder.AddProduct(productData.ProductId, productData.TypeProduct);
        }

        UnityPurchasing.Initialize(this, builder);
    }

    private bool IsInitialized()
    {
        return mStoreController != null && mStoreExtensionProvider != null;
    }

    public void Buy(ProductIdentifier productIdentifier)
    {
#if UNITY_EDITOR
        IAPItem currentProduct = productDataList.Find(e => e.Identifier == productIdentifier);
           currentProduct.GetReward();
#endif
        
        // if (MontajOption.montajMode)
        // {
        //     IAPItem currentProduct = productDataList.Find(e => e.Identifier == productIdentifier);
        //     currentProduct.GetReward();
        //     
        // }
        // else
        //  {
        string productId = "";
        productId = productDataList.Find(e => e.Identifier == productIdentifier).ProductId;

        currentProductIdentifier = productIdentifier;
        BuyProductID(productId);
        // }
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        //...
        IAPItem currentProduct = null;
        TenjinPurchase.OnProcessPurchase(args);
        Product product = null;

        if (currentProductIdentifier != ProductIdentifier.None)
        {
            currentProduct = productDataList.Find(e => e.Identifier == currentProductIdentifier);
            product = mStoreController.products.WithID(currentProduct.ProductId);
        }
        else
        {
            currentProduct =
                productDataList.Find(e => e.ProductId.Equals(args.purchasedProduct.definition.id));
            product = mStoreController.products.WithID(currentProduct.ProductId);
           
        }


        string receipt = product.receipt;
        string currency = product.metadata.isoCurrencyCode;
        int amount = decimal.ToInt32(product.metadata.localizedPrice * 100);
#if UNITY_ANDROID
        Receipt receiptAndroid = JsonUtility.FromJson<Receipt>(receipt);
        PayloadAndroid receiptPayload = JsonUtility.FromJson<PayloadAndroid>(receiptAndroid.Payload);
      // //  GameAnalytics.NewBusinessEventGooglePlay(currency, amount, currentProduct.Identifier.ToString(),
      //       currentProduct.ProductId,
      //       "IAP_PANEL", receiptPayload.json, receiptPayload.signature);
#endif
#if UNITY_IPHONE
			Receipt receiptiOS = JsonUtility.FromJson<Receipt> (receipt);
			string receiptPayload = receiptiOS.Payload;
			//GameAnalytics.NewBusinessEventIOS (currency, amount, currentProduct.Identifier.ToString(), currentProduct.ProductId, "IAP_PANEL", receiptPayload);
#endif

        currentProduct.GetReward();


        return PurchaseProcessingResult.Complete;
    }

    private void Awake()
    {
        TestSingleton();
    }

    private void Start()
    {
        #if UNITY_EDITOR
        InitializePurchasing();
        #endif
        if (mStoreController == null)
        {
            InitializePurchasing();
        }
    }

    private void TestSingleton()

    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void BuyProductID(string productId)
    {
        if (IsInitialized())
        {
            Product product = mStoreController.products.WithID(productId);

            if (product is {availableToPurchase: true})
            {
                Debug.Log($"Purchasing product asynchronously: '{product.definition.id}'");
                mStoreController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log(
                    "BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }

    public void RestorePurchases()
    {
        currentProductIdentifier = ProductIdentifier.None;
        if (!IsInitialized())
        {
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            Debug.Log("RestorePurchases started ...");

            var apple = mStoreExtensionProvider.GetExtension<IAppleExtensions>();
            apple.RestoreTransactions((result) =>
            {
                Debug.Log("RestorePurchases continuing: " + result +
                          ". If no further messages, no purchases available to restore.");

                // MenuManager.OpenScreen?.Invoke(MenuType.None,
                //     result ? PopUpType.RestoreSuccess : PopUpType.RestoreFail, false);
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
        mStoreController = controller;
        mStoreExtensionProvider = extensions;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(
            $"OnPurchaseFailed: FAIL. Product: '{product.definition.storeSpecificId}', PurchaseFailureReason: {failureReason}");
    }
}