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
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""b5a76a08-e20a-4b22-b65e-ccfdb3c11438"",
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
                    ""path"": ""<Keyboard>/y"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""a926cfc9-759c-47b3-8138-822856077e0e"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb77bbec-3720-4080-96ce-a6d647c31f7e"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""e4a80fb3-05cc-4611-9e6c-a2320fbc9c8c"",
            ""actions"": [
                {
                    ""name"": ""Menu"",
                    ""type"": ""Value"",
                    ""id"": ""f782f3b8-d319-419c-8840-2c07f0719de2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dialogues"",
                    ""type"": ""Button"",
                    ""id"": ""63d43058-a1cd-4380-b608-a3ba588dc699"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LifePlus"",
                    ""type"": ""Button"",
                    ""id"": ""7173953b-8f09-4422-ae25-9232cd123970"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoneyPlus"",
                    ""type"": ""Button"",
                    ""id"": ""063097c1-36d2-4684-bcb3-ebf9fd45aced"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Donjon"",
                    ""type"": ""Button"",
                    ""id"": ""91f0e626-487e-4702-8dbb-adb699fac04b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Boss"",
                    ""type"": ""Button"",
                    ""id"": ""37f85ec3-4faa-46a7-b20b-40055737cbd9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TPHome"",
                    ""type"": ""Button"",
                    ""id"": ""520688a3-94ce-4835-882e-83965e900678"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4787eeaa-c826-40bf-999c-f3d3785eaeb8"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5519afc6-8e76-4ed7-8764-d616e465fe6c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dialogues"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb8864d9-6eac-4f97-9df1-9d59f8e0743d"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dialogues"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b7254d9-1c8d-44f1-b697-233e05ce2d32"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LifePlus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2b238d3-06cd-4bfb-ba1d-3bd9d6a985ec"",
                    ""path"": ""<Keyboard>/semicolon"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoneyPlus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9603dc3-c392-49e6-b5ec-5ea247008676"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Donjon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92d93a36-c227-4ec1-b9f2-7fc7fdeb2a68"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Boss"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97fcd95d-423d-411b-a95e-e9d365ad7007"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TPHome"",
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
        m_MainController_Pause = m_MainController.FindAction("Pause", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Menu = m_Menu.FindAction("Menu", throwIfNotFound: true);
        m_Menu_Dialogues = m_Menu.FindAction("Dialogues", throwIfNotFound: true);
        m_Menu_LifePlus = m_Menu.FindAction("LifePlus", throwIfNotFound: true);
        m_Menu_MoneyPlus = m_Menu.FindAction("MoneyPlus", throwIfNotFound: true);
        m_Menu_Donjon = m_Menu.FindAction("Donjon", throwIfNotFound: true);
        m_Menu_Boss = m_Menu.FindAction("Boss", throwIfNotFound: true);
        m_Menu_TPHome = m_Menu.FindAction("TPHome", throwIfNotFound: true);
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
    private readonly InputAction m_MainController_Pause;
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
        public InputAction @Pause => m_Wrapper.m_MainController_Pause;
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
                @Pause.started -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnPause;
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
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public MainControllerActions @MainController => new MainControllerActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Menu;
    private readonly InputAction m_Menu_Dialogues;
    private readonly InputAction m_Menu_LifePlus;
    private readonly InputAction m_Menu_MoneyPlus;
    private readonly InputAction m_Menu_Donjon;
    private readonly InputAction m_Menu_Boss;
    private readonly InputAction m_Menu_TPHome;
    public struct MenuActions
    {
        private @Controller m_Wrapper;
        public MenuActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Menu => m_Wrapper.m_Menu_Menu;
        public InputAction @Dialogues => m_Wrapper.m_Menu_Dialogues;
        public InputAction @LifePlus => m_Wrapper.m_Menu_LifePlus;
        public InputAction @MoneyPlus => m_Wrapper.m_Menu_MoneyPlus;
        public InputAction @Donjon => m_Wrapper.m_Menu_Donjon;
        public InputAction @Boss => m_Wrapper.m_Menu_Boss;
        public InputAction @TPHome => m_Wrapper.m_Menu_TPHome;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Menu.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnMenu;
                @Menu.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnMenu;
                @Menu.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnMenu;
                @Dialogues.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnDialogues;
                @Dialogues.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnDialogues;
                @Dialogues.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnDialogues;
                @LifePlus.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnLifePlus;
                @LifePlus.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnLifePlus;
                @LifePlus.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnLifePlus;
                @MoneyPlus.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnMoneyPlus;
                @MoneyPlus.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnMoneyPlus;
                @MoneyPlus.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnMoneyPlus;
                @Donjon.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnDonjon;
                @Donjon.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnDonjon;
                @Donjon.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnDonjon;
                @Boss.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnBoss;
                @Boss.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnBoss;
                @Boss.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnBoss;
                @TPHome.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnTPHome;
                @TPHome.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnTPHome;
                @TPHome.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnTPHome;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
                @Dialogues.started += instance.OnDialogues;
                @Dialogues.performed += instance.OnDialogues;
                @Dialogues.canceled += instance.OnDialogues;
                @LifePlus.started += instance.OnLifePlus;
                @LifePlus.performed += instance.OnLifePlus;
                @LifePlus.canceled += instance.OnLifePlus;
                @MoneyPlus.started += instance.OnMoneyPlus;
                @MoneyPlus.performed += instance.OnMoneyPlus;
                @MoneyPlus.canceled += instance.OnMoneyPlus;
                @Donjon.started += instance.OnDonjon;
                @Donjon.performed += instance.OnDonjon;
                @Donjon.canceled += instance.OnDonjon;
                @Boss.started += instance.OnBoss;
                @Boss.performed += instance.OnBoss;
                @Boss.canceled += instance.OnBoss;
                @TPHome.started += instance.OnTPHome;
                @TPHome.performed += instance.OnTPHome;
                @TPHome.canceled += instance.OnTPHome;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
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
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnMenu(InputAction.CallbackContext context);
        void OnDialogues(InputAction.CallbackContext context);
        void OnLifePlus(InputAction.CallbackContext context);
        void OnMoneyPlus(InputAction.CallbackContext context);
        void OnDonjon(InputAction.CallbackContext context);
        void OnBoss(InputAction.CallbackContext context);
        void OnTPHome(InputAction.CallbackContext context);
    }
}
