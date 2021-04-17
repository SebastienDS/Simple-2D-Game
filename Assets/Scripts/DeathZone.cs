using System.Collections;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private Transform playerSpawn;
    private Animator fadeSystem;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ReplacePlayer(collision.transform));
        }
    }

    private IEnumerator ReplacePlayer(Transform playerTransform)
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);

        playerTransform.position = playerSpawn.position;
    }

}
