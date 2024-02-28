using AutoMapper;
using Contracts;
using Web.ViewModels;

namespace Web.MapProfiles
{
	public class SimulationProfile : Profile
	{
		public SimulationProfile()
		{
			CreateMap<SimulationDto, SimulationViewModel>();
			CreateMap<RoundDto, RoundViewModel>();
			CreateMap<MatchDto, MatchViewModel>();
			CreateMap<MatchTeamDto, MatchTeamViewModel>();
			CreateMap<TeamSummaryDto, SummaryTeamViewModel>();
		}
	}
}
