using UnityEngine;

public class SapoAtirador : MonoBehaviour
{
    public GameObject projetilPrefab;
    public Transform pontoDisparo; // lugar de onde o projétil sai
    public float tempoEntreTiros = 1f;
    private float cronometro;

    private Transform alvo;

    [SerializeField] private float danoDoProjetil = 1f;
    [SerializeField] private float velocidadeDoProjetil = 5f;


    void Update()
    {
        if (alvo != null)
        {
            cronometro += Time.deltaTime;
            if (cronometro >= tempoEntreTiros)
            {
                Atirar();
                cronometro = 0f;
            }
        }
    }

    void Atirar()
{
    if (projetilPrefab != null && alvo != null)
    {
        GameObject novoProjetil = Instantiate(projetilPrefab, pontoDisparo.position, Quaternion.identity);
        Projetil proj = novoProjetil.GetComponent<Projetil>();
        if (proj != null)
        {
            proj.SetAlvo(alvo);
            proj.dano = danoDoProjetil;
            proj.velocidade = velocidadeDoProjetil;
        }
    }
}




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            alvo = collision.transform;
            cronometro = tempoEntreTiros; // força o pro tiro atirar na hr
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && collision.transform == alvo)
        {
            alvo = null;
        }
    }
}
