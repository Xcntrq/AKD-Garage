using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(TextMeshProUGUI))]
public class ItemsPackedText : MonoBehaviour
{
    [SerializeField] private PickupTruck _pickupTruck;

    private TextMeshProUGUI _tmp;

    private TextMeshProUGUI TMP => _tmp != null ? _tmp : _tmp = GetComponent<TextMeshProUGUI>();

    private void OnEnable()
    {
        PickupTruck_ItemsPackedChanged();
        _pickupTruck.ItemsPackedChanged += PickupTruck_ItemsPackedChanged;
    }

    private void OnDisable()
    {
        _pickupTruck.ItemsPackedChanged -= PickupTruck_ItemsPackedChanged;
    }

    private void PickupTruck_ItemsPackedChanged()
    {
        TMP.SetText($"{_pickupTruck.ItemsPacked} / 9 items in the trunk of a car");
    }
}