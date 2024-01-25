import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddDataComponent } from './AddData.component';

describe('AddDataService', () => {
  let component: AddDataComponent;
  let fixture: ComponentFixture<AddDataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddDataComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
