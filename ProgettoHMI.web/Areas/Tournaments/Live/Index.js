var Tournaments;
(function (Tournaments) {
    var Live;
    (function (Live) {
        class indexViewModel {
            constructor(model, drawUrl) {
                this.selectedCities = [];
                this.selectedRanks = [];
                this.startDate = null;
                this.endDate = null;
                this.filtersCount = 0;
                this.popUpTournament = null;
                this.cardWidth = "";
                this.showTournamentLst = [];
                this.showTournamentFlag = true;
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
                        { value: "1", label: "Bronzo", selected: false },
                        { value: "2", label: "Argento", selected: false },
                        { value: "3", label: "Oro", selected: false },
                        { value: "4", label: "Diamante", selected: false }
                    ];
                };
                this.initShowTournament = () => {
                    this.showTournamentLst = [];
                    this.showTournamentFlag = true;
                    this.showMoreTournaments();
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
                /* -------- Tournaments -------- */
                this.getTournaments = async (filters) => {
                    let res = await fetch(this.model.urlFilters, {
                        method: "POST",
                        headers: {
                            "Content-Type": "application/json"
                        },
                        body: JSON.stringify(filters)
                    });
                    if (res.ok) {
                        let data = await res.json();
                        this.model.tournaments = data;
                        this.initShowTournament();
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
                        endDate: this.endDate,
                        status: 1
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
                this.showMoreTournaments = () => {
                    let lenStart = this.showTournamentLst.length;
                    for (let i = lenStart; i < 10 + lenStart && this.showTournamentFlag; ++i) {
                        let len = this.showTournamentLst.length;
                        if (len < this.model.tournaments.length) {
                            this.showTournamentLst.push(this.model.tournaments[i]);
                        }
                        else {
                            this.showTournamentFlag = false;
                        }
                    }
                    if (this.showTournamentLst.length == this.model.tournaments.length) {
                        this.showTournamentFlag = false;
                    }
                };
                /* -------- Games -------- */
                this.getGames = async (tournamentId) => {
                    let res = await fetch(`${this.model.urlGames}?tournamentId=${tournamentId}`, {
                        method: "GET",
                        headers: {
                            "Content-Type": "application/json"
                        },
                    });
                    if (res.ok) {
                        let data = await res.json();
                        this.model.games = data;
                    }
                    else {
                        this.model.games = [];
                        console.error("Failed to fetch tournaments:", res.statusText);
                    }
                };
                this.performeGamesReq = (tournamentId) => {
                    if (this.popUpTournament != tournamentId)
                        this.popUpTournament = tournamentId;
                    else
                        this.popUpTournament = null;
                    this.getGames(tournamentId);
                };
                this.model = model;
                this.model.games = [];
                this.initCities();
                this.initRanks();
                this.initShowTournament();
                this.drawUrl = drawUrl;
            }
        }
        Live.indexViewModel = indexViewModel;
    })(Live = Tournaments.Live || (Tournaments.Live = {}));
})(Tournaments || (Tournaments = {}));
//# sourceMappingURL=Index.js.map