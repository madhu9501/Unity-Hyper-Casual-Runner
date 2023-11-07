using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    public static ChunkManager _instance;
    [SerializeField]
    LevelSO[] _levels;
    private GameObject _finishLine;

    void Awake()
    {
        if(_instance != null)
            Destroy(gameObject);
        else
            _instance = this;
    }
    void Start()
    {
        // OrderedChunkGenerator();
        GenerateLevel();
        _finishLine = GameObject.FindWithTag("FinishLine");
    }

    private void GenerateLevel()
    {
       int currentLevel = GetLevel();

       currentLevel %= _levels.Length;
       LevelSO level = _levels[currentLevel];
       CreateLevel(level.cunks);
    }

    void CreateLevel(Chunk[] levelChunks)
    {
        Vector3 chunkPosition = Vector3.zero;

        for(int i =0; i < levelChunks.Length; i++ )
        {
            Chunk chunkToCreate = levelChunks[i];

            if(i>0) chunkPosition.z += chunkToCreate.GetLength() /2;  

            Chunk chunk_Instance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform );

            chunkPosition.z += chunk_Instance.GetLength() /2;            
        }
    }

    public float GetFinishZ()
    {
        return _finishLine.transform.position.z;
    }

    public int GetLevel()
    {
        return PlayerPrefs.GetInt("level", 0);
    }



    // private Chunk[] _randomChunkPrefabs;
    // [SerializeField]
    // int _roadLength;
    // [SerializeField]
    // private Chunk[] _orderedChunkPrefabs;
    // private void OrderedChunkGenerator()
    // {
    //     Vector3 chunkPosition = Vector3.zero;

    //     for(int i =0; i < _orderedChunkPrefabs.Length; i++ )
    //     {
    //         Chunk chunkToCreate = _orderedChunkPrefabs[i];

    //         if(i>0) chunkPosition.z += chunkToCreate.GetLength() /2;  

    //         Chunk chunk_Instance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform );

    //         chunkPosition.z += chunk_Instance.GetLength() /2;            
    //     }
    // }

    // private void RandomChunkGenerator()
    // {
    //     Vector3 chunkPosition = Vector3.zero;

    //     for(int i =0; i < _roadLength; i++ )
    //     {
    //         Chunk chunkToCreate = _randomChunkPrefabs[Random.Range(0, _randomChunkPrefabs.Length)];

    //         if(i>0) chunkPosition.z += chunkToCreate.GetLength() /2;  

    //         Chunk chunk_Instance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform );

    //         chunkPosition.z += chunk_Instance.GetLength() /2;            
    //     }
    // }
}
