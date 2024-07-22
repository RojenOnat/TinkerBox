using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class BotAIDestinationSetter : MonoBehaviour
{
    public Transform target;
    IAstarAI ai;
    private Transform t;
    private BotAnimatorController _botAnimatorController;
		
    void OnEnable () {
        ai = GetComponent<IAstarAI>();
        // Update the destination right before searching for a path as well.
        // This is enough in theory, but this script will also update the destination every
        // frame as the destination is used for debugging and may be used for other things by other
        // scripts as well. So it makes sense that it is up to date every frame.
        if (ai != null) ai.onSearchPath += Update;
    }

    void OnDisable () {
        if (ai != null) ai.onSearchPath -= Update;
    }

    private void Start()
    {
        _botAnimatorController = GetComponent<BotAnimatorController>();
    }

    /// <summary>Updates the AI's destination every frame</summary>
    void Update () {
        if (target != null && ai != null)
        {
            ai.destination = target.position;
				_botAnimatorController.SetWalkState(true);
                t = target;
        }

        if (ai.reachedEndOfPath) transform.position = t.position;
    }
}
