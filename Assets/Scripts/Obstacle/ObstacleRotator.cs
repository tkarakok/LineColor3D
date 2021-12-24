using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotator : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _waitForSeconds;

    private void Start()
    {
        StartCoroutine(Rotator());
    }
    
    IEnumerator Rotator( )
    {
        while (true)
        {
            yield return new WaitForSeconds(_waitForSeconds);
            transform.Rotate(0, _speed * Time.deltaTime, 0, Space.Self);
        }
        
    }
}
