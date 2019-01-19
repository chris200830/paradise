﻿using System;
using System.Collections.Generic;
using DTO.Entities;

namespace DAL.Interfaces
{
    public interface IDialogueOptionRepository : IDisposable
    {
        IEnumerable<DialogueOption> FindAllDialogueOptions();
        DialogueOption GetDialogueOptionById(int dialogueOptionId);
        void InsertDialogueOption(DialogueOption dialogueOption);
        void DeleteDialogueOption(int dialogueOptionId);
        void UpdateDialogueOption(DialogueOption dialogueOption);
        void Save();
    }
}