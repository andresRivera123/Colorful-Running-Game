using UnityEngine;
using TMPro;

public class TouchBall : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textScore = null;
    [SerializeField] private TextMeshProUGUI textKM = null;
    [SerializeField] private static bool touchBall = false;
    [SerializeField] private TextMeshProUGUI minus = null;
    [SerializeField] private TextMeshProUGUI plus = null;
    [SerializeField] private int scoreParty = 0;
    private float distance;

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("GoodBall"))
        {
            scoreParty++;
        }
        if (player.CompareTag("BadBall"))
        {
            scoreParty--;
        }
    }

    private void Update()
    {
        distance += Time.deltaTime;
        float kilometers = distance /10f;
        string kilometersString = kilometers.ToString("F2");//Cifras decimales

        //Imprimir en el texto
        textScore.text = "SCORE: " + scoreParty.ToString();
        textKM.text = "KM: " + kilometersString;
    }

    private void PrintSign()
    {
        
    }
}
