using System.Collections.Generic;
using System.Linq;
using DAL.Database;
using DAL.Interfaces;
using DAL.Repositories;
using DTO.Entities;
using Service.Interfaces;

namespace Service.Implementations
{
    public class DialogueOptionService : IDialogueOptionService
    {
        private readonly IDialogueOptionRepository dialogueOptionRepository;

        public DialogueOptionService()
        {
            var context = new WpfAppContext();
            dialogueOptionRepository = new DialogueOptionRepository(context);
        }

        public void AddDialogueOption(DialogueOption dialogueOption)
        {
            dialogueOptionRepository.InsertDialogueOption(dialogueOption);
            dialogueOptionRepository.Save();
        }

        public void UpdateDialogueOption(DialogueOption dialogueOption)
        {
            dialogueOptionRepository.UpdateDialogueOption(dialogueOption);
            dialogueOptionRepository.Save();
        }

        public void RemoveDialogueOption(DialogueOption dialogueOption)
        {
            dialogueOptionRepository.DeleteDialogueOption(dialogueOption.DialogueOptionId);
            dialogueOptionRepository.Save();
        }

        public void Dispose()
        {
            dialogueOptionRepository.Dispose();
        }

        public IEnumerable<DialogueOption> GetDialogueOptions()
        {
            return dialogueOptionRepository.FindAllDialogueOptions().ToList();
        }
    }
}
