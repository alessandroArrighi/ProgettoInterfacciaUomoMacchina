module Tournaments.Tournaments {
    export class indexViewModel {
        public model: Tournaments.Server.IndexViewModelInterface;
        public cities: Tournaments.Server.TournamentFiltersViewModelInterface[] = [
            { value: "Milano", selected: false },
            { value: "Roma", selected: false },
            { value: "Torino", selected: false },
            { value: "Napoli", selected: false },
            { value: "Firenze", selected: false },
            { value: "Bologna", selected: false },
            { value: "Palermo", selected: false },
            { value: "Genova", selected: false },
            { value: "Catania", selected: false },
            { value: "Verona", selected: false }
        ];
        public ranks: Tournaments.Server.TournamentFiltersViewModelInterface[] = [
            { value: "1", selected: false },
            { value: "2", selected: false },
            { value: "3", selected: false },
            { value: "4", selected: false }
        ]
        public selectedCities: string[] = [];
        public selectedRanks: number[] = [];
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
                rank: this.selectedRanks,
                startDate: this.startDate,
                endDate: this.endDate
            }

            this.getTournaments(data);
        }

        public handleCitySelectionChange = (city: Tournaments.Server.TournamentFiltersViewModelInterface) => {
            if (city.selected) {
                this.selectedCities.push(city.value);
            } else {
                const index = this.selectedCities.indexOf(city.value);
                if (index > -1) {
                    this.selectedCities.splice(index, 1);
                }
            }

            this.performTournamentReq();
        }

        public handleRankSelectionChange = (rank: Tournaments.Server.TournamentFiltersViewModelInterface) => {
            if (rank.selected) {
                this.selectedRanks.push(Number(rank.value));
            } else {
                const index = this.selectedRanks.indexOf(Number(rank.value));
                if (index > -1) {
                    this.selectedRanks.splice(index, 1);
                }
            }

            this.performTournamentReq();
        }

        public handleStartDateChange = () => {
            if (typeof this.startDate === "string" && this.startDate === "") {
                this.startDate = null;
                this.endDate = null;
            } else {
                this.endDate = new Date(this.startDate);
                this.endDate.setDate(this.endDate.getDate() + 90);
            }

            this.performTournamentReq();
        }
    }
    
}