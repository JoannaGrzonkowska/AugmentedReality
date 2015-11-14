using AutoMapper;
using CQRS.Implementation.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Implementation
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new GroupProfile());
                cfg.AddProfile(new NoteProfile());                
            });
        }
    }
}
