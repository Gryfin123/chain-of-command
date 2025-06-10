using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    [SerializeField] OpponentDataSO data;

    // Start is called before the first frame update
    void Start()
    {
        data.Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(13);
        }
    }
     
    void TakeDamage(float damageTaken)
    {
        data.TakeDamage(damageTaken);
    }
}
