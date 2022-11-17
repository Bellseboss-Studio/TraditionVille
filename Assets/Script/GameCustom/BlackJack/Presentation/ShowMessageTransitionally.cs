using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowMessageTransitionally : Presentation
{
    [SerializeField] private Button next;
    [SerializeField] private TextMeshProUGUI titleText, messageText;
    public Action OnClickInScream;

    private void Start()
    {
        next.onClick.AddListener(() =>
        {
            OnClickInScream?.Invoke();
            animator.SetTrigger("next");
        });
    }

    public void ShowMessage(string title, string message)
    {
        titleText.text = title;
        messageText.text = message;
        StartPresentation();
    }

    public void ShowMessage(string title, string message, float time)
    {
        ShowMessage(title, message);
        this.tt().Add(handle =>
        {
            handle.Wait(time);
            next.onClick?.Invoke();
        });
    }
}