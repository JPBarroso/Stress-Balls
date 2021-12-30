using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SizeMGR : MonoBehaviour
{
    public float size,maxSize,minSize,steps;
    public GameObject smallButton, mediumButton, largeButton;
    public GameObject ball;
    public TextMeshProUGUI sizeText;
    int _smallerSize;
    bool isBlack;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SizeInitializer(ScriptableSphere sphere)
    {
        _smallerSize = 0;
        if (sphere.isSmall)
        {
            smallButton.SetActive(true);
            _smallerSize = 1; //The smaller size is 1, small.
        }
        else
        {
            smallButton.SetActive(false);
        }
        if (sphere.isMedium)
        {
            mediumButton.SetActive(true);
            if(_smallerSize == 0)
            {
                _smallerSize = 2; //The smaller size is 2, medium.
            }
        }
        else
        {
            mediumButton.SetActive(false);
        }
        if (sphere.isBig)
        {
            largeButton.SetActive(true);
            if(_smallerSize == 0)
            {
                _smallerSize = 3; //The smaller size is 3, large.
            }
        }
        else
        {
            largeButton.SetActive(false);
        }
        if(sphere.name == "Black")
        {
            isBlack = true;
            minSize = 5.0f;
            maxSize = 5.0f;
            size = 5.0f;
            ball.transform.localScale = new Vector3(2f, 2f, 2f);
            sizeText.text = "Fixed Radius of 5";
        }
        else
        {
            isBlack = false;
            switch (_smallerSize)
            {
                case 0:
                    break;
                case 1:
                    SmallSetter();
                    break;
                case 2:
                    MediumSetter();
                    break;
                case 3:
                    BigSetter();
                    break;
            }
        }
        
    }
    public void SmallSetter()
    {
        if (!isBlack)
        {
            minSize = 1.0f;
            maxSize = 1.90f;
            size = 1.40f;
            ball.transform.localScale = new Vector3(size * 0.5f, size * 0.5f, size * 0.5f);
            sizeText.text = "Radius: " + size;
        }
       
    }
    public void MediumSetter()
    {
        minSize = 2.0f;
        maxSize = 2.90f;
        size = 2.40f;
        ball.transform.localScale = new Vector3(size * 0.5f, size * 0.5f, size * 0.5f);
        sizeText.text = "Radius: " + size;
    }
    public void BigSetter()
    {
        if (!isBlack)
        {
            minSize = 3f;
            maxSize = 3.90f;
            size = 3.40f;
            ball.transform.localScale = new Vector3(size * 0.5f, size * 0.5f, size * 0.5f);
            sizeText.text = "Radius: " + size;
        }
        
    }
    public void IncreaseSize()
    {
        if(size < maxSize && !isBlack)
        {
            size = size + 0.10f;
            ball.transform.localScale = new Vector3(size * 0.5f, size * 0.5f, size * 0.5f);
            sizeText.text = "Radius: " + size;
        }
    }
    public void DecreaseSize()
    {
        if(size > minSize && !isBlack)
        {
            size = size - 0.10f;
            ball.transform.localScale = new Vector3(size * 0.5f, size * 0.5f, size * 0.5f);
            sizeText.text = "Radius: " + size;
        }
    }
}
