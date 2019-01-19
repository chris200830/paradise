using System.Collections.Generic;
using DTO.Entities;

namespace Service.Interfaces
{
    public interface IDialogueService
    {
        void AddDialogue(Dialogue dialogue);
        void UpdateDialogue(Dialogue dialogue);
        void RemoveDialogue(Dialogue dialogue);
        void Dispose();
        IEnumerable<Dialogue> GetDialogues();
    }
}