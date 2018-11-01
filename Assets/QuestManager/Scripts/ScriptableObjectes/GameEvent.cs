
using UnityEngine;

[CreateAssetMenu(menuName = "vidioomedia/Game Event", fileName ="Game Event")]
public class GameEvent : ScriptableObject {
    private event System.Action gameEvent;

    public void Invoke()
    {
        gameEvent();
    }

    public void Register(System.Action listner) {
        gameEvent += listner;
    }

    public void UnRegister(System.Action listner)
    {
        gameEvent -= listner;
    }

}
