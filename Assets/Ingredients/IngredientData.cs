using UnityEngine;

[CreateAssetMenu(fileName = "New IngredientData", menuName = "Ingredient Data", order = 51)]
public class IngredientData : ScriptableObject
{
    public string name;
    public float density;
    public Color color;
}
