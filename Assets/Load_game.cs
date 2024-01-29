using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Load_game : MonoBehaviour
{
    [SerializeField] float load = 1f;
    public GameObject endGame;
    // Start is called before the first frame update
    public void ReLoadGame()
    {
        endGame.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Spike")
        {
            endGame.SetActive(true);
            Debug.Log("va cham");
            //SceneManager.LoadScene(0);
        }
    }
}
