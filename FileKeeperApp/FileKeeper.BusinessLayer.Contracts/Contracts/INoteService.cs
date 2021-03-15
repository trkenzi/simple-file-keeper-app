using FileKeeper.BusinessLayer.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileKeeper.BusinessLayer.Contracts.Contracts
{
    public interface INoteService
    {
        IEnumerable<NoteResponseDTO> GetAllNotes();
        bool DeleteNote(int noteId);
        NoteResponseDTO UpdateNote(int noteId, NoteRequestDTO noteData);
        NoteResponseDTO AddNote(NoteRequestDTO noteData);
    }
}
