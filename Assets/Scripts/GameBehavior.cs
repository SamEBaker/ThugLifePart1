using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CustomExtensions;

public class GameBehavior : MonoBehaviour
{
	private string _state;
	public string State 
	{
		get {return _state; }
		set { _state = value; }
	}
	public Stack<string> lootStack = new Stack<string>();
    public bool showWinScreen = false;
    public float moveSpeed = 7f;
    public bool showLossScreen = false;
	public delegate void DebugDelegate(string newText);
	public DebugDelegate debug = Print;
	public string labelText = "Objective: Find a disguise and hijack a car!";
    public int maxItems = 5;
	private int _itemsCollected = 0;
	public int Items
    {
	    get { return _itemsCollected; }
		set {
		    _itemsCollected = value;
			if(_itemsCollected >= maxItems)
			{
				showWinScreen = true;
				Time.timeScale = 0f;
			}
			else
			{
				labelText = "Item found, only " + (maxItems - _itemsCollected) 
					+ " more to go!";
			}
		}
    }

    private int _playerHP = 10;
    public int HP
    {	
	    get {return _playerHP; }
		set {
			_playerHP = value;
			if(_playerHP <= 0)
			{
				showLossScreen = true;
				Time.timeScale = 0;
			}
			else if(_playerHP > 10)
			{
				labelText = "Lookin' Nice!";
			}
			else
			{
				labelText = "Ouch!";
			}
		}
	}
	void Start()
	{
		Time.timeScale = 1f;
		Initialize();
		InventoryList<string> inventoryList = new InventoryList<string>();
		inventoryList.SetItem("Cash");
		Debug.Log(inventoryList.item);
	}

	public void Initialize()
	{
		_state = "Manager initialized..";
		_state.FancyDebug();

		debug(_state);
		LogWithDelegate(debug);
		GameObject player = GameObject.Find("Player");
		PlayerBehavior playerBehavior = player.GetComponent<PlayerBehavior>();
		lootStack.Push("Cash");
		lootStack.Push("Police Hat");
		lootStack.Push("Police Uniform");
		lootStack.Push("Soda");
		lootStack.Push("SlingShot");
		lootStack.Push("Car Keys");
	}

	public static void Print(string newText)
	{
		Debug.Log(newText);
	}
	public void LogWithDelegate(DebugDelegate del)
	{
		del("Delegating the debug task...");
	}
    void OnGUI()
    {

		if (showWinScreen)
		{	
		     Cursor.lockState = CursorLockMode.None;
			 Cursor.visible = true;
			 SceneManager.LoadScene(3);
		}
		if (showLossScreen)
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			SceneManager.LoadScene(2);
		}
    }
	public void PrintLootReport()
	{
		var currentItem = lootStack.Pop();
		var nextItem = lootStack.Peek();
		Debug.LogFormat("You got a {0}! You've got a good chance of finding a {1} next!", currentItem, nextItem);
		Debug.LogFormat("There are {0} random loot items waiting for you!", lootStack.Count);
	}
}
