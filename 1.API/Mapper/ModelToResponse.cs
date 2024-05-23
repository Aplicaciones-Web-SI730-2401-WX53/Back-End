using _1.API.Response;
using _3._Data;
using _3._Data.Models;
using AutoMapper;

namespace _1.API.Mapper;

public class ModelToResponse : Profile
{
    public ModelToResponse()
    {
        CreateMap<Tutorial, TutorialResponse>();
        CreateMap<Section, SectionResponse>();
    }
}