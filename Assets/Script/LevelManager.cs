using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject brickPrefab;
    public int rows = 5;
    public int columns = 8;
    public float spacing = 0.1f;
    public Vector2 startPos = new Vector2(-3.5f, 4f);
    public GameObject button;

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        Vector2 brickSize = brickPrefab.GetComponent<SpriteRenderer>().bounds.size;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector2 pos = startPos + new Vector2(
                    col * (brickSize.x + spacing),
                    -row * (brickSize.y + spacing)
                );

                Instantiate(brickPrefab, pos, Quaternion.identity, transform);
            }
        }
    }
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Brick").Length == 0)
        {
           button.SetActive(true);
        }
    }

}