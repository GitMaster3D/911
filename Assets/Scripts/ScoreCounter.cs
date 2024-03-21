using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI hurensohn;
    public static ScoreCounter insance;
    int Penis;
    public int score{get{
        return Penis;
    } set{
        Penis = value;
        hurensohn.text = Penis.ToString();
    }}
    // Start is called before the first frame update
    void Start()
    {
        insance =this;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
