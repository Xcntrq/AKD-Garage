using System.Collections;
using DG.Tweening;
using StarterAssets;
using UnityEngine;

[DisallowMultipleComponent]
public class Cutscene : MonoBehaviour
{
    [SerializeField] private FirstPersonController _fpc;
    [SerializeField] private Transform _garageDoorLeft;
    [SerializeField] private Transform _garageDoorRight;
    [SerializeField] private RectTransform _uiPanel;

    private IEnumerator Start()
    {
        _fpc.enabled = false;
        _uiPanel.gameObject.SetActive(false);
        _garageDoorLeft.DOLocalRotate(new Vector3(0f, 160f, 0f), 2f, RotateMode.Fast).SetEase(Ease.InOutQuad);
        _garageDoorRight.DOLocalRotate(new Vector3(0f, -160f, 0f), 2f, RotateMode.Fast).SetEase(Ease.InOutQuad);

        yield return new WaitForSeconds(2f);

        _uiPanel.localScale = Vector3.zero;
        _uiPanel.pivot = Vector2.one * 0.5f;
        _uiPanel.anchorMin = Vector2.one * 0.5f;
        _uiPanel.anchorMax = Vector2.one * 0.5f;
        _uiPanel.gameObject.SetActive(true);

        _uiPanel.DOScale(Vector3.one, 0.75f);
        _uiPanel.DOPivot(Vector2.up, 0.75f).SetEase(Ease.OutQuad);
        _uiPanel.DOAnchorMin(Vector2.up, 0.75f).SetEase(Ease.OutQuad);
        _uiPanel.DOAnchorMax(Vector2.up, 0.75f).SetEase(Ease.OutQuad);

        yield return new WaitForSeconds(1f);

        _fpc.enabled = true;
    }
}