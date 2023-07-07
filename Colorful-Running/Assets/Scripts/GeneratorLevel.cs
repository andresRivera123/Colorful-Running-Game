using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] levelPart; //Generar area de juego
    [SerializeField] private float minDistance; //distancia minima 
    [SerializeField] private Transform finalPoint; //Punto final
    [SerializeField] private int initialQuantity; //Entero con partes del nivel
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //Posicion del jugador
        for(int i = 0; i < initialQuantity; i++)
        {
            GeneratePartLevel();   
        }
    }

    private void Update()
    {
        //Comprobar si el jugador esta cerca para generar el nivel
        if (Vector2.Distance(player.position, finalPoint.position) < minDistance)
        {
            GeneratePartLevel();
        }
    }

    private void GeneratePartLevel()
    {
        int aleatoryNumber = Random.Range(0, levelPart.Length);
        GameObject nivel = Instantiate(levelPart[aleatoryNumber], finalPoint.position , Quaternion.identity);
        finalPoint = SearchFinalPoint(nivel, "FinalPoint");
    }

    private Transform SearchFinalPoint(GameObject partLevel, string tag)
    {
        Transform point = null;
        foreach (Transform ubication in partLevel.transform)
        {
            if (ubication.CompareTag(tag))
            {
                point = ubication;
                break;
            }
        }
        return point;
    }

}
