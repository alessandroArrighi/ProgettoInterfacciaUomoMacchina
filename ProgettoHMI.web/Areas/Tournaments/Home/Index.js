var Tournaments;
(function (Tournaments) {
    var Home;
    (function (Home) {
        class IndexViewModel {
            constructor(model) {
                this.register = false;
                this.handleSub = async () => {
                    let flag = true;
                    try {
                        console.log(`${this.model.registerUrl}?TournamentId=${this.model.tournament.id}&UserId=${this.model.userId}`);
                        let res = await fetch(`${this.model.registerUrl}?TournamentId=${this.model.tournament.id}&UserId=${this.model.userId}`);
                        const data = await res.json();
                        if (data) {
                            alert("Iscrizione avvenuta con successo!");
                            this.register = false;
                            flag = false;
                        }
                    }
                    finally {
                        if (flag) {
                            alert("Iscrizione cancellata. Riprovare più tardi");
                        }
                    }
                };
                this.model = model;
                let now = new Date();
                let startDate = new Date(this.model.tournament.startDate);
                if (!this.isAlreadyRegister() && this.model.isLogged && startDate > now) {
                    this.register = true;
                }
            }
            isAlreadyRegister() {
                let flag = false;
                for (let i = 0; i < this.model.users.length && !flag; ++i) {
                    let user = this.model.users[i];
                    if (user.id == this.model.userId) {
                        flag = true;
                    }
                }
                return flag;
            }
        }
        Home.IndexViewModel = IndexViewModel;
    })(Home = Tournaments.Home || (Tournaments.Home = {}));
})(Tournaments || (Tournaments = {}));
//# sourceMappingURL=Index.js.map