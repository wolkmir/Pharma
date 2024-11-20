using UnityEngine;

public class Area : MonoBehaviour
{
    [field: SerializeField] public Transform Pivot { get; private set; }
    [field: SerializeField] public GameObject State { get; private set; }
    [field: SerializeField] public float InteractionDistance { get; private set; } = 2.0f;
}