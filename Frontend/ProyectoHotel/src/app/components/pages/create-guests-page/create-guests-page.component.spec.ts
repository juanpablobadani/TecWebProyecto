import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateGuestsPageComponent } from './create-guests-page.component';

describe('CreateGuestsPageComponent', () => {
  let component: CreateGuestsPageComponent;
  let fixture: ComponentFixture<CreateGuestsPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateGuestsPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateGuestsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
