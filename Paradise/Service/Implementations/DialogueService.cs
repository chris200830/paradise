using System.Collections.Generic;
using System.Linq;
using DAL.Database;
using DAL.Interfaces;
using DAL.Repositories;
using DTO.Entities;
using Service.Interfaces;

namespace Service.Implementations
{
    public class DialogueService : IDialogueService
    {
        private readonly IDialogueRepository dialogueRepository;

        public DialogueService()
        {
            var context = new WpfAppContext();
            dialogueRepository = new DialogueRepository(context);
        }

        public void AddDialogue(Dialogue dialogue)
        {
            dialogueRepository.InsertDialogue(dialogue);
            dialogueRepository.Save();
        }

        public void UpdateDialogue(Dialogue dialogue)
        {
            dialogueRepository.UpdateDialogue(dialogue);
            dialogueRepository.Save();
        }

        public void RemoveDialogue(Dialogue dialogue)
        {
            dialogueRepository.DeleteDialogue(dialogue.DialogueId);
            dialogueRepository.Save();
        }

        public void Dispose()
        {
            dialogueRepository.Dispose();
        }

        public IEnumerable<Dialogue> GetDialogues()
        {
            return dialogueRepository.FindAllDialogues().ToList();
        }
    }
}
