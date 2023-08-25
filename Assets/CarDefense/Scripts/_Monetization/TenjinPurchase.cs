
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.MiniJSON;

public static class TenjinPurchase
{

    public static void OnProcessPurchase(PurchaseEventArgs purchaseEventArgs)
    {
        var price = purchaseEventArgs.purchasedProduct.metadata.localizedPrice;
        double lPrice = decimal.ToDouble(price);
        var currencyCode = purchaseEventArgs.purchasedProduct.metadata.isoCurrencyCode;

        var wrapper = Json.Deserialize(purchaseEventArgs.purchasedProduct.receipt) as Dictionary<string, object>;  // https://gist.github.com/darktable/1411710
        if (null == wrapper)
        {
            return;
        }

        var payload = (string)wrapper["Payload"]; // For Apple this will be the base64 encoded ASN.1 receipt
        var productId = purchaseEventArgs.purchasedProduct.definition.id;

#if UNITY_ANDROID

        var gpDetails = Json.Deserialize(payload) as Dictionary<string, object>;
        var gpJson = (string)gpDetails["json"];
        var gpSig = (string)gpDetails["signature"];

        CompletedAndroidPurchase(productId, currencyCode, 1, lPrice, gpJson, gpSig);

#elif UNITY_IOS

  var transactionId = purchaseEventArgs.purchasedProduct.transactionID;

  CompletedIosPurchase(productId, currencyCode, 1, lPrice , transactionId, payload);

#endif

    }

    private static void CompletedAndroidPurchase(string ProductId, string CurrencyCode, int Quantity, double UnitPrice, string Receipt, string Signature)
    {
        BaseTenjin instance = Tenjin.getInstance("WQYKOCJS31BW5JTCFZPMZREWMWSAIWHE");
        instance.Transaction(ProductId, CurrencyCode, Quantity, UnitPrice, null, Receipt, Signature);
    }

    private static void CompletedIosPurchase(string ProductId, string CurrencyCode, int Quantity, double UnitPrice, string TransactionId, string Receipt)
    {
        BaseTenjin instance = Tenjin.getInstance("WQYKOCJS31BW5JTCFZPMZREWMWSAIWHE");
        instance.Transaction(ProductId, CurrencyCode, Quantity, UnitPrice, TransactionId, Receipt, null);
    }

}