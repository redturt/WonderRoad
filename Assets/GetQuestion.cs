using UnityEngine;
using System.Collections;

public class GetQuestion : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InitialPlayers.SetQuestion(GetComponent<UnityEngine.UI.Text>());
	}
	
}
