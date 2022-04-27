using UnityEngine;

namespace StateMachine
{
    [CreateAssetMenu(menuName = "States/Character/Jump")]
    public class JumpState : State<CharacterCtrl>
    {
        private GroundCheck _groundCheck;
        private Rigidbody2D _rigidbody;
        private bool _leftTheGround;

        [SerializeField]
        private float _jumpVelocity;

        public override void Init(CharacterCtrl parent)
        {
            base.Init(parent);
            if (_groundCheck == null) _groundCheck = parent.GetComponentInChildren<GroundCheck>();
            if (_rigidbody == null) _rigidbody = parent.GetComponent<Rigidbody2D>();
            _leftTheGround = false;
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpVelocity);
        }

        public override void CaptureInput() {}

        public override void Update()
        {
            if (!_groundCheck.Check())
                _leftTheGround = true;
        }

        public override void FixedUpdate() {}

        public override void ChangeState()
        {
            if (_leftTheGround && _groundCheck.Check())
            {
                _runner.SetState(typeof(WalkState));
            }
        }
        public override void Exit() {}
    }
}
