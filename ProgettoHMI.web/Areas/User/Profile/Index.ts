module User.Profile {
    export class profileVueModel {
        constructor(public tournaments: User.Profile.Server.ITournamentModel[], public selectedSection: number) {
            selectedSection = selectedSection ?? 0;
        }
    }
}