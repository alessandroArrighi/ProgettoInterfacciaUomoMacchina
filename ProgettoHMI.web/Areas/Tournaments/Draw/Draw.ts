module Tournaments.Draw {
    export class drawVueModel {

        loadingGetSingleDrawPosition: boolean = false;
        sets: number[][] = [];
        tempGames: Draw.Server.IGameModel[] | null = null;
        public playerNameFilter: string = "";
        public drawTitle: { label: string, drawPosition: number }[];

        constructor(public model: Draw.Server.drawViewModel) {
            this.sets = [[6,3],[7,5]];
            if (model.selectBtn == 5) {
                model.selectBtn = 5.1
            }
            this.initDrawTitle();
        }

        private initDrawTitle() {
            this.drawTitle = [
                { label: "Prima parte 3° Turno", drawPosition: 5.1 },
                { label: "Seconda parte 3° Turno", drawPosition: 5.2 },
                { label: "Ottavi di Finale", drawPosition: 4 },
                { label: "Quarti di Finale", drawPosition: 3 },
                { label: "Semifinale", drawPosition: 2 },
                { label: "Finale", drawPosition: 1 }
            ]
        }

        get selectedLabel() {
            const found = this.drawTitle.find(x => x.drawPosition == this.model.selectBtn);
            return found ? found.label : '';
        }

        public getSingleDrawPosition = async (pos: number) => {
            try {
                this.tempGames = null;
                this.loadingGetSingleDrawPosition = true;
                const choice = this.model.selectBtn;

                var url: string = this.model.urlRaw + "?position=" + pos + "&tournamentId=" + this.model.tournamentId;

                await this.getJsonT<Draw.Server.IGameModel[]>(url).then((games) => {
                    
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
        }

        public async getJson(url: string): Promise<Response> {
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

        public async getJsonT<T>(url: string): Promise<T> {
            const response = await this.getJson(url);
            return await response.json();
        }

        public splitGamesInHalf(select: number): void {


            const allGames = this.tempGames;
            const half = Math.floor(allGames.length / 2);

            if (select == 5.1) {
                this.model.games = allGames.slice(0, half);
            } else if (select == 5.2) {
                this.model.games = allGames.slice(half);
            }
        }

        public get filteredGames(): Draw.Server.IGameModel[] {
            if (!this.model.games) return [];
            if (!this.playerNameFilter.trim()) return this.model.games;
            
            const filter = this.playerNameFilter.trim().toLowerCase();
            return this.model.games.filter(g =>
                (g.player1.name && g.player1.name.toLowerCase().includes(filter)) ||
                (g.player2.name && g.player2.name.toLowerCase().includes(filter))
            );
        }
    }
}   