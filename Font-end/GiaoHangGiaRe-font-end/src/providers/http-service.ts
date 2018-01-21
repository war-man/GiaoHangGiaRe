import { Http, Headers } from '@angular/http';
import { config } from '../providers/config';
import { Observable } from 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
@Injectable()
export class HttpService {
    base_url: string;
    constructor(public http: Http) {
        this.base_url = config.host;
    }
    buildHeaders(): any {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        if (localStorage.getItem('access_token')) {
            headers.append('access_token', localStorage.getItem('access_token'));
        }
        return headers;
    }
    get(inner_url: string): any {
        return new Promise((resolve, reject) => {
            this.http.get(this.base_url + inner_url, this.buildHeaders()).subscribe((res) => {
                resolve(res.json);
                console.log(res);
            });
        });
    };
}
