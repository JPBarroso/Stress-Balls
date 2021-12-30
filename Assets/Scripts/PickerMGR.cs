using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class PickerMGR : MonoBehaviour
{
    public ScriptableSphere[] spheres;
    public GameObject content, button;
    public Color lightText, darkText;
    string sizes;
    [Range(0f, 1f)]
    public float brightnessTolerance = 0.4f;
    public SizeMGR sizeManager;
    Button _default;
    // Start is called before the first frame update
    void Start()
    {
        spheres = Resources.LoadAll("Spheres", typeof(ScriptableSphere)).Cast<ScriptableSphere>().ToArray();
        ButtonCreator();
    }


    void ButtonCreator()
    {
        TextMeshProUGUI colortext, sizetext;

        for (int i = 0; i < spheres.Length; i++)
        {
            Button newbutton = Instantiate(button, content.transform).GetComponent<Button>();
            newbutton.GetComponent<ButtonMGR>().sphere = spheres[i];
            newbutton.GetComponent<ButtonMGR>().sizeManager = sizeManager;
            colortext = newbutton.transform.Find("Color").GetComponent<TextMeshProUGUI>();
            sizetext = newbutton.transform.Find("Size").GetComponent<TextMeshProUGUI>();
            colortext.text = spheres[i].name;
            sizetext.text = StringComposer(spheres[i]);
            newbutton.transform.SetParent(content.transform);
            Color newcolor = new Color(spheres[i].color.r, spheres[i].color.g, spheres[i].color.b, 255); 
            newbutton.image.color = newcolor;
            Brightness(newcolor); //We run the formula twice for good measure.
            if(Brightness(spheres[i].color) > brightnessTolerance) //If brightness is above our tolerance levels, we use a dark font, and vice versa.
            {
                colortext.color = darkText;
                sizetext.color = darkText;
            }
            else
            {
                colortext.color = lightText;
                sizetext.color = lightText;
            }
        }
    }
    string StringComposer(ScriptableSphere sphere)
    {
        sizes = "";
        if(sphere.isSmall)
        {
            sizes = "Small | ";
        }
        if (sphere.isMedium)
        {
            sizes = sizes + "Medium | ";
        }
        if (sphere.isBig)
        {
            sizes = sizes + "Large";
        }
        return sizes;
    }
    float Brightness(Color col) //We use the HSP formula to decide if the color being used in the button is bright or dark.
    {
        float brightness = Mathf.Sqrt((0.299f * (col.r * col.r)) + (0.587f * (col.g * col.g))+(0.114f * (col.b * col.b)));
        return brightness;
    }
}
