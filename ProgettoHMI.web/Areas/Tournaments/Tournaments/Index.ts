module Tournaments.Tournaments {
    export class indexViewModel {
        public model: Tournaments.Server.IndexViewModelInterface;
        public cities: Tournaments.Server.TournamentFiltersViewModelInterface[]
        public ranks: Tournaments.Server.TournamentFiltersViewModelInterface[]
        public selectedCities: string[] = [];
        public selectedRanks: number[] = [];
        public startDate: Date | null = null;
        public endDate: Date | null = null;
        public filtersCount: number = 0;

        public constructor(model: Tournaments.Server.IndexViewModelInterface) {
            this.model = model;

            this.initCities()
            this.initRanks()
        }

        private initCities = () => {
            this.cities = [
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
        }

        private initRanks = () => {
            this.ranks = [
                { value: "1", selected: false },
                { value: "2", selected: false },
                { value: "3", selected: false },
                { value: "4", selected: false }
            ]
        }

        public resetFilters = () => {
            this.selectedCities = []
            this.initCities()
            
            this.selectedRanks = []
            this.initRanks()

            this.startDate = null
            this.endDate = null
            this.filtersCount = 0
        }

        public getTournaments = async (filters: Tournaments.Server.TournamentsFilterQueryViewModelInterface) => {
            let res = await fetch(this.model.urlFilters, {
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

        public handleCityOnClick = (city: Tournaments.Server.TournamentFiltersViewModelInterface) => {
            city.selected = !city.selected;

            if(city.selected) {
                this.filtersCount++
            } else {
                this.filtersCount--
            }

            this.handleCitySelectionChange(city);
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

        public handleRankOnClick = (rank: Tournaments.Server.TournamentFiltersViewModelInterface) => {
            rank.selected = !rank.selected;

            if(rank.selected) {
                this.filtersCount++
            } else {
                this.filtersCount--
            }
            
            this.handleRankSelectionChange(rank);
        }

        public handleStartDateChange = () => {
            if (typeof this.startDate === "string" && this.startDate === "") {
                this.startDate = null;
                this.endDate = null;
                this.filtersCount--;
            } else {
                this.endDate = new Date(this.startDate);
                this.endDate.setDate(this.endDate.getDate() + 90);
                this.filtersCount++;
            }

            this.performTournamentReq();
        }
    }
    
}