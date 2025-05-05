using UnityEngine;
using System.Collections;

public class MoscaVida : MonoBehaviour
{
    public float vida = 100f;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool jaMorreu = false;
    private Color corOriginal;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        vida *= WavesConfig.main.waves[WavesConfig.main.waveAtual].boost;
        animator = GetComponent<Animator>();

        if (spriteRenderer != null)
        {
            corOriginal = spriteRenderer.color;
        }
    }

    public void ReceberDano(float dano)
    {

        if (jaMorreu) return;

        vida -= dano;

        if (spriteRenderer != null)
        {
            StopAllCoroutines(); // Evita piscar errado se levar vários danos seguidos
            StartCoroutine(DanoFlash());
        }

        if (vida <= 0)
        {
            Morrer();
        }
    }

    private IEnumerator DanoFlash()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f); // Pisca vermelho por 0.1s
        spriteRenderer.color = corOriginal;
    }

    void Morrer()
    {

        jaMorreu = true;

        if (animator != null)
        {
            animator.SetBool("Morta", true);
        }

        // Destroi o objeto depois de um tempo (ex: após a animação de morte)
        Destroy(gameObject, 1f); // Ajuste esse tempo conforme a duração da animação
    }
}
