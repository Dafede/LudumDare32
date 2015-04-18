using UnityEngine;
using System.Collections;

public class RedDamageBehaviour : MonoBehaviour {

    private Animator _animator;

    void Start() 
    {
        _animator = GetComponent<Animator>();
    }

    public void EndAnimationEvent() {
        _animator.SetBool("ActivateRedDamageIndicator", false);
    }

    public void BeginAnimation() {
        _animator.SetBool("ActivateRedDamageIndicator", true);
    }
}
