using System;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PickupTruck : MonoBehaviour
{
    private readonly List<Item> _items = new();

    public int ItemsPacked => _items.Count;

    public event Action ItemsPackedChanged;

    public void AddItem(Item item)
    {
        if (!_items.Contains(item))
        {
            _items.Add(item);
            ItemsPackedChanged?.Invoke();
        }
    }

    public void RemoveItem(Item item)
    {
        if (_items.Contains(item))
        {
            _items.Remove(item);
            ItemsPackedChanged?.Invoke();
        }
    }

    private void Start()
    {
        ItemsPackedChanged?.Invoke();
    }
}