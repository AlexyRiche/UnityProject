using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText;
    public void Setup(int score) {
        gameObject.SetActive(true);
        scoreText.text = "Score : " + score.ToString(); 
    }

    public void playAgain() {
        SceneManager.LoadScene("Game");
    }
}
