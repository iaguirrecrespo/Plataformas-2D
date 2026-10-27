using UnityEngine;
using UnityEngine.InputSystem;

public class TestInputManager : MonoBehaviour
{
    [SerializeField] private InputActionProperty pulsacionesAction;
    [SerializeField] private InputActionProperty moveAction;

    private void OnEnable()
    {
        pulsacionesAction.action.Enable();
        moveAction.action.Enable();
        pulsacionesAction.action.performed += pulsacionTecla;
    }

    private void OnDisable()
    {
        pulsacionesAction.action.Disable();
        moveAction.action.Disable() ;
        pulsacionesAction.action.performed -= pulsacionTecla;
    }

    

    private void pulsacionTecla(InputAction.CallbackContext context)
    {
        Debug.Log("PULSACION");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(moveAction.action.ReadValue<Vector2>());
    }


}
