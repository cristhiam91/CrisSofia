using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PmTool.UI
{
    public static class AutomapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                // Solo hay un Initialize
                cfg.CreateMap<Models.Users, DATA.Users>();
                cfg.CreateMap<DATA.Users, Models.Users>();

                cfg.CreateMap<Models.UserTypes, DATA.UserTypes>();
                cfg.CreateMap<DATA.UserTypes, Models.UserTypes>();

                cfg.CreateMap<Models.ConnectionTypes, DATA.ConnectionTypes>();
                cfg.CreateMap<DATA.ConnectionTypes, Models.ConnectionTypes>();

                cfg.CreateMap<Models.DataCenters, DATA.DataCenters>();
                cfg.CreateMap<DATA.DataCenters, Models.DataCenters>();

                cfg.CreateMap<Models.FabScopes, DATA.FabScopes>();
                cfg.CreateMap<DATA.FabScopes, Models.FabScopes>();

                cfg.CreateMap<Models.Factories, DATA.Factories>();
                cfg.CreateMap<DATA.Factories, Models.Factories>();

                cfg.CreateMap<Models.Labs, DATA.Labs>();
                cfg.CreateMap<DATA.Labs, Models.Labs>();

                cfg.CreateMap<Models.LabScopes, DATA.LabScopes>();
                cfg.CreateMap<DATA.LabScopes, Models.LabScopes>();

                cfg.CreateMap<Models.Offices, DATA.Offices>();
                cfg.CreateMap<DATA.Offices, Models.Offices>();

                cfg.CreateMap<Models.OfficeScopes, DATA.OfficeScopes>();
                cfg.CreateMap<DATA.OfficeScopes, Models.OfficeScopes>();

                cfg.CreateMap<Models.OtherProjects, DATA.OtherProjects>();
                cfg.CreateMap<DATA.OtherProjects, Models.OtherProjects>();

                cfg.CreateMap<Models.PhaseTypes, DATA.PhaseTypes>();
                cfg.CreateMap<DATA.PhaseTypes, Models.PhaseTypes>();

                cfg.CreateMap<Models.ProjectTypes, DATA.ProjectTypes>();
                cfg.CreateMap<DATA.ProjectTypes, Models.ProjectTypes>();

                cfg.CreateMap<Models.SpeedConnectionTypes, DATA.SpeedConnectionTypes>();
                cfg.CreateMap<DATA.SpeedConnectionTypes, Models.SpeedConnectionTypes>();

                cfg.CreateMap<Models.DcScopes, DATA.DcScopes>();
                cfg.CreateMap<DATA.DcScopes, Models.DcScopes>();

                // Por cada objeto que tenga
            });
        }
    }
}