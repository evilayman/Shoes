using vidioomedia;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace vidioomedia
{
    public class StambingAction : Action
    {
        private void Start()
        {
        }
        public override void Begin()
        {
            base.Begin();
            StartCoroutine(AudioActionUpdate());
        }
        private IEnumerator AudioActionUpdate()
        {
            while (GameObject.FindGameObjectsWithTag("Stampable").Length>0)
            {
                yield return new WaitForSeconds(.1f);
            }

            Complete();   
        }
    }
}