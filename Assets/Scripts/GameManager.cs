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
    private List<BoxController> boxPool = new List<BoxController>();


    [Header("Game Area")]
    public float areaConstraintX = 5f;
    public float areaConstraintY = 5f;

    private int currentScore = 0;


    private void Start()
    {
        currentScore = 0;

        for (int i = 0; i < boxSpawn; i++)
        {
            BoxController box = GetBox();
            box.Spawn();
        }
    }

    public Vector2 GetRandomPosition()
    {
        float xPosition = Random.Range(-areaConstraintX, areaConstraintX);
        float yPosition = Random.Range(-areaConstraintY, areaConstraintY);

        return new Vector2(xPosition, yPosition);
    }

    public BoxController GetBox()
    {
        for (int i = 0; i < boxPool.Count; i++)
        {
            if (!boxPool[i].gameObject.activeSelf)
            {
                boxPool[i].gameObject.SetActive(true);
                return boxPool[i];
            }
        }

        BoxController boxObject = Instantiate(boxPrefab, transform);
        boxPool.Add(boxObject);
        return boxObject;
    }

    public void RespawnBox() => StartCoroutine(ReSpawnBox());
    IEnumerator ReSpawnBox()
    {
        yield return new WaitForSeconds(3);
        BoxController coin = GetBox();
        coin.Spawn();
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