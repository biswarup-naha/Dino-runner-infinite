using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private float xVel;
    private Vector3 offset;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -9.8f)
            Destroy(gameObject);
        //offset = new Vector3(xVel, 0, 0);

        //transform.position -= offset * Time.deltaTime;
        transform.position += Vector3.left * xVel * Time.deltaTime;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name=="Ground")
        {
            offset = new Vector3(xVel, 0, 0);
            transform.position -= offset * Time.deltaTime;
        }
    }
}
