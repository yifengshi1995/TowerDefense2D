using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    [Header("Ranged Tower Prefabs")]
    public GameObject ArrowTowerPrefab;
    public GameObject ExplosionTowerPrefab;
    public GameObject SlowTowerPrefab;

    [Header("Melee Tower Prefabs")]
    public GameObject ShielderPrefab;
    

    private GameObject turretToBuild = null;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
        }
        instance = this;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void setTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }

    public void clearTurretToBuild()
    {
        turretToBuild = null;
    }
}
