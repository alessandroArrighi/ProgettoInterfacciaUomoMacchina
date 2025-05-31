declare module Tournaments.Live.Server {
    interface IndexViewModelInterface {
        public tournaments: TournamentViewModelInterface[];
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

    interface TournamentFiltersViewModelInterface {
        public value: string;
        public selected: boolean;
    }
}