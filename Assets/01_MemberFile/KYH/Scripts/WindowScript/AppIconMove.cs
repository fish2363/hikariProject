using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AppIconMove : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {

    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 mouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseDir;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
