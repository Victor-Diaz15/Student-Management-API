using AutoMapper;
using StudentManagement.Core.Application.Dtos;
using StudentManagement.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
       public GeneralProfile()
       {
            #region mappings

            #region Student

            CreateMap<Student, Student_Dto>()
                .ReverseMap()
                .ForMember(x => x.Subjects, opt => opt.Ignore());

            #endregion

            #region Subject

            CreateMap<Subject, Subject_Dto>()
                .ReverseMap();

            #endregion

            #region Student_Subject

            CreateMap<Student_Subject, Student_Subject_Dto>()
                .ReverseMap();

            #endregion

            #endregion
        }

    }
}
