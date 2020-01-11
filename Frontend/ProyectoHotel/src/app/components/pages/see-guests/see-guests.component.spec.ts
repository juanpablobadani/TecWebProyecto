import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SeeGuestsComponent } from './see-guests.component';

describe('SeeGuestsComponent', () => {
  let component: SeeGuestsComponent;
  let fixture: ComponentFixture<SeeGuestsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SeeGuestsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SeeGuestsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
