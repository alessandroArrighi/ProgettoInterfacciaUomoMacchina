declare module Tournaments.Tournaments.Server {
    interface IndexViewModelInterface {
        public tournaments: TournamentViewModelInterface[];
        public urlFilters: string
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
}