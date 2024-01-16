using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        public Vector2 Move { get; private set; }
        public Vector2 Look { get; private set; }
        public Vector2 ScrollWheel { get; private set; }
        public Vector2 MousePos { get; private set; }

        public bool Attack { get; private set; }
        public bool Pause { get; private set; }
        public bool Jump { get; private set; }
        public bool Run { get; private set; }
        public bool Crouch { get; private set; }
        public bool Interact { get; private set; }
        public bool Block { get; private set; }
        public bool CombatMode { get; private set; }
        public bool Logs { get; private set; }

        private int CurrentScene;
        private PlayerInput UserInput;
        private InputActionMap _currentMap;

        private InputAction _MoveAct;
        private InputAction _LookAct;
        private InputAction _AttackAct;
        private InputAction _PauseAct;
        private InputAction _JumpAct;
        private InputAction _RunAct;
        private InputAction _CrouchAct;
        private InputAction _ScrollWheelAct;
        private InputAction _IntetactAct;
        private InputAction _BlockAct;
        private InputAction _CombatAct;
        private InputAction _LogAct;
        private InputAction _MousePosAct;

        private void Start()
        {
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            CurrentScene = SceneManager.GetActiveScene().buildIndex;
            if (CurrentScene == 0)
            {
                // Debug.Log("Input Manager Disabled");
                _currentMap.Disable();
            }
            else
            {
                // Debug.Log("Input Manager Enabled");
                _currentMap.Enable();
            }
        }

        private void Awake()
        {
            UserInput = GetComponent<PlayerInput>();
            _currentMap = UserInput.currentActionMap;

            _MoveAct = _currentMap.FindAction("Move");
            _LookAct = _currentMap.FindAction("Look");
            _AttackAct = _currentMap.FindAction("Attack");
            _PauseAct = _currentMap.FindAction("Pause");
            _JumpAct = _currentMap.FindAction("Jump");
            _RunAct = _currentMap.FindAction("Run");
            _CrouchAct = _currentMap.FindAction("Crouch");
            _ScrollWheelAct = _currentMap.FindAction("ScrollWheel");
            _IntetactAct = _currentMap.FindAction("Interact");
            _BlockAct = _currentMap.FindAction("Block");
            _CombatAct = _currentMap.FindAction("CombatMode");
            _LogAct = _currentMap.FindAction("Logs");
            _MousePosAct = _currentMap.FindAction("MousePos");

            _MoveAct.performed += OnMove;
            _LookAct.performed += OnLook;
            _AttackAct.performed += OnAttack;
            _PauseAct.performed += OnPause;
            _JumpAct.performed += OnJump;
            _RunAct.performed += OnRun;
            _CrouchAct.performed += OnCrouch;
            _ScrollWheelAct.performed += OnScrollWheel;
            _IntetactAct.performed += OnInteract;
            _BlockAct.performed += OnBlock;
            _CombatAct.performed += OnCombat;
            _LogAct.performed += OnLogs;
            _MousePosAct.performed += OnMousePos;

            _MoveAct.canceled += OnMove;
            _LookAct.canceled += OnLook;
            _AttackAct.canceled += OnAttack;
            _PauseAct.canceled += OnPause;
            _JumpAct.canceled += OnJump;
            _RunAct.canceled += OnRun;
            _CrouchAct.canceled += OnCrouch;
            _ScrollWheelAct.canceled += OnScrollWheel;
            _IntetactAct.canceled += OnInteract;
            _BlockAct.canceled += OnBlock;
            _CombatAct.canceled += OnCombat;
            _LogAct.canceled += OnLogs;
            _MousePosAct.canceled += OnMousePos;

        }

        private void OnMove(InputAction.CallbackContext context)
        {
            Move = context.ReadValue<Vector2>();
        }
        private void OnLook(InputAction.CallbackContext context)
        {
            Look = context.ReadValue<Vector2>();
        }
        private void OnAttack(InputAction.CallbackContext context)
        {
            Attack = context.ReadValueAsButton();
        }

        private void OnPause(InputAction.CallbackContext context)
        {
            Pause = context.ReadValueAsButton();
        }
        private void OnJump(InputAction.CallbackContext context)
        {
            Jump = context.ReadValueAsButton();
        }
        private void OnRun(InputAction.CallbackContext context)
        {
            Run = context.ReadValueAsButton();
        }
        private void OnCrouch(InputAction.CallbackContext context)
        {
            Crouch = context.ReadValueAsButton();
        }
        private void OnScrollWheel(InputAction.CallbackContext context)
        {
            ScrollWheel = context.ReadValue<Vector2>();
        }
        private void OnInteract(InputAction.CallbackContext context)
        {
            Interact = context.ReadValueAsButton();
        }
        private void OnBlock(InputAction.CallbackContext context)
        {
            Block = context.ReadValueAsButton();
        }
        private void OnLogs(InputAction.CallbackContext context)
        {
            Logs = context.ReadValueAsButton();
        }
        private void OnCombat(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                CombatMode = context.ReadValueAsButton();
            }
            if (context.canceled)
            {
                CombatMode = context.ReadValueAsButton();
            }
        }
        private void OnMousePos(InputAction.CallbackContext context)
        {
            MousePos = context.ReadValue<Vector2>();
        }

        private void OnEnable()
        {
            _currentMap.Enable();
        }

        private void OnDisable()
        {
            _currentMap.Disable();
        }


    }
}

