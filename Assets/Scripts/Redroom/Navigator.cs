using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Navigator : MonoBehaviour
{
    public GameObject[] sprites;


	public void Enable(string Sprites, bool enabled)
	{
		SpriteRenderer s = Array.Find(sprites, gameObject => gameObject.name == Sprites).GetComponent<SpriteRenderer>();
		if (s == null)
		{
			Debug.LogWarning("Sprite: " + Sprites + " not found!");
			return;
		}

		s.enabled = enabled;
	}

}
