using UnityEngine;

namespace Arkanoid
{
    //public class Camera2Controller : CameraController
    //{
    //    public static Camera2Controller Self;

    //    public Vector3 CurrentPosition
    //    {
    //        get => transform.position;
    //        private set { }
    //    }

    //    private void Start() => Self = this;


    //    protected void OnEnable()
    //    {
    //        controls.Camera2ActionMap.Enable();
    //        controls.Camera2ActionMap.Throw.performed += OnThrow;
    //    }

    //    protected void Update()
    //    {
    //        var value = controls.Camera2ActionMap.Moving.ReadValue<Vector2>();
    //        OnMovement(value);
    //    }

    //    //public void OnMovement(Vector3 value)
    //    //{

    //    //    transform.Translate(_movementSpeed * Time.deltaTime * new Vector3(value.x, 0, value.y), Space.Self);
    //    //}

    //    protected void OnDisable()
    //    {
    //        controls.Camera2ActionMap.Disable();
    //        controls.Camera2ActionMap.Throw.performed -= OnThrow;
    //    }
    //}
}
