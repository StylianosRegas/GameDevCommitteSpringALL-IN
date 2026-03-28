using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCards : MonoBehaviour
{
    public GameObject shield;
    public Health playerHealth;
    public GameObject wallSpawn;
    public GameObject PlatformSpawn;
    public Transform player;
    public float spawnDistance = 2;
    public void activeSheild()
    {
        Debug.Log("Sheild Activated");
        StartCoroutine(SheildTimer(5f));
    }

    IEnumerator SheildTimer(float duration)
    {
        shield.SetActive(true);
        playerHealth.shieldActive = true;

        yield return new WaitForSeconds(duration);

        shield.SetActive(false);
        playerHealth.shieldActive = false;

        Debug.Log("Shield Ended");
    }

    public void SpawnWall()
    {
        Debug.Log("Wall Ability Activated");

        Vector3 direction = player.right;
        Vector3 spawnPos = player.position + direction * spawnDistance;
        GameObject wall = Instantiate(wallSpawn, spawnPos, Quaternion.identity);
        StartCoroutine(DestroyWall(wall, 15f));
    }

    public void SpawnPlatform()
    {
        Debug.Log("Platform Ability Activated");

        Vector3 direction = -player.up;
        Vector3 spawnPos = player.position + direction * spawnDistance;
        GameObject Platform = Instantiate(PlatformSpawn, spawnPos, Quaternion.identity);
        StartCoroutine(DestroyWall(Platform, 15f));
    }

    IEnumerator DestroyWall(GameObject wall, float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(wall);
    }
}
