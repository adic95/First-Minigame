using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killbox : MonoBehaviour
{
    void OnTriggerEnter(Collider _col)
    {
        
            Debug.Log("DU hast Verloren");
            Destroy(_col.gameObject);
        
    }
}
