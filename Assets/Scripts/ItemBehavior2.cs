using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior2 : MonoBehaviour
{
	public GameBehavior gameManager;
	void Start()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Player")
		{
			Destroy(this.transform.parent.gameObject);
			Debug.Log("You found $20!");
			PlayerBehavior Player = collision.gameObject.GetComponent<PlayerBehavior>();
			gameManager.Items += 1;
			gameManager.HP += 1;
			gameManager.PrintLootReport();
			GetComponent<AudioSource>().Play();
		}
	}
}