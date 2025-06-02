declare module Tournaments.Live.Server {
    interface IndexViewModelInterface {
        public tournaments: TournamentViewModelInterface[];
        public games: IGameModel[]
        public urlFilters: string
        public urlGames: string
    }

    interface TournamentViewModelInterface {
        public id: number;
        public name: string;
        public rankId: string;
        public imgRank: string;
    }

    interface TournamentsFilterQueryViewModelInterface {
        public city: list<string>;
        public rank: list<number>;
        public startDate: Date;
        public endDate: Date;
        public status: number;
    }

    interface TournamentCityFiltersViewModelInterface {
        public value: string;
        public selected: boolean;
    }

    interface TournamentRankFiltersViewModelInterface {
        public value: string;
        public label: string
        public selected: boolean;
    }

    interface IGameModel {
        gameId: string;
        drawPosition: number;
        status: number;
        player1: User;
        player2: User;
        score: Score;
    }

    interface User {
        id: string;
        name: string;
        rank: Rank;
    }

    interface Rank {
        points: number;
        id: number;
        name: string;
        imgRank: string;
    }

    interface Score {
        set: ScoreSet[];
    }

    interface ScoreSet {
        score1: number;
        score2: number;
    }
}