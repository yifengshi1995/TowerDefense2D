using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;
    
    private GameObject towerToBuild = null;
    private string panelName;
    private RangedPlace rangedPlace;
	private MeleePlace meleePlace;
    
    void Start()
    {
        panelName = transform.name;
    }

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
        }
        instance = this;
    }

    public GameObject GettowerToBuild()
    {
        return towerToBuild;
    }

    public void setRangedPlace(RangedPlace place)
    {
		rangedPlace = place;
    }

	public void setMeleePlace(MeleePlace place)
	{
		meleePlace = place;
	}

    public void LeftButton()
    {
        if(panelName == "RangedBuilderUI")
        {
            towerToBuild = Resources.Load("Prefabs/ArrowTower") as GameObject;
        }
        else if(panelName == "MeleeBuilderUI")
        {
            //towerToBuild = GameObject.Find("Commander").GetComponent<GameObject>();
        }
        else if(panelName == "UpgraderUI")
        {

        }

		Instantiate(towerToBuild, transform.position, transform.rotation);
		Player.panelOn = false;
		currentPlace.tower = towerToBuild;
		GetComponent<Image>().enabled = false;
    }

    public void UpButton()
    {
        if (panelName == "RangedBuilderUI")
        {
            towerToBuild = Resources.Load("Prefabs/ExplosionTower") as GameObject;     
        }
        else if (panelName == "MeleeBuilderUI")
        {
			towerToBuild = Resources.Load("Prefabs/Shielder") as GameObject;
        }
        else if (panelName == "UpgraderUI")
        {

        }

		Instantiate(towerToBuild, transform.position, transform.rotation);
		Player.panelOn = false;
		currentPlace.tower = towerToBuild;
		GetComponent<Image>().enabled = false;
    }

    public void RightButton()
    {
        if (panelName == "RangedBuilderUI")
        {
            towerToBuild = Resources.Load("Prefabs/SlowTower") as GameObject;
            Instantiate(towerToBuild, transform.position, transform.rotation);
            Player.panelOn = false;
            currentPlace.tower = towerToBuild;
            GetComponent<Image>().enabled = false;
        }
        else if (panelName == "MeleeBuilderUI")
        {
            //towerToBuild = GameObject.Find("Commander").GetComponent<GameObject>();
        }
        else if (panelName == "UpgraderUI")
        {

        }
    }

    public void DownButton()
    {
        if (panelName == "RangedBuilderUI")
        {
            /**
            towerToBuild = Resources.Load("Prefabs/ArrowTower") as GameObject;
            Instantiate(towerToBuild, transform.position, transform.rotation);
            Player.panelOn = false;
            currentPlace.tower = towerToBuild;
            GetComponent<Image>().enabled = false;
             **/
        }
        else if (panelName == "MeleeBuilderUI")
        {
            //towerToBuild = GameObject.Find("Commander").GetComponent<GameObject>();
        }
        else if (panelName == "UpgraderUI")
        {

        }
    }
}
