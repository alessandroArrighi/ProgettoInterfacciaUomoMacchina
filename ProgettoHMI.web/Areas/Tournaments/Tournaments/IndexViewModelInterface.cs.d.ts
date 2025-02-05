declare module Tournaments.Tournaments.Server {
    interface IndexViewModelInterface {
        public tournaments: TournamentListViewModelInterface[];
    }

    interface TournamentListViewModelInterface {
        public name: string;
        public rank: string;
    }
}