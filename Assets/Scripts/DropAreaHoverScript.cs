using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class DropAreaHoverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string name = "00";
    private Color color;
    public TMP_Text textMsg;
    private void Start()
    {
        //textMsg = GetComponent<TextMeshProUGUI>();
        color = GetComponent<Renderer>().material.color;
    }
    void IPointerEnterHandler.OnPointerEnter (PointerEventData eventData)
    {
        GetComponent<Renderer>().material.color = new Color(0, 255, 0);
        textMsg.text = "hover sur le trou " + name;
        Debug.Log("Mouse is over GameObject.");
    }

    void IPointerExitHandler.OnPointerExit (PointerEventData eventData)
    {
        GetComponent<Renderer>().material.color = color;
        textMsg.text = "indication";
        Debug.Log("Mouse is no longer on GameObject.");
    }

}
