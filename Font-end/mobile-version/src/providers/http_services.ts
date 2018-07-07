export const config = {
     host: 'http://192.168.30.103:8080/',
     host2: 'http://192.168.30.103:8080/',
    // host: 'http://localhost:8195/',
    // host2: 'http://localhost:8195',
    //   host: 'http://localhost:8080/',
    // host2: 'http://localhost:8080',
}
import { LoadingController, Loading, AlertController} from 'ionic-angular';
import { Http, Headers } from '@angular/http';
import { HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/Rx';
import { UserData } from '../providers/user-data';
import { Injectable } from '@angular/core';
@Injectable()
export class HttpService {
    base_url: string;
    loading: Loading;
    constructor(public http: Http, public userData: UserData, public AlertCtr: AlertController,
     private loadingCtrl: LoadingController ) {
        this.base_url = config.host;
    }
    buildHeaders() {
        this.loading = this.loadingCtrl.create({
            spinner:'crescent',
            content: ''
        });
        this.loading.present();
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
                if(this.loading){
                    this.loading.dismiss();
                }
                console.log(done);
            }, err => {
                console.log(err);
                if(err.status == 401){
                    this.userData.logout();
                }
                if(this.loading){
                    this.loading.dismiss().then(() =>{
                        this.AlertCtr.create({
                            title: err.Text
                        })
                    })
                }
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
                if(this.loading){
                    this.loading.dismiss();
                }
            }, err => {
                console.log(err);
                if(this.loading){
                    this.loading.dismiss().then(() =>{
                        this.AlertCtr.create({
                            title: err.Text
                        })
                    })
                }
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
                if(this.loading){
                    this.loading.dismiss();
                }
            }, err => {
                console.log(err);
                if(this.loading){
                    this.loading.dismiss().then(() =>{
                        this.AlertCtr.create({
                            title: err.Text
                        })
                    })
                }
            })
    }
}