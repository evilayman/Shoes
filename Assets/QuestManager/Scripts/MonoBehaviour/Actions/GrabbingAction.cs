using vidioomedia;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace vidioomedia
{
    public class GrabbingAction : Action
    {
        public Interactable interactable;

        public override void Begin()
        {
            base.Begin();
            StartCoroutine(GrabbingActionUpdate());
        }
        private IEnumerator GrabbingActionUpdate()
        {
            while (!interactable.isHovering)
            {
                yield return null;
            }
            yield return new WaitForSeconds(1); ;

            Complete();
            
        }

    }
}