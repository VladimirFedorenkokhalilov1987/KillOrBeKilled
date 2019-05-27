using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnedObject : MonoBehaviour
{
    private SpawnGO _spawnGO;
    private Camera cam;
    public float _moveSpeed = 0.1f;
    // Start is called before the first frame update
    private float x;
    private float y;
    private float z;
    Vector3 pos;
  
    private void Start()
    {
        x = Random.Range(-5, 5);
        y = Random.Range(-5, 5);
        z = 0;
        pos = new Vector3(x, y, z);
        transform.position = pos;
        cam = Camera.main;
        _spawnGO = GameObject.FindObjectOfType<SpawnGO>();
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, pos, _moveSpeed * Time.deltaTime);
    }
}
