public class Commander : MeleeTower {

    protected override void Attack()
    {
        target.gameObject.GetComponent<Enemy>().hp -= dmg;
    }
}
