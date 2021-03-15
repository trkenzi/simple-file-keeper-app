using AutoMapper;
using FileKeeper.BusinessLayer.Contracts.DTOs;
using FileKeeper.DataAccess.Contracts.Models;
using FileKeeper.DataAccess.ModelsEF;

namespace FileKeeper.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PhotoRequestDTO, Photo>();
            CreateMap<Photo, PhotoModelEF>();

            CreateMap<PhotoModelEF, Photo>();
            CreateMap<Photo, PhotoResponseDTO>();

            CreateMap<NoteRequestDTO, Note>();
            CreateMap<Note, NoteModelEF>();

            CreateMap<NoteModelEF, Note>();
            CreateMap<Note, NoteResponseDTO>();

        }
    }
}
