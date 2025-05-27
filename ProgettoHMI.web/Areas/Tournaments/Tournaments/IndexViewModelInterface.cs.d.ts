declare module Tournaments.Tournaments.Server {
    interface IndexViewModelInterface {
        public tournaments: TournamentViewModelInterface[];
    }

    interface TournamentViewModelInterface {
        public id: number;
        public name: string;
        public rankId: string;
        public rankImg: string;
    }

    interface TournamentsFilterQueryViewModelInterface {
        public city: list<string>;
        public rank: list<number>;
        public startDate: Date;
        public endDate: Date;
    }
}