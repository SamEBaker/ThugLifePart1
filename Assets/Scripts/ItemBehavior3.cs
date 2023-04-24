using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior3 : MonoBehaviour
{
	public GameBehavior gameManager;
	//private GameObject Hat;
	public MeshRenderer Hat;

	void Start()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
	}
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Player")
		{
			Destroy(this.transform.parent.gameObject);
			Debug.Log("Disguise Added");
			gameManager.Items += 1;
			gameManager.HP += 1;
			GetComponent<AudioSource>().Play();
			PlayerBehavior Player = collision.gameObject.GetComponent<PlayerBehavior>();
			Hat.enabled = true;
			gameManager.PrintLootReport();
		}
	}
}
