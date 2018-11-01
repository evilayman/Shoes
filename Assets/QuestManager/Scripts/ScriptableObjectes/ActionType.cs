using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//namespace vidioomedia{
[CreateAssetMenu(menuName = "vidioomedia/Action Type", fileName ="New Action Type" )]
    public class ActionType : ScriptableObject {
        public vidioomedia.Action prefab;
        public string description;
    }
//}