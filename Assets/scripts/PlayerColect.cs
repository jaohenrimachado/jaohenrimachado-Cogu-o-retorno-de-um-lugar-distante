using TMPro;
using UnityEngine;

public class PlayerColect : MonoBehaviour
{
   
    public TextMeshProUGUI scoreText;
    public int score = 0;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coletavel"))
        {
            Destroy(collision.gameObject);
            score++;
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        scoreText.text = score.ToString();
    }
}
