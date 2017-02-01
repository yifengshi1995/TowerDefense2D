using UnityEngine;
using System.Collections;

public class GlobalControl : MonoBehaviour {

    ControlPanel cp;

    void Start()
    {
        cp = ControlPanel.cpinstance;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (cp.sprite != null)
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
