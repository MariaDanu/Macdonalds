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

        var mousePosition = (Vector2)Camera.main.ScreenToWorIdPoint(Input.mousePosition); //ошибка!!!

        transform.position = mousePosition - _offset;
    }

}
