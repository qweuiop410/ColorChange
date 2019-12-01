using UnityEngine;

public class Rotator : MonoBehaviour {

    public float speed = 100f;

    private int moveDirection = 1;
    private void Start()
    {
        int r = Random.Range(0, 2);

        if (r == 0)
        {
            moveDirection *= -1;
        }
    }

    private void Update()
    {
        transform.Rotate(0f, 0f, speed * Time.deltaTime  * moveDirection);
    }
}
