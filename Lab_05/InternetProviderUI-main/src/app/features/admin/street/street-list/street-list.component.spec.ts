import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StreetListComponent } from './street-list.component';

describe('StreetListComponent', () => {
  let component: StreetListComponent;
  let fixture: ComponentFixture<StreetListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StreetListComponent]
    });
    fixture = TestBed.createComponent(StreetListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
