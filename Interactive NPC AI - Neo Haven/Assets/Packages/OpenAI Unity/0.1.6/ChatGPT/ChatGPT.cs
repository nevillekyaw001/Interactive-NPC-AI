using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

namespace OpenAI
{
    public class ChatGPT : MonoBehaviour
    {
        [SerializeField] private float typingSpeed;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private Button button;
        [SerializeField] private TMP_Text textArea;

        private OpenAIApi openai = new OpenAIApi("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");

        private string userInput;
        //private string Instruction = "Act as a random stranger in a chat room and reply to the questions.\nQ: ";

        [TextArea(10, 20)]
        public string Instruction;

        private string Instruction1 { get => Instruction; set => Instruction = value; }

        private void Start()
        {
            button.onClick.AddListener(SendReply);
        }

        public async virtual void SendReply()
        {
            userInput = inputField.text;
            Instruction1 += $"{userInput}\nA: ";
            
            textArea.text = ". . .";
            inputField.text = "";

            button.enabled = false;
            inputField.enabled = false;
            
            // Complete the instruction
            var completionResponse = await openai.CreateCompletion(new CreateCompletionRequest()
            {
                Prompt = Instruction1,
                Model = "text-davinci-003",
                MaxTokens = 100
            });

            if (completionResponse.Choices != null && completionResponse.Choices.Count > 0)
            {
                textArea.text = completionResponse.Choices[0].Text;
                Instruction1 += $"{completionResponse.Choices[0].Text}\nQ:";
                
            }
            else
            {
                Debug.LogWarning("No text was generated from this prompt.");
            }

            SpecialTrait();
            button.enabled = true;
            inputField.enabled = true;
        }

        public virtual void SpecialTrait()
        {

        }

        public virtual void Exit()
        {
            StartCoroutine(ExitMenu());
        }

        IEnumerator ExitMenu()
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(0);
        }

    }
}
