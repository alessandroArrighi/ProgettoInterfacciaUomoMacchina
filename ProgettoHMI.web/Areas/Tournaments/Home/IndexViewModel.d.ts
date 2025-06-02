declare module Tournaments.Home.Server {
    interface indexViewModel {
        tournament: tournamentViewModel
        users: userViewModel[]
        isLogged: boolean
        userId: any
        registerUrl: string
    }

    interface tournamentViewModel {
        id: any
        name: string
        startDate: Date
        RankId: number
        rankName: string
        ImgRank: string
        club: string
        startDate: Date
        endDate: Date
        image: string
        city: string
        status: number
    }

    interface rankViewModel {
        id: string
        name: string
        imgRank: string
        points: number
    }

    interface userViewModel {
        id: any
        name: string
        surname: string
        rank: rankViewModel
        imgProfile: string
    }
}