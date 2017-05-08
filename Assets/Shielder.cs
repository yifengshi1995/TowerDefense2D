using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shielder : MeleeTower {

	protected override void Attack(){
		target.gameObject.GetComponent<Enemy>().hp -= dmg;
	}
}
