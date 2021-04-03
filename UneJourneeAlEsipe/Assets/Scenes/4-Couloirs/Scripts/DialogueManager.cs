using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject boy;
    public GameObject girl;
    public GameObject dialogueGo;
    public GameHandler gameHandler;
    public GameObject nextButton;

    private Queue<string> sentences;

    private TextMeshProUGUI dialogue;

    // Start is called before the first frame update
    public void startGame()
    {
        dialogue = dialogueGo.GetComponent<TextMeshProUGUI>();

        sentences = new Queue<string>();

        sentences.Enqueue("Brandon : Salut, tu es là pour quelle filière ?");
        sentences.Enqueue("Mélissa : Bonjour. Je ne sais pas encore, je viens pour me faire une idée.");
        sentences.Enqueue("Brandon : Tu es en quelle année? ");
        sentences.Enqueue("Mélissa : Je passe mon bac de SI.");
        sentences.Enqueue("Brandon : Ah? Tu t’y prends tôt !");
        sentences.Enqueue("Mélissa : Je sais... c’est mes parents qui me forcent…");
        sentences.Enqueue("Brandon : Je vais te présenter un peu toutes les filières alors! Il y a Electronique et Informatique - Systèmes Communicants...");
        sentences.Enqueue("Mélissa : Je ne sais pas si ça m’intéresse...");
        sentences.Enqueue("Brandon : Génie Civil - Conception et Contrôle dans la Construction...");
        sentences.Enqueue("Mélissa : Je ne sais pas si ça m’intéresse…");
        sentences.Enqueue("Brandon : Génie Mécanique...");
        sentences.Enqueue("Mélissa : Je ne sais pas si ça m’intéresse...");
        sentences.Enqueue("Brandon : Image, multimédia, audiovisuel et communication...");
        sentences.Enqueue("Mélissa : Je ne sais pas si ça m’intéresse...");
        sentences.Enqueue("Brandon : Informatique - design, architecture et développement - option géomatique, logiciel ou réseau...");
        sentences.Enqueue("Mélissa : Je ne sais pas si ça m’intéresse...");
        sentences.Enqueue("Brandon : Maintenance et Fiabilité des Processus Industriels...");
        sentences.Enqueue("Mélissa : Bon bah je vais réfléchir… Vous êtes dans quelle filière vous ?");
        sentences.Enqueue("Brandon : En génie mécanique, j’aime bien résoudre des problèmes.");
        sentences.Enqueue("Mélissa : Oh merci ça a l’air chouette. Je vais me renseigner merci beaucoup !");


        //dialogue.text = sentences.Peek();
        //sentences.Dequeue();
        boy.SetActive(false);
        girl.SetActive(true);
        NextSentence();
    }

    public void NextSentence()
    {
        if(sentences.Count <= 0)
        {
            gameHandler.LoadLevel("Level5");
        }
        else
        {
            nextButton.SetActive(false);
            StartCoroutine(TypeSentence(sentences.Peek()));
            
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        girl.SetActive(!girl.activeSelf);
        boy.SetActive(!girl.activeSelf);

        dialogue.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogue.text += letter;
            yield return new WaitForSeconds(.03f);
        }
        sentences.Dequeue();

        nextButton.SetActive(true);
    }


}
