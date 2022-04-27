using UnityEngine;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "States/Character/Walk")]
    public class WalkState : State<CharacterCtrl>
    {
        private Rigidbody2D _rigidbody;
        private GroundCheck _groundCheck;
        private CharacterAnimation _animation;
        private float _xInput;
        private bool _jump;

        [SerializeField]
        private float _speed = 5f;

        public override void Init(CharacterCtrl parent)
        {
            base.Init(parent);
            if (_groundCheck == null) _groundCheck = parent.GetComponentInChildren<GroundCheck>();
            if (_rigidbody == null) _rigidbody = parent.GetComponent<Rigidbody2D>();
            if (_animation == null) _animation = parent.CharacterAnimation;
        }

        public override void CaptureInput()
        {
            _xInput = Input.GetAxis("Horizontal");
            _jump = Input.GetButtonDown("Jump");
        }

        public override void Update()
        {
            _rigidbody.velocity = 
                new Vector2(_speed * _xInput, _rigidbody.velocity.y);
            
            _animation.AdjustSpriteRotation(_xInput);
            _animation.WalkingAnimation(_groundCheck.Check());
        }

        public override void FixedUpdate() {}

        public override void ChangeState()
        {
            if (_groundCheck.Check() && _jump)
            {
                _runner.SetState(typeof(JumpState));
            }
        }

        public override void Exit() {}
    }
}
