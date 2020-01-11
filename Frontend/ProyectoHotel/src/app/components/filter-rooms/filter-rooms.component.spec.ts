import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FilterRoomsComponent } from './filter-rooms.component';

describe('FilterRoomsComponent', () => {
  let component: FilterRoomsComponent;
  let fixture: ComponentFixture<FilterRoomsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FilterRoomsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FilterRoomsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
