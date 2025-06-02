declare module Tournaments.Draw.Server {

    interface drawViewModel {
        games: IGameModel[];
        selectBtn: number;
        urlRaw: string;
        tournamentId: string;
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
