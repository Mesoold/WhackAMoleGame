using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hammer : MonoBehaviour
{
    public SpriteRenderer HammerRenderer;
    public Sprite NormalHammer;
    public Sprite HitHammer;

    Collider2D hammerCollider;

    public Text ScoreText;
    int score = 0;

    public Text TimeText;
    public float time = 30;

    public GameObject GameOverObject;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        hammerCollider = GetComponent<Collider2D>();
        hammerCollider.enabled = false;
    }

   void RestartGame()
   {
        SceneManager.LoadScene("SampleScene");
   }
    void Update()
    {
        time -= Time.deltaTime;
        
        if(time <= 0)
        {
            GameOverObject.SetActive(true);
            Invoke("RestartGame", 2);
            return;
        }
        else
        {
            TimeText.text = "Time:" + Mathf.FloorToInt(time).ToString();
        }

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;

        if(Input.GetMouseButtonDown(0))
        {
            HammerRenderer.sprite = HitHammer;
            hammerCollider.enabled = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            HammerRenderer.sprite = NormalHammer;
            hammerCollider.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collosion)
    {
        var hole = collosion.gameObject.GetComponentInParent<MoleHole>();
        if(hole.Canhit==true)
        {
            Debug.Log(collosion.gameObject.name);
            hole.HitByHammer();
            score += 1;
            ScoreText.text = score.ToString();
        }
    }
}
