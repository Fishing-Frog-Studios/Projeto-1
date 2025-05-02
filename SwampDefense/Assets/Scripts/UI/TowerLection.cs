using Unity.VisualScripting;
using UnityEngine;

public class TowerLection : MonoBehaviour
{

    [SerializeField] private int listaDeck;

    public void TrocaTower()
    {
        GameObject newTower = DeckTower.main.towersDeck[listaDeck];
        DeckTower.main.towerPrefabSelect = newTower;
    }

}
