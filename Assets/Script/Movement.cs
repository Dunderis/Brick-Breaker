using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    
        public float speed = 10f;

        void Update()
        {
            float move = Input.GetAxis("Horizontal");
            transform.position += (Vector3.right * move * speed * Time.deltaTime);
        }
    

}
