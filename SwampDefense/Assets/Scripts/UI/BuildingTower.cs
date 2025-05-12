using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingTower : MonoBehaviour
{
   
    [SerializeField] private Tilemap grid;
    [SerializeField] private Rigidbody2D boxGrid;
    public GameObject tower;

    private     bool         colidiu;           // define o estado de colisão
    private     Vector3      towerLoction;      // salva o local para posicionar a torre
    public      bool         turnoDia;      // defini se esta no turno de construir
    public bool construir;


    private void Update()
    {
        tower = DeckTower.main.towerPrefabSelect;
        if (turnoDia == true && construir == true)
        {
            GridDef();
            if (Input.GetMouseButtonDown(0))
            {
                Building();
            }
        }
    }

  

    void GridDef()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = new Vector3(mousePosition.x, mousePosition.y, 1f);
        Vector3Int cellPosition = grid.WorldToCell(mousePosition);
        Vector3 cellCenter = grid.GetCellCenterWorld(cellPosition);
        towerLoction = cellCenter; 
    }
    void Building ()
    {  
        if (colidiu != true && CoinsTowers.main.coins >= CoinsTowers.main.preco)
        {
            Instantiate(tower, towerLoction, Quaternion.identity);
            CoinsTowers.main.coins -= CoinsTowers.main.preco;
            CoinsTowers.main.preco++;
        }
    }
    private void OnTriggerStay2D(Collider2D boxGrid)
    {
        if (boxGrid.gameObject.CompareTag("Invalido"))
        {
            colidiu = true;
        }
        else
        { colidiu = false; }
    }  //Detecta o estado de colição ao entrar
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (boxGrid.gameObject.CompareTag("Invalido"))
        {
            colidiu = true;
        }
        else
        { colidiu = false; }
    }  //Detecta o estado de colição ao sair
}
