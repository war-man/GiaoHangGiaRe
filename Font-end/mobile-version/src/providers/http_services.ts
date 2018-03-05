export const config = {
    host: 'http://localhost:8195/'
}
import { Http, Headers } from '@angular/http';
import { HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/Rx';
import { UserData } from '../providers/user-data';
import { Injectable } from '@angular/core';
@Injectable()
export class HttpService {
    base_url: string;
    constructor(public http: Http, public userData: UserData, ) {
        this.base_url = config.host;
    }
    buildHeaders() {
        let headers = new Headers({ "Content-Type": "application/json" });
        return this.userData.getUserAuth().then((userAuth) => {
            if (userAuth) {
                headers.append('Authorization', userAuth.token_type + ' ' + userAuth.access_token);
                return headers;
            } else {
                return headers;
            }
        })
    }
    get(inner_url: string, params1?: HttpParams) {
        if (!params1) {
            params1 = new HttpParams();
        }
        return Observable
            .fromPromise(this.buildHeaders())
            .switchMap((headers) =>
                this.http.get(this.base_url + inner_url, { headers: headers, params: params1.toString() }).map(res => res.json()))
            .do(done => {
                console.log(done);
            }, err => {
                console.log(err);
            })
    }
    post(inner_url, input?: any, params1?: HttpParams) {
        if (!params1) {
            params1 = new HttpParams();
        }
        return Observable
            .fromPromise(this.buildHeaders())
            .switchMap((headers) => this.http.post(this.base_url + inner_url, input, { headers: headers, params: params1.toString() }).map(res => res.json()))
            .do(done => {
                console.log(done);
            }, err => {
                console.log(err);
            })
    }
    put(inner_url, input?: any, params1?: HttpParams) {
        if (!params1) {
            params1 = new HttpParams();
        }
        return Observable
            .fromPromise(this.buildHeaders())
            .switchMap((headers) => this.http.put(this.base_url + inner_url, JSON.stringify(input), { headers: headers, params: params1.toString() }).map(res => res.json()))
            .do(done => {
                console.log(done);
            }, err => {
                console.log(err);
            })
    }
}