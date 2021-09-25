"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.SignInService = void 0;
var SignInService = /** @class */ (function () {
    function SignInService(hostname) {
        this.hostname = hostname;
    }
    SignInService.prototype.Login = function (payload, success, error) {
        return $.ajax('api/sign-in/login', {
            type: 'post',
            data: JSON.stringify(payload),
            success: function () { }
        });
    };
    return SignInService;
}());
exports.SignInService = SignInService;
//# sourceMappingURL=sign-in-service.js.map