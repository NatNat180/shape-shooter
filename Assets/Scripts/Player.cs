using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private int health;
	private int score;

	public int Health
	{
		get { return health; }
		set { health = value; }
	}

	public int Score
	{
		get { return score; }
		set { score = value; }
	}
	
}
