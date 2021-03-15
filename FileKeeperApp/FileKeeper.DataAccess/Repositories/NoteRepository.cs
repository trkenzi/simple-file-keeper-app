using AutoMapper;
using FileKeeper.DataAccess.Contracts.Contracts;
using FileKeeper.DataAccess.Contracts.Models;
using FileKeeper.DataAccess.ModelsEF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileKeeper.DataAccess.Repositories
{
    public class NoteRepository : INoteRepository
    {
        IMapper mapper;
        FileKeeperDbContext context;
        public NoteRepository(FileKeeperDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public Note AddNewNote(Note noteData)
        {
            if (noteData == null)
                throw new ArgumentNullException("Note data can not be null.");

            try
            {
                NoteModelEF noteModel = mapper.Map<NoteModelEF>(noteData);
                context.Notes.Add(noteModel);
                context.SaveChanges();

                return mapper.Map<Note>(noteModel);
            }
            catch (DbUpdateConcurrencyException exception)
            {
                throw new Exception(exception.Message);
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(exception.Message);
            }
           
        }

        public bool DeleteNote(int noteId)
        {
            NoteModelEF noteForDelete = context.Notes.SingleOrDefault(note => note.Id == noteId);

            if (noteForDelete == null)
                throw new ArgumentException("Note with given ID does not exist.");

            try
            {
                context.Notes.Remove(noteForDelete);
                context.SaveChanges();
                return true;
            }
            catch(DbUpdateConcurrencyException exception)
            {
                throw new Exception(exception.Message);
            }
            catch(DbUpdateException exception)
            {
                throw new Exception(exception.Message);
            }

        }

        public IEnumerable<Note> GetAllNotes()
        {
            return mapper.Map<IEnumerable<Note>>(context.Notes.ToList());
        }

        public Note UpdateNote(int noteId, Note noteData)
        {
            if (noteData == null)
                throw new ArgumentNullException("Note data can not be null.");

            NoteModelEF noteForUpdate = context.Notes.SingleOrDefault(note => note.Id == noteId);

            if (noteForUpdate == null)
                throw new ArgumentException("Note with given ID does not exist.");

            try
            {
                noteForUpdate.ImportantDate = noteData.ImportantDate;
                noteForUpdate.Title = noteData.Title;
                noteForUpdate.Description = noteData.Description;

                context.Notes.Update(noteForUpdate);
                context.SaveChanges();

                return mapper.Map<Note>(noteForUpdate);
            }
            catch (DbUpdateConcurrencyException exception)
            {
                throw new Exception(exception.Message);
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(exception.Message);
            }

        }
    }
}
