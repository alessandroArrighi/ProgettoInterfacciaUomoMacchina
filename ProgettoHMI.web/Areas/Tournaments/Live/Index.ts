module Tournaments.Live {
    export class indexViewModel {
        public model: Live.Server.IndexViewModelInterface;
        public cities: Live.Server.TournamentCityFiltersViewModelInterface[]
        public ranks: Live.Server.TournamentRankFiltersViewModelInterface[]
        public selectedCities: string[] = [];
        public selectedRanks: number[] = [];
        public startDate: Date | null = null;
        public endDate: Date | null = null;
        public filtersCount: number = 0;
        public popUpTournament: any = null
        public drawUrl: string
        public cardWidth: string = ""
        public showTournamentLst: Tournaments.Server.TournamentViewModelInterface[] = []
        public showTournamentFlag: boolean = true

        public constructor(model: Live.Server.IndexViewModelInterface, drawUrl: string) {
            this.model = model;
            this.model.games = []

            this.initCities()
            this.initRanks()
            this.initShowTournament()

            this.drawUrl = drawUrl

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
                { value: "1", label: "Bronzo" , selected: false },
                { value: "2", label: "Argento", selected: false },
                { value: "3", label: "Oro", selected: false },
                { value: "4", label: "Diamante", selected: false }
            ]
        }

        private initShowTournament = () => {
            this.showTournamentLst = []
            this.showTournamentFlag = true
            this.showMoreTournaments()
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

        /* -------- Tournaments -------- */
        public getTournaments = async (filters: Live.Server.TournamentsFilterQueryViewModelInterface) => {
            let res = await fetch(this.model.urlFilters, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(filters)
            });

            if (res.ok) {
                let data = await res.json();
                this.model.tournaments = <Live.Server.TournamentViewModelInterface[]>data;
                this.initShowTournament()
            } else {
                console.error("Failed to fetch tournaments:", res.statusText);
            }
        }

        public performTournamentReq = () => {
            let data = <Live.Server.TournamentsFilterQueryViewModelInterface>{
                city: this.selectedCities,
                rank: this.selectedRanks,
                startDate: this.startDate,
                endDate: this.endDate,
                status: 1
            }
            
            this.getTournaments(data);
        }

        public handleCitySelectionChange = (city: Live.Server.TournamentCityFiltersViewModelInterface) => {
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

        public handleCityOnClick = (city: Live.Server.TournamentCityFiltersViewModelInterface) => {
            city.selected = !city.selected;

            if(city.selected) {
                this.filtersCount++
            } else {
                this.filtersCount--
            }

            this.handleCitySelectionChange(city);
        }

        public handleRankSelectionChange = (rank: Live.Server.TournamentRankFiltersViewModelInterface) => {
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

        public handleRankOnClick = (rank: Live.Server.TournamentRankFiltersViewModelInterface) => {
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

        public showMoreTournaments = () => {
            let lenStart = this.showTournamentLst.length
            for(let i = lenStart; i < 10 + lenStart && this.showTournamentFlag; ++i) {
                let len = this.showTournamentLst.length

                if(len < this.model.tournaments.length) {
                    this.showTournamentLst.push(this.model.tournaments[i])
                } else {
                    this.showTournamentFlag = false
                }
            }

            if(this.showTournamentLst.length == this.model.tournaments.length) {
                this.showTournamentFlag = false
            }
        }

        /* -------- Games -------- */
        public getGames = async (tournamentId: any) => {
            let res = await fetch(`${this.model.urlGames}?tournamentId=${tournamentId}`, {
                method: "GET",
                headers: {
                    "Content-Type": "application/json"
                },
            });

            if (res.ok) {
                let data = await res.json();
                this.model.games = <Live.Server.IGameModel[]>data
            } else {
                this.model.games = []
                console.error("Failed to fetch tournaments:", res.statusText);
            }
        }

        public performeGamesReq = (tournamentId: any) => {
            if(this.popUpTournament != tournamentId)
                this.popUpTournament = tournamentId
            else
                this.popUpTournament = null

            this.getGames(tournamentId)
        }
    }
    
}