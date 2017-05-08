using UnityEngine;
using UnityEngine.UI;

public class BuildArea : MonoBehaviour
{
    public string panelName;
    private GameObject tower = null;
    private Image panel;

    void Start()
    {
        panel = GameObject.Find(panelName).GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RightClick();
        }

        if (tower == null)
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -7);
        else
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -5);
    }

    public void setTower(GameObject t)
    {
        tower = t;
    }

    void OnMouseDown()
    {
        if (tower == null && !Player.panelOn)
        {
            panel.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, panel.transform.position.z);
            panel.GetComponent<BuildManager>().setBuildArea(this);
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
