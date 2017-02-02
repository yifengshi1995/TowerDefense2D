using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlPanel : MonoBehaviour {

    public static ControlPanel cpinstance;
    private RangedPlace ranged = null;
    private MeleePlace melee = null;
    private BuildManager buildManager;

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

    public void ActivateRanged(RangedPlace rp)
    {
        ranged = rp;
        cpinstance.gameObject.SetActive(true);
        for (int i = 0; i < towers.Length; i++)
        {
            if (towers[i].tag == "RangedTower")
                towers[i].gameObject.SetActive(true);
        }
        activated = true;
    }

    public void ActivateMelee(MeleePlace mp)
    {
        melee = mp;
        cpinstance.gameObject.SetActive(true);
        for (int i = 0; i < towers.Length; i++)
        {
            if (towers[i].tag == "MeleeTower")
                towers[i].gameObject.SetActive(true);
        }
        activated = true;
    }

    public void Deactivate()
    {
        cpinstance.gameObject.SetActive(false);
        for(int i = 0; i < towers.Length; i++)
        {
            towers[i].gameObject.SetActive(false);
        }
        activated = false;
    }

    void Start()
    {
        towers = new Button[transform.childCount];
        for(int i = 0; i < towers.Length; i++)
        {
            towers[i] = transform.GetChild(i).GetComponent<Button>();
            towers[i].gameObject.SetActive(false);
        }

        buildManager = BuildManager.instance;

        cpinstance.gameObject.SetActive(false);
        activated = false;
        
    }

    public void SelectArrowTower()
    {
        ranged.BuildTower(buildManager.ArrowTowerPrefab);
    }

    public void SelectShielder()
    {
        melee.BuildTower(buildManager.ShielderPrefab);
    }
}
