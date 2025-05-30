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
                this.getSingleDrawPosition = async (pos) => {
                    try {
                        this.tempGames = null;
                        this.loadingGetSingleDrawPosition = true;
                        const choice = this.model.selectBtn;
                        var url = this.model.urlRaw + "?position=" + pos;
                        await this.getJsonT(url).then((games) => {
                            this.model.games = games;
                            this.tempGames = JSON.parse(JSON.stringify(games));
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
            }
            cons() {
                console.log("dentro alla func");
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
                const allGames = this.tempGames.games;
                const half = Math.floor(allGames.length / 2);
                if (select == 5.1) {
                    this.model.games.games = allGames.slice(0, half);
                }
                else if (select == 5.2) {
                    this.model.games.games = allGames.slice(half);
                }
            }
        }
        Draw.drawVueModel = drawVueModel;
    })(Draw = Tournaments.Draw || (Tournaments.Draw = {}));
})(Tournaments || (Tournaments = {}));
//# sourceMappingURL=Draw.js.map