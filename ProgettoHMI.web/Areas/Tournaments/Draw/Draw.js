var Tournaments;
(function (Tournaments) {
    var Draw;
    (function (Draw) {
        class drawVueModel {
            constructor(model) {
                this.model = model;
                this.loadingGetSingleDrawPosition = false;
                this.sets = [];
                this.tempGames = null;
                this.playerNameFilter = "";
                this.getSingleDrawPosition = async (pos) => {
                    try {
                        this.tempGames = null;
                        this.loadingGetSingleDrawPosition = true;
                        const choice = this.model.selectBtn;
                        var url = this.model.urlRaw + "?position=" + pos + "&tournamentId=" + this.model.tournamentId;
                        await this.getJsonT(url).then((games) => {
                            this.model.games = games;
                            this.tempGames = JSON.parse(JSON.stringify(this.model.games));
                            if (choice == 5.1 || choice == 5.2) {
                                this.splitGamesInHalf(choice);
                            }
                            console.log(games);
                        });
                    }
                    catch (e) {
                        console.log(e);
                        this.loadingGetSingleDrawPosition = false;
                    }
                };
                this.sets = [[6, 3], [7, 5]];
                if (model.selectBtn == 5) {
                    model.selectBtn = 5.1;
                }
                this.initDrawTitle();
            }
            initDrawTitle() {
                this.drawTitle = [
                    { label: "Prima parte 3° Turno", drawPosition: 5.1 },
                    { label: "Seconda parte 3° Turno", drawPosition: 5.2 },
                    { label: "Ottavi di Finale", drawPosition: 4 },
                    { label: "Quarti di Finale", drawPosition: 3 },
                    { label: "Semifinale", drawPosition: 2 },
                    { label: "Finale", drawPosition: 1 }
                ];
            }
            get selectedLabel() {
                const found = this.drawTitle.find(x => x.drawPosition == this.model.selectBtn);
                return found ? found.label : '';
            }
            async getJson(url) {
                let res = await fetch(url, {
                    method: "GET",
                    headers: {
                        'Accept': 'application/json',
                        'X-Requested-With': 'XMLHttpRequest',
                    },
                    credentials: "same-origin",
                });
                return res;
            }
            async getJsonT(url) {
                const response = await this.getJson(url);
                return await response.json();
            }
            splitGamesInHalf(select) {
                const allGames = this.tempGames;
                const half = Math.floor(allGames.length / 2);
                if (select == 5.1) {
                    this.model.games = allGames.slice(0, half);
                }
                else if (select == 5.2) {
                    this.model.games = allGames.slice(half);
                }
            }
            get filteredGames() {
                if (!this.model.games)
                    return [];
                if (!this.playerNameFilter.trim())
                    return this.model.games;
                const filter = this.playerNameFilter.trim().toLowerCase();
                return this.model.games.filter(g => (g.player1.name && g.player1.name.toLowerCase().includes(filter)) ||
                    (g.player2.name && g.player2.name.toLowerCase().includes(filter)));
            }
        }
        Draw.drawVueModel = drawVueModel;
    })(Draw = Tournaments.Draw || (Tournaments.Draw = {}));
})(Tournaments || (Tournaments = {}));
//# sourceMappingURL=Draw.js.map