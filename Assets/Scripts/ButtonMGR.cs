using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMGR : MonoBehaviour
{
    public ScriptableSphere sphere;
    public SizeMGR sizeManager;
    GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClick()
    {
        ball.GetComponent<MeshRenderer>().material.SetColor("Base_Color", sphere.color);
        sizeManager.SizeInitializer(sphere);
    }
}
