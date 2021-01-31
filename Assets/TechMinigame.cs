
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
            GameObject asdasd = Instantiate(platformPrefab, transform);
			asdasd.GetComponent<BulletInfoBehaviour>().minigame = this;
        }
    }

    private IEnumerator GameCheck()
    {
        while (points < pointsToHit && !didLoose)
        {
            //lineAnimator.speed = speed;
            var state = lineAnimator.GetCurrentAnimatorStateInfo(0);
            
            if (state.IsName("Idle"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    lineAnimator.Play("Move");
                    Invoke(nameof(CheckBullets), 0.3f);
                }
            }
            yield return null;
        }
        print(didLoose);
        if (didLoose)
        {
            WorldBroadcast.GameEngLoose.Publish(gameObject);
        } else WorldBroadcast.GameEngWin.Publish(gameObject);

        FindObjectOfType<Player>().SetControl(true);
        Destroy(gameObject);
    }

    private void CheckBullets()
    {
        foreach (var b in FindObjectsOfType<BulletInfoBehaviour>())
        {
            if (b.transform.position.x < 4.5f && b.transform.position.x > -4.5f)
            {
                points++;
                print("HitPoint");
                Destroy(b.gameObject);
            }
        }
    }
}
