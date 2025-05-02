using UnityEngine;

public class MoscaVida : MonoBehaviour
{
    public int vida = 100;

    public void ReceberDano(int dano)
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
