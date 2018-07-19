import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss']
})
export class ContactComponent implements OnInit {
  contactForm: FormGroup;
  title: string = 'My first AGM project';
  lat: number = 20.976479;
  lng: number = 105.815679;
  constructor(private formBuilder: FormBuilder) { 
    this.contactForm = this.formBuilder.group({
      HoTen: ['', [Validators.required]],
      Email: ['', [Validators.required]],
      NoiDung: ['', [Validators.required]],
    });
  }

  ngOnInit() {
  }
  submitData(){
    if(this.contactForm.valid){
      console.log(this.contactForm.value);
    }
  }

}
