using UnityEngine;
using UnityEngine.UI;
using Sounds;

public class SoundSetter : MonoBehaviour
{
    enum Type
    { 
        Strat,
        Button,
    }

    [SerializeField] Type _type;
    [SerializeField] int _requestID;
    [SerializeField] int _groupID;

    void Start()
    {
        if (_type == Type.Strat)
        {
            SoundMaster.Request(null, _requestID, _groupID);
        }
        else
        {
            Button button = transform.parent.GetComponent<Button>();
            button.onClick.AddListener(() => CallBack());
        }
    }

    public void CallBack()
    {
        Debug.Log("aaa");
        SoundMaster.Request(null, _requestID, _groupID);
    }
}
