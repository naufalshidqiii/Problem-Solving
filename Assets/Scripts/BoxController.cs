using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public Vector2 scaleRandomValue;

    private Transform player;

    private void Awake()
    {
        player = FindObjectOfType<DotController>().transform;
    }

    public void Spawn()
    {
        bool boxSpawned = false;
        while (!boxSpawned)
        {
            Vector2 spawnPosition = GameManager.Instance.GetRandomPosition();
            if (((Vector2)player.position - spawnPosition).magnitude < 1)
                continue;

            else
            {
                transform.position = spawnPosition;
                Setup();
                boxSpawned = true;
            }
        }
    }

    private void Setup()
    {
        float xScale = Random.Range(scaleRandomValue.x, -scaleRandomValue.x);
        float yScale = Random.Range(scaleRandomValue.y, -scaleRandomValue.y);

        transform.localScale = new Vector2(xScale, yScale);
    }
}