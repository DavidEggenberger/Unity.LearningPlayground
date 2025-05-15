using UnityEngine;
using UnityEngine.UIElements;

public class Script : MonoBehaviour
{
    [SerializeField]
    private UIDocument document;

    [SerializeField]
    private UIDocument documentPopUp;


    private VisualElement root;
    private VisualElement button;
    private VisualElement textInput;
    private Label label;

    private VisualElement rootPopUp;
    private Label labelPopUp;
    private Button buttonPopUp;

    private void Awake()
    {
        root = document.rootVisualElement;

        button = root.Query<VisualElement>("SaveButton");
        textInput = root.Query<VisualElement>("TextField");
        label = root.Query<Label>(className: "Label");

        textInput.RegisterCallback<ChangeEvent<string>>(t => ChangeMessage(t));
        button.RegisterCallback<ClickEvent>(e => OnClicked(e));

        rootPopUp = documentPopUp.rootVisualElement;
        rootPopUp.style.display = DisplayStyle.None;
        labelPopUp = rootPopUp.Query<Label>(name: "Label");
        buttonPopUp = rootPopUp.Query<Button>(name: "Button");

        buttonPopUp.RegisterCallback<ClickEvent>(e => rootPopUp.style.display = DisplayStyle.None);
    }

    private void ChangeMessage(ChangeEvent<string> message)
    {
        label.text = message.newValue;
    }

    private void OnClicked(ClickEvent clickEvent)
    {
        rootPopUp.style.display = DisplayStyle.Flex;
        labelPopUp.text = label.text;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
