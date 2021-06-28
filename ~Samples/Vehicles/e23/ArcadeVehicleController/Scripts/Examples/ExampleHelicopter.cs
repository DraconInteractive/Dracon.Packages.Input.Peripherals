using System.Collections;
using UnityEngine;

public class ExampleHelicopter : MonoBehaviour
{
    [SerializeField] private Transform modelTransform = null;
    [SerializeField] private Vector3 startPos = Vector3.zero;
    [SerializeField] private float maxHeightOffGround = 1f;
    [SerializeField] private float timeToMove = 2f;

    private Vector3 targetPosition;
    private Vector3 targetDirection;

    public JoystickInputManager inputManager;

    private void Awake()
    {
        GetDefaultPos();
        SetInitialPos();
    }

    private void Start() 
    {
        StartCoroutine(StartAnimation());
    }

    private void GetDefaultPos()
    {
        targetPosition = modelTransform.localPosition;
    }

    private void SetInitialPos()
    {
        modelTransform.localPosition = startPos;
    }

    private IEnumerator StartAnimation()
    {
        var currentPos = modelTransform.localPosition;
        var t = 0f;
        while(t < 1)
        {
            t += Time.deltaTime / timeToMove;
            modelTransform.localPosition = Vector3.Lerp(currentPos, targetPosition, t);
            yield return null;
        }
    }

    private void Update()
    {
        targetDirection = Vector3.zero;
        if (inputManager.hatSwitch.y > 0 && modelTransform.localPosition.y < maxHeightOffGround) { ChangeHelicopterHeight(1); }
        if (inputManager.hatSwitch.y < 0 && modelTransform.localPosition.y > startPos.y) { ChangeHelicopterHeight(-1); }
    }

    private void ChangeHelicopterHeight(int direction)
    {
        targetDirection.y = direction;
        modelTransform.Translate(targetDirection * timeToMove * Time.deltaTime);
    }
}