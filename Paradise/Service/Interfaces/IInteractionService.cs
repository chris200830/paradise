using System.Collections.Generic;
using DTO.Entities;

namespace Service.Interfaces
{
    public interface IInteractionService
    {
        void AddInteraction(Interaction interaction);
        void UpdateInteraction(Interaction interaction);
        void RemoveInteraction(Interaction interaction);
        void Dispose();
        IEnumerable<Interaction> GetInteractions();
    }
}