using System.Collections;
using System.Collections.Generic;


using Pathfinding;
using UnityEngine;
using UnityEngine.Events;

public class BotAIReachedController : MonoBehaviour
{
    IAstarAI ai;
    Transform tr;
    protected Vector3 lastTarget;
    bool isAtDestination;

    private BotAnimatorController _botAnimatorController;
    private BotAIDestinationSetter _botAIDestinationSetter;
    private TextInstantor _textInstantor;
    public UnityEvent EndOfPlayerPath;

    public bool IsClearState = false;
    private AudioManager _aManager;
    
    void OnTargetReached () {
       /* if ( Vector3.Distance(tr.position, lastTarget) > 1f) {
            //GameObject.Instantiate(endOfPathEffect, tr.position, tr.rotation);
            lastTarget = tr.position;
            
            _botAIDestinationSetter.target = null;
            if(!IsClearState)EndOfPlayerPath.Invoke();
            Debug.Log("A* Movemend Ending!");
            if(!IsClearState)_botAnimatorController.SetWalkState(false);*/
           GetComponent<AIPath>().canMove = false;
           _botAIDestinationSetter.target = null;
           _aManager.PlaySitSound();
            //Destroy(GetComponent<AIPath>());
            if (!IsClearState)
            {
                var t = GetComponent<TextInstantor>().TableObject;
                Vector3 dir = t.transform.position - transform.position;
                Quaternion lookRot = Quaternion.LookRotation(dir);
                lookRot.x = 0; lookRot.z = 0;
                transform.rotation = lookRot;
                
                
                _botAIDestinationSetter.target = null;
                if(!IsClearState)EndOfPlayerPath.Invoke();
               // Debug.Log("A* Movemend Ending!");
                _botAnimatorController.SetWalkState(false);
               // transform.position = _botAIDestinationSetter.target.position;
             //  GetComponent<AIPath>().Teleport(  _botAIDestinationSetter.target.position,true);
            
            }
            else
            {
               // _botAnimatorController.SetWalkState(true);

               // Debug.LogError(Vector3.Distance(_botAIDestinationSetter.target.position, transform.position) + " " +_botAIDestinationSetter.target.name);
              // gameObject.SetActive(false);
            }
          
        //}
        /*else
        {
        }*/
    }
    void Start()
    {
        ai = GetComponent<IAstarAI>();
        tr = GetComponent<Transform>();
        _botAnimatorController = GetComponent<BotAnimatorController>();
         _botAIDestinationSetter = GetComponent<BotAIDestinationSetter>();
         _textInstantor = GetComponent<TextInstantor>();
         _aManager = FindObjectOfType<AudioManager>();
    }

    
    // Update is called once per frame
    void Update()
    {
        
           /* if (ai.reachedEndOfPath)
            {
                if (!isAtDestination)
                {
                    OnTargetReached();
                    Debug.Log("BURA");
                }

             
                isAtDestination = true;
            }
            else
            {
                isAtDestination = false;
            }*/
            if (_botAIDestinationSetter.target != null)
            {
                GetComponent<AIPath>().canMove = true;
                

               // Debug.LogError(Vector3.Distance(_botAIDestinationSetter.target.position, transform.position));
               Vector3 heading = _botAIDestinationSetter.target.position - transform.position;
                if (heading.magnitude <= .25f)
                {
                    //var rotation = Quaternion.LookRotation(_textInstantor.TableObject.transform.position - transform.position);
                    transform.position = _botAIDestinationSetter.target.position;
                   // var rotation = Quaternion.LookRotation(_textInstantor.TableObject.transform.position - transform.position);
                    //ai.FinalizeMovement(_botAIDestinationSetter.target.localPosition,rotation);
                    if (!IsClearState)
                    {
                        //  ai.FinalizeMovement(_botAIDestinationSetter.target.localPosition,rotation);
                       // Debug.Log(heading.magnitude + " " + transform.position + " " + _botAIDestinationSetter.target.transform.position);

                        //transform.position = _botAIDestinationSetter.target.position;
                        //transform.rotation = rotation;
                    }
                    else
                    {
                       

                    }
                   
                    OnTargetReached();

                }
                    
            }
            // Calculate the velocity relative to this transform's orientation
            //Vector3 relVelocity = tr.InverseTransformDirection(ai.velocity);
            //relVelocity.y = 0;

            // Speed relative to the character size
            //anim.SetFloat("NormalizedSpeed", relVelocity.magnitude / anim.transform.lossyScale.x);
        
    }
}
