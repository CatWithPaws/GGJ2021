using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelOnTrigger : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    private void OnCollisionEnter2D(Collision2D other)
    {
        print(other.collider.name);
        if (other.collider && other.collider.CompareTag("Players"))
        {
            print("Collided with levelloader");
            SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
        }
    }
}
