using _Scripts.Weapons;
using UnityEngine;
using _Scripts;
using _Scripts.CoreSystem;
using _Scripts.UI;

public class Player : MonoBehaviour 
{

    #region State Variables
    [SerializeField]
    private PlayerData playerData;

    public PlayerStateMachine StateMachine { get; private set;}

    // MOVE STATES
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    //public PlayerWallSlideState WallSlideState { get; private set; }
    //public PlayerWallGrabState WallGrabState { get; private set; }
    //public PlayerWallClimbState WallClimbState { get; private set; }
    //public PlayerWallJumpState WallJumpState { get; private set; }
    public PlayerLedgeClimbState LedgeClimbState { get; private set; }
    //public PlayerDashState DashState { get; private set; }

    // ATTACK STATES
    public PlayerAttackState PrimaryAttackState { get; private set; }
    public PlayerAttackState SecondaryAttackState { get; private set; }
    
    #endregion

    #region Components
    public Core Core { get; private set; }
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public Transform DashDirectionIndicator { get; private set; }
    public StatBar healthBar;

    [SerializeField]
    public GameObject playerHud;

    #endregion

    #region Other Variables
    private Vector2 workspace;

    private Weapon weapon;

    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        Core = GetComponentInChildren<Core>();

        weapon = transform.Find("Weapon").GetComponent<Weapon>();

        weapon.Init(Core);
        
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
        InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
        LandState = new PlayerLandState(this, StateMachine, playerData, "land");
        //WallSlideState = new PlayerWallSlideState(this, StateMachine, playerData, "wallSlide");
        //WallGrabState = new PlayerWallGrabState(this, StateMachine, playerData, "wallGrab");
        //WallClimbState = new PlayerWallClimbState(this, StateMachine, playerData, "wallClimb");
        //WallJumpState = new PlayerWallJumpState(this, StateMachine, playerData, "inAir");
        LedgeClimbState = new PlayerLedgeClimbState(this, StateMachine, playerData, "ledgeClimbState");
        //DashState = new PlayerDashState(this, StateMachine, playerData, "inAir");
        PrimaryAttackState = new PlayerAttackState(this, StateMachine, playerData, "attack", weapon);
        

    }

    private void Start() {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();
        //DashDirectionIndicator = transform.Find("DashDirectionIndicator");

        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        Core.LogicUpdate();
        
        healthBar.SetMaxValue(Core.GetCoreComponent<HealthSystem>().CurrentHealth);

        StateMachine.CurrentState.LogicUpdate();
        
    }

    private void FixedUpdate() 
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion
    
    #region Other Functions

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimationFinishTrigger () => StateMachine.CurrentState.AnimationFinishTrigger();
    
    
    #endregion
}
