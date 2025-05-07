using UnityEngine;

public class Final : MonoBehaviour
{
    private GameManager gm;

    private void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            if (gm != null)
                gm.PerderVida();
        }
    }
}
