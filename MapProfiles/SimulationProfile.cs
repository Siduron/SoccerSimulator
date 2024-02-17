using AutoMapper;
using SoccerSimulator.Models;
using SoccerSimulator.ViewModels;

namespace SoccerSimulator.MapProfiles
{
	public class SimulationProfile : Profile
	{
		public SimulationProfile()
		{
			CreateMap<Simulation, SimulationViewModel>();
			CreateMap<Round, RoundViewModel>();
			CreateMap<Match, MatchViewModel>();
			CreateMap<MatchTeam, MatchTeamViewModel>();
			CreateMap<SummaryTeam, SummaryTeamViewModel>();
		}
	}
}
