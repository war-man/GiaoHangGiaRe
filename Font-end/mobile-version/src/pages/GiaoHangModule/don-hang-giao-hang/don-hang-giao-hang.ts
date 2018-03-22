import { Component } from '@angular/core';
import { config } from '../../../providers/http_services';
import { NavController, NavParams } from 'ionic-angular';
import {DonhangServicesProvider} from '../../../providers/donhang-services/donhang-services';
import { HubConnection } from '@aspnet/signalr-client';

/**
 * Generated class for the DonHanGiaoHangPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@Component({
  selector: 'page-don-hang-giao-hang',
  templateUrl: 'don-hang-giao-hang.html',
})
export class DonHangGiaoHangPage {
  private hubConnection: HubConnection;
  nick = '';
  message = '';
  messages: string[] = [];
  listDonHang: any;
  constructor(public navCtrl: NavController, public navParams: NavParams,
  public DonhangServices: DonhangServicesProvider) {
    this.DonhangServices.getAllDonHangShipper().then(res =>{
      this.listDonHang = res.list;
      console.log(this.listDonHang);
    })
  }

  ngOnInit() {
    
    this.nick = 'John';

    this.hubConnection = new HubConnection(config.host);
    this.hubConnection
      .start()
      .then(() => console.log('Connection started!'))
      .catch(() => console.log('Error while establishing connection :('));
      this.hubConnection.on('sendToAll', (nick: string, receivedMessage: string) => {
        const text = `${nick}: ${receivedMessage}`;
        this.messages.push(text);
      });
  }

  public sendMessage(): void {
    this.hubConnection
      .invoke('sendToAll', this.nick, this.message)
      .catch(err => console.error(err));
  }

}
