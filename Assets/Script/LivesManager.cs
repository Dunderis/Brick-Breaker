using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vector2 = System.Numerics.Vector2;

public class LivesManager : MonoBehaviour
{
    public int maxLives = 2;
    public int currentLives;
    public Image[] hearts;
    public GameObject ball;
    public GameObject Reset;
    
   

    void Start()
    {
        currentLives = maxLives;
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(true);
        }
    }

    public void LoseLife()
    {
        UpdateHearts();
        currentLives--;
        

        if (currentLives < 0)
        {
            GameOver();
        }
        else
        {
            ball.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            ball.transform.position = new Vector3(0.268f,-2.266f, 0);
            FindObjectOfType<Ball>().ResetBall();
        }
    }

    void UpdateHearts()
    {
        hearts[currentLives].gameObject.SetActive(false);
    }

    void GameOver()
    {
        Reset.SetActive(true);
        ball.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    void Update()
    {
        print(currentLives);
    }
}