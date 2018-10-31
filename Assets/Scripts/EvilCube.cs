using UnityEngine;
using System.Collections;

public class EvilCube : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(this.transform.position.x, -5, this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRandonY();
    }

    void UpdateRandonY() {

        if (transform.position.y == -5) {
        
            float y = Random.Range(-1, 3);
            transform.position = new Vector3(this.transform.position.x, y, this.transform.position.z);
        }
    } 
}