using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using DependencyInjection;


public class ExampleGameStateFactory : MonoBehaviour
{
    public ExampleGameState CreateGameState(string name)
    {
        var goState = new GameObject(name);
        var state = goState.AddComponent<ExampleGameState>();
        GameDependencies.SetDependencies(state);
        return state;
    }
}

