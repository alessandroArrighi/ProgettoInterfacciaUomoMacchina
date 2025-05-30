declare module Tournaments.Draw.Server {

    interface drawViewModel {
        games: IGames;
        selectBtn: number;
        urlRaw: string;
    }

    interface IGames {
        games: IGameModel[];
    }

    interface IGameModel {
        gameId: string;
        drawPosition: number;
        status: number;
        player1Id: string;
        player2Id: string;
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
