using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

namespace TZUnfrozen.Characters
{
    public class AnimatorCharacters : MonoBehaviour
    {
        public SkeletonAnimation skeletonAnimation;
        public AnimationReferenceAsset idle, attack, damage, skip;

        public string eventName;
        public string currentState;

        public Spine.EventData eventData;


        public Spine.TrackEntry SetAnimation(AnimationReferenceAsset animation, bool loop, float timeScale)
        {
            //skeletonAnimation.state.SetAnimation(0, animation, loop).TimeScale = timeScale;
            Spine.TrackEntry track = skeletonAnimation.state.SetAnimation(0, animation, loop);
            track.TimeScale = timeScale;
            return track;
        }



        public Spine.TrackEntry Idle()
        {
            GetComponent<MeshRenderer>().sortingOrder = 2;
            Spine.TrackEntry track = SetAnimation(idle, true, 1);
            return track;
            
           
        }

        public Spine.TrackEntry Attack()
        {

            GetComponent<MeshRenderer>().sortingOrder = 3;
            Spine.TrackEntry track = SetAnimation(attack, false, 1);
            return track;
            
            
        }

        public Spine.TrackEntry Damage()
        {
            GetComponent<MeshRenderer>().sortingOrder = 3;
            Spine.TrackEntry track = SetAnimation(damage, false, 1);
            return track;
        }


        public Spine.TrackEntry Skip()
        {
           
            GetComponent<MeshRenderer>().sortingOrder = 3;
            Spine.TrackEntry track = SetAnimation(skip, false, 1);
            return track;
        }

        private void Start()
        {

            Idle();
            eventData = skeletonAnimation.Skeleton.Data.FindEvent(eventName);
        }


    }
}