using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HumanController : MonoBehaviour { 
	bool flag;  //캐릭터의 움직이는 방향을 설정하는 파라미터 
	bool isDead;  //캐릭터가 죽었는지 살았는지 판단하는 파라미터 
	public float speed;  //캐릭터 이동 속도 
	public float right;  //우측 최댓값 
	public float left;   //좌측 최댓값 
	// Use this for initialization 
	void Awake(){  
		isDead = false;  
		flag = false; 
	}  
	// Update is called once per frame 
	void Update () {  
		if (isDead == true)   
			return;  
		if (Input.GetButtonDown ("Fire1")) {  //클릭 했을 때   
			flag = !flag;  //좌우반전  
			if (flag == true) 
				transform.localRotation = Quaternion.Euler (0.0f, -180.0f, 0.0f);   
			else
				transform.localRotation =  Quaternion.Euler (0.0f, 0.0f, 0.0f);
			transform.Translate(1 * speed * Time.deltaTime, 0.0f, 0.0f);
		}

		if(transform.position.x > left && transform.position.x < right)
			transform.Translate(1 * speed * Time.deltaTime, 0.0f, 0.0f);
	} 
	public bool IsDead(){  //캐릭터의 생존여부를 확인하기 위한 함수  
		return isDead; 
	} 
	void OnCollisionEnter2D (Collision2D collision){ //충돌이 발생한 경우 호출  //캐릭터가 눈송이에 충돌한 경우 쓰러지게함.
		if (flag == true)   
			transform.localRotation = Quaternion.Euler (0.0f, 0.0f, -90.0f);  
		else   
			transform.localRotation = Quaternion.Euler (0.0f, 0.0f, 90.0f);    
		if (isDead)   
			return;

		//눈송이에 충돌시 isDead 값을 true로 변경  
		isDead = true; 
	}
} 
