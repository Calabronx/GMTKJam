using UnityEngine;
using UnityEngine.UIElements;

public class Game : MonoBehaviour
{
    [SerializeField]
    private UIGameManager m_uiManager;
    void Start()
    {
        Debug.Log("Start");
        init();
    }

    void Update()
    {
        //Debug.Log("running");
    }

    private void init()
    {
        Debug.Log("Init()");
        // m_uiCanvas = new UIGameCanvas(m_uiDocument.rootVisualElement);
        

    }
}
