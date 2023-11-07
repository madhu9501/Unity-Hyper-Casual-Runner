using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField]
    private Vector3 _chunkSize;

    public float GetLength(){
        return _chunkSize.z;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, _chunkSize);

    }
}
