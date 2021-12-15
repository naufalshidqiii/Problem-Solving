using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotController : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [SerializeField]
    private float _xForceRange;
    [SerializeField]
    private float _yForceRange;
    [SerializeField]
    private float _moveSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        //Invoke("Push", 1);
    }

    // Update is called once per frame
    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
    }

    private void FixedUpdate()
    {
        
    }

    private void Push()
    {
        //Randomize force
        float yRandomForce = Random.Range(-_yForceRange - 50, _yForceRange + 50);
        float xRandomForce = Random.Range(-_xForceRange - 50, _xForceRange + 50);

        //Direction
        Vector2 direction = Vector2.zero;
        direction = new Vector2(xRandomForce, yRandomForce);

        //Add force to rb
        rb2D.AddForce(direction);
    }

    private void Move(float h, float v)
    {
        Vector2 direction = new Vector2(h, v).normalized;
        direction = direction * _moveSpeed * Time.deltaTime;
        rb2D.velocity = direction;
    }
}
