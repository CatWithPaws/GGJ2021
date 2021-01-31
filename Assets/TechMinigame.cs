
using System.Collections;
using UnityEngine;

public class TechMinigame : MonoBehaviour
{
    public GameObject platformPrefab;
    public Animator lineAnimator;

    public int pointsToHit = 3;

    public bool didLoose;
    public int points;
    public float speed;
    void Start()
    {
        object inGame = true;
        FindObjectOfType<Player>().SetControl(false);
        StartCoroutine(GameCheck());
        StartCoroutine(SpawnBullets());
    }

    private IEnumerator SpawnBullets()
    {
        while (points < pointsToHit && !didLoose)
        {
            yield return new WaitForSeconds(3.5f);
            Instantiate(platformPrefab, transform);
        }
    }

    private IEnumerator GameCheck()
    {
        while (points < pointsToHit && !didLoose)
        {
            lineAnimator.speed = speed;
            var state = lineAnimator.GetCurrentAnimatorStateInfo(0);
            
            if (state.IsName("Idle"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    lineAnimator.Play("Move");
                }
            }
            yield return null;
        }

        if (didLoose)
        {
            WorldBroadcast.GameEngLoose.Publish(gameObject);
        } else WorldBroadcast.GameEngWin.Publish(gameObject);

        FindObjectOfType<Player>().SetControl(true);
        Destroy(gameObject);
    }
}
