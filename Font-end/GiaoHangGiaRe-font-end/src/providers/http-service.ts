import { Http, Headers, RequestOptions, URLSearchParams } from '@angular/http';
import { config } from '../providers/config';
import { Observable } from 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { Router } from '@angular/router';

@Injectable()
export class HttpService {
    base_url: string;
    constructor(public http: Http, private router: Router) {
        this.base_url = config.host;
    }
    buildHeaders(params?: URLSearchParams): any {
        let headers = new Headers({ 'Content-Type': 'application/json' });

        if (localStorage.getItem('userProfile')) {
            let userProfile = JSON.parse(localStorage.getItem('userProfile'));
            headers.append('Authorization', userProfile.token_type + ' ' + userProfile.access_token);
        }
        const options = new RequestOptions({ headers: headers });
        if(params){
            options.search =  params;
        }
        return options;
    }
    get(inner_url: string, params?: URLSearchParams ): any {
        if(!params){
            params = new URLSearchParams();
        }
        return Observable
            .from(this.http.get(this.base_url + inner_url , this.buildHeaders(params)).map(res => res.json()))
            .do(data => {

            }, err => {
                if (err.status == 401) {
                    err = err.json();
                    alert(err.Message);
                    this.router.navigateByUrl('/login');
                }
                if (err.status == 500) {
                    err = err.json();
                    alert(err.Message);
                }
            });
    };
    put(inner_url: string, input: any): any {
        return Observable
            .from(this.http.put(this.base_url + inner_url, input, this.buildHeaders()).map(res => res.json()))
            .do(data => {

            }, err => {
                if (err.status == 401) {
                    err = err.json();
                    alert(err.Message);
                    this.router.navigateByUrl('/login');
                }
                if (err.status == 500) {
                    err = err.json();
                    alert(err.Message);
                }
            });
    };
    post(inner_url: string, input: any): any {
        return Observable
            .from(this.http.post(this.base_url + inner_url, input, this.buildHeaders()).map(res => res.json()))
            .do(data => {

            }, err => {
                if (err.status == 401) {
                    err = err.json();
                    alert(err.Message);
                    this.router.navigateByUrl('/login');
                }
                if (err.status == 500) {
                    err = err.json();
                    alert(err.Message);
                }
            });
    };
}
