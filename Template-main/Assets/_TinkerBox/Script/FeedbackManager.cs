using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

public class FeedbackManager : MonoBehaviour
{
    public MMF_Player LightVibrate;
    public MMF_Player SellectionVibrate;
    public MMF_Player RigidVibrate;

    public void OnLightVibrate() => LightVibrate.PlayFeedbacks();
    public void OnSellectionVibrate() => SellectionVibrate.PlayFeedbacks();
    public void OnRigidVibrate() => RigidVibrate.PlayFeedbacks();
}
