using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusDisplay : MonoBehaviour {

    public static StatusDisplay instance;

    private GameObject towerToDisplay = null;

    public Text towerName;
    public Text hpDmg;
    public Text dmgRange;
    public Text def;
    public Text block;

	// Use this for initialization
	void Start () {
		
	}

    void OnEnable()
    {
        instance = this;
    }
	
	// Update is called once per frame
	void Update () {

        if(towerToDisplay != null) 
        {
            if(towerToDisplay.tag == "MeleeTower")
            {
                towerName.text = towerToDisplay.GetComponent<MeleeTower>().towerName;
                hpDmg.text = towerToDisplay.GetComponent<MeleeTower>().getCurrentHp().ToString() + "/" + towerToDisplay.GetComponent<MeleeTower>().maxHp.ToString();
                dmgRange.text = "DMG: " + towerToDisplay.GetComponent<MeleeTower>().dmg.ToString();
                def.text = "DEF: " + towerToDisplay.GetComponent<MeleeTower>().def.ToString();
                block.text = "BLOCK: " + towerToDisplay.GetComponent<MeleeTower>().maxBlock.ToString();
            }     
        }
        else
        {
            towerName.text = null;
            hpDmg.text = null;
            dmgRange.text = null;
            def.text = null;
            block.text = null;
        }
		
	}

    public void setTower(GameObject tower)
    {
        towerToDisplay = tower;
    }


}
