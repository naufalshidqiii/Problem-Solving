using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region SINGLETON
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null) Debug.LogError("No Game Manager Found!");
            }
            return _instance;
        }
    }
    #endregion

    [Header("Box Controller")]
    public int boxSpawn;
    [SerializeField] 
    private BoxController boxPrefab;

    [Header("Game Area")]
    public float areaConstraintX = 5f;
    public float areaConstraintY = 5f;

    private int currentScore = 0;


    private void Start()
    {
        currentScore = 0;

        for (int i = 0; i < boxSpawn; i++)
        {
            BoxController box = Instantiate(boxPrefab);
            box.Spawn();
        }
    }

    public Vector2 GetRandomPosition()
    {
        float xPosition = Random.Range(-areaConstraintX, areaConstraintX);
        float yPosition = Random.Range(-areaConstraintY, areaConstraintY);

        return new Vector2(xPosition, yPosition);
    }

    public void IncreaseScore(int increment = 1)
    {
        currentScore += increment;

    }

    public float GetCurrentScore()
    {
        return currentScore;
    }
}