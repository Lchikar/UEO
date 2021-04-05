using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


[System.Serializable]
public class Sentences
{
	public string narratorName;
	[TextArea(10, 20)]
	public string text;
	public UnityEvent dialogStartedCallback;
}

[System.Serializable]
public class Dialog
{
	public Sentences[] sentences;
	[Tooltip("in letters by seconds")] public float typingSpeed = 20.0f;
}


public class DialogManager : MonoBehaviour
{

	[SerializeField] Text nameText;
	[SerializeField] Text dialogText;
	[SerializeField] Animator dialogHUD;
	[SerializeField] AudioSource dialogSound;
	[SerializeField] UnityEngine.UI.Text UITextNarrator;
	[SerializeField] UnityEngine.UI.Text UITextDialog;
	[SerializeField] Dialog dialogToPlay;
	[SerializeField] UnityEvent dialogEndedCallback;

	public static DialogManager currentOpendialog = null;

	private bool dialogueStarted = false;
	private bool displayNextSentence = false;

	public void StartDialog()
	{
		if (!dialogueStarted)
		{
			if (currentOpendialog != null)
			{
				currentOpendialog.StopAllCoroutines();
				currentOpendialog.dialogHUD.SetBool("open", false);
				currentOpendialog.dialogueStarted = false;
			}
			currentOpendialog = this;
			dialogueStarted = true;
			StartCoroutine(DisplayDialog(dialogToPlay));
		}
	}

	public void StartDialogOnPlay()
    {
		StartDialog();
	}

	IEnumerator TypeSentence(UnityEngine.UI.Text textObj, string sentence, float secByletter)
	{
		textObj.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogSound.Play();
			textObj.text += letter;
			yield return new WaitForSeconds(secByletter);
		}
		dialogSound.Stop();
	}

	IEnumerator DisplayDialog(Dialog dialog)
	{
		UITextNarrator.text = dialog.sentences[0].narratorName;
		UITextDialog.text = "";
		dialogHUD.SetBool("open", true);
		yield return new WaitForSeconds(0.5f);

		foreach (var sentence in dialog.sentences)
		{
			sentence.dialogStartedCallback.Invoke();
			UITextNarrator.text = sentence.narratorName;
			yield return StartCoroutine(TypeSentence(UITextDialog, sentence.text, 1 / dialog.typingSpeed));
			displayNextSentence = false;

			while (!displayNextSentence) yield return null;
		}
		dialogEndedCallback.Invoke();
		dialogHUD.SetBool("open", false);

		dialogueStarted = false;

	}

	public void NextSentence()
    {
		displayNextSentence = true;
	}
}