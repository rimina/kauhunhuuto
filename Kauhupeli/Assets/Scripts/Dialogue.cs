﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

	public GameObject dialogBox;
	public Text dialogText;
	public string dialog;
	public bool dialogActive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Npc"))
		{
			Debug.Log("Clickety Click");
		}
	}
}
