using UnityEngine;
using UnityEngine.EventSystems;
public class Drop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        NumbersManagerDrag number = eventData.pointerDrag.GetComponent<NumbersManagerDrag>();

        if (number != null)
        {
            Debug.Log("Numero detectado: " + number.Number);
        }
    }
}