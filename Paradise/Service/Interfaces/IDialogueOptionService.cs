using System.Collections.Generic;
using DTO.Entities;

namespace Service.Interfaces
{
    public interface IDialogueOptionService
    {
        void AddDialogueOption(DialogueOption dialogueOption);
        void UpdateDialogueOption(DialogueOption dialogueOption);
        void RemoveDialogueOption(DialogueOption dialogueOption);
        void Dispose();
        IEnumerable<DialogueOption> GetDialogueOptions();
    }
}