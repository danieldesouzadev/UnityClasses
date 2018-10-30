using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private int _score = 0;

    [SerializeField]
    private Text _scoreText;    
    
    void Start () {
		
	}
	
	void Update () {
		
	}

    public void UpdateScore() {
        _scoreText.text = "Cubos destruídos: " + ++_score;
    }
}
