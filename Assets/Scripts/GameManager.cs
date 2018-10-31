using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private Text _scoreText;

    [SerializeField]
    private Text _textGameOver;

    [SerializeField]
    private GameObject _cube;

    [SerializeField]
    private GameObject _evilCube;

    void Start () {

        _textGameOver.gameObject.SetActive(false);

        ConfigLevel();
	}
	
	void Update () {
		
	}

    void ConfigLevel() {

        for (int i = 0; i < 6; i++) {
            CreateCube(_cube);
        }

        for (int i = 0; i < 2; i++) {
            CreateCube(_evilCube);
        }
    }

    public void UpdateScore() {

        ScoreManager.IncraseScore();

        _scoreText.text = "Cubos destruídos: " + ScoreManager.score;

        if (ScoreManager.score == 10) {

            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level_1")) {
                SceneManager.LoadScene("Level_2", LoadSceneMode.Single);
            } else {
                SceneManager.LoadScene("Level_1", LoadSceneMode.Single);
            }
        }

        CreateCube(_cube);
        CreateCube(_evilCube);
    }

    public void gameOver() {
        _textGameOver.gameObject.SetActive(true);
    }

    void CreateCube(GameObject _gameObj){

        float x = Random.Range(-100, 100);
        float y = 1;
        float z = Random.Range(-100, 100);
        Vector3 pos = new Vector3(x, y, z);

        Instantiate(_gameObj, pos, Quaternion.identity);
    }
}
