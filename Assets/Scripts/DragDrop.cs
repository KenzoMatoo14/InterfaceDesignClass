using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class DragDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    
    private Vector2 _Offset;

    public void OnBeginDrag(PointerEventData eventData){
        _Offset = new Vector2(transform.position.x, transform.position.y) - eventData.pressPosition;
        //Debug.Log("Me empiezan a arrastrar");
    }

    public void OnDrag(PointerEventData eventData){
        transform.position = eventData.position + _Offset;
        //Debug.Log("Me estan arrastrando");
    }

    public void OnEndDrag(PointerEventData eventData){
        Magnet.CheckMagnet(transform);


        //Debug.Log("Me dejaron de arrastrar");
    }
}
