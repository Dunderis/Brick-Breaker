using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    private bool isLaunched = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        transform.position = new Vector2(0.268f,-2.266f); 
    }

    void Update()
    {
        if (!isLaunched && Input.GetKeyDown(KeyCode.Space))
        {
            LaunchBall();
        }
    }

    void LaunchBall()
    {
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), 1).normalized;
        rb.velocity = direction * speed;
        isLaunched = true;
    }

    public void ResetBall()
    {
        isLaunched = false;
        rb.velocity = Vector2.zero;
        transform.position = new Vector2(0.268f,-2.266f); 
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Paddle"))
        {
            float x = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, 1);
            rb.velocity = dir * speed;
        }
        if (collision.gameObject.CompareTag("Death"))
        {
            FindObjectOfType<LivesManager>().LoseLife();
            
        }
    }
    float HitFactor(Vector2 ballPos, Vector2 paddlePos, float paddleWidth)
    {
        return (ballPos.x - paddlePos.x) / paddleWidth;
    }
}
