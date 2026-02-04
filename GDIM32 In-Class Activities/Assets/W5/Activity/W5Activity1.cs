using System.Collections.Generic;
using UnityEngine;

/*

public class W5Activity1 : MonoBehaviour
{
	// You don't need to change Start.
	private void Start()
	{
		List<Item> inventory = new List<Item>()
        {
            new Torch(),
            new ElvenSword(),
            new Axe()
        };
		
		foreach(Item item in inventory) {
			item.Use();
		}
	}
}

// Willow is building a game and needs your help completing this code.
//
// There are 2 parents and 3 child classes in this game.
// IBreakable is an interface which defines objects that can be damaged and broken.
// Item is an abstract class which defines items that the player can use.
// Axe, ElvenSword, and Torch are all Items, but only the Axe and Torch are IBreakables.
// 	(The ElvenSword cannot be broken because... it's magic.)
// 
// Without changing which of these objects are inheriting from Item and IBreakable,
// fix Willow's compiler errors.
//
// Expected output:

// lighting area with torch
// torch now has 0 durability remaining
// torch is broken!
// attacking with Elven sword
// attacking with axe
// axe now has 4 durability remaining

public interface IBreakable {
	void Damage(float damage);
	void Break();
}

public abstract class Item {
	public abstract void Use();
}

public class Axe : Item, IBreakable {
	private float _durability = 5.0f;
	
	public void Damage (float damage) {
		_durability -= damage;
		Debug.Log("axe now has " + _durability + " durability remaining");
		
		if(_durability <= 0) {
			Break();
		}
	}
	
	public override void Use () {
		Debug.Log("attacking with axe");
		Damage(1.0f);
	}
}

public class ElvenSword : Item {
	public void Use () {
		Debug.Log("attacking with Elven sword");
	}
}

public class Torch : Item, IBreakable {
	
	public void Damage (float damage) {
		_durability -= damage;
		Debug.Log("torch now has " + _durability + " durability remaining");
		
		if(_durability <= 0) {
			Break();
		}
	}
	
	public void BreakItem () {
		Debug.Log("torch is broken!");
	}
	
	protected override void Use () {
		Debug.Log("lighting area with torch");
		Damage(1.0f);
	}
}

*/