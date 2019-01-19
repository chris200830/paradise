using System.Collections.Generic;
using System.Linq;
using DAL.Database;
using DAL.Interfaces;
using DAL.Repositories;
using DTO.Entities;
using Service.Interfaces;

namespace Service.Implementations
{
    public class InteractionService : IInteractionService
    {
        private readonly IInteractionRepository interactionRepository;

        public InteractionService()
        {
            var context = new WpfAppContext();
            interactionRepository = new InteractionRepository(context);
        }

        public void AddInteraction(Interaction interaction)
        {
            interactionRepository.InsertInteraction(interaction);
            interactionRepository.Save();
        }

        public void UpdateInteraction(Interaction interaction)
        {
            interactionRepository.UpdateInteraction(interaction);
            interactionRepository.Save();
        }

        public void RemoveInteraction(Interaction interaction)
        {
            interactionRepository.DeleteInteraction(interaction.InteractionId);
            interactionRepository.Save();
        }

        public void Dispose()
        {
            interactionRepository.Dispose();
        }

        public IEnumerable<Interaction> GetInteractions()
        {
            return interactionRepository.FindAllInteractions().ToList();
        }
    }
}
