import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DonHangDetailsComponent } from './don-hang-details.component';

describe('DonHangDetailsComponent', () => {
  let component: DonHangDetailsComponent;
  let fixture: ComponentFixture<DonHangDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DonHangDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DonHangDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
