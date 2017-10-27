using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

	public GameObject player;
	public GameObject eventSystem;
	public GameObject startUI, restartUI;
	public GameObject startPoint, playPoint, restartPoint;
	public GameObject shark, dolphin, golden_fish, colored_fish,Marlinfish;
	public GameObject sharkCanvas, dolphinCanvas, golden_fishCanvas, colored_fishCanvas,MarlinfishCanvas;
	public AudioSource Shark, marlin, Dolphin, colored, golden;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}


	public void startPuzzle() { //Begin the puzzle sequence
		//Generate a random number one through five, save it in an array.  Do this n times.
		//Step through the array for displaying the puzzle, and checking puzzle failure or success.
		startUI.SetActive (false);
		iTween.MoveTo (player, playPoint.transform.position, 5f);
	}



	public void return_center(){
		iTween.MoveTo (player, playPoint.transform.position, 5f);
		sharkCanvas.SetActive (false);
		dolphinCanvas.SetActive (false);
		golden_fishCanvas.SetActive (false);
		colored_fishCanvas.SetActive (false);
		MarlinfishCanvas.SetActive (false);
		//killer_whaleCanvas.SetActive (false);
	}

	public void restart_Game(){
		iTween.MoveTo (player, startPoint.transform.position, 5f);
		startUI.SetActive (true);
	}

	public void go_to_shark(){
		iTween.MoveTo (player, shark.transform.position, 5f);
		sharkCanvas.SetActive (true);
		Shark.PlayDelayed (2.0f);
	}

	public void go_to_dolphin(){
		iTween.MoveTo (player, dolphin.transform.position, 5f);
		dolphinCanvas.SetActive (true);
		Dolphin.PlayDelayed (2.0f);
	}

	public void go_to_goldenFish(){
		iTween.MoveTo (player, golden_fish.transform.position, 5f);
		golden_fishCanvas.SetActive (true);
		golden.PlayDelayed (2.0f);
	}

	public void go_to_colored_Fish(){
		iTween.MoveTo (player, colored_fish.transform.position, 5f);
		colored_fishCanvas.SetActive (true);
		colored.PlayDelayed (2.0f);
	}


	public void go_to_marlinfish(){
		iTween.MoveTo (player, Marlinfish.transform.position, 5f);
		MarlinfishCanvas.SetActive (true);
		marlin.PlayDelayed (2.0f);
	}

	/*
	public void go_to_killerWhale(){
		iTween.MoveTo (player, killer_whale.transform.position, 5f);
		killer_whaleCanvas.SetActive (true);
	}*/
		

}