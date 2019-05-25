
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour {
	public GameObject stone;
	public GameObject start;

	void Start(){
		InvokeRepeating ("CreateObject", 0, 0.3f);
	}
	void CreateObject(){
		int rand = Random.Range (-4, 4);
		Destroy (Instantiate (stone, new Vector3(rand,6,0), stone.transform.rotation), 2);

	}

	void Update(){
		stone.transform.Rotate (0.0f, 0.0f, 90.0f * Time.deltaTime);
	}

}
