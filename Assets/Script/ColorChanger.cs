using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {

    public SpriteRenderer sr;

    public Color blue;
    public Color yellow;
    public Color purple;
    public Color red;

    private float timer = 0;

    private int randomNum = 0;
	void Update () {
        timer += Time.deltaTime * 1;

        if (timer > 0.1f)
        {
            randomNum = Random.Range(0, 4);

            switch (randomNum)
            {
                case 0:
                    sr.color = blue;
                    break;
                case 1:
                    sr.color = yellow;
                    break;
                case 2:
                    sr.color = purple;
                    break;
                case 3:
                    sr.color = red;
                    break;
            }

            timer = 0;
        }
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Finish" || col.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
