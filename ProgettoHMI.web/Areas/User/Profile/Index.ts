module User.Profile {
    export class profileVueModel {
        public selectedFilter: string = "all";
        public sortOrder: string = "desc";
        public statusFilter: string = "all";
        public tournamentsToShow: number;
        public allTournaments: Profile.Server.ITournamentModel[];

        constructor( tournaments: Profile.Server.ITournamentModel[], public selectedSection: number, tournamentsToShow: number ) {
            this.allTournaments = tournaments;
            this.tournamentsToShow = tournamentsToShow ?? 4;
        }

        get filteredTournaments(): User.Profile.Server.ITournamentModel[] {
            let filtered = this.selectedFilter === "all"
                ? this.allTournaments
                : this.allTournaments.filter(
                    t => t.rank && t.rank.name && t.rank.name.toLowerCase() === this.selectedFilter
                );

            
            if (this.statusFilter !== "all") {
                filtered = filtered.filter(t => t.status.toString() === this.statusFilter);
            }

            
            filtered = filtered.slice().sort((a, b) => {
                const dateA = new Date(a.startDate).getTime();
                const dateB = new Date(b.startDate).getTime();
                return this.sortOrder === "asc" ? dateA - dateB : dateB - dateA;
            });

            return Array.isArray(filtered) ? filtered : [];
        }

        get tournaments(): User.Profile.Server.ITournamentModel[] {
            return this.filteredTournaments.slice(0, this.tournamentsToShow);
        }

        loadMoreTournaments() {
            if (this.tournamentsToShow >= this.filteredTournaments.length) {
                return;
            }

            this.tournamentsToShow += 4;

            if (this.tournamentsToShow >= this.filteredTournaments.length) {
                this.sendAlerts("Non ci sono più tornei da mostrare!");
            }
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

        formatDate(dateStr) {
            if (!dateStr) return '';
            const date = new Date(dateStr);
            
            //return date.toLocaleDateString('it-IT') + ' ' + date.toLocaleTimeString('it-IT', { hour: '2-digit', minute: '2-digit' });
            return date.toLocaleDateString('it-IT');
        }
    }
}
