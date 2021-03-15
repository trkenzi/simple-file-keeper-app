using AutoMapper;
using FileKeeper.BusinessLayer.Contracts.Contracts;
using FileKeeper.BusinessLayer.Contracts.DTOs;
using FileKeeper.DataAccess.Contracts.Contracts;
using FileKeeper.DataAccess.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileKeeper.BusinessLayer.Services
{
    public class NoteService : INoteService
    {
        IMapper mapper;
        INoteRepository noteRepository;
        public NoteService(IMapper mapper, INoteRepository noteRepository)
        {
            this.mapper = mapper;
            this.noteRepository = noteRepository;
        }
        public NoteResponseDTO AddNote(NoteRequestDTO noteData)
        {
            if (noteData == null)
                throw new ArgumentNullException("Note data can not be null.");

            return mapper.Map<NoteResponseDTO>(noteRepository.AddNewNote(mapper.Map<Note>(noteData)));
        }

        public bool DeleteNote(int noteId)
        {
            return noteRepository.DeleteNote(noteId);
        }

        public IEnumerable<NoteResponseDTO> GetAllNotes()
        {
            return mapper.Map<IEnumerable<NoteResponseDTO>>(noteRepository.GetAllNotes());
        }

        public NoteResponseDTO UpdateNote(int noteId, NoteRequestDTO noteData)
        {
            if (noteData == null)
                throw new ArgumentNullException("Note data can not be null.");

            return mapper.Map<NoteResponseDTO>(noteRepository.UpdateNote(noteId, mapper.Map<Note>(noteData)));
        }
    }
}
