using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlPanel : MonoBehaviour {

    public static ControlPanel cpinstance;

    BuildManager buildManager;

    public static Button[] towers;
    public bool activated;
    public GameObject sprite = null;

    void Update()
    {
        if(sprite != null)
        {
            Vector3 temp = sprite.transform.position;
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 4;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            temp.x = mousePosition.x;
            temp.y = mousePosition.y;
            temp.z = -6;
            sprite.transform.position = temp;
        }
    }

    void Awake()
    {
        if (cpinstance != null)
        {
            Debug.LogError("More than one ControlPanel in scene!");
        }
        cpinstance = this;
    }

    public void ActivateRanged()
    {
        cpinstance.gameObject.SetActive(true);
        for (int i = 0; i < towers.Length; i++)
        {
            if (towers[i].tag == "RangedTower")
                towers[i].gameObject.SetActive(true);
        }
        activated = true;
    }

    public void ActivateMelee()
    {
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
        buildManager.setTurretToBuild(buildManager.ArrowTowerPrefab);
        InstantiateSprite(buildManager.ArrowTowerPrefab);
    }

    public void SelectShielder()
    {
        buildManager.setTurretToBuild(buildManager.ShielderPrefab);
        InstantiateSprite(buildManager.ShielderPrefab);
    }

    void InstantiateSprite(GameObject prefab)
    {
        sprite = new GameObject("temp sprite");
        SpriteRenderer r = sprite.AddComponent<SpriteRenderer>();
        r.sprite = prefab.GetComponent<SpriteRenderer>().sprite;
    }
}
