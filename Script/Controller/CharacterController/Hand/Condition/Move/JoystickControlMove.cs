using UnityEngine;
using System.Collections;
using VRTK;

//可以移動人物
public class JoystickControlMove : JoystickControllerItem
{
    [SerializeField]
    private bool leftController = true;
    public bool LeftController
    {
        get { return leftController; }
        set
        {
            leftController = value;
            SetControllerListeners(controllerManager.left);
        }
    }

    [SerializeField]
    private bool rightController = true;
    public bool RightController
    {
        get { return rightController; }
        set
        {
            rightController = value;
            SetControllerListeners(controllerManager.right);
        }
    }

    public float maxWalkSpeed = 3f;
    public float deceleration = 0.1f;

    private SteamVR_ControllerManager controllerManager;
    private Vector2 touchAxis;
    private float movementSpeed = 0f;
    private float strafeSpeed = 0f;

    private bool leftSubscribed;
    private bool rightSubscribed;

    private ControllerInteractionEventHandler touchpadAxisChanged;
    private ControllerInteractionEventHandler touchpadUntouched;

    private VRTK_PlayerPresence playerPresence;

    private void Awake()
    {
        if (GetComponent<VRTK_PlayerPresence>())
        {
            playerPresence = GetComponent<VRTK_PlayerPresence>();
        }
        else
        {
            Debug.LogError("The VRTK_TouchpadWalking script requires the VRTK_PlayerPresence script to be attached to the [CameraRig]");
            return;
        }

        //註冊事件
        touchpadAxisChanged = new ControllerInteractionEventHandler(DoTouchpadAxisChanged);
        touchpadUntouched = new ControllerInteractionEventHandler(DoTouchpadTouchEnd);

        controllerManager = GetComponent<SteamVR_ControllerManager>();
    }

    private void Start()
    {
        Utilities.SetPlayerObject(gameObject, VRTK_PlayerObject.ObjectTypes.CameraRig);

        var controllerManager = FindObjectOfType<SteamVR_ControllerManager>();

        SetControllerListeners(controllerManager.left);
        SetControllerListeners(controllerManager.right);
    }

    //抓取觸控板位置
    private void DoTouchpadAxisChanged(object sender, ControllerInteractionEventArgs e)
    {
        touchAxis = e.touchpadAxis;
    }

    //如果觸控板被放開
    private void DoTouchpadTouchEnd(object sender, ControllerInteractionEventArgs e)
    {
        touchAxis = Vector2.zero;
    }

    private void CalculateSpeed(ref float speed, float inputValue)
    {
        if (inputValue != 0f)
        {
            speed = (maxWalkSpeed * inputValue);
        }
        else
        {
            Decelerate(ref speed);
        }
    }

    private void Decelerate(ref float speed)
    {
        if (speed > 0)
        {
            speed -= Mathf.Lerp(deceleration, maxWalkSpeed, 0f);
        }
        else if (speed < 0)
        {
            speed += Mathf.Lerp(deceleration, -maxWalkSpeed, 0f);
        }
        else
        {
            speed = 0;
        }

        float deadzone = 0.1f;
        if (speed < deadzone && speed > -deadzone)
        {
            speed = 0;
        }
    }

    private void Move()
    {
        var movement = playerPresence.GetHeadset().forward * movementSpeed * Time.deltaTime;
        var strafe = playerPresence.GetHeadset().right * strafeSpeed * Time.deltaTime;
        float fixY = _target.transform.position.y;
        _target.transform.position += (movement + strafe);
        _target.transform.position = new Vector3(_target.transform.position.x, fixY, _target.transform.position.z);
    }

    private void FixedUpdate()
    {
        CalculateSpeed(ref movementSpeed, touchAxis.y);
        CalculateSpeed(ref strafeSpeed, touchAxis.x);
        Move();
    }

    private void SetControllerListeners(GameObject controller)
    {
        if (controller && controller == controllerManager.left)
        {
            ToggleControllerListeners(controller, leftController, ref leftSubscribed);
        }
        else if (controller && controller == controllerManager.right)
        {
            ToggleControllerListeners(controller, rightController, ref rightSubscribed);
        }
    }

    private void ToggleControllerListeners(GameObject controller, bool toggle, ref bool subscribed)
    {
        var controllerEvent = controller.GetComponent<VRTK_ControllerEvents>();
        if (controllerEvent && toggle && !subscribed)
        {
            controllerEvent.TouchpadAxisChanged += touchpadAxisChanged;
            controllerEvent.TouchpadTouchEnd += touchpadUntouched;
            subscribed = true;
        }
        else if (controllerEvent && !toggle && subscribed)
        {
            controllerEvent.TouchpadAxisChanged -= touchpadAxisChanged;
            controllerEvent.TouchpadTouchEnd -= touchpadUntouched;
            touchAxis = Vector2.zero;
            subscribed = false;
        }
    }

}
