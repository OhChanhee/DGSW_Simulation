


﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {	
	enum State{		Ready,		Play,		GameOver	
	}	State state;  //게임 상태를 관리하기 위한 변수	
	int score;	
	public HumanController human;  //human 오브젝트 연결을 위한 변수	
	public GameObject snows;        //snows 오브젝트 연결을 위한 변수	
	public Text scoreLabel;           //UI scoreLabel 연결을 위한 변수	
	public Text stateLabel;            //UI stateLabel 연결을 위한 변수		
	void Start () {		
		Ready ();		
	}	
	void LateUpdate(){		
		switch (state) {		
		case State.Ready:			
			if (Input.GetButtonDown ("Fire1")) //Ready상태에서 화면 클릭한 경우				
				GameStart ();			
			break;		
		case State.Play:			
			if (human.IsDead ()) //게임 시작 중 캐릭터가 죽은 경우				
				GameOver ();			
			break;		
		case State.GameOver:			
			if (Input.GetButtonDown ("Fire1")) //게임이 종료된 후 다시 클릭했을 경우				
				Reload ();			
			break;		
		}	
	}	
	void Ready(){   // 게임 준비 상태		
		state = State.Ready;   //게임의 상태변수 state를 Ready로 변경		
		snows.SetActive (false);   //snows 오브젝트를 비활성화 한다.		
		scoreLabel.text = "Score : " + 0;   //scoreLabel 설정		
		stateLabel.gameObject.SetActive (true);    //stateLabel 활성화		
		stateLabel.text = "READY";  //stateLabel 설정
	}	void GameStart(){  //게임 시작 상태		
		state = State.Play;		
		snows.SetActive (true);			
		stateLabel.gameObject.SetActive (false);		
		stateLabel.text = "";	
	}	
	void GameOver(){  //게임 종료 상태		
		state = State.GameOver;		
		ScrollObject[] scrollObjects = GameObject.FindObjectsOfType<ScrollObject> ();                //Scene에 존재하는 ScrollObject를 모두 보관		
		foreach (ScrollObject so in scrollObjects)			
			so.enabled = false;                // 모든 ScrollObject를 비활성화한다.
		snows.SetActive (false);		
		stateLabel.gameObject.SetActive (true);		
		stateLabel.text = "GAME OVER";	
	}	
	void Reload(){		
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);	
	}	
	public void IncreaseScore(){
		if(!human.IsDead())
			score++;		
		scoreLabel.text = "Score : " + score;	
	}
}
