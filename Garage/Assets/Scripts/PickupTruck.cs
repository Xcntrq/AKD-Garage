using System;
using UnityEngine;

[DisallowMultipleComponent]
public class PickupTruck : MonoBehaviour
{
    [SerializeField] private int _itemsPacked;

    public int ItemsPacked => _itemsPacked;

    public event Action ItemsPackedChanged;

    private void Start()
    {
        ItemsPackedChanged?.Invoke();
    }
}
