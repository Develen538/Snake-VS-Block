using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Snake))]
public class SneakView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private Snake _snake;

    private void Awake()
    {
        _snake = GetComponent<Snake>();
    }


    private void OnEnable()
    {
        _snake.SizeUpdate += OnSnakeView;
    }

    private void OnDisable()
    {
        _snake.SizeUpdate -= OnSnakeView;
    }

    private void OnSnakeView(int size)
    {
        _text.text = size.ToString();
    }
}
