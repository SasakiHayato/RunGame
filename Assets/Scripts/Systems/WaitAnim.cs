using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitAnim : CustomYieldInstruction
{
    Animator _anim;
    AnimatorStateInfo _info;
    int _savePash;

    public override bool keepWaiting
    {
        get
        {
            int currentPash = _anim.GetCurrentAnimatorStateInfo(0).fullPathHash;
            return _info.normalizedTime < 1 && currentPash == _savePash;
        }
    }

    public WaitAnim(Animator anim)
    {
        _anim = anim;
        _info = anim.GetCurrentAnimatorStateInfo(0);
        _savePash = _info.fullPathHash;
    }
}
