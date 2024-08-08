using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SnakeGeneration : MonoBehaviour
{
    [SerializeField] private Sigment _sigmentTemplet;

    public List<Sigment> Generation(int count)
    {
        List<Sigment> tail = new List<Sigment>();

        for (int i = 0; i < count; i++)
        {
            tail.Add(Instantiate(_sigmentTemplet,transform));
        }
        return tail;
    }
}
