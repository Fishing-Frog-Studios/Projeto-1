using UnityEngine;

public class SapoAtirador4 : MonoBehaviour
{
    public GameObject projetilPrefab;
    public Transform pontoDisparo;
    public float tempoEntreTiros = 1f;
    private float cronometro;

    private Transform alvo;

    [SerializeField] private float danoDoProjetil = 1f;
    [SerializeField] private float velocidadeDoProjetil = 5f;

    public GameObject frenteVisual;
    public GameObject costasVisual;

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

            AtualizarVisual();
        }
    }

    void AtualizarVisual()
{
    if (alvo == null) return;

    Vector2 direcao = alvo.position - transform.position;
    float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;

    // Ativa frente ou costas com base no ângulo
    bool inimigoAcima = angulo > 30f && angulo < 150f; // entre nordeste e noroeste
    frenteVisual.SetActive(!inimigoAcima);
    costasVisual.SetActive(inimigoAcima);

    // Espelha o sprite na horizontal
    float escalaX;

    if (inimigoAcima)
    {
        escalaX = direcao.x < 0 ? 1 : -1; // costas
    }
    else
    {
        escalaX = direcao.x < 0 ? -1 : 1; // frente
    }

    transform.localScale = new Vector3(escalaX, 1, 1);
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
            cronometro = tempoEntreTiros; // <-- força o primeiro tiro imediato
            AtualizarVisual();            // atualiza o sprite na hora
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
