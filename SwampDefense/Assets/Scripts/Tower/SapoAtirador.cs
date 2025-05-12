using UnityEngine;

public class SapoAtirador : MonoBehaviour
{

    private Animator animator;
    public GameObject projetilPrefab;
    public Transform pontoDisparo; // lugar de onde o projétil sai
    public float tempoEntreTiros = 1f;
    private float cronometro;

    private Transform alvo;

    [SerializeField] private float danoDoProjetil = 1f;
    [SerializeField] private float velocidadeDoProjetil = 5f;


    private System.Collections.IEnumerator VoltarParaIdle()
    {
    yield return new WaitForSeconds(0.3f); // tempo da animação de ataque
    if (animator != null)
        animator.SetBool("Atacando", false);
    }

    void Start()
    {
    animator = GetComponent<Animator>();
    }


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

        if (animator != null){
            animator.SetBool("Atacando", true);
        }

        GameObject novoProjetil = Instantiate(projetilPrefab, pontoDisparo.position, Quaternion.identity);
        Projetil proj = novoProjetil.GetComponent<Projetil>();
        if (proj != null)
        {
            proj.SetAlvo(alvo);
            proj.dano = danoDoProjetil;
            proj.velocidade = velocidadeDoProjetil;
        }

        StartCoroutine(VoltarParaIdle());
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
