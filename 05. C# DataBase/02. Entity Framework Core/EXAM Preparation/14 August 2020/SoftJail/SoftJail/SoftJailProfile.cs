namespace SoftJail
{
    using AutoMapper;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;

    public class SoftJailProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public SoftJailProfile()
        {
            //Import Departments
            this.CreateMap<DepartmentCellInputModel, Department>();
            this.CreateMap<CellInputModel, Cell>();

            //Import Prisoners
            this.CreateMap<PrisonerInputModel, Prisoner>();
            this.CreateMap<MailInputModel, Mail>();

            //Import Officers
            this.CreateMap<OfficersInputModel, Officer>()
                .ForMember(x => x.FullName, y => y.MapFrom(s => s.Name))
                .ForMember(x => x.Salary, y => y.MapFrom(s => s.Money))
                .ForMember(x => x.OfficerPrisoners, y => y.MapFrom(s => s.Prisoners));

            this.CreateMap<PrisonerDTO, OfficerPrisoner>()
               .ForMember(x => x.PrisonerId, y => y.MapFrom(s => s.Id));




        }
    }
}
