using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformGeneratpr : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    public float spawnInterval = 2f;
    public float moveSpeed = 2f;

    private List<GameObject> activePlatforms = new List<GameObject>();
    private List<GameObject> inactivePlatforms = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(SpawnPlatforms());
    }

    private IEnumerator SpawnPlatforms()
    {
        while (true)
        {
            GameObject platform = GetInactivePlatform();

            if (platform == null)
            {
                platform = InstantiateRandomPlatform();
            }

            platform.SetActive(true);
            platform.transform.position = transform.position;

            activePlatforms.Add(platform);
            inactivePlatforms.Remove(platform);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private GameObject InstantiateRandomPlatform()
    {
        int randomIndex = Random.Range(0, platformPrefabs.Length);
        GameObject platform = Instantiate(platformPrefabs[randomIndex], transform);
        inactivePlatforms.Add(platform);
        return platform;
    }

    private GameObject GetInactivePlatform()
    {
        if (inactivePlatforms.Count > 0)
        {
            return inactivePlatforms[0];
        }

        return null;
    }

    private void Update()
    {
        MovePlatforms();
    }

    private void MovePlatforms()
    {
        for (int i = 0; i < activePlatforms.Count; i++)
        {
            activePlatforms[i].transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

            if (activePlatforms[i].transform.position.x < -10f)
            {
                activePlatforms[i].SetActive(false);
                activePlatforms.RemoveAt(i);
                i--;
            }
        }
    }
}
