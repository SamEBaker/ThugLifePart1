using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterHealth : MonoBehaviour
{
	public GameBehavior gameManager;
    public Text healthText;

    void Update()
    {
        healthText.text = gameManager.HP.ToString("");
    }
}
