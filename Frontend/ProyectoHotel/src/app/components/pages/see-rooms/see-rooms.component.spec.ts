import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SeeRoomsComponent } from './see-rooms.component';

describe('SeeRoomsComponent', () => {
  let component: SeeRoomsComponent;
  let fixture: ComponentFixture<SeeRoomsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SeeRoomsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SeeRoomsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
