using UnityEngine;
using UnityEngine.Tilemaps;

public class GridSelection : MonoBehaviour
{
    // Variaveis

  
    [SerializeField] GameObject sapoSeguidor;
    [SerializeField] private Transform          selectionGrid;          //Objeto base de seleção
    [SerializeField] private Tilemap            grid;                   //tile base da grid
    [SerializeField] private SpriteRenderer     selectionGridColor;     // Edita a cor da seleção
    [SerializeField] private Rigidbody2D        boxGrid;                // Caixa de colisão da Seleção 

    private UnityEngine.Color   legalCor    =  new Color32(43, 192, 49, 128);   // define a cor de disponivel (verde)
    private UnityEngine.Color   ilegalCor   =  new Color32(203, 32, 18, 128);   // define a cor de indisponivel (vermelho)

    public bool segurandoSapo = false;      // defini se esta no turno de construir
    private bool colidiu;           // define o estado de colisão

    void spritmodificator()
    {
        SpriteRenderer meuRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer prefabRenderer = DeckTower.main.towerPrefabSelect.GetComponent<SpriteRenderer>();

        if (meuRenderer != null && prefabRenderer != null)
        {
            Debug.Log("Trocando sprite...");
            meuRenderer.sprite = prefabRenderer.sprite;
        }
    }
    private void FixedUpdate()
    {
        spritmodificator();
        if (segurandoSapo == true)
        {
            PositionSelection(); // chama a função 
        }
        else
        {
            sapoSeguidor.SetActive(segurandoSapo);
        }
    }
    void PositionSelection () // Detecta a posição do mouse e converte para o grid
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // captura a posição do mause em relação a camera
        mousePosition = new Vector3(mousePosition.x, mousePosition.y, 1f); // corrige o Z da posição
        Vector3Int cellPosition = grid.WorldToCell(mousePosition); // Converte para posição do grid
        Vector3 cellCenter = grid.GetCellCenterWorld(cellPosition); // Corrige a posição no grid
        selectionGrid.position = cellCenter; // posiciona a seleção no local
        LegalPositionDef(); // chama a função
    }

    void LegalPositionDef() // determina a cor da seleção
    {

        if (colidiu == true) 
        {

            selectionGridColor.color = ilegalCor;
        }//aplica a cor na seleção Indisponivel
        else 
        {
            selectionGridColor.color = legalCor;
        } //aplica a cor na seleção Disponivel

    }
    private void OnTriggerStay2D(Collider2D boxGrid)
    {
        if (boxGrid.gameObject.CompareTag ("tower"))
        {
            colidiu = true;
        }
        else
        { colidiu = false; }
    }  //Detecta o estado de colição ao entrar
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (boxGrid.gameObject.CompareTag("tower"))
        {
            colidiu = true;
        }
        else 
        { colidiu = false; }
    }  //Detecta o estado de colição ao sair
    public void SelecionarOuCancelar()
    {
        segurandoSapo = !segurandoSapo;
        sapoSeguidor.SetActive(segurandoSapo);
    }
}
