using UnityEngine;
using UnityEngine.UIElements;

public class UIGameManager : MonoBehaviour
{
    public UIDocument doc;
    private int m_clickCount;
    private const string m_buttonPrefix = "button";

    public StatisticsCounter m_stats;

    void Start()
    {
        createGUI();
    }

    public void createGUI()
    {
        var root = doc.rootVisualElement;
        int width = Screen.width;
        int height = Screen.height;

        root.style.backgroundColor = new StyleColor(Color.white);

        root.Clear(); // Always clean before adding new

        // Top-left - Current Stats
        Button statsButton = new Button();
        statsButton.name = "button1";
        statsButton.text = "Current Stats";
        statsButton.style.position = Position.Absolute;
        statsButton.style.left = 20;
        statsButton.style.top = 20;
        statsButton.style.width = 80;
        statsButton.style.height = 16;
        statsButton.style.fontSize = 10;

        root.Add(statsButton);

        // Top-left - Inventory (below Current Stats)
        Button inventoryButton = new Button();
        inventoryButton.name = "button2";
        inventoryButton.text = "Inventory";
        inventoryButton.style.position = Position.Absolute;
        inventoryButton.style.left = 20;
        inventoryButton.style.top = 70;
        inventoryButton.style.width = 80;
        inventoryButton.style.height = 16;
        inventoryButton.style.fontSize = 10;
        root.Add(inventoryButton);

        // Center-left - Home Button
        Button homeButton = new Button();
        homeButton.name = "button3";
        homeButton.text = "Home";
        homeButton.style.position = Position.Absolute;
        homeButton.style.left = 20;
        homeButton.style.top = height / 2 - 20;
        homeButton.style.width = 50;
        homeButton.style.height = 40;
        root.Add(homeButton);

        // Somewhere center-ish - Start Button (keep original pos)
        Button startButton = new Button();
        startButton.name = "button4";
        startButton.text = "Start";
        startButton.style.position = Position.Absolute;
        startButton.style.left = width / 4; // Centrado horizontal
        startButton.style.top = height / 2 - 30;       // Cerca del borde inferior
        startButton.style.width = 50;
        startButton.style.height = 40;
        startButton.style.backgroundColor = new StyleColor(Color.green);

        root.Add(startButton);

        Label menuLabel = new Label("MENU");
        menuLabel.style.position = Position.Absolute;
        menuLabel.style.left = width / 20;
        menuLabel.style.top = -10;
        menuLabel.style.fontSize = 20;
        menuLabel.style.unityFontStyleAndWeight = FontStyle.Bold;
        root.Add(menuLabel);

        // Label: Loops
        Label loopsLabel = new Label("Loops: " + m_stats.loopsTime);
        loopsLabel.name = "loopsLabel";
        loopsLabel.style.position = Position.Absolute;
        loopsLabel.style.left = width / 2;
        loopsLabel.style.top = 100;
        loopsLabel.style.fontSize = 16;
        root.Add(loopsLabel);

        // Label: Years Travelled
        Label yearsLabel = new Label("Years Travelled: " + + m_stats.yearsCount);
        yearsLabel.name = "yearsLabel";
        yearsLabel.style.position = Position.Absolute;
        yearsLabel.style.left = width / 2;
        yearsLabel.style.top = 140;
        yearsLabel.style.fontSize = 16;
        root.Add(yearsLabel);


        setupButtonHandler();
        Debug.Log("GUI Built");
    }   


    private void setupButtonHandler()
    {
        var root = doc.rootVisualElement;
        var buttons = root.Query<Button>();
        buttons.ForEach(registerHandler);
    }

    private void registerHandler(Button button)
    {
        button.RegisterCallback<ClickEvent>(printClickMessage);
    }

    private void printClickMessage(ClickEvent evt)
    {
        var root = doc.rootVisualElement;
        Button button = evt.currentTarget as Button;
        Debug.Log("m_buttonPrefix.Length " + m_buttonPrefix.Length);
        string buttonNumber = button.name.Substring(m_buttonPrefix.Length);
        string toggleName = "toggle" + buttonNumber;


        if (button.name == "button4") // Start button
        {
             if (button.text == "Start")
                {
                    button.text = "Stop";
                    button.style.backgroundColor = new StyleColor(Color.red);
                    m_stats.loopsTime += 1;
                    m_stats.yearsCount += 15;

                    Debug.Log("loopsTime: " + m_stats.loopsTime);
                    Debug.Log("yearsCount: " + m_stats.yearsCount);
                }
                else
                {
                    button.text = "Start";
                    button.style.backgroundColor = new StyleColor(Color.green);
                }
        }

        // Toggle toggle = root.Q<Toggle>(toggleName);
    }
}

