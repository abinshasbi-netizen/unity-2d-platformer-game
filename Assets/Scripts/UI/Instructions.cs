using UnityEngine;

public class Instructions : MonoBehaviour
{
    [SerializeField] private GameObject instructionPanel;

    public void OpenInstructions() {

        instructionPanel.SetActive(true);
    }

    public void CloseInstructions() { 

        instructionPanel.SetActive(false);
    
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
