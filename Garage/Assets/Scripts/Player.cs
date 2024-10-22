using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class Player : MonoBehaviour
{
    [SerializeField] private float _reach;
    [SerializeField] private Transform _origin;
    [SerializeField] private Transform _itemHolder;
    [SerializeField] private GameObject _hintPanel;
    [SerializeField] private TextMeshProUGUI _hintText;
    [SerializeField] private LayerMask _raycastMask;

    private bool _isWithItem;
    private bool _isHintActive;
    private Item _currentItem;

    private void ShowHint(string hint)
    {
        _hintText.SetText(hint);
        _hintPanel.SetActive(true);
        _isHintActive = true;
    }

    private void HideHint()
    {
        _hintPanel.SetActive(false);
        _isHintActive = false;
    }

    private void Start()
    {
        HideHint();
    }

    private void FixedUpdate()
    {
        if (_isWithItem)
        {
            return;
        }

        // Not holding an item
        _currentItem = null;
        if (Physics.Raycast(_origin.position, _origin.forward, out RaycastHit hit, _reach, _raycastMask, QueryTriggerInteraction.Ignore))
        {
            if ((hit.rigidbody != null) && hit.rigidbody.TryGetComponent(out _currentItem))
            {
                ProcessHitItem();
            }
        }

        if (_isHintActive && (_currentItem == null))
        {
            HideHint();
        }
    }

    private void ProcessHitItem()
    {
        if (!_isHintActive)
        {
            ShowHint("LMB to pick up");
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_isWithItem && (_currentItem != null))
        {
            PickUpCurrentItem();
        }

        if (Input.GetMouseButtonDown(1) && _isWithItem)
        {
            DropCurrentItem();
        }
    }

    private void PickUpCurrentItem()
    {
        _currentItem.GetPickedUp(_itemHolder);
        _isWithItem = true;
        ShowHint("RMB to drop");
    }

    private void DropCurrentItem()
    {
        _currentItem.GetDropped();
        _isWithItem = false;
        HideHint();
    }
}