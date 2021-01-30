using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelOnTrigger : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider && other.collider.CompareTag("Players"))
        {
            SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
        }
    }
}
