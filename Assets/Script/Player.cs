using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject spawnPoint;

    public List<GameObject> enemyPrefabs = new List<GameObject>();

    public float jumpForce = 0;

    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public string currentColor;

    public Color colorBlue;
    public Color colorYellow;
    public Color colorPurple;
    public Color colorRed;

    public TextMesh scoreText;

    private int score = 0;
    
    private void Start()
    {
        SetRandomColor();

        rb.bodyType = RigidbodyType2D.Kinematic;
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;

            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != currentColor)
        {
            if (col.tag == "ColorChange")
            {
                SetRandomColor();

                score++;
                scoreText.text = score + "";

                int randomEnemy = Random.Range(0, enemyPrefabs.Count);
                Instantiate(enemyPrefabs[randomEnemy], spawnPoint.transform.position, Quaternion.identity);
            }
            else
            {
                SceneManager.LoadScene("ColorChange");
                // Debug.Log("Game Over");
            }
        }
    }

    private void SetRandomColor()
    {
        int index = Random.Range(0, 4);
        
        switch (index)
        {
            case 0:
                currentColor = "Blue";
                sr.color = colorBlue;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Purple";
                sr.color = colorPurple;
                break;
            case 3:
                currentColor = "Red";
                sr.color = colorRed;
                break;
        }
    }
}
