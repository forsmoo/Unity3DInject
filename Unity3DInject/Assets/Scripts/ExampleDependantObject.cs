using UnityEngine;
using System.Collections;
using DependencyInjection;

public class ExampleDependantObject : MonoBehaviour {

    [Dependency]
    ExampleStateManager stateManager;

    void Awake()
    {
        Debug.Log(name + " has dependency set in awake " + stateManager.name);
    }
	// Use this for initialization
	void Start () {
        stateManager.SetState(name);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
