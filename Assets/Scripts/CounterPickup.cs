using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterPickup : MonoBehaviour
{
    public GameBehavior gameManager;
    public Text pickupText;
    void Update()
    {
        pickupText.text = gameManager.Items.ToString("");
    }
}
