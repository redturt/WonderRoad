using UnityEngine;
using System.Collections;

public class GetColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().color = InitialPlayers.GetNextColor();
	}
}
