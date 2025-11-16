using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("player"))
        {
            if (MoneyUI.Instance.moneyCount >= 30)
            {
                GameClear_UI.Instance.ShowGameClear();
            }
            else
            {
                EscapeTry_UI.Instance.ShowTryFailed();
            }
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("player"))
        {
            EscapeTry_UI.Instance.HideTryFailled();
        }
    }
}
