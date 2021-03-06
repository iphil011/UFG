using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharSel : MonoBehaviour {
	public RectTransform navigator1;
	int nav1Pos = 0;
	public RectTransform navigator2;
	int nav2Pos = 0;

	public RectTransform[] slots = new RectTransform[2];
	public int jumpAmount = 2;
	public Text textShowNav1;
	public Text textShowNav2;
	void Start(){
		MoveNav1(0);
		MoveNav2(0);
	}
	void Update () {
		
		//Load the Different Matchup Scenes
		if(Input.GetKeyDown(KeyCode.KeypadEnter)){
			if(nav1Pos == 0 && nav2Pos == 0){
				Application.LoadLevel (Application.loadedLevel + 1);
			}

			if(nav1Pos == 0 && nav2Pos == 1){
				Application.LoadLevel (Application.loadedLevel + 2);
			}

			if(nav1Pos == 1 && nav2Pos == 0){
				Application.LoadLevel (Application.loadedLevel + 3);
			}

			if(nav1Pos == 1 && nav2Pos == 1){
				Application.LoadLevel (Application.loadedLevel + 4);
			}
		}

		if(Input.GetKeyDown(KeyCode.Return)){
			if(nav1Pos == 0 && nav2Pos == 0){
				Application.LoadLevel (Application.loadedLevel + 1);
			}

			if(nav1Pos == 0 && nav2Pos == 1){
				Application.LoadLevel (Application.loadedLevel + 2);
			}

			if(nav1Pos == 1 && nav2Pos == 0){
				Application.LoadLevel (Application.loadedLevel + 3);
			}

			if(nav1Pos == 1 && nav2Pos == 1){
				Application.LoadLevel (Application.loadedLevel + 4);
			}
		}


			
			
		// move up
		if(Input.GetKeyDown(KeyCode.W)){
			MoveNav1(-jumpAmount);
		}
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			MoveNav2(-jumpAmount);
		}

		if(Input.GetKeyDown(KeyCode.A)){
			MoveNav1(-1);
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			MoveNav2(-1);
		}

		if(Input.GetKeyDown(KeyCode.S)){
			MoveNav1(jumpAmount);
		}
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			MoveNav2(jumpAmount);
		}

		if(Input.GetKeyDown(KeyCode.D)){
			MoveNav1(1);
		}
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			MoveNav2(1);
		}
	}

	void MoveNav1(int change){
		if(change > 0){
			if(nav1Pos+change < slots.Length-1){
				nav1Pos += change;
			}else{
				nav1Pos = slots.Length-1;
			}
		}else{
			if(nav1Pos+change >= 0){
				nav1Pos += change;
			}else{
				nav1Pos = 0;
			}
		}
		navigator1.position = slots[nav1Pos].position;
		textShowNav1.text = "P1 "; //+ nav1Pos;
	}

	void MoveNav2(int change){
		if(change > 0){
			if(nav2Pos+change < slots.Length-1){
				nav2Pos += change;
			}else{
				nav2Pos = slots.Length-1;
			}
		}else{
			if(nav2Pos+change >= 0){
				nav2Pos += change;
			}else{
				nav2Pos = 0;
			}
		}
		navigator2.position = slots[nav2Pos].position;
		textShowNav2.text = "P2 "; //+ nav2Pos;
	}
}