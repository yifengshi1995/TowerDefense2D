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

    void Start()
    {
        life = startLife;
        costA = startA;
        costB = startB;
    }
}
