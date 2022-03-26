using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bun_p : MonoBehaviour
{
    private bool _dragging, _placed;
    private Vector2 _offset, _firstPosition;

    [SerializeField] private SpriteRenderer _renderer;
    
    private Bun_pSlot _pslot;
    
    public void Init(Bun_pSlot slot) //метод
    {
        _renderer.sprite = slot.Renderer.sprite;
        _pslot = slot;
    }

    private void Awake()
    {
        _firstPosition = transform.position;
    }

    private void Update()
    {
        //if(_pslot != null)
        if (_placed) return;
        //_placed = true;
        if (!_dragging) return;

        var mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = mousePosition - _offset;
    }

    private void OnMouseDown()
    {
        _dragging = true;
        _offset = GetMousePos() - (Vector2)transform.position;
    }

    private void OnMouseUp()
    {
        if(Vector2.Distance(transform.position, _pslot.transform.position) < 3)
        {
            transform.position = _pslot.transform.position;
            _pslot.Placed();
            _placed = true;
        }
        else
        {
            _dragging = false;
            //_offset = _pslot.transform.position;
            transform.position = _firstPosition;
        }
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
