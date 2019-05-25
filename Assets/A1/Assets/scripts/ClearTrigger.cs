
﻿using UnityEngine;
using System.Collections;
public class ClearTrigger : MonoBehaviour {	
	GameObject gameController;	// Use this for initialization	
	void Start () {		
		gameController = GameObject.FindWithTag ("GameController");
		//게임오브젝트 중에서 Tag가 GameController인 오브젝트를 찾아 
		//gameController변수에 보관한다.	
	}	
	void OnTriggerEnter2D(Collider2D other){ 
		//Trigger에 오브젝트가 진입시
		gameController.SendMessage ("IncreaseScore");  //보관하고 있는          
		//GameController의 IncreaseScore메소드를 호출한다.	
	}
}
