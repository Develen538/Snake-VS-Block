using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Block))]
public class BlockView : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;

    private Block _block;

    private void Awake()
    {
        _block = GetComponent<Block>();
    }

    private void OnEnable()
    {
        _block.ScoreBlock += OnBlockView;
    }

    private void OnDisable()
    {
        _block.ScoreBlock += OnBlockView;
    }

    private void OnBlockView(int size)
    {
        _view.text = size.ToString();
    }
}
