using UnityEngine;

public class Projetil : MonoBehaviour
{
    public float dano = 1f;
    private Transform alvo;
    public float velocidade = 5f;

    

    public void SetAlvo(Transform inimigo)
    {
        alvo = inimigo;
    }

    void Update()
    {
        if (alvo == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 direcao = (alvo.position - transform.position).normalized;
        transform.position += (Vector3)direcao * velocidade * Time.deltaTime;

        if (Vector2.Distance(transform.position, alvo.position) < 0.2f)
        {
            if (alvo.TryGetComponent(out EnemyMove life))
            {
                life.ReceberDano(dano);
            }

            Destroy(gameObject); // destrói o projétil ao acertar
        }
    }
}
