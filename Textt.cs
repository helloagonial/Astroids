using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class Textt : MonoBehaviour
{
    public EnemySpawner spawner;
    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Killed: "+spawner.killedCount;
    }
}
