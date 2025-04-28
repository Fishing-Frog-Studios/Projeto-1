using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelecionarSapo : MonoBehaviour
{
    public GameObject sapoSeguidor;
    private bool segurandoSapo = false;

    void Update()
    {
        if (segurandoSapo)
        {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                sapoSeguidor.transform.parent.GetComponent<RectTransform>(),
                Input.mousePosition,
                null,
                out pos
            );
            sapoSeguidor.GetComponent<RectTransform>().localPosition = pos;
        }
    }

    public void SelecionarOuCancelar()
    {
        segurandoSapo = !segurandoSapo;
        sapoSeguidor.SetActive(segurandoSapo);
    }
}
