using UnityEngine;
using UnityEngine.UI;

public class DamageTake : MonoBehaviour {

    public Text lifePoint;
    public Text gameOverText;
    private bool gameover = false;

    void Update()
    {
        lifePoint.text = Player.life.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Player.life -= 1;
        }
        
        if(Player.life <= 0 && !gameover)
        {
            gameover = true;

        }
    }

    void Start()
    {
        lifePoint.text = Player.life.ToString();
    }
}
