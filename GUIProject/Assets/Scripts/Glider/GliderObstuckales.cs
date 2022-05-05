using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class GliderObstuckales : MonoBehaviour
{
    public Transform top;
    public Transform bottom;

    private float speed;
    private float leftEdge;

    private void Start()
    {
        speed = 1.0f;
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        
    }
    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < leftEdge) {
            Destroy(gameObject);
        }
    }


      public void speedIncrease(){
         if (speed <= 10f) {
            Debug.Log("Working");
            speed += 1.0f;
            Debug.Log(speed);

         }
    }
    public  void speedDown(){
         if (speed >= 1f) {
            Debug.Log("Working");
            speed -= 1f;
         }
    }

}
