using _Scripts.CoreSystem;
using UnityEngine;

namespace _Scripts.Weapons.Components
{
    public abstract class WeaponComponent : MonoBehaviour
    {
        protected Weapon weapon;

        //TODO: FIX this when finishing weapon data
        //protected AnimationEventHandler EventHandler => weapon.EventHandler;

        protected AnimationEventHandler eventHandler;
        protected Core Core => weapon.Core;

        protected bool isAttackActive;

        public virtual void Init()
        {

        }

        protected virtual void Awake()
        {
            weapon = GetComponentInParent<Weapon>();

            eventHandler = transform.parent.GetComponentInChildren<AnimationEventHandler>();

            if(eventHandler == null)
            {
                Debug.LogError("eventHandler is null");
            }
        }

        protected virtual void HandleEnter() => isAttackActive = true;

        protected virtual void HandleExit() => isAttackActive = false;


        protected virtual void OnDestroy()
        {
            weapon.OnEnter -= HandleEnter;
            weapon.OnExit -= HandleExit;
        }
    }

    public abstract class WeaponComponent<T1, T2> : WeaponComponent where T1 : ComponentData<T2> where T2 : AttackData
    {
        protected T1 data;
        protected T2 currentAttackData;

        public override void Init()
        {
            base.Init();

            data = weapon.Data.GetData<T1>();
        }

        protected virtual void Start()
        {
            weapon.OnEnter += HandleEnter;
            weapon.OnExit += HandleExit;
        }

        protected override void HandleEnter()
        {
            base.HandleEnter();

            currentAttackData = data.AttackData[weapon.CurrentAttackCounter];
        }
    }
}
