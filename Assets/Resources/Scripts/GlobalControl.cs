using UnityEngine;
using System.Collections;

public class GlobalControl : MonoBehaviour {

    ControlPanel cp;

    void Start()
    {
        cp = ControlPanel.cpinstance;
    }

}
