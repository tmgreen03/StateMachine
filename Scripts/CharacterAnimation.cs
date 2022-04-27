﻿using UnityEngine;

namespace StateMachine
{
    public class CharacterAnimation
    {
        private readonly Animator _animator;
        private readonly Transform _transform;

        public CharacterAnimation(Animator animator, Transform transform)
        {
            _animator = animator;
            _transform = transform;
        }
        public void AdjustSpriteRotation(float xInput)
        {
            if (xInput != 0)
            {
                _transform.localScale = new Vector3(Mathf.Sign(xInput), 1, 1);
            }
        }
        public void WalkingAnimation(bool isGrounded)
        {
            _animator.SetBool("IsWalking", Input.GetAxisRaw("Horizontal") != 0 && isGrounded);
        }
    }
}
