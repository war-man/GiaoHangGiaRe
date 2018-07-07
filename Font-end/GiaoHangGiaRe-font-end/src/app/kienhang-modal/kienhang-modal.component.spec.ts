import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KienhangModalComponent } from './kienhang-modal.component';

describe('KienhangModalComponent', () => {
  let component: KienhangModalComponent;
  let fixture: ComponentFixture<KienhangModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KienhangModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KienhangModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
