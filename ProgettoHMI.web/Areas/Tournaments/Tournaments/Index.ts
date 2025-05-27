module Tournaments.Tournaments {
    export class indexViewModel {
        public model: Tournaments.Server.IndexViewModelInterface;
        public cities: string[] = ["Milano", "Roma", "Torino", "Napoli", "Firenze", "Bologna", "Palermo", "Genova", "Catania", "Verona"];

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
    }
}