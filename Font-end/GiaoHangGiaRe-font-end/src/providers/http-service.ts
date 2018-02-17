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
        const headers = new Headers({ 'Content-Type': 'application/json' });
        if (localStorage.getItem('access_token')) {
            headers.append('access_token', localStorage.getItem('access_token'));
        }
        return headers;
    }
    get(inner_url: string): any {
        return Observable
            .from(this.http.get(this.base_url + inner_url, this.buildHeaders()).map(res => res.json()));
    };
    put(inner_url: string, input: any): any {
        return Observable
            .from(this.http.put(this.base_url + inner_url, input, this.buildHeaders()).map(res => res.json()));
    };
    post(inner_url: string, input: any): any {
        return Observable
            .from(this.http.post(this.base_url + inner_url, input, this.buildHeaders()).map(res => res.json()));
    };
}
