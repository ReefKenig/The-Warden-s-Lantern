using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int totalShrines = 4;
    private int litShrines = 0;

    public TextMeshProUGUI objectiveText;

    public GateController gateController;

    private void Awake()
    {
        Instance = this;
        UpdateUI();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void LightShrine()
    {
        litShrines++;
        UpdateUI();

        if (litShrines >= totalShrines)
        {
            if (gateController != null)
            {
                gateController.OpenGate();
            }
        }
    }

    private void UpdateUI()
    {
        if (objectiveText != null)
        {
            objectiveText.text = "Shrines Lit: " + litShrines + " / " + totalShrines;
        }
    }
    
    public void WinGame()
    {
        SceneManager.LoadScene("VictoryScene");
    }
}
