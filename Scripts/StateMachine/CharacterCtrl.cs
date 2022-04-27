using UnityEngine;

namespace StateMachine
{
    public class CharacterCtrl : StateRunner<CharacterCtrl>
    {
        public CharacterAnimation CharacterAnimation;

        protected override void Awake()
        {
            CharacterAnimation = new CharacterAnimation(GetComponent<Animator>(), transform);
            base.Awake();
        }
    }
}
