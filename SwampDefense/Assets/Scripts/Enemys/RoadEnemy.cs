using UnityEngine;

public class RoadEnemy : MonoBehaviour
{
    public static RoadEnemy main;

    public Transform start;
    public Transform[] points;

    private void Awake()
    {
        main = this;
    }
}
