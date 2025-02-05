module Tournaments.Tournaments {
    export class indexViewModel {
        public model: Tournaments.Server.IndexViewModelInterface;
        public prova: string;

        public constructor(model: Tournaments.Server.IndexViewModelInterface) {
            this.model = model;
        }
    }
}