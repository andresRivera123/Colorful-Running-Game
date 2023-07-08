using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public List<GameObject> platformPrefabs;
    public float speed = 3f;
    public float minX = -10f;
    public float spawnInterval = 2f;
    public float initialDelay = 1f;
    public int maxActivePlatforms = 7;

    private List<GameObject> activePlatforms = new List<GameObject>();

    private void Start()
    {
        InvokeRepeating("SpawnPlatform", initialDelay, spawnInterval);
    }

    private void Update()
    {
        MovePlatforms();
    }

    private void SpawnPlatform()
    {
        GameObject platform = null;

        // Busca una plataforma desactivada para reutilizar
        for (int i = 0; i < activePlatforms.Count; i++)
        {
            if (!activePlatforms[i].activeSelf)
            {
                platform = activePlatforms[i];
                break;
            }
        }

        // Si no hay plataformas desactivadas disponibles, crea una nueva plataforma
        if (platform == null)
        {
            GameObject randomPrefab = platformPrefabs[Random.Range(0, platformPrefabs.Count)];
            platform = Instantiate(randomPrefab, transform.position, Quaternion.identity);
            activePlatforms.Add(platform);
        }

        // Activa la plataforma y la coloca en la posición inicial
        platform.SetActive(true);
        platform.transform.position = transform.position;
    }

    private void MovePlatforms()
    {
        for (int i = 0; i < activePlatforms.Count; i++)
        {
            activePlatforms[i].transform.Translate(Vector2.left * speed * Time.deltaTime);

            if (activePlatforms[i].transform.position.x < minX)
            {
                activePlatforms[i].SetActive(false);
            }
        }
    }
}
