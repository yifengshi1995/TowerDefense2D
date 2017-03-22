using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shielder : MeleeTower {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected override void Attack(){
		target.gameObject.GetComponent<Enemy>().hp -= dmg;
	}
}
