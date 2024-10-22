using DG.Tweening;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
public class Item : MonoBehaviour
{
    private Rigidbody _rb;

    private Rigidbody Rb => _rb != null ? _rb : _rb = GetComponent<Rigidbody>();

    public void GetPickedUp(Transform newParent)
    {
        Rb.isKinematic = true;
        Rb.detectCollisions = false;
        transform.parent = newParent;
        transform.DOLocalMove(Vector3.zero, 0.25f);
        transform.DOLocalRotate(Vector3.zero, 0.25f);
    }

    public void GetDropped()
    {
        transform.DOKill();
        Rb.isKinematic = false;
        Rb.detectCollisions = true;
        transform.parent = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PickupTruck pickupTruck))
        {
            pickupTruck.AddItem(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PickupTruck pickupTruck))
        {
            pickupTruck.RemoveItem(this);
        }
    }
}