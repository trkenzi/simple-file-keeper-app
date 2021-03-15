using FileKeeper.DataAccess.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileKeeper.DataAccess.Contracts.Contracts
{
    public interface INoteRepository
    {
        IEnumerable<Note> GetAllNotes();
        Note AddNewNote(Note noteData);
        bool DeleteNote(int noteId);
        Note UpdateNote(int noteId, Note noteData);
    }
}
