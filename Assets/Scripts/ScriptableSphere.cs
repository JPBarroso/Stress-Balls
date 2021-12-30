using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Balls/ScriptableBall", order = 1)]
public class ScriptableSphere : ScriptableObject
{
    public bool isSmall, isMedium, isBig;
    public Color color;

}
