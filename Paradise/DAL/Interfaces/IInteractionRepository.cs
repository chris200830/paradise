using System;
using System.Collections.Generic;
using DTO.Entities;

namespace DAL.Interfaces
{
    public interface IInteractionRepository : IDisposable
    {
        IEnumerable<Interaction> FindAllInteractions();
        Interaction GetInteractionById(int interactionId);
        void InsertInteraction(Interaction interaction);
        void DeleteInteraction(int interactionId);
        void UpdateInteraction(Interaction interaction);
        void Save();
    }
}