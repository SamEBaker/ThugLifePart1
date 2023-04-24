using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
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
			Debug.Log("Speed Boost!");
			PlayerBehavior Player = collision.gameObject.GetComponent<PlayerBehavior>();
			Player._moveSpeed += 15;
			gameManager.Items += 1;
			gameManager.HP += 1;
			GetComponent<AudioSource>().Play();
			gameManager.PrintLootReport();
		}
	}
}