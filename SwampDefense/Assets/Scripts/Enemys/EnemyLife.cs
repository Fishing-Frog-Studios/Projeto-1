using UnityEngine;

public class MoscaVida : MonoBehaviour
{
    public float vida = 100f;

    public void ReceberDano(float dano)
    {
        vida -= dano;

        if (vida <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        Destroy(gameObject);
    }
}
