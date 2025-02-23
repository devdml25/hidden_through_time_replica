using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public LayerMask pickupLayer;

    private void OnMouseDown()
    {
        DestroyItem();  
    }

    private void Update()
    {
        TouchItem();
    }

    private void TouchItem()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, pickupLayer)) // Raycast chỉ trên layer "pickupLayer"
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        DestroyItem();
                    }
                }
            }
        }
    }

    private void DestroyItem()
    {
        if (((1 << gameObject.layer) & pickupLayer) != 0)
        {
            Destroy(gameObject);
        }
    }
}