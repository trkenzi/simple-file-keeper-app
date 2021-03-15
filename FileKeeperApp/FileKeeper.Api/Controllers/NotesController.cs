using FileKeeper.BusinessLayer.Contracts.Contracts;
using FileKeeper.BusinessLayer.Contracts.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FileKeeper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        INoteService noteService;

        public NotesController(INoteService noteService)
        {
            this.noteService = noteService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<NoteResponseDTO>> GetAllNotes()
        {
            return Ok(noteService.GetAllNotes());
        }

        [HttpPost]
        public ActionResult<NoteResponseDTO> AddNewNote([FromBody] NoteRequestDTO noteData)
        {
            try
            {
                NoteResponseDTO createdNote = noteService.AddNote(noteData);
                return Ok(createdNote);
            }
            catch (ArgumentNullException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        [HttpDelete("{noteId}")]
        public ActionResult DeleteNote(int noteId)
        {
            try
            {
                noteService.DeleteNote(noteId);
                return NoContent();
            }
            catch (ArgumentException exception)
            {
                return NotFound(exception.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
          
           
        }

        [HttpPut("{noteId}")]
        public ActionResult<NoteResponseDTO> UpdateNote(int noteId, [FromBody] NoteRequestDTO noteData)
        {
            try
            {
                NoteResponseDTO updatedNote = noteService.UpdateNote(noteId, noteData);
                return updatedNote;
            }
            catch (ArgumentNullException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (ArgumentException exception)
            {
                return NotFound(exception.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
           
        }
      
    }
}
