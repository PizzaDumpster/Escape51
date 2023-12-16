using UnityEngine;

public class ButtonSensor : MonoBehaviour
{
    [SerializeField] SpriteRenderer aButtonRenderer;
    [SerializeField] SpriteRenderer bButtonRenderer;
    [SerializeField] SpriteRenderer xButtonRenderer;
    [SerializeField] SpriteRenderer yButtonRenderer;
    [SerializeField] SpriteRenderer rbButtonRenderer;
    [SerializeField] SpriteRenderer rtButtonRenderer;
    [SerializeField] Sprite aButtonController;
    [SerializeField] Sprite bButtonController;
    [SerializeField] Sprite xButtonController;
    [SerializeField] Sprite yButtonController;
    [SerializeField] Sprite rbButtonController;
    [SerializeField] Sprite rtButtonController;
    [SerializeField] Sprite aButtonKeyboard;
    [SerializeField] Sprite bButtonKeyboard;
    [SerializeField] Sprite xButtonKeyboard;
    [SerializeField] Sprite yButtonKeyboard;
    [SerializeField] Sprite rbButtonKeyboard;
    [SerializeField] Sprite rtButtonKeyboard;
    [SerializeField] public bool isKeyboard;
    [SerializeField] public bool isController;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            isKeyboard = true;
            isController = false;
        }

        if (
        System.Convert.ToBoolean(Input.GetAxis("HorizontalController")) ||
        Input.GetButton("Fire1Controller") ||
        Input.GetButton("Fire2Controller") ||
        Input.GetButton("Fire3Controller") ||
        Input.GetButton("JumpController") ||
        Input.GetButton("Submit") ||
        Input.GetButton("Start") ||
        Input.GetButton("RightTrigger") ||
        Input.GetButton("RightBumper") ||
        Input.GetButton("LeftBumper")
        )
        {
            isKeyboard = false;
            isController = true;
        }

        if (isController)
        {
            if (aButtonRenderer != null)
                aButtonRenderer.sprite = aButtonController;
            if (bButtonRenderer != null)
                bButtonRenderer.sprite = bButtonController;
            if (xButtonRenderer != null)
                xButtonRenderer.sprite = xButtonController;
            if (yButtonRenderer != null)
                yButtonRenderer.sprite = yButtonController;
            if (rbButtonRenderer != null)
                rbButtonRenderer.sprite = rbButtonController;
            if (rtButtonRenderer != null)
                rtButtonRenderer.sprite = rtButtonController;
        }
        else if (isKeyboard)
        {
            if (aButtonRenderer != null)
                aButtonRenderer.sprite = aButtonKeyboard;
            if (bButtonRenderer != null)
                bButtonRenderer.sprite = bButtonKeyboard;
            if (xButtonRenderer != null)
                xButtonRenderer.sprite = xButtonKeyboard;
            if (yButtonRenderer != null)
                yButtonRenderer.sprite = yButtonKeyboard;
            if (rbButtonRenderer != null)
                rbButtonRenderer.sprite = rbButtonKeyboard;
            if (rtButtonRenderer != null)
                rtButtonRenderer.sprite = rtButtonKeyboard;
        }
    }
}
