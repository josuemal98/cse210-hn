using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] splitWords = text.Split(' ');
        foreach (string wordText in splitWords)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        int countToHide = Math.Min(numberToHide, visibleWords.Count);

        for (int i = 0; i < countToHide; i++)
        {
            int randomIndex = random.Next(visibleWords.Count);
            visibleWords[randomIndex].Hide();
            visibleWords.RemoveAt(randomIndex);
        }
    }

    public string GetDisplayText()
    {
        string referenceText = _reference.GetDisplayText();
        List<string> wordStrings = _words.Select(w => w.GetDisplayText()).ToList();
        string scriptureText = string.Join(" ", wordStrings);

        return $"{referenceText}\n{scriptureText}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}