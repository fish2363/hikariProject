using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDropObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private CaptureManager captureManager;

    private Image image;
    public Sprite basicImage;
    public Sprite nullImage;
    private GameObject furnitureObj = null;
    private GameObject furniture;

    [HideInInspector] public Transform parentAfterDrag;

    private void Awake()
    {
        captureManager = FindAnyObjectByType<CaptureManager>();
        image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (image.sprite == basicImage)
            return;
        else
        {
            image.sprite = nullImage;
            transform.SetAsLastSibling();
            //parentAfterDrag = transform.parent;
            //transform.SetParent(transform.root);
            image.raycastTarget = false;

            PlaceObjSO placeObjSO = GetComponent<FurnitureDistince>().placeObjSO;

            furniture = placeObjSO.prefab;
            furnitureObj = Instantiate(furniture, transform);
            furnitureObj.GetComponent<Rigidbody2D>().simulated = false;
            furnitureObj.GetComponent<ObjectGather>().enabled = false;

            GetComponent<FurnitureDistince>().placeObjSO = null;
            furnitureObj.GetComponent<PlaceObj>().PlaceIt();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (image.sprite == basicImage)
            return;
        else
        {
            image.sprite = nullImage;
            Vector2 pos = UtillClass.GetMousePointerPosition();

            furnitureObj.transform.position = pos;

            print(furnitureObj.transform.position);
            print(furnitureObj.name);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (image.sprite == basicImage)
            return;
        else
        {
            PlaceObj placeObj = furnitureObj.GetComponent<PlaceObj>();

            if (furnitureObj.GetComponent<PlaceObj>().isPlaceTure)
            {
                image.sprite = basicImage;
                CaptureManager.inventoryIdx -= 1;
                placeObj.placeHelp.GetComponent<ObjectGather>().enabled = true;
                placeObj.placeHelp.GetComponent<BoxCollider2D>().enabled = true;
                placeObj.placeHelp.GetComponent<Rigidbody2D>().simulated = true;
                if (gameObject.GetComponent<Animator>() != null)
                    placeObj.placeHelp.GetComponent<Animator>().enabled = true;
                if (gameObject.GetComponentInChildren<Collider2D>() != null)
                    gameObject.GetComponentInChildren<Collider2D>().enabled = true;
                placeObj.placeHelp.GetComponent<SpriteRenderer>().color = Color.white;
            }
            else if (!furnitureObj.GetComponent<PlaceObj>().isPlaceTure)
            {
                image.sprite = basicImage;
                placeObj.placeHelp.GetComponent<CaptureObject>().CaptureFinish(CaptureManager.inventoryIdx);
                // if (CaptureManager.inventoryIdx != 7)
                // {
                //    CaptureManager.inventoryIdx++;
                // }
                //  else
                //  {
                //      CaptureManager.inventoryIdx = 0;
                //    }
                Destroy(placeObj.placeHelp);
            }

            placeObj.isPlaceStart = false;

            Destroy(furnitureObj);
            furnitureObj = null;
            image.raycastTarget = true;
        }
    }
}
