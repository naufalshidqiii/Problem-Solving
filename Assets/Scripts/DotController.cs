using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotController : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [SerializeField]
    private float xForceRange;
    [SerializeField]
    private float yForceRange;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Invoke("Push", 1);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void Push()
    {
        //Randomize force
        float yRandomForce = Random.Range(-yForceRange - 50, yForceRange + 50);
        float xRandomForce = Random.Range(-xForceRange - 50, xForceRange + 50);

        //Direction
        Vector2 direction = Vector2.zero;
        direction = new Vector2(xRandomForce, yRandomForce);

        //Add force to rb
        rb2D.AddForce(direction);
    }
}
