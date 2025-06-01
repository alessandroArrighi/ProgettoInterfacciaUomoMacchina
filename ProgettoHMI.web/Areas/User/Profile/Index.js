var User;
(function (User) {
    var Profile;
    (function (Profile) {
        class profileVueModel {
            constructor(tournaments, selectedSection, tournamentsToShow) {
                this.selectedSection = selectedSection;
                this.selectedFilter = "all";
                this.allTournaments = tournaments;
                this.tournamentsToShow = tournamentsToShow !== null && tournamentsToShow !== void 0 ? tournamentsToShow : 4;
            }
            get filteredTournaments() {
                if (this.selectedFilter === "all")
                    return this.allTournaments;
                // Filtro per nome rank (adatta se serve per id)
                return this.allTournaments.filter(t => t.rank && t.rank.name && t.rank.name.toLowerCase() === this.selectedFilter);
            }
            get tournaments() {
                return this.filteredTournaments.slice(0, this.tournamentsToShow);
            }
            loadMoreTournaments() {
                if (this.tournamentsToShow >= this.filteredTournaments.length) {
                    this.sendAlerts("Non ci sono più tornei da mostrare!");
                    return;
                }
                this.tournamentsToShow += 4;
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
        }
        Profile.profileVueModel = profileVueModel;
    })(Profile = User.Profile || (User.Profile = {}));
})(User || (User = {}));
//# sourceMappingURL=Index.js.map