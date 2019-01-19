using System;
using System.Collections.Generic;
using DTO.Entities;

namespace DAL.Interfaces
{
    public interface IDialogueRepository : IDisposable
    {
        IEnumerable<Dialogue> FindAllDialogues();
        Dialogue GetDialogueById(int dialogueId);
        void InsertDialogue(Dialogue dialogue);
        void DeleteDialogue(int dialogueId);
        void UpdateDialogue(Dialogue dialogue);
        void Save();
    }
}