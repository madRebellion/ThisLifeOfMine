// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/InputSystem/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""SimpleControls"",
            ""id"": ""d74e7fae-f21d-4ffb-97b4-546f1e80aaf0"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""61733ce0-da79-450e-9967-30ec8cee3427"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""7c6ef4aa-7453-4f5b-a865-b22838c97937"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PauseMenu"",
                    ""type"": ""Value"",
                    ""id"": ""143694a9-4b53-4d5d-8bf0-83d963f95899"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveCamera"",
                    ""type"": ""Value"",
                    ""id"": ""0d7b8845-0e8b-451a-93dc-41dc9d50eb82"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UseItem"",
                    ""type"": ""Button"",
                    ""id"": ""5da8e019-905d-4d6e-bfb9-dbd1e2fe4d27"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""6cd77f97-1966-4827-9e49-f8c78f131dcb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Vector_KM"",
                    ""id"": ""8f4dad84-3d0c-4786-8ca4-2754d178472a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""b1d32064-bca0-4b5a-bfc7-aba615613a50"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""9aae9c59-0d96-4503-ad74-7df7ebdf99a5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""fafc373a-9c98-4936-a719-09f057bb9a72"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""42622992-a078-4e4b-b95d-5f3f6d424ee3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Vector_GP"",
                    ""id"": ""b1e6f853-9e87-4ce7-9bbe-d5b8540e6c4a"",
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
                    ""id"": ""4a7992ac-0a9d-42db-b2df-cc45442700c4"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gampad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f2c749ec-3771-43f5-bc28-d72e006a3ac6"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gampad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""da9a0b81-600f-4dce-971f-5af87eac4304"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gampad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1c0daff2-51bc-4239-b0fb-555adbccdca2"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gampad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""734380a3-8cf2-41e4-b745-c0f5ee997ccf"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2111ecc4-f386-4300-a88f-b6bb6a78b2fa"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gampad"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""084996cf-8d54-460e-90c4-c18c425e9764"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""PauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eecd2a36-bd14-426e-8a08-46f6a5989ed3"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gampad"",
                    ""action"": ""PauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2fc1372-cd0c-4c60-bc3e-40c62e4c36b2"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86a57d82-a57f-49a5-85ff-8bd9ddefc117"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gampad"",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d04b1a4-5f57-4b3d-acb1-ec89be1c1042"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": ""Scale"",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""UseItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ad7eda9-45b2-48ef-9239-24ab859af80a"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=2)"",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""UseItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7395631-18be-46da-95b5-87d446cdb430"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=3)"",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""UseItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b655f16-11d8-45b0-ab3e-3e988fd0bd45"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=4)"",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""UseItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf22b029-5dad-4a77-8f68-f562e3c46d8f"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=5)"",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""UseItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""853f9d6a-70e9-42ac-a05a-6e8fe141c531"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=6)"",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""UseItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef178e1b-ffaf-4314-8e4b-317c99c62570"",
                    ""path"": ""<Keyboard>/7"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=7)"",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""UseItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3863e801-1f20-43ad-8720-a552ee4b660c"",
                    ""path"": ""<Keyboard>/8"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=8)"",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""UseItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61776417-de35-432c-b42d-f208b6dce5b6"",
                    ""path"": ""<Keyboard>/9"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=9)"",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""UseItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""124cff2f-3d94-4c12-9b70-7064e415dabb"",
                    ""path"": ""<Keyboard>/0"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=10)"",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""UseItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8865a89-1774-4d86-9a9a-3e322592f48b"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gampad"",
            ""bindingGroup"": ""Gampad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<DualShockGamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // SimpleControls
        m_SimpleControls = asset.FindActionMap("SimpleControls", throwIfNotFound: true);
        m_SimpleControls_Move = m_SimpleControls.FindAction("Move", throwIfNotFound: true);
        m_SimpleControls_Interact = m_SimpleControls.FindAction("Interact", throwIfNotFound: true);
        m_SimpleControls_PauseMenu = m_SimpleControls.FindAction("PauseMenu", throwIfNotFound: true);
        m_SimpleControls_MoveCamera = m_SimpleControls.FindAction("MoveCamera", throwIfNotFound: true);
        m_SimpleControls_UseItem = m_SimpleControls.FindAction("UseItem", throwIfNotFound: true);
        m_SimpleControls_Sprint = m_SimpleControls.FindAction("Sprint", throwIfNotFound: true);
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

    // SimpleControls
    private readonly InputActionMap m_SimpleControls;
    private ISimpleControlsActions m_SimpleControlsActionsCallbackInterface;
    private readonly InputAction m_SimpleControls_Move;
    private readonly InputAction m_SimpleControls_Interact;
    private readonly InputAction m_SimpleControls_PauseMenu;
    private readonly InputAction m_SimpleControls_MoveCamera;
    private readonly InputAction m_SimpleControls_UseItem;
    private readonly InputAction m_SimpleControls_Sprint;
    public struct SimpleControlsActions
    {
        private @PlayerControls m_Wrapper;
        public SimpleControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_SimpleControls_Move;
        public InputAction @Interact => m_Wrapper.m_SimpleControls_Interact;
        public InputAction @PauseMenu => m_Wrapper.m_SimpleControls_PauseMenu;
        public InputAction @MoveCamera => m_Wrapper.m_SimpleControls_MoveCamera;
        public InputAction @UseItem => m_Wrapper.m_SimpleControls_UseItem;
        public InputAction @Sprint => m_Wrapper.m_SimpleControls_Sprint;
        public InputActionMap Get() { return m_Wrapper.m_SimpleControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SimpleControlsActions set) { return set.Get(); }
        public void SetCallbacks(ISimpleControlsActions instance)
        {
            if (m_Wrapper.m_SimpleControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_SimpleControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_SimpleControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_SimpleControlsActionsCallbackInterface.OnMove;
                @Interact.started -= m_Wrapper.m_SimpleControlsActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_SimpleControlsActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_SimpleControlsActionsCallbackInterface.OnInteract;
                @PauseMenu.started -= m_Wrapper.m_SimpleControlsActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.performed -= m_Wrapper.m_SimpleControlsActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.canceled -= m_Wrapper.m_SimpleControlsActionsCallbackInterface.OnPauseMenu;
                @MoveCamera.started -= m_Wrapper.m_SimpleControlsActionsCallbackInterface.OnMoveCamera;
                @MoveCamera.performed -= m_Wrapper.m_SimpleControlsActionsCallbackInterface.OnMoveCamera;
                @MoveCamera.canceled -= m_Wrapper.m_SimpleControlsActionsCallbackInterface.OnMoveCamera;
                @UseItem.started -= m_Wrapper.m_SimpleControlsActionsCallbackInterface.OnUseItem;
                @UseItem.performed -= m_Wrapper.m_SimpleControlsActionsCallbackInterface.OnUseItem;
                @UseItem.canceled -= m_Wrapper.m_SimpleControlsActionsCallbackInterface.OnUseItem;
                @Sprint.started -= m_Wrapper.m_SimpleControlsActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_SimpleControlsActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_SimpleControlsActionsCallbackInterface.OnSprint;
            }
            m_Wrapper.m_SimpleControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @PauseMenu.started += instance.OnPauseMenu;
                @PauseMenu.performed += instance.OnPauseMenu;
                @PauseMenu.canceled += instance.OnPauseMenu;
                @MoveCamera.started += instance.OnMoveCamera;
                @MoveCamera.performed += instance.OnMoveCamera;
                @MoveCamera.canceled += instance.OnMoveCamera;
                @UseItem.started += instance.OnUseItem;
                @UseItem.performed += instance.OnUseItem;
                @UseItem.canceled += instance.OnUseItem;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
            }
        }
    }
    public SimpleControlsActions @SimpleControls => new SimpleControlsActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    private int m_GampadSchemeIndex = -1;
    public InputControlScheme GampadScheme
    {
        get
        {
            if (m_GampadSchemeIndex == -1) m_GampadSchemeIndex = asset.FindControlSchemeIndex("Gampad");
            return asset.controlSchemes[m_GampadSchemeIndex];
        }
    }
    public interface ISimpleControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnPauseMenu(InputAction.CallbackContext context);
        void OnMoveCamera(InputAction.CallbackContext context);
        void OnUseItem(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
    }
}
