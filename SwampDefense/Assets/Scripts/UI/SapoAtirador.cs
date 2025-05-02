using UnityEngine;
using System.Collections.Generic;

public class SapoAtirador : MonoBehaviour
{
    public float tempoEntreAtaques = 1f;
    public int dano = 10;
    private float contador;
    private List<GameObject> inimigosNoAlcance = new List<GameObject>();

    void Update()
    {
        contador -= Time.deltaTime;

        if (inimigosNoAlcance.Count > 0 && contador <= 0f)
        {
            Atacar(inimigosNoAlcance[0]); // ataca o primeiro inimigo
            contador = tempoEntreAtaques;
        }
    }

    private void Atacar(GameObject inimigo)
    {
        if (inimigo != null)
        {
            MoscaVida vida = inimigo.GetComponent<MoscaVida>();
            if (vida != null)
            {
                vida.ReceberDano(dano);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            inimigosNoAlcance.Add(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            inimigosNoAlcance.Remove(other.gameObject);
        }
    }
}
