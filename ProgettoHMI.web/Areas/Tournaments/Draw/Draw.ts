module Tournaments.Draw {
    export class drawVueModel {
        constructor(public model: Torunaments.Draw.Server.drawViewModel, public selectBtn: number) {
            model.sets = [[6,3],[6,3],[5,7],[6,4]];
        }
    }
}   