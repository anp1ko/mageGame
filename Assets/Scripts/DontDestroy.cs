using System;
using UnityEngine;
public class DontDestroy : MonoBehaviour
{
    private string _objectId;

    private void Awake()
    {
        _objectId = name + transform.position.ToString();
    }

    private void Start()
    {
        for (int i = 0; i < FindObjectsByType<DontDestroy>(FindObjectsSortMode.None).Length; i++)
        {
            if (FindObjectsByType<DontDestroy>(FindObjectsSortMode.None)[i] != this)
            {
                if (FindObjectsByType<DontDestroy>(FindObjectsSortMode.None)[i]._objectId == _objectId)
                {
                    Destroy(gameObject); 
                }
            }
        }
        
        
        DontDestroyOnLoad(gameObject);
    }
}
