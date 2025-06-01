var User;
(function (User) {
    var Profile;
    (function (Profile) {
        class profileVueModel {
            constructor(tournaments, selectedSection) {
                this.tournaments = tournaments;
                this.selectedSection = selectedSection;
                selectedSection = selectedSection !== null && selectedSection !== void 0 ? selectedSection : 0;
            }
        }
        Profile.profileVueModel = profileVueModel;
    })(Profile = User.Profile || (User.Profile = {}));
})(User || (User = {}));
//# sourceMappingURL=Index.js.map