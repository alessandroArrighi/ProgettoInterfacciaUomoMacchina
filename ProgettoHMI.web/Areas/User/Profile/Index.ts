module User.Profile {
    export class profileVueModel {
        public selectedFilter: string = "all";
        public tournamentsToShow: number;
        public allTournaments: Profile.Server.ITournamentModel[];

        constructor( tournaments: Profile.Server.ITournamentModel[], public selectedSection: number, tournamentsToShow: number ) {
            this.allTournaments = tournaments;
            this.tournamentsToShow = tournamentsToShow ?? 4;
        }

        get filteredTournaments(): Profile.Server.ITournamentModel[] {
            if (this.selectedFilter === "all") return this.allTournaments;
            // Filtro per nome rank (adatta se serve per id)
            return this.allTournaments.filter(
                t => t.rank && t.rank.name && t.rank.name.toLowerCase() === this.selectedFilter
            );
        }

        get tournaments(): User.Profile.Server.ITournamentModel[] {
            return this.filteredTournaments.slice(0, this.tournamentsToShow);
        }

        loadMoreTournaments() {
            if (this.tournamentsToShow >= this.filteredTournaments.length) {
                this.sendAlerts("Non ci sono più tornei da mostrare!");
                return;
            }
            this.tournamentsToShow += 4;
        }

        onFilterChange(e: Event) {
            const target = e.target as HTMLSelectElement;
            this.selectedFilter = target.value;
            this.tournamentsToShow = 4;
        }

        sendAlerts(message: string) {
            Toastify({
                text: message,
                className: "onit-toastify onit-toastify-info",
                close: true,
                gravity: 'bottom',
                position: 'left',
                duration: 3000
            }).showToast();
        }
    }
}
