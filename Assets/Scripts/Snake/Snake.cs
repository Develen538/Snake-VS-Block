using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(InputPlayer))]
[RequireComponent(typeof(SnakeGeneration))]
public class Snake : MonoBehaviour
{
    [SerializeField] private Restart _restart;
    [SerializeField] private SnakeHead _head;
    [SerializeField] private float _speed;
    [SerializeField] private float _tailSpeed;

    public event UnityAction<int> SizeUpdate;

    private InputPlayer _input;
    private List<Sigment> _tail;
    private SnakeGeneration _generation;

    private void Awake()
    {
      int _tilSize = Random.Range(50, 200);
      _generation = GetComponent<SnakeGeneration>();
        _tail = _generation.Generation(_tilSize);
        _input = GetComponent<InputPlayer>();
        SizeUpdate?.Invoke(_tail.Count);
        
    }

    private void OnEnable()
    {
        _head.BlockCollider += OnBlockCollider;
        _head.BonusCollectid += OnBonusCollectid;
    }

    private void OnDisable()
    {
        _head.BlockCollider -= OnBlockCollider;
        _head.BonusCollectid -= OnBonusCollectid;
    }

    private void FixedUpdate()
    {
        Move(_head.transform.position + _head.transform.up * _speed * Time.fixedDeltaTime);

        _head.transform.up = _input.GetDistanceToClik(_head.transform.position);
        if (_tail.Count == 1)
        {
            _restart.Restar();
        }
       
    }

    private void Move(Vector3 NextPosition)
    {
        Vector3 perviousPosition = _head.transform.position;

        foreach (var tails in _tail)
        {
            Vector3 tempPosition = tails.transform.position;
            tails.transform.position = Vector2.Lerp(tails.transform.position, perviousPosition, _tailSpeed * Time.deltaTime );
            perviousPosition = tempPosition;
        }

        _head.Move(NextPosition);
    }

    private void OnBlockCollider()
    {
        Sigment deletSegemn = _tail[_tail.Count - 1];
        _tail.Remove(deletSegemn);
        Destroy(deletSegemn);
        SizeUpdate?.Invoke(_tail.Count);
    }

    private void OnBonusCollectid(int bonusSize)
    {
        _tail.AddRange(_generation.Generation(bonusSize));
        SizeUpdate?.Invoke(_tail.Count);
    }
}
