
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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

//  [SerializeField] private algumtipo reward;

    private Transform destiny; //ponto alvo no momento
    private int indexPoint = 0; //numeros do proximo alvo
    private bool flipSprite;   

    private void Start()
    {
        destiny = RoadEnemy.main.points[indexPoint]; //atribui ao destiny o valor alvo
    }

    private void Update()
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

    private void FixedUpdate()
    {
        Vector2 direction = (destiny.position - transform.position).normalized; //defini a direção do movimento
        enemyBox.linearVelocity = speed * direction; // aplica a direção de movimento e a velocidade no inimigo

        print(enemyBox.linearVelocity);
    }


    void Direction() // atualizar quando tiver sprites e a animação
    {
        //olhando para o canto direito superior)
        if (enemyBox.linearVelocityX >= 0 && enemyBox.linearVelocityY >= 0) // xy positivo 
        { 
            
        }
        //olhando para o canto esquerdo superior)
        if (enemyBox.linearVelocityX <= 0 && enemyBox.linearVelocityY >= 0) //x negativo e y positivo ()
        {
        
        }
        //olhando para o canto direito inferior)
        if (enemyBox.linearVelocityX >= 0 && enemyBox.linearVelocityY <= 0) //x positivo e y negativo
        { 

        }
        //olhando para o canto esquerdo inferior)
        if (enemyBox.linearVelocityX <= 0 && enemyBox.linearVelocityY <= 0) //xy negativo
        { 

        }








    }


}
