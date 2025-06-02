var User;
(function (User) {
    var Profile;
    (function (Profile) {
        class profileVueModel {
            constructor(tournaments, selectedSection, tournamentsToShow) {
                this.selectedSection = selectedSection;
                this.selectedFilter = "all";
                this.sortOrder = "desc";
                this.statusFilter = "all";
                this.allTournaments = tournaments;
                this.tournamentsToShow = tournamentsToShow !== null && tournamentsToShow !== void 0 ? tournamentsToShow : 4;
            }
            get filteredTournaments() {
                let filtered = this.selectedFilter === "all"
                    ? this.allTournaments
                    : this.allTournaments.filter(t => t.rank && t.rank.name && t.rank.name.toLowerCase() === this.selectedFilter);
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
            get tournaments() {
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
            onFilterChange(e) {
                const target = e.target;
                this.selectedFilter = target.value;
                this.tournamentsToShow = 4;
            }
            sendAlerts(message) {
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
                if (!dateStr)
                    return '';
                const date = new Date(dateStr);
                //return date.toLocaleDateString('it-IT') + ' ' + date.toLocaleTimeString('it-IT', { hour: '2-digit', minute: '2-digit' });
                return date.toLocaleDateString('it-IT');
            }
        }
        Profile.profileVueModel = profileVueModel;
    })(Profile = User.Profile || (User.Profile = {}));
})(User || (User = {}));
//# sourceMappingURL=Index.js.map