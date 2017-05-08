using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour {
    
    private GameObject towerToBuild = null;
    private string panelName;
    private BuildArea buildArea;
    
    void Start()
    {
        panelName = transform.name;
    }

    public GameObject GettowerToBuild()
    {
        return towerToBuild;
    }

    public void setBuildArea(BuildArea place)
    {
        buildArea = place;
    }

    public void LeftButton()
    {
        if(panelName == "RangedBuilderUI")
        {
            towerToBuild = Resources.Load("Prefabs/ArrowTower") as GameObject;
            buildArea.setTower(Instantiate(towerToBuild, new Vector3(transform.position.x, transform.position.y, -6), transform.rotation));
            Player.panelOn = false;
            GetComponent<Image>().enabled = false;
        }
        else if(panelName == "MeleeBuilderUI")
        {
            towerToBuild = Resources.Load("Prefabs/Commander") as GameObject;
            buildArea.setTower(Instantiate(towerToBuild, new Vector3(transform.position.x, transform.position.y, -6), transform.rotation));
            Player.panelOn = false;
            GetComponent<Image>().enabled = false;
        }
        else if(panelName == "UpgraderUI")
        {

        }

		
    }

    public void UpButton()
    {
        if (panelName == "RangedBuilderUI")
        {
            towerToBuild = Resources.Load("Prefabs/ExplosionTower") as GameObject;
            buildArea.setTower(Instantiate(towerToBuild, new Vector3(transform.position.x, transform.position.y, -6), transform.rotation));
            Player.panelOn = false;
            GetComponent<Image>().enabled = false;
        }
        else if (panelName == "MeleeBuilderUI")
        {
			towerToBuild = Resources.Load("Prefabs/Shielder") as GameObject;
            buildArea.setTower(Instantiate(towerToBuild, new Vector3(transform.position.x, transform.position.y, -6), transform.rotation));
            Player.panelOn = false;
            GetComponent<Image>().enabled = false;
        }
        else if (panelName == "UpgraderUI")
        {

        }

		
    }

    public void RightButton()
    {
        if (panelName == "RangedBuilderUI")
        {
            towerToBuild = Resources.Load("Prefabs/SlowTower") as GameObject;
            buildArea.setTower(Instantiate(towerToBuild, new Vector3(transform.position.x, transform.position.y, -6), transform.rotation));
            Player.panelOn = false;
            GetComponent<Image>().enabled = false;
        }
        else if (panelName == "MeleeBuilderUI")
        {

        }
        else if (panelName == "UpgraderUI")
        {

        }
    }

    public void DownButton()
    {
        if (panelName == "RangedBuilderUI")
        {

        }
        else if (panelName == "MeleeBuilderUI")
        {

        }
        else if (panelName == "UpgraderUI")
        {

        }
    }
}
