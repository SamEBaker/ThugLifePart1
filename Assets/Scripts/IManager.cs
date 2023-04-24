using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManager
{
	string state { get; set; }
	void Initialize();
}

