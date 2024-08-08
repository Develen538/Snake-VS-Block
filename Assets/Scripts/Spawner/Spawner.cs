using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private Transform _conteiner;
    [SerializeField] private int _distanseBetweenFullLine;
    [SerializeField] private int _distanceBetweenRandomLine;
    [Header("Block")]
    [SerializeField] private Block _block;
    [SerializeField] private int _blockSpawnChance;
    [Header("Wall")]
    [SerializeField] private Wall _wallTamplet;
    [SerializeField] private int _wallSpawnChance;

    private BlockSpawnPoint[] _blocksSpawnPoint;
    private WallSpawnPoint[] _wallSpawnPoints;

    private void Start()
    {
        int _repitCount = Random.Range(5, 15);
        _blocksSpawnPoint = GetComponentsInChildren<BlockSpawnPoint>();
        _wallSpawnPoints = GetComponentsInChildren<WallSpawnPoint>();

        for (int i = 0; i < _repitCount; i++)
        {
            Movespawner(_distanseBetweenFullLine);
            GenerateRandomLineElements(_wallSpawnPoints, _wallTamplet.gameObject, _wallSpawnChance, _distanseBetweenFullLine, _distanseBetweenFullLine / 2f);
            GenerateFullLineElements(_blocksSpawnPoint, _block.gameObject);
            Movespawner(_distanceBetweenRandomLine);
            GenerateRandomLineElements(_wallSpawnPoints, _wallTamplet.gameObject, _wallSpawnChance, _distanceBetweenRandomLine, _distanceBetweenRandomLine /2f);
            GenerateRandomLineElements(_blocksSpawnPoint, _block.gameObject, _blockSpawnChance);
        }
    }

    private void GenerateFullLineElements(SpawnPoint[] spawnPoint, GameObject genereitElement)
    {
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            GenereitElemnt(spawnPoint[i].transform.position,genereitElement);
        }
    }

    private void GenerateRandomLineElements(SpawnPoint[] spawnPoint, GameObject genereitElement, int spawnChance, int scaleY = 1, float offsetY = 0)
    {
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            if(Random.Range(0,100) < spawnChance)
            {
                GameObject elemt = GenereitElemnt(spawnPoint[i].transform.position, genereitElement, offsetY);
                elemt.transform.localScale = new Vector3(elemt.transform.localScale.x,scaleY,elemt.transform.localScale.z);
            }
        }
    }

    private GameObject GenereitElemnt(Vector3 spawnPosition, GameObject genereitElemnt, float offsetY = 0)
    {
        spawnPosition.y -= offsetY;
        return Instantiate(genereitElemnt,spawnPosition,Quaternion.identity,_conteiner);
    }

    private void Movespawner(int distans)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + distans, transform.position.z);
    }
}
