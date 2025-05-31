declare module Tournaments.Draw.Server {

    interface drawViewModel {
        games: IGameModel[];
        selectBtn: number;
        urlRaw: string;
    }

    interface IGameModel {
        gameId: string;
        drawPosition: number; // -1
        status: number; // -1
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
