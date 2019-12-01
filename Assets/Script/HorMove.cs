using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorMove : MonoBehaviour {

    public List<GameObject> diagonals = new List<GameObject>();

    public float speed = 0;

    private List<float> x = new List<float>();

    private int direction = 1;
    private void Start()
    {
        int r = Random.Range(0, 2);

        if (r == 1)
            direction = -1;

        for (int i = 0; i < diagonals.Count; i++)
        {
            x.Add(diagonals[i].transform.position.x);
        }
    }
    void Update()
    {
        for (int i = 0; i < x.Count; i++)
        {

            x[i] += Time.deltaTime * speed * direction;

            diagonals[i].transform.position = new Vector3(x[i], diagonals[i].transform.position.y, diagonals[i].transform.position.z);

            if (diagonals[i].transform.position.x > 3.5f)
                x[i] = -3.5f;
            else if (diagonals[i].transform.position.x < -3.5f)
                x[i] = 3.5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }
}
