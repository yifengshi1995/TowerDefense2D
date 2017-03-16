using UnityEngine;
using UnityEngine.UI;

public class RangedPlace : MonoBehaviour {

    public GameObject tower = null;
    private Image panel;

    void Start()
    {
        panel = GameObject.Find("RangedBuilderUI").GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RightClick();
        }
    }

	void OnMouseDown()
    {
        if(tower == null && !Player.panelOn)
        {
            panel.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, panel.transform.position.z);
            panel.GetComponent<BuildManager>().setRangedPlace(this);
            panel.enabled = true;
            Player.panelOn = true;
        }
    }

    void RightClick()
    {
        if (Player.panelOn)
        {
            panel.enabled = false;
            Player.panelOn = false;
        }
    }

    public void RemoveTower()
    {
        Destroy(tower);
    }
}
