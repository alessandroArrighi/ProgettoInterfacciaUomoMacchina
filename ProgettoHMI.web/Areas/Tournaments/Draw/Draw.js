var Tournaments;
(function (Tournaments) {
    var Draw;
    (function (Draw) {
        class drawVueModel {
            constructor(model, selectBtn) {
                this.model = model;
                this.selectBtn = selectBtn;
                model.sets = [[6, 3], [6, 3], [5, 7], [6, 4]];
            }
        }
        Draw.drawVueModel = drawVueModel;
    })(Draw = Tournaments.Draw || (Tournaments.Draw = {}));
})(Tournaments || (Tournaments = {}));
//# sourceMappingURL=Draw.js.map