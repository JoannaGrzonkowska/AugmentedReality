using AutoMapper;
using CQRS.Implementation.Profiles;

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
                cfg.AddProfile(new CategoryProfile());
                cfg.AddProfile(new TypeProfile());
                cfg.AddProfile(new InviteProfile());
            });
        }
    }
}
