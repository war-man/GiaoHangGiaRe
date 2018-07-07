import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DonhangFormComponent } from './donhang-form.component';

describe('DonhangFormComponent', () => {
  let component: DonhangFormComponent;
  let fixture: ComponentFixture<DonhangFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DonhangFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DonhangFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
