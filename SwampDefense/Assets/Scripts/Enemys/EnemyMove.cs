
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering.Analytics;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMove : MonoBehaviour
{
    [Header("Referencia")]
    [SerializeField] private Rigidbody2D enemyBox; //caixa de colisão do inimigo

    [Header ("Atributos")]

 
    [SerializeField] private float speed; //velocidade de movimento do inimigo
    [SerializeField] private float life;  // vida do inimigo
    [SerializeField] private int damege;  // dano do inimigo ao chegar no fim da base
    [SerializeField] private int reward;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool jaMorreu = false;
    private Color corOriginal;

    private Transform destiny; //ponto alvo no momento
    private int indexPoint = 0; //numeros do proximo alvo
//    private bool flipSprite;   
    private void Start()
    {
        Reden();
        BaseData();
    }
    private void Update()
    {
        PointMoviment();
    }
    private void FixedUpdate()
    {
        MoveDirection();
        Direction();
    }

    void Reden()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();

        if (spriteRenderer != null)
        {
            corOriginal = spriteRenderer.color;
        }
    }
    public void ReceberDano(float dano)
    {

        if (jaMorreu) return;

        life -= dano;

        if (spriteRenderer != null)
        {
            StopAllCoroutines(); // Evita piscar errado se levar vários danos seguidos
            StartCoroutine(DanoFlash());
        }

        if (life <= 0)
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

    void BaseData()
    {
        speed *= WavesConfig.main.waves[WavesConfig.main.waveAtual].boost;
        life *= WavesConfig.main.waves[WavesConfig.main.waveAtual].boost;
        damege = Mathf.RoundToInt(damege * WavesConfig.main.waves[WavesConfig.main.waveAtual].boost);
        reward = Mathf.RoundToInt(reward * WavesConfig.main.waves[WavesConfig.main.waveAtual].boost);
        destiny = RoadEnemy.main.points[indexPoint]; //atribui ao destiny o valor alvo

    }
    void MoveDirection()
    {
        Vector2 direction = (destiny.position - transform.position).normalized; //defini a direção do movimento
        enemyBox.linearVelocity = speed * direction; // aplica a direção de movimento e a velocidade no inimigo
    }
    void PointMoviment()
    {
        if (Vector2.Distance(destiny.position, transform.position) <= 0.1f) //compara se a dintancia dos elementos é menor que 0.1
        {
            indexPoint++; //atualiza para o priximo valor
            if (indexPoint == RoadEnemy.main.points.Length) // compara para ver se foi atingido o ponto final
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                destiny = RoadEnemy.main.points[indexPoint];
            }
        }
    }

    void Direction() // atualizar quando tiver sprites e a animação
    {
        //olhando para o canto direito superior)
        if (enemyBox.linearVelocityX >= 0 && enemyBox.linearVelocityY >= 0) // xy positivo 
        { 
            spriteRenderer.flipX = true;
        }
        //olhando para o canto esquerdo superior)
        if (enemyBox.linearVelocityX <= 0 && enemyBox.linearVelocityY >= 0) //x negativo e y positivo ()
        {
            spriteRenderer.flipX = false;
        }
        //olhando para o canto direito inferior)
        if (enemyBox.linearVelocityX >= 0 && enemyBox.linearVelocityY <= 0) //x positivo e y negativo
        {
            spriteRenderer.flipX = false;
        }
        //olhando para o canto esquerdo inferior)
        if (enemyBox.linearVelocityX <= 0 && enemyBox.linearVelocityY <= 0) //xy negativo
        {
            spriteRenderer.flipX = true;
        }








    }


}
