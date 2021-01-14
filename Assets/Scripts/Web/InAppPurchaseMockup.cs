using System;
using UnityEngine;
using UnityEngine.Purchasing;

namespace Web
{
    [Obsolete("Temponary solution for testing purposes.")]
    public class InAppPurchaseMockup : GUI.AbstractMenuController
    {
        public void OnPurchaseComplete(Product product)
        {
            PlayLevel();
        }

        public void OnPurchaseFailrue(Product product, PurchaseFailureReason reason)
        {
#if UNITY_EDITOR
            Debug.Log("Purchase of " + product + " failed.");
#endif
        }
    }
}
