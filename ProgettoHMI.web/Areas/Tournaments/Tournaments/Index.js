var Tournaments;
(function (Tournaments_1) {
    var Tournaments;
    (function (Tournaments) {
        class indexViewModel {
            constructor(model) {
                this.cities = ["Milano", "Roma", "Torino", "Napoli", "Firenze", "Bologna", "Palermo", "Genova", "Catania", "Verona"];
                this.selectedCities = [];
                this.slectedRanks = [];
                this.startDate = null;
                this.endDate = null;
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
                        rank: this.slectedRanks,
                        startDate: this.startDate,
                        endDate: this.endDate
                    };
                    this.getTournaments(data);
                };
                this.handleCitySelectionChange = (city, isSelected) => {
                    if (isSelected) {
                        this.selectedCities.push(city);
                    }
                    else {
                        const index = this.selectedCities.indexOf(city);
                        if (index > -1) {
                            this.selectedCities.splice(index, 1);
                        }
                    }
                    this.performTournamentReq();
                };
                this.model = model;
            }
        }
        Tournaments.indexViewModel = indexViewModel;
    })(Tournaments = Tournaments_1.Tournaments || (Tournaments_1.Tournaments = {}));
})(Tournaments || (Tournaments = {}));
//# sourceMappingURL=Index.js.map