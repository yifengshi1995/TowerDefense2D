using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public static int life;
    public static int costA;
    public static int costB;

    public int startLife;
    public int startA;
    public int startB;

    public static bool panelOn;

    void Start()
    {
        life = startLife;
        costA = startA;
        costB = startB;
        panelOn = false;
        GameObject.Find("RangedBuilderUI").GetComponent<Image>().enabled = false;
    }
}
