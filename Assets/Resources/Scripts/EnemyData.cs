public class EnemyData
{
    private int index;
    private float waitTime;
    private string name;

    public EnemyData(int _index, string _name, float _waitTime)
    {
        index = _index;
        name = _name;
        waitTime = _waitTime;
    }

    public int getIndex()
    {
        return index;
    }

    public float getWaitTime()
    {
        return waitTime;
    }

    public string getName()
    {
        return name;
    }
}
