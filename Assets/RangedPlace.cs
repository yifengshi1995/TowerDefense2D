using UnityEngine;
using System.Collections;

public class RangedPlace : MonoBehaviour {

    ControlPanel cp;

    void Start()
    {
        cp = ControlPanel.cpinstance;
    }

	void OnMouseDown()
    {
        if (!cp.activated)
            cp.ActivateRanged();
        if (cp.sprite != null)
        {
            Instantiate(BuildManager.instance.GetTurretToBuild(), transform.position, transform.rotation);
            Destroy(cp.sprite);
            cp.Deactivate();
            return;
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(cp.sprite != null)
            {
                Destroy(cp.sprite);
                return;
            }
            else
            {
                cp.Deactivate();
            }
        }
    }
}
