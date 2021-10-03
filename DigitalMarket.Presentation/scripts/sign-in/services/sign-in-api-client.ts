import { HttpClient } from "../../http/http-client";

export class SignInApiClient {
    private readonly http: HttpClient;

    constructor() {
        this.http = new HttpClient(`https://${location.host}`);
    }

    public async login() {

    }
}