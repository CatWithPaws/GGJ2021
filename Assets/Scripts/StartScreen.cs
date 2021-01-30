using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void OnAnimationEnd()
    {
        SceneManager.LoadScene(1);
    }
}
