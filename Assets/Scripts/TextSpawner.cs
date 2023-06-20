using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextSpawner : MonoBehaviour
{
    [SerializeField] private TMP_Text labelPrefab;
   
    public void Spawn(Vector3 position,string text)
          
    {
        var label = Instantiate(labelPrefab, position, Quaternion.identity);
        label.text = text;
        Destroy(label.gameObject, 1.5f);

    }
    
}
