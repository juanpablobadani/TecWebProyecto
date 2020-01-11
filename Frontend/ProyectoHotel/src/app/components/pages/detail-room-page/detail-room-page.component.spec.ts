import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailRoomPageComponent } from './detail-room-page.component';

describe('DetailRoomPageComponent', () => {
  let component: DetailRoomPageComponent;
  let fixture: ComponentFixture<DetailRoomPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetailRoomPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailRoomPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
