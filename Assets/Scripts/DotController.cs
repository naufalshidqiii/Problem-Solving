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
    [SerializeField]
    private float _moveConstraint = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        //Invoke("Push", 1); Problem 2
    }

    // Update is called once per frame
    private void Update()
    {
        /* Problem 4 - Move with Input
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        */

        //Problem 5 - Dot follow cursor
        FollowCursor();

    }

    private void FixedUpdate()
    {
        
    }

    //Problem - 2 Push dot, 3 Bounce
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

    //Problem 4 - Move with Input
    private void Move(float h, float v)
    {
        Vector2 direction = new Vector2(h, v).normalized;
        direction = direction * _moveSpeed * Time.deltaTime;
        rb2D.velocity = direction;
    }

    //Problem 5 - Dot follow cursor
    private void FollowCursor()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, cursorPos, _moveSpeed * Time.deltaTime);
    }
}
