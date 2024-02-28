using AutoMapper;
using Contracts;
using Core.DomainObjects;

namespace Core.MapProfiles
{
	public class SimulationProfile : Profile
	{
		public SimulationProfile()
		{
			CreateMap<Simulation, SimulationDto>();
			CreateMap<Round, RoundDto>();
			CreateMap<Match, MatchDto>();
			CreateMap<MatchTeam, MatchTeamDto>();
			CreateMap<TeamSummary, TeamSummaryDto>();
		}
	}
}
