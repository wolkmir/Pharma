using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public static ActionManager _inst;

    [SerializeField]
    private KeyCode[] _keyCodes;

    private GameObject _pickable;
    private Action[] _currentProfile;

    void Awake()
    {
        _inst = this;
    }

    void Update()
    {
        if (_currentProfile == null) return;

        for (int i = 0; i < _currentProfile.Length; i++)
        {
            Action action = _currentProfile[i];

            if (Input.GetKeyDown(_keyCodes[i]) && action.CanActivate(_pickable))
            {
                action.Activate(_pickable);
                break;
            }
        }
    }

    public void Display(GameObject pickable, Action[] profile)
    {
        _pickable = pickable;
        _currentProfile = profile;
    }

    public void Hide()
    {
        _pickable = null;
        _currentProfile = null;
    }
}
