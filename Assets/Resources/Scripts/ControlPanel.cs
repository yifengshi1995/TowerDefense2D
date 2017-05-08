using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlPanel : MonoBehaviour {

    public static ControlPanel cpinstance;

    public static Button[] towers;
    public bool activated;

    void Update()
    {

    }

    void Awake()
    {
        if (cpinstance != null)
        {
            Debug.LogError("More than one ControlPanel in scene!");
        }
        cpinstance = this;
    }

    void Start()
    {

    }
}
