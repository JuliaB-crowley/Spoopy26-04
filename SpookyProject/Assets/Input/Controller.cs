// GENERATED AUTOMATICALLY FROM 'Assets/Input/Controller.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controller : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controller()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controller"",
    ""maps"": [
        {
            ""name"": ""MainController"",
            ""id"": ""70b333c8-43d9-41ea-b412-9ff543bb233f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""1531a241-fc12-4524-9db2-c3db67866fa7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""51e078bf-fcd0-4ee8-b35b-356aec30e354"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ef6d2506-6663-434f-abaf-1c937b571a7b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""HeavyAttack"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a7b03126-8b37-4d3e-9013-c86f51348e34"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""56a2eb90-b20e-43ed-8a0b-4cf86944dd72"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Flash"",
                    ""type"": ""Button"",
                    ""id"": ""ccdc2700-ee87-4da5-aaa2-594b67e7a597"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hint"",
                    ""type"": ""Button"",
                    ""id"": ""8f0d1136-c018-4616-a8cd-e46df816f476"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Push"",
                    ""type"": ""Button"",
                    ""id"": ""b8da1420-fee3-41f6-977e-cda69da81ff6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""5003cda7-c65b-4947-8adf-000f06b8c3a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""1137028b-e995-4b9f-bdf2-8abd26d6875d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8e53c238-c261-47c3-b81c-ab6eea5d292b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5c01cb37-6786-415b-99a8-7dea2e1b5ad1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fef0d41c-5d86-4ff5-ac62-7fd35f40ff8a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""dc3ed25a-f15c-4ab7-aa91-e2e5ac124e20"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f9085e6c-5d41-4ffe-a67b-c69cbc025a3a"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14d9461a-f18b-4e5c-a905-d5ca4097dacf"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""011fa760-4ece-4622-ba1d-32952f251491"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e8e66b2-7073-4692-8028-f7b3276f729f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d032730-7180-4f84-9d0d-1525fa28a82c"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b763f81-f31f-4217-8703-be252593e513"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HeavyAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ada555d-206b-40b4-92ff-e2edb2665a3d"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HeavyAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""722caa08-4abc-4efd-bf98-b0eb881bab5e"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""42f06e26-7ca7-48f7-878d-984e0f9ecc2a"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c44487c7-71f1-49c6-ba9b-6bb5a57f51be"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Flash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d07d226-73dd-4174-b1a7-a1a8101376db"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Flash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f3b47673-d6bc-459e-b7e3-54a262b003b6"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8fff5d1d-5a30-4e3b-ba12-0d6acda1dd14"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db71c7df-5d52-4b82-988f-b851425157f4"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Push"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e608458-1697-4683-a0f6-78e7b47ed1f5"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Push"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd39586e-fef8-4405-931a-71110795743f"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eba4fd98-e14b-4cf1-945c-98aa8b02bd08"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MainController
        m_MainController = asset.FindActionMap("MainController", throwIfNotFound: true);
        m_MainController_Move = m_MainController.FindAction("Move", throwIfNotFound: true);
        m_MainController_Roll = m_MainController.FindAction("Roll", throwIfNotFound: true);
        m_MainController_Attack = m_MainController.FindAction("Attack", throwIfNotFound: true);
        m_MainController_HeavyAttack = m_MainController.FindAction("HeavyAttack", throwIfNotFound: true);
        m_MainController_Crouch = m_MainController.FindAction("Crouch", throwIfNotFound: true);
        m_MainController_Flash = m_MainController.FindAction("Flash", throwIfNotFound: true);
        m_MainController_Hint = m_MainController.FindAction("Hint", throwIfNotFound: true);
        m_MainController_Push = m_MainController.FindAction("Push", throwIfNotFound: true);
        m_MainController_Interact = m_MainController.FindAction("Interact", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // MainController
    private readonly InputActionMap m_MainController;
    private IMainControllerActions m_MainControllerActionsCallbackInterface;
    private readonly InputAction m_MainController_Move;
    private readonly InputAction m_MainController_Roll;
    private readonly InputAction m_MainController_Attack;
    private readonly InputAction m_MainController_HeavyAttack;
    private readonly InputAction m_MainController_Crouch;
    private readonly InputAction m_MainController_Flash;
    private readonly InputAction m_MainController_Hint;
    private readonly InputAction m_MainController_Push;
    private readonly InputAction m_MainController_Interact;
    public struct MainControllerActions
    {
        private @Controller m_Wrapper;
        public MainControllerActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_MainController_Move;
        public InputAction @Roll => m_Wrapper.m_MainController_Roll;
        public InputAction @Attack => m_Wrapper.m_MainController_Attack;
        public InputAction @HeavyAttack => m_Wrapper.m_MainController_HeavyAttack;
        public InputAction @Crouch => m_Wrapper.m_MainController_Crouch;
        public InputAction @Flash => m_Wrapper.m_MainController_Flash;
        public InputAction @Hint => m_Wrapper.m_MainController_Hint;
        public InputAction @Push => m_Wrapper.m_MainController_Push;
        public InputAction @Interact => m_Wrapper.m_MainController_Interact;
        public InputActionMap Get() { return m_Wrapper.m_MainController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainControllerActions set) { return set.Get(); }
        public void SetCallbacks(IMainControllerActions instance)
        {
            if (m_Wrapper.m_MainControllerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnMove;
                @Roll.started -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnRoll;
                @Attack.started -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnAttack;
                @HeavyAttack.started -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnHeavyAttack;
                @HeavyAttack.performed -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnHeavyAttack;
                @HeavyAttack.canceled -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnHeavyAttack;
                @Crouch.started -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnCrouch;
                @Flash.started -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnFlash;
                @Flash.performed -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnFlash;
                @Flash.canceled -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnFlash;
                @Hint.started -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnHint;
                @Hint.performed -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnHint;
                @Hint.canceled -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnHint;
                @Push.started -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnPush;
                @Push.performed -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnPush;
                @Push.canceled -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnPush;
                @Interact.started -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_MainControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @HeavyAttack.started += instance.OnHeavyAttack;
                @HeavyAttack.performed += instance.OnHeavyAttack;
                @HeavyAttack.canceled += instance.OnHeavyAttack;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Flash.started += instance.OnFlash;
                @Flash.performed += instance.OnFlash;
                @Flash.canceled += instance.OnFlash;
                @Hint.started += instance.OnHint;
                @Hint.performed += instance.OnHint;
                @Hint.canceled += instance.OnHint;
                @Push.started += instance.OnPush;
                @Push.performed += instance.OnPush;
                @Push.canceled += instance.OnPush;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public MainControllerActions @MainController => new MainControllerActions(this);
    public interface IMainControllerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnHeavyAttack(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnFlash(InputAction.CallbackContext context);
        void OnHint(InputAction.CallbackContext context);
        void OnPush(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
}
