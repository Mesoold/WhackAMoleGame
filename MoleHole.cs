using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleHole : MonoBehaviour
{
    public Transform MoleTransform;

    public float Speed = 10;
    bool isMoveUp = false;

    public bool Canhit = false;

    public SpriteRenderer MoleRenderer;
    public Sprite NormalMole;
    public Sprite HitMole;

    float counter = 0;
    float Delay;


    private void Start()
    {
        RandomDelay();
    }

    void RandomDelay()
    {
        Delay = Random.Range(2.0f, 4.0f);
    }

    void Update()
    {
        counter += Time.deltaTime;
        if(counter > Delay)
        {
            isMoveUp = true;
            counter = 0;
            RandomDelay();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            isMoveUp = true;
        }

        if(isMoveUp == true)
        {
            MoveMole();
        }

        if(MoleTransform.localPosition.y >=0)
        {
            isMoveUp = false;
        }
    }

    void MoveMole()
    {
        Canhit = true;
        MoleTransform.Translate(Vector3.up * Speed * Time.deltaTime);   
    }

    public void HitByHammer()
    {
        MoleRenderer.sprite = HitMole;

        Invoke("Reset", 0.5f);
    }

    private void Reset()
    {
        counter = 0;
        RandomDelay();
        
        Canhit = false;
        MoleRenderer.sprite = NormalMole;
        MoleTransform.localPosition = new Vector3(0, -3, 0);
    }
}
