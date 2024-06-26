using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class ObjectSpawning : MonoBehaviour
{
    [SerializeField] private int MaxX, MaxY, MinX, MinY;
    public GameObject[] SpawnObjects;
    public Tilemap tilemap;
    private float Timer;
    [SerializeField] private float MaxTime;
    public Grid grid;
    public ResourceCounter rc;

    private void Awake()
    {
        InstaSpawn();
    }

    private void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= MaxTime && rc.currentCount < rc.maxCount)
        {
            TrySpawnObject();
            Timer = 0;
        }
    }

    public void InstaSpawn()
    {
        Debug.Log("InstaSpawn");
        TrySpawnObject();
    }

    private void TrySpawnObject()
    {
        Debug.Log(tilemap);
        int XPos = Random.Range(MinX, MaxX + 1);
        int YPos = Random.Range(MinY, MaxY + 1);

        if (tilemap.GetTile(new Vector3Int(XPos, YPos, 0)))
        {
            Vector3 objPos = grid.CellToLocal(new Vector3Int(XPos, YPos, 0));
            objPos = new Vector3(objPos.x + 0.08f, objPos.y + 0.08f, objPos.z);

            RaycastHit2D hit = Physics2D.Raycast(objPos, Vector2.zero);
            if (hit.collider == null)
            {
                int InstNum = Random.Range(0, SpawnObjects.Length);
                Instantiate(SpawnObjects[InstNum], objPos, Quaternion.identity);
                rc.currentCount++;
                Debug.Log("Object Spawned at: " + objPos);
            }
        }
    }

    public void MinusCurrent()
    {
        rc.currentCount--;
    }
}
