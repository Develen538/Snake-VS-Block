using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Block : MonoBehaviour
{
    [SerializeField] private Vector2Int _destroiPriceRange;
    [SerializeField] private Color[] _colors;

    private SpriteRenderer _spriteRenderer;
    private int _destroiPrice;
    private int _filing;
    private Restart _restart;

    public event UnityAction<int> ScoreBlock;
    private int _leftToFill => _destroiPrice - _filing;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        SetColors(_colors[Random.Range(0, _colors.Length)]);

        _destroiPrice = Random.Range(_destroiPriceRange.x,_destroiPriceRange.y);
        ScoreBlock?.Invoke(_leftToFill);
    }

    public void Fill()
    {
        _filing++;
        ScoreBlock?.Invoke(_leftToFill);

        if (_filing == _destroiPrice)
            Destroy(gameObject);
    }

    private void SetColors(Color color)
    {
        _spriteRenderer.color = color;
    }
}
