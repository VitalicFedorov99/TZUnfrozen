using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class AnimatorCharacters : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset idle,attack,damage;


    public string currentState;

    public void SetAnimation(AnimationReferenceAsset animation,bool loop, float timeScale) 
    {

        skeletonAnimation.state.SetAnimation(0,animation,loop).TimeScale=timeScale;
        
    }

    public void Idle(string state) 
    {
        if (state.Equals("Idle")) 
        {
            SetAnimation(idle, true, 1);
        }
    }

    public void Attack(string state) 
    {

        
        if (state.Equals("DoubleShift"))
        {
            SetAnimation(attack, true, 1);
        }
    }

    public void Damage(string state) 
    {
        if (state.Equals("Damage"))
        {
            SetAnimation(damage, true, 1);
        }
    }
    private void Start()
    {
        currentState = "Idle";
        Idle(currentState);
        GetComponent<MeshRenderer>().sortingOrder = 2;
    }

    
}
