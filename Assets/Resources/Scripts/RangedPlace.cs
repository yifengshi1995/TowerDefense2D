using UnityEngine;
using System.Collections;

public class RangedPlace : MonoBehaviour {

    private GameObject tower = null;


    void Start()
    {

    }

	void OnMouseDown()
    {
    }

    public void BuildTower(GameObject t)
    {

    }

    public void RemoveTower()
    {
        Destroy(tower);
    }
}
