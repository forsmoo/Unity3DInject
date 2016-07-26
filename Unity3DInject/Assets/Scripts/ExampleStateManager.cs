using UnityEngine;
using System.Collections;
using DependencyInjection;
using DependencyInjection;

public class ExampleStateManager : MonoBehaviour {

    [Dependency]
    ExampleGameStateFactory stateFactory;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    ExampleGameState gameState;
    public void SetState(string statename)
    {
        gameState = stateFactory.CreateGameState(statename);
        Debug.Log(name + " setting state " + gameState);
    }
}

