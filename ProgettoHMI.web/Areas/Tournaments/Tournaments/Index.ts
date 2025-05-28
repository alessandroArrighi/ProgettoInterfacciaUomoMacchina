module Tournaments.Tournaments {
    export class indexViewModel {
        public model: Tournaments.Server.IndexViewModelInterface;
        public cities: string[] = ["Milano", "Roma", "Torino", "Napoli", "Firenze", "Bologna", "Palermo", "Genova", "Catania", "Verona"];
        public selectedCities: string[] = [];
        public slectedRanks: number[] = [];
        public startDate: Date | null = null;
        public endDate: Date | null = null;

        public constructor(model: Tournaments.Server.IndexViewModelInterface) {
            this.model = model;
        }

        public getTournaments = async (filters: Tournaments.Server.TournamentsFilterQueryViewModelInterface) => {
            let res = await fetch("/Tournaments/Tournaments/TournamentsFilters", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(filters)
            });

            if (res.ok) {
                let data = await res.json();
                this.model.tournaments = <Tournaments.Server.TournamentViewModelInterface[]>data;
            } else {
                console.error("Failed to fetch tournaments:", res.statusText);
            }
        }

        public performTournamentReq = () => {
            let data = <Tournaments.Server.TournamentsFilterQueryViewModelInterface>{
                city: this.selectedCities,
                rank: this.slectedRanks,
                startDate: this.startDate,
                endDate: this.endDate
            }

            this.getTournaments(data);
        }

        public handleCitySelectionChange = (city: string, isSelected: boolean) => {
            if (isSelected) {
                this.selectedCities.push(city);
            } else {
                const index = this.selectedCities.indexOf(city);
                if (index > -1) {
                    this.selectedCities.splice(index, 1);
                }
            }

            this.performTournamentReq();
        }
    }
}