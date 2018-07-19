import { Component, ViewChild, ElementRef } from '@angular/core';
import { Geolocation } from '@ionic-native/geolocation';
import { ConferenceData } from '../../providers/conference-data';

import { Platform } from 'ionic-angular';


declare var google: any;


@Component({
  selector: 'page-map',
  templateUrl: 'map.html'
})
export class MapPage {
  position: any;
  @ViewChild('mapCanvas') mapElement: ElementRef;
  constructor(public confData: ConferenceData,
    private geolocation: Geolocation, public platform: Platform) {
  }
    ngOnInit(){
      this.geolocation.getCurrentPosition().then((resp) => {
        // resp.coords.latitude
        // resp.coords.longitude
        this.position.latitude = resp.coords.latitude;
        this.position.longitude = resp.coords.longitude;
        console.log(resp);
       }).catch((error) => {
         console.log('Error getting location', error);
       });
       
       let watch = this.geolocation.watchPosition();
       watch.subscribe((data) => {
        // data can be a set of coordinates, or an error (if an error occurred).
        // data.coords.latitude
        // data.coords.longitude
        console.log(data);
       });
    }
  ionViewDidLoad() {
   
      this.confData.getMap().subscribe((mapData: any) => {
        let mapEle = this.mapElement.nativeElement;

        let map = new google.maps.Map(mapEle, {
          center: mapData.find((d: any) => d.center),
          zoom: 16
        });

        mapData.forEach((markerData: any) => {
          let infoWindow = new google.maps.InfoWindow({
            content: `<h5>${markerData.name}</h5>`
          });

          let marker = new google.maps.Marker({
            position: markerData,
            map: map,
            title: markerData.name
          });

          marker.addListener('click', () => {
            infoWindow.open(map, marker);
          });
        });

        google.maps.event.addListenerOnce(map, 'idle', () => {
          mapEle.classList.add('show-map');
        });

      });

  }
}
