using System.Collections;
using UnityEngine;

public class CaptureManager : MonoBehaviour
{
    [Header("ĸ�� ������")]
    private Door _door;
    [SerializeField]
    private Vector2 captureSize;
    [SerializeField] private GameObject _captureBoxImage;
    [SerializeField]
    private LayerMask whatIsCaptureObj;

    private Vector2 mousePos;
    private bool isNowCapture;

    public int inventoryIdx;
    [SerializeField] private Transform _captureCollection;


    private void Awake()
    {   
        isNowCapture = false;
    }
    private void Update()
    {
        MouseFollow();
        Capture();
        _captureBoxImage.transform.position = transform.position;
    }

    private void MouseFollow()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (!isNowCapture)
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, mousePos, 10f * Time.deltaTime);
    }

    private void Capture()
    {
        Collider2D[] captureObject = Physics2D.OverlapBoxAll(gameObject.transform.position, captureSize, 0, whatIsCaptureObj);

        if (Input.GetMouseButtonDown(0) && !isNowCapture && transform.localPosition != _captureCollection.localPosition)
        {
            if (captureObject != null)
            {
                SaveInventory(captureObject);
                //StartCoroutine(WaitCaptureRoutine());
            }
            else
            {
                print("ĸ���� ��cprk djqttmq�ϴ�");
                isNowCapture = false;
            }  
        }
    }

    private void SaveInventory(Collider2D[] captureObject)
    {
        for (int i = 0; i < captureObject.Length; i++)
        {
            if (inventoryIdx < 6)
            {
                captureObject[i].GetComponent<CaptureObject>().CaptureFinish(inventoryIdx);
                inventoryIdx++;

            }
            else
            {
                inventoryIdx = 0;
                captureObject[i].GetComponent<CaptureObject>().CaptureFinish(inventoryIdx);
            }
        }
    }

    //private IEnumerator WaitCaptureRoutine()
    //{
      //  isNowCapture = true;
      //  yield return new WaitForSeconds(1f);
      //  isNowCapture = false;
  //  }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(gameObject.transform.position, captureSize);
    }
}
