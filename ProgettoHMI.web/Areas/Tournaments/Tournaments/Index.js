var Tournaments;
(function (Tournaments_1) {
    var Tournaments;
    (function (Tournaments) {
        class indexViewModel {
            constructor(model) {
                this.selectedCities = [];
                this.selectedRanks = [];
                this.startDate = null;
                this.endDate = null;
                this.filtersCount = 0;
                this.initCities = () => {
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
                };
                this.initRanks = () => {
                    this.ranks = [
                        { value: "1", selected: false },
                        { value: "2", selected: false },
                        { value: "3", selected: false },
                        { value: "4", selected: false }
                    ];
                };
                this.resetFilters = () => {
                    this.selectedCities = [];
                    this.initCities();
                    this.selectedRanks = [];
                    this.initRanks();
                    this.startDate = null;
                    this.endDate = null;
                    this.filtersCount = 0;
                };
                this.getTournaments = async (filters) => {
                    let res = await fetch("/Tournaments/Tournaments/TournamentsFilters", {
                        method: "POST",
                        headers: {
                            "Content-Type": "application/json"
                        },
                        body: JSON.stringify(filters)
                    });
                    if (res.ok) {
                        let data = await res.json();
                        this.model.tournaments = data;
                    }
                    else {
                        console.error("Failed to fetch tournaments:", res.statusText);
                    }
                };
                this.performTournamentReq = () => {
                    let data = {
                        city: this.selectedCities,
                        rank: this.selectedRanks,
                        startDate: this.startDate,
                        endDate: this.endDate
                    };
                    this.getTournaments(data);
                };
                this.handleCitySelectionChange = (city) => {
                    if (city.selected) {
                        this.selectedCities.push(city.value);
                    }
                    else {
                        const index = this.selectedCities.indexOf(city.value);
                        if (index > -1) {
                            this.selectedCities.splice(index, 1);
                        }
                    }
                    this.performTournamentReq();
                };
                this.handleCityOnClick = (city) => {
                    city.selected = !city.selected;
                    if (city.selected) {
                        this.filtersCount++;
                    }
                    else {
                        this.filtersCount--;
                    }
                    this.handleCitySelectionChange(city);
                };
                this.handleRankSelectionChange = (rank) => {
                    if (rank.selected) {
                        this.selectedRanks.push(Number(rank.value));
                    }
                    else {
                        const index = this.selectedRanks.indexOf(Number(rank.value));
                        if (index > -1) {
                            this.selectedRanks.splice(index, 1);
                        }
                    }
                    this.performTournamentReq();
                };
                this.handleRankOnClick = (rank) => {
                    rank.selected = !rank.selected;
                    if (rank.selected) {
                        this.filtersCount++;
                    }
                    else {
                        this.filtersCount--;
                    }
                    this.handleRankSelectionChange(rank);
                };
                this.handleStartDateChange = () => {
                    if (typeof this.startDate === "string" && this.startDate === "") {
                        this.startDate = null;
                        this.endDate = null;
                        this.filtersCount--;
                    }
                    else {
                        this.endDate = new Date(this.startDate);
                        this.endDate.setDate(this.endDate.getDate() + 90);
                        this.filtersCount++;
                    }
                    this.performTournamentReq();
                };
                this.model = model;
                this.initCities();
                this.initRanks();
            }
        }
        Tournaments.indexViewModel = indexViewModel;
    })(Tournaments = Tournaments_1.Tournaments || (Tournaments_1.Tournaments = {}));
})(Tournaments || (Tournaments = {}));
//# sourceMappingURL=Index.js.map