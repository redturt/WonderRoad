using UnityEngine;
using System.Collections;

public class RandomStep : MonoBehaviour {

    private int count = 3;

	// Use this for initialization
	void Start () {
	}

    void Update()
    {
        if (count == 0)
        {
            transform.position = new Vector3(transform.position.x + Random.Range(-0.01f, 0.01f), transform.position.y + Random.Range(-0.01f, 0.01f), 0);
        }
        if (count >= 0)
        {
            count--;
        }
    }
}
