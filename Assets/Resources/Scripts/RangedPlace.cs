using UnityEngine;
using System.Collections;

public class RangedPlace : MonoBehaviour {

    ControlPanel cp;
    private GameObject tower = null;


    void Start()
    {
        cp = ControlPanel.cpinstance;
    }

	void OnMouseDown()
    {
        if (tower == null)
            cp.ActivateRanged(this);
        if(tower != null)
        {
            RemoveTower();
        }
    }

    public void BuildTower(GameObject t)
    {
        tower = (GameObject)Instantiate(t, transform.position, transform.rotation);
        cp.Deactivate();
    }

    public void RemoveTower()
    {
        Destroy(tower);
    }
}
