using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Canvas))]
public class CurclePosController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField]
    private RectTransform _backgroundUI;
    [SerializeField]
    private RectTransform _handleUI;
    [SerializeField]
    private float _raduisPx = 128.0f;
    [SerializeField]
    private float _operatableRadiusPx = 256.0f;

    [System.Serializable]
    public class CurclePosChangedEvent : UnityEvent<float> { };
    public CurclePosChangedEvent OnCurclePosChanged;

    private Canvas _canvas;

    void Awake()
    {
        _canvas = GetComponent<Canvas>();
        SetPos(0f);
    }

    public void SetPos(float clockAngledeg)
    {
        var ang = Mathf.Deg2Rad * Mathf.Repeat(90.0f - clockAngledeg, 360.0f);
        _handleUI.anchoredPosition = _raduisPx * new Vector2(Mathf.Cos(ang), Mathf.Sin(ang));
        OnCurclePosChanged?.Invoke(clockAngledeg);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        var origin = _backgroundUI.anchoredPosition + _backgroundUI.rect.center;
        var inputPos = eventData.position - (origin * _canvas.scaleFactor);
        if(inputPos.magnitude > _operatableRadiusPx)
        {
            return;
        }
        SetPos(-Vector2.SignedAngle(Vector2.up, inputPos));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    private Camera GetUICam()
    {
        if(_canvas.renderMode == RenderMode.ScreenSpaceCamera)
        {
            return _canvas.worldCamera;
        }
        return null;
    }
}