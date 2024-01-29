using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Scenes : MonoBehaviour
{
    [SerializeField] float levelLoad = 0.1f;
    // Start is called before the first frame update

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoad);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        FindObjectOfType<ScenesPesits>().ResetScenePersist();
        SceneManager.LoadScene(nextSceneIndex);
    }
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(LoadNextLevel());
        }
    }
    public void loadGame()
    {
        StartCoroutine(LoadNextLevel());
    }
}
