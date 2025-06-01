declare module User.Profile.Server {

    interface profileViewModel {
        tournaments: ITournamentModel[];
    }

    interface ITournamentModel {
        id: string;
        name: string;
        startDate: Date;
        endDate: Date;
        rank: Rank;
        image: string;
    }

    interface Rank {
        id: number;
        name: string;
        imgRank: string;
    }
}