using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Sirenix.OdinInspector;
using UnityEngine;

public class Engine : MonoBehaviour
{
    public static Engine E => _instance;
    private static Engine _instance;

    [BoxGroup("Game Systems Details")]
    [Required]
    public InputManager InputManager;
    [BoxGroup("Player Details")]
    [Required]
    public Character.Character Player;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
