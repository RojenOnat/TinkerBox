using UnityEngine;


    public class BotAnimatorController : MonoBehaviour
    {
        public Animator BotAnimator;
        private readonly int walkState = Animator.StringToHash("Walking");
        private readonly int sittingState = Animator.StringToHash("Sitting");


        public void SetWalkState(bool isWalking) => BotAnimator.SetBool(walkState, isWalking);
        public void TriggerSittingState() => BotAnimator.SetTrigger(sittingState);
    }

