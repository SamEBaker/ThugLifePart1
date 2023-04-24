using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior4 : MonoBehaviour
{
    public GameBehavior gameManager;
	//public GameObject bullet;
	//public float bulletSpeed = 100f;
	public MeshRenderer Slingshot;
	void Start()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
	}
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Player")
		{
			Destroy(this.transform.parent.gameObject);
			Debug.Log("You found better Ammo! You now deal 10 damage!");
			gameManager.Items +=1;
			gameManager.HP += 1;
			PlayerBehavior Player = collision.gameObject.GetComponent<PlayerBehavior>();
			EnemyBehavior Enemy = gameObject.GetComponent<EnemyBehavior>();
			Slingshot.enabled = true;
			GetComponent<AudioSource>().Play();
			gameManager.PrintLootReport();
			Enemy.bulletDamage = 10;
		}
	}
}